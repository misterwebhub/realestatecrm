<?php

namespace App\Http\Controllers;

use App\Models\Customer;
use App\Models\CustomerBond;
use App\Models\CustomerBondPayment;
use App\Models\CustomerBondCheque;
use Illuminate\Http\Request;

class CustomerDashboardController extends Controller
{
    public function show(Request $request, Customer $customer)
    {
        // Non-admins may only open dashboards for customers they created.
        $this->authorizeOwner($customer);

        $bonds = $this->ownScope(CustomerBond::with('plots')->where('customer_id', $customer->id))->get();
        $bondsCount = $bonds->count();
        $totalBondAmount = $bonds->sum(function ($b) { return (float) ($b->total_amount ?? $b->bond_amount ?? 0); });

        $payments = $this->ownScope(CustomerBondPayment::where('customer_id', $customer->id)->latest())->limit(50)->get();
        $totalPaid = $payments->sum('amount');

        $cheques = $this->ownScope(CustomerBondCheque::where('customer_id', $customer->id)->latest())->limit(50)->get();

        $shareUrl = route('customer.dashboard', ['customer' => $customer->id, 'shared' => 1]);

        return view('dashboards.customer', compact('customer', 'bonds', 'bondsCount', 'totalBondAmount', 'payments', 'totalPaid', 'cheques', 'shareUrl'));
    }

    /**
     * Abort 404 if a non-admin opens a record they do not own.
     */
    protected function authorizeOwner($model): void
    {
        $user = auth()->user();
        if ($user && ! $user->isSuperAdmin()
            && \Illuminate\Support\Facades\Schema::hasColumn($model->getTable(), 'created_by')
            && (string) $model->getAttribute('created_by') !== (string) $user->getKey()) {
            abort(404);
        }
    }

    /**
     * Restrict a deal-data query to the current user's own records (non-admins).
     */
    protected function ownScope($query)
    {
        $user = auth()->user();
        if (! $user || $user->isSuperAdmin()) {
            return $query;
        }

        $model = $query->getModel();
        try {
            $hasColumn = \Illuminate\Support\Facades\Schema::hasColumn($model->getTable(), 'created_by');
        } catch (\Throwable $e) {
            $hasColumn = false;
        }

        if ($hasColumn) {
            $query->where($model->qualifyColumn('created_by'), $user->getKey());
        }

        return $query;
    }
}
