<?php

namespace App\Console\Commands;

use Illuminate\Console\Command;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Str;
use Carbon\Carbon;
use Throwable;

/**
 * Imports data from the old ASP.NET / SQL Server system (oldcodereference)
 * into a fresh, isolated MySQL database ("heeddatabase") so reports can be
 * generated in the new Laravel CRM without touching the live app database.
 *
 * Source connection:  config/database.php -> 'legacy'   (SQL Server, old system)
 * Target connection:  config/database.php -> 'heeddatabase' (MySQL, new isolated DB)
 *
 * Scope of this first pass (per user request): agents/brokers, arazis, plots,
 * customers, customer_bonds, registries, customer_bond_payments.
 * NOT included yet: call-center/dialer tables, advocate/legal tables,
 * wallets/ledgers, receipt-reversal history — these had no equivalent table
 * in the new schema (see earlier schema-comparison discussion).
 *
 * SAFETY: defaults to --dry-run (reads the legacy DB, prints counts/samples,
 * writes NOTHING). Pass --commit to actually insert into heeddatabase.
 *
 * Usage:
 *   php artisan legacy:import                 # dry run, all steps
 *   php artisan legacy:import --commit         # actually import
 *   php artisan legacy:import --only=agents,arazis --commit
 */
class ImportLegacyData extends Command
{
    protected $signature = 'legacy:import
        {--commit : Actually write to heeddatabase. Without this flag, nothing is written.}
        {--only= : Comma separated list of steps to run: agents,arazis,plots,customers,payments}
        {--limit=0 : For testing — cap number of legacy rows processed per step (0 = no limit)}';

    protected $description = 'Import agents/arazis/plots/customers/customer_bonds/registries/payments from the old SQL Server system into the isolated heeddatabase MySQL database';

    /** @var bool */
    protected $commit = false;

    /** @var int */
    protected $limit = 0;

    /** Legacy formid => new agents.id */
    protected array $agentMap = [];

    /** Legacy arazi code (APPNO / arazimap.arazi) => new arazis.id */
    protected array $araziMap = [];

    /** "arazi_id|title" => new plots.id */
    protected array $plotMap = [];

    /** Legacy CUSTREGNO (namespaced) => new customers.id */
    protected array $customerMap = [];

    /** Legacy CUSTREGNO (namespaced) => new registries.id */
    protected array $registryMap = [];

    protected int $placeholderKisanId;

    public function handle(): int
    {
        $this->commit = (bool) $this->option('commit');
        $this->limit = (int) $this->option('limit');

        $only = $this->option('only')
            ? array_map('trim', explode(',', $this->option('only')))
            : ['agents', 'arazis', 'plots', 'customers', 'payments'];

        if (! $this->commit) {
            $this->warn('DRY RUN — nothing will be written to heeddatabase. Pass --commit to actually import.');
        }

        try {
            DB::connection('legacy')->getPdo();
        } catch (Throwable $e) {
            $this->error('Could not connect to the legacy SQL Server DB. Check LEGACY_DB_HOST/PORT/DATABASE/USERNAME/PASSWORD in .env.');
            $this->error($e->getMessage());

            return self::FAILURE;
        }

        if ($this->commit) {
            try {
                DB::connection('heeddatabase')->getPdo();
            } catch (Throwable $e) {
                $this->error('Could not connect to heeddatabase. Create the MySQL database "heeddatabase" first (e.g. CREATE DATABASE heeddatabase;) and run: php artisan migrate --database=heeddatabase');
                $this->error($e->getMessage());

                return self::FAILURE;
            }
        }

        if (in_array('agents', $only)) {
            $this->importAgents();
        }

        if (in_array('arazis', $only)) {
            $this->importArazis();
        }

        if (in_array('plots', $only)) {
            $this->importPlots();
        }

        if (in_array('customers', $only)) {
            // customers + customer_bonds + registries all come from the same
            // legacy source row (wjstar1.customerreg1), so one step.
            $this->importCustomersBondsAndRegistries();
        }

        if (in_array('payments', $only)) {
            $this->importPayments();
        }

        $this->info($this->commit ? 'Import complete.' : 'Dry run complete. Re-run with --commit to actually write data.');

        return self::SUCCESS;
    }

