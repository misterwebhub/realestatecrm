<?php

namespace App\Http\Controllers;

use App\Models\CustomerBondCheque;
use App\Models\CustomerBond;
use Illuminate\Http\Request;
use Illuminate\Validation\Rule;
use Illuminate\Support\Facades\DB;

class CustomerBondChequeController extends Controller
{
    /**
     * Restrict a cheque query to the current user's own records, unless they are
     * a Super Admin (who sees everything). Cheques are deal data → owner-scoped.
     */
    protected function scopeToOwner($query)
    {
        $user = auth()->user();
        if ($user && ! $user->isSuperAdmin()) {
            $canViewBondModule = $user->canAny(['cheques.view', 'customer_bonds.view', 'customer_payments.view', 'customer_ledger.view']);
            if (! $canViewBondModule) {
                $query->where('customer_bond_cheques.created_by', $user->getKey());
            }
        }

        return $query;
    }

    /**
     * Abort 404 if a non-admin tries to manage a bond they do not own, so the
     * cheque screen never exposes another user's deal via a guessed bond id.
     */
    protected function authorizeBondOwnership(CustomerBond $bond): void
    {
        $user = auth()->user();
        if (! $user) {
            abort(403);
        }

        if ($user->isSuperAdmin()) {
            return;
        }

        $bondOwner = $bond->getAttribute('created_by');
        $hasDirectAccess = (string) $bondOwner === (string) $user->getKey()
            || blank($bondOwner);
        $hasModuleAccess = $user->canAny(['cheques.view', 'customer_bonds.view', 'customer_payments.view', 'customer_ledger.view']);

        if (! $hasDirectAccess && ! $hasModuleAccess) {
            abort(403);
        }
    }

    /**
     * Abort 403 unless the current user holds the "cheques.delete" permission
     * (Super Admin always passes via Gate::before). Deleting a cheque entry —
     * single, bulk, or via the manage-screen row remover — must never be
     * possible for a user whose role wasn't explicitly granted this permission,
     * even if they own the record or can view/edit cheques.
     */
    protected function authorizeChequeDelete(): void
    {
        $user = auth()->user();
        if (! $user || ! $user->can('cheques.delete')) {
            abort(403, 'You are not allowed to delete cheques.');
        }
    }

    public function index(Request $request)
    {
        $filterStatus  = $request->query('status', '');
        $filterBond    = $request->query('bond_no', '');
        $filterAccount = $request->query('account_id', '');
        $filterFrom    = $request->query('date_from', '');
        $filterTo      = $request->query('date_to', '');

        $query = CustomerBondCheque::with(['customerBond.customer', 'connectedAccount'])
            ->when($filterStatus,  fn ($q) => $q->where('status', $filterStatus))
            ->when($filterBond,    fn ($q) => $q->whereHas('customerBond', fn ($bq) => $bq->where('bond_no', 'like', '%' . $filterBond . '%')))
            ->when($filterAccount, fn ($q) => $q->where('connected_account_id', $filterAccount))
            ->when($filterFrom,    fn ($q) => $q->whereDate('cheque_date', '>=', $filterFrom))
            ->when($filterTo,      fn ($q) => $q->whereDate('cheque_date', '<=', $filterTo))
            ->latest('cheque_date')
            ->latest('id');
        $this->scopeToOwner($query);

        $cheques = $query->get();

        // summary totals — respect active filters
        $summaryQuery = CustomerBondCheque::query()
            ->when($filterBond,    fn ($q) => $q->whereHas('customerBond', fn ($bq) => $bq->where('bond_no', 'like', '%' . $filterBond . '%')))
            ->when($filterAccount, fn ($q) => $q->where('connected_account_id', $filterAccount))
            ->when($filterFrom,    fn ($q) => $q->whereDate('cheque_date', '>=', $filterFrom))
            ->when($filterTo,      fn ($q) => $q->whereDate('cheque_date', '<=', $filterTo));
        $this->scopeToOwner($summaryQuery);

        $all     = (clone $summaryQuery)->selectRaw('status, SUM(amount) as total, COUNT(*) as count')->groupBy('status')->get()->keyBy('status');
        $summary = [
            'pending'   => $all->get('pending'),
            'cleared'   => $all->get('cleared'),
            'bounced'   => $all->get('bounced'),
            'cancelled' => $all->get('cancelled'),
        ];

        $accounts = \App\Models\ConnectedAccount::orderBy('name')->get();

        return view('customer_bond_cheques.index', [
            'title'          => 'Connected Accounts Cheques',
            'cheques'        => $cheques,
            'summary'        => $summary,
            'filterStatus'   => $filterStatus,
            'filterBond'     => $filterBond,
            'filterAccount'  => $filterAccount,
            'filterFrom'     => $filterFrom,
            'filterTo'       => $filterTo,
            'accounts'       => $accounts,
        ]);
    }

