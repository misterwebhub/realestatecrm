<?php

namespace App\Http\Controllers;

use App\Models\CustomerBond;
use App\Models\Plot;
use App\Models\Registry;
use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;

class ArazisMapPlotDetailsController extends Controller
{
    /**
     * Customer/broker/gaz details for a single plot, shown in the click
     * popup on the legacy arazi map pages (arazis-map/<folder>/index.php).
     *
     * These map pages are static legacy PHP files served directly by
     * Apache (not routed through Laravel), so they cannot see the Laravel
     * session/auth state themselves. This endpoint is the only place the
     * access check actually happens — the map pages just fetch() it with
     * the browser's same-origin session cookie and render whatever comes
     * back. Non-super-admins get a 403 and the map JS shows nothing.
     */
    public function show(Request $request, int $plotId): JsonResponse
    {
        $user = $request->user();

        if (! $user || ! $user->isSuperAdmin()) {
            return response()->json([
                'ok' => false,
                'message' => 'Only super admin can view plot buyer details.',
            ], 403);
        }

        $plot = Plot::with('arazi')->find($plotId);

        if (! $plot) {
            return response()->json(['ok' => false, 'message' => 'Plot not found.'], 404);
        }

        $data = [
            'ok' => true,
            'plot_id' => $plot->id,
            'plot_title' => $plot->title ?: ('Plot-' . $plot->id),
            'arazi_code' => $plot->arazi_code,
            'status' => $plot->status,
            'area' => $plot->area,
        ];

        // Registry done — pull customer/broker/gaz from the registry (and its
        // pivot area for this specific plot, if it's a multi-plot registry).
        $registry = Registry::with(['customer', 'agent'])
            ->forPlot($plot->id)
            ->latest('id')
            ->first();

        if ($registry) {
            $pivotArea = $registry->plots()->where('plots.id', $plot->id)->first()?->pivot?->area;

            $data['source'] = 'registry';
            $data['customer_id'] = $registry->customer?->id;
            $data['customer_url'] = $registry->customer ? route('customer.dashboard', $registry->customer->id) : null;
            $data['customer_name'] = $registry->customer?->name;
            $data['customer_mobile'] = $registry->customer?->mobile ?? $registry->customer?->phone;
            $data['broker_name'] = $registry->agent?->name;
            $data['gaz'] = $pivotArea ?? $registry->land_size ?? $plot->area;
            $data['deed_no'] = $registry->deed_no;
            $data['registry_date'] = optional($registry->registry_date)->format('d-m-Y');

            return response()->json($data);
        }

        // Not registered yet — look for a bond that includes this plot.
        $bond = CustomerBond::with(['customer', 'broker'])
            ->whereHas('plots', fn ($q) => $q->where('plots.id', $plot->id))
            ->latest('id')
            ->first();

        if ($bond) {
            $pivotArea = $bond->plots()->where('plots.id', $plot->id)->first()?->pivot?->sale_amount;

            $data['source'] = 'bond';
            $data['bond_id'] = $bond->id;
            $data['bond_no'] = $bond->bond_no;
            $data['bond_url'] = route('customer-bonds.edit', $bond->id);
            $data['customer_id'] = $bond->customer?->id;
            $data['customer_url'] = $bond->customer ? route('customer.dashboard', $bond->customer->id) : null;
            $data['customer_name'] = $bond->customer?->name;
            $data['customer_mobile'] = $bond->customer?->mobile ?? $bond->customer?->phone;
            $data['broker_name'] = $bond->broker?->name;
            $data['gaz'] = $plot->area;
            $data['sale_amount'] = $pivotArea;

            return response()->json($data);
        }

        $data['source'] = 'none';
        $data['message'] = 'No customer/broker on record for this plot yet.';

        return response()->json($data);
    }
}
