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
                'name' => 'arazi_code',
                'label' => 'Arazi',
                'type' => 'select',
                'options' => Arazi::orderBy('legacy_arazi_code')
                    ->get()
                    ->groupBy(function (Arazi $a) {
                        return $a->araziNoCode();
                    })
                    ->mapWithKeys(function ($group, $label) {
                        return [$label => $label];
                    })->all(),
                'value' => $item?->arazi_code,
            ],
            ['name' => 'title', 'label' => 'Plot No', 'type' => 'text', 'value' => $item?->title],
            ['name' => 'block', 'label' => 'Block', 'type' => 'text', 'value' => $item?->block],
            ['name' => 'area', 'label' => 'Area', 'type' => 'number', 'step' => '0.01', 'value' => $item?->area],
            ['name' => 'coordinates', 'label' => 'Coordinates', 'type' => 'text', 'value' => $item?->coordinates],
            ['name' => 'latitude', 'label' => 'Latitude', 'type' => 'number', 'step' => '0.000001', 'value' => $item?->latitude],
            ['name' => 'longitude', 'label' => 'Longitude', 'type' => 'number', 'step' => '0.000001', 'value' => $item?->longitude],
            ['name' => 'description', 'label' => 'Description', 'type' => 'textarea', 'value' => $item?->description],
            ['name' => 'status', 'label' => 'Status', 'type' => 'select', 'options' => [
                'available' => 'Available',
                'booked' => 'Booked',
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
            'arazi_code' => ['required', 'string', 'exists:arazis,legacy_arazi_code'],
            'title' => ['required', 'string', 'max:150'],
            'block' => ['nullable', 'string', 'max:20'],
            'area' => [
                'nullable',
                'numeric',
                'min:0',
                function ($attribute, $value, $fail) use ($item) {
                    $araziCode = request()->input('arazi_code');

                    if (!$araziCode) {
                        return;
                    }

                    $arazi = Arazi::where('legacy_arazi_code', $araziCode)->first();

                    if (!$arazi) {
                        return;
                    }

                    // if area is empty, skip the remaining checks
                    if ($value === null || $value === '') {
                        return;
                    }

                    $existing = \App\Models\Plot::where('arazi_code', $araziCode)
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
            'status' => ['required', 'in:available,booked,booked_advance,hold,registry,blacklist,not_for_sale,locked,sold'],
        ];
    }

    protected function resourceQuery()
    {
        return Plot::with('arazi')->latest();
    }

    public function index(\Illuminate\Http\Request $request)
    {
        $q = trim((string) $request->query('q', ''));

        $query = $this->resourceQuery();
        if ($q !== '') {
            $query->where(function($sub) use ($q) {
                $sub->where('title', 'like', '%' . $q . '%')
                    ->orWhere('id', $q)
                    ->orWhereHas('arazi', function($a) use ($q) {
                        $a->where('legacy_arazi_code', 'like', '%' . $q . '%')
                          ->orWhere('plot_number', 'like', '%' . $q . '%')
                          ->orWhere('location', 'like', '%' . $q . '%');
                    });
            });
        }

        $records = $query->get();
        $routeName = $this->resourceRouteName();

        $rows = $records->map(function (\Illuminate\Database\Eloquent\Model $record) use ($routeName) {
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
            'exportCsvUrl' => $this->allowsCsvExport() ? route($routeName.'.export.csv') : null,
            'showSearch' => true,
            'searchQuery' => $q,
            'searchInHeader' => true,
        ]);
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
