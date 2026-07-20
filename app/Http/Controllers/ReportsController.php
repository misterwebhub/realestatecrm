<?php

namespace App\Http\Controllers;

use App\Models\Agent;
use App\Models\Arazi;
use App\Models\CustomerBond;
use App\Models\CustomerBondPayment;
use App\Models\KisanRegistryBuyer;
use App\Models\Partner;
use App\Models\Plot;
use App\Models\Registry;
use App\Models\User;
use Illuminate\Http\Request;

class ReportsController extends Controller
{
    public function index()
    {
        return view('reports.index');
    }

    public function plotDetails()
    {
        return view('reports.plot_details');
    }

    /**
     * Detailed customer-payment report, grouped by the user who took the payment.
     * Supports filtering by user, customer, bond, arazi, entry type, payment
     * method and date range — all filter option lists are derived from the data.
     */
    public function customerPaymentsByUser(Request $request)
    {
        $userId        = $request->query('user_id', '');
        $customerId    = $request->query('customer_id', '');
        $bondId        = $request->query('bond_id', '');
        $araziCode     = $request->query('arazi_code', '');
        $entryType     = $request->query('entry_type', '');
        $paymentMethod = $request->query('payment_method', '');
        $brokerId      = $request->query('broker_id', '');
        $partnerId     = $request->query('partner_id', '');
        $deedNo        = $request->query('deed_no', '');
        $dateFrom      = $request->query('date_from', '');
        $dateTo        = $request->query('date_to', '');

        $payments = CustomerBondPayment::with([
                'takenByUser',
                'customer',
                'customerBond.customer',
                'customerBond.arazi',
                'customerBond.plots',
                'customerBond.broker',
            ])
            ->whereNotNull('taken_by_user_id')
            ->when($userId,        fn ($q) => $q->where('taken_by_user_id', $userId))
            ->when($customerId,    fn ($q) => $q->whereHas('customerBond', fn ($b) => $b->where('customer_id', $customerId)))
            ->when($bondId,        fn ($q) => $q->where('customer_bond_id', $bondId))
            ->when($araziCode,     fn ($q) => $q->where('arazi_code', $araziCode))
            ->when($entryType,     fn ($q) => $q->where('entry_type', $entryType))
            ->when($paymentMethod, fn ($q) => $q->where('payment_method', $paymentMethod))
            ->when($brokerId,      fn ($q) => $q->whereHas('customerBond', fn ($b) => $b->where('broker_id', $brokerId)))
            ->when($dateFrom,      fn ($q) => $q->whereDate('entry_date', '>=', $dateFrom))
            ->when($dateTo,        fn ($q) => $q->whereDate('entry_date', '<=', $dateTo))
            ->orderBy('entry_date')
            ->orderBy('id')
            ->get();

        // Registry lookup (deed no, partner, status) keyed by customer + arazi.
        $regMap = [];
        foreach (Registry::with('partner:id,name')->get(['id', 'customer_id', 'arazi_code', 'deed_no', 'partner_id', 'status']) as $reg) {
            $key = $reg->customer_id . '|' . $reg->arazi_code;
            if (! isset($regMap[$key])) {
                $regMap[$key] = $reg;
            }
        }

        foreach ($payments as $p) {
            $custId = $p->customerBond?->customer_id ?? $p->customer_id;
            $code   = $p->customerBond?->arazi?->legacy_arazi_code ?? $p->arazi_code;
            $p->reg_info = ($custId && $code) ? ($regMap[$custId . '|' . $code] ?? null) : null;
        }

        // Registry-derived filters (deed no / partner) applied post-load.
        if ($partnerId !== '') {
            $payments = $payments->filter(fn ($p) => $p->reg_info && (string) $p->reg_info->partner_id === (string) $partnerId)->values();
        }
        if ($deedNo !== '') {
            $payments = $payments->filter(fn ($p) => $p->reg_info && stripos((string) $p->reg_info->deed_no, $deedNo) !== false)->values();
        }

        $isDebit = fn ($p) => in_array($p->entry_type, ['return', 'discount'], true);

        $byUser = $payments->groupBy('taken_by_user_id')->map(function ($userPayments) use ($isDebit) {
            $user   = $userPayments->first()->takenByUser;
            $credit = $userPayments->reject($isDebit)->sum('amount');
            $debit  = $userPayments->filter($isDebit)->sum('amount');

            return [
                'user'     => $user,
                'payments' => $userPayments,
                'count'    => $userPayments->count(),
                'credit'   => $credit,
                'debit'    => $debit,
                'net'      => $credit - $debit,
            ];
        })->sortByDesc('net')->values();

        $grandCredit = $payments->reject($isDebit)->sum('amount');
        $grandDebit  = $payments->filter($isDebit)->sum('amount');

        return view('reports.customer_payments_by_user', [
            'title'         => 'Customer Payments by User',
            'byUser'        => $byUser,
            'grandCredit'   => $grandCredit,
            'grandDebit'    => $grandDebit,
            'grandNet'      => $grandCredit - $grandDebit,
            'totalCount'    => $payments->count(),
            // Filter option lists (data-driven)
            'users'         => User::orderBy('name')->get(['id', 'name']),
            'customers'     => \App\Models\Customer::orderBy('name')->get(['id', 'name']),
            'bonds'         => \App\Models\CustomerBond::orderBy('bond_no')->get(['id', 'bond_no']),
            'araziCodes'    => CustomerBondPayment::whereNotNull('arazi_code')->distinct()->orderBy('arazi_code')->pluck('arazi_code'),
            'entryTypes'    => CustomerBondPayment::whereNotNull('entry_type')->distinct()->orderBy('entry_type')->pluck('entry_type'),
            'paymentMethods'=> CustomerBondPayment::whereNotNull('payment_method')->where('payment_method', '!=', '')->distinct()->orderBy('payment_method')->pluck('payment_method'),
            'brokers'       => Agent::orderBy('name')->get(['id', 'name']),
            'partners'      => Partner::orderBy('name')->get(['id', 'name']),
            'deedNos'       => Registry::whereNotNull('deed_no')->where('deed_no', '!=', '')->distinct()->orderBy('deed_no')->pluck('deed_no'),
            // Current filter values
            'userId'        => $userId,
            'customerId'    => $customerId,
            'bondId'        => $bondId,
            'araziCode'     => $araziCode,
            'entryType'     => $entryType,
            'paymentMethod' => $paymentMethod,
            'brokerId'      => $brokerId,
            'partnerId'     => $partnerId,
            'deedNo'        => $deedNo,
            'dateFrom'      => $dateFrom,
            'dateTo'        => $dateTo,
        ]);
    }

