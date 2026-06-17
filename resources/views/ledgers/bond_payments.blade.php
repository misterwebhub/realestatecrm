@extends('layouts.app')

@section('content')
@php
    $isCustomerLedger = $isCustomerLedger ?? false;
    $selectedBond     = $selectedBond ?? null;

    $overallTotal   = $bonds->sum('total');
    $overallPaid    = $bonds->sum('paid');
    $overallBalance = $bonds->sum('balance');

    // running balance for entries
    $runningBalance = 0;
    $entriesWithBalance = collect($entries)->map(function($e) use (&$runningBalance) {
        if(!empty($e['is_debit'])) {
            $runningBalance -= $e['amount'];
        } else {
            $runningBalance += $e['amount'];
        }
        return array_merge($e, ['running_balance' => $runningBalance]);
    });

    // When a specific bond is selected (customer ledger bond-detail view), use entries for totals
    $useEntriesTotals = !$isCustomerLedger || $selectedBondId;
    $totalCredit = $useEntriesTotals ? collect($entries)->where('is_debit', false)->sum('amount') : $overallPaid;
    $totalDebit  = $useEntriesTotals ? collect($entries)->where('is_debit', true)->sum('amount')  : 0;
    $netCollected = $totalCredit - $totalDebit;
@endphp

<style>
.ledger-stat { border-radius: 10px; padding: 18px 20px; }
.ledger-stat .stat-label { font-size: 12px; font-weight: 600; text-transform: uppercase; letter-spacing: .5px; opacity: .75; margin-bottom: 4px; }
.ledger-stat .stat-value { font-size: 22px; font-weight: 700; line-height: 1.1; }
.ledger-stat .stat-sub   { font-size: 11px; opacity: .7; margin-top: 2px; }

