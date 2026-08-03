<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ExportsCsv;
use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Customer;
use App\Models\CustomerBond;
use App\Models\CustomerBondPayment;
use App\Support\PaymentReceiptPresenter;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;
use Illuminate\Validation\Rule;
use Illuminate\Support\Facades\DB;

class CustomerBondPaymentController extends Controller
{
    use ExportsCsv;
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Customer Payment';
    }

    protected function allowsCsvExport(): bool
    {
        return true;
    }

    protected function resourceModel(): string
    {
        return CustomerBondPayment::class;
    }

    protected function resourceRouteName(): string
    {
        return 'customer-bond-payments';
    }

    public function index(\Illuminate\Http\Request $request)
    {
        // ── Bond-level inline ledger ──────────────────────────────────────────
        $bondId = $request->query('bond_id');
        if ($bondId) {
            $bond = CustomerBond::with(['customer', 'arazi', 'plots'])
                ->withSum('payments as total_paid', 'amount')
                ->findOrFail($bondId);
            $this->authorizeOwnership($bond);

            $entries = CustomerBondPayment::with('takenByUser')
                ->where('customer_bond_id', $bondId)
                ->orderBy('entry_date')
                ->orderBy('id')
                ->get();

            $totalPaid    = (float) ($bond->total_paid ?? 0);
            $totalAmount  = (float) ($bond->total_amount ?? $bond->bond_amount ?? 0);
            $balance      = max($totalAmount - $totalPaid, 0);
            $routeName    = $this->resourceRouteName();

            return view('customer_payments.bond_ledger', [
                'title'      => 'Payment Ledger — '.$bond->bond_no,
                'bond'       => $bond,
                'entries'    => $entries,
                'totalPaid'  => $totalPaid,
                'totalAmount'=> $totalAmount,
                'balance'    => $balance,
                'routeName'  => $routeName,
            ]);
        }

        // ── Standard payment index ────────────────────────────────────────────
        $q           = trim((string) $request->input('q', ''));
        $bondQ       = trim((string) $request->input('bond', ''));
        $araziCode   = trim((string) $request->input('arazi_code', ''));
        $plotQ       = trim((string) $request->input('plot', ''));
        $brokerQ     = trim((string) $request->input('broker', ''));
        $entryType   = trim((string) $request->input('entry_type', ''));
        $creditDebit = trim((string) $request->input('credit_debit', ''));
        $dateFrom    = trim((string) $request->input('date_from', ''));
        $dateTo      = trim((string) $request->input('date_to', ''));

        $query = $this->resourceQuery();

        // Search by customer name or mobile
        if ($q !== '') {
            $query->where(function ($qb) use ($q) {
                $qb->whereHas('customer', fn($c) =>
                    $c->where('name', 'like', '%'.$q.'%')
                      ->orWhere('mobile', 'like', '%'.$q.'%')
                )->orWhereHas('customerBond.customer', fn($c) =>
                    $c->where('name', 'like', '%'.$q.'%')
                      ->orWhere('mobile', 'like', '%'.$q.'%')
                );
            });
        }

        // Search by bond no
        if ($bondQ !== '') {
            $query->whereHas('customerBond', fn($b) =>
                $b->where('bond_no', 'like', '%'.$bondQ.'%')
            );
        }

        // Search by arazi legacy code
        if ($araziCode !== '') {
            $query->where('arazi_code', $araziCode);
        }

        // Search by plot title
        if ($plotQ !== '') {
            $query->whereHas('plot', fn($p) =>
                $p->where('title', $plotQ) // exact — plot title behaves like a plot number, never LIKE
            );
        }

        // Search by broker name (the bond's assigned broker/agent)
        if ($brokerQ !== '') {
            $query->whereHas('customerBond.broker', fn($b) =>
                $b->where('name', 'like', '%'.$brokerQ.'%')
            );
        }

        // Filter by entry type (advance, installment, final, etc.)
        if ($entryType !== '') {
            $query->where('entry_type', $entryType);
        }

        // Filter by credit / debit
        if ($creditDebit === 'credit') {
            $query->whereNotIn('entry_type', ['return', 'discount']);
        } elseif ($creditDebit === 'debit') {
            $query->whereIn('entry_type', ['return', 'discount']);
        }

        // Filter by payment entry date (never created_at — created_at is
        // when the record was saved, entry_date is the actual payment date).
        if ($dateFrom !== '') {
            $query->whereDate('entry_date', '>=', $dateFrom);
        }
        if ($dateTo !== '') {
            $query->whereDate('entry_date', '<=', $dateTo);
        }

        $records   = $query->get();
        $routeName = $this->resourceRouteName();

        // ── Cumulative summary of the filtered result set ─────────────────────
        $debitTypes  = ['return', 'discount'];
        $sumCredit   = (float) $records->whereNotIn('entry_type', $debitTypes)->sum('amount');
        $sumDebit    = (float) $records->whereIn('entry_type', $debitTypes)->sum('amount');
        $summary = [
            'count'   => $records->count(),
            'credit'  => round($sumCredit, 2),
            'debit'   => round($sumDebit, 2),
            'net'     => round($sumCredit - $sumDebit, 2),
        ];

        $rows = $records->map(function (Model $record) use ($routeName) {
            $entry = $record->entry_no;
            return array_merge($this->resourceRow($record), [
                'edit_url'   => route($routeName . '.edit', $record),
                'delete_url' => route($routeName . '.destroy', $record),
                'print_url'  => $entry ? route('customer-bond-payments.receipt', ['entry_no' => $entry, 'print' => 1]) : null,
                'pdf_url'    => $entry ? route('customer-bond-payments.receipt-pdf', ['entry_no' => $entry]) : null,
            ]);
        })->all();

        return view('crud.index', [
            'title'                  => $this->resourceTitle(),
            'columns'                => $this->resourceColumns(),
            'rows'                   => $rows,
            'createUrl'              => route($routeName . '.create'),
            'exportCsvUrl'           => $this->allowsCsvExport() ? route($routeName.'.export.csv') : null,
            'isCustomerPaymentIndex' => true,
            'cpSummary'              => $summary,
            'cp_q'                   => $q,
            'cp_bond'                => $bondQ,
            'cp_arazi'               => $araziCode,
            'cp_plot'                => $plotQ,
            'cp_broker'              => $brokerQ,
            'cp_entry_type'          => $entryType,
            'cp_credit_debit'        => $creditDebit,
            'cp_date_from'           => $dateFrom,
            'cp_date_to'             => $dateTo,
            'permModule'             => $this->resourcePermModule(),
        ]);
    }

    public function ledger(\Illuminate\Http\Request $request)
    {
        $q               = trim((string) $request->query('q', ''));
        $araziCode       = trim((string) $request->query('arazi_code', ''));
        $plotQ           = trim((string) $request->query('plot', ''));
        $dateFrom        = $request->query('date_from', '');
        $dateTo          = $request->query('date_to', '');
        $lowProgress     = (bool) $request->query('low_progress', false);
        $selectedBondId  = $request->query('bond_id');
        $selectedCustomerId = $request->query('customer_id');

        $bondsQuery = CustomerBond::with(['customer', 'arazi', 'plots'])
            ->withSum(['payments as paid_amount' => function ($query) use ($dateFrom, $dateTo) {
                if ($dateFrom) $query->whereDate('entry_date', '>=', $dateFrom);
                if ($dateTo)   $query->whereDate('entry_date', '<=', $dateTo);
            }], 'amount')
            ->when($selectedBondId, fn ($query) => $query->where('id', $selectedBondId))
            ->when($selectedCustomerId && !$selectedBondId, fn ($query) => $query->where('customer_id', $selectedCustomerId))
            ->when(!$selectedBondId && !$selectedCustomerId && $q, fn ($query) => $query->whereHas('customer', fn ($c) =>
                $c->where('name', 'like', '%'.$q.'%')
                  ->orWhere('mobile', 'like', '%'.$q.'%')
            ))
            ->when(!$selectedBondId && $araziCode !== '', fn ($query) => $query->where('arazi_code', $araziCode))
            ->when(!$selectedBondId && $plotQ, fn ($query) => $query->whereHas('plots', fn ($p) =>
                $p->where('title', $plotQ) // exact — plot title behaves like a plot number, never LIKE
            ))
            ->latest();

        // Non-admins only see the bonds they created; admins see everything.
        $bondsQuery = $this->applyOwnershipScope($bondsQuery);

        $bonds = $bondsQuery->get()->map(function (CustomerBond $bond) {
            $total = (float) ($bond->total_amount ?? $bond->bond_amount ?? 0);
            $paid  = (float) ($bond->paid_amount ?? 0);
            $pct   = $total > 0 ? min(round(($paid / $total) * 100), 100) : 0;

            $araziCode = $bond->arazi
                ? ($bond->arazi->legacy_arazi_code ?: '-')
                : '-';

            $plotTitles = $bond->plots->pluck('title')->filter()->implode(', ') ?: '-';

            return [
                'id'        => $bond->id,
                'bond_no'   => $bond->bond_no,
                'bond_date' => optional($bond->bond_date)->format('d-m-Y') ?? '-',
                'party'     => $bond->customer?->name ?? '-',
                'mobile'  => $bond->customer?->mobile ?? '',
                'arazi'   => $araziCode,
                'plots'   => $plotTitles,
                'total'   => $total,
                'paid'    => $paid,
                'balance' => max($total - $paid, 0),
                'pct'     => $pct,
            ];
        });

        // Apply low-progress filter (< 50%) after mapping (only on full list, not single-bond)
        if ($lowProgress && !$selectedBondId) {
            $bonds = $bonds->filter(fn ($b) => $b['pct'] < 50)->values();
        }

        // Load payment entries + full bond object when a specific bond is requested
        $entries       = collect([]);
        $cheques       = collect([]);
        $chequeSummary = ['count' => 0, 'total' => 0, 'cleared' => 0, 'bounced' => 0, 'pending' => 0, 'cancelled' => 0, 'balance' => 0];
        $selectedBond  = null;
        if ($selectedBondId) {
            $selectedBond = $this->applyOwnershipScope(
                    CustomerBond::with(['customer', 'arazi', 'plots', 'broker', 'witnesses'])
                        ->withSum('payments as total_paid', 'amount')
                )->find($selectedBondId);

            if ($selectedBond) {
                $entries = \App\Models\CustomerBondPayment::with(['customerBond.customer', 'takenByUser', 'cheque.connectedAccount'])
                    ->where('customer_bond_id', $selectedBondId)
                    ->orderBy('entry_date')
                    ->orderBy('id')
                    ->get()
                    ->map(function (\App\Models\CustomerBondPayment $payment) {
                        $isCheque = strtolower((string) $payment->payment_method) === 'cheque';
                        return [
                            'entry_no'  => $payment->entry_no ?? '-',
                            'bond_no'   => $payment->customerBond?->bond_no ?? '-',
                            'bond_date' => optional($payment->customerBond?->bond_date)->format('d-m-Y') ?? '-',
                            'party'     => $payment->customerBond?->customer?->name ?? '-',
                            'date'      => optional($payment->entry_date)->format('d-m-Y') ?? '-',
                            'type'      => ucfirst($payment->entry_type ?? 'payment'),
                            'amount'    => (float) $payment->amount,
                            'method'    => $payment->payment_method ?? '-',
                            'mtr_no'    => $isCheque
                                ? ($payment->cheque?->cheque_number ?: ($payment->mtr_transaction_no ?: '-'))
                                : ($payment->mtr_transaction_no ?? '-'),
                            'payee'     => $isCheque
                                ? ($payment->cheque?->connectedAccount?->name ?: ($payment->account_payee_name ?: '-'))
                                : ($payment->account_payee_name ?? '-'),
                            'taken_by'  => $payment->takenByUser->name ?? '-',
                            'remarks'   => $payment->remarks ?? '-',
                            'is_debit'  => in_array($payment->entry_type, ['return', 'discount']),
                        ];
                    });

                // Cheque entries attached to this bond
                $cheques = \App\Models\CustomerBondCheque::with('connectedAccount')
                    ->where('customer_bond_id', $selectedBondId)
                    ->orderBy('cheque_date')
                    ->orderBy('id')
                    ->get()
                    ->map(function (\App\Models\CustomerBondCheque $c) {
                        return [
                            'cheque_number' => $c->cheque_number ?: '-',
                            'bank_name'     => $c->bank_name ?: '-',
                            'branch_name'   => $c->branch_name ?: '-',
                            'account'       => $c->connectedAccount?->name ?? '-',
                            'cheque_date'   => optional($c->cheque_date)->format('d-m-Y') ?? '-',
                            'due_date'      => optional($c->action_due_date)->format('d-m-Y') ?? '-',
                            'amount'        => (float) $c->amount,
                            'status'        => $c->status ?: 'pending',
                            'type'          => $c->type ?: '-',
                            'notes'         => $c->notes ?: '',
                        ];
                    });

                $chequeSummary['count']   = $cheques->count();
                $chequeSummary['total']   = (float) $cheques->sum('amount');
                $chequeSummary['cleared'] = (float) $cheques->where('status', 'cleared')->sum('amount');
                $chequeSummary['bounced'] = (float) $cheques->where('status', 'bounced')->sum('amount');
                $chequeSummary['pending'] = (float) $cheques->where('status', 'pending')->sum('amount');
                $chequeSummary['cancelled'] = (float) $cheques->where('status', 'cancelled')->sum('amount');
                // Balance = amounts not yet cleared/cancelled (pending + bounced awaiting re-collection)
                $chequeSummary['balance'] = $chequeSummary['pending'] + $chequeSummary['bounced'];
            }
        }

        return view('ledgers.bond_payments', [
            'title'            => 'Customer Payment Ledger',
            'bondLabel'        => 'Customer Bond',
            'partyLabel'       => 'Customer',
            'filterName'       => 'bond_id',
            'selectedBondId'   => $selectedBondId,
            'selectedBond'     => $selectedBond,
            'partyFilterName'  => 'customer_id',
            'selectedPartyId'  => $selectedCustomerId,
            'isCustomerLedger' => true,
            'bonds'            => $bonds,
            'entries'          => $entries,
            'cheques'          => $cheques,
            'chequeSummary'    => $chequeSummary,
            // filter state for repopulating form
            'cl_q'             => $q,
            'cl_arazi'         => $araziCode,
            'cl_plot'          => $plotQ,
            'cl_date_from'     => $dateFrom,
            'cl_date_to'       => $dateTo,
            'cl_low_progress'  => $lowProgress,
            'exportLedgerCsvUrl' => route('customer-bond-payments.ledger.export.csv', array_filter([
                'bond_id'      => $selectedBondId ?: null,
                'q'            => $selectedBondId ? null : $q,
                'arazi_code'   => $selectedBondId ? null : $araziCode,
                'plot'         => $selectedBondId ? null : $plotQ,
                'date_from'    => $selectedBondId ? null : $dateFrom,
                'date_to'      => $selectedBondId ? null : $dateTo,
                'low_progress' => (!$selectedBondId && $lowProgress) ? 1 : null,
            ], fn ($v) => $v !== null && $v !== '' && $v !== false)),
        ]);
    }

    /**
     * Redirect the standard create route to the compact payment UI.
     */
    public function create()
    {
        return redirect()->route('customer-bond-payments.compact');
    }

    public function ledgerExportCsv(\Illuminate\Http\Request $request)
    {
        $bondId      = $request->query('bond_id');
        $q           = trim((string) $request->query('q', ''));
        $araziCode   = trim((string) $request->query('arazi_code', ''));
        $plotQ       = trim((string) $request->query('plot', ''));
        $dateFrom    = $request->query('date_from', '');
        $dateTo      = $request->query('date_to', '');
        $lowProgress = (bool) $request->query('low_progress', false);

        // ── Bond-level: export payment entries for a specific bond ──
        if ($bondId) {
            $bond = $this->applyOwnershipScope(
                CustomerBond::with(['customer', 'arazi', 'plots'])
            )->find($bondId);

            // Non-admin requesting a bond they don't own → nothing to export.
            if (! $bond) {
                abort(404);
            }

            $entries = \App\Models\CustomerBondPayment::where('customer_bond_id', $bondId)
                ->orderBy('entry_date')
                ->orderBy('id')
                ->get();

            $columns = ['#', 'Entry No', 'Date', 'Type', 'Amount (₹)', 'Method', 'Remarks'];

            $rows = $entries->values()->map(function ($p, $i) {
                return [
                    $i + 1,
                    $p->entry_no ?? '-',
                    optional($p->entry_date)->format('d-m-Y') ?? '-',
                    ucfirst($p->entry_type ?? '-'),
                    number_format((float) $p->amount, 2, '.', ''),
                    $p->payment_method ?? '-',
                    $p->remarks ?? '',
                ];
            })->all();

            $filename = 'payment-entries-' . ($bond?->bond_no ?? $bondId);
            return $this->csvDownload($filename, $columns, $rows);
        }

        // ── Default: export bond-wise summary ──
        $bonds = $this->applyOwnershipScope(
            CustomerBond::with(['customer', 'arazi', 'plots'])
            ->withSum(['payments as paid_amount' => function ($query) use ($dateFrom, $dateTo) {
                if ($dateFrom) $query->whereDate('entry_date', '>=', $dateFrom);
                if ($dateTo)   $query->whereDate('entry_date', '<=', $dateTo);
            }], 'amount'))
            ->when($q, fn ($query) => $query->whereHas('customer', fn ($c) =>
                $c->where('name', 'like', '%'.$q.'%')
                  ->orWhere('mobile', 'like', '%'.$q.'%')
            ))
            ->when($araziCode !== '', fn ($query) => $query->where('arazi_code', $araziCode))
            ->when($plotQ, fn ($query) => $query->whereHas('plots', fn ($p) =>
                $p->where('title', $plotQ) // exact — plot title behaves like a plot number, never LIKE
            ))
            ->latest()
            ->get()
            ->map(function (CustomerBond $bond) {
                $total = (float) ($bond->total_amount ?? $bond->bond_amount ?? 0);
                $paid  = (float) ($bond->paid_amount ?? 0);
                $pct   = $total > 0 ? min(round(($paid / $total) * 100), 100) : 0;
                return [
                    'bond_no' => $bond->bond_no,
                    'party'   => $bond->customer?->name ?? '-',
                    'mobile'  => $bond->customer?->mobile ?? '',
                    'arazi'   => $bond->arazi ? ($bond->arazi->legacy_arazi_code ?: '-') : '-',
                    'plots'   => $bond->plots->pluck('title')->filter()->implode(', ') ?: '-',
                    'total'   => $total,
                    'paid'    => $paid,
                    'balance' => max($total - $paid, 0),
                    'pct'     => $pct,
                ];
            });

        if ($lowProgress) {
            $bonds = $bonds->filter(fn ($b) => $b['pct'] < 50)->values();
        }

        $columns = ['Bond No', 'Customer', 'Mobile', 'Arazi No', 'Plot(s)', 'Total (₹)', 'Paid (₹)', 'Balance (₹)', 'Progress (%)'];

        $rows = $bonds->map(fn ($b) => [
            $b['bond_no'],
            $b['party'],
            $b['mobile'],
            $b['arazi'],
            $b['plots'],
            number_format($b['total'], 2, '.', ''),
            number_format($b['paid'],  2, '.', ''),
            number_format($b['balance'], 2, '.', ''),
            $b['pct'].'%',
        ])->all();

        return $this->csvDownload('customer-payment-ledger', $columns, $rows);
    }

    protected function resourceColumns(): array
    {
        return ['Entry No', 'Bond Date', 'Bond', 'Customer', 'Arazi / Plot / Broker', 'Land Size', 'Entry Date', 'Type', 'Credit', 'Debit', 'Method', 'MTR / Cheque No', 'Payee Name / Account Name', 'Taken By', 'Created'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        $customerId = $item?->customer_id ?? request('customer_id');

        if ($item && $item->exists) {
            $item->loadMissing(['customerBond.arazi', 'customerBond.plots']);
        }

        [$araziDisplay, $plotDisplay] = $this->customerPaymentBondDisplays($item);

        return [
            ['name' => 'entry_no', 'label' => 'Entry Number', 'type' => 'text', 'value' => $item?->entry_no ?? $this->nextEntryNumber(), 'required' => true, 'readonly' => true],
            [
                'name' => 'customer_id',
                'label' => 'Customer',
                'type' => 'select',
                'options' => Customer::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $customerId,
                'required' => true,
            ],
            [
                'name' => 'customer_bond_id',
                'label' => 'Customer Bond',
                'type' => 'select',
                'options' => CustomerBond::query()
                    ->when($customerId, fn ($query) => $query->where('customer_id', $customerId))
                    ->latest()
                    ->get()
                    ->mapWithKeys(function (CustomerBond $bond) {
                        return [$bond->id => $bond->bond_no . ' - ' . number_format((float) ($bond->total_amount ?? $bond->bond_amount ?? 0), 2)];
                    })
                    ->all(),
                'value' => $item?->customer_bond_id,
                'required' => true,
            ],
            [
                'name' => 'customer_bond_cheque_id',
                'label' => 'Cheque (optional)',
                'type' => 'select',
                // only show unpaid/pending cheques for selection, plus this payment's own
                // cheque (which was marked "cleared" when the payment was saved) so editing
                // doesn't drop it from the dropdown and unassign it on save.
                'options' => ($item && $item->customer_bond_id)
                    ? \App\Models\CustomerBondCheque::where('customer_bond_id', $item->customer_bond_id)
                        ->where(function ($q) use ($item) {
                            $q->where('status', 'pending');
                            if ($item->customer_bond_cheque_id) {
                                $q->orWhere('id', $item->customer_bond_cheque_id);
                            }
                        })
                        ->orderByDesc('id')->get()->mapWithKeys(function ($c) {
                            return [$c->id => ($c->cheque_number ? $c->cheque_number . ' — ' : '') . '₹' . number_format((float)$c->amount, 2) . ' — ' . ucfirst($c->status)];
                        })->all()
                    : [],
                'value' => $item?->customer_bond_cheque_id,
            ],
            [
                'name' => 'arazi_display',
                'label' => 'Arazi',
                'type' => 'readonly_text',
                'value' => $araziDisplay,
                'help' => 'Taken from the selected bond.',
            ],
            [
                'name' => 'plot_display',
                'label' => 'Plot(s)',
                'type' => 'readonly_text',
                'value' => $plotDisplay,
                'help' => 'Taken from the selected bond.',
            ],
            ['name' => 'arazi_code', 'type' => 'hidden', 'value' => $item?->arazi_code],
            ['name' => 'plot_id', 'type' => 'hidden', 'value' => $item?->plot_id],
            [
                'name' => 'entry_date',
                'label' => 'Entry Date',
                'type' => 'date',
                'value' => optional($item?->entry_date)->format('Y-m-d'),
                'required' => true,
                // Non-privileged users can't pick a date before today (no back entry).
                // Super Admin and users with "Allow Back-Dated Payment Entries" enabled
                // on their profile (User Master) have no lower bound.
                'min' => auth()->user()?->canBackdatePayments() ? null : now()->format('Y-m-d'),
                'help' => auth()->user()?->canBackdatePayments()
                    ? null
                    : 'You are not allowed to enter a back-dated (past) Entry Date.',
            ],
            ['name' => 'entry_type', 'label' => 'Entry Type', 'type' => 'select', 'options' => ['advance' => 'Advance', 'installment' => 'Installment', 'final' => 'Final', 'penalty' => 'Penalty', 'return' => 'Return', 'discount' => 'Discount', 'other' => 'Other'], 'value' => $item?->entry_type ?? 'installment', 'required' => true],
            ['name' => 'land_size', 'label' => 'Land Size', 'type' => 'number', 'step' => '0.01', 'value' => $item?->land_size],
            // witness_name removed per request
            ['name' => 'amount', 'label' => 'Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->amount, 'required' => true],
            ['name' => 'payment_method', 'label' => 'Payment Method', 'type' => 'select', 'options' => [
                'cash' => 'Cash',
                'cheque' => 'Cheque',
                'rtgs' => 'RTGS',
                'imps' => 'IMPS',
                'upi' => 'UPI',
                'other' => 'Other',
            ], 'value' => $item?->payment_method ?? 'cash'],
            ['name' => 'mtr_transaction_no', 'label' => 'MTR Transaction No.', 'type' => 'text', 'value' => $item?->mtr_transaction_no, 'help' => 'Required for IMPS, RTGS and UPI.'],
            ['name' => 'account_payee_name', 'label' => 'Account / Payee Name', 'type' => 'text', 'value' => $item?->account_payee_name],
            [
                'name'    => 'taken_by_user_id',
                'label'   => 'Taken By',
                'type'    => 'select',
                'options' => \App\Models\User::orderBy('name')->pluck('name', 'id')->all(),
                'value'   => $item?->taken_by_user_id ?? auth()->id(),
            ],
            ['name' => 'remarks', 'label' => 'Remarks', 'type' => 'textarea', 'value' => $item?->remarks],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'entry_no' => ['nullable', 'string', 'max:50', Rule::unique('customer_bond_payments', 'entry_no')->ignore($item?->id)],
            'customer_id' => ['required', 'exists:customers,id'],
            'customer_bond_id' => ['required', 'exists:customer_bonds,id', function ($attribute, $value, $fail) {
                $customerId = request()->input('customer_id');

                if ($customerId && ! CustomerBond::where('id', $value)->where('customer_id', $customerId)->exists()) {
                    $fail('Selected Customer Bond does not belong to selected Customer.');
                }
            }],
            // registry removed; payments are now against arazi/plot
            'arazi_code' => ['nullable', 'string', 'exists:arazis,legacy_arazi_code'],
            'plot_id' => ['nullable', 'exists:plots,id', function($attr, $value, $fail) {
                // if plot provided, ensure it belongs to provided arazi code
                $plot = \App\Models\Plot::find($value);
                if($plot && request()->input('arazi_code') && (string)$plot->arazi_code !== (string)request()->input('arazi_code')){
                    $fail('Selected plot does not belong to selected Arazi.');
                }
            }],
            'entry_date' => ['required', 'date', function ($attribute, $value, $fail) use ($item) {
                $user = auth()->user();
                if ($user && $user->canBackdatePayments()) {
                    return;
                }

                $newDate = \Carbon\Carbon::parse($value)->startOfDay();
                if ($newDate->greaterThanOrEqualTo(today())) {
                    return;
                }

                // Editing a record without changing its already-past entry date
                // isn't a new "back entry" — don't block unrelated edits.
                if ($item && $item->entry_date && $item->entry_date->isSameDay($newDate)) {
                    return;
                }

                $fail('You are not allowed to enter a back-dated Entry Date. Ask an administrator to enable this for your account.');
            }],
            'customer_bond_cheque_id' => ['nullable', 'exists:customer_bond_cheques,id', function ($attr, $value, $fail) use ($item) {
                $bondId = request()->input('customer_bond_id');
                if ($value && $bondId) {
                    $cheque = \App\Models\CustomerBondCheque::where('id', $value)->where('customer_bond_id', $bondId)->first();
                    if (! $cheque) {
                        $fail('Selected cheque does not belong to selected Customer Bond.');
                        return;
                    }

                    // A cheque already tied to this payment was marked "cleared" when the
                    // payment was first saved. Re-submitting the same cheque while editing
                    // other fields (e.g. entry date) must not be rejected as "not pending".
                    $isSameChequeAsBefore = $item && (int) $item->customer_bond_cheque_id === (int) $value;

                    if ($cheque->status !== 'pending' && ! $isSameChequeAsBefore) {
                        $fail('Selected cheque is not unpaid (pending).');
                    }
                }
            }],
            'entry_type' => ['required', 'in:advance,installment,final,penalty,return,discount,other'],
            'land_size' => ['nullable', 'numeric', 'min:0'],
            'amount' => ['required', 'numeric', 'min:0'],
            'payment_method' => ['nullable', 'string', 'max:40'],
            'mtr_transaction_no' => [
                'nullable', 'string', 'max:100',
                function ($attribute, $value, $fail) {
                    $method = strtolower(trim((string) request()->input('payment_method', '')));
                    if (in_array($method, ['imps', 'rtgs', 'upi'], true) && trim((string) $value) === '') {
                        $fail('MTR Transaction No. is required for IMPS, RTGS and UPI payments.');
                    }
                },
            ],
            'account_payee_name' => ['nullable', 'string', 'max:150'],
            'taken_by_user_id' => ['nullable', 'exists:users,id'],
            'remarks' => ['nullable', 'string'],
        ];
    }

    protected function resourcePrepareData(array $validated, \Illuminate\Http\Request $request, ?Model $item = null): array
    {
        $validated['entry_no'] = ($validated['entry_no'] ?? null) ?: $this->nextEntryNumber();

        // Non-admins may only record payments under their own name — force it
        // server-side so a spoofed/disabled field can't reassign the payment.
        $currentUser = auth()->user();
        if ($currentUser && ! $currentUser->isSuperAdmin()) {
            $validated['taken_by_user_id'] = $currentUser->getKey();
        }

        $bond = CustomerBond::with('plots')->find($validated['customer_bond_id']);

        if ($bond) {
            $validated['customer_id'] = $bond->customer_id;
            $validated['arazi_code'] = $bond->arazi_code;
            $validated['plot_id'] = $bond->plots->first()?->id;

            if (empty($validated['land_size']) && ($bond->land_size ?? $bond->sale_land)) {
                $validated['land_size'] = $bond->land_size ?? $bond->sale_land;
            }
        }

        // If a cheque is selected, ensure its customer matches and keep reference
        if (! empty($validated['customer_bond_cheque_id'])) {
            $cheque = \App\Models\CustomerBondCheque::find($validated['customer_bond_cheque_id']);
            if ($cheque) {
                $validated['customer_id'] = $validated['customer_id'] ?? $cheque->customer_id;
            }
        }

        return $validated;
    }

    /**
     * @param  CustomerBondPayment|null  $item
     */
    private function customerPaymentBondDisplays(?Model $item): array
    {
        if (! $item || ! $item->exists) {
            return ['', ''];
        }

        /** @var CustomerBondPayment $item */
        $item->loadMissing(['customerBond.arazi', 'customerBond.plots']);
        $bond = $item->customerBond;

        if (! $bond) {
            return ['-', '-'];
        }

        $bond->loadMissing(['arazi', 'plots']);

        $araziLabel = '-';
        if ($bond->arazi) {
            $araziLabel = $bond->arazi->araziNoCode();
        }

        $plotSummary = '-';
        if ($bond->plots->isNotEmpty()) {
            $plotSummary = $bond->plots->map(function ($p) {
                $lbl = $p->title ?? ('Plot-' . $p->id);

                return $lbl.' / '.($p->area ?? '-').' gaz';
            })->implode('; ');
        }

        return [$araziLabel, $plotSummary];
    }

    private function nextEntryNumber(): string
    {
        $prefix = 'CP';
        $next = CustomerBondPayment::where('entry_no', 'like', $prefix . '%')
            ->pluck('entry_no')
            ->map(function ($entryNo) use ($prefix) {
                return preg_match('/^' . preg_quote($prefix, '/') . '(\d+)$/', (string) $entryNo, $matches)
                    ? (int) $matches[1]
                    : 0;
            })
            ->max() + 1;

        do {
            $entryNo = $prefix . str_pad((string) $next, 5, '0', STR_PAD_LEFT);
            $next++;
        } while (CustomerBondPayment::where('entry_no', $entryNo)->exists());

        return $entryNo;
    }

    protected function resourceQuery()
    {
        return $this->applyOwnershipScope(
            CustomerBondPayment::with(['customerBond.customer', 'customerBond.broker', 'customerBond.plots', 'customer', 'arazi', 'plot', 'takenByUser', 'cheque.connectedAccount'])
                ->whereNotNull('customer_bond_id')
                ->latest()
        );
    }

    protected function resourceRow(Model $item): array
    {
        /** @var CustomerBondPayment $item */
        $bond = $item->customerBond;

        // Prefer every plot on the bond (so the merged column shows the full
        // picture even if this particular payment entry is only tied to one
        // plot_id); fall back to just this payment's own plot.
        $plotSource = $bond && $bond->relationLoaded('plots') && $bond->plots->isNotEmpty()
            ? $bond->plots
            : collect($item->plot ? [$item->plot] : []);

        $plotRows = $plotSource->map(fn($p) => [
            'title' => $p->title ?? ('Plot-'.$p->id),
            'area'  => $p->area ? $p->area.' gaz' : '-',
        ])->all();

        return [
            'cells' => [
                $item->entry_no,
                optional($bond?->bond_date)->format('d-m-Y') ?? '-',
                $bond?->bond_no ?? '-',
                $item->customer?->name ?? $bond?->customer?->name ?? '-',
                [
                    'type'   => 'arazi_plot_broker',
                    'arazi'  => $item->arazi?->legacy_arazi_code ?? '-',
                    'plots'  => $plotRows,
                    'broker' => $bond?->broker?->name ?? '-',
                    // flat text fallback used by CSV export (see ManagesCrud::exportCsv)
                    'csv'    => 'Arazi: ' . ($item->arazi?->legacy_arazi_code ?? '-')
                        . ' | Plot: ' . ($plotRows ? collect($plotRows)->map(fn ($p) => $p['title'] . ' (' . $p['area'] . ')')->implode(', ') : '-')
                        . ' | Broker: ' . ($bond?->broker?->name ?? '-'),
                ],
                (string) ($item->land_size ?? '-'),
                optional($item->entry_date)->format('d-m-Y') ?? '-',
                ucfirst($item->entry_type),
                in_array($item->entry_type, ['return', 'discount']) ? '—' : number_format((float) $item->amount, 2),
                in_array($item->entry_type, ['return', 'discount']) ? number_format((float) $item->amount, 2) : '—',
                $item->payment_method ? strtoupper($item->payment_method) : '—',
                strtolower((string) $item->payment_method) === 'cheque'
                    ? ($item->cheque?->cheque_number ?: ($item->mtr_transaction_no ?: '—'))
                    : ($item->mtr_transaction_no ?: '—'),
                strtolower((string) $item->payment_method) === 'cheque'
                    ? ($item->cheque?->connectedAccount?->name ?: ($item->account_payee_name ?: '—'))
                    : ($item->account_payee_name ?: '—'),
                $item->takenByUser?->name ?? '—',
                optional($item->created_at)->format('d-m-Y H:i') ?? '—',
            ],
            'action_buttons' => [
                [
                    'url' => route('change-log.record', ['type' => 'payment', 'id' => $item->id]),
                    'label' => 'Log',
                    'class' => 'btn-outline-dark',
                    'data_modal' => true,
                    'data_toggle' => 'modal',
                    'data_target' => 'changeLogModal',
                ],
            ],
        ];
    }

    public function printReceipt(Request $request)
    {
        $entryNo = trim((string) $request->query('entry_no', ''));
        $payment = $this->findCustomerPaymentByEntry($entryNo);

        $receipt = $payment ? PaymentReceiptPresenter::fromCustomerPayment($payment) : null;

        return view('payments.payment_receipt', [
            'receipt' => $receipt,
            'lookupKey' => $entryNo,
            'lookupAction' => route('customer-bond-payments.receipt'),
            'lookupParam' => 'entry_no',
            'pdfUrl' => $entryNo !== '' && $payment
                ? route('customer-bond-payments.receipt-pdf', ['entry_no' => $entryNo])
                : null,
            'autoPrint' => $request->boolean('print') && $receipt,
            'toolbar' => true,
        ]);
    }

    /**
     * Compact UI: start with Arazi -> Plot -> autofill customer/land size, compact payment options.
     */
    public function compact()
    {
        $this->authorizeCrud('create');
        $arazis = \App\Models\Arazi::orderBy('id')->get()->mapWithKeys(function ($a) {
            return [$a->id => $a->araziNoCode()];
        })->all();

        $paymentMethods = [
            'cash' => 'Cash',
            'cheque' => 'Cheque',
            'rtgs' => 'RTGS',
            'imps' => 'IMPS',
            'upi' => 'UPI',
            'other' => 'Other',
        ];

        $activeUsers = \App\Models\User::where('is_active', true)->orderBy('name')->get(['id', 'name', 'username']);

        return view('customer_payments.compact', [
            'title'       => 'Compact Customer Payment',
            'arazis'      => $arazis,
            'paymentMethods' => $paymentMethods,
            'activeUsers' => $activeUsers,
            'action'      => route('customer-bond-payments.store'),
            'method'      => 'POST',
        ]);
    }

    /**
     * Override store to ensure atomic save and return JSON for AJAX requests.
     */
    public function store(Request $request)
    {
        $this->authorizeCrud('create');
        $validated = $request->validate($this->resourceRules());
        $modelClass = $this->resourceModel();
        $payload = $this->resourcePrepareData($validated, $request);

        try {
            $payment = DB::transaction(function () use ($modelClass, $payload, $request, $validated) {
                $item = $modelClass::create($payload);

                // If the request explicitly included a cheque id but it wasn't in payload
                // (e.g., disabled fields or other client issues), ensure the payment
                // references it so resourceAfterSave can mark it cleared.
                $reqCheque = $request->input('customer_bond_cheque_id') ?? null;
                if ($reqCheque && empty($item->customer_bond_cheque_id)) {
                    $item->customer_bond_cheque_id = $reqCheque;
                    $item->save();
                }

                // call after save hook to mark cheque cleared etc
                $this->resourceAfterSave($item, $request, $validated, null);
                return $item;
            });
        } catch (\Throwable $e) {
            if ($request->wantsJson() || $request->ajax()) {
                return response()->json(['success' => false, 'error' => $e->getMessage()], 500);
            }
            throw $e;
        }

        if ($request->wantsJson() || $request->ajax()) {
            $cheque = null;
            if ($payment->customer_bond_cheque_id) {
                $c = \App\Models\CustomerBondCheque::find($payment->customer_bond_cheque_id);
                $cheque = $c ? ['id' => $c->id, 'status' => $c->status, 'cheque_date' => $c->cheque_date] : null;
            }

            return response()->json([
                'success' => true,
                'payment' => [
                    'id' => $payment->id,
                    'entry_no' => $payment->entry_no,
                    'amount' => (float) $payment->amount,
                    'entry_date' => optional($payment->entry_date)->format('Y-m-d'),
                    'customer_bond_cheque_id' => $payment->customer_bond_cheque_id,
                ],
                'cheque' => $cheque,
            ], 201);
        }

        return redirect()
            ->route($this->resourceRouteName() . '.index')
            ->with('success', $this->resourceTitle() . ' created successfully.');
    }

    public function receiptPdf(Request $request)
    {
        $entryNo = trim((string) $request->query('entry_no', ''));
        $payment = $this->findCustomerPaymentByEntry($entryNo);
        abort_unless($payment, 404);

        $receipt = PaymentReceiptPresenter::fromCustomerPayment($payment);
        $html = view('payments.payment_receipt', [
            'receipt' => $receipt,
            'lookupKey' => $entryNo,
            'pdfUrl' => null,
            'autoPrint' => false,
            'toolbar' => false,
        ])->render();

        if (class_exists(\Barryvdh\DomPDF\Facade\Pdf::class)) {
            return \Barryvdh\DomPDF\Facade\Pdf::loadHTML($html)
                ->setPaper('a4', 'portrait')
                ->stream('customer-receipt-'.$entryNo.'.pdf');
        }

        return response($html, 200)->header('Content-Type', 'text/html; charset=UTF-8');
    }

    /**
     * Return payment details for a given entry number (for the delete confirmation popup).
     */
    public function lookupEntry(Request $request)
    {
        $entryNo = trim((string) $request->query('entry_no', ''));
        $payment = $this->findCustomerPaymentByEntry($entryNo);

        if (! $payment) {
            return response()->json(['found' => false]);
        }

        $customerName = $payment->customer?->name
            ?? $payment->customerBond?->customer?->name
            ?? '-';

        return response()->json([
            'found'       => true,
            'entry_no'    => $payment->entry_no,
            'bond_no'     => $payment->customerBond?->bond_no ?? '-',
            'customer'    => $customerName,
            'arazi_code'  => $payment->arazi_code ?? '-',
            'entry_type'  => ucfirst((string) $payment->entry_type),
            'amount'      => number_format((float) $payment->amount, 2),
            'entry_date'  => optional($payment->entry_date)->format('d-m-Y') ?? '-',
        ]);
    }

    /**
     * Delete a payment identified by its entry number (from the listing's delete-by-entry box).
     */
    public function deleteByEntry(Request $request)
    {
        $entryNo = trim((string) $request->input('entry_no', ''));
        $payment = $this->findCustomerPaymentByEntry($entryNo);

        if (! $payment) {
            return redirect()
                ->route('customer-bond-payments.index')
                ->with('error', 'No payment found for entry number "' . $entryNo . '".');
        }

        $payment->delete();

        return redirect()
            ->route('customer-bond-payments.index')
            ->with('success', 'Payment entry "' . $entryNo . '" deleted successfully.');
    }

    private function findCustomerPaymentByEntry(string $entryNo): ?CustomerBondPayment
    {
        if ($entryNo === '') {
            return null;
        }

        return $this->applyOwnershipScope(
            CustomerBondPayment::with(['customerBond.customer', 'customer'])
                ->where('entry_no', $entryNo)
                ->latest('entry_date')
                ->latest('id')
        )->first();
    }

    protected function resourceAfterSave(Model $item, \Illuminate\Http\Request $request, array $validated, ?Model $original = null): void
    {
        // If a cheque was used for this payment, mark the cheque as cleared and set its date
        $chequeId = $item->customer_bond_cheque_id ?? null;
        if ($chequeId) {
            try {
                $cheque = \App\Models\CustomerBondCheque::find($chequeId);
                if ($cheque) {
                    $cheque->status = 'cleared';
                    // set cheque_date to payment date if available, otherwise today
                    $cheque->cheque_date = $item->entry_date ? $item->entry_date->format('Y-m-d') : now()->format('Y-m-d');
                    $cheque->save();
                }
            } catch (\Throwable $e) {
                // ignore errors to avoid breaking payment save
            }
        }
    }
}