    /**
     * Cumulative bond report: one row per bond with totals for amount, paid,
     * balance and cheque figures. Date filter narrows paid/cheque-paid to the
     * selected period; the final column always shows lifetime paid (unfiltered).
     */
    public function bondsCumulative(Request $request)
    {
        $userId        = $request->query('user_id', '');
        $customerId    = $request->query('customer_id', '');
        $bondId        = $request->query('bond_id', '');
        $araziCode     = $request->query('arazi_code', '');
        $entryType     = $request->query('entry_type', '');
        $paymentMethod = $request->query('payment_method', '');
        $brokerId      = $request->query('broker_id', '');
        $partnerId     = $request->query('partner_id', '');
        $deedNo        = $request->query('deed_no', '');
        $dateFrom      = $request->query('date_from', '');
        $dateTo        = $request->query('date_to', '');

        $bonds = CustomerBond::with(['customer', 'arazi', 'plots', 'broker', 'payments', 'cheques.connectedAccount'])
            ->when($customerId,    fn ($q) => $q->where('customer_id', $customerId))
            ->when($bondId,        fn ($q) => $q->where('id', $bondId))
            ->when($araziCode,     fn ($q) => $q->where('arazi_code', $araziCode))
            ->when($brokerId,      fn ($q) => $q->where('broker_id', $brokerId))
            ->when($userId,        fn ($q) => $q->whereHas('payments', fn ($p) => $p->where('taken_by_user_id', $userId)))
            ->when($entryType,     fn ($q) => $q->whereHas('payments', fn ($p) => $p->where('entry_type', $entryType)))
            ->when($paymentMethod, fn ($q) => $q->whereHas('payments', fn ($p) => $p->where('payment_method', $paymentMethod)))
            ->orderBy('bond_no')
            ->get();

        // Registry lookup keyed by customer + arazi (deed/partner/status).
        $regMap = [];
        foreach (Registry::with('partner:id,name')->get(['id', 'customer_id', 'arazi_code', 'deed_no', 'partner_id', 'status']) as $reg) {
            $key = $reg->customer_id . '|' . $reg->arazi_code;
            if (! isset($regMap[$key])) {
                $regMap[$key] = $reg;
            }
        }

        $inRange = function ($date) use ($dateFrom, $dateTo) {
            if (! $date) return false;
            $d = $date instanceof \Carbon\Carbon ? $date->format('Y-m-d') : (string) $date;
            if ($dateFrom !== '' && $d < $dateFrom) return false;
            if ($dateTo !== '' && $d > $dateTo) return false;
            return true;
        };

        $debitTypes = ['return', 'discount'];
        $rows = [];
        $gTotal = $gPaid = $gBalance = $gChequePaid = $gChequeBal = $gPaidAll = $gChequeTotal = 0;

        foreach ($bonds as $bond) {
            $code = $bond->arazi_code ?: ($bond->arazi?->legacy_arazi_code ?? '-');
            $reg  = $regMap[$bond->customer_id . '|' . $code] ?? null;

            // Registry-derived filters.
            if ($partnerId !== '' && (! $reg || (string) $reg->partner_id !== (string) $partnerId)) continue;
            if ($deedNo !== '' && (! $reg || stripos((string) $reg->deed_no, $deedNo) === false)) continue;

            // Payments: lifetime and within-period net paid.
            $paidAll = (float) $bond->payments->whereNotIn('entry_type', $debitTypes)->sum('amount')
                     - (float) $bond->payments->whereIn('entry_type', $debitTypes)->sum('amount');

            // Paid column = CASH payments only (within selected period).
            $periodPayments = ($dateFrom === '' && $dateTo === '')
                ? $bond->payments
                : $bond->payments->filter(fn ($p) => $inRange($p->entry_date));
            $cashPayments = $periodPayments->filter(fn ($p) => strtolower((string) $p->payment_method) === 'cash');
            $paidPeriod = (float) $cashPayments->whereNotIn('entry_type', $debitTypes)->sum('amount')
                        - (float) $cashPayments->whereIn('entry_type', $debitTypes)->sum('amount');

            $total   = (float) ($bond->total_amount ?? $bond->bond_amount ?? 0);
            $balance = round($total - $paidAll, 2);

            // Cheques.
            $clearedCheques = $bond->cheques->where('status', 'cleared');
            $pendingCheques = $bond->cheques->where('status', 'pending');
            $noDate = ($dateFrom === '' && $dateTo === '');

            // Columns "Paid Cheque" / "Pending Cheque" -> respect the date filter.
            $chequePaid = (float) ($noDate
                ? $clearedCheques->sum('amount')
                : $clearedCheques->filter(fn ($c) => $inRange($c->cheque_date))->sum('amount'));
            $chequeBalance = (float) ($noDate
                ? $pendingCheques->sum('amount')
                : $pendingCheques->filter(fn ($c) => $inRange($c->cheque_date))->sum('amount'));

            // Cheque/Account mini-table -> lifetime totals (ignore the date filter).
            $chequePaidAll = (float) $clearedCheques->sum('amount');
            $chequeBalanceAll = (float) $pendingCheques->sum('amount');

            // Registry found = registry done (no pending state).
            $regDone = (bool) $reg;

            $rows[] = [
                'bond_id'        => $bond->id,
                'bond_no'        => $bond->bond_no ?? ('BOND-' . $bond->id),
                'bond_date'      => optional($bond->bond_date)->format('d-m-Y'),
                'customer'       => $bond->customer?->name ?? '—',
                'arazi'          => $code,
                'plots'          => $bond->plots->map(fn ($pl) => [
                                        'label' => $pl->plot_number ?: $pl->title,
                                        'gaz'   => (float) ($pl->area ?? 0),
                                    ])->values()->all(),
                'broker'         => $bond->broker?->name ?? '—',
                'total'          => round($total, 2),
                'paid'           => round($paidPeriod, 2),
                'balance'        => $balance,
                'cheque_paid'    => round($chequePaid, 2),
                'cheque_balance' => round($chequeBalance, 2),
                'cheque_paid_all'    => round($chequePaidAll, 2),
                'cheque_balance_all' => round($chequeBalanceAll, 2),
                'reg_status'     => $reg ? ($regDone ? 'Done' : 'Pending') : null,
                'paid_all'       => round($paidAll, 2),
                'cheque_count'   => $bond->cheques->count(),
                'cheque_total'   => round((float) $bond->cheques->sum('amount'), 2),
                'account_name'   => optional($bond->cheques->first(fn ($c) => $c->connectedAccount)?->connectedAccount)->name,
            ];

            $gTotal += $total;
            $gPaid += $paidPeriod;
            $gBalance += $balance;
            $gChequePaid += $chequePaid;
            $gChequeBal += $chequeBalance;
            $gPaidAll += $paidAll;
            $gChequeTotal += (float) $bond->cheques->sum('amount');
        }

        if (strtolower((string) $request->query('export')) === 'csv') {
            // Human-readable filter summary for the top of the sheet.
            $filters = [
                'User'      => $userId ? optional(User::find($userId))->name : 'All',
                'Customer'  => $customerId ? optional(\App\Models\Customer::find($customerId))->name : 'All',
                'Bond'      => $bondId ? optional(CustomerBond::find($bondId))->bond_no : 'All',
                'Arazi'     => $araziCode !== '' ? $araziCode : 'All',
                'Deed No'   => $deedNo !== '' ? $deedNo : 'All',
                'Type'      => $entryType !== '' ? ucfirst($entryType) : 'All',
                'Method'    => $paymentMethod !== '' ? ucfirst($paymentMethod) : 'All',
                'Broker'    => $brokerId ? optional(Agent::find($brokerId))->name : 'All',
                'Partner'   => $partnerId ? optional(Partner::find($partnerId))->name : 'All',
                'Date From' => $dateFrom !== '' ? $dateFrom : 'All',
                'Date To'   => $dateTo !== '' ? $dateTo : 'All',
            ];

            $filename = 'bond-cumulative-' . now()->format('Ymd-His') . '.csv';

            return response()->streamDownload(function () use ($rows, $filters, $gTotal, $gPaid, $gChequePaid, $gChequeBal, $gChequeTotal, $gPaidAll, $gBalance) {
                $out = fopen('php://output', 'w');
                // UTF-8 BOM for Excel.
                fwrite($out, "\xEF\xBB\xBF");

                fputcsv($out, ['Bond Cumulative Report']);
                fputcsv($out, ['Generated', now()->format('d-m-Y H:i')]);
                fputcsv($out, []);
                fputcsv($out, ['Filters Applied']);
                foreach ($filters as $label => $value) {
                    fputcsv($out, [$label, $value ?: 'All']);
                }
                fputcsv($out, []);

                fputcsv($out, [
                    '#', 'Bond Date', 'Bond', 'Customer', 'Arazi', 'Plots (gaz)', 'Broker',
                    'Bond Amount', 'Paid (cash)', 'Cheque Paid', 'Cheque Balance', 'Registry',
                    'Cheque Name', 'Cheque Paid (all)', 'Cheque Unpaid (all)', 'Cheque Total',
                    'Total Paid (all)', 'Total Balance (all)',
                ]);

                foreach ($rows as $i => $r) {
                    $plots = collect($r['plots'])->map(fn ($pl) => ($pl['label'] ?: '-') . ' (' . rtrim(rtrim(number_format($pl['gaz'], 2), '0'), '.') . ' gaz)')->implode('; ');
                    fputcsv($out, [
                        $i + 1,
                        $r['bond_date'] ?: '-',
                        $r['bond_no'],
                        $r['customer'],
                        $r['arazi'],
                        $plots,
                        $r['broker'],
                        number_format($r['total'], 2, '.', ''),
                        number_format($r['paid'], 2, '.', ''),
                        number_format($r['cheque_paid'], 2, '.', ''),
                        number_format($r['cheque_balance'], 2, '.', ''),
                        $r['reg_status'] ?? '-',
                        $r['account_name'] ?? '',
                        number_format($r['cheque_paid_all'], 2, '.', ''),
                        number_format($r['cheque_balance_all'], 2, '.', ''),
                        number_format($r['cheque_total'], 2, '.', ''),
                        number_format($r['paid_all'], 2, '.', ''),
                        number_format($r['balance'], 2, '.', ''),
                    ]);
                }

                $gChequePaidAll = (float) collect($rows)->sum('cheque_paid_all');
                $gChequeUnpaidAll = (float) collect($rows)->sum('cheque_balance_all');

                fputcsv($out, []);
                fputcsv($out, [
                    'GRAND TOTAL', '', '', '', '', '', '',
                    number_format($gTotal, 2, '.', ''),
                    number_format($gPaid, 2, '.', ''),
                    number_format($gChequePaid, 2, '.', ''),
                    number_format($gChequeBal, 2, '.', ''),
                    '', '',
                    number_format($gChequePaidAll, 2, '.', ''),
                    number_format($gChequeUnpaidAll, 2, '.', ''),
                    number_format($gChequeTotal, 2, '.', ''),
                    number_format($gPaidAll, 2, '.', ''),
                    number_format($gBalance, 2, '.', ''),
                ]);

                fclose($out);
            }, $filename, ['Content-Type' => 'text/csv; charset=UTF-8']);
        }

        return view('reports.bonds_cumulative', [
            'title'       => 'Bond Cumulative Report',
            'rows'        => $rows,
            'users'         => User::orderBy('name')->get(['id', 'name']),
            'customers'     => \App\Models\Customer::orderBy('name')->get(['id', 'name']),
            'bondsList'     => CustomerBond::orderBy('bond_no')->get(['id', 'bond_no']),
            'araziCodes'    => CustomerBond::whereNotNull('arazi_code')->where('arazi_code', '!=', '')->distinct()->orderBy('arazi_code')->pluck('arazi_code'),
            'entryTypes'    => CustomerBondPayment::whereNotNull('entry_type')->distinct()->orderBy('entry_type')->pluck('entry_type'),
            'paymentMethods'=> CustomerBondPayment::whereNotNull('payment_method')->where('payment_method', '!=', '')->distinct()->orderBy('payment_method')->pluck('payment_method'),
            'brokers'       => Agent::orderBy('name')->get(['id', 'name']),
            'partners'      => Partner::orderBy('name')->get(['id', 'name']),
            'deedNos'       => Registry::whereNotNull('deed_no')->where('deed_no', '!=', '')->distinct()->orderBy('deed_no')->pluck('deed_no'),
            'userId'        => $userId,
            'customerId'    => $customerId,
            'bondId'        => $bondId,
            'araziCode'     => $araziCode,
            'entryType'     => $entryType,
            'paymentMethod' => $paymentMethod,
            'brokerId'      => $brokerId,
            'partnerId'     => $partnerId,
            'deedNo'        => $deedNo,
            'dateFrom'      => $dateFrom,
            'dateTo'        => $dateTo,
            'g_total'         => round($gTotal, 2),
            'g_paid'          => round($gPaid, 2),
            'g_balance'       => round($gBalance, 2),
            'g_cheque_paid'   => round($gChequePaid, 2),
            'g_cheque_balance'=> round($gChequeBal, 2),
            'g_cheque_total'  => round($gChequeTotal, 2),
            'g_paid_all'      => round($gPaidAll, 2),
        ]);
    }

