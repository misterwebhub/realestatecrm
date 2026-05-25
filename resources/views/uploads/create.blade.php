@extends('layouts.app')

@section('content')
<div class="container py-3">
    <div class="card">
        <div class="card-body">
            <h4>Create Upload</h4>
            <form action="{{ route('uploads.store') }}" method="post" enctype="multipart/form-data">
                @csrf
                <div class="mb-3">
                    <label class="form-label">Category</label>
                    <select name="upload_category_id" class="form-select">
                        @foreach($categories as $id => $label)
                            <option value="{{ $id }}">{{ $label }}</option>
                        @endforeach
                    </select>
                    <small class="form-text text-muted">You can add categories in Upload Categories.</small>
                </div>
                <div class="mb-3">
                    <label class="form-label">Arazi (optional)</label>
                    <select id="arazi-select" name="arazi_id" class="form-select"></select>
                </div>
                <div class="mb-3">
                    <label class="form-label">Label</label>
                    <input type="text" name="label" class="form-control" />
                </div>
                <div class="mb-3">
                    <label class="form-label">File</label>
                    <input type="file" name="file" class="form-control" />
                </div>
                <button class="btn btn-primary">Upload</button>
            </form>
        </div>
    </div>
</div>
@endsection

@push('scripts')
<script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>
<link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
<script>
document.addEventListener('DOMContentLoaded', function(){
    $('#arazi-select').select2({
        placeholder: 'Select Arazi (or leave empty)',
        allowClear: true,
        ajax: {
            url: '{{ route('ajax.arazi.search') }}',
            dataType: 'json',
            delay: 250,
            data: function(params){ return { q: params.term }; },
            processResults: function(data){ return { results: data.results }; }
        }
    });
});
</script>
@endpush
