@php
    $consideration = (float) ($bond->total_amount ?? $bond->bond_amount ?? 0);
    $booking = (float) ($bond->amount ?? 0);
    $expectedSumPayable = max(0, $consideration - $booking);
    $installmentMonths = $bond->installment_amount ?? $bond->no_of_months;
    $fmtDate = static function ($value) {
        if ($value === null || $value === '') {
            return '-';
        }
        try {
            return \Carbon\Carbon::parse($value)->format('d-m-Y');
        } catch (\Throwable $e) {
            return '-';
        }
    };
@endphp
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>Registration Certificate - {{ $bond->bond_no ?? '' }}</title>
    <style>
        @page { margin: 12mm; size: A4 portrait; }
        * { box-sizing: border-box; }
        body { font-family: DejaVu Sans, sans-serif; font-size: 11pt; color: #000; margin: 0; padding: 12px; }
        .wrrper { max-width: 990px; margin: 0 auto; border: 3px solid #000; padding: 8px; }
        table { border-collapse: collapse; width: 100%; table-layout: fixed; }
        table, td, th { border: 1px solid #000; text-align: center; vertical-align: middle; word-wrap: break-word; }
        th { padding: 6px; background: #ececec; font-weight: bold; }
        td { padding: 8px 6px; }
        .style4 { min-height: 120px; }
        .style3 { min-height: 80px; }
        .style1 { height: 56px; }
        .style5 { width: 38%; text-align: left !important; }
        .textboxmain { width: 100%; }
        .small { font-size: 10px; color: #555; }
        .num { text-align: right; white-space: nowrap; }
        .bg-cyan { background-color: #00FFCC; }
        .bg-navy { background-color: #000080; color: #fff; }
        @media print {
            body { padding: 0; }
            .no-print { display: none !important; }
        }
    </style>
</head>
<body>
<div class="wrrper" id="main">
    <table>
        <tr>
            <td style="font-weight:bold;">CIN-U45201UP2019PTC123734</td>
            <td class="bg-cyan"><strong>CUSTOMER REG. NO</strong>&nbsp;
                <span style="color:red;font-weight:bold">{{ $bond->bond_no ?? '' }}</span>
            </td>
            <td style="text-align:right;font-weight:bold;">MOB. +91-9696446268, 9935142277</td>
        </tr>
        <tr>
            <td colspan="3" class="style4" style="text-align:left">
                <p style="font-size:28pt;color:red;font-weight:bold;margin:0;line-height:1;">HEED REAL</p>
                <p style="margin:0;font-size:16pt;line-height:1;">ESTATE PRIVATE LIMITED</p>
                <p class="bg-navy" style="padding:4px 6px;font-size:12pt;margin-top:6px;">19A ,New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</p>
                <p style="font-size:11pt;font-weight:bold;text-align:justify;margin-top:8px;">CERTIFIED that the associate described in Schedule here to Registered Joint Venture Of Consideration as shown in Schedule under Plan of Company subject to the regular payment of subscription(s) has mentioned in the said schedule and also subject to "general terms &amp; conditions" printed over leaf...</p>
            </td>
        </tr>
    </table>

    <table>
        <tr>
            <th>Regd.No &amp; Date of Commenement</th>
            <th>Plan Name / Term</th>
            <th>Mode of Payment</th>
            <th>Consideration Amount</th>
            <th>Installment of subscription Payment<br><span class="small">(No. of months)</span></th>
        </tr>
        <tr>
            <td>{{ $bond->bond_date ? $bond->bond_date->format('d-m-Y') : '' }}</td>
            <td>{{ $bond->bond_type ?? '-' }}</td>
            <td>{{ ucfirst($bond->bayana_mode ?? '-') }}</td>
            <td class="num">{{ number_format($consideration, 2) }}</td>
            <td>{{ $installmentMonths !== null && $installmentMonths !== '' ? (int) $installmentMonths : '-' }}</td>
        </tr>
    </table>

    <table>
        <tr>
            <th>Installment Due Date</th>
            <th>Booking Amount</th>
            <th>Date Of Last Payment</th>
            <th>Expiry Date</th>
            <th>Broker Name</th>
        </tr>
        <tr>
            <td>{{ $bond->last_date ? $bond->last_date->format('d-m-Y') : '-' }}</td>
            <td class="num">{{ number_format($booking, 2) }}</td>
            <td>{{ isset($lastPaymentDate) && $lastPaymentDate ? $fmtDate($lastPaymentDate) : '-' }}</td>
            <td>{{ $bond->expiry_date ? $bond->expiry_date->format('d-m-Y') : '-' }}</td>
            <td style="text-align:left">{{ $bond->broker?->name ?? '-' }}</td>
        </tr>
    </table>

    <table>
        <tr>
            <th rowspan="4">Name, D.O.B and Address of Associate</th>
            <td rowspan="4" class="style5">{{ $bond->customer?->name ?? '-' }}<br>{{ $bond->customer?->address ?? '' }}</td>
            <th colspan="2">Arazi No.</th>
        </tr>
        <tr>
            <td colspan="2">{{ $bond->arazi?->legacy_arazi_code ?? $bond->arazi?->plot_number ?? '-' }}</td>
        </tr>
        <tr>
            <th colspan="2">Plot No./Plot Size</th>
        </tr>
        <tr>
            <td colspan="2" style="text-align:left">
                @if($bond->plots && $bond->plots->isNotEmpty())
                    <ol style="margin:0;padding-left:18px;text-align:left">
                        @foreach($bond->plots as $plot)
                            <li style="text-align:left">
                                {{ $plot->plot_number ?? $plot->title ?? ('Plot-' . $plot->id) }}
                                / {{ $plot->area ?? $plot->size ?? '-' }}
                            </li>
                        @endforeach
                    </ol>
                @else
                    {{ $bond->arazi?->plot_number ?? '-' }} / {{ $bond->land_size ?? $bond->arazi?->size ?? '-' }}
                @endif
            </td>
        </tr>
        <tr>
            <th>Nominee's Name D.O.B and Relationship</th>
            <td colspan="2" class="style5" style="text-align:left">{{ $bond->nominee_details ? nl2br(e($bond->nominee_details)) : '-' }}</td>
            <td style="text-align:left"><strong>Aadhar/PAN/Voter/D.L NO</strong><br>{{ $bond->customer?->id_document_no ?? '-' }}</td>
        </tr>
    </table>

    <table>
        <tr>
            <th>EXPECTED SUM PAYABLE RUPEES</th>
            <td class="num">{{ number_format($expectedSumPayable, 2) }}</td>
        </tr>
        <tr>
            <td rowspan="2" style="font-weight:bold;">Date</td>
            <td style="text-align:left">For: ____________________________</td>
        </tr>
        <tr>
            <td style="text-align:left">&nbsp;</td>
        </tr>
    </table>

    <table>
        <tr>
            <td style="font-weight:bold;" colspan="2"></td>
            <td style="text-align:right;font-weight:bold;" colspan="2">MOB. +91-9696446268, 9935142277</td>
        </tr>
        <tr>
            <td colspan="4" class="style3" style="text-align:left">
                <p style="font-size:28pt;color:red;font-weight:bold;margin:0;line-height:1;">HEED REAL</p>
                <p style="margin:0;font-size:16pt;">ESTATE PRIVATE LIMITED</p>
                <p class="bg-navy" style="padding:4px 6px;font-size:12pt;margin-top:6px;">19A ,New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</p>
            </td>
        </tr>
        <tr>
            <th>Mobile No</th>
            <td>{{ $bond->mobile ?? ($bond->customer?->mobile ?? '-') }}</td>
            <th>Receipt No. :</th>
            <td>-</td>
        </tr>
        <tr>
            <th colspan="2">Name, D.o.B and Address of Associate :</th>
            <td colspan="2">{{ $bond->customer?->name ?? '-' }}</td>
        </tr>
        <tr>
            <th>Amount in words Rs.</th>
            <td colspan="3" class="num">{{ number_format($consideration, 2) }}</td>
        </tr>
    </table>

    <table>
        <tr>
            <td class="style1"><strong>Seal with Stamp</strong></td>
            <td class="style1"><strong>Authorised by</strong></td>
            <td class="style1"><strong>Authorised Signatory</strong></td>
        </tr>
    </table>

    <div style="margin-top:12px">
        <div style="font-weight:700">Witnesses:</div>
        @if($bond->witnesses && $bond->witnesses->isNotEmpty())
            <ul style="margin:6px 0;padding-left:20px;text-align:left">
                @foreach($bond->witnesses as $w)
                    <li style="text-align:left">{{ $w->name }} @if($w->id_no) — ID: {{ $w->id_no }}@endif @if($w->mobile) — {{ $w->mobile }}@endif</li>
                @endforeach
            </ul>
        @else
            <div class="small">No witnesses recorded.</div>
        @endif
    </div>

</div>

@if(request()->boolean('print'))
<script>
document.addEventListener('DOMContentLoaded', function () {
    window.print();
});
</script>
@endif
</body>
</html>
