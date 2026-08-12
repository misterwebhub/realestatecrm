@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3">
        <h4 class="mb-0">{{ $title }}</h4>
        <a href="{{ route('deed-mappings.map') }}" class="btn btn-primary btn-sm ms-auto">
            <i class="bi bi-plus-lg"></i> Map Arazi
        </a>
    </div>

    @if(session('success'))
        <div class="alert alert-success">{{ session('success') }}</div>
    @endif

    <div class="card shadow-sm mb-3">
        <div class="card-body py-3">
            <form method="GET" action="{{ route('deed-mappings.index') }}" class="row g-2 align-items-end">
                <div class="col-md-3">
                    <label class="form-label mb-1" style="font-size:12px;">Arazi</label>
                    <select name="arazi_code" class="form-select form-select-sm js-select2" data-placeholder="-- All Arazis --">
                        <option value="">-- All Arazis --</option>
                        @foreach($araziCodes as $code)
                            <option value="{{ $code }}" @selected((string) $filters['arazi_code'] === (string) $code)>{{ $code }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-3">
                    <label class="form-label mb-1" style="font-size:12px;">Kisan</label>
                    <select name="kisan_id" class="form-select form-select-sm js-select2" data-placeholder="-- All Kisans --">
                        <option value="">-- All Kisans --</option>
                        @foreach($kisans as $kisan)
                            <option value="{{ $kisan->id }}" @selected((string) $filters['kisan_id'] === (string) $kisan->id)>{{ $kisan->name }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-3">
                    <label class="form-label mb-1" style="font-size:12px;">Deed No</label>
                    <select name="deed_no" class="form-select form-select-sm js-select2" data-placeholder="-- All Deed Nos --">
                        <option value="">-- All Deed Nos --</option>
                        @foreach($deedNos as $deedNo)
                            <option value="{{ $deedNo }}" @selected((string) $filters['deed_no'] === (string) $deedNo)>{{ $deedNo }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-3">
                    <label class="form-label mb-1" style="font-size:12px;">Partner</label>
                    <select name="partner_id" class="form-select form-select-sm js-select2" data-placeholder="-- All Partners --">
                        <option value="">-- All Partners --</option>
                        @foreach($partners as $partner)
                            <option value="{{ $partner->id }}" @selected((string) $filters['partner_id'] === (string) $partner->id)>{{ $partner->name }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-3 d-flex gap-2">
                    <button type="submit" class="btn btn-primary btn-sm">
                        <i class="bi bi-search"></i> Search
                    </button>
                    @if($hasFilter)
                        <a href="{{ route('deed-mappings.index') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                    @endif
                </div>
            </form>
        </div>
    </div>

    @if($hasFilter && $summary->isEmpty())
        <div class="card shadow-sm">
            <div class="card-body text-center text-muted py-5">
                No deed mappings match your search.
            </div>
        </div>
    @endif

    @forelse($summary as $group)
        <div class="card shadow-sm mb-3 deed-arazi-card">
            <div class="card-header d-flex align-items-center gap-2">
                <span class="badge bg-primary text-white fs-6 fw-semibold px-3 py-2">Arazi {{ $group['code'] }}</span>
                <span class="badge {{ $group['mapped'] > 0 ? 'bg-success-subtle text-success border border-success-subtle' : 'bg-secondary-subtle text-secondary border border-secondary-subtle' }}">
                    {{ $group['mapped'] }} / {{ $group['total'] }} kisan row(s) mapped
                </span>
                <a href="{{ route('deed-mappings.map', $group['code']) }}" class="btn btn-outline-primary btn-sm ms-auto">
                    <i class="bi bi-pencil"></i> {{ $group['mapped'] > 0 ? 'Edit' : 'Map' }}
                </a>
            </div>
            @if($group['rows']->isNotEmpty())
                <div class="table-responsive">
                    <table class="table table-sm mb-0 align-middle deed-rows-table">
                        <thead class="table-light">
                            <tr>
                                <th class="ps-3 text-center" style="width:50px;">#</th>
                                <th style="width:22%;">Kisan</th>
                                <th class="text-center" style="width:18%;">Deed No</th>
                                <th style="width:22%;">Partner</th>
                                <th class="text-center" style="width:120px;">Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            @foreach($group['rows'] as $i => $entry)
                                @php $row = $entry['arazi']; @endphp
                                <tr class="{{ $entry['is_group_start'] ? 'kisan-group-start' : 'kisan-group-cont' }}">
                                    <td class="ps-3 text-center text-muted">{{ $i + 1 }}</td>
                                    @if($entry['is_group_start'])
                                        <td rowspan="{{ $entry['span'] }}" class="fw-semibold align-middle kisan-cell">
                                            {{ optional($row->kisan)->name ?? '—' }}
                                        </td>
                                    @endif
                                    <td class="text-center">
                                        @if($row->deedMapping)
                                            <span class="badge bg-primary-subtle text-primary-emphasis">{{ $row->deedMapping->deed_no }}</span>
                                        @else
                                            <span class="text-muted">—</span>
                                        @endif
                                    </td>
                                    <td>{{ optional($row->deedMapping?->partner)->name ?? '—' }}</td>
                                    <td class="text-center">
                                        @if($row->deedMapping)
                                            <span class="badge bg-success-subtle text-success border border-success-subtle">Mapped</span>
                                        @else
                                            <span class="badge bg-secondary-subtle text-secondary border border-secondary-subtle">Unmapped</span>
                                        @endif
                                    </td>
                                </tr>
                            @endforeach
                        </tbody>
                    </table>
                </div>
            @else
                <div class="card-body py-3 text-muted">No kisan rows for this arazi.</div>
            @endif
        </div>
    @empty
        @unless($hasFilter)
            <div class="card shadow-sm">
                <div class="card-body text-center text-muted py-5">
                    No arazis found. Add an Arazi first, then come back to map its deed numbers.
                </div>
            </div>
        @endunless
    @endforelse
</div>
@endsection

@push('styles')
<style>
    .deed-arazi-card .card-header { background: #f8fafc; }
    .deed-rows-table thead th {
        font-size: 11px;
        text-transform: uppercase;
        letter-spacing: .3px;
        color: #6b7280;
        border-bottom-width: 2px;
    }
    /* Kisan cell (rowspan) gets a soft left accent so every deed line under
       the same kisan reads as one indented group, not a repeated block. */
    .deed-rows-table .kisan-cell {
        border-left: 3px solid #cfe0fb;
        background: #fbfdff;
    }
    /* Continuation rows (2nd+ deed no for the same kisan) get a lighter,
       slightly indented look so they visually nest under the kisan above. */
    .deed-rows-table .kisan-group-cont td:not(.kisan-cell) {
        background: #fcfdff;
    }
    .deed-rows-table .kisan-group-start:not(:first-child) td {
        border-top: 1px solid #e5e9f0;
    }
    .deed-rows-table td, .deed-rows-table th { vertical-align: middle; }
</style>
@endpush