    /**
     * AJAX: all cheque entries for a bond with summary.
     * The cheque list/summary always shows every cheque for the bond and is
     * intentionally NOT affected by the report's date filters.
     */
    public function bondCheques(Request $request)
    {
        $bondId = $request->query('bond_id', '');

        $bond = CustomerBond::with(['cheques' => function ($q) {
            $q->orderBy('cheque_date');
        }])->find($bondId);

        if (! $bond) {
            return response()->json(['found' => false, 'cheques' => []]);
        }

        $cheques = $bond->cheques->values();

        $list = $cheques->map(fn ($c) => [
            'cheque_number' => $c->cheque_number ?: '—',
            'bank_name'     => $c->bank_name ?: '—',
            'cheque_date'   => optional($c->cheque_date)->format('d-m-Y') ?? '—',
            'amount'        => (float) $c->amount,
            'status'        => ucfirst((string) $c->status),
        ])->all();

        return response()->json([
            'found'   => true,
            'bond_no' => $bond->bond_no,
            'cheques' => $list,
            'summary' => [
                'count'   => $cheques->count(),
                'total'   => round((float) $cheques->sum('amount'), 2),
                'cleared' => round((float) $cheques->where('status', 'cleared')->sum('amount'), 2),
                'pending' => round((float) $cheques->where('status', 'pending')->sum('amount'), 2),
            ],
        ]);
    }

