@extends('layouts.app')

@section('content')
@php
    $statusColors = [
        'pending'   => ['bg' => '#fff7ed', 'border' => '#fed7aa', 'text' => '#c2410c', 'badge' => 'warning'],
        'cleared'   => ['bg' => '#f0fdf4', 'border' => '#bbf7d0', 'text' => '#15803d', 'badge' => 'success'],
        'bounced'   => ['bg' => '#fef2f2', 'border' => '#fecaca', 'text' => '#b91c1c', 'badge' => 'danger'],
        'cancelled' => ['bg' => '#f8fafc', 'border' => '#e2e8f0', 'text' => '#475569', 'badge' => 'secondary'],
    ];
@endphp

<style>
.cheque-stat { border-radius: 10px; padding: 16px 20px; border: 1px solid; }
.cheque-stat .cs-label { font-size: 11px; font-weight: 700; text-transform: uppercase; letter-spacing: .5px; margin-bottom: 4px; }
.cheque-stat .cs-count { font-size: 13px; margin-bottom: 2px; }
.cheque-stat .cs-amount { font-size: 20px; font-weight: 700; line-height: 1.1; }
.ch-table th { background: #f8fafc; font-size: 12px; font-weight: 700; text-transform: uppercase; letter-spacing: .4px; color: #64748b; white-space: nowrap; }
.ch-table td { font-size: 15px; vertical-align: middle; border-bottom: 1px solid #f1f5f9; }
.ch-table tr:last-child td { border-bottom: none; }
.ch-table tr:hover td { background: #fafbff; }
@media print { .no-print { display: none !important; } }
</style>

{{-- Page header --}}
<div class="d-flex align-items-center justify-content-between flex-wrap gap-2 mb-3 no-print">
    <div>
        <h4 class="mb-0 fw-bold">{{ $title }}</h4>
        <span class="text-muted" style="font-size:14px;">All bond cheques across all customers</span>
    </div>
    <div class="d-flex gap-2">
        <button class="btn btn-sm btn-outline-secondary" onclick="window.print()">
            <i class="bi bi-printer"></i> Print
        </button>
    </div>
</div>

{{-- Summary cards --}}
<div class="row g-3 mb-4">
    @foreach(['pending' => 'Pending', 'cleared' => 'Cleared', 'bounced' => 'Bounced', 'cancelled' => 'Cancelled'] as $key => $label)
    @php $s = $summary[$key]; $c = $statusColors[$key]; @endphp
    <div class="col-6 col-md-3">
        <div class="cheque-stat" style="background:{{ $c['bg'] }}; border-color:{{ $c['border'] }}; color:{{ $c['text'] }};">
            <div class="cs-label">{{ $label }}</div>
            <div class="cs-count">{{ $s ? number_format($s->count) : 0 }} cheque(s)</div>
            <div class="cs-amount">₹{{ $s ? number_format((float)$s->total, 2) : '0.00' }}</div>
        </div>
    </div>
    @endforeach
</div>

{{-- Filter bar --}}
<div class="no-print" style="background:#fff; border:1px solid #e2e8f0; border-radius:10px; padding:14px 18px; margin-bottom:20px;">
    <form method="GET" class="row g-2 align-items-end">
        <div class="col-md-3">
            <label class="form-label fw-semibold mb-1" style="font-size:12px;">STATUS</label>
            <select name="status" id="filter_status" class="form-select form-select-sm">
                <option value="">All Statuses</option>
                <option value="pending"   @selected($filterStatus === 'pending')>Pending</option>
                <option value="cleared"   @selected($filterStatus === 'cleared')>Cleared</option>
                <option value="bounced"   @selected($filterStatus === 'bounced')>Bounced</option>
                <option value="cancelled" @selected($filterStatus === 'cancelled')>Cancelled</option>
            </select>
        </div>
        <div class="col-md-3">
            <label class="form-label fw-semibold mb-1" style="font-size:12px;">BOND NO.</label>
            <input type="text" name="bond_no" value="{{ $filterBond }}" class="form-control form-control-sm" placeholder="Search bond no...">
        </div>
        <div class="col-md-auto">
            <button class="btn btn-primary btn-sm px-4">Filter</button>
            <a href="{{ route('customer-bond-cheques.index') }}" class="btn btn-outline-secondary btn-sm ms-1">Clear</a>
        </div>
    </form>
</div>

{{-- Cheques table --}}
<div class="card border-0 shadow-sm">
    <div class="card-header bg-white border-bottom py-3 d-flex justify-content-between align-items-center">
        <span class="fw-bold" style="font-size:15px;">
            Cheques
            @if($filterStatus || $filterBond)
                <span class="text-muted fw-normal" style="font-size:13px;">— filtered</span>
            @endif
        </span>
        <span class="text-muted" style="font-size:13px;">{{ $cheques->count() }} record(s)</span>
    </div>
    <div class="card-body p-0">
        <div class="table-responsive">
            <table class="table ch-table mb-0">
                <thead>
                    <tr>
                        <th class="ps-3 py-3">#</th>
                        <th>Account</th>
                        <th>Customer</th>
                        <th>Bond No</th>
                        <th>Cheque No</th>
                        <th>Date</th>
                        <th>Bank</th>
                        <th class="text-end">Amount</th>
                        <th>Status</th>
                        <th>Type</th>
                        <th>Notes</th>
                        <th class="no-print"></th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($cheques as $i => $cheque)
                    @php
                        $sc = $statusColors[$cheque->status] ?? $statusColors['cancelled'];
                        $customer = $cheque->customerBond?->customer;
                    @endphp
                    <tr>
                        <td class="ps-3 text-muted" style="font-size:12px;">{{ $i + 1 }}</td>
                        <td>
                            @if($cheque->connectedAccount)
                                <div class="fw-semibold" style="font-size:14px;">{{ $cheque->connectedAccount->name }}</div>
                                <div class="text-muted" style="font-size:12px;">{{ $cheque->connectedAccount->mobile }}</div>
                            @else
                                <span class="text-muted">—</span>
                            @endif
                        </td>
                        <td class="fw-semibold">{{ $customer?->name ?? '-' }}</td>
                        <td>
                            @if($cheque->customerBond)
                                <a href="{{ route('customer-bond-cheques.manage', $cheque->customer_bond_id) }}" class="text-decoration-none fw-semibold">
                                    {{ $cheque->customerBond->bond_no ?? '-' }}
                                </a>
                            @else
                                -
                            @endif
                        </td>
                        <td class="fw-semibold">{{ $cheque->cheque_number ?? '-' }}</td>
                        <td style="white-space:nowrap;">{{ optional($cheque->cheque_date)->format('d-m-Y') ?? '-' }}</td>
                        <td>
                            {{ $cheque->bank_name ?? '-' }}
                            @if($cheque->branch_name)
                                <span class="text-muted" style="font-size:13px;">/ {{ $cheque->branch_name }}</span>
                            @endif
                        </td>
                        <td class="text-end fw-bold">₹{{ number_format((float)$cheque->amount, 2) }}</td>
                        <td>
                            <span class="badge" style="font-size:12px; padding:5px 11px; background:{{ $sc['bg'] }}; color:{{ $sc['text'] }}; border:1px solid {{ $sc['border'] }};">
                                {{ ucfirst($cheque->status) }}
                            </span>
                        </td>
                        <td class="text-muted">{{ ucfirst($cheque->type ?? '-') }}</td>
                        <td style="color:#64748b; max-width:160px; overflow:hidden; text-overflow:ellipsis; white-space:nowrap;" title="{{ $cheque->notes }}">
                            {{ $cheque->notes ?: '' }}
                        </td>
                        <td class="no-print" style="white-space:nowrap;">
                            <a href="{{ route('customer-bond-cheques.edit', $cheque->id) }}" class="btn btn-outline-secondary btn-sm" style="font-size:12px;">Edit</a>
                        </td>
                    </tr>
                    @empty
                    <tr>
                        <td colspan="12" class="text-center py-5 text-muted">
                            <div style="font-size:32px;">🗒️</div>
                            <div class="mt-2" style="font-size:15px;">No cheques found.</div>
                            @if($filterStatus || $filterBond)
                                <a href="{{ route('customer-bond-cheques.index') }}" class="btn btn-sm btn-outline-secondary mt-2">Clear filters</a>
                            @endif
                        </td>
                    </tr>
                    @endforelse
                </tbody>
                @if($cheques->count() > 0)
                <tfoot>
                    <tr style="background:#f8fafc; font-weight:700; font-size:13px; border-top:2px solid #e2e8f0;">
                        <td colspan="7" class="ps-3 py-2 text-end text-muted">TOTAL</td>
                        <td class="text-end text-primary">₹{{ number_format($cheques->sum('amount'), 2) }}</td>
                        <td colspan="4"></td>
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
    $('#filter_status').select2({
        theme: 'bootstrap-5',
        minimumResultsForSearch: Infinity,
        width: '100%',
    });
});
</script>
@endpush

@endsection
