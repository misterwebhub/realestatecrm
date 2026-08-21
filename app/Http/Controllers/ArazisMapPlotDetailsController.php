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
     * One row in a popup section. Anything empty is still emitted (as null)
     * so the popup renders a "-" placeholder rather than silently dropping
     * the field — a missing value is information too.
     */
    private function row(string $label, $value, string $type = 'text', ?string $url = null): array
    {
        if ($value === '') {
            $value = null;
        }

        $row = ['label' => $label, 'value' => $value, 'type' => $type];

        if ($url !== null && $value !== null) {
            $row['url'] = $url;
        }

        if ($type === 'amount' && $value !== null) {
            $row['words'] = $this->amountWords((float) $value);
        }

        return $row;
    }

    private function date($value): ?string
    {
        return optional($value)->format('d-m-Y');
    }

    /**
     * Witness / nominee columns store a JSON array of {name, mobile} rather
     * than a plain string (all 445 registries do). Rendered as-is that shows
     * raw JSON in the popup, so flatten it to "NAME (mobile), NAME (mobile)".
     * Anything that isn't JSON is passed straight through unchanged.
     */
    private function peopleList($value): ?string
    {
        if ($value === null || $value === '') {
            return null;
        }

        if (! is_array($value)) {
            $trimmed = trim((string) $value);

            if ($trimmed === '' || ! in_array($trimmed[0], ['[', '{'], true)) {
                return $trimmed === '' ? null : $trimmed;
            }

            $decoded = json_decode($trimmed, true);

            if (! is_array($decoded)) {
                return $trimmed;
            }

            $value = $decoded;
        }

        if (isset($value['name']) || isset($value['mobile'])) {
            $value = [$value];
        }

        $parts = [];

        foreach ($value as $person) {
            if (! is_array($person)) {
                $person = trim((string) $person);
                if ($person !== '') {
                    $parts[] = $person;
                }
                continue;
            }

            $name = trim((string) ($person['name'] ?? ''));
            $mobile = trim((string) ($person['mobile'] ?? ''));

            if ($name === '' && $mobile === '') {
                continue;
            }

            $parts[] = $mobile !== '' ? ($name !== '' ? $name . ' (' . $mobile . ')' : $mobile) : $name;
        }

        return $parts ? implode(', ', $parts) : null;
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
     *
     * Every registry, bond, booking and hold attached to the plot is
     * returned, each as its own section with all of its fields. Nothing is
     * merged, overwritten or hidden behind a "primary source" — a plot that
     * is both registered and bonded shows both records in full.
     */
    public function show(Request $request, int $plotId): JsonResponse
    {
        $user = $request->user();

        if (! $user || ! $user->isSuperAdmin()) {
            return $this->noStore(response()->json([
                'ok' => false,
                'message' => 'Only super admin can view plot buyer details.',
            ], 403));
        }

        $plot = Plot::with(['arazi', 'activeHold.agent', 'activeHold.customer', 'activeHold.creator'])->find($plotId);

        if (! $plot) {
            return $this->noStore(response()->json(['ok' => false, 'message' => 'Plot not found.'], 404));
        }

        $data = [
            'ok' => true,
            'plot_id' => $plot->id,
            'plot_title' => $plot->title ?: ('Plot-' . $plot->id),
            'arazi_code' => $plot->arazi_code,
            'status' => $plot->status,
            'area' => $plot->area,
            'sections' => [],
        ];

        $sources = [];

        // ---- Registries -------------------------------------------------
        // Every registry the plot belongs to, newest first. A few plots are
        // linked to more than one, and with a ->first() the older ones were
        // silently invisible.
        $registries = Registry::with(['customer', 'agent', 'partner', 'checkByAgent'])
            ->forPlot($plot->id)
            ->orderByDesc('id')
            ->get();

        foreach ($registries as $i => $registry) {
            $sources[] = 'registry';
            $pivotArea = $registry->plots()->where('plots.id', $plot->id)->first()?->pivot?->area;

            $data['sections'][] = [
                'key' => 'registry',
                'title' => $registries->count() > 1 ? 'Registry ' . ($i + 1) : 'Registry',
                'rows' => [
                    $this->row('Registry Code', $registry->registry_code ?: ('REG-' . $registry->id), 'text', route('registries.edit', $registry->id)),
                    $this->row('Receipt No', $registry->receipt_no),
                    $this->row('Customer Reg No', $registry->customer_reg_no),
                    $this->row('Registry Date', $this->date($registry->registry_date)),
                    $this->row('Deed No', $registry->deed_no),
                    $this->row('Gaz (this plot)', $pivotArea ?? $plot->area),
                    $this->row('Land Size (registry)', $registry->land_size),
                    $this->row('Registry Amount', $registry->registry_amount, 'amount'),
                    $this->row('Circle Value', $registry->circle_value, 'amount'),
                    $this->row('Advance Amount', $registry->advance_amount, 'amount'),
                    $this->row('Down Payment', $registry->down_payment, 'amount'),
                    $this->row('Installment Amount', $registry->installment_amount, 'amount'),
                    $this->row('Booking Mode', $registry->booking_mode),
                    $this->row('Due Date', $this->date($registry->due_date)),
                    $this->row('Expected Registry Date', $this->date($registry->expected_registry_date)),
                    $this->row('Status', $registry->status),
                    $this->row('Payment Status', $registry->payment_status),
                    $this->row('Lock Status', $registry->lock_status),
                    $this->row('Customer', $registry->customer?->name, 'text', $registry->customer ? route('customer.dashboard', $registry->customer->id) : null),
                    $this->row('Customer Mobile', $registry->customer?->mobile ?: $registry->customer?->phone),
                    $this->row('Broker', $registry->agent?->name),
                    $this->row('Broker Commission', $registry->broker_commission, 'amount'),
                    $this->row('Checked By', $registry->checkByAgent?->name),
                    $this->row('Partner', $registry->partner?->name),
                    $this->row('ID Card No', $registry->id_card_no),
                    $this->row('Witness', $this->peopleList($registry->witness_name)),
                    $this->row('Nominee', $this->peopleList($registry->nominee_name)),
                ],
            ];
        }

        // ---- Bonds ------------------------------------------------------
        $bonds = CustomerBond::with(['customer', 'broker'])
            ->whereHas('plots', fn ($q) => $q->where('plots.id', $plot->id))
            ->orderByDesc('id')
            ->get();

        foreach ($bonds as $i => $bond) {
            $sources[] = 'bond';
            $saleAmount = $bond->plots()->where('plots.id', $plot->id)->first()?->pivot?->sale_amount;
            $totalAmount = (float) ($bond->bond_amount ?? $bond->total_amount ?? 0);
            $paidAmount = (float) $bond->payments()->sum('amount');
            $balanceAmount = max($totalAmount - $paidAmount, 0);

            $data['sections'][] = [
                'key' => 'bond',
                'title' => $bonds->count() > 1 ? 'Bond ' . ($i + 1) : 'Bond',
                'rows' => [
                    $this->row('Bond No', $bond->bond_no, 'text', route('customer-bonds.edit', $bond->id)),
                    $this->row('Bond Date', $this->date($bond->bond_date)),
                    $this->row('Bond Type', $bond->bond_type),
                    $this->row('Bond Amount', $bond->bond_amount, 'amount'),
                    $this->row('Total Amount', $bond->total_amount, 'amount'),
                    $this->row('Sale Amount (this plot)', $saleAmount, 'amount'),
                    $this->row('Paid', $paidAmount, 'amount'),
                    $this->row('Balance (calculated)', $balanceAmount, 'amount'),
                    $this->row('Balance (on bond)', $bond->balance, 'amount'),
                    $this->row('Land Size', $bond->land_size),
                    $this->row('Sale Land', $bond->sale_land),
                    $this->row('Sale Rate', $bond->sale_rate, 'amount'),
                    $this->row('Bayana Mode', $bond->bayana_mode),
                    $this->row('Amount', $bond->amount, 'amount'),
                    $this->row('Installment Amount', $bond->installment_amount, 'amount'),
                    $this->row('No of Months', $bond->no_of_months),
                    $this->row('Last Date', $this->date($bond->last_date)),
                    $this->row('Expiry Date', $this->date($bond->expiry_date)),
                    $this->row('Customer', $bond->customer?->name, 'text', $bond->customer ? route('customer.dashboard', $bond->customer->id) : null),
                    $this->row('Customer Mobile', $bond->mobile ?: ($bond->customer?->mobile ?: $bond->customer?->phone)),
                    $this->row('Broker', $bond->broker?->name),
                    $this->row('Broker Payment', $bond->broker_payment, 'amount'),
                    $this->row('Broker Paid', $bond->broker_paid, 'amount'),
                    $this->row('Broker Balance', $bond->broker_balance, 'amount'),
                    $this->row('Broker Comment', $bond->broker_comment),
                    $this->row('Customer Comment', $bond->customer_comment),
                    $this->row('Witness', $this->peopleList($bond->witness_name)),
                    $this->row('Nominee', $this->peopleList($bond->nominee_details)),
                    $this->row('Notes', $bond->notes),
                ],
            ];
        }

        // ---- Bookings ---------------------------------------------------
        $bookings = Booking::with('customer')
            ->where('plot_id', $plot->id)
            ->where(function ($q) {
                $q->whereNull('status')->orWhere('status', '!=', 'expired');
            })
            ->orderByDesc('id')
            ->get();

        foreach ($bookings as $i => $booking) {
            $sources[] = 'booking';

            $data['sections'][] = [
                'key' => 'booking',
                'title' => $bookings->count() > 1 ? 'Booking ' . ($i + 1) : 'Booking',
                'rows' => [
                    $this->row('Booking Date', $this->date($booking->booking_date), 'text', route('bookings.edit', $booking->id)),
                    $this->row('Expiry Date', $this->date($booking->expiry_date)),
                    $this->row('Advance Amount', $booking->advance_amount, 'amount'),
                    $this->row('Booking Status', $booking->status),
                    $this->row('Customer', $booking->customer?->name, 'text', $booking->customer ? route('customer.dashboard', $booking->customer->id) : null),
                    $this->row('Customer Mobile', $booking->customer?->mobile ?: $booking->customer?->phone),
                ],
            ];
        }

        // ---- Hold -------------------------------------------------------
        $activeHold = $plot->activeHold;

        if ($activeHold) {
            $sources[] = 'hold';

            $data['sections'][] = [
                'key' => 'hold',
                'title' => 'Hold',
                'rows' => [
                    $this->row('Hold Days', $activeHold->days, 'text', route('plot-holds.index', ['status' => 'active', 'arazi_code' => $plot->arazi_code, 'q' => $plot->title])),
                    $this->row('Hold From', $this->date($activeHold->start_date)),
                    $this->row('Hold Till', $this->date($activeHold->end_date)),
                    $this->row('Held For', $activeHold->customer_name ?: $activeHold->customer?->name),
                    $this->row('Phone', $activeHold->customer_phone ?: $activeHold->customer?->mobile ?: $activeHold->customer?->phone),
                    $this->row('Hold Broker', $activeHold->agent?->name),
                    $this->row('Held By', $activeHold->creator?->name),
                    $this->row('Held On', optional($activeHold->created_at)->format('d-m-Y H:i')),
                    $this->row('Notes', $activeHold->notes),
                ],
            ];
        }

        $data['source'] = $sources[0] ?? 'none';
        $data['data_issue'] = false;

        if (empty($sources)) {
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
                $data['message'] = $status === 'available'
                    ? 'This plot is available — no customer or broker on record.'
                    : 'No customer/broker on record for this plot yet.';
            }
        }

        return $this->noStore(response()->json($data));
    }

    /**
     * Never cache a plot-details payload. The map pages are static files
     * served straight by Apache, so a browser or intermediate proxy that
     * stored this response would keep showing an old registry/bond long
     * after the record was edited.
     */
    private function noStore(JsonResponse $response): JsonResponse
    {
        return $response
            ->header('Cache-Control', 'no-store, no-cache, must-revalidate, max-age=0')
            ->header('Pragma', 'no-cache')
            ->header('Expires', '0');
    }
}
