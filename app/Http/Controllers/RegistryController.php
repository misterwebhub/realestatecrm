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
use Illuminate\View\View;

class RegistryController extends Controller
{
    use ManagesCrud {
        store as crudStore;
        update as crudUpdate;
    }

    public function __construct(private readonly RegistryLifecycleService $registryLifecycleService)
    {
    }

    public function waitingPayments(): View
    {
        $this->registryLifecycleService->expirePendingRegistries();

        $records = $this->applyOwnershipScope(
            Registry::with(['customer', 'arazi', 'agent'])
                ->where('status', 'pending')
                ->whereNotNull('due_date')
                ->orderBy('due_date')
        )->get();

        // Exclude registries where more than 50% of the linked bond amount is already paid.
        $records = $records->reject(function (Registry $registry) {
            return $this->registryPaymentProgress($registry) > 50.0;
        })->values();

        return view('registries.waiting', [
            'title' => 'Waiting Payments',
            'records' => $records,
        ]);
    }

    /**
     * Percentage of the linked bond amount that has already been paid for a registry.
     * Bonds are matched by the registry's customer + arazi code.
     */
    protected function registryPaymentProgress(Registry $registry): float
    {
        if (! $registry->customer_id || ! $registry->arazi_code) {
            return 0.0;
        }

        $bonds = \App\Models\CustomerBond::where('customer_id', $registry->customer_id)
            ->where('arazi_code', $registry->arazi_code)
            ->withSum('payments as paid_amount', 'amount')
            ->get(['id', 'total_amount', 'bond_amount']);

        if ($bonds->isEmpty()) {
            return 0.0;
        }

        $total = (float) $bonds->sum(fn ($b) => (float) ($b->total_amount ?? $b->bond_amount ?? 0));
        $paid  = (float) $bonds->sum(fn ($b) => (float) ($b->paid_amount ?? 0));

        if ($total <= 0) {
            return 0.0;
        }

        return ($paid / $total) * 100.0;
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
        return ['Reg Code', 'Customer', 'Bond Arazi', 'Registry Arazi', 'Plot', 'Booking Mode', 'Registry Date', 'Deed No', 'Circle Value', 'Amount', 'Lock', 'Status'];
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
            ],
            'partner_id'       => [
                'required', 'exists:partners,id',
                function ($attribute, $value, $fail) use ($item) {
                    $partnerId = (int) $value;
                    $araziCode = trim((string) request()->input('arazi_code', ''));

                    if ($partnerId <= 0 || $araziCode === '') {
                        return;
                    }

                    // Assigned area = total area this partner bought (as a Kisan Registry
                    // buyer) for this arazi and any arazi merged with it.
                    $codes = $this->relatedAraziCodes($araziCode);
                    $registryIds = \App\Models\KisanRegistry::whereIn('arazi_code', $codes)->pluck('id');

                    $assigned = (float) \App\Models\KisanRegistryBuyer::whereIn('kisan_registry_id', $registryIds)
                        ->where('partner_id', $partnerId)
                        ->sum('area');

                    // No allocation recorded → nothing to cap against.
                    if ($assigned <= 0) {
                        return;
                    }

                    // Area of the registry being saved (plot area, else land_size).
                    $plotId  = request()->input('plot_id');
                    $newArea = 0.0;
                    if ($plotId) {
                        $newArea = (float) (\App\Models\Plot::whereKey($plotId)->value('area') ?? 0);
                    }
                    if ($newArea <= 0) {
                        $newArea = (float) request()->input('land_size', 0);
                    }

                    // Area already registered for this partner across these arazi codes
                    // (excluding this record when editing).
                    $existing = (float) Registry::query()
                        ->where('registries.partner_id', $partnerId)
                        ->whereIn('registries.arazi_code', $codes)
                        ->when($item?->id, fn ($q) => $q->where('registries.id', '!=', $item->id))
                        ->leftJoin('plots', 'plots.id', '=', 'registries.plot_id')
                        ->sum(\Illuminate\Support\Facades\DB::raw('COALESCE(plots.area, registries.land_size, 0)'));

                    $total = $existing + $newArea;

                    if ($total > $assigned + 0.001) {
                        $remaining = max($assigned - $existing, 0);
                        $fail(sprintf(
                            'This partner is assigned %s gaz for this Arazi. Already registered: %s gaz, this registry: %s gaz — total %s exceeds the assigned area. Remaining allowed: %s gaz.',
                            rtrim(rtrim(number_format($assigned, 2), '0'), '.'),
                            rtrim(rtrim(number_format($existing, 2), '0'), '.'),
                            rtrim(rtrim(number_format($newArea, 2), '0'), '.'),
                            rtrim(rtrim(number_format($total, 2), '0'), '.'),
                            rtrim(rtrim(number_format($remaining, 2), '0'), '.')
                        ));
                    }
                },
            ],
            'plot_id'          => ['nullable', 'exists:plots,id'],
            'registry_date'    => ['required', 'date'],
            'deed_no'          => [
                'required', 'string', 'max:100',
                function ($attribute, $value, $fail) use ($item) {
                    $araziCode = trim((string) request()->input('arazi_code', ''));
                    $deedNo    = trim((string) $value);

                    if ($araziCode === '' || $deedNo === '') {
                        return;
                    }

                    // Cap = total_gaz recorded in kisan_registries for this arazi + deed.
                    $cap = (float) \App\Models\KisanRegistry::where('arazi_code', $araziCode)
                        ->where(function ($q) use ($deedNo) {
                            $q->where('arazi_deed_no', $deedNo)
                              ->orWhere('name_deed_no', $deedNo);
                        })
                        ->sum('total_gaz');

                    // No kisan-registry gaz recorded → nothing to cap against.
                    if ($cap <= 0) {
                        return;
                    }

                    // Area of the registry being saved (its plot's area, falling back to land_size).
                    $plotId  = request()->input('plot_id');
                    $newArea = 0.0;
                    if ($plotId) {
                        $newArea = (float) (\App\Models\Plot::whereKey($plotId)->value('area') ?? 0);
                    }
                    if ($newArea <= 0) {
                        $newArea = (float) request()->input('land_size', 0);
                    }

                    // Sum of area already registered for this arazi + deed (excluding self on edit).
                    $existing = (float) Registry::query()
                        ->where('registries.arazi_code', $araziCode)
                        ->where('registries.deed_no', $deedNo)
                        ->when($item?->id, fn ($q) => $q->where('registries.id', '!=', $item->id))
                        ->leftJoin('plots', 'plots.id', '=', 'registries.plot_id')
                        ->sum(\Illuminate\Support\Facades\DB::raw('COALESCE(plots.area, registries.land_size, 0)'));

                    $total = $existing + $newArea;

                    if ($total > $cap + 0.001) {
                        $remaining = max($cap - $existing, 0);
                        $fail("Total registry area for this Arazi & Deed No ({$total}) exceeds the Kisan registry total gaz ({$cap}). Remaining allowed: {$remaining}.");
                    }
                },
            ],
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
        return $this->applyOwnershipScope(Registry::with(['customer', 'arazi', 'agent'])->latest());
    }

    public function store(Request $request)
    {
        $this->authorizeCrud('create');
        $request->validate($this->resourceRules());

        return $this->crudStore($request);
    }

    public function update(Request $request, $id)
    {
        $item = Registry::findOrFail($id);
        $this->authorizeOwnership($item);
        $this->authorizeCrud('edit', $item);
        $request->validate($this->resourceRules($item));

        return $this->crudUpdate($request, $id);
    }

    // Override index to support search filters for plot registry listing
    public function index(Request $request)
    {
        $q = $this->applyOwnershipScope(Registry::with(['customer', 'arazi', 'agent', 'plot']));

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
                'doc_url'      => $record->document_path ? route('registries.download', $record->id) : null,
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
        $this->authorizeCrud('create');

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
        $this->authorizeOwnership($item);
        $this->authorizeCrud('edit', $item);

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
        $this->authorizeOwnership($registry);
        return view('prints.registry_certificate', ['registry' => $registry, 'title' => 'Registry Certificate']);
    }

    public function download($id)
    {
        $registry = Registry::findOrFail($id);
        $this->authorizeOwnership($registry);

        if (! $registry->document_path) {
            abort(404, 'No file attached.');
        }

        $path = storage_path('app/public/' . $registry->document_path);

        if (! file_exists($path)) {
            abort(404, 'File not found.');
        }

        return response()->download($path, basename($registry->document_path));
    }

    public function pdf($id)
    {
        $registry = Registry::with(['customer', 'arazi', 'agent'])->findOrFail($id);
        $this->authorizeOwnership($registry);
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
        $this->authorizeOwnership($registry);
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
                $item->plot?->arazi_code ?: '-',
                $item->arazi_code ?: '-',
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
                $disk = \Illuminate\Support\Facades\Storage::disk('public');

                // Ensure the target directory exists before storing the file.
                if (! $disk->exists('registries')) {
                    $disk->makeDirectory('registries');
                }

                // Keep the original file name; sanitise only what could break a path.
                $original  = $file->getClientOriginalName();
                $extension = pathinfo($original, PATHINFO_EXTENSION);
                $baseName  = pathinfo($original, PATHINFO_FILENAME);
                $baseName  = trim(preg_replace('/[\/\\\\:*?"<>|]+/', '_', $baseName)) ?: 'document';
                $safeName  = $baseName . ($extension ? '.' . $extension : '');

                // If a file with the same name already exists, keep both by
                // storing this upload as a numbered copy instead of replacing it.
                $fileName = $safeName;
                $counter  = 1;
                while ($disk->exists('registries/' . $fileName)) {
                    $fileName = $baseName . ' (' . $counter . ')' . ($extension ? '.' . $extension : '');
                    $counter++;
                }

                $path = $file->storeAs('registries', $fileName, 'public');
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
                $p->where('title', $plotQ) // exact — plot title behaves like a plot number
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

    /**
     * Return the list of deed numbers recorded in kisan_registries for a given arazi_code.
     * Used to populate the Deed No dropdown on the registry create form once a bond is chosen.
     */
    public function deedsByArazi(Request $request)
    {
        $code = trim((string) $request->query('arazi_code', ''));

        if ($code === '') {
            return response()->json(['found' => false, 'deeds' => []]);
        }

        $rows = \App\Models\KisanRegistry::where('arazi_code', $code)
            ->get(['arazi_deed_no', 'name_deed_no']);

        $deeds = $rows->flatMap(function ($r) {
            return [$r->arazi_deed_no, $r->name_deed_no];
        })->filter(function ($v) {
            return $v !== null && trim((string) $v) !== '';
        })->map(function ($v) {
            return trim((string) $v);
        })->unique()->values()->all();

        return response()->json([
            'found' => count($deeds) > 0,
            'deeds' => $deeds,
        ]);
    }

    /**
     * Return the list of arazi codes that share an Arazi Group with the given
     * arazi code. The given code is always returned first (default selection);
     * any merged/grouped arazi codes follow so the registry form can offer them
     * as alternative options in the Arazi No dropdown.
     */
    public function araziGroupOptions(Request $request)
    {
        $code = trim((string) $request->query('arazi_code', ''));

        if ($code === '') {
            return response()->json(['options' => []]);
        }

        // Arazi record ids that match this code (legacy_arazi_code / plot_number).
        $ids = \App\Models\Arazi::idsForCode($code);

        $options = [];
        $seen = [];

        $push = function (?string $c, ?string $location = null) use (&$options, &$seen) {
            $c = trim((string) $c);
            if ($c === '' || isset($seen[$c])) {
                return;
            }
            $seen[$c] = true;
            $label = $location ? ($c . ' — ' . $location) : $c;
            $options[] = ['value' => $c, 'label' => $label];
        };

        // Default option: the bond's own arazi code.
        $push($code);

        if (! empty($ids)) {
            // Groups that contain any of these arazi ids.
            $groupIds = \App\Models\AraziGroupItem::whereIn('arazi_id', $ids)
                ->pluck('arazi_group_id')
                ->unique()
                ->all();

            if (! empty($groupIds)) {
                $memberIds = \App\Models\AraziGroupItem::whereIn('arazi_group_id', $groupIds)
                    ->pluck('arazi_id')
                    ->unique()
                    ->all();

                $arazis = \App\Models\Arazi::whereIn('id', $memberIds)
                    ->get(['id', 'legacy_arazi_code', 'location']);

                foreach ($arazis as $arazi) {
                    $push($arazi->legacy_arazi_code ?: ('#' . $arazi->id), $arazi->location);
                }
            }
        }

        return response()->json([
            'grouped' => count($options) > 1,
            'options' => $options,
        ]);
    }

    /**
     * Return the partners associated with a given arazi code. A partner is
     * "associated" with an arazi when they appear as a buyer in a Kisan
     * Registry recorded for that arazi (kisan_registry_buyers). Used to
     * populate the required Partner dropdown on the customer registry form.
     */
    public function partnersByArazi(Request $request)
    {
        $code = trim((string) $request->query('arazi_code', ''));

        if ($code === '') {
            return response()->json(['partners' => []]);
        }

        // Include grouped/merged arazi codes so partners from any merged arazi appear too.
        $codes = $this->relatedAraziCodes($code);

        $registryIds = \App\Models\KisanRegistry::whereIn('arazi_code', $codes)->pluck('id');

        $partners = \App\Models\Partner::whereIn(
                'id',
                \App\Models\KisanRegistryBuyer::whereIn('kisan_registry_id', $registryIds)
                    ->whereNotNull('partner_id')
                    ->pluck('partner_id')
                    ->unique()
            )
            ->orderBy('name')
            ->get(['id', 'name'])
            ->map(fn ($p) => ['id' => $p->id, 'name' => $p->name])
            ->values();

        return response()->json([
            'partners' => $partners,
        ]);
    }

    /**
     * Given an arazi code, return that code plus any arazi codes merged with it
     * through an Arazi Group.
     */
    private function relatedAraziCodes(string $code): array
    {
        $codes = [$code];
        $ids = Arazi::idsForCode($code);

        if (! empty($ids)) {
            $groupIds = \App\Models\AraziGroupItem::whereIn('arazi_id', $ids)
                ->pluck('arazi_group_id')->unique()->all();

            if (! empty($groupIds)) {
                $memberIds = \App\Models\AraziGroupItem::whereIn('arazi_group_id', $groupIds)
                    ->pluck('arazi_id')->unique()->all();

                $codes = array_merge(
                    $codes,
                    Arazi::whereIn('id', $memberIds)->pluck('legacy_arazi_code')->filter()->all()
                );
            }
        }

        return array_values(array_unique(array_filter($codes, fn ($c) => trim((string) $c) !== '')));
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
