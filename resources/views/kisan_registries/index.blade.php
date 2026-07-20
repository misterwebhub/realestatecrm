@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">
    <div class="card-header d-flex align-items-center flex-wrap gap-2">
        <h5 class="card-title mb-0 fw-bold">{{ $title }}</h5>
        @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
            <a href="{{ $createUrl }}" class="btn btn-primary btn-sm ms-auto">
                <i class="bi bi-plus-lg"></i> Add New Registry
            </a>
        @endif
    </div>

    <div class="card-body table-responsive p-0">
        @if(!empty($arazis))
            <div class="card-body border-top">
                <form method="GET" class="row g-2 align-items-end">
                    <div class="col-2">
                        <label class="form-label small">Arazi</label>
                        <select id="filter-arazi" name="arazi_code" class="form-select form-select-sm" data-placeholder="All Arazis">
                            <option value="">All</option>
                            @foreach($arazis as $value => $label)
                                <option value="{{ $value }}" @selected((string)($filter_arazi_code ?? '') === (string)$value)>{{ $label }}</option>
                            @endforeach
                        </select>
                    </div>
                    <div class="col-2">
                        <label class="form-label small">Deed No</label>
                        <select id="filter-deed" name="deed" class="form-select form-select-sm" data-placeholder="All Deeds">
                            <option value="">All</option>
                            @foreach($deeds ?? [] as $deedNo)
                                <option value="{{ $deedNo }}" @selected((string)($filter_deed ?? '') === (string)$deedNo)>{{ $deedNo }}</option>
                            @endforeach
                        </select>
                    </div>
                    <div class="col-auto">
                        <button class="btn btn-sm btn-primary">Filter</button>
                        <a href="{{ route('kisan-registries.index') }}" class="btn btn-sm btn-outline-secondary ms-1">Clear</a>
                    </div>
                </form>
            </div>
        @endif
        <table class="table table-striped table-hover mb-0 align-middle">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Arazi Deed No.</th>
                    <th>Arazi</th>
                    <th>Name Deed No.</th>
                    <th>Sale By</th>
                    <th>Buy By</th>
                    <th>Total Gaz</th>
                    <th>Road Land (Gaj)</th>
                    <th>Date</th>
                    <th>Broker Name</th>
                    <th>Total Expense</th>
                    <th>File</th>
                    @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                        <th class="text-end">Actions</th>
                    @endif
                </tr>
            </thead>
            <tbody>
            @forelse($records as $i => $rec)
                <tr>
                    <td>{{ $i + 1 }}</td>
                    <td>{{ $rec->arazi_deed_no ?? '-' }}</td>
                    <td>
                        @php
                            $araziLabel = $rec->arazi
                                ? ($rec->arazi->araziNoCode() ?: ($rec->arazi->legacy_arazi_code ?: ('Arazi-' . $rec->arazi->id)))
                                : ($arazi_map[$rec->arazi_code] ?? ($rec->arazi_code ?? '-'));
                        @endphp
                        {{ $araziLabel }}
                    </td>
                    <td>{{ $rec->name_deed_no ?? '-' }}</td>
                    <td>{{ $rec->sale_by ?? '-' }}</td>
                    <td>{{ $rec->buy_by ?? '-' }}</td>
                    <td>{{ $rec->total_gaz !== null ? number_format($rec->total_gaz, 2) : '-' }}</td>
                    <td>{{ $rec->road_land_gaj !== null ? number_format($rec->road_land_gaj, 2) : '-' }}</td>
                    <td>{{ $rec->registry_date ? $rec->registry_date->format('d-m-Y') : '-' }}</td>
                    <td>{{ $rec->broker_name ?? '-' }}</td>
                    <td>
                        @php
                            $total = (float)$rec->stamp + (float)$rec->registrar_fees + (float)$rec->khasra + (float)$rec->commission + (float)$rec->brokari;
                        @endphp
                        {{ number_format($total, 2) }}
                        <small class="text-muted d-block" style="font-size:0.75em;">
                            Stamp: {{ number_format($rec->stamp,2) }} |
                            Reg: {{ number_format($rec->registrar_fees,2) }} |
                            Khasra: {{ number_format($rec->khasra,2) }} |
                            Comm: {{ number_format($rec->commission,2) }} |
                            Brokari: {{ number_format($rec->brokari,2) }}
                        </small>
                    </td>
                    <td>
                        @if($rec->registry_file_path)
                            <a href="{{ route('kisan-registries.download', $rec) }}" class="btn btn-outline-secondary btn-sm">
                                <i class="bi bi-download"></i> Download
                            </a>
                        @else
                            <span class="text-muted">-</span>
                        @endif
                    </td>
                    @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                    <td class="text-end text-nowrap">
                        <a href="{{ route('kisan-registries.edit', $rec) }}" class="btn btn-outline-secondary btn-sm">
                            <i class="bi bi-pencil"></i> Edit
                        </a>
                        <form action="{{ route('kisan-registries.destroy', $rec) }}" method="POST"
                              class="d-inline-block ms-1"
                              onsubmit="return confirm('Delete this registry record?');">
                            @csrf
                            @method('DELETE')
                            <button type="submit" class="btn btn-outline-danger btn-sm">
                                <i class="bi bi-trash"></i>
                            </button>
                        </form>
                    </td>
                    @endif
                </tr>
            @empty
                <tr>
                    <td colspan="12" class="text-center py-4">No registry records found.</td>
                </tr>
            @endforelse
            </tbody>
        </table>
    </div>
</div>
@endsection

@push('scripts')
<script>
    jQuery(function(){
        jQuery('#filter-arazi').select2({
            theme: 'bootstrap-5',
            width: '250px',
            placeholder: 'All Arazis',
            allowClear: true,
            dropdownParent: jQuery(document.body)
        });
        jQuery('#filter-deed').select2({
            theme: 'bootstrap-5',
            width: '250px',
            placeholder: 'All Deeds',
            allowClear: true,
            dropdownParent: jQuery(document.body)
        });
        // Re-scope the deed list to the chosen arazi by reloading with the arazi filter
        jQuery('#filter-arazi').on('change', function(){
            jQuery('#filter-deed').val('').trigger('change.select2');
            jQuery(this).closest('form').submit();
        });
    });
</script>
@endpush
