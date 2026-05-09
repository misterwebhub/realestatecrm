<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Arazi;
use App\Models\Kisan;
use App\Models\Plot;
use Illuminate\Database\Eloquent\Model;

class AraziController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Arazi';
    }

    protected function resourceModel(): string
    {
        return Arazi::class;
    }

    protected function resourceRouteName(): string
    {
        return 'arazis';
    }

    protected function resourceColumns(): array
    {
        return ['Arazi Number', 'Kisan', 'Location', 'Size', 'Unit', 'Road Area', 'Saleable', 'Available', 'Status'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            ['name' => 'legacy_arazi_code', 'label' => 'Arazi Number', 'type' => 'text', 'value' => $item?->legacy_arazi_code],
            [
                'name' => 'kisan_id',
                'label' => 'Kisan',
                'type' => 'select',
                'options' => Kisan::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $item?->kisan_id,
            ],
            ['name' => 'location', 'label' => 'Location', 'type' => 'text', 'value' => $item?->location],
            ['name' => 'size', 'label' => 'Size', 'type' => 'number', 'step' => '0.01', 'value' => $item?->size],
            ['name' => 'unit', 'label' => 'Unit', 'type' => 'select', 'options' => ['gaz' => 'Gaz', 'marla' => 'Marla', 'kanal' => 'Kanal', 'sqft' => 'Sq Ft'], 'value' => $item?->unit ?? 'gaz'],
            ['name' => 'road_area', 'label' => 'Road Area', 'type' => 'number', 'step' => '0.01', 'value' => $item?->road_area ?? 0],
            ['name' => 'coordinates', 'label' => 'Coordinates', 'type' => 'text', 'value' => $item?->coordinates],
            ['name' => 'status', 'label' => 'Status', 'type' => 'select', 'options' => ['available' => 'Available', 'sold' => 'Sold'], 'value' => $item?->status ?? 'available'],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'legacy_arazi_code' => ['nullable', 'string', 'max:50'],
            'kisan_id' => ['required', 'exists:kisans,id'],
            'location' => ['required', 'string', 'max:255'],
            'plot_type' => ['nullable', 'string', 'max:50'],
            'unit' => ['required', 'string', 'max:20'],
            'size' => ['required', 'numeric', 'min:0'],
            'road_area' => ['nullable', 'numeric', 'min:0', function ($attr, $value, $fail) {
                $value = (float) ($value ?? 0);
                $size = (float) (request()->input('size') ?? 0);

                if ($value > $size) {
                    $fail('Road area cannot be greater than total size.');
                }
            }],
            'coordinates' => ['nullable', 'string', 'max:255'],
            'status' => ['required', 'in:available,sold'],
        ];
    }

    protected function resourceQuery()
    {
        return Arazi::with('kisan')->latest();
    }

    public function index()
    {
        $records = Arazi::with('kisan')->latest()->get();

        // group by display label (legacy code or plot_number or fallback)
        $unique = $records->groupBy(function (Arazi $a) {
            return $a->legacy_arazi_code ?: ($a->plot_number ?? ('Arazi-' . $a->id));
        })->map(function ($group) {
            return $group->sortBy('id')->first();
        })->values();

        $routeName = $this->resourceRouteName();

        $rows = $unique->map(function (\Illuminate\Database\Eloquent\Model $record) use ($routeName) {
            return array_merge($this->resourceRow($record), [
                'edit_url' => route($routeName . '.edit', $record),
                'delete_url' => route($routeName . '.destroy', $record),
            ]);
        })->all();

        return view('crud.index', [
            'title' => $this->resourceTitle(),
            'columns' => $this->resourceColumns(),
            'rows' => $rows,
            'createUrl' => route($routeName . '.create'),
        ]);
    }

    public function saleable(Arazi $arazi)
    {
        $saleableTotal = $arazi->saleable_area;
        $existing = (float) Plot::where('arazi_id', $arazi->id)->sum('area');
        $remaining = $saleableTotal - $existing;
        if ($remaining < 0) $remaining = 0;

        $unit = $arazi->unit ?? 'gaz';
        try {
            $saleableGaz = \App\Services\AreaConverter::toGaz($remaining, $unit);
        } catch (\Exception $e) {
            $saleableGaz = (float) $remaining;
        }

        return response()->json([
            'saleable_total' => $saleableTotal,
            'existing' => $existing,
            'remaining' => round($remaining, 2),
            'unit' => $unit,
            'remaining_gaz' => $saleableGaz,
        ]);
    }

    public function plots(Arazi $arazi)
    {
        $plots = $arazi->plots()->get(['id', 'plot_number', 'title', 'area'])->map(function ($p) {
            return [
                'id' => $p->id,
                'label' => $p->title ?? ($p->plot_number ?: ('Plot-' . $p->id)),
                'area' => $p->area,
            ];
        })->values();

        return response()->json($plots);
    }

    protected function resourceRow(Model $item): array
    {
        /** @var Arazi $item */
        $existing = (float) Plot::where('arazi_id', $item->id)->sum('area');
        $saleableTotal = (float) $item->saleable_area;
        $remaining = $saleableTotal - $existing;
        if ($remaining < 0) $remaining = 0;

        return [
            'cells' => [
                $item->legacy_arazi_code ?? '-',
                $item->kisan?->name ?? '-',
                $item->location,
                (string) $item->size,
                $item->unit ?? '-',
                (string) ($item->road_area ?? 0),
                (string) $saleableTotal,
                (string) round($remaining, 2),
                ucfirst($item->status),
            ],
        ];
    }
}
