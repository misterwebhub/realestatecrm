@extends('layouts.app')

@section('content')
@php
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

    $totalCredit = collect($entries)->where('is_debit', false)->sum('amount');
    $totalDebit  = collect($entries)->where('is_debit', true)->sum('amount');
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
    .no-print { display: none !important; }
    .entries-table td, .entries-table th { font-size: 11px; padding: 5px 7px !important; }
}
</style>

{{-- ── PAGE HEADER ── --}}
<div class="d-flex align-items-center justify-content-between flex-wrap gap-2 mb-3 no-print">
    <div>
        <h4 class="mb-0 fw-bold">{{ $title }}</h4>
        <span class="text-muted small">Track all bond payments, credits &amp; debits</span>
    </div>
    <div class="d-flex gap-2">
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

{{-- ── FILTER BAR ── --}}
<div class="filter-card no-print">
    <form method="GET" class="row g-2 align-items-end">
        <div class="col-md-5">
            <label class="form-label fw-semibold mb-1" style="font-size:12px;">FILTER BY BOND</label>
            <select name="{{ $filterName }}" id="bond_filter_select" class="form-select form-select-sm">
                <option value="">All Bonds</option>
                @foreach($bonds as $bond)
                    <option value="{{ $bond['id'] }}" @selected((string)$selectedBondId === (string)$bond['id'])>
                        {{ $bond['bond_no'] }} — {{ $bond['party'] }}
                    </option>
                @endforeach
            </select>
        </div>
        <div class="col-md-auto">
            <button class="btn btn-primary btn-sm px-4">Apply Filter</button>
        </div>
        <div class="col-md-auto">
            <a href="{{ url()->current() }}" class="btn btn-outline-secondary btn-sm px-3">Clear</a>
        </div>
        @if(!empty($selectedPartyId))
            <input type="hidden" name="{{ $partyFilterName }}" value="{{ $selectedPartyId }}">
        @endif
    </form>
</div>

{{-- ── SUMMARY STATS ── --}}
<div class="row g-3 mb-4">
    <div class="col-sm-4">
        <div class="ledger-stat bg-primary bg-opacity-10 border border-primary border-opacity-25">
            <div class="stat-label text-primary">Total Bond Value</div>
            <div class="stat-value text-primary">₹{{ number_format($overallTotal, 2) }}</div>
            <div class="stat-sub text-primary">Across {{ $bonds->count() }} bond(s)</div>
        </div>
    </div>
    <div class="col-sm-4">
        @php $netCollected = $totalCredit - $totalDebit; @endphp
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

{{-- ── BOND SUMMARY (show when no specific bond selected) ── --}}
@if(!$selectedBondId)
<div class="card border-0 shadow-sm mb-4">
    <div class="card-header bg-white border-bottom py-3 d-flex justify-content-between align-items-center">
        <span class="fw-bold">Bond-wise Summary</span>
        <span class="text-muted small">{{ $bonds->count() }} bond(s)</span>
    </div>
    <div class="card-body p-0">
        <div class="table-responsive">
            <table class="table mb-0 align-middle" style="font-size:13px;">
                <thead>
                    <tr style="background:#f8fafc;">
                        <th class="ps-3 py-2" style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Bond No</th>
                        <th style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Customer</th>
                        <th class="text-end" style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Total</th>
                        <th class="text-end" style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Paid</th>
                        <th class="text-end" style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Balance</th>
                        <th style="width:140px;font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Progress</th>
                        <th class="no-print" style="font-size:11px;font-weight:600;text-transform:uppercase;color:#64748b;letter-spacing:.4px;"></th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($bonds as $bond)
                    @php $pct = $bond['total'] > 0 ? min(round(($bond['paid'] / $bond['total']) * 100), 100) : 0; @endphp
                    <tr class="bond-row" style="border-bottom:1px solid #f1f5f9;">
                        <td class="ps-3 fw-semibold">{{ $bond['bond_no'] }}</td>
                        <td>{{ $bond['party'] }}</td>
                        <td class="text-end">₹{{ number_format($bond['total'], 2) }}</td>
                        <td class="text-end text-success fw-semibold">₹{{ number_format($bond['paid'], 2) }}</td>
                        <td class="text-end {{ $bond['balance'] > 0 ? 'text-danger fw-semibold' : 'text-success' }}">
                            @if($bond['balance'] > 0) ₹{{ number_format($bond['balance'], 2) }}
                            @else <span class="badge bg-success-subtle text-success">Cleared</span>
                            @endif
                        </td>
                        <td>
                            <div class="d-flex align-items-center gap-1">
                                <div class="progress flex-grow-1 progress-thin">
                                    <div class="progress-bar bg-success" style="width:{{ $pct }}%"></div>
                                </div>
                                <span style="font-size:10px;color:#64748b;width:30px;text-align:right;">{{ $pct }}%</span>
                            </div>
                        </td>
                        <td class="no-print">
                            <a href="{{ url()->current() }}?bond_id={{ $bond['id'] }}" class="btn btn-xs btn-outline-primary" style="font-size:11px;padding:2px 8px;">View</a>
                        </td>
                    </tr>
                    @empty
                    <tr><td colspan="7" class="text-center py-4 text-muted">No bonds found.</td></tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
</div>
@endif

{{-- ── ENTRIES TABLE ── --}}
<div class="card border-0 shadow-sm">
    <div class="card-header bg-white border-bottom py-3 d-flex justify-content-between align-items-center flex-wrap gap-2">
        <div>
            <span class="fw-bold">
                @if($selectedBondId)
                    @php $selBond = $bonds->firstWhere('id', (int)$selectedBondId); @endphp
                    Payment Entries — Bond {{ $selBond['bond_no'] ?? '' }}
                    @if(!empty($selBond['party'])) <span class="text-muted fw-normal">({{ $selBond['party'] }})</span> @endif
                @else
                    All Payment Entries
                @endif
            </span>
            <span class="text-muted small ms-2">{{ count($entries) }} entr{{ count($entries) === 1 ? 'y' : 'ies' }}</span>
        </div>
        {{-- mini totals for visible entries --}}
        <div class="d-flex gap-3" style="font-size:12px;">
            <span>Credit: <strong class="text-success">₹{{ number_format($totalCredit, 2) }}</strong></span>
            <span>Debit: <strong class="text-danger">₹{{ number_format($totalDebit, 2) }}</strong></span>
            <span>Net: <strong class="{{ ($totalCredit - $totalDebit) >= 0 ? 'text-primary' : 'text-danger' }}">₹{{ number_format($totalCredit - $totalDebit, 2) }}</strong></span>
        </div>
    </div>
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

@push('scripts')
<script>
$(function(){
    $('#bond_filter_select').select2({
        theme: 'bootstrap-5',
        placeholder: 'Search bond or customer...',
        allowClear: true,
        width: '100%',
    });
});
</script>
@endpush

@endsection