    /**
     * AJAX: distinct deed numbers for a given arazi code (for dependent filter).
     */
    public function deedsByArazi(Request $request)
    {
        $code = trim((string) $request->query('arazi_code', ''));

        if ($code === '') {
            return response()->json(['deeds' => []]);
        }

        $deeds = Registry::where('arazi_code', $code)
            ->whereNotNull('deed_no')
            ->where('deed_no', '!=', '')
            ->distinct()
            ->orderBy('deed_no')
            ->pluck('deed_no')
            ->values();

        return response()->json(['deeds' => $deeds]);
    }

    /**
     * Resolve the sold area for a registry: prefer the linked plot's area, fall back to land_size.
     */
    protected function registrySoldArea(Registry $r): float
    {
        if ($r->relationLoaded('plot') && $r->plot && $r->plot->area !== null && $r->plot->area !== '') {
            return (float) $r->plot->area;
        }
        return (float) ($r->land_size ?? 0);
    }

    /**
     * Partner-wise report: area each partner purchased (from kisan) and sold (to customers)
     * per arazi, with remaining area and registry status.
     */
    public function partners(Request $request)
    {
        $partnerId = $request->query('partner_id', '');
        $araziCode = $request->query('arazi_code', '');
        $activity  = $request->query('activity', ''); // pending|complete
        $dateFrom  = $request->query('date_from', '');
        $dateTo    = $request->query('date_to', '');

        $partners = Partner::orderBy('name')->get(['id', 'name', 'mobile']);

        $buyers = KisanRegistryBuyer::with('kisanRegistry:id,arazi_code')
            ->whereNotNull('partner_id')
            ->get();

        $assigned = [];
        foreach ($buyers as $b) {
            $code = $b->kisanRegistry->arazi_code ?? '-';
            $assigned[$b->partner_id][$code] = ($assigned[$b->partner_id][$code] ?? 0) + (float) $b->area;
        }

        $registries = Registry::with('plot:id,area')
            ->whereNotNull('partner_id')
            ->when($dateFrom, fn ($q) => $q->whereDate('registry_date', '>=', $dateFrom))
            ->when($dateTo,   fn ($q) => $q->whereDate('registry_date', '<=', $dateTo))
            ->get(['id', 'partner_id', 'arazi_code', 'plot_id', 'land_size', 'status']);

        $sold = $regCount = $regDone = [];
        foreach ($registries as $r) {
            $code = $r->arazi_code ?? '-';
            $sold[$r->partner_id][$code] = ($sold[$r->partner_id][$code] ?? 0) + $this->registrySoldArea($r);
            $regCount[$r->partner_id][$code] = ($regCount[$r->partner_id][$code] ?? 0) + 1;
            if (strtolower((string) $r->status) === 'completed') {
                $regDone[$r->partner_id][$code] = ($regDone[$r->partner_id][$code] ?? 0) + 1;
            }
        }

        // Option list of arazi codes involved in partner activity.
        $araziOptions = collect(array_merge(
            $buyers->pluck('kisanRegistry.arazi_code')->all(),
            $registries->pluck('arazi_code')->all()
        ))->filter()->unique()->sort()->values();

        $rows = [];
        $gAssigned = $gSold = 0;
        foreach ($partners as $p) {
            if ($partnerId && (int) $partnerId !== (int) $p->id) {
                continue;
            }
            $codes = array_unique(array_merge(
                array_keys($assigned[$p->id] ?? []),
                array_keys($sold[$p->id] ?? [])
            ));
            sort($codes);
            if (empty($codes)) {
                continue; // skip partners with no land activity
            }

            $araziRows = [];
            $totAssigned = $totSold = 0;
            foreach ($codes as $code) {
                if ($araziCode !== '' && (string) $araziCode !== (string) $code) {
                    continue;
                }
                $a = (float) ($assigned[$p->id][$code] ?? 0);
                $s = (float) ($sold[$p->id][$code] ?? 0);
                $cnt  = (int) ($regCount[$p->id][$code] ?? 0);
                $done = (int) ($regDone[$p->id][$code] ?? 0);

                if ($activity === 'complete' && !($cnt > 0 && $done >= $cnt)) {
                    continue;
                }
                if ($activity === 'pending' && !($cnt === 0 || $done < $cnt)) {
                    continue;
                }

                $totAssigned += $a;
                $totSold += $s;
                $araziRows[] = [
                    'arazi'     => $code,
                    'assigned'  => $a,
                    'sold'      => $s,
                    'remaining' => round($a - $s, 2),
                    'reg_count' => $cnt,
                    'reg_done'  => $done,
                ];
            }

            if (empty($araziRows)) {
                continue;
            }

            $gAssigned += $totAssigned;
            $gSold += $totSold;
            $rows[] = [
                'partner'         => $p->name,
                'mobile'          => $p->mobile ?: '-',
                'arazis'          => $araziRows,
                'total_assigned'  => round($totAssigned, 2),
                'total_sold'      => round($totSold, 2),
                'total_remaining' => round($totAssigned - $totSold, 2),
            ];
        }

        return view('reports.partners', [
            'title'           => 'Partner-wise Report',
            'rows'            => $rows,
            'partners'        => $partners,
            'araziOptions'    => $araziOptions,
            'partnerId'       => $partnerId,
            'araziCode'       => $araziCode,
            'activity'        => $activity,
            'dateFrom'        => $dateFrom,
            'dateTo'          => $dateTo,
            'grand_assigned'  => round($gAssigned, 2),
            'grand_sold'      => round($gSold, 2),
            'grand_remaining' => round($gAssigned - $gSold, 2),
        ]);
    }

