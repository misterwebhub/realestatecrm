@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 gap-2">
        <h4 class="mb-0"><i class="bi bi-graph-up-arrow me-2"></i>{{ $title }}</h4>
        <div class="ms-auto d-flex gap-2">
            <a href="{{ route('reports.index') }}" class="btn btn-outline-secondary btn-sm">Back to Reports</a>
            <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i> Print</button>
        </div>
    </div>

    <div class="card shadow-sm mb-3">
        <div class="card-body">
            <form method="GET" class="row g-2 align-items-end">
                <div class="col-md-3">
                    <label class="form-label small fw-semibold mb-1">Arazi</label>
                    <select name="arazi_code" class="form-select form-select-sm js-select2">
                        <option value="">All Arazis</option>
                        @foreach($araziOptions as $c)
                            <option value="{{ $c }}" @selected($araziCode === $c)>{{ $c }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-3">
                    <label class="form-label small fw-semibold mb-1">Location</label>
                    <select name="location" class="form-select form-select-sm js-select2">
                        <option value="">All Locations</option>
                        @foreach($locationOptions as $l)
                            <option value="{{ $l }}" @selected($location === $l)>{{ $l }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">Reg. From</label>
                    <input type="date" name="date_from" value="{{ $dateFrom }}" class="form-control form-control-sm">
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold mb-1">Reg. To</label>
                    <input type="date" name="date_to" value="{{ $dateTo }}" class="form-control form-control-sm">
                </div>
                <div class="col-auto d-flex gap-2">
                    <button class="btn btn-primary btn-sm">Apply</button>
                    <a href="{{ route('reports.sales') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                </div>
            </form>
        </div>
    </div>

    <div class="row g-3">
        <div class="col-md-4">
            <div class="card shadow-sm border-start border-4 border-primary">
                <div class="card-body">
                    <div class="text-muted small text-uppercase">Total Arazis</div>
                    <div class="fs-3 fw-bold">{{ $arazi_count }}</div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card shadow-sm border-start border-4 border-info">
                <div class="card-body">
                    <div class="text-muted small text-uppercase">Saleable Area</div>
                    <div class="fs-3 fw-bold">{{ number_format($total_saleable,2) }} <small class="fs-6 text-muted">gaz</small></div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card shadow-sm border-start border-4 border-success">
                <div class="card-body">
                    <div class="text-muted small text-uppercase">Sold Area</div>
                    <div class="fs-3 fw-bold text-success">{{ number_format($total_sold,2) }} <small class="fs-6 text-muted">gaz</small></div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card shadow-sm border-start border-4 border-danger">
                <div class="card-body">
                    <div class="text-muted small text-uppercase">Remaining Area</div>
                    <div class="fs-3 fw-bold text-danger">{{ number_format($total_remaining,2) }} <small class="fs-6 text-muted">gaz</small></div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card shadow-sm border-start border-4 border-warning">
                <div class="card-body">
                    <div class="text-muted small text-uppercase">Sold %</div>
                    <div class="fs-3 fw-bold">{{ $sold_pct }}%</div>
                    <div class="progress mt-2" style="height:8px;">
                        <div class="progress-bar bg-success" style="width:{{ min($sold_pct,100) }}%"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card shadow-sm border-start border-4 border-secondary">
                <div class="card-body">
                    <div class="text-muted small text-uppercase">Estimated Sold Value</div>
                    <div class="fs-3 fw-bold">₹{{ number_format($total_value,2) }}</div>
                </div>
            </div>
        </div>
    </div>

    <div class="card shadow-sm mt-3">
        <div class="card-header bg-light fw-semibold">Per-Arazi Breakdown</div>
        <div class="table-responsive">
            <table class="table table-sm table-hover align-middle mb-0">
                <thead class="table-light">
                    <tr>
                        <th>Arazi</th>
                        <th>Location</th>
                        <th class="text-end">Saleable (gaz)</th>
                        <th class="text-end">Sold (gaz)</th>
                        <th class="text-end">Remaining (gaz)</th>
                        <th style="min-width:120px;">Sold %</th>
                        <th class="text-end">Sold Value</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($breakdown as $b)
                        <tr>
                            <td><span class="badge bg-primary-subtle text-primary-emphasis">{{ $b['arazi'] }}</span></td>
                            <td class="small text-muted">{{ $b['location'] }}</td>
                            <td class="text-end">{{ number_format($b['saleable'],2) }}</td>
                            <td class="text-end text-success">{{ number_format($b['sold'],2) }}</td>
                            <td class="text-end text-danger">{{ number_format($b['remaining'],2) }}</td>
                            <td>
                                <div class="d-flex align-items-center gap-2">
                                    <div class="progress flex-grow-1" style="height:6px;"><div class="progress-bar {{ $b['pct'] >= 100 ? 'bg-success' : ($b['pct'] >= 50 ? 'bg-info' : 'bg-warning') }}" style="width:{{ min($b['pct'],100) }}%"></div></div>
                                    <span class="small">{{ number_format($b['pct'],1) }}%</span>
                                </div>
                            </td>
                            <td class="text-end">₹{{ number_format($b['value'],2) }}</td>
                        </tr>
                    @empty
                        <tr><td colspan="7" class="text-center text-muted py-4">No data.</td></tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
</div>
@endsection