    public function create(Request $request)
    {
        $bond = null;
        $bondId = $request->query('customer_bond_id') ?? $request->input('customer_bond_id');
        if ($bondId) {
            $bond = CustomerBond::with(['customer'])->find($bondId);
        }

        // If a bond is supplied, redirect to the manage screen which supports
        // adding multiple cheque entries in one go.
        if ($bondId) {
            return redirect()->route('customer-bond-cheques.manage', $bondId);
        }

        return view('customer_bond_cheques.form', [
            'title' => 'Create Cheque Entry',
            'item' => null,
            'bond' => $bond,
            'customers' => \App\Models\Customer::orderBy('name')->pluck('name', 'id')->all(),
        ]);
    }

    public function store(Request $request)
    {
        $bondId = $request->input('customer_bond_id');

        $data = $request->validate([
            'customer_bond_id' => ['required', 'exists:customer_bonds,id'],
            'customer_id' => ['nullable', 'exists:customers,id'],
            'cheque_number' => [
                'required',
                'string',
                'max:100',
                Rule::unique('customer_bond_cheques', 'cheque_number')->where(function ($q) use ($bondId) {
                    return $q->where('customer_bond_id', $bondId);
                }),
            ],
            'connected_account_id' => ['required', 'exists:connected_accounts,id'],
            'bank_name' => ['nullable', 'string', 'max:150'],
            'branch_name' => ['nullable', 'string', 'max:150'],
            'cheque_date' => ['nullable', 'date'],
            'amount' => ['required', 'numeric', 'min:0'],
            'status' => ['nullable', 'in:pending,cleared,bounced,cancelled'],
            'type' => ['nullable', 'in:mentioned,not_mentioned'],
            'notes' => ['nullable', 'string'],
        ]);

        $data['status'] = $data['status'] ?? 'pending';
        $data['type'] = $data['type'] ?? 'mentioned';
        $data['created_by'] = auth()->id() ?? null;

        $cheque = CustomerBondCheque::create($data);

        return redirect()->back()->with('success', 'Cheque entry created.');
    }

    public function forBond(CustomerBond $customer_bond)
    {
        $query = CustomerBondCheque::where('customer_bond_id', $customer_bond->id)->orderByDesc('id');

        // allow filtering by status (e.g., ?status=pending) so callers can request unpaid only
        if ($status = request()->query('status')) {
            // ?include_id=<id> always keeps a specific cheque in the result even if its
            // status no longer matches (e.g. the cheque already tied to the payment
            // being edited, which was marked "cleared" when the payment was saved).
            // Without this, editing a cheque payment would reload a filtered dropdown
            // that no longer contains its own cheque and silently unassign it on save.
            $includeId = request()->query('include_id');
            $query->where(function ($q) use ($status, $includeId) {
                $q->where('status', $status);
                if ($includeId) {
                    $q->orWhere('id', $includeId);
                }
            });
        }

        $cheques = $query->get()->map(function ($c) {
            return [
                'id' => $c->id,
                'label' => ($c->cheque_number ? $c->cheque_number . ' — ' : '') . '₹' . number_format((float)$c->amount, 2) . ' — ' . ucfirst($c->status),
                'amount' => (float) $c->amount,
                'status' => $c->status,
            ];
        })->values();

        return response()->json($cheques);
    }

    public function manage(CustomerBond $customer_bond)
    {
        $this->authorizeBondOwnership($customer_bond);

        $customer_bond->loadMissing(['customer', 'arazi', 'plots', 'witnesses', 'payments']);

        $cheques = CustomerBondCheque::with('connectedAccount')
            ->where('customer_bond_id', $customer_bond->id)
            ->orderBy('id')
            ->get();

        // Payment summary (debit-aware)
        $debitTypes  = ['return', 'discount'];
        $totalPaid   = $customer_bond->payments->whereNotIn('entry_type', $debitTypes)->sum('amount');
        $totalDebit  = $customer_bond->payments->whereIn('entry_type', $debitTypes)->sum('amount');
        $netPaid     = $totalPaid - $totalDebit;
        $balance     = ($customer_bond->total_amount ?? 0) - $netPaid;
        $installmentNo = $customer_bond->payments->whereNotIn('entry_type', $debitTypes)->count();

        // Default starting point for auto-generated cheque schedules:
        // the bond's Installment Due Date (stored in `last_date`), falling back
        // to the bond date, then today.
        $installmentDueDate = optional($customer_bond->last_date)->format('Y-m-d')
            ?: (optional($customer_bond->bond_date)->format('Y-m-d') ?: now()->format('Y-m-d'));

        return view('customer_bond_cheques.manage', [
            'bond'               => $customer_bond,
            'cheques'            => $cheques,
            'netPaid'            => $netPaid,
            'balance'            => $balance,
            'installmentNo'      => $installmentNo,
            'installmentDueDate' => $installmentDueDate,
            'defaultMonths'      => (int) ($customer_bond->no_of_months ?? 0),
        ]);
    }

