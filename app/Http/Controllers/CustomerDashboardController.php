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
        $bonds = CustomerBond::with('plots')->where('customer_id', $customer->id)->get();
        $bondsCount = $bonds->count();
        $totalBondAmount = $bonds->sum(function ($b) { return (float) ($b->total_amount ?? $b->bond_amount ?? 0); });

        $payments = CustomerBondPayment::where('customer_id', $customer->id)->latest()->limit(50)->get();
        $totalPaid = $payments->sum('amount');

        $cheques = CustomerBondCheque::where('customer_id', $customer->id)->latest()->limit(50)->get();

        $shareUrl = route('customer.dashboard', ['customer' => $customer->id, 'shared' => 1]);

        return view('dashboards.customer', compact('customer', 'bonds', 'bondsCount', 'totalBondAmount', 'payments', 'totalPaid', 'cheques', 'shareUrl'));
    }
}
