<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>Registry Certificate - {{ $registry->registry_code ?? $registry->customer_reg_no }}</title>
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .wrrper{width:990px;margin:0 auto;border:5px solid black;padding:8px}
        table {border-collapse: collapse;width:100%;}
        table, td, th {border: 1px solid black;text-align:center;}
        th{padding:5px;background:#ececec}
        td{padding:10px}
    </style>
</head>
<body>
<div class="wrrper" id="main">
    <table>
        <tr>
            <td style="font-weight:bold;">CIN-U45201UP2019PTC123734</td>
            <td bgcolor="#00FFCC"><strong>REG. NO</strong>&nbsp;{{ $registry->customer_reg_no ?? '' }}</td>
            <td style="text-align:right;font-weight:bold;">MOB. {{ $registry->mobile ?? ($registry->customer?->mobile ?? '') }}</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:center">
                <p style="font-size:36pt;color:red;font-weight:bold;margin:0">HEED REAL</p>
                <p style="font-size:18pt;margin:0">ESTATE PRIVATE LIMITED</p>
                <p style="background:#000080;color:#fff;padding:6px;margin-top:6px;">19A, New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</p>
                <p style="text-align:justify;padding:6px;">CERTIFIED that the associate described in the Schedule here to is registered as per the Company rules and subject to the General Terms & Conditions printed overleaf.</p>
            </td>
        </tr>
    </table>

    <table style="margin-top:8px;">
        <tr>
            <th>Name, D.O.B and Address of Associate</th>
            <td style="text-align:left">{{ $registry->customer?->name ?? '-' }}<br>{{ $registry->associate_address ?? $registry->customer?->address ?? '' }}</td>
            <th>Registry Amount</th>
            <td>{{ number_format((float) ($registry->registry_amount ?? 0), 2) }}</td>
        </tr>
    </table>

    <div style="margin-top:12px;text-align:left">
        <strong>Witness:</strong> {{ $registry->witness_name ?? '-' }}
    </div>

    <div style="margin-top:12px;text-align:center">
        <table>
            <tr>
                <td style="height:80px">Seal with Stamp</td>
                <td>Authorised by</td>
                <td>Authorised Signatory</td>
            </tr>
        </table>
    </div>

    @if($registry->esign_signed)
        <div style="margin-top:12px;text-align:center;color:green;font-weight:bold">E-Signed</div>
    @endif
</div>
</body>
</html>
