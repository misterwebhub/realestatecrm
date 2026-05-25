<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Arazi;
use App\Models\Plot;
use Illuminate\Database\Eloquent\Model;

class PlotController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Plot';
    }

    protected function resourceModel(): string
    {
        return Plot::class;
    }

    protected function resourceRouteName(): string
    {
        return 'plots';
    }

    protected function resourceColumns(): array
    {
        return ['Arazi', 'Block', 'Title', 'Area', 'Coordinates', 'Latitude', 'Longitude', 'Status'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            [
                'name' => 'arazi_id',
                'label' => 'Arazi',
                'type' => 'select',
                'options' => Arazi::orderBy('legacy_arazi_code')
                    ->get()
                    ->groupBy(function (Arazi $a) {
                        return $a->legacy_arazi_code ?: ($a->plot_number ?? ('Arazi-' . $a->id));
                    })
                    ->mapWithKeys(function ($group, $label) {
                        $first = $group->sortBy('id')->first();
                        return [$first->id => $label];
                    })->all(),
                'value' => $item?->arazi_id,
            ],
            ['name' => 'title', 'label' => 'Title', 'type' => 'text', 'value' => $item?->title],
            ['name' => 'block', 'label' => 'Block', 'type' => 'text', 'value' => $item?->block],
            ['name' => 'area', 'label' => 'Area', 'type' => 'number', 'step' => '0.01', 'value' => $item?->area],
            ['name' => 'coordinates', 'label' => 'Coordinates', 'type' => 'text', 'value' => $item?->coordinates],
            ['name' => 'latitude', 'label' => 'Latitude', 'type' => 'number', 'step' => '0.000001', 'value' => $item?->latitude],
            ['name' => 'longitude', 'label' => 'Longitude', 'type' => 'number', 'step' => '0.000001', 'value' => $item?->longitude],
            ['name' => 'description', 'label' => 'Description', 'type' => 'textarea', 'value' => $item?->description],
            ['name' => 'status', 'label' => 'Status', 'type' => 'select', 'options' => [
                'available' => 'Available',
                'booked_advance' => 'Booked (advance)',
                'hold' => 'Hold',
                'registry' => 'Registry done',
                'blacklist' => 'Blacklist',
                'not_for_sale' => 'Not for sale',
            ], 'value' => $item?->status ?? 'available'],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'arazi_id' => ['required', 'exists:arazis,id'],
            'title' => ['required', 'string', 'max:150'],
            'block' => ['nullable', 'string', 'max:20'],
            'area' => [
                'required',
                'numeric',
                'min:0',
                function ($attribute, $value, $fail) use ($item) {
                    $araziId = request()->input('arazi_id');

                    if (!$araziId) {
                        return;
                    }

                    $arazi = Arazi::find($araziId);

                    if (!$arazi) {
                        return;
                    }

                    $existing = \App\Models\Plot::where('arazi_id', $arazi->id)
                        ->when(isset($item->id), fn($q) => $q->where('id', '!=', $item->id))
                        ->sum('area');

                    $allowed = $arazi->saleable_area - $existing;

                    if ($value > $allowed) {
                        $fail('The plot area exceeds available saleable area (remaining: ' . $allowed . ').');
                    }
                }
            ],
            'coordinates' => ['nullable', 'string', 'max:255'],
            'latitude' => ['nullable', 'numeric'],
            'longitude' => ['nullable', 'numeric'],
            'description' => ['nullable', 'string'],
            'status' => ['required', 'in:available,booked_advance,hold,registry,blacklist,not_for_sale,locked,sold'],
        ];
    }

    protected function resourceQuery()
    {
        return Plot::with('arazi')->latest();
    }

    protected function resourceRow(Model $item): array
    {
        /** @var Plot $item */
        return [
            'cells' => [
                $item->arazi?->legacy_arazi_code ?: ($item->arazi?->plot_number ?? '-'),
                $item->block ?? '-',
                $item->title,
                (string) ($item->area ?? '-'),
                $item->coordinates ?? '-',
                $item->latitude ?? '-',
                $item->longitude ?? '-',
                ucfirst(str_replace('_', ' ', (string) ($item->status ?? 'available'))),
            ],
        ];
    }
}
