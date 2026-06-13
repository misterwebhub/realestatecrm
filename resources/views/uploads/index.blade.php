@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary mb-3">
        <div class="card-header d-flex align-items-center justify-content-between">
            <h5 class="card-title mb-0 fw-bold">Uploads</h5>
            <a href="{{ route('uploads.create') }}" class="btn btn-primary btn-sm"><i class="bi bi-plus-lg"></i> New Upload</a>
        </div>
        <div class="card-body border-bottom">
            <form method="get" class="row g-2">
                <div class="col-md-3">
                    <label class="form-label small">Category</label>
                    <select name="category" class="form-select form-select-sm">
                        <option value="">All</option>
                        @foreach($categories as $cat)
                            <option value="{{ $cat->id }}" {{ request('category') == $cat->id ? 'selected' : '' }}>{{ $cat->name }}</option>
                        @endforeach
                    </select>
                </div>

                <div class="col-md-3">
                    <label class="form-label small">Arazi</label>
                    <select id="filter-arazi" name="arazi_id" class="form-select form-select-sm">
                        <option value="">Any</option>
                        @if(request('arazi_id') && $a = \App\Models\Arazi::find(request('arazi_id')))
                            <option value="{{ $a->id }}" selected>{{ $a->legacy_arazi_code ?? ('Arazi '.$a->id) }}</option>
                        @endif
                    </select>
                </div>

                <div class="col-md-2">
                    <label class="form-label small">Unassigned</label>
                    <select name="unassigned" class="form-select form-select-sm">
                        <option value="0" {{ request('unassigned') ? '' : 'selected' }}>No</option>
                        <option value="1" {{ request('unassigned') ? 'selected' : '' }}>Only Unassigned</option>
                    </select>
                </div>

                <div class="col-md-4">
                    <label class="form-label small">Search</label>
                    <div class="input-group input-group-sm">
                        <input type="text" name="q" value="{{ request('q') }}" class="form-control" placeholder="label or filename">
                        <button class="btn btn-outline-secondary" type="submit">Filter</button>
                        <a href="{{ route('uploads.index') }}" class="btn btn-outline-danger">Clear</a>
                    </div>
                </div>
            </form>
        </div>
    </div>

    <div class="card card-outline card-primary">
        <div class="card-body p-0">
            <div class="table-responsive">
                <table class="table table-sm table-striped mb-0">
                    <thead class="table-light">
                        <tr>
                            <th>#</th>
                            <th>Category</th>
                            <th>Arazi</th>
                            <th>Label / File</th>
                            <th>MIME</th>
                            <th class="text-end">Size (KB)</th>
                            <th>Uploaded</th>
                            <th class="text-end">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        @php
                            $palette = ['primary','success','info','warning','danger','secondary','dark'];
                        @endphp
                        @foreach($uploads as $u)
                            @php
                                $color = $palette[$u->upload_category_id % count($palette)];
                                $ext = strtolower(pathinfo($u->file_path, PATHINFO_EXTENSION));
                                if (str_contains($u->mime,'image')) { $icon = 'bi-image'; }
                                elseif ($ext === 'pdf') { $icon = 'bi-file-earmark-pdf-fill'; }
                                elseif (in_array($ext, ['xls','xlsx','csv'])) { $icon = 'bi-file-earmark-excel-fill'; }
                                elseif (in_array($ext, ['doc','docx'])) { $icon = 'bi-file-earmark-word-fill'; }
                                else { $icon = 'bi-file-earmark-fill'; }
                            @endphp
                            <tr class="align-middle">
                                <td class="text-muted">{{ $u->id }}</td>
                                <td><span class="badge bg-{{ $color }} text-white">{{ $u->category->name }}</span></td>
                                <td>
                                    @if($u->arazi)
                                        <span class="text-muted small">{{ $u->arazi->legacy_arazi_code ?? ('Arazi '.$u->arazi->id) }}</span>
                                    @else
                                        <span class="text-muted small">—</span>
                                    @endif
                                </td>
                                <td>
                                    <i class="bi {{ $icon }} text-muted me-2" style="font-size:1.05rem"></i>
                                    <strong>{{ $u->label ?? basename($u->file_path) }}</strong>
                                    <div class="text-muted small">{{ basename($u->file_path) }}</div>
                                </td>
                                <td class="text-muted small">{{ $u->mime }}</td>
                                <td class="text-end"><span class="text-muted small">{{ number_format($u->size/1024,2) }}</span></td>
                                <td class="text-nowrap">{{ $u->created_at->format('M d, Y H:i') }}</td>
                                <td class="text-end" style="white-space:nowrap;">
                                    <a href="{{ route('uploads.download', $u) }}" class="btn btn-sm btn-primary" title="Download"><i class="bi bi-download"></i> Download</a>
                                </td>
                            </tr>
                        @endforeach
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div class="mt-3">{{ $uploads->links() }}</div>

@push('scripts')
<script>
$(function(){
    $('#filter-arazi').select2({
        theme: 'bootstrap-5',
        placeholder: 'Search Arazi',
        ajax: {
            url: '{{ route('ajax.arazi.search') }}',
            dataType: 'json',
            delay: 250,
            data: function(params){ return { q: params.term }; },
            processResults: function(data){ return { results: data.results }; }
        },
        allowClear: true,
        width: '100%'
    });
});
</script>
@endpush

@endsection

@push('styles')
<style>
    .table thead th { background: #f8fafc; }
    .table tbody tr:hover { background: rgba(13,110,253,0.03); }
    .badge { font-size: 0.85rem; padding: 0.45em 0.6em; }
    .table td { vertical-align: middle; }
</style>
@endpush
