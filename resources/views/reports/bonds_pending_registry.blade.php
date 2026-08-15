@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 flex-wrap gap-2">
        <h5 class="mb-0">Bonds Pending Registry</h5>
        <div class="ms-auto d-flex gap-2 no-print">
            <a href="{{ route('reports.index') }}" class="btn btn-outline-secondary btn-sm">Back</a>
            <a href="{{ route('reports.bonds-pending-registry', array_merge(request()->query(), ['export' => 'csv'])) }}" class="btn btn-outline-success btn-sm"><i class="bi bi-filetype-csv"></i> Export CSV</a>
            <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i></button>
        </div>
    </div>

    <p class="text-muted small">
        Bonds that have at least one plot with no <strong>completed</strong> registry yet,
        along with how much payment is still pending on that bond.
    </p>

    {{-- Filters --}}
    <form method="GET" class="row g-2 align-items-end mb-3 no-print">
        <div class="col-md-3 col-sm-6">
            <label class="form-label small fw-semibold mb-1">Bond No.</label>
            <input type="text" name="q" value="{{ $q }}" class="form-control form-control-sm" placeholder="Search bond no.">
        </div>
        <div class="col-md-3 col-sm-6">
            <label class="form-label small fw-semibold mb-1">Arazi</label>
            <input type="text" name="arazi_code" value="{{ $araziCode }}" class="form-control form-control-sm" placeholder="Arazi code">
        </div>
        <div class="col-auto d-flex gap-2">
            <button class="btn btn-primary btn-sm">Apply</button>
            <a href="{{ route('reports.bonds-pending-registry') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
        </div>
    </form>

    {{-- Summary --}}
    <div class="row g-2 mb-3">
        <div class="col-6 col-md-3">
            <div class="card shadow-sm border-start border-4 border-secondary h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Bonds Pending Registry</div>
                    <div class="fs-6 fw-bold">{{ number_format(count($rows)) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md-3">
            <div class="card shadow-sm border-start border-4 border-primary h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Total Bond Amount</div>
                    <div class="fs-6 fw-bold">{{ number_format($g_total, 2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md-3">
            <div class="card shadow-sm border-start border-4 border-success h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Total Paid</div>
                    <div class="fs-6 fw-bold">{{ number_format($g_paid, 2) }}</div>
                </div>
            </div>
        </div>
        <div class="col-6 col-md-3">
            <div class="card shadow-sm border-start border-4 border-danger h-100">
                <div class="card-body py-2">
                    <div class="small text-muted text-uppercase">Total Pending Payment</div>
                    <div class="fs-6 fw-bold text-danger">{{ number_format($g_balance, 2) }}</div>
                </div>
            </div>
        </div>
    </div>

    <div class="table-responsive">
        <table class="table table-sm table-bordered table-striped align-middle">
            <thead class="table-light">
                <tr>
                    <th>#</th>
                    <th>Bond Date</th>
                    <th>Bond No.</th>
                    <th>Customer</th>
                    <th>Arazi</th>
                    <th>Plots Pending Registry</th>
                    <th>Broker</th>
                    <th class="text-end">Bond Amount</th>
                    <th class="text-end">Total Paid</th>
                    <th class="text-end">Pending Payment</th>
                </tr>
            </thead>
            <tbody>
                @forelse($rows as $i => $r)
                    <tr>
                        <td>{{ $i + 1 }}</td>
                        <td>{{ $r['bond_date'] ?: '-' }}</td>
                        <td class="fw-semibold">{{ $r['bond_no'] }}</td>
                        <td>{{ $r['customer'] }}</td>
                        <td>{{ $r['arazi'] }}</td>
                        <td>
                            @if(count($r['pending_plots']))
                                @foreach($r['pending_plots'] as $p)
                                    <span class="badge bg-danger-subtle text-danger border border-danger-subtle">{{ $p }}</span>
                                @endforeach
                            @else
                                <span class="badge bg-danger-subtle text-danger border border-danger-subtle">No plot registered</span>
                            @endif
                        </td>
                        <td>{{ $r['broker'] }}</td>
                        <td class="text-end">{{ number_format($r['total'], 2) }}</td>
                        <td class="text-end text-success">{{ number_format($r['paid'], 2) }}</td>
                        <td class="text-end fw-bold {{ $r['balance'] > 0 ? 'text-danger' : '' }}">{{ number_format($r['balance'], 2) }}</td>
                    </tr>
                @empty
                    <tr><td colspan="10" class="text-center text-muted py-4">No bonds with pending registry found.</td></tr>
                @endforelse
            </tbody>
            @if(count($rows))
            <tfoot class="table-light">
                <tr class="fw-bold">
                    <td colspan="7" class="text-end">GRAND TOTAL</td>
                    <td class="text-end">{{ number_format($g_total, 2) }}</td>
                    <td class="text-end text-success">{{ number_format($g_paid, 2) }}</td>
                    <td class="text-end text-danger">{{ number_format($g_balance, 2) }}</td>
                </tr>
            </tfoot>
            @endif
        </table>
    </div>
</div>
@endsection
