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
            // filter records whose deed contains the selected arazi code
            $query->where('arazi_deed_no', 'like', '%' . $araziCode . '%');
        }

        $records = $query->with('arazi')->latest()->get();

        // provide a unique list of arazi labels for the filter
        $araziList = \App\Models\Arazi::orderBy('id')->get();
        $unique = [];
        $araziMap = [];
        foreach ($araziList as $a) {
            $label = $a->araziNoCode();
            if (! isset($unique[$label])) {
                $unique[$label] = $label; // use label as value
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
        ]);
    }

    public function create()
    {
        // Provide list of arazis to allow filtering kisans by selected arazi in the form
        $arazis = \App\Models\Arazi::orderBy('legacy_arazi_code')->get(['id', 'legacy_arazi_code', 'plot_number']);

        return view('kisan_registries.form', [
            'title'  => 'Add Kisan Registry',
            'action' => route('kisan-registries.store'),
            'method' => 'POST',
            'item'   => new KisanRegistry(),
            'arazis' => $arazis,
        ]);
    }

    public function store(Request $request)
    {
        $validated = $this->validateRequest($request, null);
        $validated = $this->handleFileUpload($request, $validated);

        KisanRegistry::create($validated);

        return redirect()->route('kisan-registries.index')
            ->with('success', 'Kisan Registry record created successfully.');
    }

    public function edit(KisanRegistry $kisanRegistry)
    {
        $arazis = \App\Models\Arazi::orderBy('legacy_arazi_code')->get(['id', 'legacy_arazi_code', 'plot_number']);

        return view('kisan_registries.form', [
            'title'  => 'Edit Kisan Registry',
            'action' => route('kisan-registries.update', $kisanRegistry),
            'method' => 'PUT',
            'item'   => $kisanRegistry,
            'arazis' => $arazis,
        ]);
    }

    public function update(Request $request, KisanRegistry $kisanRegistry)
    {
        $validated = $this->validateRequest($request, $kisanRegistry);
        $validated = $this->handleFileUpload($request, $validated, $kisanRegistry);

        $kisanRegistry->update($validated);

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

        return $request->validate([
            'arazi_id'       => ['nullable', 'integer', 'exists:arazis,id'],
            'arazi_deed_no'  => ['required', 'string', 'max:100'],
            'name_deed_no'   => ['required', 'string', 'max:100'],
            'sale_by'        => ['nullable', 'string', 'max:200'],
            'buy_by'         => ['required', 'string', 'max:200'],
            'total_gaz'      => ['required', 'numeric', 'min:0'],
            'road_land_gaj'  => ['required', 'numeric', 'min:0'],
            'registry_date'  => ['required', 'date'],
            'stamp'          => ['required', 'numeric', 'min:0'],
            'registrar_fees' => ['required', 'numeric', 'min:0'],
            'khasra'         => ['required', 'numeric', 'min:0'],
            'commission'     => ['required', 'numeric', 'min:0'],
            'brokari'        => ['required', 'numeric', 'min:0'],
            'broker_name'    => ['required', 'string', 'max:200'],
            'registry_file'  => $fileRule,
        ]);
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
