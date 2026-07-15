@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary" style="max-width:600px;">
    <div class="card-header d-flex align-items-center gap-2">
        <h5 class="card-title mb-0 fw-bold">New Upload</h5>
        <a href="{{ route('uploads.index') }}" class="btn btn-outline-secondary btn-sm ms-auto">
            <i class="bi bi-arrow-left"></i> Back
        </a>
    </div>
    <div class="card-body">
        @if($errors->any())
            <div class="alert alert-danger">
                <ul class="mb-0">@foreach($errors->all() as $e)<li>{{ $e }}</li>@endforeach</ul>
            </div>
        @endif

        <form action="{{ route('uploads.store') }}" method="POST" enctype="multipart/form-data">
            @csrf

            <div class="mb-3">
                <label class="form-label fw-semibold">Category <span class="text-danger">*</span></label>
                <select name="upload_category_id" class="form-select @error('upload_category_id') is-invalid @enderror">
                    <option value="">-- Select Category --</option>
                    @foreach($categories as $id => $label)
                        <option value="{{ $id }}" {{ old('upload_category_id') == $id ? 'selected' : '' }}>{{ $label }}</option>
                    @endforeach
                </select>
                @error('upload_category_id')<div class="invalid-feedback">{{ $message }}</div>@enderror
                <div class="form-text">Manage categories in Upload Categories.</div>
            </div>

            <div class="mb-3">
                <label class="form-label fw-semibold">Arazi No. <span class="text-muted fw-normal">(optional)</span></label>
                <select name="arazi_code" id="arazi-select" class="form-select">
                    <option value="">-- None --</option>
                    @foreach($araziOptions as $code)
                        <option value="{{ $code }}" {{ old('arazi_code') === $code ? 'selected' : '' }}>{{ $code }}</option>
                    @endforeach
                </select>
            </div>

            <div class="mb-3">
                <label class="form-label fw-semibold">Label</label>
                <input type="text" name="label" value="{{ old('label') }}" class="form-control" placeholder="Optional description">
            </div>

            <div class="mb-4">
                <label class="form-label fw-semibold">File <span class="text-danger">*</span></label>
                <input type="file" name="file" class="form-control @error('file') is-invalid @enderror">
                @error('file')<div class="invalid-feedback">{{ $message }}</div>@enderror
                <div class="form-text">Max 10 MB.</div>
            </div>

            <div class="d-flex gap-2">
                <button class="btn btn-primary px-4"><i class="bi bi-upload"></i> Upload</button>
                <a href="{{ route('uploads.index') }}" class="btn btn-outline-secondary">Cancel</a>
            </div>
        </form>
    </div>
</div>
@endsection

@push('scripts')
<script>
$(function(){
    $('#arazi-select').select2({
        theme: 'bootstrap-5',
        placeholder: '-- None --',
        allowClear: true,
        width: '100%'
    });
});
</script>
@endpush
