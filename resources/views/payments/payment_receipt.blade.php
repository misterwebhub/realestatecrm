<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>@if($receipt) Receipt {{ $receipt['receipt_no'] }} @else Payment receipt @endif</title>
    <style>
        * { box-sizing: border-box; }
        body {
            font-family: DejaVu Sans, Helvetica, Arial, sans-serif;
            font-size: 12px;
            color: #000;
            margin: 0;
            padding: 16px 20px 24px;
            background: #fff;
        }
        .no-print { margin-bottom: 12px; }
        @media print {
            .no-print { display: none !important; }
            body { padding: 8px; }
        }
        .toolbar { display: flex; flex-wrap: wrap; gap: 8px; align-items: center; }
        .toolbar a, .toolbar button {
            display: inline-block;
            padding: 6px 12px;
            border: 1px solid #333;
            background: #f5f5f5;
            color: #000;
            text-decoration: none;
            font-size: 12px;
            cursor: pointer;
        }
        .toolbar .btn-primary { background: #0d6efd; color: #fff; border-color: #0d6efd; }
        .receipt-head { text-align: center; margin-bottom: 14px; }
        .receipt-head h1 { font-size: 18px; margin: 0 0 6px; font-weight: 700; text-transform: uppercase; letter-spacing: 0.5px; }
        .receipt-head .rn { font-size: 13px; font-weight: 700; margin: 4px 0; }
        .receipt-head .dt { font-size: 12px; }
        .box { border: 2px solid #000; width: 100%; border-collapse: collapse; }
        .box td { border: 1px solid #000; padding: 10px 12px; vertical-align: top; }
        .box .lbl { font-weight: 700; width: 28%; white-space: nowrap; }
        .box .val { width: 72%; }
        .amount-row td { vertical-align: middle; }
        .seal { width: 32%; font-weight: 700; font-size: 11px; min-height: 56px; }
        .amount-big { width: 28%; text-align: center; font-size: 16px; font-weight: 700; }
        .methods { width: 40%; font-size: 11px; line-height: 1.6; }
        .methods span { margin-right: 10px; white-space: nowrap; }
        .tick { font-weight: 700; }
        .footer-sign { margin-top: 20px; width: 100%; border-collapse: collapse; }
        .footer-sign td { padding: 8px 6px; vertical-align: bottom; font-size: 11px; width: 25%; }
        .footer-sign .line { border-bottom: 1px solid #000; min-height: 28px; margin-top: 4px; }
        .alert { padding: 10px; border: 1px solid #856404; background: #fff3cd; color: #856404; margin-bottom: 12px; }
        form.lookup { margin-bottom: 12px; }
        form.lookup input { padding: 6px 8px; border: 1px solid #999; width: 220px; }
    </style>
    @if(!empty($autoPrint) && $receipt)
        <script>window.addEventListener('load', function () { window.print(); });</script>
    @endif
</head>
<body>
@if(($toolbar ?? true) === true)
    <div class="no-print">
        @if(!$receipt && ($lookupKey ?? '') !== '')
            <div class="alert">No receipt found for this number.</div>
        @endif
        <div class="toolbar">
            <a href="{{ url()->previous() !== url()->current() ? url()->previous() : route('dashboard') }}">Back</a>
            @if($receipt)
                <button type="button" class="btn-primary" onclick="window.print()">Print</button>
                @if(!empty($pdfUrl))
                    <a href="{{ $pdfUrl }}" target="_blank" rel="noopener">Download PDF</a>
                @endif
            @endif
        </div>
        <form class="lookup" method="get" action="{{ $lookupAction ?? route('kisan-payment.print') }}">
            <label>Receipt / entry no.&nbsp;</label>
            <input type="text" name="{{ $lookupParam ?? 'receipt_no' }}" value="{{ $lookupKey ?? '' }}" placeholder="e.g. KP00001 or CP00001">
            <button type="submit">Open</button>
        </form>
    </div>
@endif

@if($receipt)
    @php($f = $receipt['method_flags'])
    <div class="receipt-head">
        <h1>Payment receipt</h1>
        <div class="rn">Receipt No. {{ $receipt['receipt_no'] }}</div>
        <div class="dt">Date: {{ $receipt['receipt_date'] }}</div>
    </div>

    <table class="box" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td class="lbl">Received today:</td>
            <td class="val" colspan="2">{{ $receipt['received_from'] }}</td>
        </tr>
        <tr>
            <td class="lbl">Towards (details):</td>
            <td class="val" colspan="2">{{ $receipt['hand_in'] }}</td>
        </tr>
        <tr>
            <td class="lbl">Amount in words (INR):</td>
            <td class="val" colspan="2">{{ $receipt['amount_in_words'] }}</td>
        </tr>
        <tr class="amount-row">
            <td class="seal">Payee (official seal)<br><span style="font-weight:400;font-size:10px;">{{ $receipt['payee_name'] }}</span></td>
            <td class="amount-big">{{ $receipt['amount_formatted'] }}</td>
            <td class="methods">
                <span><span class="tick">{{ $f['cash'] ? '☑' : '☐' }}</span> Cash</span>
                <span><span class="tick">{{ $f['transfer'] ? '☑' : '☐' }}</span> Bank transfer</span>
                <span><span class="tick">{{ $f['upi'] ? '☑' : '☐' }}</span> UPI</span>
                <span><span class="tick">{{ $f['cheque'] ? '☑' : '☐' }}</span> Cheque</span>
                @if($f['other'] || (!$f['cash'] && !$f['transfer'] && !$f['upi'] && !$f['cheque'] && $receipt['method_raw'] !== '-'))
                    <span><span class="tick">{{ $f['other'] ? '☑' : '☐' }}</span> Other</span>
                @endif
                @if($receipt['method_raw'] !== '-')
                    <div style="margin-top:6px;font-size:10px;">Noted: {{ $receipt['method_raw'] }}</div>
                @endif
            </td>
        </tr>
    </table>

    @if(!empty($receipt['bond_no']) && $receipt['bond_no'] !== '-')
    <table class="box" cellspacing="0" cellpadding="0" width="100%" style="margin-top:10px;">
        <tr>
            <td class="lbl" style="background:#f8f8f8;font-weight:700;" colspan="4">Bond Details</td>
        </tr>
        <tr>
            <td class="lbl">Bond No</td>
            <td class="val">{{ $receipt['bond_no'] }}</td>
            <td class="lbl">Bond Date</td>
            <td class="val">{{ $receipt['bond_date'] ?? '-' }}</td>
        </tr>
        <tr>
            <td class="lbl">Installment No</td>
            <td class="val">{{ $receipt['installment_no'] ?? '-' }}</td>
            <td class="lbl">Installment End Date</td>
            <td class="val">{{ $receipt['installment_end_date'] ?? '-' }}</td>
        </tr>
        @if(!empty($receipt['installment_amount']) && $receipt['installment_amount'] > 0)
        <tr>
            <td class="lbl">Per Installment</td>
            <td class="val">Rs. {{ number_format($receipt['installment_amount'], 2) }}</td>
            <td></td><td></td>
        </tr>
        @endif
        <tr>
            <td class="lbl">Total Bond Amount</td>
            <td class="val">Rs. {{ number_format($receipt['total_amount'] ?? 0, 2) }}</td>
            <td class="lbl">Amount Paid</td>
            <td class="val">Rs. {{ number_format($receipt['paid_amount'] ?? 0, 2) }}</td>
        </tr>
        <tr>
            <td class="lbl" style="font-weight:700;">Balance Left</td>
            <td class="val" style="font-weight:700;">Rs. {{ number_format($receipt['balance_amount'] ?? 0, 2) }}</td>
            <td></td><td></td>
        </tr>
    </table>
    @endif

    @if(!empty($receipt['witnesses']) && count($receipt['witnesses']) > 0)
    <table class="box" cellspacing="0" cellpadding="0" width="100%" style="margin-top:10px;">
        <tr>
            <td class="lbl" style="background:#f8f8f8;font-weight:700;" colspan="4">Witnesses</td>
        </tr>
        @foreach($receipt['witnesses'] as $i => $w)
        <tr>
            <td class="lbl">Witness {{ $i + 1 }}</td>
            <td class="val">{{ $w['name'] }}</td>
            <td class="lbl">Mobile</td>
            <td class="val">{{ $w['mobile'] ?? '-' }}</td>
        </tr>
        @endforeach
    </table>
    @endif

    <table class="footer-sign" cellspacing="0">
        <tr>
            <td>Financial officer:<div class="line"></div></td>
            <td>Cashier:<div class="line"></div></td>
            <td>Audit:<div class="line"></div></td>
            <td>Attn:<div class="line"></div></td>
        </tr>
    </table>
@elseif(($toolbar ?? true) && ($lookupKey ?? '') === '')
    <p class="no-print" style="color:#555;">Enter a receipt number above, or open print from the payment list.</p>
@endif
</body>
</html>
