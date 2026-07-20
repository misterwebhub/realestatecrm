<?php

namespace App\Http\Controllers;

use App\Models\KisanRegistry;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Storage;

class KisanRegistryController extends Controller
{
    public function index(Request $request)
    {
        $deed = trim((string) $request->query('deed'));
        $araziCode = trim((string) $request->query('arazi_code'));

        $query = KisanRegistry::query();
        if ($deed !== '') {
            $query->where('arazi_deed_no', 'like', '%' . $deed . '%');
        }
        if ($araziCode !== '') {
            // filter records by their legacy arazi code
            $query->where('arazi_code', $araziCode);
        }

        $records = $query->with('arazi')->latest()->get();

        // Build a list of deed numbers for the dropdown (scoped to the selected arazi)
        $deedQuery = KisanRegistry::query()
            ->whereNotNull('arazi_deed_no')
            ->where('arazi_deed_no', '!=', '');
        if ($araziCode !== '') {
            $deedQuery->where('arazi_code', $araziCode);
        }
        $deeds = $deedQuery->orderBy('arazi_deed_no')
            ->pluck('arazi_deed_no')
            ->unique()
            ->values();

        // provide a unique list of arazi labels for the filter
        $araziList = \App\Models\Arazi::orderBy('legacy_arazi_code')->get();
        $unique = [];
        $araziMap = [];
        foreach ($araziList as $a) {
            $label = $a->araziNoCode();
            // value must be the legacy arazi code (used for filtering)
            if (! empty($a->legacy_arazi_code) && ! isset($unique[$a->legacy_arazi_code])) {
                $unique[$a->legacy_arazi_code] = $label;
            }

            // map possible keys to label for fast lookup in view
            if (! empty($a->legacy_arazi_code)) {
                $araziMap[$a->legacy_arazi_code] = $label;
            }
            if (! empty($a->plot_number)) {
                $araziMap[$a->plot_number] = $label;
            }
        }

        return view('kisan_registries.index', [
            'title'     => 'Kisan Registry',
            'records'   => $records,
            'createUrl' => route('kisan-registries.create'),
            'filter_deed' => $deed,
            'filter_arazi_code' => $araziCode,
            'arazis' => $unique,
            'arazi_map' => $araziMap,
            'deeds' => $deeds,
        ]);
    }

    public function create()
    {
        // Provide list of arazis to allow filtering kisans by selected arazi in the form
        $arazis = \App\Models\Arazi::orderBy('legacy_arazi_code')->get(['id', 'legacy_arazi_code', 'plot_number']);

        return view('kisan_registries.form', [
            'title'    => 'Add Kisan Registry',
            'action'   => route('kisan-registries.store'),
            'method'   => 'POST',
            'item'     => new KisanRegistry(),
            'arazis'   => $arazis,
            'partners' => \App\Models\Partner::orderBy('name')->get(['id', 'name']),
        ]);
    }

    public function store(Request $request)
    {
        $validated = $this->validateRequest($request, null);
        $validated = $this->handleFileUpload($request, $validated);

        $buyers = $this->extractBuyers($request);
        $validated['buy_by'] = $this->buyersSummary($buyers);

        $registry = KisanRegistry::create($validated);
        $this->syncBuyers($registry, $buyers);

        return redirect()->route('kisan-registries.index')
            ->with('success', 'Kisan Registry record created successfully.');
    }

    public function edit(KisanRegistry $kisanRegistry)
    {
        $arazis = \App\Models\Arazi::orderBy('legacy_arazi_code')->get(['id', 'legacy_arazi_code', 'plot_number']);

        $kisanRegistry->load('buyers');

        return view('kisan_registries.form', [
            'title'    => 'Edit Kisan Registry',
            'action'   => route('kisan-registries.update', $kisanRegistry),
            'method'   => 'PUT',
            'item'     => $kisanRegistry,
            'arazis'   => $arazis,
            'partners' => \App\Models\Partner::orderBy('name')->get(['id', 'name']),
        ]);
    }

    public function update(Request $request, KisanRegistry $kisanRegistry)
    {
        $validated = $this->validateRequest($request, $kisanRegistry);
        $validated = $this->handleFileUpload($request, $validated, $kisanRegistry);

        $buyers = $this->extractBuyers($request);
        $validated['buy_by'] = $this->buyersSummary($buyers);

        $kisanRegistry->update($validated);
        $this->syncBuyers($kisanRegistry, $buyers);

        return redirect()->route('kisan-registries.index')
            ->with('success', 'Kisan Registry record updated successfully.');
    }

    public function destroy(KisanRegistry $kisanRegistry)
    {
        if ($kisanRegistry->registry_file_path) {
            Storage::disk('public')->delete($kisanRegistry->registry_file_path);
        }
        $kisanRegistry->delete();

        return redirect()->route('kisan-registries.index')
            ->with('success', 'Record deleted.');
    }

    public function download(KisanRegistry $kisanRegistry)
    {
        if (! $kisanRegistry->registry_file_path) {
            abort(404, 'No file attached.');
        }

        $path = storage_path('app/public/' . $kisanRegistry->registry_file_path);

        if (! file_exists($path)) {
            abort(404, 'File not found.');
        }

        return response()->download($path, $kisanRegistry->registry_file_name ?? basename($path));
    }

