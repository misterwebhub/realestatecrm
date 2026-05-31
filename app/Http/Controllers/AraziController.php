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
            ['name' => 'no_of_plots', 'label' => 'Number of Plots (optional)', 'type' => 'number', 'step' => '1', 'value' => $item?->no_of_plots ?? 0, 'hidden' => true],
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
                // Duplicate arazi codes are allowed (same arazi from multiple kisans)
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
            'plots' => ['nullable', 'array'],
            'plots.*.plot_number' => ['required_with:plots', 'string', 'max:150'],
            'plots.*.area' => ['nullable', 'numeric', 'min:0'],
            'coordinates' => ['nullable', 'string', 'max:255'],
            'status' => ['required', 'in:available,booked_advance,registry,blacklist,not_for_sale'],
        ];
    }

    protected function resourceQuery()
    {
        return Arazi::with('kisan')->latest();
    }

    public function index(Request $request)
    {
        $q = trim((string) $request->query('q', ''));

        $query = Arazi::with('kisan')->latest();
        if ($q !== '') {
            $query->where(function($sub) use ($q) {
                $sub->where('legacy_arazi_code', 'like', '%'.$q.'%')
                    ->orWhere('plot_number', 'like', '%'.$q.'%')
                    ->orWhere('location', 'like', '%'.$q.'%')
                    ->orWhereHas('kisan', function($k) use ($q) { $k->where('name', 'like', '%'.$q.'%'); });
            });
        }

        $records = $query->get();

        // Group by legacy_arazi_code (same arazi can have multiple kisan purchases)
        $grouped = $records->groupBy(function (Arazi $a) {
            return $a->legacy_arazi_code ?: ('Arazi-' . $a->id);
        });

        $routeName = $this->resourceRouteName();

        $groups = $grouped->map(function ($group, $araziCode) use ($routeName) {
            $totalSize   = $group->sum('size');
            $totalRoad   = $group->sum('road_area');
            $isActive    = $group->contains(fn($a) => $a->status === 'available');
            $statusLabel = $isActive ? 'Active' : 'Inactive';
            $statusClass = $isActive ? 'success' : 'secondary';

            // compute per-group totals: total plots and total saleable area (in Gaz)
            $araziIds = $group->pluck('id')->all();
            $totalPlots = \App\Models\Plot::whereIn('arazi_id', $araziIds)->count();
            $groupSaleableGaz = 0.0;
            foreach ($group as $a) {
                $saleable = $a->saleable_area ?? null;
                if ($saleable === null) {
                    $size = (float) ($a->size ?? 0);
                    $road = (float) ($a->road_area ?? 0);
                    $saleable = max(0, $size - $road);
                }
                try {
                    $gaz = \App\Services\AreaConverter::toGaz((float)$saleable, $a->unit ?? 'gaz');
                } catch (\Throwable $e) {
                    $gaz = (float) $saleable;
                }
                $groupSaleableGaz += $gaz;
            }

            // Detail rows for popup (all records in this group)
            $details = $group->sortBy('id')->map(function (Arazi $a) use ($routeName) {
                return [
                    'id'               => $a->id,
                    'kisan'            => $a->kisan?->name ?? '-',
                    'location'         => $a->location,
                    'size'             => $a->size,
                    'unit'             => $a->unit ?? 'gaz',
                    'road_area'        => $a->road_area ?? 0,
                    'status'           => $a->status,
                    'status_label'     => in_array($a->status, ['available']) ? 'Active' : 'Inactive',
                    'status_class'     => in_array($a->status, ['available']) ? 'success' : 'secondary',
                    'edit_url'         => route($routeName . '.edit', $a),
                    'delete_url'       => route($routeName . '.destroy', $a),
                    'grid_url'         => route('arazis.grid', $a),
                ];
            })->values()->all();

            return [
                'arazi_code'   => $araziCode,
                'total_size'   => $totalSize,
                'total_road'   => $totalRoad,
                'total_plots'  => $totalPlots,
                'total_saleable_gaz' => $groupSaleableGaz,
                'count'        => $group->count(),
                'status_label' => $statusLabel,
                'status_class' => $statusClass,
                'details'      => $details,
            ];
        })->values()->all();

        // totals across the current result set
        $araziIds = $records->pluck('id')->all();
        $totalPlots = \App\Models\Plot::whereIn('arazi_id', $araziIds)->count();
        $totalSaleArea = 0.0;
        foreach ($records as $a) {
            $saleable = $a->saleable_area ?? null;
            if ($saleable === null) {
                $size = (float) ($a->size ?? 0);
                $road = (float) ($a->road_area ?? 0);
                $saleable = max(0, $size - $road);
            }
            try {
                $gaz = \App\Services\AreaConverter::toGaz((float)$saleable, $a->unit ?? 'gaz');
            } catch (\Throwable $e) {
                $gaz = (float) $saleable;
            }
            $totalSaleArea += $gaz;
        }

        return view('arazis.index', [
            'title'     => 'Arazi (Lands)',
            'groups'    => $groups,
            'createUrl' => route($routeName . '.create'),
            'totalPlots' => $totalPlots,
            'totalSaleArea' => $totalSaleArea,
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

    /**
     * Lookup an Arazi by legacy code or plot_number and return plots and arazi info.
     * GET /arazi/by-code?code=XXX
     */
    public function byCode(Request $request)
    {
        $code = trim((string) $request->query('code', ''));
        if ($code === '') {
            return response()->json(['found' => false]);
        }

        $araziQuery = Arazi::where('legacy_arazi_code', $code)->orWhere('plot_number', $code);
        $arazis = $araziQuery->get();
        if ($arazis->isEmpty()) {
            return response()->json(['found' => false]);
        }

        // If multiple arazis share same legacy code, return matches for client to choose
        if ($arazis->count() > 1) {
            $matches = $arazis->map(function (Arazi $a) {
                return [
                    'id' => $a->id,
                    'label' => $a->legacy_arazi_code ?: ($a->plot_number ?? ('Arazi-' . $a->id)),
                    'kisan' => $a->kisan?->name ?? null,
                    'location' => $a->location,
                    'size' => $a->size,
                    'unit' => $a->unit ?? 'gaz',
                    'road_area' => $a->road_area ?? 0,
                    'status' => $a->status,
                ];
            })->values()->all();

            return response()->json(['found' => true, 'matches' => $matches]);
        }

        $arazi = $arazis->first();

        // reuse plots() logic to prepare plot payload
        $plots = $arazi->plots()->get(['id', 'plot_number', 'title', 'block', 'area', 'description', 'status'])->map(function ($p) {
            $status = null;
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
                'area' => $p->area,
                'status' => $status,
            ];
        })->values();

        return response()->json([
            'found' => true,
            'arazi_id' => $arazi->id,
            'arazi_label' => $arazi->legacy_arazi_code ?: ($arazi->plot_number ?? ('Arazi-' . $arazi->id)),
            'plots' => $plots,
        ]);
    }

    /**
     * Return lightweight arazi info for AJAX forms.
     * Includes kisan name/id, sizes and saleable remaining in Gaz.
     */
    public function info(Arazi $arazi)
    {
        $saleableTotal = $arazi->saleable_area;
        $existing = (float) Plot::where('arazi_id', $arazi->id)->sum('area');
        $remaining = $saleableTotal - $existing;
        if ($remaining < 0) $remaining = 0;

        $unit = $arazi->unit ?? 'gaz';
        try {
            $remainingGaz = \App\Services\AreaConverter::toGaz($remaining, $unit);
            $totalGaz = \App\Services\AreaConverter::toGaz($saleableTotal, $unit);
        } catch (\Exception $e) {
            $remainingGaz = (float) $remaining;
            $totalGaz = (float) $saleableTotal;
        }

        return response()->json([
            'id' => $arazi->id,
            'legacy_arazi_code' => $arazi->legacy_arazi_code ?: ($arazi->plot_number ?? null),
            'kisan' => [
                'id' => $arazi->kisan?->id ?? null,
                'name' => $arazi->kisan?->name ?? null,
            ],
            'size' => (float) $arazi->size,
            'unit' => $unit,
            'road_area' => (float) ($arazi->road_area ?? 0),
            'saleable_total_gaz' => (float) $totalGaz,
            'remaining_gaz' => (float) round($remainingGaz, 2),
        ]);
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
            // Treat as 'issue' only when description mentions 'issue' or area is explicitly set and <= 0.
            if (str_contains($desc, 'issue') || (isset($p->area) && (float) $p->area <= 0)) {
                $status = 'issue'; // black
            }

            // Fallback to available if still null
            if ($status === null) $status = 'available';
            $status = 'available';
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

    protected function resourcePrepareData(array $validated, Request $request, ?Model $item = null): array
    {
        // remove plots and no_of_plots from payload so Arazi can be created without mass-assigning plots
        if (isset($validated['plots'])) unset($validated['plots']);
        if (isset($validated['no_of_plots'])) unset($validated['no_of_plots']);
        return $validated;
    }

    protected function resourceAfterSave(Model $item, Request $request, array $validated, ?Model $original = null): void
    {
        // handle creating plots submitted with the Arazi create form
        $plots = $request->input('plots');
        if (is_array($plots) && $item instanceof Arazi) {
            foreach ($plots as $p) {
                $plotNumber = trim($p['plot_number'] ?? '');
                if ($plotNumber === '') continue;
                $area = isset($p['area']) && $p['area'] !== '' ? (float) $p['area'] : null;
                Plot::create([
                    'arazi_id' => $item->id,
                    'plot_number' => $plotNumber,
                    'title' => $plotNumber,
                    'area' => $area,
                    'status' => 'available',
                ]);
            }
        }
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

    /**
     * Return customers who have purchased / hold bonds for this Arazi.
     * Used by autocomplete flows to show customer-specific purchases.
     */
    public function customers(Arazi $arazi)
    {
        $bonds = \App\Models\CustomerBond::with(['customer', 'plots'])
            ->where('arazi_id', $arazi->id)
            ->get();

        $grouped = $bonds->groupBy('customer_id')->map(function ($group, $customerId) {
            $first = $group->first();
            $customer = $first?->customer;
            $bondsArr = $group->map(function ($b) {
                return [
                    'id' => $b->id,
                    'bond_no' => $b->bond_no,
                    'plots' => $b->plots->map(fn($p) => ['id' => $p->id, 'plot_number' => $p->plot_number])->values()->all(),
                ];
            })->values()->all();

            return [
                'customer_id' => $customerId,
                'name' => $customer?->name ?? '-',
                'purchases' => $group->count(),
                'bonds' => $bondsArr,
            ];
        })->values()->all();

        return response()->json(['customers' => $grouped]);
    }

    /**
     * Return comprehensive details for an Arazi: basic info, plots, kisan bonds, customer bonds, and payments.
     */
    public function details(Arazi $arazi)
    {
        // basic info
        $basic = [
            'id' => $arazi->id,
            'legacy_arazi_code' => $arazi->legacy_arazi_code,
            'plot_number' => $arazi->plot_number,
            'location' => $arazi->location,
            'size' => $arazi->size,
            'unit' => $arazi->unit,
            'kisan' => $arazi->kisan ? ['id' => $arazi->kisan->id, 'name' => $arazi->kisan->name] : null,
            'status' => $arazi->status,
        ];

        // plots
        $plots = $arazi->plots()->get(['id','plot_number','area','status'])->map(function($p){
            return [
                'id' => $p->id,
                'plot_number' => $p->plot_number,
                'area' => $p->area,
                'status' => $p->status,
            ];
        })->values();

        // kisan bonds referencing this arazi
        $kisanBonds = \App\Models\KisanBond::whereHas('arazis', function($q) use ($arazi){ $q->where('arazi_id', $arazi->id); })
            ->with(['kisan','payments'])
            ->orderByDesc('bond_date')->get()->map(function($b) use ($arazi){
                $related = $b->arazis->firstWhere('id', $arazi->id);
                $pivot = $related?->pivot ?? null;
                return [
                    'id' => $b->id,
                    'bond_no' => $b->bond_no,
                    'bond_date' => optional($b->bond_date)->toDateString(),
                    'kisan' => $b->kisan ? ['id' => $b->kisan->id, 'name' => $b->kisan->name] : null,
                    'land_size' => $pivot->land_size ?? ($b->land_size ?? null),
                    'sale_amount' => $pivot->sale_amount ?? ($b->total_amount ?? $b->sale_amount ?? null),
                    'sale_rate' => $pivot->sale_rate ?? ($b->sale_rate ?? null),
                    'payments' => $b->payments->map(function($p){ return ['id'=>$p->id,'amount'=>$p->amount,'payment_date'=>optional($p->payment_date)->toDateString(),'payment_method'=>$p->payment_method,'notes'=>$p->notes,'kisan_bond_id'=>$p->kisan_bond_id]; })->values(),
                ];
            })->values();

        // customer bonds for this arazi
        $customerBonds = \App\Models\CustomerBond::with(['customer','payments','plots'])->where('arazi_id', $arazi->id)
            ->orderByDesc('bond_date')->get()->map(function($c){
                return [
                    'id' => $c->id,
                    'bond_no' => $c->bond_no,
                    'bond_date' => optional($c->bond_date)->toDateString(),
                    'customer' => $c->customer ? ['id'=>$c->customer->id,'name'=>$c->customer->name] : null,
                    'plots' => $c->plots->map(fn($p) => ['id'=>$p->id,'plot_number'=>$p->plot_number])->values(),
                    'total_amount' => $c->total_amount,
                    'payments' => $c->payments->map(function($p){ return ['id'=>$p->id,'amount'=>$p->amount,'entry_date'=>optional($p->entry_date)->toDateString(),'entry_no'=>$p->entry_no,'payment_method'=>$p->payment_method,'plot_id'=>$p->plot_id]; })->values(),
                ];
            })->values();

        // aggregate transactions: combine kisan bond payments and customer bond payments
        $transactions = [];
        foreach($kisanBonds as $kb){
            foreach($kb['payments'] as $pm){
                $transactions[] = array_merge($pm, ['source'=>'kisan_bond','bond_no'=>$kb['bond_no'],'party'=>$kb['kisan']['name'] ?? null]);
            }
        }
        foreach($customerBonds as $cb){
            foreach($cb['payments'] as $pm){
                $transactions[] = array_merge($pm, ['source'=>'customer_bond','bond_no'=>$cb['bond_no'],'party'=>$cb['customer']['name'] ?? null]);
            }
        }

        // sort transactions by date desc (payment_date or entry_date)
        usort($transactions, function($a,$b){
            $da = $a['payment_date'] ?? $a['entry_date'] ?? null;
            $db = $b['payment_date'] ?? $b['entry_date'] ?? null;
            if($da === $db) return 0;
            if(!$da) return 1;
            if(!$db) return -1;
            return $da < $db ? 1 : -1;
        });

        return response()->json([
            'arazi' => $basic,
            'plots' => $plots,
            'kisan_bonds' => $kisanBonds,
            'customer_bonds' => $customerBonds,
            'transactions' => $transactions,
        ]);
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
