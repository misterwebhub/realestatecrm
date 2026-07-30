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
                        <div class="fw-semibold text-dark" style="font-size:13.5px;">How installment status is determined</div>
                        <div class="text-muted" style="font-size:11.5px;">Based on days relative to each bond's installment due date</div>
                    </div>
                </div>
                <a href="{{ route('settings.index') }}" target="_blank"
                   class="btn btn-outline-secondary btn-sm d-flex align-items-center gap-1">
                    <i class="bi bi-gear"></i> Manage in Settings
                </a>
            </div>

            <div class="d-flex align-items-stretch gap-2 flex-wrap">
                <div class="flex-fill text-center py-2 px-2 rounded" style="min-width:150px;background:#fff8ea;border:1px solid #ffe3a3;">
                    <div class="fw-bold text-warning-emphasis" style="font-size:12.5px;"><i class="bi bi-hourglass-split me-1"></i>Pending</div>
                    <div class="text-muted" style="font-size:11px;">before the due date</div>
                </div>
                <div class="d-flex align-items-center text-muted"><i class="bi bi-arrow-right"></i></div>
                <div class="flex-fill text-center py-2 px-2 rounded" style="min-width:170px;background:#eaf7fb;border:1px solid #a6e0f0;">
                    <div class="fw-bold text-info-emphasis" style="font-size:12.5px;"><i class="bi bi-bell-fill me-1"></i>Reminder</div>
                    <div class="text-muted" style="font-size:11px;">within <strong>{{ $reminderDays }}</strong> day(s) of the due date</div>
                </div>
                <div class="d-flex align-items-center text-muted"><i class="bi bi-arrow-right"></i></div>
                <div class="flex-fill text-center py-2 px-2 rounded" style="min-width:170px;background:#eef2ff;border:1px solid #c7d2fe;">
                    <div class="fw-bold" style="font-size:12.5px;color:#4338ca;"><i class="bi bi-calendar-event-fill me-1"></i>Due Date</div>
                    <div class="text-muted" style="font-size:11px;">day the installment is due</div>
                </div>
                <div class="d-flex align-items-center text-muted"><i class="bi bi-arrow-right"></i></div>
                <div class="flex-fill text-center py-2 px-2 rounded" style="min-width:170px;background:#fdecec;border:1px solid #f3b8b8;">
                    <div class="fw-bold text-danger" style="font-size:12.5px;"><i class="bi bi-exclamation-octagon-fill me-1"></i>Overdue</div>
                    <div class="text-muted" style="font-size:11px;">more than <strong>{{ $overdueDays }}</strong> day(s) past due</div>
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
                <option value="pending" @selected($status === 'pending')>Pending</option>
                <option value="overdue" @selected($status === 'overdue')>Overdue</option>
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
                    <div class="small text-muted text-uppercase">Total Bond Amount</div>
                    <div class="fs-6 fw-bold text-primary">₹{{ number_format($g_total,2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md">
            <div class="card shadow-sm border-start border-4 border-success h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Paid Cheque</div>
                    <div class="fs-6 fw-bold text-success">₹{{ number_format($g_paid_cheque,2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md">
            <div class="card shadow-sm border-start border-4 border-success h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Paid Cash</div>
                    <div class="fs-6 fw-bold text-success">₹{{ number_format($g_paid_cash,2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md">
            <div class="card shadow-sm border-start border-4 border-info h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Paid Other</div>
                    <div class="fs-6 fw-bold text-info-emphasis">₹{{ number_format($g_paid_other,2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md">
            <div class="card shadow-sm border-start border-4 border-danger h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Total Balance</div>
                    <div class="fs-6 fw-bold text-danger">₹{{ number_format($g_balance,2) }}</div>
                </div>
            </div>
        </div>
    </div>

    <div class="card">
        <div class="table-responsive">
            <table class="table table-sm table-hover align-middle mb-0" style="font-size:12px;">
                <thead class="table-light">
                    <tr>
                        <th>#</th>
                        <th>Bond</th>
                        <th>Bond Date</th>
                        <th>Customer</th>
                        <th>Mobile</th>
                        <th>Arazi / Plots</th>
                        <th>Installment Due Date</th>
                        <th class="text-end">Total Bond Amount</th>
                        <th class="text-end">No. of Installments</th>
                        <th class="text-end">Due Amount</th>
                        <th class="text-end">Paid Cheque</th>
                        <th class="text-end">Paid Cash</th>
                        <th class="text-end">Paid Other</th>
                        <th class="text-end">Balance</th>
                        <th class="text-center">Status</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($rows as $i => $r)
                        <tr>
                            <td>{{ $i + 1 }}</td>
                            <td class="fw-semibold">{{ $r['bond_no'] }}</td>
                            <td class="text-muted" style="white-space:nowrap;">{{ $r['bond_date'] ?: '—' }}</td>
                            <td>{{ $r['customer'] }}</td>
                            <td>{{ $r['customer_mobile'] }}</td>
                            <td style="min-width:150px;">
                                <span class="badge bg-primary-subtle text-primary-emphasis mb-1">{{ $r['arazi'] }}</span>
                                @if(count($r['plots']) === 0)
                                    <div class="text-muted" style="font-size:11px;">No plots</div>
                                @else
                                    @php $plotTotal = collect($r['plots'])->sum('gaz'); @endphp
                                    <table style="width:100%;border-collapse:collapse;font-size:10px;border:1px solid #d0ddf0;border-radius:4px;overflow:hidden;">
                                        <thead>
                                            <tr style="background:#1a3a6b;">
                                                <th style="padding:1px 5px;color:rgba(255,255,255,.8);font-size:9px;font-weight:600;text-transform:uppercase;letter-spacing:.3px;border-right:1px solid rgba(255,255,255,.12);text-align:left;">Plot</th>
                                                <th style="padding:1px 5px;color:rgba(255,255,255,.8);font-size:9px;font-weight:600;text-transform:uppercase;letter-spacing:.3px;border-right:1px solid rgba(255,255,255,.12);text-align:right;">Gaz</th>
                                                <th style="padding:1px 5px;color:rgba(255,255,255,.8);font-size:9px;font-weight:600;text-transform:uppercase;letter-spacing:.3px;text-align:center;">Registry</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            @foreach($r['plots'] as $j => $pl)
                                                <tr style="background:{{ $j % 2 === 0 ? '#fff' : '#f6f9ff' }};border-bottom:1px solid #e4ecf7;">
                                                    <td style="padding:1px 5px;border-right:1px solid #e4ecf7;font-weight:600;color:#1a3a6b;white-space:nowrap;">{{ $pl['label'] ?: '—' }}</td>
                                                    <td style="padding:1px 5px;border-right:1px solid #e4ecf7;text-align:right;color:#374151;white-space:nowrap;">{{ rtrim(rtrim(number_format($pl['gaz'],2),'0'),'.') }}</td>
                                                    <td style="padding:1px 5px;text-align:center;white-space:nowrap;">
                                                        @if($pl['registry'] === 'Y')
                                                            <span style="color:#15803d;font-weight:700;">Y</span>
                                                        @else
                                                            <span style="color:#dc2626;font-weight:700;">N</span>
                                                        @endif
                                                    </td>
                                                </tr>
                                            @endforeach
                                            @if(count($r['plots']) > 1)
                                                <tr style="background:#eef4ff;border-top:1px solid #d0ddf0;">
                                                    <td style="padding:1px 5px;border-right:1px solid #e4ecf7;font-weight:700;color:#15803d;text-align:right;">Total</td>
                                                    <td style="padding:1px 5px;border-right:1px solid #e4ecf7;text-align:right;font-weight:700;color:#15803d;white-space:nowrap;">{{ rtrim(rtrim(number_format($plotTotal,2),'0'),'.') }}</td>
                                                    <td></td>
                                                </tr>
                                            @endif
                                        </tbody>
                                    </table>
                                @endif
                            </td>
                            <td style="white-space:nowrap;">
                                {{ $r['last_date'] }}
                                @if($r['days_past_due'] > 0)
                                    <div class="text-muted" style="font-size:11px;">{{ $r['days_past_due'] }} day(s) past due</div>
                                @elseif($r['days_past_due'] < 0)
                                    <div class="text-muted" style="font-size:11px;">due in {{ abs($r['days_past_due']) }} day(s)</div>
                                @else
                                    <div class="text-muted" style="font-size:11px;">due today</div>
                                @endif
                            </td>
                            <td class="text-end fw-semibold">{{ number_format($r['total'],2) }}</td>
                            <td class="text-end">{{ $r['no_of_installments'] ?? '—' }}</td>
                            <td class="text-end">{{ $r['due_amount'] !== null ? number_format($r['due_amount'],2) : '—' }}</td>
                            <td class="text-end text-success">{{ number_format($r['paid_cheque'],2) }}</td>
                            <td class="text-end text-success">{{ number_format($r['paid_cash'],2) }}</td>
                            <td class="text-end text-info-emphasis">{{ number_format($r['paid_other'],2) }}</td>
                            <td class="text-end fw-bold text-danger">{{ number_format($r['balance'],2) }}</td>
                            <td class="text-center">
                                @if($r['status'] === 'Overdue')
                                    <span class="badge bg-danger">Overdue</span>
                                @else
                                    <span class="badge bg-warning text-dark">Pending</span>
                                @endif
                                @if($r['is_reminder'])
                                    <div class="badge bg-info-subtle text-info-emphasis mt-1">Reminder</div>
                                @endif
                            </td>
                        </tr>
                    @empty
                        <tr><td colspan="15" class="text-center text-muted py-4">No pending installments found.</td></tr>
                    @endforelse
                </tbody>
                @if(count($rows))
                <tfoot class="table-light">
                    <tr class="fw-bold">
                        <td colspan="7" class="text-end">GRAND TOTAL</td>
                        <td class="text-end">{{ number_format($g_total,2) }}</td>
                        <td></td>
                        <td></td>
                        <td class="text-end text-success">{{ number_format($g_paid_cheque,2) }}</td>
                        <td class="text-end text-success">{{ number_format($g_paid_cash,2) }}</td>
                        <td class="text-end text-info-emphasis">{{ number_format($g_paid_other,2) }}</td>
                        <td class="text-end text-danger">{{ number_format($g_balance,2) }}</td>
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