    /**
     * Arazi-wise report: land totals, sold vs remaining, plots and registry counts per arazi.
     */
    public function arazis(Request $request)
    {
        $araziCode = $request->query('arazi_code', '');
        $location  = $request->query('location', '');
        $saleState = $request->query('sale_state', ''); // sold|partial|unsold
        $dateFrom  = $request->query('date_from', '');
        $dateTo    = $request->query('date_to', '');

        $arazis = Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '<>', '')
            ->orderBy('legacy_arazi_code')
            ->get(['id', 'legacy_arazi_code', 'location', 'size', 'road_area', 'sale_amount_per_gaz']);

        $grouped = $arazis->groupBy('legacy_arazi_code');

        $plotArea = Plot::selectRaw('arazi_code, COUNT(*) as cnt, COALESCE(SUM(area),0) as area')
            ->groupBy('arazi_code')->get()->keyBy('arazi_code');
        $regAgg = Registry::selectRaw("arazi_code, COUNT(*) as cnt, SUM(CASE WHEN LOWER(status)='completed' THEN 1 ELSE 0 END) as done, COALESCE(SUM(COALESCE(land_size,0)),0) as land")
            ->when($dateFrom, fn ($q) => $q->whereDate('registry_date', '>=', $dateFrom))
            ->when($dateTo,   fn ($q) => $q->whereDate('registry_date', '<=', $dateTo))
            ->groupBy('arazi_code')->get()->keyBy('arazi_code');
        $bondAgg = CustomerBond::selectRaw('arazi_code, COUNT(*) as cnt')
            ->groupBy('arazi_code')->get()->keyBy('arazi_code');

