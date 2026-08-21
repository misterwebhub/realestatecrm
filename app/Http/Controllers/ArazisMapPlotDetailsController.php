<?php

namespace App\Http\Controllers;

use App\Models\Booking;
use App\Models\CustomerBond;
use App\Models\Plot;
use App\Models\Registry;
use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;
use NumberFormatter;

class ArazisMapPlotDetailsController extends Controller
{
    private function amountWords(float $amount): string
    {
        if ($amount <= 0) {
            return 'zero rupees only';
        }

        if (class_exists(NumberFormatter::class)) {
            foreach (['hi_IN', 'en_IN'] as $locale) {
                try {
                    $formatter = new NumberFormatter($locale, NumberFormatter::SPELLOUT);
                    $whole = (int) floor($amount);
                    $paise = (int) round(($amount - $whole) * 100);

                    $words = trim((string) $formatter->format($whole));
                    if ($words === '') {
                        continue;
                    }

                    $result = ucfirst($words) . ' rupees';
                    if ($paise > 0) {
                        $paiseWords = trim((string) $formatter->format($paise));
                        if ($paiseWords !== '') {
                            $result .= ' and ' . ucfirst($paiseWords) . ' paise';
                        }
                    }

                    return $result . ' only';
                } catch (\Throwable $e) {
                    continue;
                }
            }
        }

        return (string) $amount;
    }

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

        $plot = Plot::with(['arazi', 'activeHold.agent', 'activeHold.customer', 'activeHold.creator'])->find($plotId);

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

        $booking = Booking::with('customer')
            ->where('plot_id', $plot->id)
            ->where(function ($q) {
                $q->whereNull('status')->orWhere('status', '!=', 'expired');
            })
            ->latest('id')
            ->first();

        if ($booking) {
            $data['booking_id'] = $booking->id;
            $data['booking_url'] = route('bookings.edit', $booking->id);
            $data['booking_date'] = optional($booking->booking_date)->format('d-m-Y');
            $data['booking_expiry_date'] = optional($booking->expiry_date)->format('d-m-Y');
            $data['advance_amount'] = $booking->advance_amount;
            $data['booking_status'] = $booking->status;
            $data['booking_customer_name'] = $booking->customer?->name;
        }

        $activeHold = $plot->activeHold;
        if ($activeHold) {
            $data['hold_id'] = $activeHold->id;
            $data['hold_url'] = route('plot-holds.index', ['status' => 'active', 'arazi_code' => $plot->arazi_code, 'q' => $plot->title]);
            $data['hold_days'] = $activeHold->days;
            $data['hold_start_date'] = optional($activeHold->start_date)->format('d-m-Y');
            $data['hold_end_date'] = optional($activeHold->end_date)->format('d-m-Y');
            $data['hold_customer_id'] = $activeHold->customer_id;
            $data['hold_customer_name'] = $activeHold->customer_name ?: $activeHold->customer?->name;
            $data['hold_customer_phone'] = $activeHold->customer_phone ?: $activeHold->customer?->mobile ?: $activeHold->customer?->phone;
            $data['hold_agent_name'] = $activeHold->agent?->name;
            $data['hold_notes'] = $activeHold->notes;
            $data['hold_created_by'] = $activeHold->creator?->name;
            $data['hold_created_at'] = optional($activeHold->created_at)->format('d-m-Y H:i');
        }

        // Pull whatever records actually exist for this plot — registry,
        // bond, booking, hold — and merge all of them into one response.
        // A plot can have more than one (e.g. registered AND bonded), so we
        // no longer stop at the first match; every found record's fields
        // are shown, nothing is hidden because a different record "won".
        $sources = [];

        $registry = Registry::with(['customer', 'agent'])
            ->forPlot($plot->id)
            ->latest('id')
            ->first();

        if ($registry) {
            $sources[] = 'registry';
            $pivotArea = $registry->plots()->where('plots.id', $plot->id)->first()?->pivot?->area;

            $data['customer_id'] = $data['customer_id'] ?? $registry->customer?->id;
            $data['customer_url'] = $data['customer_url'] ?? ($registry->customer ? route('customer.dashboard', $registry->customer->id) : null);
            $data['customer_name'] = $data['customer_name'] ?? $registry->customer?->name;
            $data['customer_mobile'] = $data['customer_mobile'] ?? ($registry->customer?->mobile ?? $registry->customer?->phone);
            $data['broker_name'] = $data['broker_name'] ?? $registry->agent?->name;
            $data['gaz'] = $pivotArea ?? $registry->land_size ?? $plot->area;
            $data['deed_no'] = $registry->deed_no;
            $data['registry_date'] = optional($registry->registry_date)->format('d-m-Y');
        }

