@extends('layouts.app')

@section('content')

{{-- Header --}}
<div class="d-flex align-items-center gap-2 mb-3 flex-wrap">
    <a href="{{ route('user-master.index') }}" class="btn btn-sm btn-outline-secondary">
        <i class="bi bi-arrow-left"></i> Back
    </a>
    <div class="ms-1">
        <h5 class="mb-0 fw-bold">Receipt Dashboard — {{ $user->name }}</h5>
        <small class="text-muted">
            <span class="badge {{ $user->role === 'admin' ? 'bg-danger' : ($user->role === 'manager' ? 'bg-warning text-dark' : 'bg-secondary') }} me-1">{{ ucfirst($user->role ?? 'staff') }}</span>
            {{ $user->mobile ?? '' }}
        </small>
    </div>
    <button class="btn btn-sm btn-outline-secondary ms-auto no-print" onclick="window.print()">
        <i class="bi bi-printer"></i> Print
    </button>
</div>

{{-- Date Range Filter --}}
<div class="card border-0 shadow-sm mb-3 no-print">
    <div class="card-body py-2 px-3">
        <form method="GET" class="row g-2 align-items-end">
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
                <a href="{{ route('user-master.receipts', $user) }}" class="btn btn-outline-secondary btn-sm">Clear</a>
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
            <div class="fw-bold fs-4">{{ $payments->count() }}</div>
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

@if($byBond->isEmpty())
<div class="card border-0 shadow-sm">
    <div class="card-body text-center py-5 text-muted">
        <div style="font-size:36px;">📋</div>
        <div class="mt-2 fw-semibold">No receipts found for this user{{ ($dateFrom || $dateTo) ? ' in the selected date range' : '' }}.</div>
    </div>
</div>
@else

{{-- Bond-wise breakdown --}}
@foreach($byBond as $group)
@php
    $bond    = $group['bond'];
    $entries = $group['entries'];
    $araziCode = $bond?->arazi?->legacy_arazi_code ?? $bond?->arazi_code ?? '—';
    $plots   = $bond?->plots?->pluck('title')->filter()->implode(', ') ?: '—';
@endphp

