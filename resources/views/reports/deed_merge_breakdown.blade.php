@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 gap-2">
        <h4 class="mb-0"><i class="bi bi-diagram-3 me-2"></i>{{ $title }}</h4>
        <div class="ms-auto d-flex gap-2">
            <a href="{{ route('reports.index') }}" class="btn btn-outline-secondary btn-sm">Back to Reports</a>
            @if($selected)
                <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i> Print</button>
            @endif
        </div>
    </div>

    <div class="card shadow-sm mb-3">
        <div class="card-body">
            <form method="GET" class="row g-2 align-items-end">
                <div class="col-md-4">
                    <label class="form-label small fw-semibold mb-1">Merged Deed No</label>
                    <select name="deed_merging_id" class="form-select form-select-sm js-select2" data-placeholder="Select a Merged Deed No">
                        <option value=""></option>
                        @foreach($merges as $m)
                            <option value="{{ $m->id }}" @selected((string)$mergingId === (string)$m->id)>
                                {{ $m->merged_deed_no }} (Arazi {{ $m->arazi_code }})
                            </option>
                        @endforeach
                    </select>
                </div>
                <div class="col-auto d-flex gap-2">
                    <button class="btn btn-primary btn-sm">View</button>
                    <a href="{{ route('reports.deed-merge-breakdown') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                </div>
            </form>
        </div>
    </div>

    @if($mergingId !== '' && !$selected)
        <div class="alert alert-warning">That Merged Deed No wasn't found.</div>
    @elseif(!$selected)
        <div class="alert alert-secondary mb-0">Pick a Merged Deed No above to see which arazi records were consolidated into it and how much saleable area each contributed.</div>
    @else
        <div class="row g-2 mb-3">
            <div class="col-md-3">
                <div class="card shadow-sm border-start border-4 border-primary">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Merged Deed No</div>
                        <div class="fs-6 fw-bold">{{ $selected->merged_deed_no }}</div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow-sm border-start border-4 border-info">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Arazi Code</div>
                        <div class="fs-6 fw-bold">{{ $selected->arazi_code }}</div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow-sm border-start border-4 border-secondary">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Partner</div>
                        <div class="fs-6 fw-bold">{{ $selected->partner->name ?? '-' }}</div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card shadow-sm border-start border-4 border-success">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Total Saleable Area</div>
                        <div class="fs-6 fw-bold text-success">{{ number_format($totalSaleable, 2) }}</div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row g-2 mb-3">
            <div class="col-md-4">
                <div class="card shadow-sm border-start border-4 border-danger">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Total Sold</div>
                        <div class="fs-6 fw-bold text-danger">{{ number_format($totalSold, 2) }}</div>
                        @if($mergedSold > 0)
                            <div class="small text-muted">incl. {{ number_format($mergedSold, 2) }} sold directly under the merged deed no</div>
                        @endif
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card shadow-sm border-start border-4 border-warning">
                    <div class="card-body py-2">
                        <div class="small text-muted text-uppercase">Remaining (Unsold)</div>
                        <div class="fs-6 fw-bold text-warning-emphasis">{{ number_format($totalRemaining, 2) }}</div>
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow-sm">
            <div class="table-responsive">
                <table class="table table-sm table-hover align-middle mb-0">
                    <thead class="table-light">
                        <tr>
                            <th>#</th>
                            <th>Deed No</th>
                            <th>Arazi Record</th>
                            <th>Kisan</th>
                            <th class="text-end">Saleable Area</th>
                            <th class="text-end">Sold Area</th>
                            <th class="text-end">Remaining</th>
                        </tr>
                    </thead>
                    <tbody>
                        @forelse($rows as $i => $r)
                            <tr>
                                <td>{{ $i + 1 }}</td>
                                <td>{{ $r['deed_no'] }}</td>
                                <td>{{ $r['arazi_code'] }}</td>
                                <td>{{ $r['kisan'] }}</td>
                                <td class="text-end">{{ number_format($r['saleable_area'], 2) }}</td>
                                <td class="text-end">{{ number_format($r['sold_area'], 2) }}</td>
                                <td class="text-end">{{ number_format($r['remaining'], 2) }}</td>
                            </tr>
                        @empty
                            <tr><td colspan="7" class="text-center text-muted py-3">No member rows found for this merge.</td></tr>
                        @endforelse
                        @if($mergedSold > 0)
                            <tr class="table-light">
                                <td colspan="4" class="text-end fst-italic text-muted">Sold directly under merged deed no {{ $selected->merged_deed_no }}</td>
                                <td></td>
                                <td class="text-end fst-italic">{{ number_format($mergedSold, 2) }}</td>
                                <td></td>
                            </tr>
                        @endif
                    </tbody>
                    @if(count($rows))
                        <tfoot>
                            <tr class="fw-bold table-light">
                                <td colspan="4" class="text-end">Total</td>
                                <td class="text-end">{{ number_format($totalSaleable, 2) }}</td>
                                <td class="text-end">{{ number_format($totalSold, 2) }}</td>
                                <td class="text-end">{{ number_format($totalRemaining, 2) }}</td>
                            </tr>
                        </tfoot>
                    @endif
                </table>
            </div>
        </div>
    @endif
</div>
@endsection
