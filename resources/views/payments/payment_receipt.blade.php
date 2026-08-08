<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Receipt {{ $receipt['receipt_no'] ?? '' }}</title>
    <style>
        * { box-sizing: border-box; margin: 0; padding: 0; }
        body {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            color: #000;
            background: #fff;
            padding: 16px;
        }
        @media print {
            .no-print { display: none !important; }
            body { padding: 4px; }
            .cut-line { page-break-inside: avoid; }
        }

        /* Toolbar */
        .toolbar { display: flex; gap: 8px; margin-bottom: 14px; align-items: center; }
        .toolbar a, .toolbar button {
            padding: 5px 14px; border: 1px solid #555;
            background: #f5f5f5; cursor: pointer; font-size: 12px;
            text-decoration: none; color: #000;
        }
        .toolbar .btn-print { background: #0d6efd; color: #fff; border-color: #0d6efd; }

        /* ── Receipt card ── */
        .receipt {
            width: 100%;
            border: 2px solid #1a3a6b;
            border-radius: 6px;
            overflow: hidden;
        }

        /* Header band */
        .receipt-header {
            background: #1a3a6b;
            color: #fff;
            padding: 10px 16px;
            display: flex;
            align-items: center;
            justify-content: space-between;
        }
        .receipt-header .brand-name {
            font-size: 18px;
            font-weight: 700;
            letter-spacing: 1px;
            text-transform: uppercase;
        }
        .receipt-header .brand-sub {
            font-size: 11px;
            opacity: .75;
            margin-top: 1px;
        }
        .receipt-header .receipt-label {
            text-align: right;
            font-size: 12px;
            font-weight: 700;
            letter-spacing: .5px;
            text-transform: uppercase;
            opacity: .9;
        }

        /* Body two columns */
        .receipt-body {
            display: flex;
            border-top: none;
        }
        .col-left {
            flex: 1;
            padding: 12px 16px;
            border-right: 2px solid #1a3a6b;
        }
        .col-right {
            width: 200px;
            padding: 12px 16px;
            background: #f0f4fa;
            display: flex;
            flex-direction: column;
            justify-content: space-around;
        }

        /* Info rows */
        .info-row { margin-bottom: 9px; }
        .info-row:last-child { margin-bottom: 0; }
        .lbl {
            font-size: 10px;
            text-transform: uppercase;
            letter-spacing: .5px;
            color: #5a6a8a;
            font-weight: 700;
        }
        .val {
            font-size: 15px;
            font-weight: 700;
            color: #0d1f44;
            margin-top: 1px;
        }

        /* Amount rows */
        .amt-row { margin-bottom: 10px; text-align: right; }
        .amt-row:last-child { margin-bottom: 0; }
        .amt-lbl {
            font-size: 10px;
            text-transform: uppercase;
            letter-spacing: .5px;
            color: #5a6a8a;
            font-weight: 700;
        }
        .amt-val {
            font-size: 17px;
            font-weight: 700;
            color: #0d1f44;
            margin-top: 1px;
        }
        .amt-val.balance { color: #b91c1c; }
        .amt-val.paid    { color: #15803d; }
        .amt-val.total   { color: #1a3a6b; }

        /* Thin divider inside left col */
        .inner-divider {
            border: none;
            border-top: 1px dashed #c8d5e8;
            margin: 8px 0;
        }
    </style>
    @if(!empty($autoPrint) && ($receipt ?? false))
        <script>window.addEventListener('load', function(){ window.print(); });</script>
    @endif
</head>
<body>

{{-- Toolbar --}}
<div class="no-print toolbar">
    <a href="{{ url()->previous() !== url()->current() ? url()->previous() : route('dashboard') }}">← Back</a>
    @if($receipt ?? false)
        <button class="btn-print" onclick="window.print()">🖨 Print</button>
    @endif
    <form method="get" action="{{ $lookupAction ?? route('customer-bond-payments.receipt') }}" style="display:inline-flex;gap:6px;">
        <input type="text" name="{{ $lookupParam ?? 'entry_no' }}" value="{{ $lookupKey ?? '' }}"
               placeholder="e.g. CP00001"
               style="padding:4px 8px;border:1px solid #999;font-size:12px;width:140px;">
        <button type="submit" style="padding:4px 10px;border:1px solid #555;font-size:12px;cursor:pointer;">Open</button>
    </form>
</div>

@if($receipt ?? false)
@php $r = $receipt; @endphp

<div class="receipt">

    {{-- Header --}}
    <div class="receipt-header">
        <div>
            <div class="brand-name">Kisan Land Management</div>
            <div class="brand-sub">Payment Receipt</div>
        </div>
        <div class="receipt-label">
            Receipt No
        </div>
    </div>

    {{-- Body --}}
    <div class="receipt-body">

        {{-- Left: labels --}}
        <div class="col-left">
            <div class="info-row">
                <div class="lbl">Bond No</div>
                <div class="val">{{ $r['bond_no'] ?? '—' }}</div>
            </div>
            <hr class="inner-divider">
            <div style="display:flex; gap:24px;">
                <div class="info-row">
                    <div class="lbl">Receipt No</div>
                    <div class="val">{{ $r['receipt_no'] ?? '—' }}</div>
                </div>
                <div class="info-row">
                    <div class="lbl">Installment No</div>
                    <div class="val">{{ $r['installment_no'] ?? '—' }}</div>
                </div>
            </div>
            <hr class="inner-divider">
            <div style="display:flex; gap:24px;">
                <div class="info-row">
                    <div class="lbl">Date of Entry</div>
                    <div class="val">{{ $r['receipt_date'] ?? '—' }}</div>
                </div>
                <div class="info-row">
                    <div class="lbl">Bond Date</div>
                    <div class="val">{{ $r['bond_date'] ?? '—' }}</div>
                </div>
                <div class="info-row">
                    <div class="lbl">Bond End Date</div>
                    <div class="val">{{ $r['installment_end_date'] ?? '—' }}</div>
                </div>
            </div>
        </div>

        {{-- Right: amounts --}}
        <div class="col-right">
            <div class="amt-row">
                <div class="amt-lbl">Bond Amount</div>
                <div class="amt-val total">Rs. {{ inr($r['total_amount'] ?? 0, 2) }}</div>
            </div>
            <div class="amt-row">
                <div class="amt-lbl">Total Paid</div>
                <div class="amt-val paid">Rs. {{ inr($r['paid_amount'] ?? 0, 2) }}</div>
            </div>
            <div class="amt-row">
                <div class="amt-lbl">Balance</div>
                <div class="amt-val balance">Rs. {{ inr($r['balance_amount'] ?? 0, 2) }}</div>
            </div>
        </div>

    </div>
</div>

@else
    <p class="no-print" style="color:#666; margin-top:10px;">Enter a receipt number above to load the receipt.</p>
@endif

</body>
</html>
