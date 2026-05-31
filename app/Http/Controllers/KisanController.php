<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Kisan;
use App\Models\Arazi;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;
use Illuminate\Validation\Rule;

class KisanController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Kisan';
    }

    protected function resourceModel(): string
    {
        return Kisan::class;
    }

    protected function resourceRouteName(): string
    {
        return 'kisans';
    }

    protected function resourceColumns(): array
    {
        return ['Reg. No.', 'Kishan Name', 'Location', 'Mobile'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            ['name' => 'reg_no', 'label' => 'Reg. No.', 'type' => (($item && ($item->exists ?? false)) ? 'text' : 'hidden'), 'value' => $item?->reg_no],
            ['name' => 'name', 'label' => 'Kishan Name', 'type' => 'text', 'value' => $item?->name],
            ['name' => 'location', 'label' => 'Location', 'type' => 'text', 'value' => $item?->location],
            ['name' => 'mobile', 'label' => 'Mobile', 'type' => 'text', 'value' => $item?->mobile],
            ['name' => 'address', 'label' => 'Address', 'type' => 'text', 'value' => $item?->address],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'reg_no' => array_merge(
                $item ? ['required'] : ['nullable'],
                ['string', 'max:40', Rule::unique('kisans', 'reg_no')->ignore($item?->id)]
            ),
            'name' => ['required', 'string', 'max:150'],
            'location' => ['required', 'string', 'max:255'],
            'mobile' => ['required', 'string', 'max:20'],
            'address' => ['required', 'string', 'max:255'],
        ];
    }

    protected function resourcePrepareData(array $validated, Request $request, ?Model $item = null): array
    {
        if ($item === null) {
            $validated['reg_no'] = $this->generateNextKisanRegNo();
        }

        return $validated;
    }

    /**
     * Next registration number (e.g. K00001). Based on highest existing id + 1.
     */
    private function generateNextKisanRegNo(): string
    {
        $next = (int) (Kisan::query()->max('id') ?? 0) + 1;

        return 'K'.str_pad((string) $next, 5, '0', STR_PAD_LEFT);
    }

    public function create()
    {
        $modelClass = $this->resourceModel();

        return view('kisans.form', [
            'title' => 'KISHAN REGISTRATION FORM',
            'action' => route($this->resourceRouteName() . '.store'),
            'method' => 'POST',
            'fields' => $this->resourceFields(),
            'item' => new $modelClass(),
            'nextRegNo' => $this->generateNextKisanRegNo(),
        ]);
    }

    public function edit($id)
    {
        $modelClass = $this->resourceModel();
        $item = $modelClass::findOrFail($id);

        return view('kisans.form', [
            'title' => 'EDIT KISHAN REGISTRATION',
            'action' => route($this->resourceRouteName() . '.update', $item),
            'method' => 'PUT',
            'fields' => $this->resourceFields($item),
            'item' => $item,
            'nextRegNo' => null,
        ]);
    }

    protected function resourceQuery()
    {
        return Kisan::withCount('arazis')->latest();
    }

    protected function resourceRow(Model $item): array
    {
        /** @var Kisan $item */
        return [
            'cells' => [
                $item->reg_no ?? '-',
                $item->name,
                $item->location ?? '-',
                $item->mobile,
            ],
            'add_url' => route('kisan-bonds.create') . '?kisan_id=' . $item->id,
            'action_buttons' => [
                [
                    'label' => 'Kisan Ledger',
                    'url' => route('kisan-payment.ledger', ['kisan_id' => $item->id]),
                    'class' => 'btn-outline-info',
                ],
                [
                    'label' => 'Kisan Payment',
                    'url' => route('kisan-payment.create', ['kisan_id' => $item->id]),
                    'class' => 'btn-outline-success',
                ],
            ],
        ];
    }

    public function arazis(Kisan $kisan)
    {
        $list = $kisan->arazis()
            ->where('status', 'available')
            ->get(['id', 'legacy_arazi_code', 'plot_number', 'location', 'size', 'unit', 'road_area', 'status'])
            ->map(function ($a) {
            return [
                'id' => $a->id,
                'label' => $a->legacy_arazi_code ?: ($a->plot_number ?: ('Arazi-' . $a->id)),
                'location' => $a->location,
                'land_size' => (float) ($a->size ?? 0),
                'sale_land' => (float) ($a->saleable_area ?? $a->size ?? 0),
                'unit' => $a->unit ?? 'gaz',
            ];
        })->values();

        return response()->json($list);
    }

    // Return a fragment of the Kisan create form suitable for insertion into a modal
    public function createFragment()
    {
        $modelClass = $this->resourceModel();

        $html = view('crud._form_fragment', [
            'title' => 'Create ' . $this->resourceTitle(),
            'action' => route('kisans.ajax-store'),
            'method' => 'POST',
            'fields' => $this->resourceFields(),
            'item' => new $modelClass(),
        ])->render();

        return response()->json(['html' => $html]);
    }

    // AJAX store used by create-in-modal flows for Kisan
    public function storeAjax(Request $request)
    {
        $validated = $request->validate($this->resourceRules());
        $modelClass = $this->resourceModel();
        $payload = $this->resourcePrepareData($validated, $request);
        $item = $modelClass::create($payload);
        $this->resourceAfterSave($item, $request, $validated);

        $label = $item->name ?? ($item->reg_no ?? ('Kisan-' . $item->id));

        return response()->json(['success' => true, 'kisan' => ['id' => $item->id, 'label' => $label]]);
    }

    public function bonds(Kisan $kisan)
    {
        $list = $kisan->bonds()
            ->latest()
            ->get(['id', 'bond_no', 'bond_date', 'bond_amount', 'total_amount'])
            ->map(function ($bond) {
                return [
                    'id' => $bond->id,
                    'label' => $bond->bond_no . ' - ' . number_format((float) ($bond->total_amount ?? $bond->bond_amount ?? 0), 2),
                ];
            })
            ->values();

        return response()->json($list);
    }

    // Return kisans related to a given arazi id (used by AJAX in forms)
    public function byArazi(Request $request)
    {
        $araziId = $request->query('arazi_id');

        if (! $araziId) {
            return response()->json([]);
        }

        $arazi = Arazi::find($araziId);
        if (! $arazi) {
            return response()->json([]);
        }

        $kisan = $arazi->kisan;
        if (! $kisan) {
            return response()->json([]);
        }

        $list = [
            [
                'id' => $kisan->id,
                'reg_no' => $kisan->reg_no,
                'name' => $kisan->name,
            ],
        ];

        return response()->json($list);
    }
}