    /**
     * Source: dbo.agent
     * Columns confirmed from oldcodereference/chain system/admin/ADDAGENT.aspx.cs:
     *   formid, agentid (sponsor formid), rank, name, mobile, agentper, ...
     */
    protected function importAgents(): void
    {
        $this->line('--- agents ---');

        $rows = $this->legacyQuery('SELECT formid, agentid, rank, name, mobile, agentper FROM agent');

        $this->info('Legacy agent rows found: '.count($rows));
        if (empty($rows)) {
            return;
        }
        $this->table(array_keys((array) $rows[0]), array_slice(array_map(fn ($r) => (array) $r, $rows), 0, 5));

        if (! $this->commit) {
            return;
        }

        // Pass 1: insert every agent without sponsor link.
        foreach ($rows as $row) {
            $formId = trim((string) $row->formid);
            if ($formId === '') {
                continue;
            }

            $existing = DB::connection('heeddatabase')->table('agents')->where('form_code', $formId)->first();
            if ($existing) {
                $this->agentMap[$formId] = $existing->id;

                continue;
            }

            $id = DB::connection('heeddatabase')->table('agents')->insertGetId([
                'form_code' => $formId,
                'name' => trim((string) $row->name) ?: 'Unknown (legacy '.$formId.')',
                'mobile' => $this->cleanMobile($row->mobile),
                'rank_title' => $row->rank ?: null,
                'commission_percentage' => $this->toDecimal($row->agentper),
                'legacy_percent' => $this->toDecimal($row->agentper),
                'broker_type' => 'customer',
                'created_at' => now(),
                'updated_at' => now(),
            ]);

            $this->agentMap[$formId] = $id;
        }

        // Pass 2: now that all agents exist, wire up sponsor_agent_id.
        foreach ($rows as $row) {
            $formId = trim((string) $row->formid);
            $sponsorFormId = trim((string) $row->agentid);
            if ($formId === '' || $sponsorFormId === '' || ! isset($this->agentMap[$formId]) || ! isset($this->agentMap[$sponsorFormId])) {
                continue;
            }
            if ($this->agentMap[$formId] === $this->agentMap[$sponsorFormId]) {
                continue; // avoid self-reference
            }

            DB::connection('heeddatabase')->table('agents')
                ->where('id', $this->agentMap[$formId])
                ->update(['sponsor_agent_id' => $this->agentMap[$sponsorFormId]]);
        }

        $this->info('Agents imported: '.count($this->agentMap));
    }

    /**
     * Source: dbo.arazimap (arazi, plotno, status, custregno) — the "arazi"
     * column holds the project/arazi code (e.g. '100' for the arazi100 folder).
     * We only need DISTINCT arazi codes here; per-plot rows are handled in
     * importPlots().
     *
     * NOTE: the legacy schema does not give us a clean farmer(kisan) owner
     * per arazi in the tables inspected so far. Every imported arazi is
     * attached to a single placeholder "Legacy Import" kisan so the NOT NULL
     * kisan_id foreign key is satisfied. Re-attribute real kisans later via
     * a follow-up script once/if the correct legacy source table is found.
     */
    protected function importArazis(): void
    {
        $this->line('--- arazis ---');

        if ($this->commit) {
            $this->placeholderKisanId = $this->ensurePlaceholderKisan();
        }

        $rows = $this->legacyQuery('SELECT DISTINCT arazi FROM arazimap WHERE arazi IS NOT NULL AND arazi <> \'\'');

        $this->info('Distinct legacy arazi codes found: '.count($rows));

        if (! $this->commit) {
            $this->line(implode(', ', array_slice(array_map(fn ($r) => $r->arazi, $rows), 0, 20)).(count($rows) > 20 ? ' ...' : ''));

            return;
        }

        foreach ($rows as $row) {
            $code = trim((string) $row->arazi);
            if ($code === '') {
                continue;
            }

            $existing = DB::connection('heeddatabase')->table('arazis')->where('legacy_arazi_code', $code)->first();
            if ($existing) {
                $this->araziMap[$code] = $existing->id;

                continue;
            }

            $id = DB::connection('heeddatabase')->table('arazis')->insertGetId([
                'kisan_id' => $this->placeholderKisanId,
                'legacy_arazi_code' => $code,
                'location' => 'Arazi '.$code.' (imported)',
                'plot_number' => $code,
                'total_area' => 0,
                'size' => 0,
                'status' => 'available',
                'created_at' => now(),
                'updated_at' => now(),
            ]);

            $this->araziMap[$code] = $id;
        }

        $this->info('Arazis imported: '.count($this->araziMap));
    }

