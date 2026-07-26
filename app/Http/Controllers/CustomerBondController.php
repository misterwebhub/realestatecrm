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
        return ['Bond No', 'Customer', 'Arazi', 'Plots', 'Bond Date', 'Amount', 'Paid', 'Balance'];
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
                'name' => 'arazi_code',
                'label' => 'Arazi',
                'type' => 'select',
                'options' => Arazi::whereNotNull('legacy_arazi_code')->where('legacy_arazi_code', '<>', '')
                    ->orderBy('legacy_arazi_code')->pluck('legacy_arazi_code')->unique()
                    ->mapWithKeys(fn($c) => [$c => $c])->all(),
                'value' => $item?->arazi_code,
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
            'arazi_code' => ['required', function ($attribute, $value, $fail) {
                if (Arazi::arazisForCode((string) $value)->isEmpty()) {
                    $fail('Selected Arazi No is invalid.');
                }
            }],
            'plot_ids' => ['nullable', 'array'],
            'plot_ids.*' => ['required', 'distinct', 'exists:plots,id', function ($attribute, $value, $fail) use ($item) {
                $plots = Arazi::plotsForCode((string) request()->input('arazi_code'));

                if ($plots->isNotEmpty() && ! $plots->contains('id', (int) $value)) {
                    $fail('Selected plot does not belong to the selected Arazi.');
                    return;
                }

                $plot = Plot::find($value);
                if (! $plot) {
                    return;
                }

                // Plots on hold or blacklisted must never be attached to a bond,
                // regardless of which bond is submitting the request.
                $status = strtolower((string) ($plot->status ?? ''));
                if (in_array($status, ['hold', 'blacklist'], true)) {
                    $fail('Plot "' . ($plot->title ?? $plot->id) . '" is ' . $status . ' and cannot be booked.');
                    return;
                }

                // A plot must not be booked under more than one bond. When editing
                // a bond, its own existing plot rows are excluded from this check.
                $duplicate = \Illuminate\Support\Facades\DB::table('customer_bond_plot')
                    ->join('customer_bonds', 'customer_bonds.id', '=', 'customer_bond_plot.customer_bond_id')
                    ->where('customer_bond_plot.plot_id', $value)
                    ->when($item, fn ($q) => $q->where('customer_bond_plot.customer_bond_id', '!=', $item->id))
                    ->select('customer_bonds.bond_no')
                    ->first();

                if ($duplicate) {
                    $bondLabel = $duplicate->bond_no ?: 'another bond';
                    $fail('Plot "' . ($plot->title ?? $plot->id) . '" is already booked under bond "' . $bondLabel . '".');
                }
            }],
            'plot_amounts' => ['nullable', 'array'],
            'plot_amounts.*' => ['nullable', 'numeric', 'min:0'],
            'plot_areas' => ['nullable', 'array'],
            'plot_areas.*' => ['nullable', 'numeric', 'min:0'],
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

        // arazi_code is the working key; the HasAraziCode trait resolves arazi_id automatically on save.

        $payload['bond_no'] = ($payload['bond_no'] ?? null) ?: $this->nextBondNumber();

        if (! empty($plotIds)) {
            // prefer explicit plot_areas submitted from client, otherwise fall back to DB values
            $submittedAreas = $validated['plot_areas'] ?? [];
            if (! empty($submittedAreas)) {
                $totalArea = collect($submittedAreas)->only($plotIds)->map(fn($v) => (float) $v)->sum();
            } else {
                $totalArea = Plot::whereIn('id', $plotIds)->sum('area');
            }

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

        // Update plot areas if client provided them
        $plotAreas = $validated['plot_areas'] ?? [];
        if (! empty($plotAreas)) {
            foreach ($plotAreas as $plotId => $area) {
                try {
                    Plot::where('id', $plotId)->update(['area' => (float) $area]);
                } catch (\Throwable $e) {
                    // ignore individual update errors
                }
            }
        }

        // Mark ONLY the explicitly selected plots as booked. Never fall back to
        // updating every plot of the arazi — a bond saved without specific plots
        // must not flip the whole arazi's plots to booked.
        try {
            if (! empty($plotIds)) {
                Plot::whereIn('id', $plotIds)->update(['status' => 'booked']);
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
            'arazi_code' => $bond->arazi_code,
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
        return $this->applyOwnershipScope(
            CustomerBond::with(['customer', 'arazi', 'plots', 'witnesses', 'broker'])
                ->withSum('payments as paid_amount', 'amount')
                ->withSum(['payments as installment_paid' => function ($q) { $q->where('entry_type', 'installment'); }], 'amount')
                ->latest()
        );
    }

    public function create()
    {
        $this->authorizeCrud('create');
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
        $arazis = $this->uniqueArazisList();
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

    public function index(\Illuminate\Http\Request $request)
    {
        $araziCode = $request->query('arazi_code');
        $plotQuery = trim((string) $request->query('plot'));

        $query = $this->resourceQuery();
        if ($araziCode) {
            $query->where('arazi_code', (string) $araziCode);
        }
        if ($plotQuery !== '') {
            // Exact title match — a plot title behaves like a plot number, so a
            // LIKE '%1%' would wrongly match 10, 11, 12… Scope to the selected arazi too.
            $query->whereHas('plots', function ($q) use ($plotQuery, $araziCode) {
                $q->where('plots.title', $plotQuery);
                if ($araziCode) {
                    $q->where('plots.arazi_code', (string) $araziCode);
                }
            });
        }

        $records = $query->get();
        $routeName = $this->resourceRouteName();

        $rows = $records->map(function (Model $record) use ($routeName) {
            return array_merge($this->resourceRow($record), [
                'edit_url' => route($routeName . '.edit', $record),
                'delete_url' => route($routeName . '.destroy', $record),
            ]);
        })->all();

        $arazis = $this->uniqueArazisList();

        return view('crud.index', [
            'title' => $this->resourceTitle(),
            'columns' => $this->resourceColumns(),
            'rows' => $rows,
            'createUrl' => route($routeName . '.create'),
            'exportCsvUrl' => $this->allowsCsvExport() ? route($routeName.'.export.csv') : null,
            'isCustomerBondIndex' => true,
            'filter_arazi' => $araziCode,
            'filter_plot' => $plotQuery,
            'arazis' => $arazis,
        ]);
    }

    public function edit($id)
    {
        $this->authorizeCrud('edit');
        $modelClass = $this->resourceModel();
        $item = $modelClass::with('plots')->findOrFail($id);
        $this->authorizeOwnership($item);

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
        $arazis = $this->uniqueArazisList();

        // The select uses Arazi No codes as values; arazi_code is already stored directly.

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
        $araziCode = $item->arazi
            ? ($item->arazi->legacy_arazi_code ?: ('Arazi-'.$item->arazi->id))
            : '-';

        $plotRows = $item->plots->map(fn($p) => [
            'title' => $p->title ?? ('Plot-'.$p->id),
            'area'  => $p->area ? $p->area.' gaz' : '-',
        ])->all();

        return [
            'cells' => [
                $item->bond_no,
                $item->customer?->name ?? '-',
                '',  // arazi — rendered as HTML in view via bond_arazi / bond_plots
                '',  // plots
                optional($item->bond_date)->format('d-m-Y') ?? '-',
                number_format((float) $item->bond_amount, 2),
                number_format((float) ($item->paid_amount ?? 0), 2),
                number_format(max(0, ((float) ($item->bond_amount ?? 0) - (float) ($item->paid_amount ?? 0))), 2),
            ],
            'bond_arazi' => $araziCode,
            'bond_plots' => $plotRows,
            'print_url' => route('customer-bonds.print', $item->id),
            'pdf_url' => route('customer-bonds.pdf', $item->id),
            'action_buttons' => [
                [
                    'url'   => route('customer-bond-payments.index', ['bond_id' => $item->id]),
                    'label' => 'Ledger',
                    'class' => 'btn-outline-success',
                ],
                [
                    'url' => route('customer-bonds.cheques-modal', $item->id),
                    'label' => 'Cheques',
                    'class' => 'btn-outline-info',
                    'data_modal' => true,
                    'data_toggle' => 'modal',
                    'data_target' => 'chequesModal',
                ],
                [
                    'url' => route('change-log.record', ['type' => 'bond', 'id' => $item->id]),
                    'label' => 'Log',
                    'class' => 'btn-outline-dark',
                    'data_modal' => true,
                    'data_toggle' => 'modal',
                    'data_target' => 'changeLogModal',
                ],
            ],
            // mark that links for this resource should open in a new tab
            'open_in_new_tab' => true,
        ];
    }

    /**
     * Return modal data for cheques management (for modal popup).
     */
    public function chequesModal(CustomerBond $customer_bond)
    {
        $customer_bond->loadMissing(['customer', 'cheques.connectedAccount', 'arazi', 'plots', 'payments']);

        // balance
        $totalAmount = (float) ($customer_bond->total_amount ?? $customer_bond->bond_amount ?? 0);
        $paidAmount  = (float) $customer_bond->payments
            ->whereNotIn('entry_type', ['return', 'discount'])->sum('amount')
            - (float) $customer_bond->payments
            ->whereIn('entry_type', ['return', 'discount'])->sum('amount');
        $balance = max($totalAmount - $paidAmount, 0);

        // last installment paid
        $lastPayment = $customer_bond->payments
            ->whereNotIn('entry_type', ['return', 'discount'])
            ->sortByDesc('entry_date')
            ->first();

        // arazi label
        $araziLabel = '-';
        if ($customer_bond->arazi) {
            $araziLabel = $customer_bond->arazi->araziNoCode();
        }

        // plots
        $plotsLabel = $customer_bond->plots->isNotEmpty()
            ? $customer_bond->plots->map(fn ($p) => $p->title ?? ('Plot-' . $p->id))->implode(', ')
            : '-';

        return response()->json([
            'bond_id'          => $customer_bond->id,
            'bond_no'          => $customer_bond->bond_no,
            'customer_name'    => $customer_bond->customer?->name ?? '-',
            'bond_date'        => optional($customer_bond->bond_date)->format('d-m-Y') ?? '-',
            'end_date'         => optional($customer_bond->expiry_date ?? $customer_bond->last_date)->format('d-m-Y') ?? '-',
            'arazi'            => $araziLabel,
            'plots'            => $plotsLabel,
            'total_amount'     => number_format($totalAmount, 2),
            'paid_amount'      => number_format($paidAmount, 2),
            'balance'          => number_format($balance, 2),
            'last_payment_date'=> $lastPayment ? optional($lastPayment->entry_date)->format('d-m-Y') : '-',
            'last_payment_amt' => $lastPayment ? number_format((float)$lastPayment->amount, 2) : '-',
            'cheques' => $customer_bond->cheques->map(fn ($c) => [
                'id'           => $c->id,
                'cheque_number'=> $c->cheque_number,
                'cheque_date'  => optional($c->cheque_date)->format('d-m-Y'),
                'amount'       => number_format((float)$c->amount, 2),
                'status'       => $c->status,
                'type'         => $c->type ?? 'mentioned',
                'notes'        => $c->notes,
                'account_name' => $c->connectedAccount?->name ?? '-',
            ])->all(),
            'manage_url' => route('customer-bond-cheques.manage', $customer_bond->id),
        ]);
    }

    /**
     * JSON for Customer Payment form: Arazi / plots / land size from bond (read-only on client).
     */
    public function paymentContext(CustomerBond $customer_bond)
    {
        return response()->json($this->bondPaymentContext($customer_bond));
    }

    /**
     * Find a bond by bond_no and return full payment context for compact UI.
     */
    public function byBondNo(\Illuminate\Http\Request $request)
    {
        $bondNo = trim((string) $request->query('bond_no', ''));
        if ($bondNo === '') {
            return response()->json(['found' => false, 'message' => 'Bond number is required.']);
        }

        $bond = $this->applyOwnershipScope(
            CustomerBond::where('bond_no', $bondNo)->with(['arazi', 'plots', 'customer', 'witnesses', 'payments'])->latest()
        )->first();

        if (! $bond) {
            return response()->json(['found' => false, 'message' => 'Bond not found.']);
        }

        return response()->json(array_merge(['found' => true], $this->bondPaymentContext($bond)));
    }

    /**
     * Build the full payment-context payload for a bond (shared by byBondNo, paymentContext, byPlot).
     */
    private function bondPaymentContext(CustomerBond $bond): array
    {
        $bond->loadMissing(['arazi', 'plots', 'customer', 'witnesses', 'payments']);

        $araziLabel = '-';
        if ($bond->arazi) {
            $araziLabel = $bond->arazi->araziNoCode();
        }

        $plots = $bond->plots->map(fn ($p) => [
            'id'    => $p->id,
            'label' => $p->title ?? ('Plot-' . $p->id),
            'area'  => $p->area,
        ])->values();

        $totalAmount  = (float) ($bond->total_amount ?? $bond->bond_amount ?? 0);
        $paidAmount   = (float) $bond->payments->whereNotIn('entry_type', ['return', 'discount'])->sum('amount')
                      - (float) $bond->payments->whereIn('entry_type', ['return', 'discount'])->sum('amount');
        $balance      = max($totalAmount - $paidAmount, 0);
        $paymentCount = $bond->payments->count();
        $nextInstNo   = $paymentCount + 1;

        $witnesses = $bond->witnesses->map(fn ($w) => [
            'name'   => $w->name ?? '-',
            'mobile' => $w->mobile ?? null,
            'id_no'  => $w->id_no ?? null,
        ])->values();

        return [
            'bond_id'           => $bond->id,
            'bond_no'           => $bond->bond_no,
            'customer_id'       => $bond->customer_id,
            'customer_label'    => $bond->customer?->name ?? '-',
            'arazi_code'        => $bond->arazi_code,
            'arazi_label'       => $araziLabel,
            'plots'             => $plots,
            'land_size'         => $bond->land_size ?? $bond->sale_land,
            // bond summary
            'bond_date'         => optional($bond->bond_date)->format('d-m-Y'),
            'installment_end_date' => optional($bond->expiry_date ?? $bond->last_date)->format('d-m-Y'),
            'no_of_months'      => $bond->no_of_months,
            'installment_amount'=> (float) ($bond->installment_amount ?? 0),
            'total_amount'      => $totalAmount,
            'paid_amount'       => $paidAmount,
            'balance_amount'    => $balance,
            'payment_count'     => $paymentCount,
            'next_installment_no' => $nextInstNo,
            'witnesses'         => $witnesses,
        ];
    }

    /**
     * Find a bond (if any) that includes the given plot and return basic info for compact UI.
     */
    public function byPlot(\App\Models\Plot $plot)
    {
        $bond = $this->applyOwnershipScope(
            CustomerBond::whereHas('plots', function ($q) use ($plot) {
                $q->where('plots.id', $plot->id);
            })->latest()
        )->first();

        if (! $bond) {
            return response()->json(['found' => false]);
        }

        return response()->json(array_merge(['found' => true], $this->bondPaymentContext($bond)));
    }

    public function print($id)
    {
        $bond = CustomerBond::with(['customer', 'arazi', 'plots', 'witnesses', 'broker'])->findOrFail($id);
        $this->authorizeOwnership($bond);
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
        $this->authorizeOwnership($bond);
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

    /**
     * Unique "Arazi No" codes (legacy_arazi_code, falling back to plot_number).
     */
    private function uniqueArazisList(): array
    {
        $codes = \App\Models\Arazi::orderBy('id')->get()
            ->map(fn ($a) => $a->araziNoCode())
            ->unique()
            ->values()
            ->all();

        return array_combine($codes, $codes);
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