    private function validateRequest(Request $request, ?KisanRegistry $existing = null): array
    {
        $fileRule = ($existing !== null) ? ['nullable', 'file', 'max:10240'] : ['required', 'file', 'max:10240'];

        $validated = $request->validate([
            'arazi_code'          => ['nullable', 'string', 'exists:arazis,legacy_arazi_code'],
            'arazi_deed_no'       => ['required', 'string', 'max:100'],
            'name_deed_no'        => ['required', 'string', 'max:100'],
            'sale_by'             => ['nullable', 'string', 'max:200'],
            'total_gaz'           => ['required', 'numeric', 'min:0'],
            'road_land_gaj'       => ['required', 'numeric', 'min:0'],
            'registry_date'       => ['required', 'date'],
            'stamp'               => ['required', 'numeric', 'min:0'],
            'registrar_fees'      => ['required', 'numeric', 'min:0'],
            'khasra'              => ['required', 'numeric', 'min:0'],
            'commission'          => ['required', 'numeric', 'min:0'],
            'brokari'             => ['required', 'numeric', 'min:0'],
            'broker_name'         => ['required', 'string', 'max:200'],
            'registry_file'       => $fileRule,
            'buyers'              => ['required', 'array', 'min:1'],
            'buyers.*.partner_id' => ['required', 'exists:partners,id'],
            'buyers.*.area'       => ['required', 'numeric', 'min:0.01'],
        ], [
            'buyers.required'            => 'Add at least one buyer.',
            'buyers.*.partner_id.required' => 'Select a partner for each buyer row.',
            'buyers.*.area.required'     => 'Enter an area for each buyer row.',
            'buyers.*.area.min'          => 'Buyer area must be greater than 0.',
        ]);

        // Buyer areas must not exceed saleable area (total_gaz - road_land_gaj).
        $saleable  = max((float) $validated['total_gaz'] - (float) $validated['road_land_gaj'], 0);
        $buyerSum  = collect($request->input('buyers', []))->sum(fn ($b) => (float) ($b['area'] ?? 0));

        if ($buyerSum > $saleable + 0.001) {
            throw \Illuminate\Validation\ValidationException::withMessages([
                'buyers' => sprintf(
                    'Total buyer area (%s gaz) cannot exceed saleable area of %s gaz (Total %s − Road %s).',
                    rtrim(rtrim(number_format($buyerSum, 2), '0'), '.'),
                    rtrim(rtrim(number_format($saleable, 2), '0'), '.'),
                    rtrim(rtrim(number_format((float) $validated['total_gaz'], 2), '0'), '.'),
                    rtrim(rtrim(number_format((float) $validated['road_land_gaj'], 2), '0'), '.')
                ),
            ]);
        }

        return $validated;
    }

    /**
     * Pull the repeating buyer rows out of the request, dropping empties.
     */
    private function extractBuyers(Request $request): array
    {
        return collect($request->input('buyers', []))
            ->filter(fn ($b) => ! empty($b['partner_id']))
            ->map(fn ($b) => [
                'partner_id' => (int) $b['partner_id'],
                'area'       => (float) ($b['area'] ?? 0),
            ])
            ->values()
            ->all();
    }

    /**
     * Replace this registry's buyer rows with the supplied list.
     */
    private function syncBuyers(KisanRegistry $registry, array $buyers): void
    {
        $registry->buyers()->delete();

        if (empty($buyers)) {
            return;
        }

        $names = \App\Models\Partner::whereIn('id', collect($buyers)->pluck('partner_id'))
            ->pluck('name', 'id');

        foreach ($buyers as $b) {
            $registry->buyers()->create([
                'partner_id'   => $b['partner_id'],
                'partner_name' => $names[$b['partner_id']] ?? null,
                'area'         => $b['area'],
            ]);
        }
    }

    /**
     * Build the "buy_by" summary string kept for the list view / backward compat.
     */
    private function buyersSummary(array $buyers): string
    {
        if (empty($buyers)) {
            return '';
        }

        $names = \App\Models\Partner::whereIn('id', collect($buyers)->pluck('partner_id'))
            ->pluck('name', 'id');

        return collect($buyers)
            ->map(fn ($b) => trim(($names[$b['partner_id']] ?? 'Partner') . ' (' . rtrim(rtrim(number_format($b['area'], 2), '0'), '.') . ' gaz)'))
            ->implode(', ');
    }

    private function handleFileUpload(Request $request, array $validated, ?KisanRegistry $existing = null): array
    {
        if ($request->hasFile('registry_file') && $request->file('registry_file')->isValid()) {
            // Delete old file if replacing
            if ($existing?->registry_file_path) {
                Storage::disk('public')->delete($existing->registry_file_path);
            }

            $file = $request->file('registry_file');
            $path = $file->store('kisan_registries', 'public');
            $validated['registry_file_path'] = $path;
            $validated['registry_file_name'] = $file->getClientOriginalName();
        }

        unset($validated['registry_file']);

        return $validated;
    }
}