.bond-row:hover { background: #f0f4ff !important; cursor: pointer; }
.bond-row.selected { background: #e8f0fe !important; }

.type-badge { display:inline-block; padding: 2px 9px; border-radius: 20px; font-size: 11px; font-weight: 600; }
.type-advance    { background:#dbeafe; color:#1d4ed8; }
.type-installment{ background:#dcfce7; color:#15803d; }
.type-final      { background:#f3e8ff; color:#7e22ce; }
.type-penalty    { background:#fee2e2; color:#b91c1c; }
.type-return     { background:#fff7ed; color:#c2410c; }
.type-discount   { background:#fef9c3; color:#854d0e; }
.type-other      { background:#f1f5f9; color:#475569; }

.entries-table th { background: #f8fafc; font-size: 12px; font-weight: 600; text-transform: uppercase; letter-spacing: .4px; color: #64748b; border-bottom: 2px solid #e2e8f0; white-space: nowrap; }
.entries-table td { font-size: 13px; vertical-align: middle; border-bottom: 1px solid #f1f5f9; }
.entries-table tr:last-child td { border-bottom: none; }
.entries-table tr:hover td { background: #fafbff; }

.running-bal { font-size: 12px; font-weight: 600; }

.filter-card { border: 1px solid #e2e8f0; border-radius: 10px; background: #fff; padding: 16px 20px; margin-bottom: 20px; }

.progress-thin { height: 5px; border-radius: 3px; }

@media print {
    @page { margin: 10mm 8mm; size: A4 landscape; }

    /* ── Hide everything except our print blocks ── */
    .app-sidebar,
    .app-header,
    .app-footer,
    .no-print,
    .filter-card,
    .row.g-3.mb-4,
    .card:not(.print-bond-summary):not(.print-entries) { display: none !important; }

    /* ── Reset layout wrappers ── */
    body, .app-wrapper, .app-main, .app-content, .container-fluid {
        display: block !important;
        width: 100% !important;
        margin: 0 !important;
        padding: 0 !important;
        background: #fff !important;
    }

    /* ── Show print-only blocks ── */
    .print-title, .print-stats { display: flex !important; }

    /* ── Print title bar ── */
    .print-title {
        display: flex !important;
        justify-content: space-between !important;
        align-items: flex-end !important;
        border-bottom: 2px solid #000 !important;
        padding-bottom: 6px !important;
        margin-bottom: 8px !important;
    }
    .print-title h4 { font-size: 15px !important; font-weight: 800 !important; margin: 0 !important; color: #000 !important; }
    .print-title .print-date { font-size: 10px !important; color: #555 !important; }

    /* ── Summary stats strip ── */
    .print-stats {
        display: flex !important;
        gap: 20px !important;
        margin-bottom: 8px !important;
        padding: 6px 10px !important;
        background: #f4f4f4 !important;
        border: 1px solid #ddd !important;
        border-radius: 4px !important;
    }
    .print-stats .ps-item { font-size: 10px !important; color: #000 !important; }
    .print-stats .ps-item strong { font-size: 12px !important; display: block !important; }

    /* ── Bond summary card ── */
    .print-bond-summary { display: block !important; border: none !important; box-shadow: none !important; margin: 0 !important; }
    .print-bond-summary .card-header {
        background: #fff !important;
        border-bottom: 2px solid #333 !important;
        padding: 4px 0 6px !important;
    }
    .print-bond-summary .card-header span { font-size: 12px !important; font-weight: 700 !important; color: #000 !important; }
    .print-bond-summary .card-body { padding: 0 !important; }

    /* ── Table ── */
    .print-bond-summary table { width: 100% !important; border-collapse: collapse !important; font-size: 9.5px !important; }
    .print-bond-summary thead tr { background: #ddd !important; }
    .print-bond-summary th {
        background: #ddd !important; -webkit-print-color-adjust: exact; print-color-adjust: exact;
        color: #000 !important; font-size: 8.5px !important; font-weight: 700 !important;
        text-transform: uppercase !important; border: 1px solid #aaa !important;
        padding: 4px 5px !important; white-space: nowrap !important;
    }
    .print-bond-summary td {
        border: 1px solid #ccc !important; padding: 3px 5px !important;
        color: #000 !important; vertical-align: middle !important;
    }
    .print-bond-summary tr:nth-child(even) td { background: #f9f9f9 !important; -webkit-print-color-adjust: exact; print-color-adjust: exact; }

    /* Arazi badge */
    .print-bond-summary td span[style*="background:#1a3a6b"] {
        background: #222 !important; -webkit-print-color-adjust: exact; print-color-adjust: exact;
        color: #fff !important; padding: 1px 4px !important; font-size: 8px !important; border-radius: 2px !important;
    }

    /* Hide progress bar div, show % number */
    .print-bond-summary .no-print-progress-bar { display: none !important; }

    /* Show print-only bond header inside entries card */
    .print-bond-header { display: block !important; }

    /* ── Entries card (bond-level print) ── */
    .print-entries { display: block !important; border: none !important; box-shadow: none !important; margin: 0 !important; }
    .print-entries table { width: 100% !important; border-collapse: collapse !important; font-size: 9.5px !important; }
    .print-entries th {
        background: #ddd !important; -webkit-print-color-adjust: exact; print-color-adjust: exact;
        color: #000 !important; font-size: 8.5px !important; font-weight: 700 !important;
        text-transform: uppercase !important; border: 1px solid #aaa !important;
        padding: 4px 5px !important; white-space: nowrap !important;
    }
    .print-entries td {
        border: 1px solid #ccc !important; padding: 3px 5px !important;
        color: #000 !important; vertical-align: middle !important; font-size: 9px !important;
    }
    .print-entries tr:nth-child(even) td { background: #f9f9f9 !important; -webkit-print-color-adjust: exact; print-color-adjust: exact; }
    .print-entries tfoot td { background: #eee !important; -webkit-print-color-adjust: exact; print-color-adjust: exact; font-weight: 700 !important; }
    .type-badge { border: 1px solid #aaa !important; background: #fff !important; color: #000 !important; }
}
</style>

{{-- ── PAGE HEADER ── --}}
<div class="d-flex align-items-center flex-wrap gap-2 mb-3 no-print">
    <div>
        <h4 class="mb-0 fw-bold">{{ $title }}</h4>
        <span class="text-muted small">Track all bond payments, credits &amp; debits</span>
    </div>
    <div class="d-flex gap-2 ms-auto">
        @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
            @if(!empty($exportLedgerCsvUrl))
                <a href="{{ $exportLedgerCsvUrl }}" class="btn btn-sm btn-outline-success">
                    <i class="bi bi-download"></i> Export CSV
                </a>
            @endif
        @endif
        <button class="btn btn-sm btn-outline-secondary" onclick="window.print()">
            <i class="bi bi-printer"></i> Print
        </button>
    </div>
</div>

{{-- ── BOND DETAIL CARD (customer ledger, single bond view) ── --}}
@if($isCustomerLedger && !empty($selectedBond))
@php
    $bd        = $selectedBond;
    $bdTotal   = (float) ($bd->total_amount ?? $bd->bond_amount ?? 0);
    $bdPaid    = (float) ($bd->total_paid ?? 0);
    $bdBalance = max($bdTotal - $bdPaid, 0);
    $bdPct     = $bdTotal > 0 ? min(round(($bdPaid / $bdTotal) * 100), 100) : 0;
    $bdAraziCode = $bd->arazi ? ($bd->arazi->legacy_arazi_code ?: ($bd->arazi->plot_number ?? '-')) : ($bd->arazi_code ?? '-');
    $bdPlots   = $bd->plots->map(fn($p) => $p->title ?? 'Plot-'.$p->id)->implode(', ') ?: '-';
@endphp
<div class="card border-0 shadow-sm mb-4 no-print" style="border-left:4px solid #1a3a6b !important; border-radius:10px;">
    <div class="card-header bg-white border-bottom py-3 d-flex align-items-center gap-2 flex-wrap">
        <i class="bi bi-file-earmark-text-fill text-primary fs-5"></i>
        <span class="fw-bold fs-6">Bond Details — {{ $bd->bond_no }}</span>
        <a href="{{ url()->current() }}" class="btn btn-sm btn-outline-secondary ms-auto" style="font-size:11px;">
            <i class="bi bi-arrow-left"></i> All Bonds
        </a>
        <a href="{{ route('customer-bonds.edit', $bd->id) }}" class="btn btn-sm btn-outline-primary" style="font-size:11px;">
            <i class="bi bi-pencil"></i> Edit Bond
        </a>
        <a href="{{ route('customer-bonds.print', $bd->id) }}" target="_blank" class="btn btn-sm btn-outline-secondary" style="font-size:11px;">
            <i class="bi bi-printer"></i> Print Bond
        </a>
    </div>
    <div class="card-body py-3">
        <div class="row g-3">

            {{-- Left column: Customer & Bond info --}}
            <div class="col-md-4">
                <div class="mb-3">
                    <div class="text-muted fw-semibold mb-2" style="font-size:11px;text-transform:uppercase;letter-spacing:.5px;">Customer</div>
                    <div class="fw-bold fs-6">{{ $bd->customer?->name ?? '-' }}</div>
                    @if($bd->customer?->mobile)
                        <div class="text-muted small"><i class="bi bi-telephone me-1"></i>{{ $bd->customer->mobile }}</div>
                    @endif
                    @if($bd->customer?->secondary_mobile)
                        <div class="text-muted small"><i class="bi bi-telephone me-1"></i>{{ $bd->customer->secondary_mobile }}</div>
                    @endif
                    @if($bd->customer?->address)
                        <div class="text-muted small mt-1"><i class="bi bi-geo-alt me-1"></i>{{ $bd->customer->address }}</div>
                    @endif
                </div>
                <div>
                    <div class="text-muted fw-semibold mb-1" style="font-size:11px;text-transform:uppercase;letter-spacing:.5px;">Broker / Agent</div>
                    <div class="small">{{ $bd->broker?->name ?? 'None' }}</div>
                </div>
            </div>

            {{-- Middle column: Land details --}}
            <div class="col-md-4">
                <div class="text-muted fw-semibold mb-2" style="font-size:11px;text-transform:uppercase;letter-spacing:.5px;">Land Details</div>
                <table class="table table-sm mb-0" style="font-size:13px;">
                    <tr>
                        <td class="text-muted ps-0" style="width:40%;border:none;">Arazi No</td>
                        <td style="border:none;">
                            <span style="background:#1a3a6b;color:#fff;border-radius:3px;padding:1px 8px;font-size:12px;font-weight:700;">{{ $bdAraziCode }}</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="text-muted ps-0" style="border:none;">Plot(s)</td>
                        <td style="border:none;font-weight:600;">{{ $bdPlots }}</td>
                    </tr>
                    <tr>
                        <td class="text-muted ps-0" style="border:none;">Land Size</td>
                        <td style="border:none;">{{ $bd->land_size ?? $bd->sale_land ?? '-' }} {{ $bd->land_size ? 'Gaz' : '' }}</td>
                    </tr>
                    <tr>
                        <td class="text-muted ps-0" style="border:none;">Sale Rate</td>
                        <td style="border:none;">{{ $bd->sale_rate ? '₹'.number_format((float)$bd->sale_rate, 2).' /Gaz' : '-' }}</td>
                    </tr>
                    <tr>
                        <td class="text-muted ps-0" style="border:none;">Bond Date</td>
                        <td style="border:none;">{{ optional($bd->bond_date)->format('d M Y') ?? '-' }}</td>
                    </tr>
                    @if($bd->expiry_date)
                    <tr>
                        <td class="text-muted ps-0" style="border:none;">Expiry Date</td>
                        <td style="border:none;">{{ optional($bd->expiry_date)->format('d M Y') }}</td>
                    </tr>
                    @endif
                    @if($bd->no_of_months)
                    <tr>
                        <td class="text-muted ps-0" style="border:none;">Installments</td>
                        <td style="border:none;">{{ $bd->no_of_months }} months @ ₹{{ number_format((float)$bd->installment_amount, 2) }}</td>
                    </tr>
                    @endif
                </table>
            </div>

            {{-- Right column: Financial summary --}}
            <div class="col-md-4">
                <div class="text-muted fw-semibold mb-2" style="font-size:11px;text-transform:uppercase;letter-spacing:.5px;">Financial Summary</div>
                <div class="d-flex flex-column gap-2">
                    <div class="d-flex justify-content-between align-items-center p-2 rounded" style="background:#f8fafc;">
                        <span class="text-muted small">Total Bond Amount</span>
                        <span class="fw-bold">₹{{ number_format($bdTotal, 2) }}</span>
                    </div>
                    <div class="d-flex justify-content-between align-items-center p-2 rounded" style="background:#dcfce7;">
                        <span class="text-success small fw-semibold">Total Paid</span>
                        <span class="fw-bold text-success">₹{{ number_format($bdPaid, 2) }}</span>
                    </div>
                    <div class="d-flex justify-content-between align-items-center p-2 rounded" style="background:{{ $bdBalance > 0 ? '#fee2e2' : '#dcfce7' }};">
                        <span class="{{ $bdBalance > 0 ? 'text-danger' : 'text-success' }} small fw-semibold">Balance Remaining</span>
                        <span class="fw-bold {{ $bdBalance > 0 ? 'text-danger' : 'text-success' }}">
                            @if($bdBalance > 0) ₹{{ number_format($bdBalance, 2) }}
                            @else <span class="badge bg-success">Cleared ✓</span>
                            @endif
                        </span>
                    </div>
                    {{-- Progress bar --}}
                    <div class="mt-1">
                        <div class="d-flex justify-content-between mb-1" style="font-size:11px;">
                            <span class="text-muted">Payment Progress</span>
                            <span class="fw-bold {{ $bdPct < 50 ? 'text-danger' : 'text-success' }}">{{ $bdPct }}%</span>
                        </div>
                        <div class="progress" style="height:8px;border-radius:4px;">
                            <div class="progress-bar {{ $bdPct < 50 ? 'bg-danger' : 'bg-success' }}" style="width:{{ $bdPct }}%;"></div>
                        </div>
                    </div>
                    @if($bd->bayana_mode || $bd->amount)
                    <div class="d-flex justify-content-between align-items-center p-2 rounded" style="background:#f1f5f9;font-size:12px;">
                        <span class="text-muted">Advance (Bayana)</span>
                        <span>₹{{ number_format((float)($bd->amount ?? 0), 2) }}</span>
                    </div>
                    @endif
                </div>
                @if($bd->notes || $bd->customer_comment)
                <div class="mt-2 p-2 rounded" style="background:#fffbeb;font-size:12px;color:#92400e;">
                    <i class="bi bi-sticky me-1"></i>{{ $bd->notes ?? $bd->customer_comment }}
                </div>
                @endif
            </div>
        </div>
    </div>
</div>
@endif

{{-- ── FILTER BAR ── --}}
@if($isCustomerLedger && !$selectedBondId)
<div class="filter-card no-print">
    <form method="GET" id="ledger-filter-form" class="row g-2 align-items-end">
        <div class="col-md-3">
            <label class="form-label fw-semibold mb-1" style="font-size:12px;">CUSTOMER NAME / MOBILE</label>
            <input type="text" name="q" value="{{ $cl_q ?? '' }}" class="form-control form-control-sm" placeholder="Name or mobile…">
        </div>
        <div class="col-md-2">
            <label class="form-label fw-semibold mb-1" style="font-size:12px;">ARAZI NO</label>
            <input type="text" name="arazi_code" value="{{ $cl_arazi ?? '' }}" class="form-control form-control-sm" placeholder="e.g. 419…">
        </div>
        <div class="col-md-2">
            <label class="form-label fw-semibold mb-1" style="font-size:12px;">PLOT</label>
            <input type="text" name="plot" value="{{ $cl_plot ?? '' }}" class="form-control form-control-sm" placeholder="Plot title…">
        </div>
        <div class="col-md-2">
            <label class="form-label fw-semibold mb-1" style="font-size:12px;">DATE FROM</label>
            <input type="date" name="date_from" value="{{ $cl_date_from ?? '' }}" class="form-control form-control-sm">
        </div>
        <div class="col-md-2">
            <label class="form-label fw-semibold mb-1" style="font-size:12px;">DATE TO</label>
            <input type="date" name="date_to" value="{{ $cl_date_to ?? '' }}" class="form-control form-control-sm">
        </div>
        <div class="col-md-12 d-flex align-items-center gap-3 pt-1">
            <div class="form-check mb-0">
                <input class="form-check-input" type="checkbox" name="low_progress" value="1" id="low_progress_chk"
                    {{ !empty($cl_low_progress) ? 'checked' : '' }}>
                <label class="form-check-label fw-semibold" for="low_progress_chk" style="font-size:12px;">
                    Show only &lt; 50% paid bonds
                </label>
            </div>
            <button type="submit" class="btn btn-primary btn-sm px-4">Apply</button>
            <a href="{{ url()->current() }}" class="btn btn-outline-secondary btn-sm px-3">Clear</a>
        </div>
    </form>
</div>
@elseif(!$isCustomerLedger)
<div class="filter-card no-print">
    <form method="GET" id="ledger-filter-form" class="row g-2 align-items-end">

        {{-- Kisan filter --}}
        @if(!empty($allKisans))
        <div class="col-md-3">
            <label class="form-label fw-semibold mb-1" style="font-size:12px;">KISAN</label>
            <select name="{{ $partyFilterName }}" id="kisan_filter_select" class="form-select form-select-sm">
                <option value="">All Kisans</option>
                @foreach($allKisans as $kisan)
                    <option value="{{ $kisan->id }}"
                        @selected((string)($selectedPartyId ?? '') === (string)$kisan->id)>
                        {{ $kisan->name }}{{ $kisan->mobile ? ' · '.$kisan->mobile : '' }}
                    </option>
                @endforeach
            </select>
        </div>
        @endif

        {{-- Arazi filter --}}
        <div class="col-md-2">
            <label class="form-label fw-semibold mb-1" style="font-size:12px;">ARAZI NO</label>
            <input type="text" name="arazi_code" id="arazi_filter_input"
                   value="{{ $selectedAraziCode ?? '' }}"
                   class="form-control form-control-sm" placeholder="e.g. 419…">
        </div>

        {{-- Bond filter — auto-populated based on above --}}
        <div class="col-md-4">
            <label class="form-label fw-semibold mb-1" style="font-size:12px;">BOND</label>
            <select name="{{ $filterName }}" id="bond_filter_select" class="form-select form-select-sm">
                <option value="">All Bonds</option>
                @foreach($bonds as $bond)
                    <option value="{{ $bond['id'] }}" @selected((string)$selectedBondId === (string)$bond['id'])>
                        {{ $bond['bond_no'] }} — {{ $bond['party'] }}
                    </option>
                @endforeach
            </select>
        </div>

        <div class="col-md-auto d-flex gap-2">
            <button type="submit" class="btn btn-primary btn-sm px-4">Apply</button>
            <a href="{{ url()->current() }}" class="btn btn-outline-secondary btn-sm px-3">Clear</a>
        </div>
    </form>
</div>
@endif

{{-- ── SUMMARY STATS ── --}}
@if(!$selectedBondId)
<div class="row g-3 mb-4">
    <div class="col-sm-4">
        <div class="ledger-stat bg-primary bg-opacity-10 border border-primary border-opacity-25">
            <div class="stat-label text-primary">Total Bond Value</div>
            <div class="stat-value text-primary">₹{{ number_format($overallTotal, 2) }}</div>
            <div class="stat-sub text-primary">Across {{ $bonds->count() }} bond(s)</div>
        </div>
    </div>
    <div class="col-sm-4">
        <div class="ledger-stat bg-success bg-opacity-10 border border-success border-opacity-25">
            <div class="stat-label text-success">Net Collected</div>
            <div class="stat-value text-success">₹{{ number_format($netCollected, 2) }}</div>
            @if($totalDebit > 0)
                <div class="stat-sub text-success">Credit ₹{{ number_format($totalCredit,2) }} − Debit ₹{{ number_format($totalDebit,2) }}</div>
            @elseif($overallTotal > 0)
                <div class="stat-sub text-success">{{ number_format(($netCollected / $overallTotal) * 100, 1) }}% of total</div>
            @endif
        </div>
    </div>
    <div class="col-sm-4">
        <div class="ledger-stat bg-danger bg-opacity-10 border border-danger border-opacity-25">
            <div class="stat-label text-danger">Total Outstanding</div>
            <div class="stat-value text-danger">₹{{ number_format($overallBalance, 2) }}</div>
            @if($overallTotal > 0)
                <div class="stat-sub text-danger">{{ number_format(($overallBalance / $overallTotal) * 100, 1) }}% remaining</div>
            @endif
        </div>
    </div>
</div>
@endif

{{-- ── PRINT-ONLY: title + stats (hidden on screen) ── --}}
@if(!$selectedBondId)
<div class="print-title" style="display:none;">
    <h4>{{ $title }}</h4>
    <span class="print-date">Printed: {{ now()->format('d M Y, h:i A') }}</span>
</div>
<div class="print-stats" style="display:none;">
    <div class="ps-item">
        <span>Total Bond Value</span>
        <strong>₹{{ number_format($overallTotal, 2) }}</strong>
        <span>{{ $bonds->count() }} bond(s)</span>
    </div>
    <div class="ps-item">
        <span>Net Collected</span>
        <strong style="color:#15803d;">₹{{ number_format($overallPaid, 2) }}</strong>
        @if($overallTotal > 0)<span>{{ number_format(($overallPaid / $overallTotal) * 100, 1) }}% of total</span>@endif
    </div>
    <div class="ps-item">
        <span>Total Outstanding</span>
        <strong style="color:#b91c1c;">₹{{ number_format($overallBalance, 2) }}</strong>
        @if($overallTotal > 0)<span>{{ number_format(($overallBalance / $overallTotal) * 100, 1) }}% remaining</span>@endif
    </div>
</div>
@endif

{{-- ── BOND SUMMARY ── --}}
@if(!$selectedBondId)
<div class="card border-0 shadow-sm mb-4 print-bond-summary">
    <div class="card-header bg-white border-bottom py-3 d-flex align-items-center gap-2">
        <span class="fw-bold">Bond-wise Summary</span>
        @if($isCustomerLedger && !empty($cl_low_progress))
            <span class="badge bg-danger ms-2" style="font-size:11px;">Below 50% only</span>
        @endif
        <span class="text-muted small ms-auto">{{ $bonds->count() }} bond(s)</span>
    </div>
    <div class="card-body p-0">
        <div class="table-responsive">
            <table class="table mb-0 align-middle" style="font-size:13px;">
                <thead>
                    <tr style="background:#f8fafc;">
                        <th class="ps-3 py-2" style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Bond No</th>
                        <th style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">{{ $partyLabel }}</th>
                        @if($isCustomerLedger)
                            <th style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Mobile</th>
                        @endif
                        <th style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Arazi No</th>
                        @if($isCustomerLedger)
                            <th style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Plot(s)</th>
                        @endif
                        <th class="text-end" style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Total</th>
                        <th class="text-end" style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Paid</th>
                        <th class="text-end" style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Balance</th>
                        <th style="width:140px;font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Progress</th>
                        <th class="no-print" style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;"></th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($bonds as $bond)
                    @php
                        $pct     = $bond['pct'] ?? ($bond['total'] > 0 ? min(round(($bond['paid'] / $bond['total']) * 100), 100) : 0);
                        $barColor = $pct < 50 ? 'bg-danger' : 'bg-success';
                        $colspan  = $isCustomerLedger ? 10 : 8;
                    @endphp
                    <tr class="bond-row" style="border-bottom:1px solid #f1f5f9;">
                        <td class="ps-3 fw-semibold">{{ $bond['bond_no'] }}</td>
                        <td>{{ $bond['party'] }}</td>
                        @if($isCustomerLedger)
                            <td class="text-muted" style="font-size:12px;">{{ $bond['mobile'] ?? '' }}</td>
                        @endif
                        <td>
                            @foreach(explode(', ', $bond['arazi'] ?? '-') as $code)
                                <span style="background:#1a3a6b;color:#fff;border-radius:3px;padding:1px 6px;font-size:11px;font-weight:700;display:inline-block;margin:1px 1px;">{{ trim($code) }}</span>
                            @endforeach
                        </td>
                        @if($isCustomerLedger)
                            <td class="text-muted" style="font-size:12px;">{{ $bond['plots'] ?? '-' }}</td>
                        @endif
                        <td class="text-end">₹{{ number_format($bond['total'], 2) }}</td>
                        <td class="text-end text-success fw-semibold">₹{{ number_format($bond['paid'], 2) }}</td>
                        <td class="text-end {{ $bond['balance'] > 0 ? 'text-danger fw-semibold' : 'text-success' }}">
                            @if($bond['balance'] > 0) ₹{{ number_format($bond['balance'], 2) }}
                            @else <span class="badge bg-success-subtle text-success">Cleared</span>
                            @endif
                        </td>
                        <td>
                            <div class="d-flex align-items-center gap-1 no-print-progress-bar">
                                <div class="progress flex-grow-1 progress-thin">
                                    <div class="progress-bar {{ $barColor }}" style="width:{{ $pct }}%"></div>
                                </div>
                            </div>
                            <span style="font-size:10px;color:{{ $pct < 50 ? '#b91c1c' : '#64748b' }};font-weight:{{ $pct < 50 ? '700' : '400' }};">{{ $pct }}%</span>
                        </td>
                        <td class="no-print">
                            <a href="{{ url()->current() }}?bond_id={{ $bond['id'] }}" class="btn btn-xs btn-outline-primary" style="font-size:11px;padding:2px 8px;">View</a>
                        </td>
                    </tr>
                    @empty
                    <tr><td colspan="{{ $colspan }}" class="text-center py-4 text-muted">No bonds found.</td></tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
</div>
@endif

{{-- ── ENTRIES TABLE ── --}}
@if(!$isCustomerLedger || $selectedBondId)
<div class="card border-0 shadow-sm{{ $selectedBondId ? ' print-entries' : '' }}">
    @if(!$selectedBondId)
    <div class="card-header bg-white border-bottom py-3 d-flex align-items-center flex-wrap gap-2">
        <div>
            <span class="fw-bold">All Payment Entries</span>
            <span class="text-muted small ms-2">{{ count($entries) }} entr{{ count($entries) === 1 ? 'y' : 'ies' }}</span>
        </div>
        {{-- mini totals for visible entries --}}
        <div class="d-flex gap-3 ms-auto" style="font-size:12px;">
            <span>Credit: <strong class="text-success">₹{{ number_format($totalCredit, 2) }}</strong></span>
            <span>Debit: <strong class="text-danger">₹{{ number_format($totalDebit, 2) }}</strong></span>
            <span>Net: <strong class="{{ ($totalCredit - $totalDebit) >= 0 ? 'text-primary' : 'text-danger' }}">₹{{ number_format($totalCredit - $totalDebit, 2) }}</strong></span>
        </div>
    </div>
    @else
    {{-- Print-only bond header (hidden on screen) --}}
    @if(!empty($selectedBond))
    <div style="display:none;" class="print-bond-header">
        <div style="border-bottom:2px solid #000;padding-bottom:6px;margin-bottom:8px;display:flex;justify-content:space-between;align-items:flex-end;">
            <div>
                <strong style="font-size:14px;">Payment Ledger — {{ $selectedBond->bond_no }}</strong>
                <span style="font-size:11px;margin-left:12px;">{{ $selectedBond->customer?->name }}</span>
            </div>
            <span style="font-size:10px;color:#555;">Printed: {{ now()->format('d M Y, h:i A') }}</span>
        </div>
        <div style="display:flex;gap:20px;margin-bottom:8px;padding:5px 8px;background:#f4f4f4;border:1px solid #ddd;border-radius:3px;font-size:10px;">
            <span>Bond: <strong>{{ $selectedBond->bond_no }}</strong></span>
            <span>Total: <strong>₹{{ number_format((float)($selectedBond->total_amount ?? $selectedBond->bond_amount ?? 0), 2) }}</strong></span>
            <span>Paid: <strong>₹{{ number_format($totalCredit, 2) }}</strong></span>
            <span>Balance: <strong>₹{{ number_format(max((float)($selectedBond->total_amount ?? $selectedBond->bond_amount ?? 0) - $totalCredit, 0), 2) }}</strong></span>
        </div>
    </div>
    @endif
    @endif
    <div class="card-body p-0">
        <div class="table-responsive">
            <table class="table entries-table mb-0">
                <thead>
                    <tr>
                        <th class="ps-3 py-3">#</th>
                        <th>Entry No</th>
                        @if(!$selectedBondId)<th>Bond</th><th>Customer</th>@endif
                        <th>Date</th>
                        <th>Type</th>
                        <th class="text-end text-success">Credit</th>
                        <th class="text-end text-danger">Debit</th>
                        <th class="text-end">Balance</th>
                        <th>Method</th>
                        <th>Remarks</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($entriesWithBalance as $i => $entry)
                    <tr>
                        <td class="ps-3 text-muted" style="font-size:11px;">{{ $i + 1 }}</td>
                        <td><span class="fw-semibold" style="font-size:12px;">{{ $entry['entry_no'] }}</span></td>
                        @if(!$selectedBondId)
                            <td style="font-size:12px;">{{ $entry['bond_no'] }}</td>
                            <td>{{ $entry['party'] }}</td>
                        @endif
                        <td style="white-space:nowrap;">{{ $entry['date'] }}</td>
                        <td>
                            @php $typeClass = 'type-' . strtolower($entry['type']); @endphp
                            <span class="type-badge {{ $typeClass }}">{{ $entry['type'] }}</span>
                        </td>
                        @if(!empty($entry['is_debit']))
                            <td class="text-end text-muted">—</td>
                            <td class="text-end text-danger fw-semibold">−₹{{ number_format($entry['amount'], 2) }}</td>
                        @else
                            <td class="text-end text-success fw-semibold">₹{{ number_format($entry['amount'], 2) }}</td>
                            <td class="text-end text-muted">—</td>
                        @endif
                        <td class="text-end running-bal {{ $entry['running_balance'] >= 0 ? 'text-primary' : 'text-danger' }}">
                            ₹{{ number_format($entry['running_balance'], 2) }}
                        </td>
                        <td style="font-size:12px;">
                            {{ $entry['method'] !== '-' ? $entry['method'] : '' }}
                            @if(!empty($entry['cheque_number']))
                                <span class="text-muted">#{{ $entry['cheque_number'] }}</span>
                            @endif
                        </td>
                        <td style="font-size:12px; color:#64748b; max-width:150px; overflow:hidden; text-overflow:ellipsis; white-space:nowrap;" title="{{ $entry['remarks'] }}">
                            {{ $entry['remarks'] !== '-' ? $entry['remarks'] : '' }}
                        </td>
                    </tr>
                    @empty
                    <tr>
                        <td colspan="11" class="text-center py-5 text-muted">
                            <div style="font-size:32px;">📋</div>
                            <div class="mt-2">No payment entries found.</div>
                            @if($selectedBondId)
                                <a href="{{ url()->current() }}" class="btn btn-sm btn-outline-secondary mt-2">View all entries</a>
                            @endif
                        </td>
                    </tr>
                    @endforelse
                </tbody>
                @if(count($entries) > 0)
                <tfoot>
                    <tr style="background:#f8fafc; font-weight:600; font-size:12px; border-top:2px solid #e2e8f0;">
                        <td colspan="{{ $selectedBondId ? 4 : 6 }}" class="ps-3 py-2 text-end text-muted">TOTAL</td>
                        <td class="text-end text-success">₹{{ number_format($totalCredit, 2) }}</td>
                        <td class="text-end text-danger">₹{{ number_format($totalDebit, 2) }}</td>
                        <td class="text-end text-primary">₹{{ number_format($totalCredit - $totalDebit, 2) }}</td>
                        <td colspan="2"></td>
                    </tr>
                </tfoot>
                @endif
            </table>
        </div>
    </div>
</div>
@endif {{-- !$isCustomerLedger || $selectedBondId --}}

@push('scripts')
<script>
$(function(){
    $('#kisan_filter_select').select2({
        theme: 'bootstrap-5',
        placeholder: 'Search kisan...',
        allowClear: true,
        width: '100%',
    });

    $('#bond_filter_select').select2({
        theme: 'bootstrap-5',
        placeholder: 'Search bond...',
        allowClear: true,
        width: '100%',
    });

    // Auto-submit when kisan changes → bond list refreshes
    $('#kisan_filter_select').on('change', function(){
        // clear bond selection so page shows filtered bonds
        $('#bond_filter_select').val('').trigger('change');
        $('#ledger-filter-form').submit();
    });

    // Auto-submit when arazi code loses focus or Enter pressed
    var araziTimer;
    $('#arazi_filter_input').on('input', function(){
        clearTimeout(araziTimer);
        araziTimer = setTimeout(function(){
            $('#bond_filter_select').val('').trigger('change');
            $('#ledger-filter-form').submit();
        }, 700);
    });
});
</script>
@endpush

@endsection
