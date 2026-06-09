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

    public function index()
    {
        $records = $this->resourceQuery()->get();
        $routeName = $this->resourceRouteName();

        $rows = $records->map(function (Model $record) use ($routeName) {
            $entry = $record->entry_no;

            return array_merge($this->resourceRow($record), [
                'edit_url' => route($routeName . '.edit', $record),
                'delete_url' => route($routeName . '.destroy', $record),
                'print_url' => $entry ? route('customer-bond-payments.receipt', ['entry_no' => $entry, 'print' => 1]) : null,
                'pdf_url' => $entry ? route('customer-bond-payments.receipt-pdf', ['entry_no' => $entry]) : null,
            ]);
        })->all();

        return view('crud.index', [
            'title' => $this->resourceTitle(),
            'columns' => $this->resourceColumns(),
            'rows' => $rows,
            'createUrl' => route($routeName . '.create'),
            'exportCsvUrl' => $this->allowsCsvExport() ? route($routeName.'.export.csv') : null,
        ]);
    }

    public function ledger(\Illuminate\Http\Request $request)
    {
        $selectedBondId = $request->query('bond_id');
        $selectedCustomerId = $request->query('customer_id');
        $bonds = CustomerBond::with('customer')
            ->withSum('payments as paid_amount', 'amount')
            ->when($selectedCustomerId, fn ($query) => $query->where('customer_id', $selectedCustomerId))
            ->latest()
            ->get();

        $entries = CustomerBondPayment::with(['customerBond.customer', 'customer'])
            ->whereNotNull('customer_bond_id')
            ->when($selectedCustomerId, fn ($query) => $query->whereHas('customerBond', fn ($bondQuery) => $bondQuery->where('customer_id', $selectedCustomerId)))
            ->when($selectedBondId, fn ($query) => $query->where('customer_bond_id', $selectedBondId))
            ->latest('entry_date')
            ->latest('id')
            ->get();

        return view('ledgers.bond_payments', [
            'title' => 'Customer Payment Ledger',
            'bondLabel' => 'Customer Bond',
            'partyLabel' => 'Customer',
            'filterName' => 'bond_id',
            'selectedBondId' => $selectedBondId,
            'partyFilterName' => 'customer_id',
            'selectedPartyId' => $selectedCustomerId,
            'bonds' => $bonds->map(function (CustomerBond $bond) {
                $total = (float) ($bond->total_amount ?? $bond->bond_amount ?? 0);
                $paid = (float) ($bond->paid_amount ?? 0);

                return [
                    'id' => $bond->id,
                    'bond_no' => $bond->bond_no,
                    'party' => $bond->customer?->name ?? '-',
                    'total' => $total,
                    'paid' => $paid,
                    'balance' => max($total - $paid, 0),
                ];
            }),
            'entries' => $entries->map(function (CustomerBondPayment $payment) {
                $chequeNumber = null;
                if (strtolower((string) $payment->payment_method) === 'cheque' && $payment->customer_bond_cheque_id) {
                    $c = \App\Models\CustomerBondCheque::find($payment->customer_bond_cheque_id);
                    $chequeNumber = $c?->cheque_number ?? null;
                }

                $isDebit = in_array($payment->entry_type, ['return', 'discount']);

                return [
                    'entry_no' => $payment->entry_no,
                    'bond_no' => $payment->customerBond?->bond_no ?? '-',
                    'party' => $payment->customerBond?->customer?->name ?? $payment->customer?->name ?? '-',
                    'date' => optional($payment->entry_date)->format('d-m-Y') ?? '-',
                    'type' => ucfirst($payment->entry_type),
                    'amount' => (float) $payment->amount,
                    'is_debit' => $isDebit,
                    'method' => $payment->payment_method ?? '-',
                    'cheque_number' => $chequeNumber,
                    'remarks' => $payment->remarks ?? '-',
                ];
            }),
            'exportLedgerCsvUrl' => route('customer-bond-payments.ledger.export.csv', array_filter([
                'bond_id' => $selectedBondId,
                'customer_id' => $selectedCustomerId,
            ], fn ($v) => $v !== null && $v !== '')),
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
        $selectedBondId = $request->query('bond_id');
        $selectedCustomerId = $request->query('customer_id');

        $entries = CustomerBondPayment::with(['customerBond.customer', 'customer'])
            ->whereNotNull('customer_bond_id')
            ->when($selectedCustomerId, fn ($query) => $query->whereHas('customerBond', fn ($bondQuery) => $bondQuery->where('customer_id', $selectedCustomerId)))
            ->when($selectedBondId, fn ($query) => $query->where('customer_bond_id', $selectedBondId))
            ->latest('entry_date')
            ->latest('id')
            ->get();

        $columns = ['Entry No', 'Customer Bond', 'Customer', 'Date', 'Type', 'Amount', 'Method', 'Cheque No', 'Remarks'];

        $rows = $entries->map(function (CustomerBondPayment $payment) {
            $chequeNumber = null;
            if (strtolower((string) $payment->payment_method) === 'cheque' && $payment->customer_bond_cheque_id) {
                $c = \App\Models\CustomerBondCheque::find($payment->customer_bond_cheque_id);
                $chequeNumber = $c?->cheque_number ?? null;
            }

            return [
                $payment->entry_no,
                $payment->customerBond?->bond_no ?? '-',
                $payment->customerBond?->customer?->name ?? $payment->customer?->name ?? '-',
                optional($payment->entry_date)->format('d-m-Y') ?? '-',
                ucfirst($payment->entry_type),
                number_format((float) $payment->amount, 2, '.', ''),
                $payment->payment_method ?? '-',
                $chequeNumber ?? '-',
                $payment->remarks ?? '-',
            ];
        })->all();

        return $this->csvDownload('customer-payment-ledger', $columns, $rows);
    }

    protected function resourceColumns(): array
    {
        return ['Entry No', 'Bond', 'Customer', 'Arazi', 'Plot', 'Land Size', 'Entry Date', 'Type', 'Amount'];
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
                // only show unpaid/pending cheques for selection
                'options' => ($item && $item->customer_bond_id)
                    ? \App\Models\CustomerBondCheque::where('customer_bond_id', $item->customer_bond_id)->where('status', 'pending')->orderByDesc('id')->get()->mapWithKeys(function ($c) {
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
            ['name' => 'arazi_id', 'type' => 'hidden', 'value' => $item?->arazi_id],
            ['name' => 'plot_id', 'type' => 'hidden', 'value' => $item?->plot_id],
            ['name' => 'entry_date', 'label' => 'Entry Date', 'type' => 'date', 'value' => optional($item?->entry_date)->format('Y-m-d'), 'required' => true],
            ['name' => 'entry_type', 'label' => 'Entry Type', 'type' => 'select', 'options' => ['advance' => 'Advance', 'installment' => 'Installment', 'final' => 'Final', 'penalty' => 'Penalty', 'return' => 'Return', 'discount' => 'Discount', 'other' => 'Other'], 'value' => $item?->entry_type ?? 'installment', 'required' => true],
            ['name' => 'land_size', 'label' => 'Land Size', 'type' => 'number', 'step' => '0.01', 'value' => $item?->land_size],
            // witness_name removed per request
            ['name' => 'amount', 'label' => 'Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->amount, 'required' => true],
            ['name' => 'payment_method', 'label' => 'Payment Method', 'type' => 'text', 'value' => $item?->payment_method],
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
            'arazi_id' => ['nullable', 'exists:arazis,id'],
            'plot_id' => ['nullable', 'exists:plots,id', function($attr, $value, $fail) {
                // if plot provided, ensure it belongs to provided arazi
                $plot = \App\Models\Plot::find($value);
                if($plot && request()->input('arazi_id') && (string)$plot->arazi_id !== (string)request()->input('arazi_id')){
                    $fail('Selected plot does not belong to selected Arazi.');
                }
            }],
            'entry_date' => ['required', 'date'],
            'customer_bond_cheque_id' => ['nullable', 'exists:customer_bond_cheques,id', function ($attr, $value, $fail) {
                $bondId = request()->input('customer_bond_id');
                if ($value && $bondId) {
                    $cheque = \App\Models\CustomerBondCheque::where('id', $value)->where('customer_bond_id', $bondId)->first();
                    if (! $cheque) {
                        $fail('Selected cheque does not belong to selected Customer Bond.');
                        return;
                    }

                    if ($cheque->status !== 'pending') {
                        $fail('Selected cheque is not unpaid (pending).');
                    }
                }
            }],
            'entry_type' => ['required', 'in:advance,installment,final,penalty,return,discount,other'],
            'land_size' => ['nullable', 'numeric', 'min:0'],
            'amount' => ['required', 'numeric', 'min:0'],
            'payment_method' => ['nullable', 'string', 'max:40'],
            'remarks' => ['nullable', 'string'],
        ];
    }

    protected function resourcePrepareData(array $validated, \Illuminate\Http\Request $request, ?Model $item = null): array
    {
        $validated['entry_no'] = ($validated['entry_no'] ?? null) ?: $this->nextEntryNumber();
        $bond = CustomerBond::with('plots')->find($validated['customer_bond_id']);

        if ($bond) {
            $validated['customer_id'] = $bond->customer_id;
            $validated['arazi_id'] = $bond->arazi_id;
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
            $araziLabel = $bond->arazi->legacy_arazi_code ?: ($bond->arazi->plot_number ?? ('Arazi-' . $bond->arazi_id));
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
        return CustomerBondPayment::with(['customerBond.customer', 'customer', 'arazi', 'plot'])
            ->whereNotNull('customer_bond_id')
            ->latest();
    }

    protected function resourceRow(Model $item): array
    {
        /** @var CustomerBondPayment $item */
        return [
            'cells' => [
                $item->entry_no,
                $item->customerBond?->bond_no ?? '-',
                $item->customer?->name ?? $item->customerBond?->customer?->name ?? '-',
                $item->arazi?->legacy_arazi_code ?? ($item->arazi?->plot_number ?? '-'),
                $item->plot?->title ?? ($item->plot?->plot_number ?? '-'),
                (string) ($item->land_size ?? '-'),
                optional($item->entry_date)->format('d-m-Y') ?? '-',
                ucfirst($item->entry_type),
                number_format((float) $item->amount, 2),
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
        $arazis = \App\Models\Arazi::orderBy('id')->get()->mapWithKeys(function ($a) {
            return [$a->id => ($a->legacy_arazi_code ?: ($a->plot_number ?? ('Arazi-' . $a->id)))];
        })->all();

        $paymentMethods = [
            'cheque' => 'Cheque',
            'rtgs' => 'RTGS',
            'imps' => 'IMPS',
            'other' => 'Other',
        ];

        return view('customer_payments.compact', [
            'title' => 'Compact Customer Payment',
            'arazis' => $arazis,
            'paymentMethods' => $paymentMethods,
            'action' => route('customer-bond-payments.store'),
            'method' => 'POST',
        ]);
    }

    /**
     * Override store to ensure atomic save and return JSON for AJAX requests.
     */
    public function store(Request $request)
    {
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

    private function findCustomerPaymentByEntry(string $entryNo): ?CustomerBondPayment
    {
        if ($entryNo === '') {
            return null;
        }

        return CustomerBondPayment::with(['customerBond.customer', 'customer'])
            ->where('entry_no', $entryNo)
            ->latest('entry_date')
            ->latest('id')
            ->first();
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
