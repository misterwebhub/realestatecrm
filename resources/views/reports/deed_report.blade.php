@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 gap-2">
        <h4 class="mb-0"><i class="bi bi-file-earmark-ruled me-2"></i>{{ $title }}</h4>
        <div class="ms-auto d-flex gap-2">
            <a href="{{ route('reports.index') }}" class="btn btn-outline-secondary btn-sm">Back to Reports</a>
            @if($result)
                <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i> Print</button>
            @endif
        </div>
    </div>

    <div class="card shadow-sm mb-3">
        <div class="card-body">
            <form method="GET" class="row g-2 align-items-end">
                <div class="col-md-4">
                    <label class="form-label small fw-semibold mb-1">Deed No</label>
                    <input type="text" name="deed_no" value="{{ $deedNo }}" class="form-control form-control-sm"
                           placeholder="Enter any Deed No or Merged Deed No…" autofocus>
                    <div class="form-text">Works for a standalone deed, an original deed that was later merged, or a Merged Deed No itself.</div>
                </div>
                <div class="col-auto d-flex gap-2">
                    <button class="btn btn-primary btn-sm">View</button>
                    <a href="{{ route('reports.deed-report') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                </div>
            </form>
        </div>
    </div>

    @if($deedNo !== '' && !$result)
        <div class="alert alert-warning mb-0">No deed mapping, merge, or registry found for Deed No "<strong>{{ $deedNo }}</strong>".</div>
    @elseif(!$result)
        <div class="alert alert-secondary mb-0">Enter a Deed No above to see how much area was allotted, how much has been sold, and how much is left.</div>
    @else
        @if($result['type'] === 'fallback')
            <div class="alert alert-info">
                This Deed No has registries filed against it but no formal Deed Mapping record, so <strong>Allotted</strong> and <strong>Remaining</strong> area can't be computed — only the sold area (from registries) is shown below.
            </div>
        @elseif($result['type'] === 'member')
            <div class="alert alert-info">
                This Deed No was later consolidated into Merged Deed No <strong>{{ $result['merged_deed_no'] }}</strong>. Figures below reflect only what was sold under this original deed no directly — open the Merged Deed No's own report to see the full group picture.
            </div>
        @endif

        <div class="row g-2 mb-3">
            <div class="col-md-3">
                <div class="card shadow-sm border-start border-4 border-primary h-100">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Deed No</div>
                        <div class="fs-6 fw-bold">{{ $result['deed_no'] }}</div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow-sm border-start border-4 border-info h-100">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Merged Deed No</div>
                        <div class="fs-6 fw-bold">{{ $result['merged_deed_no'] }}</div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow-sm border-start border-4 border-secondary h-100">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Arazi Code</div>
                        <div class="fs-6 fw-bold">{{ $result['arazi_code'] }}</div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow-sm border-start border-4 border-dark h-100">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Kisan / Partner</div>
                        <div class="fs-6 fw-bold">{{ $result['kisan'] !== '-' ? $result['kisan'] : $result['partner'] }}</div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row g-2 mb-3">
            <div class="col-md-4">
                <div class="card shadow-sm border-start border-4 border-success h-100">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Allotted Area</div>
                        <div class="fs-6 fw-bold text-success">{{ $result['allotted'] === null ? 'Unknown' : number_format($result['allotted'], 2) }}</div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card shadow-sm border-start border-4 border-danger h-100">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Sold Area</div>
                        <div class="fs-6 fw-bold text-danger">{{ number_format($result['sold'], 2) }}</div>
                        @if(!empty($result['merged_sold']))
                            <div class="small text-muted">incl. {{ number_format($result['merged_sold'], 2) }} sold directly under the merged deed no</div>
                        @endif
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card shadow-sm border-start border-4 border-warning h-100">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Left / Remaining Area</div>
                        <div class="fs-6 fw-bold text-warning-emphasis">{{ $result['remaining'] === null ? 'Unknown' : number_format($result['remaining'], 2) }}</div>
                    </div>
                </div>
            </div>
        </div>

        @if($result['type'] === 'merged')
            <div class="card shadow-sm">
                <div class="card-header bg-light fw-semibold">Member Deeds consolidated into {{ $result['merged_deed_no'] }}</div>
                <div class="table-responsive">
                    <table class="table table-sm table-hover align-middle mb-0">
                        <thead class="table-light">
                            <tr>
                                <th>#</th>
                                <th>Deed No</th>
                                <th>Arazi Record</th>
                                <th>Kisan</th>
                                <th class="text-end">Allotted</th>
                                <th class="text-end">Sold</th>
                                <th class="text-end">Remaining</th>
                            </tr>
                        </thead>
                        <tbody>
                            @forelse($result['members'] as $i => $m)
                                <tr>
                                    <td>{{ $i + 1 }}</td>
                                    <td>{{ $m['deed_no'] }}</td>
                                    <td>{{ $m['arazi_code'] }}</td>
                                    <td>{{ $m['kisan'] }}</td>
                                    <td class="text-end">{{ number_format($m['allotted'], 2) }}</td>
                                    <td class="text-end">{{ number_format($m['sold'], 2) }}</td>
                                    <td class="text-end">{{ number_format($m['remaining'], 2) }}</td>
                                </tr>
                            @empty
                                <tr><td colspan="7" class="text-center text-muted py-3">No member rows found for this merge.</td></tr>
                            @endforelse
                            @if(!empty($result['merged_sold']))
                                <tr class="table-light">
                                    <td colspan="4" class="text-end fst-italic text-muted">Sold directly under merged deed no {{ $result['merged_deed_no'] }}</td>
                                    <td></td>
                                    <td class="text-end fst-italic">{{ number_format($result['merged_sold'], 2) }}</td>
                                    <td></td>
                                </tr>
                            @endif
                        </tbody>
                        <tfoot>
                            <tr class="fw-bold table-light">
                                <td colspan="4" class="text-end">Total</td>
                                <td class="text-end">{{ number_format($result['allotted'], 2) }}</td>
                                <td class="text-end">{{ number_format($result['sold'], 2) }}</td>
                                <td class="text-end">{{ number_format($result['remaining'], 2) }}</td>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        @endif
    @endif
</div>
@endsection
