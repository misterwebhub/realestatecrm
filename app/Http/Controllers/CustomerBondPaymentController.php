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
                return [
                    'entry_no' => $payment->entry_no,
                    'bond_no' => $payment->customerBond?->bond_no ?? '-',
                    'party' => $payment->customerBond?->customer?->name ?? $payment->customer?->name ?? '-',
                    'date' => optional($payment->entry_date)->format('d-m-Y') ?? '-',
                    'type' => ucfirst($payment->entry_type),
                    'amount' => (float) $payment->amount,
                    'method' => $payment->payment_method ?? '-',
                    'remarks' => $payment->remarks ?? '-',
                ];
            }),
            'exportLedgerCsvUrl' => route('customer-bond-payments.ledger.export.csv', array_filter([
                'bond_id' => $selectedBondId,
                'customer_id' => $selectedCustomerId,
            ], fn ($v) => $v !== null && $v !== '')),
        ]);
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

        $columns = ['Entry No', 'Customer Bond', 'Customer', 'Date', 'Type', 'Amount', 'Method', 'Remarks'];

        $rows = $entries->map(function (CustomerBondPayment $payment) {
            return [
                $payment->entry_no,
                $payment->customerBond?->bond_no ?? '-',
                $payment->customerBond?->customer?->name ?? $payment->customer?->name ?? '-',
                optional($payment->entry_date)->format('d-m-Y') ?? '-',
                ucfirst($payment->entry_type),
                number_format((float) $payment->amount, 2, '.', ''),
                $payment->payment_method ?? '-',
                $payment->remarks ?? '-',
            ];
        })->all();

        return $this->csvDownload('customer-payment-ledger', $columns, $rows);
    }

    protected function resourceColumns(): array
    {
        return ['Entry No', 'Bond', 'Customer', 'Arazi', 'Plot', 'Land Size', 'Witness', 'Entry Date', 'Type', 'Amount'];
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
            ['name' => 'entry_type', 'label' => 'Entry Type', 'type' => 'select', 'options' => ['advance' => 'Advance', 'installment' => 'Installment', 'final' => 'Final', 'penalty' => 'Penalty', 'other' => 'Other'], 'value' => $item?->entry_type ?? 'installment', 'required' => true],
            ['name' => 'land_size', 'label' => 'Land Size', 'type' => 'number', 'step' => '0.01', 'value' => $item?->land_size],
            ['name' => 'witness_name', 'label' => 'Witness Name', 'type' => 'text', 'value' => $item?->witness_name],
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
            'entry_type' => ['required', 'in:advance,installment,final,penalty,other'],
            'land_size' => ['nullable', 'numeric', 'min:0'],
            'witness_name' => ['nullable', 'string', 'max:150'],
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
                $item->witness_name ?? '-',
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
}
