<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ExportsCsv;
use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Arazi;
use App\Models\Kisan;
use App\Models\KisanBond;
use App\Models\Payment;
use App\Services\RegistryLifecycleService;
use App\Support\PaymentReceiptPresenter;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;

class PaymentController extends Controller
{
    use ExportsCsv;
    use ManagesCrud;

    public function __construct(private readonly RegistryLifecycleService $registryLifecycleService)
    {
    }

    public function printReceipt(Request $request)
    {
        $receiptNo = trim((string) $request->query('receipt_no', ''));
        $payment = $this->findKisanPaymentByReceiptKey($receiptNo);

        // Render themed receipt view which expects a $payment variable
        return view('payments.print', [
            'payment' => $payment,
            'receiptNo' => $receiptNo,
            'lookupAction' => route('kisan-payment.print'),
            'pdfUrl' => $receiptNo !== '' && $payment
                ? route('kisan-payment.receipt-pdf', ['receipt_no' => $receiptNo])
                : null,
            'autoPrint' => $request->boolean('print') && $payment,
            'toolbar' => true,
        ]);
    }

    public function receiptPdf(Request $request)
    {
        $receiptNo = trim((string) $request->query('receipt_no', ''));
        $payment = $this->findKisanPaymentByReceiptKey($receiptNo);
        abort_unless($payment, 404);

        $html = view('payments.print', [
            'payment' => $payment,
            'receiptNo' => $receiptNo,
            'pdfUrl' => null,
            'autoPrint' => false,
            'toolbar' => false,
        ])->render();

        if (class_exists(\Barryvdh\DomPDF\Facade\Pdf::class)) {
            return \Barryvdh\DomPDF\Facade\Pdf::loadHTML($html)
                ->setPaper('a4', 'portrait')
                ->stream('kisan-receipt-'.$receiptNo.'.pdf');
        }

        return response($html, 200)->header('Content-Type', 'text/html; charset=UTF-8');
    }

    private function findKisanPaymentByReceiptKey(string $receiptNo): ?Payment
    {
        if ($receiptNo === '') {
            return null;
        }

        return Payment::with([
            'kisanBond.kisan',
            'kisanBond.arazi',
            'registry.arazi.kisan',
            'registry.customer',
            'registry.agent',
            'customer',
            'kisan',
        ])
            ->where(function ($q) use ($receiptNo) {
                $q->where('receipt_no', $receiptNo)
                    ->orWhere('reference_no', $receiptNo);
            })
            ->latest('payment_date')
            ->latest('id')
            ->first();
    }

