<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Customer;
use App\Models\CustomerBondPayment;
use App\Models\Registry;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Validation\Rule;

class CustomerBondPaymentController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Customer Bond Payment';
    }

    protected function resourceModel(): string
    {
        return CustomerBondPayment::class;
    }

    protected function resourceRouteName(): string
    {
        return 'customer-bond-payments';
    }

    protected function resourceColumns(): array
    {
        return ['Entry No', 'Customer', 'Arazi', 'Plot', 'Land Size', 'Witness', 'Entry Date', 'Type', 'Amount'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            ['name' => 'entry_no', 'label' => 'Entry Number', 'type' => 'text', 'value' => $item?->entry_no],
            [
                'name' => 'customer_id',
                'label' => 'Customer',
                'type' => 'select',
                'options' => Customer::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $item?->customer_id,
            ],
            [
                'name' => 'arazi_id',
                'label' => 'Arazi',
                'type' => 'select',
                'options' => \App\Models\Arazi::orderBy('id')->get()->mapWithKeys(function ($a) { return [$a->id => ($a->legacy_arazi_code ?: ($a->plot_number ?? ('Arazi-' . $a->id)))]; })->all(),
                'value' => $item?->arazi_id,
            ],
            [
                'name' => 'plot_id',
                'label' => 'Plot',
                'type' => 'select',
                'options' => [],
                'value' => $item?->plot_id,
            ],
            ['name' => 'entry_date', 'label' => 'Entry Date', 'type' => 'date', 'value' => optional($item?->entry_date)->format('Y-m-d')],
            ['name' => 'entry_type', 'label' => 'Entry Type', 'type' => 'select', 'options' => ['advance' => 'Advance', 'installment' => 'Installment', 'final' => 'Final', 'penalty' => 'Penalty', 'other' => 'Other'], 'value' => $item?->entry_type ?? 'installment'],
            ['name' => 'land_size', 'label' => 'Land Size', 'type' => 'number', 'step' => '0.01', 'value' => $item?->land_size],
            ['name' => 'witness_name', 'label' => 'Witness Name', 'type' => 'text', 'value' => $item?->witness_name],
            ['name' => 'amount', 'label' => 'Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->amount],
            ['name' => 'payment_method', 'label' => 'Payment Method', 'type' => 'text', 'value' => $item?->payment_method],
            ['name' => 'remarks', 'label' => 'Remarks', 'type' => 'textarea', 'value' => $item?->remarks],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'entry_no' => ['required', 'string', 'max:50', Rule::unique('customer_bond_payments', 'entry_no')->ignore($item?->id)],
            'customer_id' => ['required', 'exists:customers,id'],
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
        // pass through plot_id and arazi_id
        return $validated;
    }

    protected function resourceQuery()
    {
        return CustomerBondPayment::with(['customer', 'arazi', 'plot'])->latest();
    }

    protected function resourceRow(Model $item): array
    {
        /** @var CustomerBondPayment $item */
        return [
            'cells' => [
                $item->entry_no,
                $item->customer?->name ?? '-',
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
}