    public function storeBulk(Request $request)
    {
        $data = $request->validate([
            'customer_bond_id' => ['required', 'exists:customer_bonds,id'],
            'deleted_ids' => ['nullable', 'array'],
            'deleted_ids.*' => ['integer', 'exists:customer_bond_cheques,id'],
            'cheques' => ['nullable', 'array'],
            'cheques.*.id' => ['nullable', 'integer', 'exists:customer_bond_cheques,id'],
            'cheques.*.cheque_number' => ['required', 'string', 'max:100'],
            'cheques.*.bank_name' => ['nullable', 'string', 'max:150'],
            'cheques.*.branch_name' => ['nullable', 'string', 'max:150'],
            'cheques.*.cheque_date' => ['nullable', 'date'],
            'cheques.*.action_due_date' => ['nullable', 'date'],
            'cheques.*.frequency_type' => ['nullable', 'string', 'max:30'],
            'cheques.*.amount' => ['required', 'numeric', 'min:0'],
            'cheques.*.status' => ['nullable', 'in:pending,cleared,bounced,cancelled'],
            'cheques.*.type' => ['nullable', 'in:mentioned,not_mentioned'],
            'cheques.*.connected_account_id' => ['required', 'exists:connected_accounts,id'],
            'cheques.*.notes' => ['nullable', 'string'],
        ]);

        $bondId = $data['customer_bond_id'];

        // Process deletions first so replaced cheque_numbers are allowed.
        // Removing an existing (saved) cheque row on this screen is still a
        // delete, so it requires the same "cheques.delete" permission as the
        // dedicated destroy/bulk-delete routes.
        $deletedIds = $data['deleted_ids'] ?? [];
        if (!empty($deletedIds)) {
            $this->authorizeChequeDelete();
            CustomerBondCheque::whereIn('id', $deletedIds)->where('customer_bond_id', $bondId)->delete();
        }

        $items = $data['cheques'] ?? [];

        // Prevent duplicate cheque numbers within the submitted payload
        $seen = [];
        foreach ($items as $idx => $row) {
            $num = trim((string) ($row['cheque_number'] ?? ''));
            if ($num === '') {
                return redirect()->back()->withErrors(['cheques.' . $idx . '.cheque_number' => 'Cheque number is required'])->withInput();
            }
            if (isset($seen[$num])) {
                return redirect()->back()->withErrors(['cheques.' . $idx . '.cheque_number' => 'Duplicate cheque number in request: ' . $num])->withInput();
            }
            $seen[$num] = $row['id'] ?? null;
        }

        // Check against existing DB rows for this bond (exclude rows being updated)
        if (!empty($seen)) {
            $existing = CustomerBondCheque::where('customer_bond_id', $bondId)
                ->whereIn('cheque_number', array_keys($seen))
                ->get();

            foreach ($existing as $ex) {
                $payloadId = $seen[$ex->cheque_number] ?? null;
                if (empty($payloadId) || $payloadId != $ex->id) {
                    return redirect()->back()->withErrors(['cheques' => 'Cheque number ' . $ex->cheque_number . ' already exists for this bond'])->withInput();
                }
            }
        }

        try {
            DB::transaction(function () use ($items, $bondId) {
                $this->persistChequeRows($items, $bondId);
            });
        } catch (\Illuminate\Database\QueryException $e) {
            // 23000 = integrity constraint violation (e.g. the composite unique
            // index on customer_bond_id + cheque_number). Surface a readable
            // message naming the duplicate cheque number instead of a 500 page.
            if ((string) ($e->errorInfo[0] ?? '') === '23000') {
                $message = 'A cheque with the same number already exists for this bond. Please use a unique cheque number for each cheque.';

                // Extract the duplicate value, e.g. "Duplicate entry '51-786' for key ..."
                if (preg_match("/Duplicate entry '([^']+)'/", $e->getMessage(), $m)) {
                    $duplicate = $m[1];
                    // The unique key is (customer_bond_id, cheque_number); strip the bond id prefix.
                    $chequeNo = preg_replace('/^' . preg_quote((string) $bondId, '/') . '-/', '', $duplicate);
                    $message = 'Duplicate cheque number "' . $chequeNo . '" — this cheque number already exists for this bond. Please use a unique cheque number.';
                }

                return redirect()->back()->withErrors(['cheques' => $message])->withInput();
            }
            throw $e;
        }

        return redirect()->route('customer-bond-cheques.manage', $bondId)->with('success', 'Cheques saved.');
    }