    public function ledger(Request $request)
    {
        $selectedBondId  = $request->query('bond_id');
        $selectedKisanId = $request->query('kisan_id');
        $araziCode       = trim((string) $request->query('arazi_code', ''));

        // Resolve arazi IDs from code
        $araziIds = $araziCode !== '' ? Arazi::idsForCode($araziCode) : [];

        // All kisans for the kisan filter dropdown
        $allKisans = Kisan::orderBy('name')->get(['id', 'name', 'mobile']);

        // Bonds filtered by kisan and/or arazi
        $bonds = KisanBond::with(['kisan', 'arazis'])
            ->withSum('payments as paid_amount', 'amount')
            ->when($selectedKisanId, fn ($q) => $q->where('kisan_id', $selectedKisanId))
            ->when($araziIds, fn ($q) => $q->where(fn ($q2) =>
                $q2->whereIn('arazi_id', $araziIds)
                   ->orWhereHas('arazis', fn ($a) => $a->whereIn('arazis.id', $araziIds))
            ))
            ->latest()
            ->get();

        $entries = Payment::with(['kisanBond.kisan'])
            ->whereNotNull('kisan_bond_id')
            ->when($selectedKisanId, fn ($q) => $q->whereHas('kisanBond', fn ($b) => $b->where('kisan_id', $selectedKisanId)))
            ->when($araziIds, fn ($q) => $q->whereHas('kisanBond', fn ($b) =>
                $b->whereIn('arazi_id', $araziIds)
                  ->orWhereHas('arazis', fn ($a) => $a->whereIn('arazis.id', $araziIds))
            ))
            ->when($selectedBondId, fn ($q) => $q->where('kisan_bond_id', $selectedBondId))
            ->latest('payment_date')
            ->latest('id')
            ->get();

        return view('ledgers.bond_payments', [
            'title'            => 'Kisan Payment Ledger',
            'bondLabel'        => 'Kisan Bond',
            'partyLabel'       => 'Kisan',
            'filterName'       => 'bond_id',
            'selectedBondId'   => $selectedBondId,
            'partyFilterName'  => 'kisan_id',
            'selectedPartyId'  => $selectedKisanId,
            'selectedAraziCode'=> $araziCode,
            'allKisans'        => $allKisans,
            'bonds'            => $bonds->map(function (KisanBond $bond) {
                $total = (float) ($bond->total_amount ?? $bond->bond_amount ?? 0);
                $paid  = (float) ($bond->paid_amount ?? 0);

                // Collect arazi codes
                $arazis = $bond->arazis->isNotEmpty()
                    ? $bond->arazis->map(fn($a) => $a->legacy_arazi_code ?: ($a->plot_number ?? ('Arazi-'.$a->id)))->unique()->implode(', ')
                    : ($bond->arazi ? ($bond->arazi->legacy_arazi_code ?: ($bond->arazi->plot_number ?? '-')) : '-');

                return [
                    'id'        => $bond->id,
                    'bond_no'   => $bond->bond_no,
                    'party'     => $bond->kisan?->name ?? '-',
                    'arazi'     => $arazis,
                    'total'     => $total,
                    'paid'      => $paid,
                    'balance'   => max($total - $paid, 0),
                ];
            }),
            'entries'          => $entries->map(function (Payment $payment) {
                return [
                    'entry_no' => $payment->receipt_no ?? $payment->reference_no ?? '-',
                    'bond_no'  => $payment->kisanBond?->bond_no ?? '-',
                    'party'    => $payment->kisanBond?->kisan?->name ?? $payment->kisan?->name ?? '-',
                    'date'     => optional($payment->payment_date)->format('d-m-Y') ?? '-',
                    'type'     => ucfirst($payment->payment_type),
                    'amount'   => (float) $payment->amount,
                    'method'   => $payment->payment_method ?? '-',
                    'remarks'  => $payment->notes ?? '-',
                ];
            }),
            'exportLedgerCsvUrl' => route('kisan-payment.ledger.export.csv', array_filter([
                'bond_id'    => $selectedBondId,
                'kisan_id'   => $selectedKisanId,
                'arazi_code' => $araziCode ?: null,
            ], fn ($v) => $v !== null && $v !== '')),
        ]);
    }

    public function ledgerExportCsv(Request $request)
    {
        $selectedBondId = $request->query('bond_id');
        $selectedKisanId = $request->query('kisan_id');

        $entries = Payment::with(['kisanBond.kisan'])
            ->whereNotNull('kisan_bond_id')
            ->when($selectedKisanId, fn ($query) => $query->whereHas('kisanBond', fn ($bondQuery) => $bondQuery->where('kisan_id', $selectedKisanId)))
            ->when($selectedBondId, fn ($query) => $query->where('kisan_bond_id', $selectedBondId))
            ->latest('payment_date')
            ->latest('id')
            ->get();

        $columns = ['Entry No', 'Kisan Bond', 'Kisan', 'Date', 'Type', 'Amount', 'Method', 'Remarks'];

        $rows = $entries->map(function (Payment $payment) {
            return [
                $payment->receipt_no ?? $payment->reference_no ?? '-',
                $payment->kisanBond?->bond_no ?? '-',
                $payment->kisanBond?->kisan?->name ?? $payment->kisan?->name ?? '-',
                optional($payment->payment_date)->format('d-m-Y') ?? '-',
                ucfirst($payment->payment_type),
                number_format((float) $payment->amount, 2, '.', ''),
                $payment->payment_method ?? '-',
                $payment->notes ?? '-',
            ];
        })->all();

        return $this->csvDownload('kisan-payment-ledger', $columns, $rows);
    }

    protected function resourceTitle(): string
    {
        return 'Kisan Payment';
    }

    protected function allowsCsvExport(): bool
    {
        return true;
    }

    protected function resourceModel(): string
    {
        return Payment::class;
    }

    protected function resourceRouteName(): string
    {
        return 'kisan-payment';
    }

