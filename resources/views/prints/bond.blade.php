<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>Bond - {{ $bond->bond_no ?? '' }}</title>
    <style>
        @page { margin: 20mm }
        body { font-family: Arial, Helvetica, sans-serif; color: #111; }
        .container { max-width: 900px; margin: 0 auto; }
        .header { text-align: center; margin-bottom: 8px }
        .company { font-size: 18px; font-weight: 700 }
        .meta { font-size: 12px; color: #333 }
        .grid { display: grid; grid-template-columns: 1fr 1fr; gap: 8px; margin-top: 12px }
        .card { border: 1px solid #ddd; padding: 10px; border-radius: 4px }
        .label { font-weight: 700; display: inline-block; width: 140px }
        .value { display: inline-block }
        h1.title { font-size: 20px; margin: 0 }
        .section-title { font-weight: 700; margin-top: 12px; border-bottom: 1px solid #eee; padding-bottom: 6px }
        .witness-list { margin: 6px 0 0 0; padding-left: 18px }
        .notes { white-space: pre-wrap; }
        .sig { display: flex; justify-content: space-between; margin-top: 28px }
        .sig .box { width: 32%; text-align: center }
        .small { font-size: 12px; color: #555 }
        @media print {
            .container { max-width: 100%; }
            .card { border: none }
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="header">
            <div class="company">{{ config('app.name') }}</div>
            <div class="meta">{{ config('app.address') ?? '' }}</div>
            <h1 class="title">{{ $title ?? 'Kisan Bond' }}</h1>
        </div>

        <div class="grid">
            <div class="card">
                <div><span class="label">Bond No:</span> <span class="value">{{ $bond->bond_no }}</span></div>
                <div><span class="label">Bond Date:</span> <span class="value">{{ optional($bond->bond_date)->format('d-m-Y') ?? '-' }}</span></div>
                <div><span class="label">Arazi:</span> <span class="value">{{ $bond->arazi?->plot_number ?? '-' }}</span></div>
                <div><span class="label">Kisan:</span> <span class="value">{{ $bond->kisan?->name ?? '-' }}</span></div>
                <div><span class="label">Mobile:</span> <span class="value">{{ $bond->mobile ?? ($bond->kisan?->mobile ?? '-') }}</span></div>
                <div><span class="label">Land Size:</span> <span class="value">{{ $bond->land_size ?? $bond->arazi?->size ?? '-' }}</span></div>
            </div>

            <div class="card">
                <div><span class="label">Sale Land:</span> <span class="value">{{ number_format((float) ($bond->sale_land ?? 0), 2) }}</span></div>
                <div><span class="label">Sale Rate:</span> <span class="value">{{ number_format((float) ($bond->sale_rate ?? 0), 2) }}</span></div>
                <div><span class="label">Total Amount:</span> <span class="value">{{ number_format((float) ($bond->total_amount ?? $bond->bond_amount ?? 0), 2) }}</span></div>
                <div><span class="label">Bayana Mode:</span> <span class="value">{{ ucfirst($bond->bayana_mode ?? '-') }}</span></div>
                <div><span class="label">Type:</span> <span class="value">{{ $bond->bond_type ?? '-' }}</span></div>
                <div><span class="label">Amount:</span> <span class="value">{{ number_format((float) ($bond->amount ?? 0), 2) }}</span></div>
                <div><span class="label">Balance:</span> <span class="value">{{ number_format((float) ($bond->balance ?? 0), 2) }}</span></div>
                <div><span class="label">Last Date:</span> <span class="value">{{ optional($bond->last_date)->format('d-m-Y') ?? '-' }}</span></div>
            </div>
        </div>

        <div class="section-title">Broker / Payments</div>
        <div class="card">
            <div><span class="label">Broker:</span> <span class="value">{{ $bond->broker?->name ?? '-' }}</span></div>
            <div><span class="label">Broker Payment:</span> <span class="value">{{ number_format((float) ($bond->broker_payment ?? 0), 2) }}</span></div>
            <div><span class="label">Broker Paid:</span> <span class="value">{{ number_format((float) ($bond->broker_paid ?? 0), 2) }}</span></div>
            <div><span class="label">Broker Balance:</span> <span class="value">{{ number_format((float) ($bond->broker_balance ?? 0), 2) }}</span></div>
            <div><span class="label">Broker Comment:</span> <span class="value">{{ $bond->broker_comment ?? '-' }}</span></div>
        </div>

        <div class="section-title">Witnesses</div>
        <div class="card">
            @if($bond->witnesses->isNotEmpty())
                <ol class="witness-list">
                    @foreach($bond->witnesses as $w)
                        <li><strong>{{ $w->name }}</strong>@if($w->id_no) — ID: {{ $w->id_no }}@endif @if($w->mobile) — {{ $w->mobile }}@endif</li>
                    @endforeach
                </ol>
            @else
                <div class="small">No witnesses recorded.</div>
            @endif
        </div>

        <div class="section-title">Notes</div>
        <div class="card notes">{{ $bond->notes ?? '-' }}</div>

        <div class="section-title">Kisan Comment</div>
        <div class="card notes">{{ $bond->kisan_comment ?? '-' }}</div>

        <div class="sig">
            <div class="box">_________________________<br>Seller / Kisan</div>
            <div class="box">_________________________<br>Broker</div>
            <div class="box">_________________________<br>Authorized Signatory</div>
        </div>
    </div>

    <script>
        if (window.location.search.indexOf('print') !== -1) {
            window.print();
        }
    </script>
</body>
</html>