        $bond = CustomerBond::with(['customer', 'broker'])
            ->whereHas('plots', fn ($q) => $q->where('plots.id', $plot->id))
            ->latest('id')
            ->first();

        if ($bond) {
            $sources[] = 'bond';
            $pivotArea = $bond->plots()->where('plots.id', $plot->id)->first()?->pivot?->sale_amount;
            $totalAmount = (float) ($bond->bond_amount ?? $bond->total_amount ?? 0);
            $paidAmount = (float) $bond->payments()->sum('amount');
            $balanceAmount = max($totalAmount - $paidAmount, 0);

            $data['bond_id'] = $bond->id;
            $data['bond_no'] = $bond->bond_no;
            $data['bond_url'] = route('customer-bonds.edit', $bond->id);
            $data['customer_id'] = $data['customer_id'] ?? $bond->customer?->id;
            $data['customer_url'] = $data['customer_url'] ?? ($bond->customer ? route('customer.dashboard', $bond->customer->id) : null);
            $data['customer_name'] = $data['customer_name'] ?? $bond->customer?->name;
            $data['customer_mobile'] = $data['customer_mobile'] ?? ($bond->customer?->mobile ?? $bond->customer?->phone);
            $data['broker_name'] = $data['broker_name'] ?? $bond->broker?->name;
            $data['gaz'] = $data['gaz'] ?? $plot->area;
            $data['sale_amount'] = $pivotArea;
            $data['bond_date'] = optional($bond->bond_date)->format('d-m-Y');
            $data['booking_date'] = optional($bond->bond_date)->format('d-m-Y');
            $data['bond_amount'] = $totalAmount;
            $data['bond_amount_words'] = $this->amountWords($totalAmount);
            $data['advance_amount'] = $paidAmount;
            $data['advance_amount_words'] = $this->amountWords($paidAmount);
            $data['paid_amount'] = $paidAmount;
            $data['balance_amount'] = $balanceAmount;
            $data['balance_amount_words'] = $this->amountWords($balanceAmount);
            $data['balance'] = $balanceAmount;
            $data['last_date'] = optional($bond->last_date)->format('d-m-Y');
        }

        if ($booking && !$bond) {
            // Booking numbers are already shown above unconditionally; here
            // we only add the extra fields that are specific to a plain
            // booking-only plot (no bond raised yet).
            $sources[] = 'booking';
            $advanceAmount = (float) ($booking->advance_amount ?? 0);
            $data['customer_url'] = $data['customer_url'] ?? ($booking->customer ? route('customer.dashboard', $booking->customer->id) : null);
            $data['customer_name'] = $data['customer_name'] ?? $booking->customer?->name;
            $data['customer_mobile'] = $data['customer_mobile'] ?? ($booking->customer?->mobile ?? $booking->customer?->phone);
            $data['advance_amount'] = $data['advance_amount'] ?? $advanceAmount;
            $data['advance_amount_words'] = $data['advance_amount_words'] ?? $this->amountWords($advanceAmount);
            $data['paid_amount'] = $data['paid_amount'] ?? $advanceAmount;
            $data['balance_amount'] = $data['balance_amount'] ?? 0;
            $data['balance_amount_words'] = $data['balance_amount_words'] ?? $this->amountWords(0);
        }

        if ($activeHold) {
            $sources[] = 'hold';
        }

        if (empty($sources)) {
            $data['source'] = 'none';

            // Nothing is linked to this plot. If its status nonetheless
            // claims it's sold/booked/held, the status is stale — say so
            // explicitly rather than showing a vague "no records" note,
            // so it's obvious this is a data problem and not an empty plot.
            $status = strtolower((string) $plot->status);
            $claimsOccupied = in_array($status, ['booked', 'booked_advance', 'registry', 'sold', 'hold'], true);

            if ($claimsOccupied) {
                $data['data_issue'] = true;
                $data['message'] = 'Data issue: this plot is marked "'
                    . str_replace('_', ' ', $status)
                    . '" but has no bond, registry, booking or hold linked to it. The status is stale and needs correcting.';
            } else {
                $data['data_issue'] = false;
                $data['message'] = $status === 'available'
                    ? 'This plot is available — no customer or broker on record.'
                    : 'No customer/broker on record for this plot yet.';
            }
        } else {
            // Primary source drives the popup's status badge/label; the
            // rest of the fields above are already merged in regardless.
            $data['source'] = $sources[0];
        }

        return response()->json($data);
    }
}
