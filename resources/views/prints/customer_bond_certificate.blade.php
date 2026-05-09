<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>Registration Certificate - {{ $bond->bond_no ?? '' }}</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        .wrrper{width:990px;margin:0 auto;border:5px solid black;padding:8px}
        table {border-collapse: collapse;width:100%;}
        table, td, th {border: 1px solid black;text-align:center;}
        th{padding:5px;background:#ececec}
        td{padding:10px}
        .style4{height:237px}
        .style3{height:131px}
        .style1{height:78px}
        .style5{width:415px}
        .textboxmain{width:100%}
        .small{font-size:12px;color:#555}
    </style>
</head>
<body>
<div class="wrrper" id="main">
    <table>
        <tr>
            <td style="font-weight:bold;">CIN-U45201UP2019PTC123734</td>
            <td bgcolor="#00FFCC"><strong>CUSTOMER REG. NO</strong>&nbsp;
                <span style="color:red;font-weight:bold">{{ $bond->bond_no ?? '' }}</span>
            </td>
            <td style="text-align:right;font-weight:bold;">MOB. +91-9696446268, 9935142277</td>
        </tr>
        <tr>
            <td colspan="3" class="style4" style="text-align:left">
                <p style="font-size:37pt;color:red;font-weight:bold;margin-top:1px;">HEED REAL</p>
                <p style="margin-top:-35px;font-size:21pt;">ESTATE PRIVATE LIMITED</p>
                <p style="padding:3px;background-color:#000080;color:white;font-size:15pt;margin-top:-10px;">19A ,New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</p>
                <p style="font-size:12pt;font-weight:bold;text-align:justify;">CERTIFIED that the associate described in Schedule here to Registered Joint Venture Of Consideration as shown in Schedule under Plan of Company subject to the regular payment of subscription(s) has mentioned in the said schedule and also subject to "general terms & conditions" printed over leaf...</p>
            </td>
        </tr>
    </table>

    <table>
        <tr>
            <th>Regd.No & Date of Commenement</th>
            <th>Plan Name / Term</th>
            <th>Mode of Payment</th>
            <th>Consideration Amount</th>
            <th>Installment of subscription Payment</th>
        </tr>
        <tr>
            <td>{{ optional($bond->bond_date)->format('d/m/Y') ?? '' }}</td>
            <td>{{ $bond->bond_type ?? '-' }}</td>
            <td>{{ ucfirst($bond->bayana_mode ?? '-') }}</td>
            <td>{{ number_format((float) ($bond->total_amount ?? $bond->bond_amount ?? 0), 2) }}</td>
            <td>{{ number_format((float) ($bond->amount ?? 0), 2) }}</td>
        </tr>
    </table>

    <table>
        <tr>
            <th>Installment Due Date</th>
            <th>Booking Amount</th>
            <th>Date Of Last Payment</th>
            <th>Expiry Date</th>
            <th>Agency ID</th>
        </tr>
        <tr>
            <td>{{ optional($bond->last_date)->format('d/m/Y') ?? '-' }}</td>
            <td>{{ number_format((float) ($bond->amount ?? 0), 2) }}</td>
            <td>-</td>
            <td>-</td>
            <td>{{ $bond->broker?->id ?? '-' }}</td>
        </tr>
    </table>

    <table>
        <tr>
            <th rowspan="4">Name, D.O.B and Address of Associate</th>
            <td rowspan="4" class="style5" style="text-align:left">{{ $bond->customer?->name ?? '-' }}<br>{{ $bond->customer?->address ?? '' }}</td>
            <th colspan="2">Arazi No.</th>
        </tr>
        <tr>
            <td colspan="2">{{ $bond->arazi?->legacy_arazi_code ?? $bond->arazi?->plot_number ?? '-' }}</td>
        </tr>
        <tr>
            <th colspan="2">Plot No./Plot Size</th>
        </tr>
        <tr>
            <td colspan="2">{{ $bond->arazi?->plot_number ?? '-' }} / {{ $bond->land_size ?? $bond->arazi?->size ?? '-' }}</td>
        </tr>
        <tr>
            <th>Nominee's Name D.O.B and Relationship</th>
            <td colspan="2" class="style5">-</td>
            <td>Aadhar/PAN/Voter/D.L NO</td>
            <td>{{ $bond->customer?->id_document_no ?? '-' }}</td>
        </tr>
    </table>

    <table>
        <tr>
            <th>EXPECTED SUM PAYABLE RUPEES</th>
            <td>{{ $bond->total_amount ?? $bond->bond_amount ?? 0 }}</td>
        </tr>
        <tr>
            <td rowspan="3" style="font-weight:bold;">Date</td>
            <td>For: ____________________________</td>
        </tr>
    </table>

    <table>
        <tr>
            <td style="font-weight:bold;" colspan="2"></td>
            <td style="text-align:right;font-weight:bold;" colspan="2">MOB. +91-9696446268, 9935142277</td>
        </tr>
        <tr>
            <td colspan="4" class="style3" style="text-align:left">
                <p style="font-size:37pt;color:red;font-weight:bold;margin-top:5px;">HEED REAL</p>
                <p style="margin-top:-35px;font-size:21pt;">ESTATE PRIVATE LIMITED</p>
                <p style="padding:3px;background-color:#000080;color:white;font-size:15pt;margin-top:-10px;">19A ,New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</p>
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
            <td colspan="3">{{ number_format((float) ($bond->total_amount ?? $bond->bond_amount ?? 0), 2) }}</td>
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
            <ul>
                @foreach($bond->witnesses as $w)
                    <li>{{ $w->name }} @if($w->id_no) — ID: {{ $w->id_no }}@endif @if($w->mobile) — {{ $w->mobile }}@endif</li>
                @endforeach
            </ul>
        @else
            <div class="small">No witnesses recorded.</div>
        @endif
    </div>

</div>
</body>
</html>
