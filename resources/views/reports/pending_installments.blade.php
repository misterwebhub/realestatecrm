@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 flex-wrap gap-2">
        <h5 class="mb-0">{{ $title }}</h5>
        <div class="ms-auto d-flex gap-2 no-print">
            <a href="{{ route('reports.index') }}" class="btn btn-outline-secondary btn-sm">Back</a>
            <a href="{{ route('reports.pending-installments', array_merge(request()->query(), ['export' => 'csv'])) }}" class="btn btn-outline-success btn-sm"><i class="bi bi-filetype-csv"></i> Export CSV</a>
            <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i></button>
        </div>
    </div>

    <div class="card border-0 shadow-sm mb-3 no-print">
        <div class="card-body py-3">
            <div class="d-flex align-items-center justify-content-between flex-wrap gap-2 mb-3">
                <div class="d-flex align-items-center gap-2">
                    <span class="d-inline-flex align-items-center justify-content-center rounded-circle flex-shrink-0"
                          style="width:34px;height:34px;background:#4338ca1a;color:#4338ca;font-size:15px;">
                        <i class="bi bi-signpost-split-fill"></i>
                    </span>
                    <div>
                        <div class="fw-semibold text-dark" style="font-size:13.5px;">How EMI status is determined</div>
                        <div class="text-muted" style="font-size:11.5px;">Calculated dynamically from payment history — no manual reconciliation</div>
                    </div>
                </div>
                <a href="{{ route('settings.index') }}" target="_blank"
                   class="btn btn-outline-secondary btn-sm d-flex align-items-center gap-1">
                    <i class="bi bi-gear"></i> Manage in Settings
                </a>
            </div>

            <div class="d-flex align-items-stretch gap-2 flex-wrap">
                <div class="flex-fill text-center py-2 px-2 rounded" style="min-width:140px;background:#eafaf0;border:1px solid #a3e4bb;">
                    <div class="fw-bold text-success" style="font-size:12.5px;">🟢 On Time</div>
                    <div class="text-muted" style="font-size:11px;">no outstanding, no credit</div>
                </div>
                <div class="flex-fill text-center py-2 px-2 rounded" style="min-width:140px;background:#fff8ea;border:1px solid #ffe3a3;">
                    <div class="fw-bold text-warning-emphasis" style="font-size:12.5px;">🟡 Partial Payment</div>
                    <div class="text-muted" style="font-size:11px;">outstanding, within grace period</div>
                </div>
                <div class="flex-fill text-center py-2 px-2 rounded" style="min-width:140px;background:#eaf3fb;border:1px solid #a6c8e0;">
                    <div class="fw-bold" style="font-size:12.5px;color:#0d6efd;">🔵 Ahead of Schedule</div>
                    <div class="text-muted" style="font-size:11px;">total paid exceeds expected till date</div>
                </div>
                <div class="flex-fill text-center py-2 px-2 rounded" style="min-width:140px;background:#fdecec;border:1px solid #f3b8b8;">
                    <div class="fw-bold text-danger" style="font-size:12.5px;">🔴 Overdue</div>
                    <div class="text-muted" style="font-size:11px;">outstanding beyond <strong>{{ $overdueDays }}</strong> day(s) grace</div>
                </div>
                <div class="flex-fill text-center py-2 px-2 rounded" style="min-width:140px;background:#f3ecfa;border:1px solid #d3b8f3;">
                    <div class="fw-bold" style="font-size:12.5px;color:#7e22ce;">🟣 Fully Paid</div>
                    <div class="text-muted" style="font-size:11px;">finance amount fully repaid</div>
                </div>
            </div>
        </div>
    </div>

    {{-- Filters --}}
    <form method="GET" class="row g-2 align-items-end mb-3 no-print">
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Customer</label>
            <select name="customer_id" class="form-select form-select-sm js-select2">
                <option value="">All Customers</option>
                @foreach($customers as $c)
                    <option value="{{ $c->id }}" @selected((string)$customerId === (string)$c->id)>{{ $c->name }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Bond No</label>
            <select name="bond_id" class="form-select form-select-sm js-select2">
                <option value="">All Bonds</option>
                @foreach($bondsList as $b)
                    <option value="{{ $b->id }}" @selected((string)$bondId === (string)$b->id)>{{ $b->bond_no }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Arazi</label>
            <select name="arazi_code" class="form-select form-select-sm js-select2">
                <option value="">All Arazi</option>
                @foreach($araziCodes as $code)
                    <option value="{{ $code }}" @selected((string)$araziCode === (string)$code)>{{ $code }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Status</label>
            <select name="status" class="form-select form-select-sm js-select2">
                <option value="">All</option>
                <option value="on_time" @selected($status === 'on_time')>🟢 On Time</option>
                <option value="partial" @selected($status === 'partial')>🟡 Partial Payment</option>
                <option value="ahead" @selected($status === 'ahead')>🔵 Ahead of Schedule</option>
                <option value="overdue" @selected($status === 'overdue')>🔴 Overdue</option>
                <option value="fully_paid" @selected($status === 'fully_paid')>🟣 Fully Paid</option>
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Due Date From</label>
            <input type="date" name="date_from" value="{{ $dateFrom }}" class="form-control form-control-sm">
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Due Date To</label>
            <input type="date" name="date_to" value="{{ $dateTo }}" class="form-control form-control-sm">
        </div>
        <div class="col-auto d-flex gap-2">
            <button class="btn btn-primary btn-sm">Apply</button>
            <a href="{{ route('reports.pending-installments') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
        </div>
        <div class="col-12">
            <div class="text-muted" style="font-size:11px;">
                <i class="bi bi-info-circle"></i>
                Due Date defaults to <strong>today → today + Reminder Days ({{ $reminderDays }})</strong> from Settings, showing installments due now or coming up soon.
                Bonds already unpaid past their due date (Partial/Overdue, per the Overdue Days setting = {{ $overdueDays }}) always show regardless of this window. Adjust the dates above to widen or narrow the view.
            </div>
        </div>
    </form>

    {{-- Summary of the filtered result set --}}
    <div class="row g-2 mb-3">
        <div class="col-6 col-md">
            <div class="card shadow-sm border-start border-4 border-secondary h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Bonds</div>
                    <div class="fs-6 fw-bold">{{ number_format(count($rows)) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md">
            <div class="card shadow-sm border-start border-4 border-primary h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Finance Amount</div>
                    <div class="fs-6 fw-bold text-primary">₹{{ number_format($g_finance,2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md">
            <div class="card shadow-sm border-start border-4 border-dark h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Expected Till Date</div>
                    <div class="fs-6 fw-bold">₹{{ number_format($g_expected,2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md">
            <div class="card shadow-sm border-start border-4 border-success h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Total Paid</div>
                    <div class="fs-6 fw-bold text-success">₹{{ number_format($g_paid,2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md">
            <div class="card shadow-sm border-start border-4 border-danger h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Outstanding</div>
                    <div class="fs-6 fw-bold text-danger">₹{{ number_format($g_outstanding,2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md">
            <div class="card shadow-sm border-start border-4 border-info h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Credit</div>
                    <div class="fs-6 fw-bold text-info-emphasis">₹{{ number_format($g_credit,2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md">
            <div class="card shadow-sm border-start border-4 border-warning h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Remaining Balance</div>
                    <div class="fs-6 fw-bold text-warning-emphasis">₹{{ number_format($g_remaining,2) }}</div>
                </div>
            </div>
        </div>
    </div>

    <div class="card">
        <div class="table-responsive">
            <table class="table table-sm table-hover align-middle mb-0" style="font-size:11.5px;">
                <thead class="table-light">
                    <tr>
                        <th>#</th>
                        <th>Bond</th>
                        <th>Customer</th>
                        <th class="text-end">Bond Amount</th>
                        <th class="text-end">Advance</th>
                        <th class="text-end">Finance Amount</th>
                        <th class="text-end">Monthly EMI</th>
                        <th class="text-end">Expected Till Date</th>
                        <th class="text-end">Total Paid</th>
                        <th class="text-end">Outstanding</th>
                        <th class="text-end">Credit</th>
                        <th class="text-end">Remaining Balance</th>
                        <th>Last EMI Paid</th>
                        <th>Next EMI Due</th>
                        <th>Overdue</th>
                        <th class="text-center">Status</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($rows as $i => $r)
                        <tr>
                            <td>{{ $i + 1 }}</td>
                            <td class="fw-semibold" style="white-space:nowrap;">
                                <a href="{{ route('reports.emi-detail', $r['bond_id']) }}" target="_blank">{{ $r['bond_no'] }}</a>
                                <div class="text-muted" style="font-size:10.5px;">{{ $r['bond_date'] ?: '—' }}</div>
                            </td>
                            <td>
                                {{ $r['customer'] }}
                                <div class="text-muted" style="font-size:10.5px;">{{ $r['customer_mobile'] }}</div>
                            </td>
                            <td class="text-end">{{ number_format($r['bond_amount'],2) }}</td>
                            <td class="text-end">{{ number_format($r['advance_amount'],2) }}</td>
                            <td class="text-end fw-semibold">{{ number_format($r['finance_amount'],2) }}</td>
                            <td class="text-end">{{ number_format($r['monthly_emi'],2) }}</td>
                            <td class="text-end">{{ number_format($r['expected_till_date'],2) }}</td>
                            <td class="text-end text-success">{{ number_format($r['total_paid'],2) }}</td>
                            <td class="text-end {{ $r['outstanding'] > 0.009 ? 'text-danger fw-bold' : '' }}">{{ number_format($r['outstanding'],2) }}</td>
                            <td class="text-end {{ $r['credit'] > 0.009 ? 'text-info-emphasis fw-bold' : '' }}">{{ number_format($r['credit'],2) }}</td>
                            <td class="text-end">{{ number_format($r['remaining_balance'],2) }}</td>
                            <td style="white-space:nowrap;">
                                @if($r['last_emi_number'])
                                    <div>EMI #{{ $r['last_emi_number'] }}</div>
                                    <div class="text-muted" style="font-size:10.5px;">{{ $r['last_emi_date'] ?: '—' }} · ₹{{ number_format($r['last_emi_amount'],2) }}</div>
                                @else
                                    <span class="text-muted">—</span>
                                @endif
                            </td>
                            <td style="white-space:nowrap;">
                                @if($r['next_emi_number'])
                                    <div>EMI #{{ $r['next_emi_number'] }}</div>
                                    <div class="text-muted" style="font-size:10.5px;">{{ $r['next_due_date'] ?: '—' }} · ₹{{ number_format($r['next_emi_amount'],2) }}</div>
                                @else
                                    <span class="text-muted">—</span>
                                @endif
                            </td>
                            <td style="white-space:nowrap;">
                                @if($r['overdue_human'])
                                    <span class="text-danger fw-semibold">{{ $r['overdue_human'] }}</span>
                                @else
                                    <span class="text-muted">—</span>
                                @endif
                            </td>
                            <td class="text-center" style="white-space:nowrap;">
                                <span class="badge {{ $r['status_badge'] }}">{{ $r['status_emoji'] }} {{ $r['status_label'] }}</span>
                                @if($r['is_reminder'])
                                    <div class="badge bg-info-subtle text-info-emphasis mt-1">Reminder</div>
                                @endif
                            </td>
                        </tr>
                    @empty
                        <tr><td colspan="16" class="text-center text-muted py-4">No bonds match the selected filters.</td></tr>
                    @endforelse
                </tbody>
                @if(count($rows))
                <tfoot class="table-light">
                    <tr class="fw-bold">
                        <td colspan="3" class="text-end">GRAND TOTAL</td>
                        <td class="text-end">{{ number_format($g_bond_amount,2) }}</td>
                        <td class="text-end">{{ number_format($g_advance,2) }}</td>
                        <td class="text-end">{{ number_format($g_finance,2) }}</td>
                        <td></td>
                        <td class="text-end">{{ number_format($g_expected,2) }}</td>
                        <td class="text-end text-success">{{ number_format($g_paid,2) }}</td>
                        <td class="text-end text-danger">{{ number_format($g_outstanding,2) }}</td>
                        <td class="text-end text-info-emphasis">{{ number_format($g_credit,2) }}</td>
                        <td class="text-end">{{ number_format($g_remaining,2) }}</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </tfoot>
                @endif
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
