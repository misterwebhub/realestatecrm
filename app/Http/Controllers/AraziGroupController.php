<?php

namespace App\Http\Controllers;

use App\Models\Arazi;
use App\Models\AraziGroup;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\DB;

class AraziGroupController extends Controller
{
    /**
     * List map folder names available under the project `arazis-map` directory.
     */
    protected function mapNames(): array
    {
        $base = base_path('arazis-map');
        $names = [];

        if (is_dir($base)) {
            foreach (scandir($base) as $item) {
                if ($item === '.' || $item === '..') {
                    continue;
                }
                if (in_array($item, ['assets', 'arazis-assets'], true)) {
                    continue;
                }
                // skip archives / backup folders
                if (str_ends_with(strtolower($item), '.zip') || str_ends_with($item, '-old')) {
                    continue;
                }
                if (! is_dir($base . DIRECTORY_SEPARATOR . $item)) {
                    continue;
                }
                $names[] = $item;
            }
        }

        usort($names, function ($a, $b) {
            if (is_numeric($a) && is_numeric($b)) {
                return (int) $a <=> (int) $b;
            }

            return strnatcmp($a, $b);
        });

        return $names;
    }

    public function index()
    {
        $groups = AraziGroup::with(['arazis', 'creator'])
            ->withCount('items')
            ->latest()
            ->get();

        return view('arazi_groups.index', [
            'title'  => 'Arazi Groups',
            'groups' => $groups,
        ]);
    }

    public function create()
    {
        $arazis = Arazi::orderBy('legacy_arazi_code')
            ->get(['id', 'legacy_arazi_code', 'location', 'size']);

        return view('arazi_groups.create', [
            'title'    => 'Create Arazi Group',
            'mapNames' => $this->mapNames(),
            'arazis'   => $arazis,
        ]);
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'name'       => ['nullable', 'string', 'max:150'],
            'map_name'   => ['required', 'string', 'max:150'],
            'notes'      => ['nullable', 'string', 'max:2000'],
            'arazi_ids'  => ['required', 'array', 'min:2'],
            'arazi_ids.*'=> ['integer', 'exists:arazis,id'],
        ], [
            'arazi_ids.required' => 'Please select at least two arazis to merge.',
            'arazi_ids.min'      => 'Please select at least two arazis to merge.',
        ]);

        DB::transaction(function () use ($validated) {
            $group = AraziGroup::create([
                'name'       => $validated['name'] ?? null,
                'map_name'   => $validated['map_name'],
                'notes'      => $validated['notes'] ?? null,
                'created_by' => Auth::id(),
            ]);

            $ids = array_values(array_unique(array_map('intval', $validated['arazi_ids'])));
            $group->arazis()->sync($ids);
        });

        return redirect()
            ->route('arazi-groups.index')
            ->with('success', 'Arazi group created successfully.');
    }

    public function destroy($id)
    {
        $group = AraziGroup::findOrFail($id);
        $group->items()->delete();
        $group->delete();

        return redirect()
            ->route('arazi-groups.index')
            ->with('success', 'Arazi group deleted successfully.');
    }
}