    protected function resourceColumns(): array
    {
        return ['Entry No', 'Bond', 'Kisan', 'Type', 'Amount', 'Date', 'Method'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        $kisanId = $item?->kisan_id ?? request('kisan_id') ?? request()->route('kisan')?->id;

        return [
            ['name' => 'receipt_no', 'label' => 'Entry Number', 'type' => 'text', 'value' => $item?->receipt_no ?? $this->nextEntryNumber(), 'required' => true, 'readonly' => true],
            [
                'name' => 'kisan_id',
                'label' => 'Kisan',
                'type' => 'select',
                'options' => Kisan::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $kisanId,
                'required' => true,
            ],
            [
                'name' => 'kisan_bond_id',
                'label' => 'Kisan Bond',
                'type' => 'select',
                'options' => KisanBond::query()
                    ->when($kisanId, fn ($query) => $query->where('kisan_id', $kisanId))
                    ->latest()
                    ->get()
                    ->mapWithKeys(function (KisanBond $bond) {
                        return [$bond->id => $bond->bond_no . ' - ' . number_format((float) ($bond->total_amount ?? $bond->bond_amount ?? 0), 2)];
                    })
                    ->all(),
                'value' => $item?->kisan_bond_id,
                'required' => true,
            ],
            ['name' => 'payment_type', 'label' => 'Payment Type', 'type' => 'select', 'options' => ['advance' => 'Advance', 'installment' => 'Installment', 'final' => 'Final', 'other' => 'Other'], 'value' => $item?->payment_type ?? 'advance', 'required' => true],
            ['name' => 'amount', 'label' => 'Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->amount, 'required' => true],
            ['name' => 'payment_date', 'label' => 'Payment Date', 'type' => 'date', 'value' => optional($item?->payment_date)->format('Y-m-d'), 'required' => true],
            ['name' => 'payment_method', 'label' => 'Payment Method', 'type' => 'text', 'value' => $item?->payment_method],
            ['name' => 'notes', 'label' => 'Notes', 'type' => 'textarea', 'value' => $item?->notes],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'receipt_no' => ['nullable', 'string', 'max:40', \Illuminate\Validation\Rule::unique('payments', 'receipt_no')->ignore($item?->id)],
            'kisan_bond_id' => ['required', 'exists:kisan_bonds,id', function ($attribute, $value, $fail) {
                $kisanId = request()->input('kisan_id');

                if ($kisanId && ! KisanBond::where('id', $value)->where('kisan_id', $kisanId)->exists()) {
                    $fail('Selected Kisan Bond does not belong to selected Kisan.');
                }
            }],
            'kisan_id' => ['nullable', 'exists:kisans,id'],
            'payment_type' => ['required', 'in:advance,installment,final,other'],
            'amount' => ['required', 'numeric', 'min:0'],
            'payment_date' => ['required', 'date'],
            'payment_method' => ['nullable', 'string', 'max:50'],
            'notes' => ['nullable', 'string'],
        ];
    }

    protected function resourceQuery()
    {
        return Payment::with(['kisanBond.kisan', 'registry.arazi', 'kisan'])
            ->whereNotNull('kisan_bond_id')
            ->latest();
    }

    protected function resourceRow(Model $item): array
    {
        /** @var Payment $item */
        return [
            'cells' => [
                $item->receipt_no ?? '-',
                $item->kisanBond?->bond_no ?? '-',
                $item->kisan?->name ?? $item->kisanBond?->kisan?->name ?? '-',
                ucfirst($item->payment_type),
                (string) $item->amount,
                optional($item->payment_date)->format('d-m-Y') ?? '-',
                $item->payment_method ?? '-',
            ],
        ];
    }

    protected function resourceAfterSave(Model $item, Request $request, array $validated, ?Model $original = null): void
    {
        /** @var Payment $item */
        if (! $item->registry) {
            return;
        }

        if ($item->payment_type === 'final') {
            $this->registryLifecycleService->markRegistryPaid($item->registry);

            return;
        }

        if ($item->payment_type === 'advance') {
            $this->registryLifecycleService->markRegistryPending($item->registry);
        }
    }

    protected function resourcePrepareData(array $validated, Request $request, ?Model $item = null): array
    {
        $bond = KisanBond::find($validated['kisan_bond_id']);
        $validated['receipt_no'] = ($validated['receipt_no'] ?? null) ?: $this->nextEntryNumber();
        $validated['reference_no'] = $validated['reference_no'] ?? $validated['receipt_no'];

        if ($bond) {
            $validated['kisan_id'] = $bond->kisan_id;
        }

        return $validated;
    }

    private function nextEntryNumber(): string
    {
        $prefix = 'KP';
        $next = Payment::where('receipt_no', 'like', $prefix . '%')
            ->pluck('receipt_no')
            ->map(function ($entryNo) use ($prefix) {
                return preg_match('/^' . preg_quote($prefix, '/') . '(\d+)$/', (string) $entryNo, $matches)
                    ? (int) $matches[1]
                    : 0;
            })
            ->max() + 1;

        do {
            $entryNo = $prefix . str_pad((string) $next, 5, '0', STR_PAD_LEFT);
            $next++;
        } while (Payment::where('receipt_no', $entryNo)->orWhere('reference_no', $entryNo)->exists());

        return $entryNo;
    }

    // Kisan-scoped index
    public function index(Request $request, ?Kisan $kisan = null)
    {
        $q         = trim((string) $request->input('q', ''));
        $araziCode = trim((string) $request->input('arazi_code', ''));

        $query = $this->resourceQuery()
            ->when($kisan, fn($qb) => $qb->where('kisan_id', $kisan->id));

        // Search by kisan name or mobile
        if ($q !== '') {
            $query->where(function ($qb) use ($q) {
                $qb->whereHas('kisan', fn($k) =>
                    $k->where('name', 'like', '%'.$q.'%')
                      ->orWhere('mobile', 'like', '%'.$q.'%')
                )->orWhereHas('kisanBond.kisan', fn($k) =>
                    $k->where('name', 'like', '%'.$q.'%')
                      ->orWhere('mobile', 'like', '%'.$q.'%')
                );
            });
        }

        // Search by arazi legacy code
        if ($araziCode !== '') {
            $araziIds = Arazi::idsForCode($araziCode);
            $query->where(function ($qb) use ($araziIds) {
                $qb->whereHas('kisanBond', fn($b) =>
                    $b->whereIn('arazi_id', $araziIds)
                      ->orWhereHas('arazis', fn($a) => $a->whereIn('arazis.id', $araziIds))
                )->orWhereHas('registry.arazi', fn($a) => $a->whereIn('arazis.id', $araziIds));
            });
        }

        $records   = $query->get();
        $routeName = $this->resourceRouteName();

        $rows = $records->map(function (Model $record) use ($routeName) {
            $ref = $record->receipt_no ?: $record->reference_no;

            return array_merge($this->resourceRow($record), [
                'edit_url'   => route($routeName . '.edit', $record),
                'delete_url' => route($routeName . '.destroy', $record),
                'print_url'  => $ref ? route('kisan-payment.print', ['receipt_no' => $ref, 'print' => 1]) : null,
                'pdf_url'    => $ref ? route('kisan-payment.receipt-pdf', ['receipt_no' => $ref]) : null,
            ]);
        })->all();

        return view('crud.index', [
            'title'               => $this->resourceTitle(),
            'columns'             => $this->resourceColumns(),
            'rows'                => $rows,
            'createUrl'           => $kisan ? route('kisans.kisan-payment.create', $kisan) : route($routeName . '.create'),
            'exportCsvUrl'        => $this->allowsCsvExport()
                ? route($routeName.'.export.csv', array_filter(['kisan_id' => $kisan?->id]))
                : null,
            'isKisanPaymentIndex' => !$kisan,
            'kp_q'                => $q,
            'kp_arazi'            => $araziCode,
        ]);
    }

    protected function recordsForCsvExport(\Illuminate\Http\Request $request): \Illuminate\Database\Eloquent\Builder
    {
        $q = $this->resourceQuery();

        if ($request->filled('kisan_id')) {
            $q->where('kisan_id', (int) $request->input('kisan_id'));
        }

        return $q;
    }

    // Kisan-scoped create
    public function create(Request $request, ?Kisan $kisan = null)
    {
        $modelClass = $this->resourceModel();

        return view('crud.form', [
            'title' => 'Create ' . $this->resourceTitle(),
            'action' => $kisan ? route('kisans.kisan-payment.store', $kisan) : route($this->resourceRouteName() . '.store'),
            'method' => 'POST',
            'fields' => $this->resourceFields(),
            'item' => new $modelClass(),
        ]);
    }

    // Kisan-scoped store
    public function store(Request $request, ?Kisan $kisan = null)
    {
        $validated = $request->validate($this->resourceRules());
        $modelClass = $this->resourceModel();
        $payload = $this->resourcePrepareData($validated, $request);

        if ($kisan) {
            $payload['kisan_id'] = $kisan->id;
        }

        $item = $modelClass::create($payload);
        $this->resourceAfterSave($item, $request, $validated);

        // If requester asked for immediate print/receipt, redirect to themed print page
        if ($request->boolean('print') || $request->boolean('auto_print')) {
            return redirect()->route('kisan-payment.print', ['receipt_no' => $item->receipt_no, 'print' => 1]);
        }

        if ($kisan) {
            return redirect()
                ->route('kisans.kisan-payment.index', $kisan)
                ->with('success', $this->resourceTitle() . ' created successfully.');
        }

        return redirect()
            ->route($this->resourceRouteName() . '.index')
            ->with('success', $this->resourceTitle() . ' created successfully.');
    }
}
