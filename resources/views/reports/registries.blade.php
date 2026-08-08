@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 gap-2">
        <h4 class="mb-0"><i class="bi bi-file-earmark-text me-2"></i>{{ $title }}</h4>
        <div class="ms-auto d-flex gap-2">
            <a href="{{ route('reports.index') }}" class="btn btn-outline-secondary btn-sm">Back to Reports</a>
            <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i> Print</button>
        </div>
    </div>

    <div class="card shadow-sm mb-3">
        <div class="card-body">
            <form method="GET" class="row g-2 align-items-end">
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">Arazi</label>
                    <select name="arazi_code" class="form-select form-select-sm js-select2">
                        <option value="">All</option>
                        @foreach($araziOptions as $c)
                            <option value="{{ $c }}" @selected($araziCode === $c)>{{ $c }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">Broker</label>
                    <select name="agent_id" class="form-select form-select-sm js-select2">
                        <option value="">All</option>
                        @foreach($agents as $a)
                            <option value="{{ $a->id }}" @selected((string)$agentId === (string)$a->id)>{{ $a->name }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">Customer</label>
                    <select name="customer_id" class="form-select form-select-sm js-select2">
                        <option value="">All</option>
                        @foreach($customers as $c)
                            <option value="{{ $c->id }}" @selected((string)$customerId === (string)$c->id)>{{ \Illuminate\Support\Str::limit($c->name, 30) }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">Payment</label>
                    <select name="pay_state" class="form-select form-select-sm js-select2">
                        <option value="">All</option>
                        <option value="paid" @selected($payState==='paid')>Fully Paid</option>
                        <option value="partial" @selected($payState==='partial')>Partial</option>
                        <option value="unpaid" @selected($payState==='unpaid')>Unpaid</option>
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">From</label>
                    <input type="date" name="date_from" value="{{ $dateFrom }}" class="form-control form-control-sm">
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">To</label>
                    <input type="date" name="date_to" value="{{ $dateTo }}" class="form-control form-control-sm">
                </div>
                <div class="col-auto d-flex gap-2">
                    <button class="btn btn-primary btn-sm">Apply</button>
                    <a href="{{ route('reports.registries') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                </div>
                <div class="col-auto ms-auto text-end small">
                    <span class="text-muted">Showing {{ $count }} • Amount</span>
                    <span class="fw-bold">{{ inr($sum_amount,2) }}</span>
                    <span class="text-muted">• Balance</span>
                    <span class="fw-bold text-danger">{{ inr($sum_balance,2) }}</span>
                </div>
            </form>
        </div>
    </div>

    <div class="row g-3 mb-3">
        @foreach($statusRows as $s)
            <div class="col-md-3">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <div class="text-muted small text-uppercase">{{ $s['status'] }}</div>
                        <div class="fs-4 fw-bold">{{ $s['count'] }}</div>
                        <div class="small text-muted">Amount: {{ inr($s['amount'],2) }}</div>
                    </div>
                </div>
            </div>
        @endforeach
    </div>

    <div class="card shadow-sm">
        <div class="card-header bg-light fw-semibold">Latest Registries</div>
        <div class="table-responsive">
            <table class="table table-sm table-hover align-middle mb-0">
                <thead class="table-light">
                    <tr>
                        <th>Reg Code</th>
                        <th>Customer</th>
                        <th>Arazi</th>
                        <th>Broker</th>
                        <th>Date</th>
                        <th class="text-end">Amount</th>
                        <th class="text-center">Registry</th>
                        <th style="min-width:180px;">Payment Status</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($recent as $r)
                        <tr>
                            <td>{{ $r->registry_code ?? ('REG-'.$r->id) }}</td>
                            <td>{{ $r->customer?->name ?? '-' }}</td>
                            <td><span class="badge bg-primary-subtle text-primary-emphasis">{{ $r->arazi_code ?? '-' }}</span></td>
                            <td>{{ $r->agent?->name ?? '-' }}</td>
                            <td>{{ optional($r->registry_date)->format('d-m-Y') ?? '-' }}</td>
                            <td class="text-end">{{ inr((float)($r->registry_amount ?? 0),2) }}</td>
                            <td class="text-center">
                                <span class="badge bg-success"><i class="bi bi-check-circle me-1"></i>Done</span>
                            </td>
                            <td>
                                @php
                                    $pct = (float)($r->pay_percent ?? 0);
                                    $bal = (float)($r->pay_balance ?? 0);
                                    $barClass = $pct >= 100 ? 'bg-success' : ($pct >= 50 ? 'bg-info' : 'bg-warning');
                                @endphp
                                <div class="d-flex justify-content-between small mb-1">
                                    <span class="fw-semibold">{{ number_format($pct,1) }}% paid</span>
                                    <span class="{{ $bal > 0 ? 'text-danger' : 'text-success' }}">Bal: {{ inr($bal,2) }}</span>
                                </div>
                                <div class="progress" style="height:6px;">
                                    <div class="progress-bar {{ $barClass }}" style="width:{{ min($pct,100) }}%"></div>
                                </div>
                            </td>
                        </tr>
                    @empty
                        <tr><td colspan="8" class="text-center text-muted py-4">No registries found.</td></tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
</div>
@endsection
