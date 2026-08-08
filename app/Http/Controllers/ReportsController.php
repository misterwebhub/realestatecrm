<?php

namespace App\Http\Controllers;

use App\Models\Agent;
use App\Models\AppSetting;
use App\Models\Arazi;
use App\Models\CustomerBond;
use App\Models\CustomerBondPayment;
use App\Models\DeedMapping;
use App\Models\DeedMerging;
use App\Models\DeedMergingItem;
use App\Models\KisanRegistryBuyer;
use App\Models\Partner;
use App\Models\Plot;
use App\Models\Registry;
use App\Models\User;
use App\Services\EmiCalculator;
use Carbon\Carbon;
use Illuminate\Http\Request;

class ReportsController extends Controller
{
    /**
     * Restrict a deal-data query to the current user's own records, unless they
     * are a Super Admin (who sees everything). No-ops when the model lacks the
     * created_by column or nobody is authenticated.
     */
    protected function ownScope($query)
    {
        $user = auth()->user();
        if (! $user || $user->isSuperAdmin()) {
            return $query;
        }

        $model = $query->getModel();
        try {
            $hasColumn = \Illuminate\Support\Facades\Schema::hasColumn($model->getTable(), 'created_by');
        } catch (\Throwable $e) {
            $hasColumn = false;
        }

        if ($hasColumn) {
            $query->where($model->qualifyColumn('created_by'), $user->getKey());
        }

        return $query;
    }

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