    /**
     * Source: dbo.arazimap (arazi, plotno, status)
     * Per CLAUDE.md convention: a plot is identified by its `title` (exact
     * match, scoped to arazi_code), never `plot_number`.
     */
    protected function importPlots(): void
    {
        $this->line('--- plots ---');

        if (empty($this->araziMap)) {
            $this->rebuildAraziMap();
        }

        $rows = $this->legacyQuery('SELECT arazi, plotno, status FROM arazimap WHERE plotno IS NOT NULL AND plotno <> \'\''.$this->limitSql());

        $this->info('Legacy plot rows found: '.count($rows));

        if (! $this->commit) {
            return;
        }

        $count = 0;
        foreach ($rows as $row) {
            $araziCode = trim((string) $row->arazi);
            $title = trim((string) $row->plotno);
            if ($araziCode === '' || $title === '' || ! isset($this->araziMap[$araziCode])) {
                continue;
            }
            $araziId = $this->araziMap[$araziCode];
            $key = $araziId.'|'.$title;
            if (isset($this->plotMap[$key])) {
                continue;
            }

            $existing = DB::connection('heeddatabase')->table('plots')
                ->where('arazi_id', $araziId)
                ->where('title', $title) // exact match, never LIKE — per project convention
                ->first();
            if ($existing) {
                $this->plotMap[$key] = $existing->id;

                continue;
            }

            $id = DB::connection('heeddatabase')->table('plots')->insertGetId([
                'arazi_id' => $araziId,
                'arazi_code' => $araziCode,
                'plot_number' => $title,
                'title' => $title,
                'status' => $this->mapPlotStatus($row->status),
                'size_unit' => 'gaz',
                'type' => 'residential',
                'price' => 0,
                'created_at' => now(),
                'updated_at' => now(),
            ]);

            $this->plotMap[$key] = $id;
            $count++;
        }

        $this->info('Plots imported: '.$count);
    }

