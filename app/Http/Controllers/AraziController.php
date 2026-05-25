<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Arazi;
use App\Models\Kisan;
use App\Models\Plot;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;
use Illuminate\Validation\Rule;

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
        return ['Arazi Number', 'Kisan', 'Location', 'Size', 'Unit', 'Road Area', 'Sale ₹/Gaz', 'Saleable', 'Available', 'Status', 'Original Cost', 'Current Price', 'Current Price/ Gaz'];
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
            ['name' => 'sale_amount_per_gaz', 'label' => 'Sale amount per Gaz (₹)', 'type' => 'number', 'step' => '0.01', 'value' => $item?->sale_amount_per_gaz],
            ['name' => 'coordinates', 'label' => 'Coordinates', 'type' => 'text', 'value' => $item?->coordinates],
            ['name' => 'status', 'label' => 'Status', 'type' => 'select', 'options' => [
                'available' => 'Available',
                'booked_advance' => 'Booked (advance)',
                'registry' => 'Registry done',
                'blacklist' => 'Blacklist',
                'not_for_sale' => 'Not for sale',
            ], 'value' => $item?->status ?? 'available'],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'legacy_arazi_code' => [
                'nullable',
                'string',
                'max:50',
                Rule::unique('arazis', 'legacy_arazi_code')->ignore($item?->id),
            ],
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
            'sale_amount_per_gaz' => ['nullable', 'numeric', 'min:0'],
            'coordinates' => ['nullable', 'string', 'max:255'],
            'status' => ['required', 'in:available,booked_advance,registry,blacklist,not_for_sale'],
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
        $plots = $arazi->plots()->get(['id', 'plot_number', 'title', 'block', 'area', 'description', 'status'])->map(function ($p) {
            $status = null;

            // derive status similarly to grid() logic
            $dbStatus = strtolower((string) ($p->status ?? ''));
            $explicitStatuses = ['available','booked_advance','booked','hold','registry','blacklist','not_for_sale','issue'];
            if ($dbStatus !== '' && in_array($dbStatus, $explicitStatuses, true)) {
                $status = $dbStatus;
            }

            if ($status === null || $status === 'available') {
                $hasRegistry = \App\Models\Registry::where('plot_id', $p->id)
                    ->where(function($q){ $q->where('status', 'completed')->orWhere('payment_status', 'completed')->orWhereNull('status'); })
                    ->exists();

                if ($hasRegistry) {
                    $status = 'registry';
                } else {
                    $booking = \App\Models\Booking::where('plot_id', $p->id)
                        ->where(function($q){ $q->where('status', '!=', 'expired')->orWhereNull('status'); })
                        ->latest()->first();
                    if ($booking) {
                        $status = 'booked';
                    }
                }
            }

            $desc = strtolower((string) ($p->description ?? ''));
            if (str_contains($desc, 'issue') || empty($p->area) || (float) ($p->area ?? 0) <= 0) {
                $status = 'issue';
            }

            if ($status === null) $status = 'available';

            return [
                'id' => $p->id,
                'plot_number' => $p->plot_number ?? ($p->title ?? $p->id),
                'label' => $p->title ?? ($p->plot_number ?: ('Plot-' . $p->id)),
                'block' => $p->block,
                'area' => $p->area,
                'description' => $p->description,
                'status' => $status,
            ];
        })->values();

        return response()->json($plots);
    }

    public function grid(Arazi $arazi)
    {
        $plots = $arazi->plots()->get();

        $data = $plots->map(function ($p) {
            $status = null;

            // If an explicit status is set on the plot, prefer it (so user-set 'hold' shows immediately)
            $dbStatus = strtolower((string) ($p->status ?? ''));
            $explicitStatuses = ['available','booked_advance','booked','hold','registry','blacklist','not_for_sale','issue'];
            if ($dbStatus !== '' && in_array($dbStatus, $explicitStatuses, true)) {
                $status = $dbStatus;
            }

            // If no explicit status or it's 'available', compute derived status from registry/booking
            if ($status === null || $status === 'available') {
                // Prefer explicit Registry records: if a registry exists for this plot mark as 'registry'
                $hasRegistry = \App\Models\Registry::where('plot_id', $p->id)
                    ->where(function($q){ $q->where('status', 'completed')->orWhere('payment_status', 'completed')->orWhereNull('status'); })
                    ->exists();

                if ($hasRegistry) {
                    $status = 'registry'; // red
                } else {
                    // Check bookings: if booking exists with advance -> booked (green), else booked (yellow)
                    $booking = \App\Models\Booking::where('plot_id', $p->id)
                        ->where(function($q){ $q->where('status', '!=', 'expired')->orWhereNull('status'); })
                        ->latest()->first();
                    if ($booking) {
                        if ((float) ($booking->advance_amount ?? 0) > 0) {
                            $status = 'booked'; // green
                        } else {
                            $status = 'booked'; // green (treat booked variants the same in grid)
                        }
                    }
                }
            }

            // Detect explicit issues from plot fields and force 'issue'
            $desc = strtolower((string) ($p->description ?? ''));
            if (str_contains($desc, 'issue') || empty($p->area) || (float) ($p->area ?? 0) <= 0) {
                $status = 'issue'; // black
            }

            // Fallback to available if still null
            if ($status === null) $status = 'available';

            return [
                'id' => $p->id,
                'plot_number' => $p->plot_number ?? $p->title ?? ('Plot-' . $p->id),
                'title' => $p->title,
                'block' => $p->block,
                'area' => $p->area,
                'status' => $status,
            ];
        })->all();

        return view('arazis.grid', [
            'arazi' => $arazi,
            'plots' => $data,
        ]);
    }

    // Return a fragment of the Arazi create form suitable for insertion into a modal
    public function createFragment()
    {
        $modelClass = $this->resourceModel();

        $html = view('crud._form_fragment', [
            'title' => 'Create ' . $this->resourceTitle(),
            'action' => route('arazis.ajax-store'),
            'method' => 'POST',
            'fields' => $this->resourceFields(),
            'item' => new $modelClass(),
        ])->render();

        return response()->json(['html' => $html]);
    }

    // AJAX store used by create-in-modal flows
    public function storeAjax(Request $request)
    {
        $validated = $request->validate($this->resourceRules());
        $modelClass = $this->resourceModel();
        $payload = $this->resourcePrepareData($validated, $request);
        $item = $modelClass::create($payload);
        $this->resourceAfterSave($item, $request, $validated);

        $label = $item->legacy_arazi_code ?: ($item->plot_number ?? ('Arazi-' . $item->id));

        return response()->json(['success' => true, 'arazi' => ['id' => $item->id, 'label' => $label]]);
    }

    // Return bond/pivot info for this Arazi (latest bond that references it)
    public function bondInfo(Arazi $arazi)
    {
        try {
            $bond = \App\Models\KisanBond::whereHas('arazis', function($q) use ($arazi) { $q->where('arazi_id', $arazi->id); })
                ->orderByDesc('bond_date')->orderByDesc('id')->first();

            if (! $bond) {
                return response()->json(['found' => false]);
            }

            $related = $bond->arazis->firstWhere('id', $arazi->id);
            $pivot = $related?->pivot ?? null;

            return response()->json([
                'found' => true,
                'bond' => [
                    'id' => $bond->id,
                    'bond_no' => $bond->bond_no,
                    'bond_date' => optional($bond->bond_date)->toDateString(),
                    'sale_amount' => $bond->sale_amount ?? null,
                ],
                'pivot' => $pivot ? [
                    'sale_amount' => $pivot->sale_amount ?? null,
                    'sale_rate' => $pivot->sale_rate ?? null,
                    'land_size' => $pivot->land_size ?? null,
                ] : null,
            ]);
        } catch (\Throwable $e) {
            return response()->json(['found' => false]);
        }
    }

    protected function resourceRow(Model $item): array
    {
        /** @var Arazi $item */
        $existing = (float) Plot::where('arazi_id', $item->id)->sum('area');
        $saleableTotal = (float) $item->saleable_area;
        $remaining = $saleableTotal - $existing;
        if ($remaining < 0) $remaining = 0;
        $statusLabels = [
            'available' => 'Available',
            'booked_advance' => 'Booked (advance)',
            'registry' => 'Registry done',
            'blacklist' => 'Blacklist',
            'not_for_sale' => 'Not for sale',
            'booked' => 'Booked',
            'issue' => 'Issue',
        ];

        $label = $statusLabels[$item->status] ?? ucfirst(str_replace('_', ' ', (string) $item->status));

        // Prefer sale rate and original cost from most recent KisanBond pivot entry for this Arazi when available
        $bond = null;
        $bondSaleRate = null;
        $originalCost = null;
        try {
            $bond = \App\Models\KisanBond::whereHas('arazis', function($q) use ($item) { $q->where('arazi_id', $item->id); })
                ->orderByDesc('bond_date')->orderByDesc('id')->first();
            if ($bond) {
                $related = $bond->arazis->firstWhere('id', $item->id);
                $pivot = $related?->pivot ?? null;
                if ($pivot) {
                    // pivot may expose sale_rate (per gaz) or sale_amount (total) — prefer sale_rate for per-gaz
                    $bondSaleRate = $pivot->sale_rate ?? null;
                    if ($bondSaleRate === null && isset($pivot->sale_amount, $pivot->land_size) && (float)$pivot->land_size > 0) {
                        $bondSaleRate = (float)$pivot->sale_amount / (float)$pivot->land_size;
                    }

                    // original cost for this arazi in the bond (total amount allocated)
                    $originalCost = $pivot->sale_amount ?? null;
                }
            }
        } catch (\Throwable $e) {
            $bondSaleRate = null;
            $originalCost = null;
        }

        // fallback to bond-level fields if pivot wasn't present
        if ($originalCost === null && $bond?->sale_amount) {
            $originalCost = $bond->sale_amount;
        }

        $displaySaleRate = $bondSaleRate ?? ($item->sale_amount_per_gaz !== null ? (float) $item->sale_amount_per_gaz : null);

        // current price after expenses
        $currentPrice = (float) $item->price_after_expenses;
        $currentPricePerGaz = null;
        if (($item->saleable_area ?? 0) > 0) {
            $currentPricePerGaz = $currentPrice / (float) $item->saleable_area;
        } else {
            $currentPricePerGaz = $displaySaleRate !== null ? (float) $displaySaleRate : null;
        }

        return [
            'cells' => [
                $item->legacy_arazi_code ?? '-',
                $item->kisan?->name ?? '-',
                $item->location,
                (string) $item->size,
                $item->unit ?? '-',
                (string) ($item->road_area ?? 0),
                $displaySaleRate !== null ? number_format((float) $displaySaleRate, 2) : '-',
                (string) $saleableTotal,
                (string) round($remaining, 2),
                $label,
                $originalCost !== null ? number_format((float) $originalCost, 2) : '-',
                $currentPrice > 0 ? number_format($currentPrice, 2) : '-',
                $currentPricePerGaz !== null ? number_format((float) $currentPricePerGaz, 2) : '-',
            ],
            'action_buttons' => [
                ['url' => route('arazis.grid', $item), 'label' => 'View Plots', 'class' => 'btn-outline-primary'],
            ],
        ];
    }
}
