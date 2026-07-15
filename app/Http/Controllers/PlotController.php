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
        $registryExists = $item && \App\Models\Registry::where('plot_id', $item->id)->exists();
        // When the plot's status is 'registry', lock all detail fields except status.
        $detailsLocked = $item && $item->status === 'registry';
        $lockNote = $detailsLocked ? ' (locked — registry done)' : '';

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
                'readonly' => $detailsLocked,
            ],
            ['name' => 'title', 'label' => 'Plot No' . $lockNote, 'type' => 'text', 'value' => $item?->title, 'readonly' => $detailsLocked],
            ['name' => 'block', 'label' => 'Block', 'type' => 'text', 'value' => $item?->block, 'readonly' => $detailsLocked],
            [
                'name' => 'area',
                'label' => 'Area' . ($detailsLocked || $registryExists ? ' (locked — registry done)' : ''),
                'type' => 'number',
                'step' => '0.01',
                'value' => $item?->area,
                'readonly' => $detailsLocked || $registryExists,
            ],
            ['name' => 'coordinates', 'label' => 'Coordinates', 'type' => 'text', 'value' => $item?->coordinates, 'readonly' => $detailsLocked],
            ['name' => 'latitude', 'label' => 'Latitude', 'type' => 'number', 'step' => '0.000001', 'value' => $item?->latitude, 'readonly' => $detailsLocked],
            ['name' => 'longitude', 'label' => 'Longitude', 'type' => 'number', 'step' => '0.000001', 'value' => $item?->longitude, 'readonly' => $detailsLocked],
            ['name' => 'description', 'label' => 'Description', 'type' => 'textarea', 'value' => $item?->description, 'readonly' => $detailsLocked],
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

                    // Skip validation if area hasn't changed (editing without changing area)
                    if ($item && $item->area == $value) {
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

    protected function resourcePrepareData(array $validated, \Illuminate\Http\Request $request, ?Model $item = null): array
    {
        // When the existing plot's status is 'registry', all detail fields are locked.
        // Only the status field may change — preserve the original values for everything else,
        // even if a client bypassed the disabled inputs.
        if ($item && $item->status === 'registry') {
            foreach (['arazi_code', 'title', 'block', 'area', 'coordinates', 'latitude', 'longitude', 'description'] as $field) {
                $validated[$field] = $item->getOriginal($field);
            }
        }

        // Auto-fill plot_number from the title when it's empty, so the arazi
        // map (which can match tiles by plot_number) always has a fallback.
        if (empty($validated['plot_number'] ?? null) && !empty($validated['title'] ?? null)) {
            $validated['plot_number'] = $validated['title'];
        }

        return $validated;
    }

    protected function resourceQuery()
    {
        return Plot::with('arazi')->latest();
    }

    public function index(\Illuminate\Http\Request $request)
    {
        $q = trim((string) $request->query('q', ''));
        $filterArazi = trim((string) $request->query('arazi_code', ''));
        $filterPlotId = trim((string) $request->query('plot_id', ''));

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

        if ($filterArazi !== '') {
            $query->where('arazi_code', $filterArazi);
        }
        if ($filterPlotId !== '') {
            $query->where('id', $filterPlotId);
        }

        // Arazi options for the filter dropdown (unique legacy codes)
        $araziOptions = Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '!=', '')
            ->orderBy('legacy_arazi_code')
            ->get()
            ->groupBy('legacy_arazi_code')
            ->mapWithKeys(function ($group, $code) {
                $first = $group->first();
                $label = $first->araziNoCode() ?: $code;
                return [$code => $label];
            })->all();

        // Plots belonging to the currently selected arazi (for the dependent dropdown)
        $filterPlots = [];
        if ($filterArazi !== '') {
            $filterPlots = Plot::where('arazi_code', $filterArazi)
                ->orderBy('title')
                ->get(['id', 'title', 'block'])
                ->map(function (Plot $p) {
                    $label = $p->title ?: ('Plot #' . $p->id);
                    if ($p->block) {
                        $label .= ' (Block ' . $p->block . ')';
                    }
                    return ['id' => $p->id, 'label' => $label];
                })->all();
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
            'showSearch' => false,
            'searchQuery' => $q,
            'searchInHeader' => false,
            'permModule' => $this->resourcePermModule(),
            'isPlotIndex' => true,
            'araziOptions' => $araziOptions,
            'filterArazi' => $filterArazi,
            'filterPlotId' => $filterPlotId,
            'filterPlots' => $filterPlots,
            'plotsByCodeBase' => url('arazi-no'),
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
