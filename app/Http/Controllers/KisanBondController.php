<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Arazi;
use App\Models\Kisan;
use App\Models\KisanBond;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Validation\Rule;

class KisanBondController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Kisan Bond';
    }

    protected function resourceModel(): string
    {
        return KisanBond::class;
    }

    protected function resourceRouteName(): string
    {
        return 'kisan-bonds';
    }

    protected function resourceColumns(): array
    {
        return ['Bond No', 'Kisan', 'Arazi', 'Bond Date', 'Amount'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            ['name' => 'bond_no', 'label' => 'Bond Number', 'type' => 'text', 'value' => $item?->bond_no],
            [
                'name' => 'kisan_id',
                'label' => 'Kisan',
                'type' => 'select',
                'options' => Kisan::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $item?->kisan_id ?? request('kisan_id'),
            ],
            [
                'name' => 'arazi_id',
                'label' => 'Arazi',
                'type' => 'select',
                'options' => (function() use ($item) {
                    $q = Arazi::query();
                    $kisanId = $item?->kisan_id ?? request('kisan_id') ?? request()->route('kisan')?->id;
                    if ($kisanId) {
                        $q->where('kisan_id', $kisanId);
                    }

                    return $q->orderBy('legacy_arazi_code')
                        ->get()
                        ->mapWithKeys(function ($a) { return [$a->id => ($a->legacy_arazi_code ?: ($a->plot_number ?? ('Arazi-' . $a->id)))]; })
                        ->all();
                })(),
                'value' => $item?->arazi_id,
            ],
            ['name' => 'bond_date', 'label' => 'Bond Date', 'type' => 'date', 'value' => optional($item?->bond_date)->format('Y-m-d')],
            ['name' => 'bond_amount', 'label' => 'Bond Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->bond_amount],
            ['name' => 'mobile', 'label' => 'Mobile', 'type' => 'text', 'value' => $item?->mobile],
            ['name' => 'land_size', 'label' => 'Land Size', 'type' => 'text', 'value' => $item?->land_size],
            ['name' => 'sale_land', 'label' => 'Sale Land', 'type' => 'number', 'step' => '0.01', 'value' => $item?->sale_land],
            ['name' => 'sale_rate', 'label' => 'Sale Rate', 'type' => 'number', 'step' => '0.01', 'value' => $item?->sale_rate],
            ['name' => 'total_amount', 'label' => 'Total Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->total_amount],
            ['name' => 'bayana_mode', 'label' => 'Bayana Mode', 'type' => 'select', 'options' => ['cash' => 'Cash', 'cheque' => 'Cheque'], 'value' => $item?->bayana_mode],
            ['name' => 'bond_type', 'label' => 'Type', 'type' => 'text', 'value' => $item?->bond_type],
            ['name' => 'amount', 'label' => 'Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->amount],
            ['name' => 'balance', 'label' => 'Balance', 'type' => 'number', 'step' => '0.01', 'value' => $item?->balance],
            ['name' => 'last_date', 'label' => 'Last Date', 'type' => 'date', 'value' => optional($item?->last_date)->format('Y-m-d')],
            [
                'name' => 'broker_id',
                'label' => 'Broker',
                'type' => 'select',
                'options' => \App\Models\Agent::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $item?->broker_id,
            ],
            ['name' => 'broker_payment', 'label' => 'Broker Payment', 'type' => 'number', 'step' => '0.01', 'value' => $item?->broker_payment],
            ['name' => 'broker_paid', 'label' => 'Broker Paid', 'type' => 'number', 'step' => '0.01', 'value' => $item?->broker_paid],
            ['name' => 'broker_balance', 'label' => 'Broker Balance', 'type' => 'number', 'step' => '0.01', 'value' => $item?->broker_balance],
            ['name' => 'broker_comment', 'label' => 'Broker Comment', 'type' => 'textarea', 'value' => $item?->broker_comment],
            ['name' => 'kisan_comment', 'label' => 'Kisan Comment', 'type' => 'textarea', 'value' => $item?->kisan_comment],
            // multiple witnesses: provide newline-separated textarea
            ['name' => 'witnesses', 'label' => 'Witnesses', 'type' => 'textarea', 'help' => 'One witness per line (name).', 'value' => $item ? implode("\n", $item->witnesses->pluck('name')->all()) : ''],
            ['name' => 'notes', 'label' => 'Notes', 'type' => 'textarea', 'value' => $item?->notes],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'bond_no' => ['required', 'string', 'max:50', Rule::unique('kisan_bonds', 'bond_no')->ignore($item?->id)],
            'kisan_id' => ['required', 'exists:kisans,id'],
            'arazi_id' => ['required', 'exists:arazis,id'],
            'bond_date' => ['required', 'date'],
            'bond_amount' => ['required', 'numeric', 'min:0'],
            'mobile' => ['nullable', 'string', 'max:30'],
            'land_size' => ['nullable', 'string', 'max:60'],
            'sale_land' => ['nullable', 'numeric'],
            'sale_rate' => ['nullable', 'numeric'],
            'total_amount' => ['nullable', 'numeric'],
            'bayana_mode' => ['nullable', Rule::in(['cash', 'cheque'])],
            'bond_type' => ['nullable', 'string', 'max:100'],
            'amount' => ['nullable', 'numeric'],
            'balance' => ['nullable', 'numeric'],
            'last_date' => ['nullable', 'date'],
            'broker_id' => ['nullable', 'exists:agents,id'],
            'broker_payment' => ['nullable', 'numeric'],
            'broker_paid' => ['nullable', 'numeric'],
            'broker_balance' => ['nullable', 'numeric'],
            'broker_comment' => ['nullable', 'string'],
            'kisan_comment' => ['nullable', 'string'],
            'witnesses' => ['nullable', 'string'],
            'notes' => ['nullable', 'string'],
        ];
    }

    protected function resourcePrepareData(array $validated, \Illuminate\Http\Request $request, ?Model $item = null): array
    {
        // remove witnesses from payload; we'll handle separately
        $payload = $validated;
        unset($payload['witnesses']);

        return $payload;
    }

    protected function resourceAfterSave(Model $item, \Illuminate\Http\Request $request, array $validated, ?Model $original = null): void
    {
        // parse witnesses textarea (one per line) and sync to witnesses table
        $lines = isset($validated['witnesses']) ? preg_split('/\r\n|\r|\n/', trim($validated['witnesses'])) : [];
        $names = array_filter(array_map('trim', $lines));

        // delete existing and recreate — simple sync for demo
        $item->witnesses()->delete();
        foreach ($names as $name) {
            if ($name === '') {
                continue;
            }

            $item->witnesses()->create([
                'name' => $name,
            ]);
        }
    }

    protected function resourceQuery()
    {
        return KisanBond::with(['kisan', 'arazi'])->latest();
    }

    protected function resourceRow(Model $item): array
    {
        /** @var KisanBond $item */
        return [
            'cells' => [
                $item->bond_no,
                $item->kisan?->name ?? '-',
                $item->arazi?->legacy_arazi_code ?: ($item->arazi?->plot_number ?? '-'),
                optional($item->bond_date)->format('d-m-Y') ?? '-',
                number_format((float) $item->bond_amount, 2),
            ],
            'print_url' => route('kisan-bonds.print', $item->id),
            'pdf_url' => route('kisan-bonds.pdf', $item->id),
        ];
    }

    public function print($id)
    {
        $bond = KisanBond::with(['kisan', 'arazi'])->findOrFail($id);

        return view('prints.bond', [
            'title' => 'Kisan Bond',
            'bond' => $bond,
        ]);
    }

    public function pdf($id)
    {
        $bond = KisanBond::with(['kisan', 'arazi'])->findOrFail($id);
        $html = view('prints.bond', ['title' => 'Kisan Bond', 'bond' => $bond])->render();

        if (class_exists(\Barryvdh\DomPDF\Facade\Pdf::class)) {
            $pdf = \Barryvdh\DomPDF\Facade\Pdf::loadHTML($html);
            return $pdf->download('kisan-bond-' . $bond->id . '.pdf');
        }

        return response($html)->header('Content-Type', 'text/html');
    }
}
