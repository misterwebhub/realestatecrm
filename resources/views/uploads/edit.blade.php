@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary" style="max-width:600px;">
    <div class="card-header d-flex align-items-center gap-2">
        <h5 class="card-title mb-0 fw-bold">Edit Upload</h5>
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

        <form action="{{ route('uploads.update', $upload) }}" method="POST" enctype="multipart/form-data">
            @csrf
            @method('PUT')

            <div class="mb-3">
                <label class="form-label fw-semibold">Category <span class="text-danger">*</span></label>
                <select name="upload_category_id" class="form-select @error('upload_category_id') is-invalid @enderror">
                    <option value="">-- Select Category --</option>
                    @foreach($categories as $id => $label)
                        <option value="{{ $id }}" {{ (string) old('upload_category_id', $upload->upload_category_id) === (string) $id ? 'selected' : '' }}>{{ $label }}</option>
                    @endforeach
                </select>
                @error('upload_category_id')<div class="invalid-feedback">{{ $message }}</div>@enderror
                <div class="form-text">Manage categories in Upload Categories.</div>
            </div>

            <div class="mb-3">
                <label class="form-label fw-semibold">Arazi No. <span class="text-muted fw-normal">(optional)</span></label>
                <input type="text" name="arazi_code" value="{{ old('arazi_code', $upload->arazi_code) }}" class="form-control @error('arazi_code') is-invalid @enderror" placeholder="Type arazi no. (for your own reference only)">
                @error('arazi_code')<div class="invalid-feedback">{{ $message }}</div>@enderror
            </div>

            <div class="mb-3">
                <label class="form-label fw-semibold">Kisan <span class="text-muted fw-normal">(optional)</span></label>
                <input type="text" name="kisan_name" value="{{ old('kisan_name', $upload->kisan_name) }}" class="form-control @error('kisan_name') is-invalid @enderror" placeholder="Type kisan name (for your own reference only)">
                @error('kisan_name')<div class="invalid-feedback">{{ $message }}</div>@enderror
            </div>

            <div class="mb-3">
                <label class="form-label fw-semibold">Partner <span class="text-muted fw-normal">(optional)</span></label>
                <input type="text" name="partner_name" value="{{ old('partner_name', $upload->partner_name) }}" class="form-control @error('partner_name') is-invalid @enderror" placeholder="Type partner name (for your own reference only)">
                @error('partner_name')<div class="invalid-feedback">{{ $message }}</div>@enderror
            </div>

            <div class="mb-3">
                <label class="form-label fw-semibold">Label</label>
                <input type="text" name="label" value="{{ old('label', $upload->label) }}" class="form-control" placeholder="Optional description">
            </div>

            <div class="mb-3">
                <label class="form-label fw-semibold">Reason</label>
                <textarea name="reason" rows="2" class="form-control @error('reason') is-invalid @enderror"
                    placeholder="Why is this being uploaded? (optional)">{{ old('reason', $upload->reason) }}</textarea>
                @error('reason')<div class="invalid-feedback">{{ $message }}</div>@enderror
            </div>

            <div class="mb-4">
                <label class="form-label fw-semibold">File</label>
                <div class="mb-2">
                    <a href="{{ route('uploads.download', $upload) }}" class="small">
                        <i class="bi bi-paperclip"></i> {{ basename($upload->file_path) }}
                    </a>
                    <span class="text-muted small">(current file)</span>
                </div>
                <input type="file" name="file" class="form-control @error('file') is-invalid @enderror">
                @error('file')<div class="invalid-feedback">{{ $message }}</div>@enderror
                <div class="form-text">Leave empty to keep the current file. Max 10 MB.</div>
            </div>

            <div class="d-flex gap-2">
                <button class="btn btn-primary px-4"><i class="bi bi-save"></i> Save Changes</button>
                <a href="{{ route('uploads.index') }}" class="btn btn-outline-secondary">Cancel</a>
            </div>
        </form>
    </div>
</div>
@endsection

