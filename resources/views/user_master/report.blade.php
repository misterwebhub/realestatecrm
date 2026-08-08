@extends('layouts.app')

@section('content')

{{-- Header --}}
<div class="d-flex align-items-center gap-2 mb-3 flex-wrap">
    <a href="{{ route('user-master.index') }}" class="btn btn-sm btn-outline-secondary">
        <i class="bi bi-arrow-left"></i> Back
    </a>
    <div class="ms-1">
        <h5 class="mb-0 fw-bold">User Master Report</h5>
        <small class="text-muted">Collections by user &amp; bond</small>
    </div>
    <button class="btn btn-sm btn-outline-secondary ms-auto no-print" onclick="window.print()">
        <i class="bi bi-printer"></i> Print
    </button>
</div>

{{-- Filters --}}
<div class="card border-0 shadow-sm mb-3 no-print">
    <div class="card-body py-2 px-3">
        <form method="GET" class="row g-2 align-items-end">
            <div class="col-auto">
                <label class="form-label small fw-semibold mb-1">User</label>
                <select name="user_id" class="form-select form-select-sm">
                    <option value="">All Users</option>
                    @foreach($users as $u)
                        <option value="{{ $u->id }}" @selected((string) $userId === (string) $u->id)>{{ $u->name }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-auto">
                <label class="form-label small fw-semibold mb-1">Date From</label>
                <input type="date" name="date_from" value="{{ $dateFrom }}" class="form-control form-control-sm">
            </div>
            <div class="col-auto">
                <label class="form-label small fw-semibold mb-1">Date To</label>
                <input type="date" name="date_to" value="{{ $dateTo }}" class="form-control form-control-sm">
            </div>
            <div class="col-auto d-flex gap-2">
                <button type="submit" class="btn btn-primary btn-sm">Apply</button>
                <a href="{{ route('user-master.report') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
            </div>
            @if($dateFrom || $dateTo)
            <div class="col-auto">
                <span class="badge bg-info-subtle text-info border border-info-subtle" style="font-size:11px;">
                    {{ $dateFrom ? \Carbon\Carbon::parse($dateFrom)->format('d M Y') : '—' }}
                    →
                    {{ $dateTo ? \Carbon\Carbon::parse($dateTo)->format('d M Y') : 'Today' }}
                </span>
            </div>
            @endif
        </form>
    </div>
</div>

{{-- Summary cards --}}
<div class="row g-2 mb-3">
    <div class="col-sm-3">
        <div class="p-3 rounded border" style="background:#f8fafc;">
            <div class="text-muted small fw-semibold">Total Receipts</div>
            <div class="fw-bold fs-4">{{ $totalCount }}</div>
        </div>
    </div>
    <div class="col-sm-3">
        <div class="p-3 rounded border" style="background:#dcfce7;">
            <div class="text-success small fw-semibold">Total Credit</div>
            <div class="fw-bold fs-5 text-success">₹{{ inr($grandCredit, 2) }}</div>
        </div>
    </div>
    <div class="col-sm-3">
        <div class="p-3 rounded border" style="background:#fee2e6;">
            <div class="text-danger small fw-semibold">Total Debit (Returns)</div>
            <div class="fw-bold fs-5 text-danger">₹{{ inr($grandDebit, 2) }}</div>
        </div>
    </div>
    <div class="col-sm-3">
        <div class="p-3 rounded border" style="background:#dbeafe;">
            <div class="text-primary small fw-semibold">Net Collected</div>
            <div class="fw-bold fs-5 text-primary">₹{{ inr($grandNet, 2) }}</div>
        </div>
    </div>
</div>

@if($byUser->isEmpty())
<div class="card border-0 shadow-sm">
    <div class="card-body text-center py-5 text-muted">
        <div style="font-size:36px;">📋</div>
        <div class="mt-2 fw-semibold">No collections found{{ ($dateFrom || $dateTo || $userId) ? ' for the selected filters' : '' }}.</div>
    </div>
</div>
@else

{{-- Per-user breakdown --}}
@foreach($byUser as $group)
@php
    $u = $group['user'];
@endphp
<div class="card border-0 shadow-sm mb-3">
    {{-- User header --}}
    <div class="card-header bg-white py-2 px-3 d-flex align-items-center flex-wrap gap-2"
         style="border-left:4px solid #1a3a6b;">
        <i class="bi bi-person-circle" style="font-size:18px;color:#1a3a6b;"></i>
        <span class="fw-bold" style="font-size:14px;">{{ $u?->name ?? '—' }}</span>
        @if($u?->role)
            <span class="badge {{ $u->role === 'admin' ? 'bg-danger' : ($u->role === 'manager' ? 'bg-warning text-dark' : 'bg-secondary') }}" style="font-size:10px;">{{ ucfirst($u->role) }}</span>
        @endif
        <span class="text-muted" style="font-size:12px;">{{ $group['count'] }} receipt(s) · {{ $group['bonds']->count() }} bond(s)</span>
        <div class="ms-auto d-flex gap-2" style="font-size:12px;">
            <span class="text-success fw-semibold">Credit: ₹{{ inr($group['credit'], 2) }}</span>
            @if($group['debit'] > 0)
                <span class="text-danger fw-semibold">Debit: ₹{{ inr($group['debit'], 2) }}</span>
            @endif
            <span class="text-primary fw-bold">Net: ₹{{ inr($group['net'], 2) }}</span>
        </div>
    </div>

    {{-- Bond-wise table --}}
    <div class="card-body p-0">
        <table class="table mb-0 align-middle" style="font-size:12px;">
            <thead style="background:#f8fafc;">
                <tr>
                    <th class="ps-3 py-2" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Bond No</th>
                    <th style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Customer</th>
                    <th style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Arazi</th>
                    <th style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Plots</th>
                    <th class="text-center" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Receipts</th>
                    <th class="text-end" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Credit</th>
                    <th class="text-end" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Debit</th>
                    <th class="text-end pe-3" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Net</th>
                </tr>
            </thead>
            <tbody>
                @foreach($group['bonds'] as $b)
                @php
                    $bond      = $b['bond'];
                    $araziCode = $bond?->arazi?->legacy_arazi_code ?? $bond?->arazi_code ?? '—';
                    $plots     = $bond?->plots?->pluck('title')->filter()->implode(', ') ?: '—';
                @endphp
                <tr style="border-bottom:1px solid #f1f5f9;">
                    <td class="ps-3 fw-semibold">{{ $bond?->bond_no ?? '—' }}</td>
                    <td>{{ $bond?->customer?->name ?? '—' }}</td>
                    <td>
                        <span style="background:#1a3a6b;color:#fff;border-radius:3px;padding:1px 7px;font-size:11px;font-weight:700;">{{ $araziCode }}</span>
                    </td>
                    <td class="text-muted" style="max-width:160px;overflow:hidden;text-overflow:ellipsis;white-space:nowrap;">{{ $plots }}</td>
                    <td class="text-center text-muted">{{ $b['count'] }}</td>
                    <td class="text-end text-success fw-semibold">₹{{ inr($b['credit'], 2) }}</td>
                    <td class="text-end {{ $b['debit'] > 0 ? 'text-danger fw-semibold' : 'text-muted' }}">{{ $b['debit'] > 0 ? '₹'.inr($b['debit'], 2) : '—' }}</td>
                    <td class="text-end pe-3 text-primary fw-bold">₹{{ inr($b['net'], 2) }}</td>
                </tr>
                @endforeach
            </tbody>
            <tfoot style="background:#f8fafc;border-top:2px solid #e2e8f0;">
                <tr>
                    <td colspan="4" class="ps-3 py-1 text-end text-muted fw-semibold" style="font-size:11px;">TOTAL</td>
                    <td class="text-center text-muted fw-semibold">{{ $group['count'] }}</td>
                    <td class="text-end text-success fw-bold">₹{{ inr($group['credit'], 2) }}</td>
                    <td class="text-end text-danger fw-bold">{{ $group['debit'] > 0 ? '₹'.inr($group['debit'], 2) : '—' }}</td>
                    <td class="text-end pe-3 text-primary fw-bold">₹{{ inr($group['net'], 2) }}</td>
                </tr>
            </tfoot>
        </table>
    </div>
</div>
@endforeach

{{-- Grand total --}}
<div class="card border-0 shadow-sm" style="border-left:4px solid #0d6efd !important;">
    <div class="card-body py-2 px-3 d-flex flex-wrap gap-4 align-items-center">
        <span class="fw-bold text-muted" style="font-size:12px;">GRAND TOTAL — {{ $totalCount }} receipt(s) across {{ $byUser->count() }} user(s)</span>
        <span class="ms-auto text-success fw-bold">Credit: ₹{{ inr($grandCredit, 2) }}</span>
        @if($grandDebit > 0)
            <span class="text-danger fw-bold">Debit: ₹{{ inr($grandDebit, 2) }}</span>
        @endif
        <span class="text-primary fw-bold">Net: ₹{{ inr($grandNet, 2) }}</span>
    </div>
</div>

@endif

@push('styles')
<style>
@media print {
    .no-print { display: none !important; }
    .card { box-shadow: none !important; border: 1px solid #ddd !important; }
}
</style>
@endpush

@endsection
