<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Arazi;
use App\Models\Agent;
use App\Models\Customer;
use App\Models\CustomerBond;
use App\Models\CustomerBondPayment;
use App\Models\Plot;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Validation\Rule;

class CustomerBondController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Customer Bond';
    }

    protected function resourceModel(): string
    {
        return CustomerBond::class;
    }

    protected function resourceRouteName(): string
    {
        return 'customer-bonds';
    }

    protected function resourceColumns(): array
    {
        return ['Bond No', 'Customer', 'Arazi', 'Bond Date', 'Amount'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            ['name' => 'bond_no', 'label' => 'Bond Number', 'type' => 'text', 'value' => $item?->bond_no],
            [
                'name' => 'customer_id',
                'label' => 'Customer',
                'type' => 'select',
                'options' => Customer::orderBy('name')->pluck('name', 'id')->all(),
                'value' => $item?->customer_id ?? request('customer_id'),
            ],
            [
                'name' => 'arazi_id',
                'label' => 'Arazi',
                'type' => 'select',
                'options' => Arazi::orderBy('plot_number')->pluck('plot_number', 'id')->all(),
                'value' => $item?->arazi_id,
            ],
            ['name' => 'bond_date', 'label' => 'Bond Date', 'type' => 'date', 'value' => optional($item?->bond_date)->format('Y-m-d')],
            ['name' => 'bond_amount', 'label' => 'Bond Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->bond_amount],
            // multiple witnesses: newline-separated textarea
            ['name' => 'witnesses', 'label' => 'Witnesses', 'type' => 'textarea', 'help' => 'One witness per line (name).', 'value' => $item ? implode("\n", $item->witnesses->pluck('name')->all()) : ''],
            ['name' => 'notes', 'label' => 'Notes', 'type' => 'textarea', 'value' => $item?->notes],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'bond_no' => ['nullable', 'string', 'max:50', Rule::unique('customer_bonds', 'bond_no')->ignore($item?->id)],
            'customer_id' => ['required', 'exists:customers,id'],
            'arazi_id' => ['required', 'exists:arazis,id'],
            'plot_ids' => ['nullable', 'array'],
            'plot_ids.*' => ['required', 'distinct', 'exists:plots,id', function ($attribute, $value, $fail) {
                $araziId = request()->input('arazi_id');

                if ($araziId && ! Plot::where('id', $value)->where('arazi_id', $araziId)->exists()) {
                    $fail('Selected plot does not belong to the selected Arazi.');
                }
            }],
            'plot_amounts' => ['nullable', 'array'],
            'plot_amounts.*' => ['nullable', 'numeric', 'min:0'],
            'bond_date' => ['required', 'date'],
            'bond_amount' => ['nullable', 'numeric', 'min:0'],
            'total_amount' => ['nullable', 'numeric', 'min:0'],
            'amount' => ['nullable', 'numeric', 'min:0'],
            'installment_amount' => ['nullable', 'integer', 'min:0', 'max:84'],
            'sale_rate' => ['nullable', 'numeric', 'min:0'],
            'sale_land' => ['nullable', 'numeric', 'min:0'],
            'broker_id' => ['nullable', 'exists:agents,id', function ($attribute, $value, $fail) {
                if ($value && ! Agent::where('id', $value)->where('broker_type', 'customer')->exists()) {
                    $fail('Selected broker must be a customer broker.');
                }
            }],
            'witnesses' => ['nullable', 'string'],
            'notes' => ['nullable', 'string'],
            // legacy form fields
            'bond_type' => ['nullable', 'string', 'max:100'],
            'bayana_mode' => ['nullable', 'string', 'max:50'],
            'last_date' => ['nullable', 'date'],
            'no_of_months' => ['nullable', 'integer', 'min:0', 'max:84'],
            'expiry_date' => ['nullable', 'date'],
            'land_size' => ['nullable', 'string', 'max:100'],
            'id_card_no' => ['nullable', 'string', 'max:100'],
            'customer_address' => ['nullable', 'string'],
            'nominee_details' => ['nullable', 'string'],
        ];
    }

    protected function resourcePrepareData(array $validated, \Illuminate\Http\Request $request, ?Model $item = null): array
    {
        $payload = $validated;
        $plotIds = array_values(array_filter($validated['plot_ids'] ?? []));

        $payload['bond_no'] = ($payload['bond_no'] ?? null) ?: $this->nextBondNumber();

        if (! empty($plotIds)) {
            $totalArea = Plot::whereIn('id', $plotIds)->sum('area');
            $payload['land_size'] = (string) $totalArea;
            $payload['sale_land'] = $totalArea;
            $payload['total_amount'] = collect($request->input('plot_amounts', []))
                ->only($plotIds)
                ->sum(fn ($amount) => (float) $amount);
        }

        if (empty($payload['bond_amount']) && isset($payload['total_amount'])) {
            $payload['bond_amount'] = $payload['total_amount'];
        }

        if (array_key_exists('installment_amount', $payload)) {
            $raw = $payload['installment_amount'];
            if ($raw === null || $raw === '') {
                $payload['no_of_months'] = null;
            } else {
                $months = min(84, max(0, (int) $raw));
                $payload['installment_amount'] = $months;
                $payload['no_of_months'] = $months;
            }
        }

        unset($payload['witnesses'], $payload['plot_ids'], $payload['plot_amounts']);

        return $payload;
    }

    protected function resourceAfterSave(Model $item, \Illuminate\Http\Request $request, array $validated, ?Model $original = null): void
    {
        $lines = isset($validated['witnesses']) ? preg_split('/\r\n|\r|\n/', trim($validated['witnesses'])) : [];
        $names = array_filter(array_map('trim', $lines));

        $item->witnesses()->delete();
        foreach ($names as $name) {
            if ($name === '') {
                continue;
            }
            $item->witnesses()->create([ 'name' => $name ]);
        }

        $plotIds = array_values(array_filter($validated['plot_ids'] ?? []));
        $plotAmounts = $request->input('plot_amounts', []);
        $syncData = collect($plotIds)
            ->mapWithKeys(fn ($plotId) => [
                $plotId => ['sale_amount' => isset($plotAmounts[$plotId]) ? (float) $plotAmounts[$plotId] : null],
            ])
            ->all();

        $item->plots()->sync($syncData);
        // Mark selected plots (or all plots for the arazi) as booked; do NOT change Arazi.status
        try {
            if (! empty($plotIds)) {
                Plot::whereIn('id', $plotIds)->update(['status' => 'booked']);
            } elseif (! empty($validated['arazi_id'])) {
                Plot::where('arazi_id', $validated['arazi_id'])->update(['status' => 'booked']);
            }
        } catch (\Throwable $e) {
            // Ignore to avoid breaking bond save flow
        }
        if ($original === null) {
            $this->createBookingAdvancePaymentIfApplicable($item);
        }
    }

    /**
     * Booking amount on the bond is recorded as an advance payment once (create only).
     */
    private function createBookingAdvancePaymentIfApplicable(CustomerBond $bond): void
    {
        $booking = (float) ($bond->amount ?? 0);
        if ($booking <= 0) {
            return;
        }

        $bond->loadMissing('plots');

        CustomerBondPayment::create([
            'customer_bond_id' => $bond->id,
            'customer_id' => $bond->customer_id,
            'arazi_id' => $bond->arazi_id,
            'plot_id' => $bond->plots->first()?->id,
            'entry_no' => $this->nextCustomerBondPaymentEntryNo(),
            'entry_date' => $bond->bond_date ?? now(),
            'entry_type' => 'advance',
            'amount' => $booking,
            'land_size' => $bond->land_size ?? $bond->sale_land,
            'payment_method' => $bond->bayana_mode ? ucfirst((string) $bond->bayana_mode) : null,
            'remarks' => 'Advance from booking amount at bond creation.',
        ]);
    }

    private function nextCustomerBondPaymentEntryNo(): string
    {
        $prefix = 'CP';
        $next = CustomerBondPayment::where('entry_no', 'like', $prefix.'%')
            ->pluck('entry_no')
            ->map(function ($entryNo) use ($prefix) {
                return preg_match('/^'.preg_quote($prefix, '/').'(\d+)$/', (string) $entryNo, $matches)
                    ? (int) $matches[1]
                    : 0;
            })
            ->max() + 1;

        do {
            $entryNo = $prefix.str_pad((string) $next, 5, '0', STR_PAD_LEFT);
            $next++;
        } while (CustomerBondPayment::where('entry_no', $entryNo)->exists());

        return $entryNo;
    }

    protected function resourceQuery()
    {
        return CustomerBond::with(['customer', 'arazi', 'plots', 'witnesses', 'broker'])->latest();
    }

    public function create()
    {
        $modelClass = $this->resourceModel();
        $item = new $modelClass([
            'bond_no' => $this->nextBondNumber(),
            'bond_date' => now(),
        ]);

        $customersList = \App\Models\Customer::orderBy('name')->get();
        $customers = $customersList->pluck('name', 'id')->all();
        $customerDetails = $customersList->mapWithKeys(fn ($customer) => [
            $customer->id => [
                'name' => $customer->name,
                'mobile' => $customer->mobile,
                'secondary_mobile' => $customer->secondary_mobile,
                'id_document_no' => $customer->id_document_no,
                'address' => $customer->address,
            ],
        ])->all();
        $arazis = \App\Models\Arazi::orderBy('id')->get()->mapWithKeys(function ($a) { return [$a->id => ($a->legacy_arazi_code ?: ($a->plot_number ?? ('Arazi-' . $a->id)))]; })->all();
        $agents = Agent::where('broker_type', 'customer')->orderBy('name')->pluck('name', 'id')->all();

        return view('customer_bonds.form_certificate', [
            'title' => 'Create ' . $this->resourceTitle(),
            'action' => route($this->resourceRouteName() . '.store'),
            'method' => 'POST',
            'item' => $item,
            'customers' => $customers,
            'customerDetails' => $customerDetails,
            'arazis' => $arazis,
            'agents' => $agents,
        ]);
    }

    public function edit($id)
    {
        $modelClass = $this->resourceModel();
        $item = $modelClass::with('plots')->findOrFail($id);

        $customersList = \App\Models\Customer::orderBy('name')->get();
        $customers = $customersList->pluck('name', 'id')->all();
        $customerDetails = $customersList->mapWithKeys(fn ($customer) => [
            $customer->id => [
                'name' => $customer->name,
                'mobile' => $customer->mobile,
                'secondary_mobile' => $customer->secondary_mobile,
                'id_document_no' => $customer->id_document_no,
                'address' => $customer->address,
            ],
        ])->all();
        $arazis = \App\Models\Arazi::orderBy('id')->get()->mapWithKeys(function ($a) { return [$a->id => ($a->legacy_arazi_code ?: ($a->plot_number ?? ('Arazi-' . $a->id)))]; })->all();
        $agents = Agent::where('broker_type', 'customer')->orderBy('name')->pluck('name', 'id')->all();

        return view('customer_bonds.form_certificate', [
            'title' => 'Edit ' . $this->resourceTitle(),
            'action' => route($this->resourceRouteName() . '.update', $item),
            'method' => 'PUT',
            'item' => $item,
            'customers' => $customers,
            'customerDetails' => $customerDetails,
            'arazis' => $arazis,
            'agents' => $agents,
        ]);
    }

    protected function resourceRow(Model $item): array
    {
        /** @var CustomerBond $item */
        return [
            'cells' => [
                $item->bond_no,
                $item->customer?->name ?? '-',
                $item->arazi?->plot_number ?? $item->arazi?->legacy_arazi_code ?? '-',
                optional($item->bond_date)->format('d-m-Y') ?? '-',
                number_format((float) $item->bond_amount, 2),
            ],
            'print_url' => route('customer-bonds.print', $item->id),
            'pdf_url' => route('customer-bonds.pdf', $item->id),
            // mark that links for this resource should open in a new tab
            'open_in_new_tab' => true,
        ];
    }

    /**
     * JSON for Customer Payment form: Arazi / plots / land size from bond (read-only on client).
     */
    public function paymentContext(CustomerBond $customer_bond)
    {
        $bond = $customer_bond->load(['arazi', 'plots']);

        $araziLabel = '-';
        if ($bond->arazi) {
            $araziLabel = $bond->arazi->legacy_arazi_code ?: ($bond->arazi->plot_number ?? ('Arazi-' . $bond->arazi_id));
        }

        $plots = $bond->plots->map(function ($p) {
            $lbl = $p->title ?? ('Plot-' . $p->id);

            return [
                'id' => $p->id,
                'label' => $lbl,
                'area' => $p->area,
            ];
        })->values();

        $plotSummary = $bond->plots->isEmpty()
            ? '-'
            : $bond->plots->map(function ($p) {
                $lbl = $p->title ?? ('Plot-' . $p->id);

                return $lbl.' / '.($p->area ?? '-').' gaz';
            })->implode('; ');

        $firstPlotId = $bond->plots->first()?->id;

        return response()->json([
            'arazi_id' => $bond->arazi_id,
            'arazi_label' => $araziLabel,
            'plots' => $plots,
            'plot_summary' => $plotSummary,
            'plot_id' => $firstPlotId,
            'land_size' => $bond->land_size ?? $bond->sale_land,
        ]);
    }

    public function print($id)
    {
        $bond = CustomerBond::with(['customer', 'arazi', 'plots', 'witnesses', 'broker'])->findOrFail($id);
        $lastPaymentDate = $bond->payments()->max('entry_date');

        return view('prints.customer_bond_certificate', [
            'title' => 'Customer Bond Certificate',
            'bond' => $bond,
            'lastPaymentDate' => $lastPaymentDate,
        ]);
    }

    public function pdf($id)
    {
        $bond = CustomerBond::with(['customer', 'arazi', 'plots', 'witnesses', 'broker'])->findOrFail($id);
        $lastPaymentDate = $bond->payments()->max('entry_date');
        $html = view('prints.customer_bond_certificate', [
            'title' => 'Customer Bond Certificate',
            'bond' => $bond,
            'lastPaymentDate' => $lastPaymentDate,
        ])->render();

        if (class_exists(\Barryvdh\DomPDF\Facade\Pdf::class)) {
            return \Barryvdh\DomPDF\Facade\Pdf::loadHTML($html)
                ->setPaper('a4', 'portrait')
                ->setOption('defaultFont', 'DejaVu Sans')
                ->setOption('isHtml5ParserEnabled', true)
                ->setOption('isRemoteEnabled', false)
                ->download('customer-bond-' . $bond->id . '.pdf');
        }

        return response($html)->header('Content-Type', 'text/html');
    }

    private function nextBondNumber(): string
    {
        $prefix = 'REGC';
        $next = CustomerBond::where('bond_no', 'like', $prefix . '%')
            ->pluck('bond_no')
            ->map(function ($bondNo) use ($prefix) {
                return preg_match('/^' . preg_quote($prefix, '/') . '(\d+)$/', (string) $bondNo, $matches)
                    ? (int) $matches[1]
                    : 0;
            })
            ->max() + 1;

        do {
            $bondNo = $prefix . str_pad((string) $next, 4, '0', STR_PAD_LEFT);
            $next++;
        } while (CustomerBond::where('bond_no', $bondNo)->exists());

        return $bondNo;
    }
}
