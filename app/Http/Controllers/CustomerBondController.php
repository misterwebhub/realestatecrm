<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Arazi;
use App\Models\Customer;
use App\Models\CustomerBond;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Validation\Rule;

class CustomerBondController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Customer Bond';
    }

    protected function resourceModel(): string
    {
        return CustomerBond::class;
    }

    protected function resourceRouteName(): string
    {
        return 'customer-bonds';
    }

    protected function resourceColumns(): array
    {
        return ['Bond No', 'Customer', 'Arazi', 'Bond Date', 'Amount'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            ['name' => 'bond_no', 'label' => 'Bond Number', 'type' => 'text', 'value' => $item?->bond_no],
            [
                'name' => 'customer_id',
                'label' => 'Customer',
                'type' => 'select',
                'options' => Customer::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $item?->customer_id ?? request('customer_id'),
            ],
            [
                'name' => 'arazi_id',
                'label' => 'Arazi',
                'type' => 'select',
                'options' => Arazi::orderBy('plot_number')->pluck('plot_number', 'id')->all(),
                'value' => $item?->arazi_id,
            ],
            ['name' => 'bond_date', 'label' => 'Bond Date', 'type' => 'date', 'value' => optional($item?->bond_date)->format('Y-m-d')],
            ['name' => 'bond_amount', 'label' => 'Bond Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->bond_amount],
            // multiple witnesses: newline-separated textarea
            ['name' => 'witnesses', 'label' => 'Witnesses', 'type' => 'textarea', 'help' => 'One witness per line (name).', 'value' => $item ? implode("\n", $item->witnesses->pluck('name')->all()) : ''],
            ['name' => 'notes', 'label' => 'Notes', 'type' => 'textarea', 'value' => $item?->notes],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'bond_no' => ['required', 'string', 'max:50', Rule::unique('customer_bonds', 'bond_no')->ignore($item?->id)],
            'customer_id' => ['required', 'exists:customers,id'],
            'arazi_id' => ['required', 'exists:arazis,id'],
            'bond_date' => ['required', 'date'],
            'bond_amount' => ['nullable', 'numeric', 'min:0'],
            'total_amount' => ['nullable', 'numeric', 'min:0'],
            'amount' => ['nullable', 'numeric', 'min:0'],
            'witnesses' => ['nullable', 'string'],
            'notes' => ['nullable', 'string'],
            // legacy form fields
            'bond_type' => ['nullable', 'string', 'max:100'],
            'bayana_mode' => ['nullable', 'string', 'max:50'],
            'last_date' => ['nullable', 'date'],
            'land_size' => ['nullable', 'string', 'max:100'],
            'id_card_no' => ['nullable', 'string', 'max:100'],
            'customer_address' => ['nullable', 'string'],
        ];
    }

    protected function resourcePrepareData(array $validated, \Illuminate\Http\Request $request, ?Model $item = null): array
    {
        $payload = $validated;
        unset($payload['witnesses']);

        return $payload;
    }

    protected function resourceAfterSave(Model $item, \Illuminate\Http\Request $request, array $validated, ?Model $original = null): void
    {
        $lines = isset($validated['witnesses']) ? preg_split('/\r\n|\r|\n/', trim($validated['witnesses'])) : [];
        $names = array_filter(array_map('trim', $lines));

        $item->witnesses()->delete();
        foreach ($names as $name) {
            if ($name === '') {
                continue;
            }
            $item->witnesses()->create([ 'name' => $name ]);
        }
    }

    protected function resourceQuery()
    {
        return CustomerBond::with(['customer', 'arazi', 'witnesses', 'broker'])->latest();
    }

    public function create()
    {
        $modelClass = $this->resourceModel();
        $item = new $modelClass();

        $customers = \App\Models\Customer::orderBy('name')->pluck('name', 'id')->all();
        $arazis = \App\Models\Arazi::orderBy('id')->get()->mapWithKeys(function ($a) { return [$a->id => ($a->legacy_arazi_code ?: ($a->plot_number ?? ('Arazi-' . $a->id)))]; })->all();
        $agents = \App\Models\Agent::orderBy('name')->pluck('name', 'id')->all();

        return view('customer_bonds.form_certificate', [
            'title' => 'Create ' . $this->resourceTitle(),
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

        $customers = \App\Models\Customer::orderBy('name')->pluck('name', 'id')->all();
        $arazis = \App\Models\Arazi::orderBy('id')->get()->mapWithKeys(function ($a) { return [$a->id => ($a->legacy_arazi_code ?: ($a->plot_number ?? ('Arazi-' . $a->id)))]; })->all();
        $agents = \App\Models\Agent::orderBy('name')->pluck('name', 'id')->all();

        return view('customer_bonds.form_certificate', [
            'title' => 'Edit ' . $this->resourceTitle(),
            'action' => route($this->resourceRouteName() . '.update', $item),
            'method' => 'PUT',
            'item' => $item,
            'customers' => $customers,
            'arazis' => $arazis,
            'agents' => $agents,
        ]);
    }

    protected function resourceRow(Model $item): array
    {
        /** @var CustomerBond $item */
        return [
            'cells' => [
                $item->bond_no,
                $item->customer?->name ?? '-',
                $item->arazi?->plot_number ?? '-',
                optional($item->bond_date)->format('d-m-Y') ?? '-',
                number_format((float) $item->bond_amount, 2),
            ],
            'print_url' => route('customer-bonds.print', $item->id),
            'pdf_url' => route('customer-bonds.pdf', $item->id),
            // mark that links for this resource should open in a new tab
            'open_in_new_tab' => true,
        ];
    }

    public function print($id)
    {
        $bond = CustomerBond::with(['customer', 'arazi', 'witnesses', 'broker'])->findOrFail($id);

        return view('prints.customer_bond_certificate', [
            'title' => 'Customer Bond Certificate',
            'bond' => $bond,
        ]);
    }

    public function pdf($id)
    {
        $bond = CustomerBond::with(['customer', 'arazi', 'witnesses', 'broker'])->findOrFail($id);
        $html = view('prints.customer_bond_certificate', ['title' => 'Customer Bond Certificate', 'bond' => $bond])->render();

        if (class_exists(\Barryvdh\DomPDF\Facade\Pdf::class)) {
            $pdf = \Barryvdh\DomPDF\Facade\Pdf::loadHTML($html);
            return $pdf->download('customer-bond-' . $bond->id . '.pdf');
        }

        return response($html)->header('Content-Type', 'text/html');
    }
}
