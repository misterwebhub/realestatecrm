<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Agent;
use App\Models\Arazi;
use App\Models\Customer;
use App\Models\Registry;
use App\Services\RegistryLifecycleService;
use Carbon\Carbon;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;
use Illuminate\Validation\Rule;
use Illuminate\View\View;

class RegistryController extends Controller
{
    use ManagesCrud;

    public function __construct(private readonly RegistryLifecycleService $registryLifecycleService)
    {
    }

    public function waitingPayments(): View
    {
        $this->registryLifecycleService->expirePendingRegistries();

        $records = Registry::with(['customer', 'arazi', 'agent'])
            ->where('status', 'pending')
            ->whereNotNull('due_date')
            ->orderBy('due_date')
            ->get();

        return view('registries.waiting', [
            'title' => 'Waiting Payments',
            'records' => $records,
        ]);
    }

    protected function resourceTitle(): string
    {
        return 'Registry';
    }

    protected function resourceModel(): string
    {
        return Registry::class;
    }

    protected function resourceRouteName(): string
    {
        return 'registries';
    }

    protected function resourceColumns(): array
    {
        return ['Reg Code', 'Customer', 'Arazi', 'Plot', 'Booking Mode', 'Registry Date', 'Deed No', 'Circle Value', 'Amount', 'Lock', 'Status'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            [
                'name' => 'customer_id',
                'label' => 'Customer',
                'type' => 'select',
                'options' => Customer::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $item?->customer_id,
                'required' => true,
            ],
            [
                'name' => 'arazi_code',
                'label' => 'Arazi',
                'type' => 'select',
                'options' => Arazi::whereNotNull('legacy_arazi_code')->where('legacy_arazi_code', '<>', '')
                    ->orderBy('legacy_arazi_code')->pluck('legacy_arazi_code')->unique()
                    ->mapWithKeys(fn($c) => [$c => $c])->all(),
                'value' => $item?->arazi_code,
                'required' => true,
            ],
            [
                'name' => 'agent_id',
                'label' => 'Broker',
                'type' => 'select',
                'options' => Agent::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $item?->agent_id,
                'required' => true,
            ],
            [
                'name' => 'check_by_agent_id',
                'label' => 'Checked By Broker',
                'type' => 'select',
                'options' => Agent::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $item?->check_by_agent_id,
            ],
            ['name' => 'registry_code', 'label' => 'Registry Code', 'type' => 'text', 'value' => $item?->registry_code],
            ['name' => 'customer_reg_no', 'label' => 'Legacy Customer Reg No', 'type' => 'text', 'value' => $item?->customer_reg_no],
            ['name' => 'registry_date',  'label' => 'Registry Date',  'type' => 'date',   'value' => optional($item?->registry_date)->format('Y-m-d'), 'required' => true],
            ['name' => 'circle_value',   'label' => 'Circle Value',   'type' => 'number', 'step' => '0.01', 'value' => $item?->circle_value, 'placeholder' => 'Enter circle value'],
            ['name' => 'booking_mode', 'label' => 'Booking Mode', 'type' => 'select', 'options' => ['cash' => 'Cash', 'emi' => 'EMI', 'mixed' => 'Mixed', 'other' => 'Other'], 'value' => $item?->booking_mode ?? 'other', 'required' => true],
            ['name' => 'land_size', 'label' => 'Land Size', 'type' => 'number', 'step' => '0.01', 'value' => $item?->land_size, 'required' => true, 'placeholder' => 'Enter land size (required)'],
            ['name' => 'registry_amount', 'label' => 'Registry Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->registry_amount],
            ['name' => 'witness_name', 'label' => 'Witness Name', 'type' => 'text', 'value' => $item?->witness_name, 'required' => true],
            ['name' => 'nominee_name', 'label' => 'Nominee Name', 'type' => 'text', 'value' => $item?->nominee_name],
            ['name' => 'broker_commission', 'label' => 'Broker Commission %', 'type' => 'number', 'step' => '0.01', 'value' => $item?->broker_commission, 'required' => true, 'placeholder' => '0 - 100'],
            ['name' => 'advance_amount', 'label' => 'Advance Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->advance_amount],
            ['name' => 'down_payment', 'label' => 'Down Payment', 'type' => 'number', 'step' => '0.01', 'value' => $item?->down_payment],
            ['name' => 'installment_amount', 'label' => 'Installment Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->installment_amount],
            ['name' => 'due_date', 'label' => 'Due Date', 'type' => 'date', 'value' => optional($item?->due_date)->format('Y-m-d')],
            ['name' => 'expected_registry_date', 'label' => 'Expected Registry Date', 'type' => 'date', 'value' => optional($item?->expected_registry_date)->format('Y-m-d')],
            ['name' => 'payment_words', 'label' => 'Amount In Words', 'type' => 'text', 'value' => $item?->payment_words],
            ['name' => 'id_card_no', 'label' => 'ID Card No', 'type' => 'text', 'value' => $item?->id_card_no],
            ['name' => 'status', 'label' => 'Status', 'type' => 'select', 'options' => ['pending' => 'Pending', 'completed' => 'Completed', 'cancelled' => 'Cancelled'], 'value' => $item?->status ?? 'pending', 'required' => true],
            ['name' => 'payment_status', 'label' => 'Payment Status', 'type' => 'select', 'options' => ['pending' => 'Pending', 'partial' => 'Partial', 'completed' => 'Completed', 'expired' => 'Expired'], 'value' => $item?->payment_status ?? 'pending', 'required' => true],
            ['name' => 'lock_status', 'label' => 'Lock Status', 'type' => 'select', 'options' => ['unlock' => 'Unlock', 'lock' => 'Lock'], 'value' => $item?->lock_status ?? 'unlock', 'required' => true],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'customer_id'      => ['required', 'exists:customers,id'],
            'arazi_code'       => [
                'required', 'string', 'exists:arazis,legacy_arazi_code',
                Rule::unique('registries', 'arazi_code')->ignore($item?->id),
            ],
            'plot_id'          => ['nullable', 'exists:plots,id'],
            'registry_date'    => ['required', 'date'],
            'deed_no'          => ['required', 'string', 'max:100'],
            'circle_value'     => ['nullable', 'numeric', 'min:0'],
            'booking_mode'     => ['nullable', 'in:cash,emi,mixed,other'],
            'land_size'        => ['nullable', 'numeric', 'min:0'],
            'registry_amount'  => ['nullable', 'numeric', 'min:0'],
            'status'           => ['required', 'in:pending,completed,cancelled'],
            'payment_status'   => ['required', 'in:pending,partial,completed,expired'],
            'lock_status'      => ['required', 'in:unlock,lock'],
            // witnesses array → mapped to witness_name in resourcePrepareData
            'witnesses'        => ['nullable', 'array'],
            'witnesses.*.name'   => ['required', 'string', 'max:150'],
            'witnesses.*.mobile' => ['nullable', 'string', 'max:30'],
            // non-fillable / computed extras
            'mobile'           => ['nullable', 'string', 'max:30'],
            'secondary_mobile' => ['nullable', 'string', 'max:30'],
            'pending_amount'   => ['nullable', 'numeric', 'min:0'],
            'customer_bond_id' => ['nullable', 'integer'],
            'receipt_no'       => ['nullable', 'string', 'max:40'],
            'registry_code'    => ['nullable', 'string', 'max:40'],
            'document'         => [$item ? 'nullable' : 'required', 'file', 'mimes:pdf,jpeg,png,jpg', 'max:5120'],
        ];
    }

    protected function resourcePrepareData(array $validated, Request $request, ?Model $item = null): array
    {
        // Store witnesses as JSON array [{name, mobile}, ...]
        $witnesses = array_values(array_filter($validated['witnesses'] ?? [], fn($w) => !empty($w['name'])));
        $witnessJson = !empty($witnesses) ? json_encode($witnesses, JSON_UNESCAPED_UNICODE) : null;

        // Strip keys not in Registry $fillable
        $strip = ['witnesses', 'secondary_mobile', 'pending_amount', 'customer_bond_id', 'document', 'mobile'];
        $payload = array_diff_key($validated, array_flip($strip));

        // Defaults for hidden fields
        $payload['booking_mode'] = $payload['booking_mode'] ?? 'other';
        $payload['land_size']    = $payload['land_size'] ?? 0;
        $payload['witness_name'] = $witnessJson;

        // Auto-generate registry_code on create
        if (!$item && empty($payload['registry_code'])) {
            $payload['registry_code'] = $this->nextRegistryCode();
        }

        // On update, don't overwrite receipt_no
        if ($item) {
            unset($payload['receipt_no']);
        }

        return $payload;
    }

    private function nextRegistryCode(): string
    {
        $prefix = 'RGC';
        $max = Registry::where('registry_code', 'like', $prefix . '%')
            ->pluck('registry_code')
            ->map(fn ($v) => preg_match('/^' . preg_quote($prefix, '/') . '(\d+)$/', (string) $v, $m) ? (int) $m[1] : 0)
            ->max() ?? 0;
        $next = $max + 1;
        do {
            $code = $prefix . str_pad((string) $next, 5, '0', STR_PAD_LEFT);
            $next++;
        } while (Registry::where('registry_code', $code)->exists());
        return $code;
    }

    protected function resourceQuery()
    {
        return Registry::with(['customer', 'arazi', 'agent'])->latest();
    }

    public function store(Request $request)
    {
        $request->validate($this->resourceRules(), [
            'arazi_code.unique' => 'A registry already exists for this Arazi. Each Arazi can only have one registry.',
        ]);
        try {
            return parent::store($request);
        } catch (\Illuminate\Database\QueryException $e) {
            if ($e->errorInfo[1] === 1062) {
                return redirect()->back()->withInput()
                    ->with('error', 'A registry already exists for this Arazi. Each Arazi can only have one registry.');
            }
            throw $e;
        }
    }

    public function update(Request $request, $id)
    {
        $item = Registry::findOrFail($id);
        $request->validate($this->resourceRules($item), [
            'arazi_code.unique' => 'A registry already exists for this Arazi. Each Arazi can only have one registry.',
        ]);
        try {
            return parent::update($request, $id);
        } catch (\Illuminate\Database\QueryException $e) {
            if ($e->errorInfo[1] === 1062) {
                return redirect()->back()->withInput()
                    ->with('error', 'A registry already exists for this Arazi. Each Arazi can only have one registry.');
            }
            throw $e;
        }
    }

    // Override index to support search filters for plot registry listing
    public function index(Request $request)
    {
        $q = Registry::with(['customer', 'arazi', 'agent', 'plot']);

        $filterAraziCode = trim((string) $request->input('arazi_code', ''));
        $filterPlotId    = $request->input('plot_id');
        $filterRegNo     = trim((string) $request->input('reg_no', ''));
        $filterDeedNo    = trim((string) $request->input('deed_no', ''));

        if ($filterAraziCode !== '') {
            $q->where('arazi_code', $filterAraziCode);
        }

        if ($filterPlotId) {
            $q->where('plot_id', $filterPlotId);
        }

        if ($filterRegNo !== '') {
            $q->where(function ($q2) use ($filterRegNo) {
                $q2->where('registry_code', 'like', "%{$filterRegNo}%")
                   ->orWhere('receipt_no', 'like', "%{$filterRegNo}%")
                   ->orWhere('customer_reg_no', 'like', "%{$filterRegNo}%");
            });
        }

        if ($filterDeedNo !== '') {
            $q->where('deed_no', 'like', "%{$filterDeedNo}%");
        }

        $records = $q->latest()->get();

        $rows = $records->map(function (Model $record) {
            return array_merge($this->resourceRow($record), [
                'edit_url'     => route($this->resourceRouteName() . '.edit', $record),
                'delete_url'   => route($this->resourceRouteName() . '.destroy', $record),
                'print_url'    => route($this->resourceRouteName() . '.print', $record),
                'doc_url'      => $record->document_path ? asset('storage/' . $record->document_path) : null,
            ]);
        })->all();

        // Plots for selected arazi code (all arazis with that code)
        $filterPlots = collect();
        if ($filterAraziCode !== '') {
            $filterPlots = \App\Models\Plot::where('arazi_code', $filterAraziCode)->orderBy('plot_number')->get(['id','plot_number','title']);
        }

        // Unique arazi codes for dropdown
        $araziOptions = Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '!=', '')
            ->orderBy('legacy_arazi_code')
            ->pluck('legacy_arazi_code')
            ->unique()
            ->values();

        return view('registries.index', [
            'title'           => $this->resourceTitle(),
            'columns'         => $this->resourceColumns(),
            'rows'            => $rows,
            'createUrl'       => route($this->resourceRouteName() . '.create'),
            'araziOptions'    => $araziOptions,
            'filterPlots'     => $filterPlots,
            'filterAraziCode' => $filterAraziCode,
            'filterPlotId'    => $filterPlotId,
            'filterRegNo'     => $filterRegNo,
            'filterDeedNo'    => $filterDeedNo,
        ]);
    }

    public function create()
    {
        $modelClass = $this->resourceModel();
        $item = new $modelClass();

        // auto-generate receipt number for new registries
        $item->receipt_no = $this->nextRegistryNumber();

        $customers = Customer::orderBy('name')->get(['id','name','mobile','secondary_mobile']);
        $arazis = Arazi::orderBy('legacy_arazi_code')->get(['id','legacy_arazi_code','plot_number'])
                        ->mapWithKeys(fn($a) => [$a->id => ($a->legacy_arazi_code ?: $a->plot_number)])
                        ->all();
        $agents = Agent::orderBy('name')->pluck('name', 'id')->all();

        return view('registries.add', [
            'title'  => 'Add ' . $this->resourceTitle(),
            'action' => route($this->resourceRouteName() . '.store'),
            'method' => 'POST',
            'item'   => $item,
            'customers' => $customers->pluck('name', 'id')->all(),
            'customersJson' => $customers->keyBy('id')->map(fn($c) => ['name'=>$c->name,'mobile'=>$c->mobile,'secondary_mobile'=>$c->secondary_mobile]),
            'arazis' => $arazis,
            'agents' => $agents,
        ]);
    }

    public function edit($id)
    {
        $modelClass = $this->resourceModel();
        $item = $modelClass::findOrFail($id);

        $customers = Customer::orderBy('name')->get(['id','name','mobile','secondary_mobile']);
        $arazis = Arazi::orderBy('legacy_arazi_code')->get(['id','legacy_arazi_code','plot_number'])
                        ->mapWithKeys(fn($a) => [$a->id => ($a->legacy_arazi_code ?: $a->plot_number)])
                        ->all();
        $agents = Agent::orderBy('name')->pluck('name', 'id')->all();

        return view('registries.add', [
            'title'        => 'Edit ' . $this->resourceTitle(),
            'action'       => route($this->resourceRouteName() . '.update', $item),
            'method'       => 'PUT',
            'item'         => $item,
            'customers'    => $customers->pluck('name', 'id')->all(),
            'customersJson'=> $customers->keyBy('id')->map(fn($c) => ['name'=>$c->name,'mobile'=>$c->mobile,'secondary_mobile'=>$c->secondary_mobile]),
            'arazis'       => $arazis,
            'agents'       => $agents,
        ]);
    }

    public function print($id)
    {
        $registry = Registry::with(['customer', 'arazi', 'agent'])->findOrFail($id);
        return view('prints.registry_certificate', ['registry' => $registry, 'title' => 'Registry Certificate']);
    }

    public function pdf($id)
    {
        $registry = Registry::with(['customer', 'arazi', 'agent'])->findOrFail($id);
        $html = view('prints.registry_certificate', ['registry' => $registry, 'title' => 'Registry Certificate'])->render();
        if (class_exists(\Barryvdh\DomPDF\Facade\Pdf::class)) {
            $pdf = \Barryvdh\DomPDF\Facade\Pdf::loadHTML($html);
            return $pdf->download('registry-' . $registry->id . '.pdf');
        }
        return response($html)->header('Content-Type', 'text/html');
    }

    public function esign(Request $request, $id)
    {
        $registry = Registry::findOrFail($id);
        $registry->esign_signed = true;
        $registry->esign_data = json_encode(['signed_at' => now()->toDateTimeString(), 'by' => auth()->id()]);
        $registry->save();

        return response()->json(['ok' => true, 'message' => 'Registry e-signed (placeholder)']);
    }

    protected function resourceRow(Model $item): array
    {
        /** @var Registry $item */
        return [
            'cells' => [
                $item->registry_code ?? '-',
                $item->customer?->name ?? '-',
                $item->arazi?->legacy_arazi_code ?? '-',
                $item->plot?->title ?? $item->plot?->plot_number ?? '-',
                strtoupper((string) $item->booking_mode),
                optional($item->registry_date)->format('d-m-Y') ?? '-',
                $item->deed_no ?? '—',
                $item->circle_value !== null ? number_format((float) $item->circle_value, 2) : '—',
                number_format((float) ($item->registry_amount ?? $item->land_size), 2),
                ucfirst((string) $item->lock_status),
                ucfirst($item->status),
            ],
        ];
    }

    protected function resourceAfterSave(Model $item, Request $request, array $validated, ?Model $original = null): void
    {
        /** @var Registry $item */
        // handle uploaded registry document if present
        if ($request->hasFile('document')) {
            $file = $request->file('document');
            if ($file->isValid()) {
                $path = $file->store('registries', 'public');
                $item->document_path = $path;
                $item->save();
            }
        }

        if ($item->status === 'completed' || $item->payment_status === 'completed') {
            $this->registryLifecycleService->markRegistryPaid($item);
            return;
        }

        if ((float) ($item->advance_amount ?? 0) > 0 || $item->status === 'pending') {
            $item->forceFill([
                'due_date' => $item->due_date ?? Carbon::now()->addDays(15),
            ])->save();
            $this->registryLifecycleService->markRegistryPending($item);
        }
    }

    public function bondLookup(Request $request)
    {
        $name    = trim((string) $request->query('name', ''));
        $araziQ  = trim((string) $request->query('arazi', ''));
        $plotQ   = trim((string) $request->query('plot', ''));
        $bondNo  = trim((string) $request->query('bond_no', ''));

        // Need at least one param
        if (!$name && !$araziQ && !$plotQ && !$bondNo) {
            return response()->json(['found' => false, 'results' => []]);
        }

        $query = \App\Models\CustomerBond::with(['customer', 'arazi', 'plots', 'payments']);

        if ($bondNo) {
            $query->where('bond_no', 'like', '%'.$bondNo.'%');
        }
        if ($name) {
            $query->whereHas('customer', fn ($c) =>
                $c->where('name', 'like', '%'.$name.'%')
                  ->orWhere('mobile', 'like', '%'.$name.'%')
            );
        }
        if ($araziQ) {
            $query->whereHas('arazi', fn ($a) =>
                $a->where('legacy_arazi_code', 'like', '%'.$araziQ.'%')
                  ->orWhere('legacy_arazi_code', 'like', '%'.$araziQ.'%')
            );
        }
        if ($plotQ) {
            $query->whereHas('plots', fn ($p) =>
                $p->where('title', 'like', '%'.$plotQ.'%')
                  ->orWhere('plot_number', 'like', '%'.$plotQ.'%')
            );
        }

        $bonds = $query->latest()->limit(10)->get();

        if ($bonds->isEmpty()) {
            return response()->json(['found' => false, 'results' => []]);
        }

        $results = $bonds->map(function ($bond) {
            $paid    = (float) $bond->payments->whereNotIn('entry_type', ['return','discount'])->sum('amount');
            $debit   = (float) $bond->payments->whereIn('entry_type', ['return','discount'])->sum('amount');
            $netPaid = $paid - $debit;
            $total   = (float) ($bond->total_amount ?? $bond->bond_amount ?? 0);
            $pending = max($total - $netPaid, 0);

            return [
                'found'            => true,
                'bond_id'          => $bond->id,
                'bond_no'          => $bond->bond_no,
                'customer_id'      => $bond->customer_id,
                'customer_name'    => $bond->customer?->name ?? '',
                'mobile'           => $bond->customer?->mobile ?? '',
                'secondary_mobile' => $bond->customer?->secondary_mobile ?? '',
                'arazi_code'       => $bond->arazi_code ?: ($bond->arazi?->legacy_arazi_code ?? ''),
                'plots'            => $bond->plots->map(fn ($p) => ['id' => $p->id, 'title' => $p->title ?? $p->plot_number])->values(),
                'bond_amount'      => $total,
                'paid_amount'      => $netPaid,
                'pending_amount'   => $pending,
            ];
        })->values()->all();

        return response()->json([
            'found'   => true,
            'results' => $results,
        ]);
    }

    private function nextRegistryNumber(): string
    {
        $prefix = 'RG';

        $max = Registry::where('receipt_no', 'like', $prefix . '%')
            ->pluck('receipt_no')
            ->map(function ($entryNo) use ($prefix) {
                return preg_match('/^' . preg_quote($prefix, '/') . '(\d+)$/', (string) $entryNo, $matches)
                    ? (int) $matches[1]
                    : 0;
            })->max() ?? 0;

        $next = $max + 1;

        do {
            $entryNo = $prefix . str_pad((string) $next, 5, '0', STR_PAD_LEFT);
            $next++;
        } while (Registry::where('receipt_no', $entryNo)->exists());

        return $entryNo;
    }
}
