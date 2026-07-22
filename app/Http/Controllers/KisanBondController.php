<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Arazi;
use App\Models\Kisan;
use App\Models\KisanBond;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;
use Illuminate\Validation\Rule;

class KisanBondController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Kisan Bond';
    }

    protected function resourceModel(): string
    {
        return KisanBond::class;
    }

    protected function resourceRouteName(): string
    {
        return 'kisan-bonds';
    }

    protected function resourceColumns(): array
    {
        return ['Bond No', 'Kisan', 'Arazis', 'Bond Date', 'Amount'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            ['name' => 'bond_no', 'label' => 'Bond Number', 'type' => 'text', 'value' => $item?->bond_no],
            [
                'name' => 'kisan_id',
                'label' => 'Kisan',
                'type' => 'select',
                'options' => Kisan::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $item?->kisan_id ?? request('kisan_id'),
            ],
            [
                'name' => 'arazi_ids',
                'label' => 'Arazis',
                'type' => 'multiselect',
                'help' => 'Hold Ctrl and select multiple Arazis.',
                'options' => (function() use ($item) {
                    $q = Arazi::query();
                    $kisanId = $item?->kisan_id ?? request('kisan_id') ?? request()->route('kisan')?->id;
                    if ($kisanId) {
                        $q->where('kisan_id', $kisanId);
                    }

                    return $q->orderBy('legacy_arazi_code')
                        ->get()
                        ->mapWithKeys(function ($a) { return [$a->id => $a->araziNoCode()]; })
                        ->all();
                })(),
                'value' => $item?->exists
                    ? ($item->arazis->pluck('id')->all() ?: array_filter([$item->arazi_id]))
                    : [],
                'size' => 8,
            ],
            ['name' => 'bond_date', 'label' => 'Bond Date', 'type' => 'date', 'value' => optional($item?->bond_date)->format('Y-m-d')],
            ['name' => 'bond_amount', 'label' => 'Bond Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->bond_amount],
            ['name' => 'mobile', 'label' => 'Mobile', 'type' => 'text', 'value' => $item?->mobile],
            ['name' => 'land_size', 'label' => 'Land Size', 'type' => 'text', 'value' => $item?->land_size],
            ['name' => 'sale_land', 'label' => 'Sale Land', 'type' => 'number', 'step' => '0.01', 'value' => $item?->sale_land],
            ['name' => 'sale_rate', 'label' => 'Sale Rate', 'type' => 'number', 'step' => '0.01', 'value' => $item?->sale_rate],
            ['name' => 'total_amount', 'label' => 'Total Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->total_amount],
            ['name' => 'bayana_mode', 'label' => 'Bayana Mode', 'type' => 'select', 'options' => ['cash' => 'Cash', 'cheque' => 'Cheque'], 'value' => $item?->bayana_mode],
            ['name' => 'bond_type', 'label' => 'Type', 'type' => 'text', 'value' => $item?->bond_type],
            ['name' => 'amount', 'label' => 'Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->amount],
            ['name' => 'balance', 'label' => 'Balance', 'type' => 'number', 'step' => '0.01', 'value' => $item?->balance],
            ['name' => 'last_date', 'label' => 'Last Date', 'type' => 'date', 'value' => optional($item?->last_date)->format('Y-m-d')],
            [
                'name' => 'broker_id',
                'label' => 'Broker',
                'type' => 'select',
                'options' => \App\Models\Agent::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $item?->broker_id,
            ],
            ['name' => 'broker_payment', 'label' => 'Broker Payment', 'type' => 'number', 'step' => '0.01', 'value' => $item?->broker_payment],
            ['name' => 'broker_paid', 'label' => 'Broker Paid', 'type' => 'number', 'step' => '0.01', 'value' => $item?->broker_paid],
            ['name' => 'broker_balance', 'label' => 'Broker Balance', 'type' => 'number', 'step' => '0.01', 'value' => $item?->broker_balance],
            ['name' => 'broker_comment', 'label' => 'Broker Comment', 'type' => 'textarea', 'value' => $item?->broker_comment],
            ['name' => 'kisan_comment', 'label' => 'Kisan Comment', 'type' => 'textarea', 'value' => $item?->kisan_comment],
            // multiple witnesses: provide newline-separated textarea
            ['name' => 'witnesses', 'label' => 'Witnesses', 'type' => 'textarea', 'help' => 'One witness per line (name).', 'value' => $item ? implode("\n", $item->witnesses->pluck('name')->all()) : ''],
            ['name' => 'notes', 'label' => 'Notes', 'type' => 'textarea', 'value' => $item?->notes],
        ];
    }

    public function create()
    {
        $this->authorizeCrud('create');

        $item = new KisanBond([
            'bond_no' => $this->nextBondNumber(),
            'kisan_id' => request('kisan_id'),
            'bond_date' => now(),
        ]);

        return view('kisan_bonds.form', $this->formData($item, 'Create Kisan Bond', route('kisan-bonds.store'), 'POST'));
    }

    public function edit($id)
    {
        $item = KisanBond::with(['arazis', 'witnesses'])->findOrFail($id);
        $this->authorizeOwnership($item);
        $this->authorizeCrud('edit', $item);

        return view('kisan_bonds.form', $this->formData($item, 'Edit Kisan Bond', route('kisan-bonds.update', $item), 'PUT'));
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'bond_no' => ['nullable', 'string', 'max:50', Rule::unique('kisan_bonds', 'bond_no')->ignore($item?->id)],
            'kisan_id' => ['required', 'exists:kisans,id'],
            'arazi_items' => ['required', 'array', 'min:1'],
            'arazi_items.*.arazi_id' => ['required', 'distinct', 'exists:arazis,id', function ($attribute, $value, $fail) {
                $kisanId = request()->input('kisan_id');

                if ($kisanId && ! Arazi::where('id', $value)->where('kisan_id', $kisanId)->exists()) {
                    $fail('Selected Arazi does not belong to the selected Kisan.');
                }
            }],
            'arazi_items.*.land_size' => ['nullable', 'numeric', 'min:0'],
            'arazi_items.*.sale_land' => ['required', 'numeric', 'min:0', function ($attribute, $value, $fail) {
                $index = explode('.', $attribute)[1] ?? null;
                $araziId = $index !== null ? request()->input("arazi_items.$index.arazi_id") : null;
                $arazi = $araziId ? Arazi::find($araziId) : null;

                if ($arazi && (float) $value > (float) $arazi->saleable_area) {
                    $fail('Sale land cannot be greater than available saleable area for selected Arazi.');
                }
            }],
            'arazi_items.*.sale_rate' => ['required', 'numeric', 'min:0'],
            'arazi_items.*.sale_amount' => ['nullable', 'numeric', 'min:0'],
            'bond_date' => ['required', 'date'],
            'bond_amount' => ['nullable', 'numeric', 'min:0'],
            'mobile' => ['nullable', 'string', 'max:30'],
            'land_size' => ['nullable', 'string', 'max:60'],
            'sale_land' => ['nullable', 'numeric'],
            'sale_rate' => ['nullable', 'numeric'],
            'total_amount' => ['nullable', 'numeric'],
            'bayana_mode' => ['nullable', Rule::in(['cash', 'cheque'])],
            'bond_type' => ['nullable', 'string', 'max:100'],
            'amount' => ['nullable', 'numeric'],
            'balance' => ['nullable', 'numeric'],
            'last_date' => ['nullable', 'date'],
            'broker_id' => ['nullable', 'exists:agents,id'],
            'broker_payment' => ['nullable', 'numeric'],
            'broker_paid' => ['nullable', 'numeric'],
            'broker_balance' => ['nullable', 'numeric'],
            'broker_comment' => ['nullable', 'string'],
            'kisan_comment' => ['nullable', 'string'],
            'witnesses' => ['nullable', 'string'],
            'notes' => ['nullable', 'string'],
        ];
    }

    protected function resourcePrepareData(array $validated, \Illuminate\Http\Request $request, ?Model $item = null): array
    {
        // remove witnesses from payload; we'll handle separately
        $payload = $validated;
        $araziItems = $this->normaliseAraziItems($validated['arazi_items'] ?? []);
        $firstItem = $araziItems[0] ?? null;
        $totalLandSize = collect($araziItems)->sum('land_size');
        $totalSaleLand = collect($araziItems)->sum('sale_land');
        $totalAmount = collect($araziItems)->sum('sale_amount');

        $payload['bond_no'] = ($payload['bond_no'] ?? null) ?: $this->nextBondNumber();
        $payload['arazi_id'] = $firstItem['arazi_id'] ?? $item?->arazi_id;
        $payload['land_size'] = (string) round($totalLandSize, 2);
        $payload['sale_land'] = round($totalSaleLand, 2);
        $payload['sale_rate'] = $firstItem['sale_rate'] ?? ($validated['sale_rate'] ?? 0);
        $payload['total_amount'] = round($totalAmount, 2);
        $payload['bond_amount'] = $payload['bond_amount'] ?? round($totalAmount, 2);

        if (! isset($payload['balance']) && isset($payload['amount'])) {
            $payload['balance'] = max(round($totalAmount - (float) $payload['amount'], 2), 0);
        }

        unset($payload['witnesses'], $payload['arazi_items']);

        return $payload;
    }

    protected function resourceAfterSave(Model $item, \Illuminate\Http\Request $request, array $validated, ?Model $original = null): void
    {
        // parse witnesses textarea (one per line) and sync to witnesses table
        $lines = isset($validated['witnesses']) ? preg_split('/\r\n|\r|\n/', trim($validated['witnesses'])) : [];
        $names = array_filter(array_map('trim', $lines));

        // delete existing and recreate — simple sync for demo
        $item->witnesses()->delete();
        foreach ($names as $name) {
            if ($name === '') {
                continue;
            }

            $item->witnesses()->create([
                'name' => $name,
            ]);
        }

        $syncData = [];
        foreach ($this->normaliseAraziItems($validated['arazi_items'] ?? []) as $araziItem) {
            $syncData[$araziItem['arazi_id']] = [
                'arazi_code' => \App\Models\Arazi::whereKey($araziItem['arazi_id'])->value('legacy_arazi_code'),
                'land_size' => $araziItem['land_size'],
                'sale_land' => $araziItem['sale_land'],
                'sale_rate' => $araziItem['sale_rate'],
                'sale_amount' => $araziItem['sale_amount'],
            ];
        }

        $item->arazis()->sync($syncData);
    }

    protected function resourceQuery()
    {
        return $this->applyOwnershipScope(KisanBond::with(['kisan', 'arazi', 'arazis'])->latest());
    }

    public function index(Request $request)
    {
        $q         = trim((string) $request->input('q', ''));
        $araziCode = trim((string) $request->input('arazi_code', ''));

        $query = $this->applyOwnershipScope(KisanBond::with(['kisan', 'arazi', 'arazis'])->latest());

        // Search by kisan name or mobile
        if ($q !== '') {
            $query->where(function ($qb) use ($q) {
                $qb->whereHas('kisan', fn($k) =>
                    $k->where('name', 'like', '%'.$q.'%')
                      ->orWhere('mobile', 'like', '%'.$q.'%')
                );
            });
        }

        // Search by arazi legacy code (direct column or pivot)
        if ($araziCode !== '') {
            $query->where(function ($qb) use ($araziCode) {
                $qb->where('arazi_code', $araziCode)
                   ->orWhereHas('arazis', fn($a) => $a->where('kisan_bond_arazi.arazi_code', $araziCode));
            });
        }

        $records   = $query->get();
        $routeName = $this->resourceRouteName();

        $rows = $records->map(function (KisanBond $item) use ($routeName) {
            return array_merge($this->resourceRow($item), [
                'edit_url'   => route($routeName . '.edit', $item),
                'delete_url' => route($routeName . '.destroy', $item),
            ]);
        })->all();

        return view('crud.index', [
            'title'           => $this->resourceTitle(),
            'columns'         => $this->resourceColumns(),
            'rows'            => $rows,
            'createUrl'       => route($routeName . '.create'),
            'exportCsvUrl'    => $this->allowsCsvExport() ? route($routeName . '.export.csv') : null,
            'isKisanBondIndex'=> true,
            'kb_q'            => $q,
            'kb_arazi'        => $araziCode,
        ]);
    }

    protected function resourceRow(Model $item): array
    {
        /** @var KisanBond $item */
        return [
            'cells' => [
                $item->bond_no,
                $item->kisan?->name ?? '-',
                $item->arazis->isNotEmpty()
                    ? $item->arazis->map(fn (Arazi $arazi) => $arazi->araziNoCode())->join(', ')
                    : ($item->arazi?->legacy_arazi_code ?: ($item->arazi?->plot_number ?? '-')),
                optional($item->bond_date)->format('d-m-Y') ?? '-',
                number_format((float) $item->bond_amount, 2),
            ],
            'print_url' => route('kisan-bonds.print', $item->id),
            'pdf_url' => route('kisan-bonds.pdf', $item->id),
        ];
    }

    public function print($id)
    {
        $bond = KisanBond::with(['kisan', 'arazi', 'arazis', 'witnesses', 'broker'])->findOrFail($id);
        $this->authorizeOwnership($bond);

        return view('prints.bond', [
            'title' => 'Kisan Bond',
            'bond' => $bond,
        ]);
    }

    public function pdf($id)
    {
        $bond = KisanBond::with(['kisan', 'arazi', 'arazis', 'witnesses', 'broker'])->findOrFail($id);
        $this->authorizeOwnership($bond);
        $html = view('prints.bond', ['title' => 'Kisan Bond', 'bond' => $bond])->render();

        if (class_exists(\Barryvdh\DomPDF\Facade\Pdf::class)) {
            $pdf = \Barryvdh\DomPDF\Facade\Pdf::loadHTML($html);
            return $pdf->download('kisan-bond-' . $bond->id . '.pdf');
        }

        return response($html)->header('Content-Type', 'text/html');
    }

    private function formData(KisanBond $item, string $title, string $action, string $method): array
    {
        return [
            'title' => $title,
            'action' => $action,
            'method' => $method,
            'item' => $item,
            'kisans' => Kisan::orderBy('name')->pluck('name', 'id')->all(),
            'agents' => \App\Models\Agent::where('broker_type', 'kisan')->orderBy('name')->pluck('name', 'id')->all(),
            'selectedArazis' => $item->exists
                ? $item->arazis->map(function (Arazi $arazi) {
                    return [
                        'id' => $arazi->id,
                        'label' => $arazi->araziNoCode(),
                        'location' => $arazi->location,
                        'land_size' => (float) ($arazi->pivot->land_size ?? $arazi->size ?? 0),
                        'sale_land' => (float) ($arazi->pivot->sale_land ?? $arazi->saleable_area ?? 0),
                        'sale_rate' => (float) ($arazi->pivot->sale_rate ?? $item->sale_rate ?? 0),
                        'sale_amount' => (float) ($arazi->pivot->sale_amount ?? 0),
                        'unit' => $arazi->unit ?? 'gaz',
                    ];
                })->values()->all()
                : [],
        ];
    }

    private function normaliseAraziItems(array $items): array
    {
        return collect($items)
            ->filter(fn ($item) => ! empty($item['arazi_id']))
            ->map(function ($item) {
                $saleLand = (float) ($item['sale_land'] ?? 0);
                $saleRate = (float) ($item['sale_rate'] ?? 0);

                return [
                    'arazi_id' => (int) $item['arazi_id'],
                    'land_size' => (float) ($item['land_size'] ?? 0),
                    'sale_land' => $saleLand,
                    'sale_rate' => $saleRate,
                    'sale_amount' => round((float) ($item['sale_amount'] ?? ($saleLand * $saleRate)), 2),
                ];
            })
            ->values()
            ->all();
    }

    private function nextBondNumber(): string
    {
        $prefix = 'REGK';
        $next = KisanBond::where('bond_no', 'like', $prefix . '%')
            ->pluck('bond_no')
            ->map(function ($bondNo) use ($prefix) {
                return preg_match('/^' . preg_quote($prefix, '/') . '(\d+)$/', (string) $bondNo, $matches)
                    ? (int) $matches[1]
                    : 0;
            })
            ->max() + 1;

        do {
            $bondNo = $prefix . str_pad((string) $next, 5, '0', STR_PAD_LEFT);
            $next++;
        } while (KisanBond::where('bond_no', $bondNo)->exists());

        return $bondNo;
    }
}