        $araziOptions = $grouped->keys()->sort()->values();
        $locationOptions = $arazis->pluck('location')->filter()->unique()->sort()->values();

        $rows = [];
        $tSize = $tSaleable = $tSold = $tRemaining = $tValue = 0;
        foreach ($grouped as $code => $group) {
            if ($araziCode !== '' && (string) $araziCode !== (string) $code) {
                continue;
            }
            $loc = $group->first()->location ?: '-';
            if ($location && $location !== $loc) {
                continue;
            }

            $size = (float) $group->sum('size');
            $road = (float) $group->sum('road_area');
            $saleable = max($size - $road, 0);

            $plots = $plotArea->get($code);
            $reg   = $regAgg->get($code);
            $bond  = $bondAgg->get($code);
            $sold  = (float) ($reg->land ?? 0);
            $remaining = round(max($saleable - $sold, 0), 2);
            $rate = (float) ($group->first()->sale_amount_per_gaz ?? 0);

            $pct = $saleable > 0 ? ($sold / $saleable) * 100 : 0;
            if ($saleState === 'sold' && $pct < 99.9) continue;
            if ($saleState === 'partial' && !($pct > 0 && $pct < 99.9)) continue;
            if ($saleState === 'unsold' && $pct > 0) continue;

            $tSize += $size;
            $tSaleable += $saleable;
            $tSold += $sold;
            $tRemaining += $remaining;
            $tValue += $sold * $rate;

            $rows[] = [
                'arazi'     => $code,
                'location'  => $loc,
                'size'      => round($size, 2),
                'road'      => round($road, 2),
                'saleable'  => round($saleable, 2),
                'plots'     => (int) ($plots->cnt ?? 0),
                'plot_area' => round((float) ($plots->area ?? 0), 2),
                'sold'      => round($sold, 2),
                'remaining' => $remaining,
                'sold_pct'  => round($pct, 1),
                'reg_total' => (int) ($reg->cnt ?? 0),
                'reg_done'  => (int) ($reg->done ?? 0),
                'bonds'     => (int) ($bond->cnt ?? 0),
                'rate'      => $rate,
            ];
        }

