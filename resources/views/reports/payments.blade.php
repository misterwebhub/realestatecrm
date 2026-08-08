@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 gap-2">
        <h4 class="mb-0"><i class="bi bi-cash-stack me-2"></i>{{ $title }}</h4>
        <div class="ms-auto d-flex gap-2">
            <a href="{{ route('reports.index') }}" class="btn btn-outline-secondary btn-sm">Back to Reports</a>
            <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i> Print</button>
        </div>
    </div>

    <div class="card shadow-sm mb-3">
        <div class="card-body">
            <form method="GET" class="row g-2 align-items-end">
                <div class="col-md-3">
                    <label class="form-label small fw-semibold mb-1">From</label>
                    <input type="date" name="date_from" value="{{ $date_from }}" class="form-control form-control-sm">
                </div>
                <div class="col-md-3">
                    <label class="form-label small fw-semibold mb-1">To</label>
                    <input type="date" name="date_to" value="{{ $date_to }}" class="form-control form-control-sm">
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">Type</label>
                    <select name="entry_type" class="form-select form-select-sm js-select2">
                        <option value="">All</option>
                        @foreach($entryTypes as $t)
                            <option value="{{ $t }}" @selected($entry_type === $t)>{{ ucfirst($t) }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">Method</label>
                    <select name="payment_method" class="form-select form-select-sm js-select2">
                        <option value="">All</option>
                        @foreach($methods as $m)
                            <option value="{{ $m }}" @selected($payment_method === $m)>{{ ucfirst($m) }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">Arazi</label>
                    <select name="arazi_code" class="form-select form-select-sm js-select2">
                        <option value="">All</option>
                        @foreach($araziOptions as $c)
                            <option value="{{ $c }}" @selected($arazi_code === $c)>{{ $c }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-auto d-flex gap-2">
                    <button class="btn btn-primary btn-sm">Apply</button>
                    <a href="{{ route('reports.payments') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                </div>
                <div class="col-auto ms-auto">
                    <span class="text-muted small">Total Collected</span>
                    <div class="fs-5 fw-bold text-success">{{ inr($total,2) }}</div>
                </div>
            </form>
        </div>
    </div>

    <div class="row g-3">
        <div class="col-md-6">
            <div class="card shadow-sm">
                <div class="card-header bg-light fw-semibold">By Month</div>
                <div class="table-responsive">
                    <table class="table table-sm table-hover align-middle mb-0">
                        <thead class="table-light"><tr><th>Month</th><th class="text-center">Entries</th><th class="text-end">Amount</th></tr></thead>
                        <tbody>
                            @forelse($byMonth as $m)
                                <tr><td>{{ $m['month'] }}</td><td class="text-center">{{ $m['count'] }}</td><td class="text-end">{{ inr($m['amount'],2) }}</td></tr>
                            @empty
                                <tr><td colspan="3" class="text-center text-muted py-3">No data.</td></tr>
                            @endforelse
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="card shadow-sm">
                <div class="card-header bg-light fw-semibold">By Type</div>
                <div class="table-responsive">
                    <table class="table table-sm table-hover align-middle mb-0">
                        <thead class="table-light"><tr><th>Type</th><th class="text-center">Entries</th><th class="text-end">Amount</th></tr></thead>
                        <tbody>
                            @forelse($byType as $t)
                                <tr><td>{{ $t['type'] }}</td><td class="text-center">{{ $t['count'] }}</td><td class="text-end">{{ inr($t['amount'],2) }}</td></tr>
                            @empty
                                <tr><td colspan="3" class="text-center text-muted py-3">No data.</td></tr>
                            @endforelse
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
@endsection