    /**
     * Insert/update the submitted cheque rows for a bond.
     */
    protected function persistChequeRows(array $items, $bondId): void
    {
        foreach ($items as $row) {
            // if id present, update existing; otherwise create
            if (!empty($row['id'])) {
                $c = CustomerBondCheque::where('id', $row['id'])->where('customer_bond_id', $bondId)->first();
                if (! $c) continue;
                $c->update([
                    'connected_account_id' => $row['connected_account_id'],
                    'cheque_number' => $row['cheque_number'],
                    'bank_name' => $row['bank_name'] ?? null,
                    'branch_name' => $row['branch_name'] ?? null,
                    'cheque_date' => $row['cheque_date'] ?? null,
                    'action_due_date' => $row['action_due_date'] ?? null,
                    'frequency_type' => $row['frequency_type'] ?? null,
                    'amount' => $row['amount'],
                    'status' => $row['status'] ?? 'pending',
                    'type' => $row['type'] ?? 'mentioned',
                    'notes' => $row['notes'] ?? null,
                ]);
            } else {
                CustomerBondCheque::create([
                    'customer_bond_id' => $bondId,
                    'customer_id' => CustomerBond::find($bondId)?->customer_id ?? null,
                    'connected_account_id' => $row['connected_account_id'],
                    'cheque_number' => $row['cheque_number'],
                    'bank_name' => $row['bank_name'] ?? null,
                    'branch_name' => $row['branch_name'] ?? null,
                    'cheque_date' => $row['cheque_date'] ?? null,
                    'action_due_date' => $row['action_due_date'] ?? null,
                    'frequency_type' => $row['frequency_type'] ?? null,
                    'amount' => $row['amount'],
                    'status' => $row['status'] ?? 'pending',
                    'type' => $row['type'] ?? 'mentioned',
                    'notes' => $row['notes'] ?? null,
                    'created_by' => auth()->id() ?? null,
                ]);
            }
        }
    }

    /**
     * Show the standalone "Create manual cheque entries" page.
     * Each cheque row can be assigned to one bond (individual) or to
     * several bonds at once (checkboxes) — a copy is created per bond.
     */
    public function manualCreate()
    {
        $bonds = CustomerBond::with(['customer', 'arazi'])
            ->orderByDesc('id')
            ->get()
            ->map(function ($b) {
                $code = $b->arazi->legacy_arazi_code ?? null;
                $label = ($b->bond_no ?: ('BOND-' . $b->id))
                    . ($b->customer?->name ? ' — ' . $b->customer->name : '')
                    . ($code ? ' — Arazi ' . $code : '');
                return ['id' => $b->id, 'label' => $label];
            })
            ->values();

        $accounts = \App\Models\ConnectedAccount::orderBy('name')->get();

        // Arazi options keyed by their legacy code (project convention).
        $araziCodes = \App\Models\Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '!=', '')
            ->orderBy('legacy_arazi_code')
            ->get()
            ->map(fn ($a) => [
                'code'  => $a->legacy_arazi_code,
                'label' => $a->legacy_arazi_code . ($a->location ? ' — ' . $a->location : ''),
            ])
            ->unique('code')
            ->values();