        return view('reports.arazis', [
            'title'           => 'Arazi-wise Report',
            'rows'            => $rows,
            'araziOptions'    => $araziOptions,
            'locationOptions' => $locationOptions,
            'araziCode'       => $araziCode,
            'location'        => $location,
            'saleState'       => $saleState,
            'dateFrom'        => $dateFrom,
            'dateTo'          => $dateTo,
            'total_size'      => round($tSize, 2),
            'total_saleable'  => round($tSaleable, 2),
            'total_sold'      => round($tSold, 2),
            'total_remaining' => round($tRemaining, 2),
            'total_value'     => round($tValue, 2),
        ]);
    }

    /**
     * Broker report: bonds, commission and registry activity per broker.
     */
    public function brokers(Request $request)
    {
        $brokerId  = $request->query('broker_id', '');
        $balState  = $request->query('balance_state', ''); // due|clear
        $hasBonds  = $request->query('has_bonds', ''); // 1
        $dateFrom  = $request->query('date_from', '');
        $dateTo    = $request->query('date_to', '');

        $agents = Agent::orderBy('name')->get(['id', 'name', 'mobile', 'commission_percentage']);

        $bondAgg = CustomerBond::selectRaw('broker_id, COUNT(*) as cnt, COALESCE(SUM(total_amount),0) as total, COALESCE(SUM(broker_payment),0) as commission, COALESCE(SUM(broker_paid),0) as paid, COALESCE(SUM(broker_balance),0) as balance')
            ->whereNotNull('broker_id')
            ->when($dateFrom, fn ($q) => $q->whereDate('created_at', '>=', $dateFrom))
            ->when($dateTo,   fn ($q) => $q->whereDate('created_at', '<=', $dateTo))
            ->groupBy('broker_id')->get()->keyBy('broker_id');

        $regAgg = Registry::selectRaw("agent_id, COUNT(*) as cnt, SUM(CASE WHEN LOWER(status)='completed' THEN 1 ELSE 0 END) as done")
            ->whereNotNull('agent_id')
            ->when($dateFrom, fn ($q) => $q->whereDate('registry_date', '>=', $dateFrom))
            ->when($dateTo,   fn ($q) => $q->whereDate('registry_date', '<=', $dateTo))
            ->groupBy('agent_id')->get()->keyBy('agent_id');

        $rows = [];
        $tTotal = $tComm = $tPaid = $tBal = 0;
        foreach ($agents as $a) {
            if ($brokerId && (int) $brokerId !== (int) $a->id) {
                continue;
            }
            $b = $bondAgg->get($a->id);
            $r = $regAgg->get($a->id);
            $bonds   = (int) ($b->cnt ?? 0);
            $balance = round((float) ($b->balance ?? 0), 2);

            if ($hasBonds === '1' && $bonds === 0) continue;
            if ($balState === 'due' && $balance <= 0) continue;
            if ($balState === 'clear' && $balance > 0) continue;

            $tTotal += (float) ($b->total ?? 0);
            $tComm  += (float) ($b->commission ?? 0);
            $tPaid  += (float) ($b->paid ?? 0);
            $tBal   += $balance;

            $rows[] = [
                'broker'         => $a->name,
                'mobile'         => $a->mobile ?: '-',
                'commission_pct' => $a->commission_percentage,
                'bonds'          => $bonds,
                'bond_total'     => round((float) ($b->total ?? 0), 2),
                'commission'     => round((float) ($b->commission ?? 0), 2),
                'paid'           => round((float) ($b->paid ?? 0), 2),
                'balance'        => $balance,
                'reg_total'      => (int) ($r->cnt ?? 0),
                'reg_done'       => (int) ($r->done ?? 0),
            ];
        }

        return view('reports.brokers', [
            'title'            => 'Broker Report',
            'rows'             => $rows,
            'agents'           => $agents,
            'brokerId'         => $brokerId,
            'balanceState'     => $balState,
            'hasBonds'         => $hasBonds,
            'dateFrom'         => $dateFrom,
            'dateTo'           => $dateTo,
            'total_bond'       => round($tTotal, 2),
            'total_commission' => round($tComm, 2),
            'total_paid'       => round($tPaid, 2),
            'total_balance'    => round($tBal, 2),
        ]);
    }

    /**
     * Registry pipeline report grouped by status.
     */
    public function registries(Request $request)
    {
        $araziCode = $request->query('arazi_code', '');
        $agentId   = $request->query('agent_id', '');
        $customerId= $request->query('customer_id', '');
        $payState  = $request->query('pay_state', ''); // paid|partial|unpaid
        $dateFrom  = $request->query('date_from', '');
        $dateTo    = $request->query('date_to', '');

        $agg = Registry::selectRaw("COALESCE(NULLIF(status,''),'unknown') as status, COUNT(*) as cnt, COALESCE(SUM(registry_amount),0) as amount")
            ->groupBy('status')->get();

        $statusRows = $agg->map(fn ($r) => [
            'status' => ucfirst((string) $r->status),
            'count'  => (int) $r->cnt,
            'amount' => round((float) $r->amount, 2),
        ])->all();

        $recent = Registry::with(['customer:id,name', 'agent:id,name'])
            ->when($araziCode,  fn ($q) => $q->where('arazi_code', $araziCode))
            ->when($agentId,    fn ($q) => $q->where('agent_id', $agentId))
            ->when($customerId, fn ($q) => $q->where('customer_id', $customerId))
            ->when($dateFrom,   fn ($q) => $q->whereDate('registry_date', '>=', $dateFrom))
            ->when($dateTo,     fn ($q) => $q->whereDate('registry_date', '<=', $dateTo))
            ->latest('registry_date')
            ->limit(300)
            ->get(['id', 'registry_code', 'customer_id', 'agent_id', 'arazi_code', 'registry_date', 'registry_amount', 'status']);

        // A registry uploaded for an arazi is treated as "registry done".
        // Payment status (percent + balance) is tracked independently of registry completion.
        foreach ($recent as $r) {
            $stats = $this->registryPaymentStats($r);
            $r->pay_percent = $stats['percent'];
            $r->pay_paid    = $stats['paid'];
            $r->pay_total   = $stats['total'];
            $r->pay_balance = $stats['balance'];
        }

        if ($payState !== '') {
            $recent = $recent->filter(function ($r) use ($payState) {
                $p = (float) $r->pay_percent;
                return match ($payState) {
                    'paid'    => $p >= 99.9,
                    'partial' => $p > 0 && $p < 99.9,
                    'unpaid'  => $p <= 0,
                    default   => true,
                };
            })->values();
        }

        $sumAmount  = $recent->sum('registry_amount');
        $sumBalance = $recent->sum('pay_balance');

        $araziOptions = Registry::whereNotNull('arazi_code')->where('arazi_code', '<>', '')
            ->distinct()->orderBy('arazi_code')->pluck('arazi_code');

        return view('reports.registries', [
            'title'         => 'Registry Report',
            'statusRows'    => $statusRows,
            'recent'        => $recent,
            'araziOptions'  => $araziOptions,
            'agents'        => Agent::orderBy('name')->get(['id', 'name']),
            'customers'     => \App\Models\Customer::orderBy('name')->get(['id', 'name']),
            'araziCode'     => $araziCode,
            'agentId'       => $agentId,
            'customerId'    => $customerId,
            'payState'      => $payState,
            'dateFrom'      => $dateFrom,
            'dateTo'        => $dateTo,
            'sum_amount'    => round((float) $sumAmount, 2),
            'sum_balance'   => round((float) $sumBalance, 2),
            'count'         => $recent->count(),
        ]);
    }

    /**
     * Payment progress stats for a registry, resolved from the customer's
     * matching arazi bonds. Returns percent, paid, total and balance.
     */
    protected function registryPaymentStats(Registry $registry): array
    {
        $empty = ['percent' => 0.0, 'paid' => 0.0, 'total' => 0.0, 'balance' => 0.0];

        if (! $registry->customer_id || ! $registry->arazi_code) {
            return $empty;
        }

        $bonds = CustomerBond::where('customer_id', $registry->customer_id)
            ->where('arazi_code', $registry->arazi_code)
            ->withSum('payments as paid_amount', 'amount')
            ->get(['id', 'total_amount', 'bond_amount']);

        if ($bonds->isEmpty()) {
            return $empty;
        }

        $total = (float) $bonds->sum(fn ($b) => (float) ($b->total_amount ?? $b->bond_amount ?? 0));
        $paid  = (float) $bonds->sum(fn ($b) => (float) ($b->paid_amount ?? 0));

        return [
            'percent' => $total > 0 ? round(($paid / $total) * 100.0, 1) : 0.0,
            'paid'    => round($paid, 2),
            'total'   => round($total, 2),
            'balance' => round(max($total - $paid, 0), 2),
        ];
    }

    /**
     * Payment collection report grouped by month and entry type.
     */
    public function payments(Request $request)
    {
        $from      = trim((string) $request->query('date_from', ''));
        $to        = trim((string) $request->query('date_to', ''));
        $entryType = $request->query('entry_type', '');
        $method    = $request->query('payment_method', '');
        $araziCode = $request->query('arazi_code', '');

        $base = CustomerBondPayment::query();
        if ($from !== '') $base->whereDate('entry_date', '>=', $from);
        if ($to !== '')   $base->whereDate('entry_date', '<=', $to);
        if ($entryType)   $base->where('entry_type', $entryType);
        if ($method)      $base->where('payment_method', $method);
        if ($araziCode)   $base->where('arazi_code', $araziCode);

        $byMonth = (clone $base)
            ->selectRaw("DATE_FORMAT(entry_date, '%Y-%m') as ym, COUNT(*) as cnt, COALESCE(SUM(amount),0) as amount")
            ->whereNotNull('entry_date')
            ->groupBy('ym')->orderBy('ym', 'desc')->get()
            ->map(fn ($r) => ['month' => $r->ym, 'count' => (int) $r->cnt, 'amount' => round((float) $r->amount, 2)])
            ->all();

        $byType = (clone $base)
            ->selectRaw('entry_type, COUNT(*) as cnt, COALESCE(SUM(amount),0) as amount')
            ->groupBy('entry_type')->orderBy('entry_type')->get()
            ->map(fn ($r) => ['type' => ucfirst((string) $r->entry_type), 'count' => (int) $r->cnt, 'amount' => round((float) $r->amount, 2)])
            ->all();

        $total = (clone $base)->sum('amount');

        return view('reports.payments', [
            'title'          => 'Payment Collection Report',
            'byMonth'        => $byMonth,
            'byType'         => $byType,
            'total'          => round((float) $total, 2),
            'date_from'      => $from,
            'date_to'        => $to,
            'entry_type'     => $entryType,
            'payment_method' => $method,
            'arazi_code'     => $araziCode,
            'entryTypes'     => CustomerBondPayment::whereNotNull('entry_type')->where('entry_type', '<>', '')->distinct()->orderBy('entry_type')->pluck('entry_type'),
            'methods'        => CustomerBondPayment::whereNotNull('payment_method')->where('payment_method', '<>', '')->distinct()->orderBy('payment_method')->pluck('payment_method'),
            'araziOptions'   => CustomerBondPayment::whereNotNull('arazi_code')->where('arazi_code', '<>', '')->distinct()->orderBy('arazi_code')->pluck('arazi_code'),
        ]);
    }

    /**
     * Overall sales summary across all arazis.
     */
    public function sales(Request $request)
    {
        $araziCode = $request->query('arazi_code', '');
        $location  = $request->query('location', '');
        $dateFrom  = $request->query('date_from', '');
        $dateTo    = $request->query('date_to', '');

        $arazis = Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '<>', '')
            ->get(['legacy_arazi_code', 'location', 'size', 'road_area', 'sale_amount_per_gaz']);

        $grouped = $arazis->groupBy('legacy_arazi_code');

        $araziOptions = $grouped->keys()->sort()->values();
        $locationOptions = $arazis->pluck('location')->filter()->unique()->sort()->values();

        $regLand = Registry::selectRaw('arazi_code, COALESCE(SUM(COALESCE(land_size,0)),0) as land')
            ->when($dateFrom, fn ($q) => $q->whereDate('registry_date', '>=', $dateFrom))
            ->when($dateTo,   fn ($q) => $q->whereDate('registry_date', '<=', $dateTo))
            ->groupBy('arazi_code')->get()->keyBy('arazi_code');

        $breakdown = [];
        $totalSaleable = $totalSold = $totalValue = 0;
        $count = 0;
        foreach ($grouped as $code => $group) {
            if ($araziCode !== '' && (string) $araziCode !== (string) $code) continue;
            $loc = $group->first()->location ?: '-';
            if ($location && $location !== $loc) continue;

            $size = (float) $group->sum('size');
            $road = (float) $group->sum('road_area');
            $saleable = max($size - $road, 0);
            $sold = (float) ($regLand->get($code)->land ?? 0);
            $rate = (float) ($group->first()->sale_amount_per_gaz ?? 0);

            $totalSaleable += $saleable;
            $totalSold += $sold;
            $totalValue += $sold * $rate;
            $count++;

            $breakdown[] = [
                'arazi'     => $code,
                'location'  => $loc,
                'saleable'  => round($saleable, 2),
                'sold'      => round($sold, 2),
                'remaining' => round(max($saleable - $sold, 0), 2),
                'pct'       => $saleable > 0 ? round(($sold / $saleable) * 100, 1) : 0,
                'value'     => round($sold * $rate, 2),
            ];
        }

        $pct = $totalSaleable > 0 ? round(($totalSold / $totalSaleable) * 100, 1) : 0;

        return view('reports.sales', [
            'title'           => 'Sales Summary',
            'arazi_count'     => $count,
            'total_saleable'  => round($totalSaleable, 2),
            'total_sold'      => round($totalSold, 2),
            'total_remaining' => round(max($totalSaleable - $totalSold, 0), 2),
            'sold_pct'        => $pct,
            'total_value'     => round($totalValue, 2),
            'breakdown'       => $breakdown,
            'araziOptions'    => $araziOptions,
            'locationOptions' => $locationOptions,
            'araziCode'       => $araziCode,
            'location'        => $location,
            'dateFrom'        => $dateFrom,
            'dateTo'          => $dateTo,
        ]);
    }
}