<div class="card border-0 shadow-sm mb-3">
    {{-- Bond header --}}
    <div class="card-header bg-white py-2 px-3 d-flex align-items-center flex-wrap gap-2"
         style="border-left:4px solid #1a3a6b;">
        <span class="fw-bold" style="font-size:13px;">{{ $bond?->bond_no ?? '—' }}</span>
        <span class="text-muted mx-1" style="font-size:12px;">·</span>
        <span style="font-size:13px;">{{ $bond?->customer?->name ?? '—' }}</span>
        @if($bond?->customer?->mobile)
            <span class="text-muted" style="font-size:12px;">{{ $bond->customer->mobile }}</span>
        @endif
        <span class="mx-1 text-muted">·</span>
        <span style="background:#1a3a6b;color:#fff;border-radius:3px;padding:1px 7px;font-size:11px;font-weight:700;">{{ $araziCode }}</span>
        @if($plots !== '—')
            <span class="text-muted" style="font-size:12px;">{{ $plots }}</span>
        @endif
        <div class="ms-auto d-flex gap-2" style="font-size:12px;">
            <span class="text-success fw-semibold">Credit: ₹{{ inr($group['credit'], 2) }}</span>
            @if($group['debit'] > 0)
                <span class="text-danger fw-semibold">Debit: ₹{{ inr($group['debit'], 2) }}</span>
            @endif
            <span class="text-primary fw-bold">Net: ₹{{ inr($group['net'], 2) }}</span>
        </div>
    </div>

    {{-- Entries table --}}
    <div class="card-body p-0">
        <table class="table mb-0 align-middle" style="font-size:12px;">
            <thead style="background:#f8fafc;">
                <tr>
                    <th class="ps-3 py-2" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">#</th>
                    <th style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Entry No</th>
                    <th style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Date</th>
                    <th style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Type</th>
                    <th class="text-end" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Credit</th>
                    <th class="text-end" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Debit</th>
                    <th style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Method</th>
                    <th style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Remarks</th>
                    <th class="no-print" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;"></th>
                </tr>
            </thead>
            <tbody>
                @foreach($entries as $i => $entry)
                @php
                    $isDebit = in_array($entry->entry_type, ['return', 'discount']);
                    $typeColors = [
                        'advance'     => 'background:#dbeafe;color:#1d4ed8;',
                        'installment' => 'background:#dcfce7;color:#15803d;',
                        'final'       => 'background:#f3e8ff;color:#7e22ce;',
                        'penalty'     => 'background:#fee2e2;color:#b91c1c;',
                        'return'      => 'background:#fff7ed;color:#c2410c;',
                        'discount'    => 'background:#fef9c3;color:#854d0e;',
                    ];
                    $typeStyle = $typeColors[$entry->entry_type] ?? 'background:#f1f5f9;color:#475569;';
                @endphp
                <tr style="border-bottom:1px solid #f1f5f9;">
                    <td class="ps-3 text-muted">{{ $i + 1 }}</td>
                    <td class="fw-semibold">{{ $entry->entry_no ?? '—' }}</td>
                    <td style="white-space:nowrap;">{{ optional($entry->entry_date)->format('d-m-Y') ?? '—' }}</td>
                    <td>
                        <span style="display:inline-block;padding:1px 8px;border-radius:20px;font-size:10px;font-weight:600;{{ $typeStyle }}">
                            {{ ucfirst($entry->entry_type ?? '—') }}
                        </span>
                    </td>
                    <td class="text-end {{ $isDebit ? 'text-muted' : 'text-success fw-semibold' }}">
                        {{ $isDebit ? '—' : '₹'.inr((float)$entry->amount, 2) }}
                    </td>
                    <td class="text-end {{ $isDebit ? 'text-danger fw-semibold' : 'text-muted' }}">
                        {{ $isDebit ? '₹'.inr((float)$entry->amount, 2) : '—' }}
                    </td>
                    <td class="text-muted">{{ $entry->payment_method ?? '—' }}</td>
                    <td class="text-muted" style="max-width:150px;overflow:hidden;text-overflow:ellipsis;white-space:nowrap;">
                        {{ $entry->remarks ?? '' }}
                    </td>
                    <td class="pe-2 no-print">
                        @if($entry->entry_no)
                        <a href="{{ route('customer-bond-payments.receipt', ['entry_no' => $entry->entry_no, 'print' => 1]) }}"
                           target="_blank" class="btn btn-xs btn-outline-secondary" style="font-size:10px;padding:1px 6px;" title="Print receipt">
                            <i class="bi bi-printer"></i>
                        </a>
                        @endif
                    </td>
                </tr>
                @endforeach
            </tbody>
            <tfoot style="background:#f8fafc;border-top:2px solid #e2e8f0;">
                <tr>
                    <td colspan="4" class="ps-3 py-1 text-end text-muted fw-semibold" style="font-size:11px;">SUBTOTAL</td>
                    <td class="text-end text-success fw-bold" style="font-size:12px;">₹{{ inr($group['credit'], 2) }}</td>
                    <td class="text-end text-danger fw-bold" style="font-size:12px;">{{ $group['debit'] > 0 ? '₹'.inr($group['debit'], 2) : '—' }}</td>
                    <td colspan="3"></td>
                </tr>
            </tfoot>
        </table>
    </div>
</div>
@endforeach

{{-- Grand total --}}
<div class="card border-0 shadow-sm" style="border-left:4px solid #0d6efd !important;">
    <div class="card-body py-2 px-3 d-flex flex-wrap gap-4 align-items-center">
        <span class="fw-bold text-muted" style="font-size:12px;">GRAND TOTAL — {{ $payments->count() }} receipt(s) across {{ $byBond->count() }} bond(s)</span>
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
