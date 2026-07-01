@extends('layouts.app')

@section('content')

{{-- Header --}}
<div class="d-flex align-items-center gap-2 mb-3 flex-wrap">
    <a href="{{ route('reports.index') }}" class="btn btn-sm btn-outline-secondary">
        <i class="bi bi-arrow-left"></i> Back
    </a>
    <div class="ms-1">
        <h5 class="mb-0 fw-bold">Customer Payments by User</h5>
        <small class="text-muted">Detailed customer payments grouped by the user who collected them</small>
    </div>
    <button class="btn btn-sm btn-outline-secondary ms-auto no-print" onclick="window.print()">
        <i class="bi bi-printer"></i> Print
    </button>
</div>

{{-- Filters --}}
<div class="card border-0 shadow-sm mb-3 no-print">
    <div class="card-body py-2 px-3">
        <form method="GET" class="row g-2 align-items-end">
            <div class="col-md-2 col-sm-4">
                <label class="form-label small fw-semibold mb-1">User</label>
                <select name="user_id" class="form-select form-select-sm">
                    <option value="">All Users</option>
                    @foreach($users as $u)
                        <option value="{{ $u->id }}" @selected((string) $userId === (string) $u->id)>{{ $u->name }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-2 col-sm-4">
                <label class="form-label small fw-semibold mb-1">Customer</label>
                <select name="customer_id" class="form-select form-select-sm">
                    <option value="">All Customers</option>
                    @foreach($customers as $c)
                        <option value="{{ $c->id }}" @selected((string) $customerId === (string) $c->id)>{{ $c->name }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-2 col-sm-4">
                <label class="form-label small fw-semibold mb-1">Bond</label>
                <select name="bond_id" class="form-select form-select-sm">
                    <option value="">All Bonds</option>
                    @foreach($bonds as $b)
                        <option value="{{ $b->id }}" @selected((string) $bondId === (string) $b->id)>{{ $b->bond_no }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-2 col-sm-4">
                <label class="form-label small fw-semibold mb-1">Arazi</label>
                <select name="arazi_code" class="form-select form-select-sm">
                    <option value="">All Arazi</option>
                    @foreach($araziCodes as $code)
                        <option value="{{ $code }}" @selected((string) $araziCode === (string) $code)>{{ $code }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-2 col-sm-4">
                <label class="form-label small fw-semibold mb-1">Type</label>
                <select name="entry_type" class="form-select form-select-sm">
                    <option value="">All Types</option>
                    @foreach($entryTypes as $t)
                        <option value="{{ $t }}" @selected((string) $entryType === (string) $t)>{{ ucfirst($t) }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-2 col-sm-4">
                <label class="form-label small fw-semibold mb-1">Method</label>
                <select name="payment_method" class="form-select form-select-sm">
                    <option value="">All Methods</option>
                    @foreach($paymentMethods as $m)
                        <option value="{{ $m }}" @selected((string) $paymentMethod === (string) $m)>{{ strtoupper($m) }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-2 col-sm-4">
                <label class="form-label small fw-semibold mb-1">Date From</label>
                <input type="date" name="date_from" value="{{ $dateFrom }}" class="form-control form-control-sm">
            </div>
            <div class="col-md-2 col-sm-4">
                <label class="form-label small fw-semibold mb-1">Date To</label>
                <input type="date" name="date_to" value="{{ $dateTo }}" class="form-control form-control-sm">
            </div>
            <div class="col-auto d-flex gap-2">
                <button type="submit" class="btn btn-primary btn-sm">Apply</button>
                <a href="{{ route('reports.customer-payments.by-user') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
            </div>
        </form>
    </div>
</div>

{{-- Summary cards --}}
<div class="row g-2 mb-3">
    <div class="col-sm-3">
        <div class="p-3 rounded border" style="background:#f8fafc;">
            <div class="text-muted small fw-semibold">Total Payments</div>
            <div class="fw-bold fs-4">{{ $totalCount }}</div>
        </div>
    </div>
    <div class="col-sm-3">
        <div class="p-3 rounded border" style="background:#dcfce7;">
            <div class="text-success small fw-semibold">Total Credit</div>
            <div class="fw-bold fs-5 text-success">₹{{ number_format($grandCredit, 2) }}</div>
        </div>
    </div>
    <div class="col-sm-3">
        <div class="p-3 rounded border" style="background:#fee2e6;">
            <div class="text-danger small fw-semibold">Total Debit (Returns)</div>
            <div class="fw-bold fs-5 text-danger">₹{{ number_format($grandDebit, 2) }}</div>
        </div>
    </div>
    <div class="col-sm-3">
        <div class="p-3 rounded border" style="background:#dbeafe;">
            <div class="text-primary small fw-semibold">Net Collected</div>
            <div class="fw-bold fs-5 text-primary">₹{{ number_format($grandNet, 2) }}</div>
        </div>
    </div>
</div>

@if($byUser->isEmpty())
<div class="card border-0 shadow-sm">
    <div class="card-body text-center py-5 text-muted">
        <div style="font-size:36px;">📋</div>
        <div class="mt-2 fw-semibold">No payments found for the selected filters.</div>
    </div>
</div>
@else

@foreach($byUser as $group)
@php $u = $group['user']; @endphp
<div class="card border-0 shadow-sm mb-3">
    {{-- User header --}}
    <div class="card-header bg-white py-2 px-3 d-flex align-items-center flex-wrap gap-2"
         style="border-left:4px solid #1a3a6b;">
        <i class="bi bi-person-circle" style="font-size:18px;color:#1a3a6b;"></i>
        <span class="fw-bold" style="font-size:14px;">{{ $u?->name ?? '—' }}</span>
        @if($u?->role)
            <span class="badge {{ $u->role === 'admin' ? 'bg-danger' : ($u->role === 'manager' ? 'bg-warning text-dark' : 'bg-secondary') }}" style="font-size:10px;">{{ ucfirst($u->role) }}</span>
        @endif
        <span class="text-muted" style="font-size:12px;">{{ $group['count'] }} payment(s)</span>
        <div class="ms-auto d-flex gap-2" style="font-size:12px;">
            <span class="text-success fw-semibold">Credit: ₹{{ number_format($group['credit'], 2) }}</span>
            @if($group['debit'] > 0)
                <span class="text-danger fw-semibold">Debit: ₹{{ number_format($group['debit'], 2) }}</span>
            @endif
            <span class="text-primary fw-bold">Net: ₹{{ number_format($group['net'], 2) }}</span>
        </div>
    </div>

    {{-- Payments table --}}
    <div class="card-body p-0">
        <table class="table mb-0 align-middle" style="font-size:12px;">
            <thead style="background:#f8fafc;">
                <tr>
                    @foreach(['Entry No','Date','Bond','Customer','Arazi','Type','Method','MTR No','Payee'] as $h)
                        <th class="py-2 {{ $loop->first ? 'ps-3' : '' }}" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">{{ $h }}</th>
                    @endforeach
                    <th class="text-end" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Credit</th>
                    <th class="text-end pe-3" style="font-size:10px;font-weight:700;text-transform:uppercase;color:#64748b;">Debit</th>
                </tr>
            </thead>
            <tbody>
                @foreach($group['payments'] as $p)
                @php
                    $isDebit = in_array($p->entry_type, ['return', 'discount']);
                    $bond    = $p->customerBond;
                    $cust    = $bond?->customer?->name ?? $p->customer?->name ?? '—';
                    $code    = $bond?->arazi?->legacy_arazi_code ?? $p->arazi_code ?? '—';
                @endphp
                <tr style="border-bottom:1px solid #f1f5f9;">
                    <td class="ps-3 fw-semibold">{{ $p->entry_no ?? '—' }}</td>
                    <td style="white-space:nowrap;">{{ optional($p->entry_date)->format('d-m-Y') ?? '—' }}</td>
                    <td>{{ $bond?->bond_no ?? '—' }}</td>
                    <td>{{ $cust }}</td>
                    <td><span style="background:#1a3a6b;color:#fff;border-radius:3px;padding:1px 7px;font-size:11px;font-weight:700;">{{ $code }}</span></td>
                    <td>{{ ucfirst($p->entry_type ?? '—') }}</td>
                    <td class="text-muted">{{ $p->payment_method ? strtoupper($p->payment_method) : '—' }}</td>
                    <td class="text-muted">{{ $p->mtr_transaction_no ?: '—' }}</td>
                    <td class="text-muted">{{ $p->account_payee_name ?: '—' }}</td>
                    <td class="text-end {{ $isDebit ? 'text-muted' : 'text-success fw-semibold' }}">{{ $isDebit ? '—' : '₹'.number_format((float)$p->amount, 2) }}</td>
                    <td class="text-end pe-3 {{ $isDebit ? 'text-danger fw-semibold' : 'text-muted' }}">{{ $isDebit ? '₹'.number_format((float)$p->amount, 2) : '—' }}</td>
                </tr>
                @endforeach
            </tbody>
            <tfoot style="background:#f8fafc;border-top:2px solid #e2e8f0;">
                <tr>
                    <td colspan="9" class="ps-3 py-1 text-end text-muted fw-semibold" style="font-size:11px;">SUBTOTAL</td>
                    <td class="text-end text-success fw-bold">₹{{ number_format($group['credit'], 2) }}</td>
                    <td class="text-end pe-3 text-danger fw-bold">{{ $group['debit'] > 0 ? '₹'.number_format($group['debit'], 2) : '—' }}</td>
                </tr>
            </tfoot>
        </table>
    </div>
</div>
@endforeach

{{-- Grand total --}}
<div class="card border-0 shadow-sm" style="border-left:4px solid #0d6efd !important;">
    <div class="card-body py-2 px-3 d-flex flex-wrap gap-4 align-items-center">
        <span class="fw-bold text-muted" style="font-size:12px;">GRAND TOTAL — {{ $totalCount }} payment(s) across {{ $byUser->count() }} user(s)</span>
        <span class="ms-auto text-success fw-bold">Credit: ₹{{ number_format($grandCredit, 2) }}</span>
        @if($grandDebit > 0)
            <span class="text-danger fw-bold">Debit: ₹{{ number_format($grandDebit, 2) }}</span>
        @endif
        <span class="text-primary fw-bold">Net: ₹{{ number_format($grandNet, 2) }}</span>
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