        $paymentsQuery = CustomerBondPayment::with([
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
            ->orderBy('id');

        // Non-admins only see payments they created; admins see everything.
        $payments = $this->ownScope($paymentsQuery)->get();

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
        $plotRegistry  = trim((string) $request->query('plot_registry', '')); // '', 'Y', 'N'

        $bondsQuery = CustomerBond::with(['customer', 'arazi', 'plots', 'broker', 'payments', 'cheques.connectedAccount'])
            ->when($customerId,    fn ($q) => $q->where('customer_id', $customerId))
            ->when($bondId,        fn ($q) => $q->where('id', $bondId))
            ->when($araziCode,     fn ($q) => $q->where('arazi_code', $araziCode))
            ->when($brokerId,      fn ($q) => $q->where('broker_id', $brokerId))
            ->when($userId,        fn ($q) => $q->whereHas('payments', fn ($p) => $p->where('taken_by_user_id', $userId)))
            ->when($entryType,     fn ($q) => $q->whereHas('payments', fn ($p) => $p->where('entry_type', $entryType)))
            ->when($paymentMethod, fn ($q) => $q->whereHas('payments', fn ($p) => $p->where('payment_method', $paymentMethod)))
            ->orderBy('bond_no');

        // Non-admins only see their own bonds; admins see everything.
        $bonds = $this->ownScope($bondsQuery)->get();

        // Registry lookup keyed by customer + arazi (deed/partner/status).
        $regMap = [];
        foreach (Registry::with('partner:id,name')->get(['id', 'customer_id', 'arazi_code', 'deed_no', 'partner_id', 'status']) as $reg) {
            $key = $reg->customer_id . '|' . $reg->arazi_code;
            if (! isset($regMap[$key])) {
                $regMap[$key] = $reg;
            }
        }

        // Plot ids that already have a registry record — drives the per-plot Y/N badge.
        // Includes both the legacy singular plot_id column and every plot attached
        // via the registry_plot pivot (multi-plot registries).
        $plotIdsWithRegistry = Registry::whereNotNull('plot_id')->distinct()->pluck('plot_id')
            ->merge(\Illuminate\Support\Facades\DB::table('registry_plot')->distinct()->pluck('plot_id'))
            ->unique()->flip()->all();

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
        $gPlotArea = $gSoldArea = 0.0;

        foreach ($bonds as $bond) {
            $code = $bond->arazi_code ?: ($bond->arazi?->legacy_arazi_code ?? '-');
            $reg  = $regMap[$bond->customer_id . '|' . $code] ?? null;

            // Registry-derived filters.
            if ($partnerId !== '' && (! $reg || (string) $reg->partner_id !== (string) $partnerId)) continue;
            if ($deedNo !== '' && (! $reg || stripos((string) $reg->deed_no, $deedNo) === false)) continue;

            $plotsData = $bond->plots->map(fn ($pl) => [
                'label'    => $pl->title ?: ('Plot-' . $pl->id),
                'gaz'      => (float) ($pl->area ?? 0),
                'registry' => isset($plotIdsWithRegistry[$pl->id]) ? 'Y' : 'N',
            ])->values()->all();

            // Sold area = area of this bond's plots that already have a registry record
            // (Registry = Y), i.e. the portion actually sold/registered so far.
            $plotArea = (float) collect($plotsData)->sum('gaz');
            $soldArea = (float) collect($plotsData)->where('registry', 'Y')->sum('gaz');

            // Plot Registry filter — keep the bond only if one of its plots matches Y/N.
            if ($plotRegistry !== '' && ! collect($plotsData)->contains(fn ($p) => $p['registry'] === $plotRegistry)) {
                continue;
            }

            // Payments: lifetime and within-period net paid.
            $paidAll = (float) $bond->payments->whereNotIn('entry_type', $debitTypes)->sum('amount')
                     - (float) $bond->payments->whereIn('entry_type', $debitTypes)->sum('amount');

            // Paid column = CASH payments only (within selected period).
            $periodPayments = ($dateFrom === '' && $dateTo === '')
                ? $bond->payments
                : $bond->payments->filter(fn ($p) => $inRange($p->entry_date));

            // Date filter is based on the customer payment entry date: when a
            // date range is applied, only bonds that actually have a payment
            // entry inside that range should appear in the report.
            if (($dateFrom !== '' || $dateTo !== '') && $periodPayments->isEmpty()) {
                continue;
            }

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
                'plots'          => $plotsData,
                'plot_area'      => round($plotArea, 2),
                'sold_area'      => round($soldArea, 2),
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
            $gPlotArea += $plotArea;
            $gSoldArea += $soldArea;
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
                'Plot Registry' => $plotRegistry !== '' ? ($plotRegistry === 'Y' ? 'Yes' : 'No') : 'All',
                'Date From' => $dateFrom !== '' ? $dateFrom : 'All',
                'Date To'   => $dateTo !== '' ? $dateTo : 'All',
            ];

            $filename = 'bond-cumulative-' . now()->format('Ymd-His') . '.csv';

            return response()->streamDownload(function () use ($rows, $filters, $gTotal, $gPaid, $gChequePaid, $gChequeBal, $gChequeTotal, $gPaidAll, $gBalance, $gPlotArea, $gSoldArea) {
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
                    '#', 'Bond Date', 'Bond', 'Customer', 'Arazi', 'Plots (gaz)', 'Sold Area (gaz)', 'Broker',
                    'Bond Amount', 'Paid (cash)', 'Cheque Paid', 'Cheque Balance', 'Registry',
                    'Cheque Name', 'Cheque Paid (all)', 'Cheque Unpaid (all)', 'Cheque Total',
                    'Total Paid (all)', 'Total Balance (all)',
                ]);

                foreach ($rows as $i => $r) {
                    $plots = collect($r['plots'])->map(fn ($pl) => ($pl['label'] ?: '-') . ' (' . rtrim(rtrim(number_format($pl['gaz'], 2), '0'), '.') . ' gaz, Registry: ' . $pl['registry'] . ')')->implode('; ');
                    fputcsv($out, [
                        $i + 1,
                        $r['bond_date'] ?: '-',
                        $r['bond_no'],
                        $r['customer'],
                        $r['arazi'],
                        $plots,
                        number_format($r['sold_area'], 2, '.', ''),
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
                    'GRAND TOTAL', '', '', '', '', '',
                    number_format($gSoldArea, 2, '.', ''),
                    '',
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
            'plotRegistry'  => $plotRegistry,
            'g_total'         => round($gTotal, 2),
            'g_paid'          => round($gPaid, 2),
            'g_balance'       => round($gBalance, 2),
            'g_cheque_paid'   => round($gChequePaid, 2),
            'g_cheque_balance'=> round($gChequeBal, 2),
            'g_cheque_total'  => round($gChequeTotal, 2),
            'g_paid_all'      => round($gPaidAll, 2),
            'g_plot_area'     => round($gPlotArea, 2),
            'g_sold_area'     => round($gSoldArea, 2),
        ]);
    }

    /**
     * Pending Installments / EMI report: one row per bond with a valid EMI
     * schedule (installment count + first due date). Everything — Finance
     * Amount, Monthly EMI, Expected-till-date, Outstanding, Credit, last/next
     * EMI — is derived dynamically from the bond's payment history via
     * EmiCalculator. No individual installment rows are stored anywhere, so
     * partial payments, bulk/multi-month payments, and large advance
     * payments are all handled automatically without manual adjustment.
     * Fully paid bonds are hidden unless explicitly filtered for.
     */
    public function pendingInstallments(Request $request)
    {
        $customerId = $request->query('customer_id', '');
        $bondId     = $request->query('bond_id', '');
        $araziCode  = $request->query('arazi_code', '');
        $status     = $request->query('status', ''); // overdue|partial|ahead|on_time|fully_paid
        $dateFromRaw = $request->query('date_from', '');
        $dateToRaw   = $request->query('date_to', '');

        $overdueDays  = (int) (AppSetting::get(AppSetting::INSTALLMENT_OVERDUE_DAYS) ?? 0);
        $reminderDays = (int) (AppSetting::get(AppSetting::INSTALLMENT_REMINDER_DAYS) ?? 0);

        $today = now()->startOfDay();

        // Default "Due Date From/To" window (per Settings → Installment
        // Reminder & Overdue Settings): From = today, To = today + Reminder
        // Days, so the report surfaces installments due now through the
        // upcoming reminder window out of the box. Bonds that are already
        // unpaid past their due date (Partial/Overdue — governed by the
        // Overdue Days setting) always show regardless of this window; the
        // user can widen/narrow the window manually via the filter form.
        $dateFrom = $dateFromRaw !== '' ? $dateFromRaw : $today->format('Y-m-d');
        $dateTo   = $dateToRaw !== '' ? $dateToRaw : $today->copy()->addDays($reminderDays)->format('Y-m-d');

        try {
            $dateFromC = Carbon::parse($dateFrom)->startOfDay();
        } catch (\Throwable $e) {
            $dateFromC = $today->copy();
        }
        try {
            $dateToC = Carbon::parse($dateTo)->endOfDay();
        } catch (\Throwable $e) {
            $dateToC = $today->copy()->addDays($reminderDays)->endOfDay();
        }

        $bondsQuery = CustomerBond::with(['customer', 'arazi', 'payments', 'cheques'])
            ->whereNotNull('last_date')
            ->where('installment_amount', '>', 0)
            ->when($customerId, fn ($q) => $q->where('customer_id', $customerId))
            ->when($bondId,     fn ($q) => $q->where('id', $bondId))
            ->when($araziCode,  fn ($q) => $q->where('arazi_code', $araziCode))
            ->orderBy('last_date');

        // Non-admins only see their own bonds; admins see everything.
        $bonds = $this->ownScope($bondsQuery)->get();

        $rows = [];
        $gBondAmount = $gAdvance = $gFinance = $gExpected = $gPaid = $gOutstanding = $gCredit = $gRemaining = 0.0;
        // Cash/Cheque split (see docblock above the loop for the logic).
        $gChequeTotal = $gChequePaid = $gChequePendingBalance = 0.0;
        $gCashPaid = $gCashPendingBalance = 0.0;
        $gTotalPaidAll = $gTotalBalanceAll = 0.0;

        foreach ($bonds as $bond) {
            $emi = EmiCalculator::calculate($bond, $today, $overdueDays);

            // This is a "pending" report — hide bonds that are fully paid off
            // unless the user explicitly asks to see the Fully Paid bucket.
            if ($emi['is_fully_paid'] && $status !== EmiCalculator::STATUS_FULLY_PAID) {
                continue;
            }

            if ($status !== '' && $emi['status'] !== $status) {
                continue;
            }

            // The Due Date From/To window filters *upcoming* next-EMI dates
            // (On Time / Ahead of Schedule bonds). Anything already unpaid
            // past its due date (Partial/Overdue) is an "overdue" condition
            // governed solely by the Overdue Days setting, so it always
            // surfaces regardless of the date window.
            $hasOutstanding = $emi['outstanding'] > 0.009;
            if (! $hasOutstanding && $emi['next_due_date']) {
                if ($emi['next_due_date']->lt($dateFromC) || $emi['next_due_date']->gt($dateToC)) {
                    continue;
                }
            }

            // ── Cash / Cheque split ──────────────────────────────────────
            // A bond's amount is expected to be covered partly by cheques
            // (post-dated cheques logged against the bond via "Assign
            // Cheques to Bond") and whatever's left of the bond amount is
            // treated as the "cash" portion. Example: Bond = 1000, cheques
            // worth 500 were created against it -> the other 500 is the cash
            // portion. If 300 of those cheques have cleared, Payment from
            // Cheque = 300, Pending Cheque Balance = 200. Any money actually
            // received that isn't accounted for by a cleared cheque (cash,
            // RTGS, UPI, the booking advance, etc.) counts as "cash paid" —
            // so Pending Cash Balance = 500 - 0 = 500 in that example.
            // This is computed live every request, nothing is stored.
            $chequeTotal = round((float) $bond->cheques->sum('amount'), 2);
            $chequePaid  = round((float) $bond->cheques->where('status', 'cleared')->sum('amount'), 2);
            $chequePendingBalance = round(max($chequeTotal - $chequePaid, 0), 2);

            // Everything ever paid on the bond, any method (advance/booking
            // payment + every EMI-side entry) — $emi['total_paid'] alone
            // excludes the advance, so add it back in here.
            $totalPaidAll = round($emi['advance_amount'] + $emi['total_paid'], 2);

            $cashPortion = round(max($emi['bond_amount'] - $chequeTotal, 0), 2);
            $cashPaid    = round(max($totalPaidAll - $chequePaid, 0), 2);
            $cashPendingBalance = round(max($cashPortion - $cashPaid, 0), 2);

            $totalBalanceAll = round(max($emi['bond_amount'] - $totalPaidAll, 0), 2);

            $meta = EmiCalculator::statusMeta($emi['status']);

            // Reminder flag: next EMI falls due within the configured reminder
            // window and the bond isn't already behind on anything.
            $isReminder = false;
            if ($emi['next_due_date'] && in_array($emi['status'], [EmiCalculator::STATUS_ON_TIME, EmiCalculator::STATUS_AHEAD], true)) {
                $daysToNextDue = $today->diffInDays($emi['next_due_date'], false);
                $isReminder = $daysToNextDue >= 0 && $daysToNextDue <= $reminderDays;
            }

            $rows[] = [
                'bond_id'            => $bond->id,
                'bond_no'            => $bond->bond_no ?? ('BOND-' . $bond->id),
                'bond_date'          => optional($bond->bond_date)->format('d-m-Y'),
                'customer'           => $bond->customer?->name ?? '—',
                'customer_mobile'    => $bond->customer?->mobile ?? '—',
                'bond_amount'        => $emi['bond_amount'],
                'advance_amount'     => $emi['advance_amount'],
                'finance_amount'     => $emi['finance_amount'],
                'total_installments' => $emi['total_installments'],
                'monthly_emi'        => $emi['monthly_emi'],
                'expected_till_date' => $emi['expected_till_date'],
                'total_paid'         => $emi['total_paid'],
                'outstanding'        => $emi['outstanding'],
                'credit'             => $emi['credit'],
                'remaining_balance'  => $emi['remaining_balance'],
                'last_emi_number'    => $emi['last_emi_number'],
                'last_emi_amount'    => $emi['last_emi_amount'],
                'last_emi_date'      => $emi['last_emi_date']?->format('d-m-Y'),
                'next_emi_number'    => $emi['next_emi_number'],
                'next_emi_amount'    => $emi['next_emi_amount'],
                'next_due_date'      => $emi['next_due_date']?->format('d-m-Y'),
                'overdue_human'      => $emi['overdue_human'],
                'is_reminder'        => $isReminder,
                'status'             => $emi['status'],
                'status_label'       => $meta['label'],
                'status_emoji'       => $meta['emoji'],
                'status_badge'       => $meta['badge'],
                'cheque_total'          => $chequeTotal,
                'cheque_paid'           => $chequePaid,
                'cheque_pending_balance'=> $chequePendingBalance,
                'cash_paid'             => $cashPaid,
                'cash_pending_balance'  => $cashPendingBalance,
                'total_paid_all'        => $totalPaidAll,
                'total_balance_all'     => $totalBalanceAll,
            ];

            $gBondAmount  += $emi['bond_amount'];
            $gAdvance     += $emi['advance_amount'];
            $gFinance     += $emi['finance_amount'];
            $gExpected    += $emi['expected_till_date'];
            $gPaid        += $emi['total_paid'];
            $gOutstanding += $emi['outstanding'];
            $gCredit      += $emi['credit'];
            $gRemaining   += $emi['remaining_balance'];

            $gChequeTotal          += $chequeTotal;
            $gChequePaid           += $chequePaid;
            $gChequePendingBalance += $chequePendingBalance;
            $gCashPaid             += $cashPaid;
            $gCashPendingBalance   += $cashPendingBalance;
            $gTotalPaidAll         += $totalPaidAll;
            $gTotalBalanceAll      += $totalBalanceAll;
        }

        if (strtolower((string) $request->query('export')) === 'csv') {
            $filters = [
                'Customer'      => $customerId ? optional(\App\Models\Customer::find($customerId))->name : 'All',
                'Bond'          => $bondId ? optional(CustomerBond::find($bondId))->bond_no : 'All',
                'Arazi'         => $araziCode !== '' ? $araziCode : 'All',
                'Status'        => $status !== '' ? EmiCalculator::statusMeta($status)['label'] : 'All',
                'Due Date From' => $dateFrom !== '' ? $dateFrom : 'All',
                'Due Date To'   => $dateTo !== '' ? $dateTo : 'All',
                'Overdue After (days)'  => $overdueDays,
                'Reminder Before (days)'=> $reminderDays,
            ];

            $filename = 'pending-installments-' . now()->format('Ymd-His') . '.csv';

            return response()->streamDownload(function () use ($rows, $filters, $gBondAmount, $gAdvance, $gFinance, $gExpected, $gPaid, $gOutstanding, $gCredit, $gRemaining, $gChequeTotal, $gChequePaid, $gChequePendingBalance, $gCashPaid, $gCashPendingBalance, $gTotalPaidAll, $gTotalBalanceAll) {
                $out = fopen('php://output', 'w');
                fwrite($out, "\xEF\xBB\xBF");

                fputcsv($out, ['Pending Installments / EMI Report']);
                fputcsv($out, ['Generated', now()->format('d-m-Y H:i')]);
                fputcsv($out, []);
                fputcsv($out, ['Filters Applied']);
                foreach ($filters as $label => $value) {
                    fputcsv($out, [$label, $value !== '' && $value !== null ? $value : 'All']);
                }
                fputcsv($out, []);

                fputcsv($out, [
                    '#', 'Bond', 'Bond Date', 'Customer', 'Mobile',
                    'Bond Amount', 'Advance', 'Finance Amount', 'No. of Installments', 'Monthly EMI',
                    'Expected Till Date', 'Total Paid', 'Outstanding', 'Credit', 'Remaining Balance',
                    'Last EMI #', 'Last EMI Date', 'Last EMI Amount',
                    'Next EMI #', 'Next Due Date', 'Next EMI Amount',
                    'Overdue', 'Status',
                    'Cheque Total', 'Payment from Cheque', 'Pending Cheque Balance',
                    'Payment from Cash', 'Pending Cash Balance',
                    'Total Paid (Cash+Cheque)', 'Total Balance',
                ]);

                foreach ($rows as $i => $r) {
                    fputcsv($out, [
                        $i + 1,
                        $r['bond_no'],
                        $r['bond_date'] ?: '-',
                        $r['customer'],
                        $r['customer_mobile'],
                        number_format($r['bond_amount'], 2, '.', ''),
                        number_format($r['advance_amount'], 2, '.', ''),
                        number_format($r['finance_amount'], 2, '.', ''),
                        $r['total_installments'],
                        number_format($r['monthly_emi'], 2, '.', ''),
                        number_format($r['expected_till_date'], 2, '.', ''),
                        number_format($r['total_paid'], 2, '.', ''),
                        number_format($r['outstanding'], 2, '.', ''),
                        number_format($r['credit'], 2, '.', ''),
                        number_format($r['remaining_balance'], 2, '.', ''),
                        $r['last_emi_number'] ?? '-',
                        $r['last_emi_date'] ?? '-',
                        $r['last_emi_amount'] !== null ? number_format($r['last_emi_amount'], 2, '.', '') : '-',
                        $r['next_emi_number'] ?? '-',
                        $r['next_due_date'] ?? '-',
                        $r['next_emi_amount'] !== null ? number_format($r['next_emi_amount'], 2, '.', '') : '-',
                        $r['overdue_human'] ?? '-',
                        $r['status_label'],
                        number_format($r['cheque_total'], 2, '.', ''),
                        number_format($r['cheque_paid'], 2, '.', ''),
                        number_format($r['cheque_pending_balance'], 2, '.', ''),
                        number_format($r['cash_paid'], 2, '.', ''),
                        number_format($r['cash_pending_balance'], 2, '.', ''),
                        number_format($r['total_paid_all'], 2, '.', ''),
                        number_format($r['total_balance_all'], 2, '.', ''),
                    ]);
                }

                fputcsv($out, []);
                fputcsv($out, [
                    'GRAND TOTAL', '', '', '', '',
                    number_format($gBondAmount, 2, '.', ''),
                    number_format($gAdvance, 2, '.', ''),
                    number_format($gFinance, 2, '.', ''),
                    '',
                    '',
                    number_format($gExpected, 2, '.', ''),
                    number_format($gPaid, 2, '.', ''),
                    number_format($gOutstanding, 2, '.', ''),
                    number_format($gCredit, 2, '.', ''),
                    number_format($gRemaining, 2, '.', ''),
                    '', '', '', '', '', '', '', '',
                    number_format($gChequeTotal, 2, '.', ''),
                    number_format($gChequePaid, 2, '.', ''),
                    number_format($gChequePendingBalance, 2, '.', ''),
                    number_format($gCashPaid, 2, '.', ''),
                    number_format($gCashPendingBalance, 2, '.', ''),
                    number_format($gTotalPaidAll, 2, '.', ''),
                    number_format($gTotalBalanceAll, 2, '.', ''),
                ]);

                fclose($out);
            }, $filename, ['Content-Type' => 'text/csv; charset=UTF-8']);
        }

        return view('reports.pending_installments', [
            'title'         => 'Pending Installments / EMI Report',
            'rows'          => $rows,
            'customers'     => \App\Models\Customer::orderBy('name')->get(['id', 'name']),
            'bondsList'     => CustomerBond::whereNotNull('last_date')->orderBy('bond_no')->get(['id', 'bond_no']),
            'araziCodes'    => CustomerBond::whereNotNull('arazi_code')->where('arazi_code', '!=', '')->distinct()->orderBy('arazi_code')->pluck('arazi_code'),
            'customerId'    => $customerId,
            'bondId'        => $bondId,
            'araziCode'     => $araziCode,
            'status'        => $status,
            'dateFrom'      => $dateFrom,
            'dateTo'        => $dateTo,
            'overdueDays'   => $overdueDays,
            'reminderDays'  => $reminderDays,
            'g_bond_amount' => round($gBondAmount, 2),
            'g_advance'     => round($gAdvance, 2),
            'g_finance'     => round($gFinance, 2),
            'g_expected'    => round($gExpected, 2),
            'g_paid'        => round($gPaid, 2),
            'g_outstanding' => round($gOutstanding, 2),
            'g_credit'      => round($gCredit, 2),
            'g_remaining'   => round($gRemaining, 2),
            'g_cheque_total'           => round($gChequeTotal, 2),
            'g_cheque_paid'            => round($gChequePaid, 2),
            'g_cheque_pending_balance' => round($gChequePendingBalance, 2),
            'g_cash_paid'              => round($gCashPaid, 2),
            'g_cash_pending_balance'   => round($gCashPendingBalance, 2),
            'g_total_paid_all'         => round($gTotalPaidAll, 2),
            'g_total_balance_all'      => round($gTotalBalanceAll, 2),
        ]);
    }

    /**
     * Customer/Bond EMI Detail screen: full financial summary for one bond
     * plus a dynamically-computed payment-history ledger (running total,
     * outstanding, and credit as of each transaction's own date). Nothing
     * here is read from stored installment rows — it's all recomputed from
     * EmiCalculator + the bond's raw payment history every time.
     */
    public function emiDetail(CustomerBond $customerBond)
    {
        $customerBond->load([
            'customer',
            'arazi',
            'payments' => fn ($q) => $q->orderBy('entry_date')->orderBy('id'),
        ]);

        $overdueDays = (int) (AppSetting::get(AppSetting::INSTALLMENT_OVERDUE_DAYS) ?? 0);
        $today = now()->startOfDay();

        $emi = EmiCalculator::calculate($customerBond, $today, $overdueDays);
        $meta = EmiCalculator::statusMeta($emi['status']);

        $dueDate = $emi['due_date'];
        $monthlyEmi = $emi['monthly_emi'];
        $totalInstallments = $emi['total_installments'];

        $history = [];
        $runningEmiTotal = 0.0;

        foreach ($customerBond->payments as $p) {
            $isAdvance = in_array($p->entry_type, EmiCalculator::ADVANCE_TYPES, true);
            $isDebit   = in_array($p->entry_type, EmiCalculator::DEBIT_TYPES, true);
            $amount    = (float) $p->amount;

            $entryDate = $p->entry_date instanceof \Carbon\Carbon ? $p->entry_date : \Carbon\Carbon::parse($p->entry_date);

            $runningTotal = null;
            $outstandingAtDate = null;
            $creditAtDate = null;
            $remarks = trim((string) $p->remarks);

            if ($isAdvance) {
                $remarks = trim(($remarks !== '' ? $remarks . ' — ' : '') . 'Booking/Advance amount — excluded from EMI schedule');
            } else {
                $runningEmiTotal += $isDebit ? -$amount : $amount;
                $runningEmiTotal = max($runningEmiTotal, 0.0);
                $runningTotal = round($runningEmiTotal, 2);

                $emisDueAtDate = 0;
                if ($dueDate && $totalInstallments > 0 && ! $dueDate->greaterThan($entryDate)) {
                    $emisDueAtDate = min($dueDate->diffInMonths($entryDate) + 1, $totalInstallments);
                }
                $expectedAtDate = round($emisDueAtDate * $monthlyEmi, 2);
                $outstandingAtDate = round(max($expectedAtDate - $runningEmiTotal, 0), 2);
                $creditAtDate = round(max($runningEmiTotal - $expectedAtDate, 0), 2);

                if ($isDebit) {
                    $remarks = trim(($remarks !== '' ? $remarks . ' — ' : '') . ucfirst($p->entry_type) . ' (deducted)');
                }
            }

            $history[] = [
                'date'          => $entryDate->format('d-m-Y'),
                'amount'        => $amount,
                'is_debit'      => $isDebit,
                'is_advance'    => $isAdvance,
                'type'          => ucfirst($p->entry_type ?: 'payment'),
                'mode'          => $p->payment_method ?: '—',
                'running_total' => $runningTotal,
                'outstanding'   => $outstandingAtDate,
                'credit'        => $creditAtDate,
                'remarks'       => $remarks !== '' ? $remarks : '—',
            ];
        }

        return view('reports.emi_detail', [
            'title'       => 'EMI Detail — ' . ($customerBond->bond_no ?? ('BOND-' . $customerBond->id)),
            'bond'        => $customerBond,
            'emi'         => $emi,
            'meta'        => $meta,
            'history'     => array_reverse($history),
            'overdueDays' => $overdueDays,
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

        $bond = $this->ownScope(CustomerBond::with(['cheques' => function ($q) {
            $q->orderBy('cheque_date');
        }]))->find($bondId);

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

        $deeds = $this->ownScope(Registry::where('arazi_code', $code))
            ->whereNotNull('deed_no')
            ->where('deed_no', '!=', '')
            ->distinct()
            ->orderBy('deed_no')
            ->pluck('deed_no')
            ->values();

        return response()->json(['deeds' => $deeds]);
    }

    /**
     * Deed Merge Breakdown: for a chosen Merged Deed No, show which arazi record (kisan
     * share) each member deed no came from, how much saleable area it contributed — i.e.
     * how much land was consolidated into that merged Deed No, and from where — and how
     * much of it has actually been sold (registered).
     *
     * A registry can reference a deed no either as one of the original member deed nos
     * (if the sale happened before the merge) or as the new merged_deed_no itself (if sold
     * after consolidation), so both are matched: per-row against the member's own deed no,
     * and a merge-level total against the merged_deed_no directly.
     */
    public function deedMergeBreakdown(Request $request)
    {
        $mergingId = trim((string) $request->query('deed_merging_id', ''));

        // Searchable "Merged Deed No" select — one option per merge.
        $merges = $this->ownScope(
            DeedMerging::whereNotNull('merged_deed_no')->where('merged_deed_no', '!=', '')
        )->orderBy('merged_deed_no')->get(['id', 'arazi_code', 'merged_deed_no']);

        $selected        = null;
        $rows            = [];
        $totalSaleable   = 0.0;
        $totalSoldRows   = 0.0;
        $mergedSold      = 0.0;
        $totalSold       = 0.0;
        $totalRemaining  = 0.0;

        if ($mergingId !== '') {
            $selected = $this->ownScope(DeedMerging::query())
                ->with(['partner', 'items.arazi.kisan'])
                ->find($mergingId);

            if ($selected) {
                $memberDeedNos = $selected->items->pluck('deed_no')->filter()->values()->all();
                $allDeedNos    = array_unique(array_merge($memberDeedNos, [$selected->merged_deed_no]));

                // Sold area per deed no: sum of registrySoldArea() for every registry
                // recorded against that deed no, whether it's a member's original deed no
                // or the merged deed no itself.
                $soldByDeedNo = $this->ownScope(Registry::query())
                    ->whereIn('deed_no', $allDeedNos)
                    ->with('plot')
                    ->get()
                    ->groupBy('deed_no')
                    ->map(fn ($regs) => $regs->sum(fn ($r) => $this->registrySoldArea($r)));

                foreach ($selected->items as $item) {
                    $arazi    = $item->arazi;
                    $saleable = $arazi ? (float) $arazi->saleable_area : 0.0;
                    $sold     = (float) ($soldByDeedNo[$item->deed_no] ?? 0);
                    $remaining = max(0, round($saleable - $sold, 2));

                    $totalSaleable += $saleable;
                    $totalSoldRows += $sold;

                    $rows[] = [
                        'deed_no'       => $item->deed_no,
                        'arazi_code'    => $arazi->legacy_arazi_code ?? '-',
                        'kisan'         => $arazi->kisan->name ?? '-',
                        'saleable_area' => round($saleable, 2),
                        'sold_area'     => round($sold, 2),
                        'remaining'     => $remaining,
                    ];
                }

                // Sold directly against the merged deed no (post-merge sales) — kept
                // separate from the per-row member sums since it isn't tied to one arazi.
                $mergedSold = (float) ($soldByDeedNo[$selected->merged_deed_no] ?? 0);

                $totalSold      = $totalSoldRows + $mergedSold;
                $totalRemaining = max(0, round($totalSaleable - $totalSold, 2));
            }
        }

        return view('reports.deed_merge_breakdown', [
            'title'           => 'Deed Merge Breakdown',
            'merges'          => $merges,
            'mergingId'       => $mergingId,
            'selected'        => $selected,
            'rows'            => $rows,
            'totalSaleable'   => round($totalSaleable, 2),
            'mergedSold'      => round($mergedSold, 2),
            'totalSold'       => round($totalSold, 2),
            'totalRemaining'  => $totalRemaining,
        ]);
    }

    /**
     * Deed Report: look up a single Deed No (raw/original or a Merged Deed No)
     * and show its full picture — allotted (saleable) area, sold area, and
     * remaining ("left") area — along with the Merged Deed No it belongs to
     * (if any) or the member deeds consolidated into it (if it IS a merged
     * deed no).
     *
     * A deed no can be one of three things in this app:
     *   1. A Merged Deed No itself (deed_mergings.merged_deed_no) — an
     *      aggregate of several original deeds.
     *   2. An original member deed no that was later merged into a Merged
     *      Deed No (deed_merging_items.deed_no).
     *   3. A standalone deed no that was never merged (deed_mappings.deed_no).
     */
    public function deedReport(Request $request)
    {
        $deedNo = trim((string) $request->query('deed_no', ''));

        $result = null;
        if ($deedNo !== '') {
            $result = $this->resolveDeedReport($deedNo);
        }

        return view('reports.deed_report', [
            'title'   => 'Deed Report',
            'deedNo'  => $deedNo,
            'result'  => $result,
        ]);
    }

    /**
     * Resolve a single deed no into its full report data, handling all three
     * cases described on deedReport() above. Returns null only when nothing
     * at all (no mapping, no merge, no registry) references this deed no.
     */
    protected function resolveDeedReport(string $deedNo): ?array
    {
        // Case 1: the searched value IS a Merged Deed No — aggregate across
        // every original member deed consolidated into it (same math as
        // deedMergeBreakdown()).
        $merge = $this->ownScope(DeedMerging::where('merged_deed_no', $deedNo))
            ->with(['partner', 'items.arazi.kisan'])
            ->first();

        if ($merge) {
            $memberDeedNos = $merge->items->pluck('deed_no')->filter()->values()->all();
            $allDeedNos    = array_unique(array_merge($memberDeedNos, [$merge->merged_deed_no]));

            $soldByDeedNo = $this->ownScope(Registry::query())
                ->whereIn('deed_no', $allDeedNos)
                ->with('plot')
                ->get()
                ->groupBy('deed_no')
                ->map(fn ($regs) => $regs->sum(fn ($r) => $this->registrySoldArea($r)));

            $members = [];
            $allotted = 0.0;
            $memberSold = 0.0;
            foreach ($merge->items as $item) {
                $arazi    = $item->arazi;
                $saleable = $arazi ? (float) $arazi->saleable_area : 0.0;
                $sold     = (float) ($soldByDeedNo[$item->deed_no] ?? 0);
                $allotted += $saleable;
                $memberSold += $sold;

                $members[] = [
                    'deed_no'  => $item->deed_no,
                    'arazi_code' => $arazi->legacy_arazi_code ?? '-',
                    'kisan'    => $arazi->kisan->name ?? '-',
                    'allotted' => round($saleable, 2),
                    'sold'     => round($sold, 2),
                    'remaining' => max(0, round($saleable - $sold, 2)),
                ];
            }

            $mergedSold = (float) ($soldByDeedNo[$merge->merged_deed_no] ?? 0);
            $sold       = $memberSold + $mergedSold;

            return [
                'type'           => 'merged',
                'deed_no'        => $deedNo,
                'merged_deed_no' => $merge->merged_deed_no,
                'partner'        => $merge->partner->name ?? '-',
                'arazi_code'     => $merge->arazi_code,
                'kisan'          => '-',
                'allotted'       => round($allotted, 2),
                'sold'           => round($sold, 2),
                'remaining'      => max(0, round($allotted - $sold, 2)),
                'merged_sold'    => round($mergedSold, 2),
                'members'        => $members,
            ];
        }

        // Case 2: the searched value is an ORIGINAL deed no that was later
        // merged into a bigger Merged Deed No. deed_merging_items has no
        // created_by of its own, so scope through the parent DeedMerging.
        $memberItem = DeedMergingItem::where('deed_no', $deedNo)
            ->whereHas('deedMerging', fn ($q) => $this->ownScope($q))
            ->with(['deedMerging', 'arazi.kisan'])
            ->first();

        if ($memberItem) {
            $arazi    = $memberItem->arazi;
            $allotted = $arazi ? (float) $arazi->saleable_area : 0.0;
            $sold     = (float) $this->ownScope(Registry::where('deed_no', $deedNo))
                ->with('plot')->get()->sum(fn ($r) => $this->registrySoldArea($r));

            return [
                'type'           => 'member',
                'deed_no'        => $deedNo,
                'merged_deed_no' => $memberItem->deedMerging->merged_deed_no ?? '-',
                'partner'        => '-',
                'arazi_code'     => $arazi->legacy_arazi_code ?? '-',
                'kisan'          => $arazi->kisan->name ?? '-',
                'allotted'       => round($allotted, 2),
                'sold'           => round($sold, 2),
                'remaining'      => max(0, round($allotted - $sold, 2)),
                'merged_sold'    => null,
                'members'        => [],
            ];
        }

        // Case 3: a standalone deed no that was never part of any merge.
        $mapping = $this->ownScope(DeedMapping::where('deed_no', $deedNo))
            ->with(['arazi.kisan', 'partner'])->first();

        if ($mapping) {
            $arazi    = $mapping->arazi;
            $allotted = $arazi ? (float) $arazi->saleable_area : 0.0;
            $sold     = (float) $this->ownScope(Registry::where('deed_no', $deedNo))
                ->with('plot')->get()->sum(fn ($r) => $this->registrySoldArea($r));

            return [
                'type'           => 'standalone',
                'deed_no'        => $deedNo,
                'merged_deed_no' => '-',
                'partner'        => $mapping->partner->name ?? '-',
                'arazi_code'     => $arazi->legacy_arazi_code ?? '-',
                'kisan'          => $arazi->kisan->name ?? '-',
                'allotted'       => round($allotted, 2),
                'sold'           => round($sold, 2),
                'remaining'      => max(0, round($allotted - $sold, 2)),
                'merged_sold'    => null,
                'members'        => [],
            ];
        }

        // Case 4 (fallback): no formal deed mapping/merge record at all, but
        // registries were still filed directly against this deed no — report
        // what we can (sold area; allotted/remaining are unknown here).
        $registries = $this->ownScope(Registry::where('deed_no', $deedNo))->with('plot')->get();
        if ($registries->isNotEmpty()) {
            $sold = (float) $registries->sum(fn ($r) => $this->registrySoldArea($r));

            return [
                'type'           => 'fallback',
                'deed_no'        => $deedNo,
                'merged_deed_no' => '-',
                'partner'        => '-',
                'arazi_code'     => $registries->first()->arazi_code ?? '-',
                'kisan'          => '-',
                'allotted'       => null,
                'sold'           => round($sold, 2),
                'remaining'      => null,
                'merged_sold'    => null,
                'members'        => [],
            ];
        }

        return null;
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

        $registries = $this->ownScope(Registry::with('plot:id,area'))
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
        $regAgg = $this->ownScope(Registry::query())
            ->selectRaw("arazi_code, COUNT(*) as cnt, SUM(CASE WHEN LOWER(status)='completed' THEN 1 ELSE 0 END) as done, COALESCE(SUM(COALESCE(land_size,0)),0) as land")
            ->when($dateFrom, fn ($q) => $q->whereDate('registry_date', '>=', $dateFrom))
            ->when($dateTo,   fn ($q) => $q->whereDate('registry_date', '<=', $dateTo))
            ->groupBy('arazi_code')->get()->keyBy('arazi_code');
        $bondAgg = $this->ownScope(CustomerBond::query())
            ->selectRaw('arazi_code, COUNT(*) as cnt')
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

        $bondAgg = $this->ownScope(CustomerBond::query())
            ->selectRaw('broker_id, COUNT(*) as cnt, COALESCE(SUM(total_amount),0) as total, COALESCE(SUM(broker_payment),0) as commission, COALESCE(SUM(broker_paid),0) as paid, COALESCE(SUM(broker_balance),0) as balance')
            ->whereNotNull('broker_id')
            ->when($dateFrom, fn ($q) => $q->whereDate('bond_date', '>=', $dateFrom))
            ->when($dateTo,   fn ($q) => $q->whereDate('bond_date', '<=', $dateTo))
            ->groupBy('broker_id')->get()->keyBy('broker_id');

        $regAgg = $this->ownScope(Registry::query())
            ->selectRaw("agent_id, COUNT(*) as cnt, SUM(CASE WHEN LOWER(status)='completed' THEN 1 ELSE 0 END) as done")
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

        $agg = $this->ownScope(Registry::query())
            ->selectRaw("COALESCE(NULLIF(status,''),'unknown') as status, COUNT(*) as cnt, COALESCE(SUM(registry_amount),0) as amount")
            ->groupBy('status')->get();

        $statusRows = $agg->map(fn ($r) => [
            'status' => ucfirst((string) $r->status),
            'count'  => (int) $r->cnt,
            'amount' => round((float) $r->amount, 2),
        ])->all();

        $recent = $this->ownScope(Registry::with(['customer:id,name', 'agent:id,name']))
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

        $base = $this->ownScope(CustomerBondPayment::query());
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

        $regLand = $this->ownScope(Registry::query())
            ->selectRaw('arazi_code, COALESCE(SUM(COALESCE(land_size,0)),0) as land')
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
