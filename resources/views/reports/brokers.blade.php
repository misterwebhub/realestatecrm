@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 gap-2">
        <h4 class="mb-0"><i class="bi bi-person-badge me-2"></i>{{ $title }}</h4>
        <div class="ms-auto d-flex gap-2">
            <a href="{{ route('reports.index') }}" class="btn btn-outline-secondary btn-sm">Back to Reports</a>
            <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i> Print</button>
        </div>
    </div>

    <div class="card shadow-sm mb-3">
        <div class="card-body">
            <form method="GET" class="row g-2 align-items-end">
                <div class="col-md-3">
                    <label class="form-label small fw-semibold mb-1">Broker</label>
                    <select name="broker_id" class="form-select form-select-sm js-select2">
                        <option value="">All Brokers</option>
                        @foreach($agents as $a)
                            <option value="{{ $a->id }}" @selected((string)$brokerId === (string)$a->id)>{{ $a->name }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">Balance</label>
                    <select name="balance_state" class="form-select form-select-sm js-select2">
                        <option value="">All</option>
                        <option value="due" @selected($balanceState==='due')>Has Outstanding</option>
                        <option value="clear" @selected($balanceState==='clear')>Cleared</option>
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">Bonds</label>
                    <select name="has_bonds" class="form-select form-select-sm js-select2">
                        <option value="">All</option>
                        <option value="1" @selected($hasBonds==='1')>Only with bonds</option>
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
                    <a href="{{ route('reports.brokers') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                </div>
            </form>
        </div>
    </div>

    <div class="row g-2 mb-3">
        <div class="col-md-3"><div class="card shadow-sm border-start border-4 border-primary"><div class="card-body py-2"><div class="small text-muted text-uppercase">Bond Total</div><div class="fs-6 fw-bold">{{ inr($total_bond,2) }}</div></div></div></div>
        <div class="col-md-3"><div class="card shadow-sm border-start border-4 border-info"><div class="card-body py-2"><div class="small text-muted text-uppercase">Commission</div><div class="fs-6 fw-bold">{{ inr($total_commission,2) }}</div></div></div></div>
        <div class="col-md-3"><div class="card shadow-sm border-start border-4 border-success"><div class="card-body py-2"><div class="small text-muted text-uppercase">Paid</div><div class="fs-6 fw-bold text-success">{{ inr($total_paid,2) }}</div></div></div></div>
        <div class="col-md-3"><div class="card shadow-sm border-start border-4 border-danger"><div class="card-body py-2"><div class="small text-muted text-uppercase">Balance</div><div class="fs-6 fw-bold text-danger">{{ inr($total_balance,2) }}</div></div></div></div>
    </div>

    <div class="card shadow-sm">
        <div class="table-responsive">
            <table class="table table-sm table-hover align-middle mb-0">
                <thead class="table-light">
                    <tr>
                        <th>Broker</th>
                        <th>Mobile</th>
                        <th class="text-center">Comm %</th>
                        <th class="text-center">Bonds</th>
                        <th class="text-end">Bond Total</th>
                        <th class="text-end">Commission</th>
                        <th class="text-end">Paid</th>
                        <th class="text-end">Balance</th>
                        <th class="text-center">Registries</th>
                        <th class="text-center">Done</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($rows as $r)
                        <tr>
                            <td class="fw-semibold">{{ $r['broker'] }}</td>
                            <td class="small text-muted">{{ $r['mobile'] }}</td>
                            <td class="text-center">{{ $r['commission_pct'] !== null ? $r['commission_pct'].'%' : '-' }}</td>
                            <td class="text-center">{{ $r['bonds'] }}</td>
                            <td class="text-end">{{ inr($r['bond_total'],2) }}</td>
                            <td class="text-end">{{ inr($r['commission'],2) }}</td>
                            <td class="text-end text-success">{{ inr($r['paid'],2) }}</td>
                            <td class="text-end {{ $r['balance'] > 0 ? 'text-danger fw-semibold' : '' }}">{{ inr($r['balance'],2) }}</td>
                            <td class="text-center">{{ $r['reg_total'] }}</td>
                            <td class="text-center">
                                @if($r['reg_done'] > 0)<span class="badge bg-success">{{ $r['reg_done'] }}</span>@else<span class="text-muted">0</span>@endif
                            </td>
                        </tr>
                    @empty
                        <tr><td colspan="10" class="text-center text-muted py-4">No brokers found.</td></tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
</div>
@endsection