        return view('customer_bond_cheques.manual', [
            'title'      => 'Create Manual Cheque Entries',
            'bonds'      => $bonds,
            'accounts'   => $accounts,
            'araziCodes' => $araziCodes,
        ]);
    }

    /**
     * Persist manual cheque entries. For every selected bond of an entry a
     * separate cheque row is created. Duplicate (bond + cheque number)
     * combinations are skipped and reported back to the user.
     */
    public function manualStore(Request $request)
    {
        $data = $request->validate([
            'entries'                      => ['required', 'array', 'min:1'],
            'entries.*.bond_ids'           => ['nullable', 'array'],
            'entries.*.bond_ids.*'         => ['integer', 'exists:customer_bonds,id'],
            'entries.*.connected_account_id' => ['nullable', 'exists:connected_accounts,id'],
            'entries.*.arazi_code'         => ['required', 'string', 'max:100'],
            'entries.*.plot_id'            => ['required', 'integer', 'exists:plots,id'],
            'entries.*.cheque_number'      => ['required', 'string', 'max:100'],
            'entries.*.cheque_date'        => ['nullable', 'date'],
            'entries.*.action_due_date'    => ['nullable', 'date'],
            'entries.*.frequency_type'     => ['nullable', 'string', 'max:30'],
            'entries.*.amount'             => ['required', 'numeric', 'min:0'],
            'entries.*.status'             => ['nullable', 'in:pending,cleared,bounced,cancelled'],
            'entries.*.type'               => ['nullable', 'in:mentioned,not_mentioned'],
            'entries.*.notes'              => ['nullable', 'string'],
        ]);

        // Cheque numbers must be globally unique. Validate the batch against
        // itself and against existing records before creating anything.
        $numbers = [];
        foreach ($data['entries'] as $i => $entry) {
            $num = trim((string) ($entry['cheque_number'] ?? ''));
            if ($num === '') {
                continue;
            }
            if (isset($numbers[$num])) {
                return redirect()->back()
                    ->withErrors(['entries' => 'Duplicate cheque number "' . $num . '" in the submitted rows. Each cheque number must be unique.'])
                    ->withInput();
            }
            $numbers[$num] = true;
        }

        if (! empty($numbers)) {
            $existing = CustomerBondCheque::whereIn('cheque_number', array_keys($numbers))
                ->pluck('cheque_number')
                ->unique()
                ->all();
            if (! empty($existing)) {
                return redirect()->back()
                    ->withErrors(['entries' => 'Cheque number(s) already exist: ' . implode(', ', $existing) . '. Cheque numbers must be unique.'])
                    ->withInput();
            }
        }

        $created = 0;
        $skipped = [];

        DB::transaction(function () use ($data, &$created, &$skipped) {
            foreach ($data['entries'] as $entry) {
                $bondIds = $entry['bond_ids'] ?? [];

                // No bond selected -> store as an unassigned cheque (bond null).
                if (empty($bondIds)) {
                    CustomerBondCheque::create([
                        'customer_bond_id'     => null,
                        'customer_id'          => null,
                        'arazi_code'           => $entry['arazi_code'],
                        'plot_id'              => $entry['plot_id'],
                        'connected_account_id' => $entry['connected_account_id'] ?? null,
                        'cheque_number'        => $entry['cheque_number'],
                        'cheque_date'          => $entry['cheque_date'] ?? null,
                        'action_due_date'      => $entry['action_due_date'] ?? null,
                        'frequency_type'       => $entry['frequency_type'] ?? null,
                        'amount'               => $entry['amount'],
                        'status'               => $entry['status'] ?? 'pending',
                        'type'                 => $entry['type'] ?? 'mentioned',
                        'notes'                => $entry['notes'] ?? null,
                        'created_by'           => auth()->id() ?? null,
                    ]);
                    $created++;
                    continue;
                }

                foreach ($bondIds as $bondId) {
                    // Cheque numbers are globally unique, so a number can only be
                    // attached to a single bond. If it now exists (e.g. it was
                    // created for an earlier bond in this same entry), skip.
                    $exists = CustomerBondCheque::where('cheque_number', $entry['cheque_number'])->exists();

                    if ($exists) {
                        $skipped[] = $entry['cheque_number'] . ' (bond #' . $bondId . ')';
                        continue;
                    }

                    CustomerBondCheque::create([
                        'customer_bond_id'     => $bondId,
                        'customer_id'          => CustomerBond::find($bondId)?->customer_id ?? null,
                        'arazi_code'           => $entry['arazi_code'],
                        'plot_id'              => $entry['plot_id'],
                        'connected_account_id' => $entry['connected_account_id'] ?? null,
                        'cheque_number'        => $entry['cheque_number'],
                        'cheque_date'          => $entry['cheque_date'] ?? null,
                        'action_due_date'      => $entry['action_due_date'] ?? null,
                        'frequency_type'       => $entry['frequency_type'] ?? null,
                        'amount'               => $entry['amount'],
                        'status'               => $entry['status'] ?? 'pending',
                        'type'                 => $entry['type'] ?? 'mentioned',
                        'notes'                => $entry['notes'] ?? null,
                        'created_by'           => auth()->id() ?? null,
                    ]);
                    $created++;
                }
            }
        });

        $msg = $created . ' cheque entr' . ($created === 1 ? 'y' : 'ies') . ' created.';
        if (! empty($skipped)) {
            $msg .= ' Skipped ' . count($skipped) . ' duplicate(s): ' . implode(', ', $skipped);
        }

        return redirect()->route('customer-bond-cheques.manual')->with('success', $msg);
    }

    /**
     * Stream a sample CSV template for the manual cheque import.
     */
    public function manualTemplate()
    {
        // arazi_code and plot_title are REQUIRED; bond_no is optional (leave
        // blank to import an unassigned cheque). Use a real arazi/plot in the
        // sample so a copy-paste import succeeds out of the box.
        $sampleArazi = \App\Models\Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '!=', '')
            ->value('legacy_arazi_code') ?: 'ARAZI_CODE';
        $samplePlot = \App\Models\Plot::where('arazi_code', $sampleArazi)
            ->value('title') ?: 'PLOT_TITLE';

        $headers = ['arazi_code', 'plot_title', 'bond_no', 'account', 'cheque_number', 'amount', 'cheque_date', 'action_due_date', 'frequency_type', 'status', 'type', 'notes'];
        $sample  = [$sampleArazi, $samplePlot, '', '', 'CHQ-1001', '50000', '2026-07-20', '2026-08-20', 'every_month', 'pending', 'mentioned', 'Sample note'];

        $callback = function () use ($headers, $sample) {
            $out = fopen('php://output', 'w');
            // UTF-8 BOM for Excel
            fprintf($out, chr(0xEF) . chr(0xBB) . chr(0xBF));
            fputcsv($out, $headers);
            fputcsv($out, $sample);
            fclose($out);
        };

        return response()->streamDownload($callback, 'manual_cheques_template.csv', [
            'Content-Type' => 'text/csv',
        ]);
    }

    /**
     * Import cheques from an uploaded CSV file. Bonds are resolved by bond_no
     * and accounts by name. Rows without a resolvable bond, or that duplicate
     * an existing (bond + cheque number) pair, are skipped and reported.
     */
    public function manualImport(Request $request)
    {
        $request->validate([
            'csv_file' => ['required', 'file', 'mimes:csv,txt'],
        ]);

        $path = $request->file('csv_file')->getRealPath();
        $handle = fopen($path, 'r');
        if ($handle === false) {
            return redirect()->route('customer-bond-cheques.manual')->withErrors(['csv_file' => 'Unable to read the uploaded file.']);
        }

        $created = 0;
        $skipped = [];
        $rowNum  = 0;
        $seen    = []; // cheque numbers already handled in this file

        // Cache lookups
        $bondsByNo   = CustomerBond::pluck('id', 'bond_no');
        $accountsByName = \App\Models\ConnectedAccount::pluck('id', 'name');

        DB::beginTransaction();
        try {
            while (($row = fgetcsv($handle)) !== false) {
                $rowNum++;
                // strip BOM on first cell
                if ($rowNum === 1) {
                    $row[0] = preg_replace('/^\xEF\xBB\xBF/', '', $row[0] ?? '');
                    // Skip header row
                    if (in_array(strtolower(trim($row[0])), ['arazi_code', 'bond_no'], true)) {
                        continue;
                    }
                }

                if (count(array_filter($row, fn ($v) => trim((string) $v) !== '')) === 0) {
                    continue; // blank line
                }

                [$araziCode, $plotTitle, $bondNo, $account, $chequeNumber, $amount, $chequeDate, $actionDue, $freq, $status, $type, $notes] = array_pad($row, 12, null);

                $bondNo = trim((string) $bondNo);
                $araziCode = trim((string) $araziCode);
                $plotTitle = trim((string) $plotTitle);
                $chequeNumber = trim((string) $chequeNumber);

                $bondId = null;
                if ($bondNo !== '') {
                    $bondId = $bondsByNo[$bondNo] ?? null;
                    if (! $bondId) {
                        // A bond number was given but doesn't exist — skip.
                        $skipped[] = "row {$rowNum}: bond '{$bondNo}' not found";
                        continue;
                    }
                }
                if ($chequeNumber === '') {
                    $skipped[] = "row {$rowNum}: missing cheque number";
                    continue;
                }

                // Arazi + plot are required and must match.
                if ($araziCode === '') {
                    $skipped[] = "row {$rowNum}: missing arazi_code";
                    continue;
                }
                if (! \App\Models\Arazi::where('legacy_arazi_code', $araziCode)->exists()) {
                    $skipped[] = "row {$rowNum}: arazi '{$araziCode}' not found";
                    continue;
                }
                if ($plotTitle === '') {
                    $skipped[] = "row {$rowNum}: missing plot_title";
                    continue;
                }
                $plotId = \App\Models\Plot::where('arazi_code', $araziCode)
                    ->where('title', $plotTitle)
                    ->value('id');
                if (! $plotId) {
                    $skipped[] = "row {$rowNum}: plot '{$plotTitle}' not found in arazi '{$araziCode}'";
                    continue;
                }

                // Cheque numbers must be globally unique — check this file and the DB.
                if (isset($seen[$chequeNumber])) {
                    $skipped[] = "row {$rowNum}: duplicate {$chequeNumber} (already in file)";
                    continue;
                }
                if (CustomerBondCheque::where('cheque_number', $chequeNumber)->exists()) {
                    $skipped[] = "row {$rowNum}: duplicate {$chequeNumber} (already exists)";
                    continue;
                }
                $seen[$chequeNumber] = true;

                $accountId = null;
                if (trim((string) $account) !== '') {
                    $accountId = $accountsByName[trim((string) $account)] ?? null;
                }

                $statusVal = in_array($status, ['pending', 'cleared', 'bounced', 'cancelled'], true) ? $status : 'pending';
                $typeVal   = in_array($type, ['mentioned', 'not_mentioned'], true) ? $type : 'mentioned';

                CustomerBondCheque::create([
                    'customer_bond_id'     => $bondId,
                    'customer_id'          => $bondId ? (CustomerBond::find($bondId)?->customer_id ?? null) : null,
                    'arazi_code'           => $araziCode,
                    'plot_id'              => $plotId,
                    'connected_account_id' => $accountId,
                    'cheque_number'        => $chequeNumber,
                    'cheque_date'          => $chequeDate ?: null,
                    'action_due_date'      => $actionDue ?: null,
                    'frequency_type'       => $freq ?: null,
                    'amount'               => is_numeric($amount) ? $amount : 0,
                    'status'               => $statusVal,
                    'type'                 => $typeVal,
                    'notes'                => $notes ?: null,
                    'created_by'           => auth()->id() ?? null,
                ]);
                $created++;
            }
            DB::commit();
        } catch (\Throwable $e) {
            DB::rollBack();
            fclose($handle);
            return redirect()->route('customer-bond-cheques.manual')->withErrors(['csv_file' => 'Import failed: ' . $e->getMessage()]);
        }
        fclose($handle);

        $msg = $created . ' cheque(s) imported.';
        if (! empty($skipped)) {
            $msg .= ' Skipped ' . count($skipped) . ': ' . implode('; ', array_slice($skipped, 0, 15));
        }

        return redirect()->route('customer-bond-cheques.manual')->with('success', $msg);
    }

    /**
     * Show the "Assign cheques to a bond" page — a filterable pool of all
     * cheques with checkboxes and a bond selector for bulk (re)assignment.
     */
    public function assignForm(Request $request)
    {
        $filterNumber  = $request->query('cheque_number', '');
        $filterAccount = $request->query('account_id', '');
        $filterStatus  = $request->query('status', '');
        $filterFrom    = $request->query('date_from', '');
        $filterTo      = $request->query('date_to', '');
        $filterAssign  = $request->query('assignment', '');
        $filterArazi   = $request->query('arazi_code', '');
        $filterPlot    = $request->query('plot_id', '');

        $cheques = CustomerBondCheque::with(['customerBond.customer', 'customerBond.arazi', 'connectedAccount', 'arazi', 'plot'])
            ->when($filterNumber,  fn ($q) => $q->where('cheque_number', 'like', '%' . $filterNumber . '%'))
            ->when($filterAccount, fn ($q) => $q->where('connected_account_id', $filterAccount))
            ->when($filterStatus,  fn ($q) => $q->where('status', $filterStatus))
            ->when($filterAssign === 'assigned',   fn ($q) => $q->whereNotNull('customer_bond_id'))
            ->when($filterAssign === 'unassigned', fn ($q) => $q->whereNull('customer_bond_id'))
            ->when($filterArazi !== '', fn ($q) => $q->where('arazi_code', $filterArazi))
            ->when($filterPlot !== '',  fn ($q) => $q->where('plot_id', $filterPlot))
            ->when($filterFrom,    fn ($q) => $q->whereDate('cheque_date', '>=', $filterFrom))
            ->when($filterTo,      fn ($q) => $q->whereDate('cheque_date', '<=', $filterTo))
            ->latest('cheque_date')
            ->latest('id')
            ->limit(500)
            ->get();

        $bonds = CustomerBond::with(['customer', 'arazi'])
            ->orderByDesc('id')
            ->get()
            ->map(function ($b) {
                $code = $b->arazi->legacy_arazi_code ?? null;
                $label = ($b->bond_no ?: ('BOND-' . $b->id))
                    . ($b->customer?->name ? ' — ' . $b->customer->name : '')
                    . ($code ? ' — Arazi ' . $code : '');
                return ['id' => $b->id, 'label' => $label];
            })
            ->values();

        $accounts = \App\Models\ConnectedAccount::orderBy('name')->get();

        // Arazi codes present on cheques (for the filter dropdown).
        $araziCodes = CustomerBondCheque::whereNotNull('arazi_code')
            ->where('arazi_code', '!=', '')
            ->distinct()
            ->orderBy('arazi_code')
            ->pluck('arazi_code');

        // Plots for the selected arazi (only relevant when an arazi is chosen).
        $plots = $filterArazi !== ''
            ? \App\Models\Plot::where('arazi_code', $filterArazi)->orderBy('title')->get(['id', 'title'])
            : collect();

        return view('customer_bond_cheques.assign', [
            'title'         => 'Assign Cheques to Bond',
            'cheques'       => $cheques,
            'bonds'         => $bonds,
            'accounts'      => $accounts,
            'araziCodes'    => $araziCodes,
            'plots'         => $plots,
            'filterNumber'  => $filterNumber,
            'filterAccount' => $filterAccount,
            'filterStatus'  => $filterStatus,
            'filterFrom'    => $filterFrom,
            'filterTo'      => $filterTo,
            'filterAssign'  => $filterAssign,
            'filterArazi'   => $filterArazi,
            'filterPlot'    => $filterPlot,
        ]);
    }

    /**
     * Export the currently filtered cheque pool as CSV.
     */
    public function assignExport(Request $request)
    {
        $filterNumber  = $request->query('cheque_number', '');
        $filterAccount = $request->query('account_id', '');
        $filterStatus  = $request->query('status', '');
        $filterFrom    = $request->query('date_from', '');
        $filterTo      = $request->query('date_to', '');
        $filterAssign  = $request->query('assignment', '');
        $filterArazi   = $request->query('arazi_code', '');
        $filterPlot    = $request->query('plot_id', '');

        $cheques = CustomerBondCheque::with(['customerBond.customer', 'customerBond.arazi', 'connectedAccount', 'arazi', 'plot'])
            ->when($filterNumber,  fn ($q) => $q->where('cheque_number', 'like', '%' . $filterNumber . '%'))
            ->when($filterAccount, fn ($q) => $q->where('connected_account_id', $filterAccount))
            ->when($filterStatus,  fn ($q) => $q->where('status', $filterStatus))
            ->when($filterAssign === 'assigned',   fn ($q) => $q->whereNotNull('customer_bond_id'))
            ->when($filterAssign === 'unassigned', fn ($q) => $q->whereNull('customer_bond_id'))
            ->when($filterArazi !== '', fn ($q) => $q->where('arazi_code', $filterArazi))
            ->when($filterPlot !== '',  fn ($q) => $q->where('plot_id', $filterPlot))
            ->when($filterFrom,    fn ($q) => $q->whereDate('cheque_date', '>=', $filterFrom))
            ->when($filterTo,      fn ($q) => $q->whereDate('cheque_date', '<=', $filterTo))
            ->latest('cheque_date')
            ->latest('id')
            ->get();

        $callback = function () use ($cheques) {
            $out = fopen('php://output', 'w');
            fprintf($out, chr(0xEF) . chr(0xBB) . chr(0xBF)); // UTF-8 BOM
            fputcsv($out, [
                'Cheque No', 'Amount', 'Assignment', 'Bond No', 'Customer', 'Arazi Code', 'Plot',
                'Account', 'Cheque Date', 'Due Date', 'Frequency', 'Status', 'Type', 'Notes',
            ]);
            foreach ($cheques as $c) {
                fputcsv($out, [
                    $c->cheque_number,
                    number_format((float) $c->amount, 2, '.', ''),
                    $c->customer_bond_id ? 'Assigned' : 'Not Assigned',
                    optional($c->customerBond)->bond_no ?: '',
                    optional(optional($c->customerBond)->customer)->name ?: '',
                    $c->arazi_code ?: (optional(optional($c->customerBond)->arazi)->legacy_arazi_code ?: ''),
                    optional($c->plot)->title ?: '',
                    optional($c->connectedAccount)->name ?: '',
                    $c->cheque_date ? \Carbon\Carbon::parse($c->cheque_date)->format('Y-m-d') : '',
                    $c->action_due_date ? \Carbon\Carbon::parse($c->action_due_date)->format('Y-m-d') : '',
                    $c->frequency_type ?: '',
                    ucfirst($c->status),
                    $c->type ?: '',
                    $c->notes ?: '',
                ]);
            }
            fclose($out);
        };

        return response()->streamDownload($callback, 'cheque_entries_' . now()->format('Ymd_His') . '.csv', [
            'Content-Type' => 'text/csv',
        ]);
    }

    /**
     * (Re)assign the selected cheques to a target bond. Cheques whose number
     * already exists on the target bond are skipped and reported.
     */
    public function assignStore(Request $request)
    {
        $data = $request->validate([
            'cheque_ids'       => ['required', 'array', 'min:1'],
            'cheque_ids.*'     => ['integer', 'exists:customer_bond_cheques,id'],
            'customer_bond_id' => ['required', 'exists:customer_bonds,id'],
        ]);

        $bond = CustomerBond::find($data['customer_bond_id']);
        $this->authorizeBondOwnership($bond);
        $moved = 0;
        $skipped = [];

        DB::transaction(function () use ($data, $bond, &$moved, &$skipped) {
            $cheques = CustomerBondCheque::whereIn('id', $data['cheque_ids'])->get();
            foreach ($cheques as $cheque) {
                if ((int) $cheque->customer_bond_id === (int) $bond->id) {
                    continue; // already on target
                }
                $dup = CustomerBondCheque::where('customer_bond_id', $bond->id)
                    ->where('cheque_number', $cheque->cheque_number)
                    ->exists();
                if ($dup) {
                    $skipped[] = $cheque->cheque_number;
                    continue;
                }
                $cheque->update([
                    'customer_bond_id' => $bond->id,
                    'customer_id'      => $bond->customer_id,
                ]);
                $moved++;
            }
        });

        $msg = $moved . ' cheque(s) assigned to ' . ($bond->bond_no ?: ('BOND-' . $bond->id)) . '.';
        if (! empty($skipped)) {
            $msg .= ' Skipped ' . count($skipped) . ' duplicate(s): ' . implode(', ', $skipped);
        }

        return redirect()->route('customer-bond-cheques.assign')->with('success', $msg);
    }

    /**
     * Delete the selected cheques in bulk.
     */
    public function bulkDelete(Request $request)
    {
        $this->authorizeChequeDelete();

        $data = $request->validate([
            'cheque_ids'   => ['required', 'array', 'min:1'],
            'cheque_ids.*' => ['integer', 'exists:customer_bond_cheques,id'],
        ]);

        $deleted = $this->scopeToOwner(
            CustomerBondCheque::whereIn('id', $data['cheque_ids'])
        )->delete();

        return redirect()->back()->with('success', $deleted . ' cheque(s) deleted.');
    }

    /**
     * Unassign a single cheque from its bond (set bond/customer to null).
     */
    public function unassign(Request $request)
    {
        $data = $request->validate([
            'cheque_id' => ['required', 'integer', 'exists:customer_bond_cheques,id'],
        ]);

        $cheque = $this->scopeToOwner(
            CustomerBondCheque::whereKey($data['cheque_id'])
        )->firstOrFail();
        $cheque->update([
            'customer_bond_id' => null,
            'customer_id'      => null,
        ]);

        return redirect()->back()->with('success', 'Cheque ' . $cheque->cheque_number . ' unassigned.');
    }

    public function destroy(CustomerBondCheque $customerBondCheque)
    {
        $this->authorizeChequeDelete();

        $user = auth()->user();
        if ($user && ! $user->isSuperAdmin()
            && (string) $customerBondCheque->getAttribute('created_by') !== (string) $user->getKey()) {
            abort(404);
        }
        $customerBondCheque->delete();
        return redirect()->back()->with('success', 'Cheque entry deleted.');
    }
}
