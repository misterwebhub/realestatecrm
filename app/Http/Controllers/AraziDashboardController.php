<?php

namespace App\Http\Controllers;

use App\Models\Arazi;
use App\Models\Plot;
use App\Models\CustomerBond;
use Illuminate\Http\Request;

class AraziDashboardController extends Controller
{
    public function show(Request $request, Arazi $arazi)
    {
        $totalPlots = Plot::where('arazi_id', $arazi->id)->count();
        $soldPlots = Plot::where('arazi_id', $arazi->id)->where('status', 'sold')->count();
        $leftPlots = max($totalPlots - $soldPlots, 0);

        $bonds = CustomerBond::with('customer')->where('arazi_id', $arazi->id)->get();
        $totalBonds = $bonds->count();
        $customers = $bonds->pluck('customer_id')->unique()->count();

        $totalBrokerPayment = $bonds->sum(function ($b) { return (float) ($b->broker_payment ?? 0); });
        $totalBrokerPaid = $bonds->sum(function ($b) { return (float) ($b->broker_paid ?? 0); });

        $shareUrl = route('arazi.dashboard', ['arazi' => $arazi->id, 'shared' => 1]);

        return view('dashboards.arazi', compact(
            'arazi', 'totalPlots', 'soldPlots', 'leftPlots', 'bonds', 'totalBonds', 'customers', 'totalBrokerPayment', 'totalBrokerPaid', 'shareUrl'
        ));
    }
}
