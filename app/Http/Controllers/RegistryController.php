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
        return ['Reg Code', 'Legacy Reg No', 'Customer', 'Arazi', 'Plot', 'Booking Mode', 'Registry Date', 'Amount', 'Lock', 'Status'];
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
                'name' => 'arazi_id',
                'label' => 'Arazi',
                'type' => 'select',
                'options' => Arazi::orderBy('plot_number')->pluck('plot_number', 'id')->all(),
                'value' => $item?->arazi_id,
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
            ['name' => 'registry_date', 'label' => 'Registry Date', 'type' => 'date', 'value' => optional($item?->registry_date)->format('Y-m-d'), 'required' => true],
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
            'customer_id' => ['required', 'exists:customers,id'],
            'arazi_id' => ['required', 'exists:arazis,id', Rule::unique('registries', 'arazi_id')->ignore($item?->id)],
            'agent_id' => ['required', 'exists:agents,id'],
            'check_by_agent_id' => ['nullable', 'exists:agents,id'],
            'registry_code' => ['nullable', 'string', 'max:40', Rule::unique('registries', 'registry_code')->ignore($item?->id)],
            'customer_reg_no' => ['nullable', 'string', 'max:40', Rule::unique('registries', 'customer_reg_no')->ignore($item?->id)],
            'registry_date' => ['required', 'date'],
            'booking_mode' => ['required', 'in:cash,emi,mixed,other'],
            'plot_id' => ['nullable', 'exists:plots,id'],
            'land_size' => ['required', 'numeric', 'min:0'],
            'registry_amount' => ['nullable', 'numeric', 'min:0'],
            'witness_name' => ['required', 'string', 'max:150'],
            'nominee_name' => ['nullable', 'string', 'max:150'],
            'broker_commission' => ['required', 'numeric', 'min:0', 'max:100'],
            'advance_amount' => ['nullable', 'numeric', 'min:0'],
            'down_payment' => ['nullable', 'numeric', 'min:0'],
            'installment_amount' => ['nullable', 'numeric', 'min:0'],
            'due_date' => ['nullable', 'date'],
            'expected_registry_date' => ['nullable', 'date'],
            'payment_words' => ['nullable', 'string', 'max:255'],
            'id_card_no' => ['nullable', 'string', 'max:60'],
            'status' => ['required', 'in:pending,completed,cancelled'],
            'payment_status' => ['required', 'in:pending,partial,completed,expired'],
            'lock_status' => ['required', 'in:unlock,lock'],
            'document' => ['nullable', 'file', 'mimes:pdf,jpeg,png,jpg', 'max:5120'],
        ];
    }

    protected function resourceQuery()
    {
        return Registry::with(['customer', 'arazi', 'agent'])->latest();
    }

    // Override index to support search filters for plot registry listing
    public function index(Request $request)
    {
        $q = Registry::with(['customer', 'arazi', 'agent']);

        if ($request->filled('arazi_number')) {
            $term = $request->input('arazi_number');
            $q->whereHas('arazi', fn ($q2) => $q2->where('plot_number', 'like', "%{$term}%"));
        }

        if ($request->filled('customer_name')) {
            $term = $request->input('customer_name');
            $q->whereHas('customer', fn ($q2) => $q2->where('name', 'like', "%{$term}%"));
        }

        if ($request->filled('broker_name')) {
            $term = $request->input('broker_name');
            $q->whereHas('agent', fn ($q2) => $q2->where('name', 'like', "%{$term}%"));
        }

        if ($request->filled('plot_number')) {
            $term = $request->input('plot_number');
            $q->whereHas('arazi.plots', fn ($q2) => $q2->where('plot_number', 'like', "%{$term}%")->orWhere('title', 'like', "%{$term}%"));
        }

        $records = $q->latest()->get();

        $rows = $records->map(function (Model $record) {
            return array_merge($this->resourceRow($record), [
                'edit_url' => route($this->resourceRouteName() . '.edit', $record),
                'delete_url' => route($this->resourceRouteName() . '.destroy', $record),
                'print_url' => route($this->resourceRouteName() . '.print', $record),
                'pdf_url' => route($this->resourceRouteName() . '.pdf', $record),
            ]);
        })->all();

        return view('registries.index', [
            'title' => $this->resourceTitle(),
            'columns' => $this->resourceColumns(),
            'rows' => $rows,
            'createUrl' => route($this->resourceRouteName() . '.create'),
            'filters' => $request->only(['arazi_number', 'customer_name', 'broker_name']),
        ]);
    }

    public function create()
    {
        $modelClass = $this->resourceModel();
        $item = new $modelClass();

        // auto-generate receipt number for new registries
        $item->receipt_no = $this->nextRegistryNumber();

        $customers = Customer::orderBy('name')->pluck('name', 'id')->all();
        $arazis = Arazi::orderBy('plot_number')->pluck('plot_number', 'id')->all();
        $agents = Agent::orderBy('name')->pluck('name', 'id')->all();

        return view('registries.add', [
            'title' => 'Add ' . $this->resourceTitle(),
            'action' => route($this->resourceRouteName() . '.store'),
            'method' => 'POST',
            'item' => $item,
            'customers' => $customers,
            'arazis' => $arazis,
            'agents' => $agents,
        ]);
    }

    public function edit($id)
    {
        $modelClass = $this->resourceModel();
        $item = $modelClass::findOrFail($id);

        $customers = Customer::orderBy('name')->pluck('name', 'id')->all();
        $arazis = Arazi::orderBy('plot_number')->pluck('plot_number', 'id')->all();
        $agents = Agent::orderBy('name')->pluck('name', 'id')->all();

        return view('registries.add', [
            'title' => 'Edit ' . $this->resourceTitle(),
            'action' => route($this->resourceRouteName() . '.update', $item),
            'method' => 'PUT',
            'item' => $item,
            'customers' => $customers,
            'arazis' => $arazis,
            'agents' => $agents,
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
                $item->customer_reg_no ?? '-',
                $item->customer?->name ?? '-',
                $item->arazi?->plot_number ?? '-',
                $item->plot?->title ?? $item->plot?->plot_number ?? '-',
                strtoupper((string) $item->booking_mode),
                optional($item->registry_date)->format('d-m-Y') ?? '-',
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
