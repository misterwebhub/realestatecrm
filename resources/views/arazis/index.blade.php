@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">
    <div class="card-header d-flex align-items-center justify-content-between flex-wrap gap-2">
        <div class="d-flex align-items-center gap-3 flex-grow-1">
            <h5 class="card-title mb-0">{{ $title }}</h5>
            <form method="get" class="d-flex ms-3" action="{{ route('arazis.index') }}">
                <input name="q" value="{{ request()->query('q') }}" placeholder="Search Arazi code, plot no, location or kisan" class="form-control form-control-sm" style="min-width:320px;" />
                <button class="btn btn-sm btn-outline-secondary ms-2" type="submit">Search</button>
                @if(request()->query('q'))
                    <a href="{{ route('arazis.index') }}" class="btn btn-sm btn-outline-secondary ms-2">Clear</a>
                @endif
            </form>
        </div>
        @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
            <a href="{{ $createUrl }}" class="btn btn-primary btn-sm">
                <i class="bi bi-plus-lg"></i> Add New Arazi
            </a>
        @endif
    </div>

    <div class="card-body table-responsive p-0">
        <div class="p-3 border-bottom bg-light d-flex gap-3 align-items-center">
            <div><strong>Total groups:</strong> {{ count($groups) }}</div>
            <div><strong>Total plots:</strong> {{ $totalPlots ?? 0 }}</div>
            <div><strong>Total saleable area (Gaz):</strong> {{ isset($totalSaleArea) ? number_format($totalSaleArea, 2) : '0.00' }}</div>
        </div>
        <table class="table table-striped table-hover mb-0 align-middle">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Arazi Code</th>
                    <th>Total Size (Gaz)</th>
                    <th>Total Road Area (Gaz)</th>
                    <th>Total Plots</th>
                    <th>Total Saleable (Gaz)</th>
                    <th>Entries</th>
                    <th>Status</th>
                    <th class="text-end">Actions</th>
                </tr>
            </thead>
            <tbody>
            @forelse($groups as $i => $group)
                <tr>
                    <td>{{ $i + 1 }}</td>
                    <td><strong>{{ $group['arazi_code'] }}</strong></td>
                    <td>{{ number_format($group['total_size'], 2) }}</td>
                    <td>{{ number_format($group['total_road'], 2) }}</td>
                    <td>{{ $group['total_plots'] ?? 0 }}</td>
                    <td>{{ isset($group['total_saleable_gaz']) ? number_format($group['total_saleable_gaz'], 2) : '0.00' }}</td>
                    <td>{{ $group['count'] }}</td>
                    <td>
                        <span class="badge bg-{{ $group['status_class'] }}">{{ $group['status_label'] }}</span>
                    </td>
                    <td class="text-end">
                        <button type="button"
                                class="btn btn-outline-info btn-sm"
                                data-bs-toggle="modal"
                                data-bs-target="#modal-{{ $i }}">
                            <i class="bi bi-eye"></i> View Arazi Details
                        </button>
                        @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                            <a href="{{ $createUrl }}?legacy_arazi_code={{ urlencode($group['arazi_code']) }}"
                               class="btn btn-outline-success btn-sm ms-1">
                                <i class="bi bi-plus-lg"></i> Add Entry
                            </a>
                        @endif
                    </td>
                </tr>
            @empty
                <tr>
                    <td colspan="7" class="text-center py-4">No arazi records found.</td>
                </tr>
            @endforelse
            </tbody>
        </table>
    </div>
</div>

{{-- Modals for each arazi group --}}
@foreach($groups as $i => $group)
<div class="modal fade" id="modal-{{ $i }}" tabindex="-1" aria-labelledby="modal-label-{{ $i }}" aria-hidden="true">
    <div class="modal-dialog modal-xl modal-dialog-scrollable">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="modal-label-{{ $i }}">
                    Arazi Details &mdash; <strong>{{ $group['arazi_code'] }}</strong>
                </h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body p-0">
                <table class="table table-bordered table-hover mb-0 align-middle">
                    <thead class="table-light">
                        <tr>
                            <th>#</th>
                            <th>Kisan</th>
                            <th>Location</th>
                            <th>Size</th>
                            <th>Unit</th>
                            <th>Road Area</th>
                            <th>Status</th>
                            @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                                <th class="text-end">Actions</th>
                            @endif
                        </tr>
                    </thead>
                    <tbody>
                    @foreach($group['details'] as $j => $detail)
                        <tr>
                            <td>{{ $j + 1 }}</td>
                            <td>{{ $detail['kisan'] }}</td>
                            <td>{{ $detail['location'] }}</td>
                            <td>{{ $detail['size'] }}</td>
                            <td>{{ $detail['unit'] }}</td>
                            <td>{{ $detail['road_area'] }}</td>
                            <td>
                                <span class="badge bg-{{ $detail['status_class'] }}">
                                    {{ $detail['status_label'] }}
                                </span>
                            </td>
                            @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                            <td class="text-end text-nowrap">
                                <a href="{{ $detail['grid_url'] }}" class="btn btn-outline-primary btn-sm">
                                    <i class="bi bi-grid-3x3-gap"></i> Plots
                                </a>
                                <a href="{{ $detail['edit_url'] }}" class="btn btn-outline-secondary btn-sm ms-1">
                                    <i class="bi bi-pencil"></i> Edit
                                </a>
                                <form action="{{ $detail['delete_url'] }}" method="POST" class="d-inline-block ms-1"
                                      onsubmit="return confirm('Delete this arazi entry?');">
                                    @csrf
                                    @method('DELETE')
                                    <button type="submit" class="btn btn-outline-danger btn-sm">
                                        <i class="bi bi-trash"></i>
                                    </button>
                                </form>
                            </td>
                            @endif
                        </tr>
                    @endforeach
                    </tbody>
                    <tfoot class="table-light fw-bold">
                        <tr>
                            <td colspan="3" class="text-end">Total:</td>
                            <td>{{ number_format($group['total_size'], 2) }}</td>
                            <td></td>
                            <td>{{ number_format($group['total_road'], 2) }}</td>
                            <td></td>
                            @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                                <td></td>
                            @endif
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>
@endforeach
@endsection
