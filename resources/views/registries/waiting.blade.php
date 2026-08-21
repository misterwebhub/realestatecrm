@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 flex-wrap gap-2">
        <h5 class="mb-0">{{ $title }}</h5>
        <span class="badge bg-warning text-dark">Pending registries with 50% or less paid</span>
        <div class="ms-auto d-flex gap-2 no-print">
            <a href="{{ route('registries.index') }}" class="btn btn-outline-secondary btn-sm">Back to Registries</a>
            <a href="{{ route('registries.waiting-payments', array_merge(request()->query(), ['export' => 'csv'])) }}" class="btn btn-outline-success btn-sm"><i class="bi bi-filetype-csv"></i> Export CSV</a>
            <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i></button>
        </div>
    </div>

    {{-- Filters --}}
    <form method="GET" class="row g-2 align-items-end mb-3 no-print">
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
            <label class="form-label small fw-semibold mb-1">Customer</label>
            <select name="customer_id" class="form-select form-select-sm js-select2">
                <option value="">All Customers</option>
                @foreach($customers as $c)
                    <option value="{{ $c->id }}" @selected((string)$customerId === (string)$c->id)>{{ $c->name }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Broker</label>
            <select name="broker_id" class="form-select form-select-sm js-select2">
                <option value="">All Brokers</option>
                @foreach($brokers as $b)
                    <option value="{{ $b->id }}" @selected((string)$brokerId === (string)$b->id)>{{ $b->name }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            {{-- Plot titles behave like plot numbers, so this is matched exactly, never LIKE --}}
            <label class="form-label small fw-semibold mb-1">Plot (exact)</label>
            <input type="text" name="plot_title" value="{{ $plotTitle }}" class="form-control form-control-sm" placeholder="e.g. 42A">
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Due From</label>
            <input type="date" name="due_from" value="{{ $dueFrom }}" class="form-control form-control-sm">
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Due To</label>
            <input type="date" name="due_to" value="{{ $dueTo }}" class="form-control form-control-sm">
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Overdue</label>
            <select name="overdue" class="form-select form-select-sm js-select2">
                <option value="">All</option>
                <option value="Y" @selected($overdue === 'Y')>Overdue only</option>
                <option value="N" @selected($overdue === 'N')>Not overdue</option>
            </select>
        </div>
        <div class="col-auto d-flex gap-2">
            <button class="btn btn-primary btn-sm">Apply</button>
            <a href="{{ route('registries.waiting-payments') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
        </div>
    </form>

    {{-- Cumulative summary of the filtered result set --}}
    <div class="row g-2 mb-3">
        <div class="col-6 col-md-2">
            <div class="card shadow-sm border-start border-4 border-secondary h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Registries</div>
                    <div class="fs-6 fw-bold">{{ number_format(count($rows)) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md-2">
            <div class="card shadow-sm border-start border-4 h-100" style="border-left-color:#0f766e !important;">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Total Gaz</div>
                    <div class="fs-6 fw-bold" style="color:#0f766e;">{{ number_format($g_gaz, 2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md-2">
            <div class="card shadow-sm border-start border-4 border-primary h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Amount</div>
                    <div class="fs-6 fw-bold text-primary">₹{{ inr($g_amount, 2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md-2">
            <div class="card shadow-sm border-start border-4 border-success h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Paid</div>
                    <div class="fs-6 fw-bold text-success">₹{{ inr($g_paid, 2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md-2">
            <div class="card shadow-sm border-start border-4 border-danger h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Balance</div>
                    <div class="fs-6 fw-bold {{ $g_balance > 0 ? 'text-danger' : 'text-success' }}">₹{{ inr($g_balance, 2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md-2">
            <div class="card shadow-sm border-start border-4 border-warning h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Overdue</div>
                    <div class="fs-6 fw-bold text-warning-emphasis">{{ number_format($overdueCount) }}</div>
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
                        <th>Registry</th>
                        <th>Customer</th>
                        <th>Arazi</th>
                        <th>Plot (gaz)</th>
                        <th>Broker</th>
                        <th>Deed No</th>
                        <th class="text-end">Amount</th>
                        <th class="text-end">Paid</th>
                        <th class="text-end">Balance</th>
                        <th class="text-end">Paid %</th>
                        <th>Due Date</th>
                        <th class="text-center">Days Left</th>
                        <th class="text-center">Status</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($rows as $i => $r)
                        <tr>
                            <td>{{ $i + 1 }}</td>
                            <td class="fw-semibold">
                                <a href="{{ $r['registry_url'] }}" target="_blank" rel="noopener">{{ $r['registry_code'] }}</a>
                            </td>
                            <td>{{ $r['customer'] }}</td>
                            <td><span class="badge bg-primary-subtle text-primary-emphasis">{{ $r['arazi'] }}</span></td>
                            <td style="min-width:120px;">
                                @if(count($r['plots']) === 0)
                                    <span class="text-muted">—</span>
                                    @if($r['gaz'] > 0)
                                        <span class="fw-semibold" style="color:#0f766e;">{{ rtrim(rtrim(number_format($r['gaz'],2),'0'),'.') }} gaz</span>
                                    @endif
                                @else
                                    <table style="width:100%;border-collapse:collapse;font-size:10px;border:1px solid #d0ddf0;border-radius:4px;overflow:hidden;">
                                        <thead>
                                            <tr style="background:#1a3a6b;">
                                                <th style="padding:1px 5px;color:rgba(255,255,255,.8);font-size:9px;font-weight:600;text-transform:uppercase;letter-spacing:.3px;border-right:1px solid rgba(255,255,255,.12);text-align:left;">Plot</th>
                                                <th style="padding:1px 5px;color:rgba(255,255,255,.8);font-size:9px;font-weight:600;text-transform:uppercase;letter-spacing:.3px;text-align:right;">Gaz</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            @foreach($r['plots'] as $j => $pl)
                                                <tr style="background:{{ $j % 2 === 0 ? '#fff' : '#f6f9ff' }};border-bottom:1px solid #e4ecf7;">
                                                    <td style="padding:1px 5px;border-right:1px solid #e4ecf7;font-weight:600;color:#1a3a6b;white-space:nowrap;">{{ $pl['label'] ?: '—' }}</td>
                                                    <td style="padding:1px 5px;text-align:right;color:#374151;white-space:nowrap;">{{ rtrim(rtrim(number_format($pl['gaz'],2),'0'),'.') }}</td>
                                                </tr>
                                            @endforeach
                                            {{-- Total row is always shown so the plot cell alone
                                                 carries the registry's full gaz figure. --}}
                                            <tr style="background:#eef4ff;border-top:1px solid #d0ddf0;">
                                                <td style="padding:1px 5px;border-right:1px solid #e4ecf7;font-weight:700;color:#15803d;text-align:right;">Total</td>
                                                <td style="padding:1px 5px;text-align:right;font-weight:700;color:#15803d;white-space:nowrap;">{{ rtrim(rtrim(number_format($r['gaz'],2),'0'),'.') }}</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                @endif
                            </td>
                            <td>{{ $r['broker'] }}</td>
                            <td>{{ $r['deed_no'] }}</td>
                            <td class="text-end">{{ inr($r['amount'], 2) }}</td>
                            <td class="text-end text-success">{{ inr($r['paid'], 2) }}</td>
                            <td class="text-end fw-semibold {{ $r['balance'] > 0 ? 'text-danger' : 'text-success' }}">{{ inr($r['balance'], 2) }}</td>
                            <td class="text-end">{{ number_format($r['percent'], 1) }}%</td>
                            <td style="white-space:nowrap;">{{ $r['due_date'] }}</td>
                            <td class="text-center" style="white-space:nowrap;">
                                @if($r['overdue'])
                                    <span class="badge text-bg-danger">Overdue {{ abs($r['days_left']) }} day(s)</span>
                                @elseif($r['days_left'] <= 3)
                                    <span class="badge text-bg-warning">{{ $r['days_left'] }} day(s)</span>
                                @else
                                    <span class="badge text-bg-info">{{ $r['days_left'] }} day(s)</span>
                                @endif
                            </td>
                            <td class="text-center"><span class="badge text-bg-secondary">{{ ucfirst((string) $r['status']) }}</span></td>
                        </tr>
                    @empty
                        <tr><td colspan="14" class="text-center text-muted py-4">No pending payments found.</td></tr>
                    @endforelse
                </tbody>
                @if(count($rows))
                <tfoot class="table-light">
                    <tr class="fw-bold">
                        <td colspan="4" class="text-end">GRAND TOTAL</td>
                        <td class="text-end" style="color:#0f766e;">
                            <div class="small text-muted fw-normal text-uppercase" style="font-size:9px;">Total Gaz</div>
                            <div>{{ number_format($g_gaz, 2) }}</div>
                        </td>
                        <td></td>
                        <td></td>
                        <td class="text-end">
                            <div class="small text-muted fw-normal text-uppercase" style="font-size:9px;">Amount</div>
                            <div>{{ inr($g_amount, 2) }}</div>
                        </td>
                        <td class="text-end text-success">
                            <div class="small text-muted fw-normal text-uppercase" style="font-size:9px;">Paid</div>
                            <div>{{ inr($g_paid, 2) }}</div>
                        </td>
                        <td class="text-end {{ $g_balance > 0 ? 'text-danger' : 'text-success' }}">
                            <div class="small text-muted fw-normal text-uppercase" style="font-size:9px;">Balance</div>
                            <div>{{ inr($g_balance, 2) }}</div>
                        </td>
                        <td></td>
                        <td></td>
                        <td class="text-center">
                            <div class="small text-muted fw-normal text-uppercase" style="font-size:9px;">Overdue</div>
                            <div>{{ number_format($overdueCount) }}</div>
                        </td>
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
    @page { size: A4 landscape; margin: 8mm 6mm; }

    .app-sidebar, .app-header, .app-footer, .no-print { display: none !important; }

    body, .app-wrapper, .app-main, .app-content, .container-fluid {
        display: block !important;
        width: 100% !important;
        max-width: 100% !important;
        margin: 0 !important;
        padding: 0 !important;
        background: #fff !important;
    }

    .card { box-shadow: none !important; border: 1px solid #ddd !important; }

    /* .table-responsive scrolls on screen; left as-is, printing silently
       cuts off every column past the visible fold. */
    .table-responsive {
        overflow: visible !important;
        width: 100% !important;
    }

    table.table { width: 100% !important; font-size: 8px !important; }
    table.table th, table.table td { padding: 2px 3px !important; }

    /* Nested Plot/Gaz mini-table inside the Plot cell */
    table.table td table { font-size: 7.5px !important; }

    table.table, table.table * {
        -webkit-print-color-adjust: exact !important;
        print-color-adjust: exact !important;
        color-adjust: exact !important;
    }

    tr { page-break-inside: avoid; }

    table.table a[href] { color: inherit !important; text-decoration: none !important; }
    table.table a[href]::after { content: none !important; }
}
</style>
@endpush
