<?php

namespace App\Http\Controllers;

use App\Models\Arazi;
use App\Models\Plot;
use App\Models\CustomerBond;
use Illuminate\Http\Request;

class AraziDashboardController extends Controller
{
    public function show(Request $request, string $code)
    {
        // Always resolve an arazi by its legacy code, never the internal id.
        $arazi = Arazi::where('legacy_arazi_code', $code)->firstOrFail();

        $totalPlots = Plot::where('arazi_code', $arazi->legacy_arazi_code)->count();
        $soldPlots = Plot::where('arazi_code', $arazi->legacy_arazi_code)->where('status', 'sold')->count();
        $leftPlots = max($totalPlots - $soldPlots, 0);

        // Plot counts are shared inventory, but bond/broker figures are deal data —
        // non-admins only see their own bonds on this arazi; admins see all.
        $bondsQuery = CustomerBond::with('customer')->where('arazi_code', $arazi->legacy_arazi_code);
        $user = auth()->user();
        if ($user && ! $user->isSuperAdmin()) {
            $bondsQuery->where('customer_bonds.created_by', $user->getKey());
        }
        $bonds = $bondsQuery->get();
        $totalBonds = $bonds->count();
        $customers = $bonds->pluck('customer_id')->unique()->count();

        $totalBrokerPayment = $bonds->sum(function ($b) { return (float) ($b->broker_payment ?? 0); });
        $totalBrokerPaid = $bonds->sum(function ($b) { return (float) ($b->broker_paid ?? 0); });

        $shareUrl = route('arazi.dashboard', ['code' => $arazi->legacy_arazi_code, 'shared' => 1]);

        return view('dashboards.arazi', compact(
            'arazi', 'totalPlots', 'soldPlots', 'leftPlots', 'bonds', 'totalBonds', 'customers', 'totalBrokerPayment', 'totalBrokerPaid', 'shareUrl'
        ));
    }
}
