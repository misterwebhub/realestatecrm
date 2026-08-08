@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 flex-wrap gap-2">
        <div>
            <h5 class="mb-0">{{ $title }}</h5>
            <small class="text-muted">{{ $bond->customer?->name ?? '—' }} · {{ $bond->arazi?->legacy_arazi_code ?? $bond->arazi_code ?? '—' }}</small>
        </div>
        <div class="ms-auto d-flex gap-2 no-print">
            <a href="{{ route('reports.pending-installments') }}" class="btn btn-outline-secondary btn-sm">Back to Report</a>
            <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i></button>
        </div>
    </div>

    {{-- Financial Summary --}}
    <div class="card border-0 shadow-sm mb-3">
        <div class="card-body">
            <div class="d-flex align-items-center justify-content-between mb-3">
                <div class="fw-semibold" style="font-size:14px;">Financial Summary</div>
                <span class="badge {{ $meta['badge'] }}" style="font-size:12px;">{{ $meta['emoji'] }} {{ $meta['label'] }}</span>
            </div>
            <div class="row g-2">
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Bond Amount</div>
                        <div class="fw-bold">₹{{ inr($emi['bond_amount'],2) }}</div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Advance Amount</div>
                        <div class="fw-bold">₹{{ inr($emi['advance_amount'],2) }}</div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Finance Amount</div>
                        <div class="fw-bold text-primary">₹{{ inr($emi['finance_amount'],2) }}</div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Monthly EMI</div>
                        <div class="fw-bold">₹{{ inr($emi['monthly_emi'],2) }}</div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Total Installments</div>
                        <div class="fw-bold">{{ $emi['total_installments'] }}</div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Total Paid</div>
                        <div class="fw-bold text-success">₹{{ inr($emi['total_paid'],2) }}</div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Remaining Balance</div>
                        <div class="fw-bold text-warning-emphasis">₹{{ inr($emi['remaining_balance'],2) }}</div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Expected Till Date</div>
                        <div class="fw-bold">₹{{ inr($emi['expected_till_date'],2) }}</div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Outstanding</div>
                        <div class="fw-bold {{ $emi['outstanding'] > 0.009 ? 'text-danger' : '' }}">₹{{ inr($emi['outstanding'],2) }}</div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Credit</div>
                        <div class="fw-bold {{ $emi['credit'] > 0.009 ? 'text-info-emphasis' : '' }}">₹{{ inr($emi['credit'],2) }}</div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Next EMI</div>
                        @if($emi['next_emi_number'])
                            <div class="fw-bold">EMI #{{ $emi['next_emi_number'] }}</div>
                            <div class="text-muted" style="font-size:11px;">{{ optional($emi['next_due_date'])->format('d-m-Y') ?: '—' }} · ₹{{ inr($emi['next_emi_amount'],2) }}</div>
                        @else
                            <div class="fw-bold text-muted">—</div>
                        @endif
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="border rounded p-2 h-100">
                        <div class="small text-muted text-uppercase">Last EMI Paid</div>
                        @if($emi['last_emi_number'])
                            <div class="fw-bold">EMI #{{ $emi['last_emi_number'] }}</div>
                            <div class="text-muted" style="font-size:11px;">{{ optional($emi['last_emi_date'])->format('d-m-Y') ?: '—' }} · ₹{{ inr($emi['last_emi_amount'],2) }}</div>
                        @else
                            <div class="fw-bold text-muted">—</div>
                        @endif
                    </div>
                </div>
            </div>

            @if($emi['overdue_human'])
                <div class="alert alert-danger py-2 px-3 mt-3 mb-0 d-inline-flex align-items-center gap-2" style="font-size:12.5px;">
                    <i class="bi bi-exclamation-octagon-fill"></i>
                    Overdue by <strong>{{ $emi['overdue_human'] }}</strong> (grace period: {{ $overdueDays }} day(s))
                </div>
            @endif
        </div>
    </div>

    {{-- Payment History --}}
    <div class="card">
        <div class="card-header bg-white fw-semibold" style="font-size:13.5px;">Payment History</div>
        <div class="table-responsive">
            <table class="table table-sm table-hover align-middle mb-0" style="font-size:12px;">
                <thead class="table-light">
                    <tr>
                        <th>Date</th>
                        <th>Payment</th>
                        <th>Mode</th>
                        <th class="text-end">Running Total</th>
                        <th class="text-end">Outstanding</th>
                        <th class="text-end">Credit</th>
                        <th>Remarks</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($history as $h)
                        <tr class="{{ $h['is_advance'] ? 'table-secondary' : ($h['is_debit'] ? 'table-warning' : '') }}">
                            <td style="white-space:nowrap;">{{ $h['date'] }}</td>
                            <td class="{{ $h['is_debit'] ? 'text-danger' : 'text-success' }} fw-semibold">
                                {{ $h['is_debit'] ? '-' : '' }}₹{{ inr($h['amount'],2) }}
                                <div class="text-muted fw-normal" style="font-size:10.5px;">{{ $h['type'] }}</div>
                            </td>
                            <td>{{ $h['mode'] }}</td>
                            <td class="text-end">{{ $h['running_total'] !== null ? inr($h['running_total'],2) : '—' }}</td>
                            <td class="text-end {{ ($h['outstanding'] ?? 0) > 0.009 ? 'text-danger' : '' }}">{{ $h['outstanding'] !== null ? inr($h['outstanding'],2) : '—' }}</td>
                            <td class="text-end {{ ($h['credit'] ?? 0) > 0.009 ? 'text-info-emphasis' : '' }}">{{ $h['credit'] !== null ? inr($h['credit'],2) : '—' }}</td>
                            <td class="text-muted" style="font-size:11px;">{{ $h['remarks'] }}</td>
                        </tr>
                    @empty
                        <tr><td colspan="7" class="text-center text-muted py-4">No payments recorded yet.</td></tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
</div>
@endsection

@push('styles')
<style>
@media print {
    .no-print { display: none !important; }
    .card { box-shadow: none !important; border: 1px solid #ddd !important; }
}
</style>
@endpush
