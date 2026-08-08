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

    // Shared inventory (land parcels) — visible to every user, not owner-scoped.
    protected function ownershipColumn(): ?string
    {
        return null;
    }

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
                    ->orWhere('location', 'like', '%'.$q.'%')
                    ->orWhereHas('kisan', function($k) use ($q) { $k->where('name', 'like', '%'.$q.'%'); });
            });
        }

        $records = $query->get();

        // Group by legacy_arazi_code (same arazi can have multiple kisan purchases)
        $grouped = $records->groupBy(function (Arazi $a) {
            return $a->araziNoCode();
        });

        $routeName = $this->resourceRouteName();

        $groups = $grouped->map(function ($group, $araziCode) use ($routeName) {
            $totalSize   = $group->sum('size');
            $totalRoad   = $group->sum('road_area');
            $isActive    = $group->contains(fn($a) => $a->status === 'available');
            $statusLabel = $isActive ? 'Active' : 'Inactive';
            $statusClass = $isActive ? 'success' : 'secondary';

            // compute per-group totals: total plots and total saleable area (in Gaz)
            $totalPlots = \App\Models\Plot::where('arazi_code', $araziCode)->count();
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
                // A bond created against this Arazi (or one of its plots) blocks deletion.
                $hasBonds = false;
                if ($a->legacy_arazi_code) {
                    $hasBonds = \App\Models\CustomerBond::where('arazi_code', $a->legacy_arazi_code)->exists();
                }

                // Plots existing against this Arazi block deletion (remove plots first).
                $hasPlots = \App\Models\Plot::where('arazi_id', $a->id)
                    ->when($a->legacy_arazi_code, fn ($q) => $q->orWhere('arazi_code', $a->legacy_arazi_code))
                    ->exists();

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
                    'has_bonds'        => $hasBonds,
                    'has_plots'        => $hasPlots,
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
        $araziCodes = $records->pluck('legacy_arazi_code')->filter()->unique()->all();
        $totalPlots = \App\Models\Plot::whereIn('arazi_code', $araziCodes)->count();
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
        $existing = (float) Plot::where('arazi_code', $arazi->legacy_arazi_code)->sum('area');
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
        $plots = $this->decoratePlots(Arazi::plotsForCode($arazi->araziNoCode()));

        return response()->json($plots);
    }

    /**
     * All plots for every Arazi record sharing the given "Arazi No" code
     * (legacy_arazi_code, falling back to plot_number).
     * GET /arazi-no/{code}/plots
     */
    public function plotsByAraziNo(string $code)
    {
        $arazis = Arazi::arazisForCode($code);
        if ($arazis->isEmpty()) {
            return response()->json(['found' => false, 'plots' => []]);
        }

        $plots = Arazi::plotsForCode($code);

        // Payment creation asks for only the plots that belong to a bond the
        // current user created. Non-admins are then limited to their own deals;
        // Super Admin keeps seeing every plot for the arazi.
        $user = auth()->user();
        if (request()->boolean('only_my_bonds') && $user && ! $user->isSuperAdmin()) {
            $ownBondPlotIds = \Illuminate\Support\Facades\DB::table('customer_bond_plot')
                ->join('customer_bonds', 'customer_bonds.id', '=', 'customer_bond_plot.customer_bond_id')
                ->where('customer_bonds.created_by', $user->getKey())
                ->pluck('customer_bond_plot.plot_id')
                ->all();

            $plots = $plots->whereIn('id', $ownBondPlotIds)->values();
        }

        $plots = $this->decoratePlots($plots);

        return response()->json([
            'found' => true,
            'arazi_code' => $code,
            'plots' => $plots,
        ]);
    }

    /**
     * Saleable area summary for an Arazi code (aggregated across all rows sharing the code).
     * GET /arazi-code/{code}/saleable
     */
    public function saleableByCode(string $code)
    {
        $arazis = Arazi::where('legacy_arazi_code', $code)->get();
        if ($arazis->isEmpty()) {
            return response()->json(['remaining' => 0, 'remaining_gaz' => 0, 'unit' => 'gaz']);
        }

        $arazi = $arazis->first();
        $saleableTotal = (float) ($arazi->saleable_area ?? 0);
        $existing = (float) Plot::where('arazi_code', $code)->sum('area');
        $remaining = max(0, $saleableTotal - $existing);

        $unit = $arazi->unit ?? 'gaz';
        try {
            $saleableGaz = \App\Services\AreaConverter::toGaz($remaining, $unit);
        } catch (\Exception $e) {
            $saleableGaz = $remaining;
        }

        return response()->json([
            'saleable_total' => $saleableTotal,
            'existing'       => $existing,
            'remaining'      => round($remaining, 2),
            'unit'           => $unit,
            'remaining_gaz'  => round($saleableGaz, 2),
            'saleable_gaz'   => round($saleableGaz, 2),
        ]);
    }

    /**
     * Derive a display status for each plot and shape the payload for plot pickers.
     */
    private function decoratePlots(\Illuminate\Support\Collection $plots): \Illuminate\Support\Collection
    {
        return $plots->map(function ($p) {
            $status = null;

            // derive status similarly to grid() logic
            $dbStatus = strtolower((string) ($p->status ?? ''));
            $dbStatus = str_replace(['-',' '], '_', $dbStatus);
            $dbStatus = str_replace('adwance', 'advance', $dbStatus);
            $explicitStatuses = ['available','booked_advance','booked','hold','registry','blacklist','not_for_sale','issue'];
            if ($dbStatus !== '' && in_array($dbStatus, $explicitStatuses, true)) {
                $status = $dbStatus;
            }

            if ($status === null || $status === 'available') {
                $hasRegistry = \App\Models\Registry::forPlot($p->id)
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
            // Only treat as an issue when the description says so, or the area is
            // explicitly set to <= 0. A blank/null area (e.g. plots created via the
            // Arazi form without an area) should stay 'available', not become 'issue'.
            if (str_contains($desc, 'issue') || (isset($p->area) && $p->area !== '' && (float) $p->area <= 0)) {
                $status = 'issue';
            }

            if ($status === null) $status = 'available';

            return [
                'id' => $p->id,
                'plot_number' => $p->title ?? $p->id,
                'label' => $p->title ?? ('Plot-' . $p->id),
                'block' => $p->block,
                'area' => $p->area,
                'description' => $p->description,
                'status' => $status,
            ];
        })->values();
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

        $araziQuery = Arazi::where('legacy_arazi_code', $code)
            ->with(['kisan', 'deedMapping.partner', 'deedMergingItem.deedMerging.partner']);
        $arazis = $araziQuery->get();
        if ($arazis->isEmpty()) {
            return response()->json(['found' => false]);
        }

        // If multiple arazis share same legacy code, return matches for client to choose
        if ($arazis->count() > 1) {
            $matches = $arazis->map(function (Arazi $a) {
                return array_merge([
                    'id' => $a->id,
                    'arazi_code' => $a->legacy_arazi_code,
                    'label' => $a->araziNoCode(),
                    'kisan' => $a->kisan?->name ?? null,
                    'location' => $a->location,
                    'size' => $a->size,
                    'unit' => $a->unit ?? 'gaz',
                    'road_area' => $a->road_area ?? 0,
                    'status' => $a->status,
                ], $this->deedInfoFor($a));
            })->values()->all();

            return response()->json(['found' => true, 'matches' => $matches]);
        }

        $arazi = $arazis->first();

        // gather plots across every Arazi record sharing this Arazi No code
        $plots = $this->decoratePlots(Arazi::plotsForCode($arazi->araziNoCode()));

        return response()->json(array_merge([
            'found' => true,
            'arazi_id' => $arazi->id,
            'arazi_code' => $arazi->legacy_arazi_code,
            'arazi_label' => $arazi->araziNoCode(),
            'plots' => $plots,
        ], $this->deedInfoFor($arazi)));
    }

    /**
     * Deed Mapping / Deed Merging info for a single Arazi row (i.e. one
     * kisan's share): the plain mapped Deed No + Partner, and — if that row
     * has since been folded into a persisted merge — the merged Deed No and
     * the partner every merged row resolved to (which supersedes the plain
     * mapping's partner for that row).
     */
    private function deedInfoFor(Arazi $arazi): array
    {
        $mapping = $arazi->deedMapping;
        $merge   = $arazi->deedMergingItem?->deedMerging;

        return [
            'deed_no'        => $mapping?->deed_no,
            'merged_deed_no' => $merge?->merged_deed_no,
            'partner_id'     => $merge?->partner_id ?? $mapping?->partner_id,
            'partner_name'   => $merge?->partner?->name ?? $mapping?->partner?->name,
        ];
    }

    /**
     * Return lightweight arazi info for AJAX forms.
     * Includes kisan name/id, sizes and saleable remaining in Gaz.
     */
    public function info(Arazi $arazi)
    {
        $arazi->loadMissing(['kisan', 'deedMapping.partner', 'deedMergingItem.deedMerging.partner']);

        $saleableTotal = $arazi->saleable_area;
        $existing = (float) Plot::where('arazi_code', $arazi->legacy_arazi_code)->sum('area');
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

        return response()->json(array_merge([
            'id' => $arazi->id,
            'legacy_arazi_code' => $arazi->legacy_arazi_code,
            'kisan' => [
                'id' => $arazi->kisan?->id ?? null,
                'name' => $arazi->kisan?->name ?? null,
            ],
            'size' => (float) $arazi->size,
            'unit' => $unit,
            'road_area' => (float) ($arazi->road_area ?? 0),
            'saleable_total_gaz' => (float) $totalGaz,
            'remaining_gaz' => (float) round($remainingGaz, 2),
        ], $this->deedInfoFor($arazi)));
    }

    public function grid(Arazi $arazi)
    {
        $plots = $arazi->plots()->get();

        $data = $plots->map(function ($p) {
            $status = null;

            // If an explicit status is set on the plot, prefer it (so user-set 'hold' shows immediately)
            $dbStatus = strtolower((string) ($p->status ?? ''));
            $dbStatus = str_replace(['-',' '], '_', $dbStatus);
            $dbStatus = str_replace('adwance', 'advance', $dbStatus);
            $explicitStatuses = ['available','booked_advance','booked','hold','registry','blacklist','not_for_sale','issue'];
            if ($dbStatus !== '' && in_array($dbStatus, $explicitStatuses, true)) {
                $status = $dbStatus;
            }

            // If no explicit status or it's 'available', compute derived status from registry/booking
            if ($status === null || $status === 'available') {
                // Prefer explicit Registry records: if a registry exists for this plot mark as 'registry'
                $hasRegistry = \App\Models\Registry::forPlot($p->id)
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
            return [
                'id' => $p->id,
                'plot_number' => $p->title ?? ('Plot-' . $p->id),
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
        // status field removed from the form; keep DB column valid on new records
        if (! $item && empty($validated['status'])) {
            $validated['status'] = 'available';
        }
        return $validated;
    }

    /**
     * Block deleting an Arazi while any bond exists against it (FK / data safety).
     */
    public function destroy($id)
    {
        $this->authorizeCrud('delete');
        $arazi = Arazi::findOrFail($id);

        $code = $arazi->legacy_arazi_code;

        // Block deletion while a bond exists against this Arazi.
        if ($code && \App\Models\CustomerBond::where('arazi_code', $code)->exists()) {
            return redirect()
                ->route($this->resourceRouteName() . '.index')
                ->with('error', 'Cannot delete this Arazi: a bond has been created against it. Remove the related bond(s) first.');
        }

        // Block deletion while a registry exists against this Arazi (by FK or legacy code).
        $hasRegistry = \App\Models\Registry::where('arazi_id', $arazi->id)
            ->when($code, fn ($q) => $q->orWhere('arazi_code', $code))
            ->exists();
        if ($hasRegistry) {
            return redirect()
                ->route($this->resourceRouteName() . '.index')
                ->with('error', 'Cannot delete this Arazi: a registry exists against it. Remove the related registry first.');
        }

        // Only allow removing an Arazi that has no plots. If plots exist,
        // they must be removed first.
        $hasPlots = Plot::where('arazi_id', $arazi->id)
            ->when($code, fn ($q) => $q->orWhere('arazi_code', $code))
            ->exists();
        if ($hasPlots) {
            return redirect()
                ->route($this->resourceRouteName() . '.index')
                ->with('error', 'Cannot delete this Arazi: plots exist against it. Remove all its plots first.');
        }

        $arazi->delete();

        return redirect()
            ->route($this->resourceRouteName() . '.index')
            ->with('success', $this->resourceTitle() . ' deleted successfully.');
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
                    'arazi_code' => $item->legacy_arazi_code,
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

        $label = $item->araziNoCode();

        return response()->json(['success' => true, 'arazi' => ['id' => $item->id, 'label' => $label]]);
    }

    // Return bond/pivot info for this Arazi (latest bond that references it)
    public function bondInfo(Arazi $arazi)
    {
        try {
            $bond = \App\Models\KisanBond::whereHas('arazis', function($q) use ($arazi) { $q->where('kisan_bond_arazi.arazi_code', $arazi->legacy_arazi_code); })
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
            ->where('arazi_code', $arazi->legacy_arazi_code)
            ->get();

        $grouped = $bonds->groupBy('customer_id')->map(function ($group, $customerId) {
            $first = $group->first();
            $customer = $first?->customer;
            $bondsArr = $group->map(function ($b) {
                return [
                    'id' => $b->id,
                    'bond_no' => $b->bond_no,
                    'plots' => $b->plots->map(fn($p) => ['id' => $p->id, 'plot_number' => $p->title])->values()->all(),
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
     * Flexible grid entrypoint: accepts numeric Arazi id or legacy arazi code / plot_number.
     * If identifier matches an existing Arazi id, behaves like grid(Arazi).
     * If identifier matches a legacy_arazi_code or plot_number shared by multiple records,
     * aggregates plots across the group and renders the same grid view.
     */
    public function gridByIdentifier($identifier)
    {
        // Prefer lookup by legacy_arazi_code, falling back to plot_number (so numeric codes like "319" match code)
        $arazis = Arazi::arazisForCode((string) $identifier);

        // If no matches by code/plot_number, fall back to numeric id lookup
        if ($arazis->isEmpty() && is_numeric($identifier)) {
            $arazi = Arazi::find((int) $identifier);
            if ($arazi) {
                return $this->grid($arazi);
            }
            abort(404);
        }

        if ($arazis->isEmpty()) {
            abort(404);
        }

        // collect plots across every Arazi record sharing this Arazi No code
        $plots = $this->decoratePlots(Arazi::plotsForCode((string) $identifier))->all();

        // Pass a representative arazi object (first) but adjust label to identifier
        $representative = $arazis->first();
        $representative->legacy_arazi_code = $identifier;

        return view('arazis.grid', [
            'arazi' => $representative,
            'plots' => $plots,
        ]);
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
            'location' => $arazi->location,
            'size' => $arazi->size,
            'unit' => $arazi->unit,
            'kisan' => $arazi->kisan ? ['id' => $arazi->kisan->id, 'name' => $arazi->kisan->name] : null,
            'status' => $arazi->status,
        ];

        // plots
        $plots = $arazi->plots()->get(['id','title','area','status'])->map(function($p){
            return [
                'id' => $p->id,
                'plot_number' => $p->title,
                'area' => $p->area,
                'status' => $p->status,
            ];
        })->values();

        // kisan bonds referencing this arazi
        $kisanBonds = \App\Models\KisanBond::whereHas('arazis', function($q) use ($arazi){ $q->where('kisan_bond_arazi.arazi_code', $arazi->legacy_arazi_code); })
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
        $customerBonds = \App\Models\CustomerBond::with(['customer','payments','plots'])->where('arazi_code', $arazi->legacy_arazi_code)
            ->orderByDesc('bond_date')->get()->map(function($c){
                return [
                    'id' => $c->id,
                    'bond_no' => $c->bond_no,
                    'bond_date' => optional($c->bond_date)->toDateString(),
                    'customer' => $c->customer ? ['id'=>$c->customer->id,'name'=>$c->customer->name] : null,
                    'plots' => $c->plots->map(fn($p) => ['id'=>$p->id,'plot_number'=>$p->title])->values(),
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

    /**
     * Same as details() but keyed by the human-readable Arazi code
     * (legacy_arazi_code, falling back to plot_number) instead of the id.
     * GET /arazi-no/{code}/details
     */
    public function detailsByAraziNo(string $code)
    {
        $arazi = Arazi::where('legacy_arazi_code', $code)->first();

        if (! $arazi) {
            return response()->json(['found' => false], 404);
        }

        return $this->details($arazi);
    }

    protected function resourceRow(Model $item): array
    {
        /** @var Arazi $item */
        $existing = (float) Plot::where('arazi_code', $item->legacy_arazi_code)->sum('area');
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
            $bond = \App\Models\KisanBond::whereHas('arazis', function($q) use ($item) { $q->where('kisan_bond_arazi.arazi_code', $item->legacy_arazi_code); })
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
                $displaySaleRate !== null ? inr((float) $displaySaleRate, 2) : '-',
                (string) $saleableTotal,
                (string) round($remaining, 2),
                $label,
                $originalCost !== null ? inr((float) $originalCost, 2) : '-',
                $currentPrice > 0 ? inr($currentPrice, 2) : '-',
                $currentPricePerGaz !== null ? inr((float) $currentPricePerGaz, 2) : '-',
            ],
            'action_buttons' => [
                ['url' => route('arazis.grid', $item), 'label' => 'View Plots', 'class' => 'btn-outline-primary'],
            ],
        ];
    }
}
