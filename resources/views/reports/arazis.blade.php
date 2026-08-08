@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 gap-2">
        <h4 class="mb-0"><i class="bi bi-map me-2"></i>{{ $title }}</h4>
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
                            <option value="{{ $c }}" @selected((string)$araziCode === (string)$c)>{{ $c }}</option>
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
                <div class="col-md-3">
                    <label class="form-label small fw-semibold mb-1">Sale State</label>
                    <select name="sale_state" class="form-select form-select-sm js-select2">
                        <option value="">All</option>
                        <option value="sold" @selected($saleState==='sold')>Fully Sold</option>
                        <option value="partial" @selected($saleState==='partial')>Partially Sold</option>
                        <option value="unsold" @selected($saleState==='unsold')>Unsold</option>
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
                    <a href="{{ route('reports.arazis') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                </div>
            </form>
        </div>
    </div>

    <div class="row g-2 mb-3">
        <div class="col-md-3"><div class="card shadow-sm border-start border-4 border-info"><div class="card-body py-2"><div class="small text-muted text-uppercase">Saleable</div><div class="fs-6 fw-bold">{{ number_format($total_saleable,2) }} gaz</div></div></div></div>
        <div class="col-md-3"><div class="card shadow-sm border-start border-4 border-success"><div class="card-body py-2"><div class="small text-muted text-uppercase">Sold</div><div class="fs-6 fw-bold text-success">{{ number_format($total_sold,2) }} gaz</div></div></div></div>
        <div class="col-md-3"><div class="card shadow-sm border-start border-4 border-danger"><div class="card-body py-2"><div class="small text-muted text-uppercase">Remaining</div><div class="fs-6 fw-bold text-danger">{{ number_format($total_remaining,2) }} gaz</div></div></div></div>
        <div class="col-md-3"><div class="card shadow-sm border-start border-4 border-secondary"><div class="card-body py-2"><div class="small text-muted text-uppercase">Sold Value</div><div class="fs-6 fw-bold">₹{{ inr($total_value,2) }}</div></div></div></div>
    </div>

    <div class="card shadow-sm">
        <div class="table-responsive">
            <table class="table table-sm table-hover align-middle mb-0">
                <thead class="table-light">
                    <tr>
                        <th>Arazi</th>
                        <th>Location</th>
                        <th class="text-end">Total (gaz)</th>
                        <th class="text-end">Road (gaz)</th>
                        <th class="text-end">Saleable (gaz)</th>
                        <th class="text-end">Sold (gaz)</th>
                        <th class="text-end">Remaining (gaz)</th>
                        <th style="min-width:110px;">Sold %</th>
                        <th class="text-center">Plots</th>
                        <th class="text-center">Registries</th>
                        <th class="text-center">Done</th>
                        <th class="text-center">Bonds</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($rows as $r)
                        <tr>
                            <td><span class="badge bg-primary-subtle text-primary-emphasis">{{ $r['arazi'] }}</span></td>
                            <td class="small text-muted">{{ $r['location'] }}</td>
                            <td class="text-end">{{ number_format($r['size'],2) }}</td>
                            <td class="text-end">{{ number_format($r['road'],2) }}</td>
                            <td class="text-end">{{ number_format($r['saleable'],2) }}</td>
                            <td class="text-end text-success">{{ number_format($r['sold'],2) }}</td>
                            <td class="text-end fw-semibold {{ $r['remaining'] <= 0 ? 'text-danger' : '' }}">{{ number_format($r['remaining'],2) }}</td>
                            <td>
                                <div class="d-flex align-items-center gap-2">
                                    <div class="progress flex-grow-1" style="height:6px;"><div class="progress-bar {{ $r['sold_pct'] >= 100 ? 'bg-success' : ($r['sold_pct'] >= 50 ? 'bg-info' : 'bg-warning') }}" style="width:{{ min($r['sold_pct'],100) }}%"></div></div>
                                    <span class="small">{{ number_format($r['sold_pct'],1) }}%</span>
                                </div>
                            </td>
                            <td class="text-center">{{ $r['plots'] }}</td>
                            <td class="text-center">{{ $r['reg_total'] }}</td>
                            <td class="text-center">
                                @if($r['reg_done'] > 0)<span class="badge bg-success">{{ $r['reg_done'] }}</span>@else<span class="text-muted">0</span>@endif
                            </td>
                            <td class="text-center">{{ $r['bonds'] }}</td>
                        </tr>
                    @empty
                        <tr><td colspan="12" class="text-center text-muted py-4">No arazis found.</td></tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
</div>
@endsection
