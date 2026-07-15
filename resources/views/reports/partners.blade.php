@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3">
        <h5 class="mb-0">{{ $title }}</h5>
        <div class="ms-auto d-flex gap-2">
            <a href="{{ route('reports.index') }}" class="btn btn-outline-secondary btn-sm">Back</a>
            <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i></button>
        </div>
    </div>

    <form method="GET" class="row g-2 align-items-end mb-3">
        <div class="col-6 col-md-2">
            <label class="form-label small text-muted mb-1">Partner</label>
            <select name="partner_id" class="form-select form-select-sm js-select2">
                <option value="">All</option>
                @foreach($partners as $p)
                    <option value="{{ $p->id }}" @selected((string)$partnerId === (string)$p->id)>{{ $p->name }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-6 col-md-2">
            <label class="form-label small text-muted mb-1">Arazi</label>
            <select name="arazi_code" class="form-select form-select-sm js-select2">
                <option value="">All</option>
                @foreach($araziOptions as $c)
                    <option value="{{ $c }}" @selected($araziCode === $c)>{{ $c }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-6 col-md-2">
            <label class="form-label small text-muted mb-1">Activity</label>
            <select name="activity" class="form-select form-select-sm js-select2">
                <option value="">All</option>
                <option value="complete" @selected($activity==='complete')>Complete</option>
                <option value="pending" @selected($activity==='pending')>Pending</option>
            </select>
        </div>
        <div class="col-6 col-md-2">
            <label class="form-label small text-muted mb-1">From</label>
            <input type="date" name="date_from" value="{{ $dateFrom }}" class="form-control form-control-sm">
        </div>
        <div class="col-6 col-md-2">
            <label class="form-label small text-muted mb-1">To</label>
            <input type="date" name="date_to" value="{{ $dateTo }}" class="form-control form-control-sm">
        </div>
        <div class="col-6 col-md-2 d-flex gap-2">
            <button class="btn btn-primary btn-sm flex-fill">Apply</button>
            <a href="{{ route('reports.partners') }}" class="btn btn-light btn-sm">Clear</a>
        </div>
    </form>

    <div class="d-flex flex-wrap gap-4 mb-3 small">
        <div>Assigned: <span class="fw-bold">{{ number_format($grand_assigned,2) }}</span> gaz</div>
        <div class="text-success">Sold: <span class="fw-bold">{{ number_format($grand_sold,2) }}</span> gaz</div>
        <div class="text-danger">Remaining: <span class="fw-bold">{{ number_format($grand_remaining,2) }}</span> gaz</div>
    </div>

    <div class="card">
        <div class="table-responsive">
            <table class="table table-sm table-hover align-middle mb-0">
                <thead class="table-light">
                    <tr>
                        <th>Partner</th>
                        <th>Arazi</th>
                        <th class="text-end">Assigned</th>
                        <th class="text-end">Sold</th>
                        <th class="text-end">Remaining</th>
                        <th class="text-center">Reg.</th>
                        <th class="text-center">Done</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($rows as $r)
                        @foreach($r['arazis'] as $i => $a)
                            <tr>
                                @if($i === 0)
                                    <td rowspan="{{ count($r['arazis']) }}" class="fw-semibold border-end">
                                        {{ $r['partner'] }}
                                        <div class="text-muted small fw-normal">{{ $r['mobile'] }}</div>
                                    </td>
                                @endif
                                <td>{{ $a['arazi'] }}</td>
                                <td class="text-end">{{ number_format($a['assigned'],2) }}</td>
                                <td class="text-end text-success">{{ number_format($a['sold'],2) }}</td>
                                <td class="text-end {{ $a['remaining'] < 0 ? 'text-danger' : '' }}">{{ number_format($a['remaining'],2) }}</td>
                                <td class="text-center">{{ $a['reg_count'] }}</td>
                                <td class="text-center">
                                    @if($a['reg_done'] > 0)
                                        <span class="badge bg-success">{{ $a['reg_done'] }}</span>
                                    @elseif($a['reg_count'] > 0)
                                        <span class="badge bg-warning text-dark">Pending</span>
                                    @else
                                        <span class="text-muted">—</span>
                                    @endif
                                </td>
                            </tr>
                        @endforeach
                        <tr class="table-light">
                            <td class="text-end fw-semibold" colspan="2">{{ $r['partner'] }} — Total</td>
                            <td class="text-end fw-semibold">{{ number_format($r['total_assigned'],2) }}</td>
                            <td class="text-end fw-semibold text-success">{{ number_format($r['total_sold'],2) }}</td>
                            <td class="text-end fw-semibold text-danger">{{ number_format($r['total_remaining'],2) }}</td>
                            <td colspan="2"></td>
                        </tr>
                    @empty
                        <tr><td colspan="7" class="text-center text-muted py-4">No partner land activity found.</td></tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
</div>
@endsection
