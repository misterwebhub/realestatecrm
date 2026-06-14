<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Arazi;
use App\Models\Customer;
use App\Models\CustomerBond;
use App\Models\Plot;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;

class CustomerController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Customer';
    }

    protected function resourceModel(): string
    {
        return Customer::class;
    }

    protected function resourceRouteName(): string
    {
        return 'customers';
    }

    protected function resourceColumns(): array
    {
        return ['Code', 'Name', 'Mobile', 'Secondary Mobile', 'Bonds / Arazi / Plots'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            ['name' => 'legacy_customer_code', 'label' => 'Customer Code', 'type' => 'text', 'value' => $item?->legacy_customer_code],
            ['name' => 'name', 'label' => 'Name', 'type' => 'text', 'value' => $item?->name],
            ['name' => 'mobile', 'label' => 'Mobile', 'type' => 'text', 'value' => $item?->mobile],
            ['name' => 'secondary_mobile', 'label' => 'Secondary Mobile', 'type' => 'text', 'value' => $item?->secondary_mobile],
            ['name' => 'id_document_no', 'label' => 'ID Document No', 'type' => 'text', 'value' => $item?->id_document_no],
            ['name' => 'address', 'label' => 'Address', 'type' => 'textarea', 'value' => $item?->address],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'legacy_customer_code' => ['nullable', 'string', 'max:40', 'unique:customers,legacy_customer_code' . ($item ? ',' . $item->id : '')],
            'name' => ['required', 'string', 'max:150'],
            'mobile' => ['required', 'string', 'max:20'],
            'secondary_mobile' => ['nullable', 'string', 'max:20'],
            'id_document_no' => ['nullable', 'string', 'max:60'],
            'address' => ['required', 'string', 'max:255'],
        ];
    }

    protected function resourceQuery()
    {
        return Customer::withCount('registries')->latest();
    }

    public function index(Request $request)
    {
        $q         = trim((string) $request->input('q', ''));
        $araziCode = trim((string) $request->input('arazi_code', ''));
        $plotQ     = trim((string) $request->input('plot', ''));

        $query = Customer::withCount('registries')->latest();

        // Filter by name or phone
        if ($q !== '') {
            $query->where(function ($qb) use ($q) {
                $qb->where('name', 'like', '%' . $q . '%')
                   ->orWhere('mobile', 'like', '%' . $q . '%')
                   ->orWhere('secondary_mobile', 'like', '%' . $q . '%');
            });
        }

        // Filter by arazi code → bonds → customers
        if ($araziCode !== '') {
            $customerIds = CustomerBond::where('arazi_code', $araziCode)->pluck('customer_id')->unique()->all();
            $query->whereIn('id', $customerIds);
        }

        // Filter by plot number / title → bonds → customers
        if ($plotQ !== '') {
            $plotIds = Plot::where('plot_number', 'like', '%' . $plotQ . '%')
                ->orWhere('title', 'like', '%' . $plotQ . '%')
                ->pluck('id')->all();
            $bondCustomerIds = CustomerBond::whereHas('plots', fn($pb) => $pb->whereIn('plots.id', $plotIds))
                ->pluck('customer_id')->unique()->all();
            $query->whereIn('id', $bondCustomerIds);
        }

        $customers = $query->with(['bonds.arazi', 'bonds.plots', 'registries'])->paginate(50)->withQueryString();
        $routeName = $this->resourceRouteName();

        $rows = $customers->map(function (Customer $item) use ($routeName) {
            return array_merge($this->resourceRowWithBonds($item), [
                'edit_url'   => route($routeName . '.edit', $item),
                'delete_url' => route($routeName . '.destroy', $item),
            ]);
        })->all();

        return view('customers.index', [
            'title'      => $this->resourceTitle(),
            'columns'    => $this->resourceColumns(),
            'rows'       => $rows,
            'customers'  => $customers,
            'createUrl'  => route($routeName . '.create'),
            'exportCsvUrl' => $this->allowsCsvExport() ? route($routeName . '.export.csv') : null,
            'q'          => $q,
            'arazi_code' => $araziCode,
            'plot'       => $plotQ,
        ]);
    }

    protected function resourceRow(Model $item): array
    {
        /** @var Customer $item */
        return [
            'cells' => [
                $item->legacy_customer_code ?? '-',
                $item->name,
                $item->mobile,
                $item->secondary_mobile ?? '-',
                '-',
            ],
            'action_buttons' => [
                [
                    'label' => 'Ledger',
                    'url' => route('customer-bond-payments.ledger', ['customer_id' => $item->id]),
                    'class' => 'btn-outline-info',
                ],
                [
                    'label' => 'Payment',
                    'url' => route('customer-bond-payments.create', ['customer_id' => $item->id]),
                    'class' => 'btn-outline-success',
                ],
            ],
        ];
    }

    protected function resourceRowWithBonds(Customer $item): array
    {
        $bonds = $item->bonds ?? collect();
        $registries = $item->registries ?? collect();

        // Build compact bond summary HTML
        $bondSummary = $bonds->map(function ($bond) use ($registries) {
            $araziCode = '-';
            if ($bond->arazi) {
                $araziCode = $bond->arazi->legacy_arazi_code ?: ('Arazi-' . $bond->arazi->id);
            }
            $plots = $bond->plots->map(fn($p) => $p->title ?? $p->plot_number ?? ('Plot-'.$p->id))->implode(', ');

            // Check if a registry exists for same arazi_id
            $hasRegistry = $bond->arazi_id
                ? $registries->where('arazi_id', $bond->arazi_id)->isNotEmpty()
                : false;

            return [
                'bond_no'      => $bond->bond_no ?? ('Bond-' . $bond->id),
                'arazi_code'   => $araziCode,
                'plots'        => $plots ?: '-',
                'bond_id'      => $bond->id,
                'has_registry' => $hasRegistry,
            ];
        })->all();

        return [
            'cells' => [
                $item->legacy_customer_code ?? '-',
                $item->name,
                $item->mobile,
                $item->secondary_mobile ?? '-',
                '', // bond column rendered as HTML in view
            ],
            'bond_summary' => $bondSummary,
            'action_buttons' => [
                [
                    'label' => 'Ledger',
                    'url' => route('customer-bond-payments.ledger', ['customer_id' => $item->id]),
                    'class' => 'btn-outline-info',
                ],
                [
                    'label' => 'Payment',
                    'url' => route('customer-bond-payments.create', ['customer_id' => $item->id]),
                    'class' => 'btn-outline-success',
                ],
            ],
        ];
    }

    public function bonds(Customer $customer)
    {
        $list = $customer->bonds()
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
}