    /**
     * Source: wjstar1.customerreg1 (richest of the customerreg1/2/3 legacy
     * tables). Columns confirmed from
     * oldcodereference/home/regcertificate.aspx.cs:
     *   CUSTREGNO, NAMEDOBADDRESS, APPNO, PLOTSIZE, mobile, mobile2, mobile3,
     *   idcard, CONSAMOUNT, INSTSUBPAY, date3, lastdate, EXPIRYDATE, downpay,
     *   plotno, AGENCYID, NOMINEESNAME, RECIPTNO, AMOUNTWORD, lockreg,
     *   CHECKBY, usertype, ragistry, ragistryamt
     *
     * One legacy row fans out into THREE new tables: customers,
     * customer_bonds, registries — the legacy table was a flat "everything
     * about this customer's plot deal" record; the new schema normalizes it.
     *
     * CUSTREGNO is only guaranteed unique WITHIN customerreg1 (other legacy
     * projects have their own customerreg2/customerreg3 with possibly
     * overlapping numbers), so we namespace it as "customerreg1:<CUSTREGNO>"
     * when storing legacy_customer_code / customer_reg_no to avoid collisions.
     */
    protected function importCustomersBondsAndRegistries(): void
    {
        $this->line('--- customers / customer_bonds / registries (from wjstar1.customerreg1) ---');

        if (empty($this->araziMap)) {
            $this->rebuildAraziMap();
        }
        if (empty($this->agentMap)) {
            $this->rebuildAgentMap();
        }
        if (empty($this->plotMap)) {
            $this->rebuildPlotMap();
        }

        $rows = $this->legacyQuery('SELECT CUSTREGNO, NAMEDOBADDRESS, APPNO, PLOTSIZE, mobile, mobile2, mobile3, idcard,
                CONSAMOUNT, INSTSUBPAY, date3, lastdate, EXPIRYDATE, downpay, plotno, AGENCYID,
                NOMINEESNAME, RECIPTNO, AMOUNTWORD, lockreg, usertype, ragistry, ragistryamt
            FROM wjstar1.customerreg1'.$this->limitSql());

        $this->info('Legacy customerreg1 rows found: '.count($rows));

        if (! $this->commit) {
            if (! empty($rows)) {
                $this->table(array_keys((array) $rows[0]), array_slice(array_map(fn ($r) => (array) $r, $rows), 0, 5));
            }

            return;
        }

        $custCount = 0;
        $bondCount = 0;
        $regCount = 0;

        foreach ($rows as $row) {
            $custRegNo = trim((string) $row->CUSTREGNO);
            if ($custRegNo === '') {
                continue;
            }
            $legacyCode = 'customerreg1:'.$custRegNo;

            $araziCode = trim((string) $row->APPNO);
            $araziId = $this->araziMap[$araziCode] ?? null;
            $agentFormId = trim((string) $row->AGENCYID);
            $brokerId = $this->agentMap[$agentFormId] ?? null;
            $plotTitle = trim((string) $row->plotno);
            $plotId = ($araziId && $plotTitle !== '') ? ($this->plotMap[$araziId.'|'.$plotTitle] ?? null) : null;

            // --- customers ---
            $customerId = $this->customerMap[$legacyCode] ?? null;
            if (! $customerId) {
                $existing = DB::connection('heeddatabase')->table('customers')->where('legacy_customer_code', $legacyCode)->first();
                if ($existing) {
                    $customerId = $existing->id;
                } else {
                    $customerId = DB::connection('heeddatabase')->table('customers')->insertGetId([
                        'legacy_customer_code' => $legacyCode,
                        'name' => $this->extractName($row->NAMEDOBADDRESS) ?: 'Unknown (legacy '.$custRegNo.')',
                        'mobile' => $this->cleanMobile($row->mobile) ?: '0000000000',
                        'secondary_mobile' => $this->cleanMobile($row->mobile2),
                        'id_document_no' => $row->idcard ?: null,
                        'address' => $this->extractAddress($row->NAMEDOBADDRESS) ?: 'Unknown',
                        'created_at' => now(),
                        'updated_at' => now(),
                    ]);
                    $custCount++;
                }
                $this->customerMap[$legacyCode] = $customerId;
            }

            if (! $araziId) {
                // Can't create a customer_bond/registry without a valid arazi FK.
                continue;
            }

            // --- customer_bonds ---
            $existingBond = DB::connection('heeddatabase')->table('customer_bonds')->where('bond_no', $legacyCode)->first();
            if (! $existingBond) {
                DB::connection('heeddatabase')->table('customer_bonds')->insert([
                    'customer_id' => $customerId,
                    'arazi_id' => $araziId,
                    'arazi_code' => $araziCode,
                    'bond_no' => $legacyCode,
                    'bond_date' => $this->parseDate($row->date3) ?? now()->toDateString(),
                    'bond_amount' => $this->toDecimal($row->CONSAMOUNT),
                    'land_size' => $row->PLOTSIZE ?: null,
                    'installment_amount' => $this->toDecimal($row->INSTSUBPAY),
                    'last_date' => $this->parseDate($row->lastdate),
                    'expiry_date' => $this->parseDate($row->EXPIRYDATE),
                    'witness_name' => $row->NOMINEESNAME ?: null,
                    'broker_id' => $brokerId,
                    'notes' => 'Imported from legacy wjstar1.customerreg1 CUSTREGNO='.$custRegNo,
                    'created_at' => now(),
                    'updated_at' => now(),
                ]);
                $bondCount++;
            }

            // --- registries ---
            $existingReg = DB::connection('heeddatabase')->table('registries')->where('customer_reg_no', $legacyCode)->first();
            if (! $existingReg) {
                $registryId = DB::connection('heeddatabase')->table('registries')->insertGetId([
                    'registry_code' => $legacyCode,
                    'receipt_no' => $row->RECIPTNO ?: null,
                    'customer_reg_no' => $legacyCode,
                    'customer_id' => $customerId,
                    'arazi_id' => $araziId,
                    'arazi_code' => $araziCode,
                    'agent_id' => $brokerId,
                    'plot_id' => $plotId,
                    'registry_date' => $this->parseDate($row->date3) ?? now()->toDateString(),
                    'land_size' => $row->PLOTSIZE ?: 0,
                    'registry_amount' => $this->toDecimal($row->ragistryamt),
                    'payment_words' => $row->AMOUNTWORD ?: null,
                    'id_card_no' => $row->idcard ?: null,
                    'witness_name' => $row->NOMINEESNAME ?: 'Unknown',
                    'nominee_name' => $row->NOMINEESNAME ?: null,
                    'advance_amount' => $this->toDecimal($row->downpay),
                    'installment_amount' => $this->toDecimal($row->INSTSUBPAY),
                    'down_payment' => $this->toDecimal($row->downpay),
                    'due_date' => $this->parseDate($row->lastdate),
                    'status' => Str::contains(strtolower((string) $row->ragistry), 'complet') ? 'completed' : 'pending',
                    'lock_status' => strtolower(trim((string) $row->lockreg)) === 'lock' ? 'lock' : 'unlock',
                    'created_at' => now(),
                    'updated_at' => now(),
                ]);
                $this->registryMap[$legacyCode] = $registryId;
                $regCount++;
            } else {
                $this->registryMap[$legacyCode] = $existingReg->id;
            }
        }

        $this->info("Customers imported: {$custCount}, customer_bonds imported: {$bondCount}, registries imported: {$regCount}");
    }

    /**
     * Source: wjstar1.recipt1. Columns confirmed from
     * oldcodereference/home/Recipt.aspx.cs:
     *   CUSTREGNO, RECIPT, DATE1, AMOUNTR, MOD, insttype, ...
     */
    protected function importPayments(): void
    {
        $this->line('--- customer_bond_payments (from wjstar1.recipt1) ---');

        if (empty($this->customerMap)) {
            $this->rebuildCustomerMap();
        }
        if (empty($this->registryMap)) {
            $this->rebuildRegistryMap();
        }

        $rows = $this->legacyQuery('SELECT CUSTREGNO, RECIPT, DATE1, AMOUNTR, MOD, insttype
            FROM wjstar1.recipt1'.$this->limitSql());

        $this->info('Legacy recipt1 rows found: '.count($rows));

        if (! $this->commit) {
            if (! empty($rows)) {
                $this->table(array_keys((array) $rows[0]), array_slice(array_map(fn ($r) => (array) $r, $rows), 0, 5));
            }

            return;
        }

        $count = 0;
        foreach ($rows as $row) {
            $custRegNo = trim((string) $row->CUSTREGNO);
            $entryNo = trim((string) $row->RECIPT);
            if ($custRegNo === '' || $entryNo === '') {
                continue;
            }
            $legacyCode = 'customerreg1:'.$custRegNo;
            $customerId = $this->customerMap[$legacyCode] ?? null;
            if (! $customerId) {
                continue; // customer wasn't imported (ran payments before customers?)
            }

            $entryNoNamespaced = 'recipt1:'.$entryNo;
            $exists = DB::connection('heeddatabase')->table('customer_bond_payments')->where('entry_no', $entryNoNamespaced)->exists();
            if ($exists) {
                continue;
            }

            DB::connection('heeddatabase')->table('customer_bond_payments')->insert([
                'registry_id' => $this->registryMap[$legacyCode] ?? null,
                'customer_id' => $customerId,
                'entry_no' => $entryNoNamespaced,
                'entry_date' => $this->parseDate($row->DATE1) ?? now()->toDateString(),
                'entry_type' => $this->mapEntryType($row->insttype),
                'amount' => $this->toDecimal($row->AMOUNTR),
                'payment_method' => $row->MOD ?: null,
                'remarks' => 'Imported from legacy wjstar1.recipt1 CUSTREGNO='.$custRegNo,
                'created_at' => now(),
                'updated_at' => now(),
            ]);
            $count++;
        }

        $this->info('Customer bond payments imported: '.$count);
    }

    // ------------------------------------------------------------------
    // Helpers
    // ------------------------------------------------------------------

    protected function legacyQuery(string $sql): array
    {
        return DB::connection('legacy')->select($sql);
    }

    protected function limitSql(): string
    {
        return $this->limit > 0 ? " ORDER BY 1 OFFSET 0 ROWS FETCH NEXT {$this->limit} ROWS ONLY" : '';
    }

    protected function ensurePlaceholderKisan(): int
    {
        $existing = DB::connection('heeddatabase')->table('kisans')->where('reg_no', 'LEGACY-IMPORT-PLACEHOLDER')->first();
        if ($existing) {
            return $existing->id;
        }

        return DB::connection('heeddatabase')->table('kisans')->insertGetId([
            'reg_no' => 'LEGACY-IMPORT-PLACEHOLDER',
            'name' => 'Legacy Import (unattributed)',
            'mobile' => '0000000000',
            'address' => 'Unattributed — real kisan not identified during legacy import',
            'created_at' => now(),
            'updated_at' => now(),
        ]);
    }

    protected function rebuildAraziMap(): void
    {
        foreach (DB::connection('heeddatabase')->table('arazis')->whereNotNull('legacy_arazi_code')->get(['id', 'legacy_arazi_code']) as $r) {
            $this->araziMap[$r->legacy_arazi_code] = $r->id;
        }
    }

    protected function rebuildAgentMap(): void
    {
        foreach (DB::connection('heeddatabase')->table('agents')->whereNotNull('form_code')->get(['id', 'form_code']) as $r) {
            $this->agentMap[$r->form_code] = $r->id;
        }
    }

    protected function rebuildPlotMap(): void
    {
        foreach (DB::connection('heeddatabase')->table('plots')->get(['id', 'arazi_id', 'title']) as $r) {
            $this->plotMap[$r->arazi_id.'|'.$r->title] = $r->id;
        }
    }

    protected function rebuildCustomerMap(): void
    {
        foreach (DB::connection('heeddatabase')->table('customers')->whereNotNull('legacy_customer_code')->get(['id', 'legacy_customer_code']) as $r) {
            $this->customerMap[$r->legacy_customer_code] = $r->id;
        }
    }

    protected function rebuildRegistryMap(): void
    {
        foreach (DB::connection('heeddatabase')->table('registries')->whereNotNull('customer_reg_no')->get(['id', 'customer_reg_no']) as $r) {
            $this->registryMap[$r->customer_reg_no] = $r->id;
        }
    }

    protected function cleanMobile(?string $mobile): ?string
    {
        $mobile = preg_replace('/[^0-9]/', '', (string) $mobile);

        return $mobile !== '' ? substr($mobile, 0, 20) : null;
    }

    protected function toDecimal($value): float
    {
        if ($value === null || $value === '') {
            return 0;
        }
        $clean = preg_replace('/[^0-9.\-]/', '', (string) $value);

        return is_numeric($clean) ? (float) $clean : 0;
    }

    /**
     * Legacy dates are stored/entered as text in MM/dd/yyyy (see date1/date12
     * construction throughout the old .cs files). Falls back to null if it
     * can't be parsed rather than guessing.
     */
    protected function parseDate($value): ?string
    {
        if (! $value) {
            return null;
        }
        $value = trim((string) $value);
        if ($value === '' || $value === '00/00/0000') {
            return null;
        }

        foreach (['m/d/Y', 'd/m/Y', 'Y-m-d'] as $format) {
            try {
                return Carbon::createFromFormat($format, $value)->toDateString();
            } catch (Throwable) {
                continue;
            }
        }

        try {
            return Carbon::parse($value)->toDateString();
        } catch (Throwable) {
            return null;
        }
    }

    protected function mapPlotStatus($legacyStatus): string
    {
        $s = strtolower(trim((string) $legacyStatus));

        return match (true) {
            str_contains($s, 'sold') => 'sold',
            str_contains($s, 'book') => 'booked',
            default => 'available',
        };
    }

    protected function mapEntryType($legacyType): string
    {
        $s = strtolower(trim((string) $legacyType));

        return match (true) {
            str_contains($s, 'advance') => 'advance',
            str_contains($s, 'final') => 'final',
            str_contains($s, 'penalty') => 'penalty',
            str_contains($s, 'return') => 'return',
            str_contains($s, 'install') => 'installment',
            default => 'other',
        };
    }

    /**
     * NAMEDOBADDRESS is a legacy free-text field observed being truncated
     * to just show a "name" in reporting queries (LEFT(...,20) AS 'NAME').
     * We take it as the name in full; address is unknown from this field
     * alone — flagged as a TODO if a separate address source is found.
     */
    protected function extractName($namedobaddress): ?string
    {
        $v = trim((string) $namedobaddress);

        return $v !== '' ? $v : null;
    }

    protected function extractAddress($namedobaddress): ?string
    {
        // No reliable separate address in this legacy field; left null/Unknown
        // deliberately rather than guessing. Revisit if a better source table
        // (e.g. a dedicated address column elsewhere) is identified.
        return null;
    }
}
