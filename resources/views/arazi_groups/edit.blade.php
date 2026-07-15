@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3">
        <h4 class="mb-0">{{ $title }}</h4>
        <a href="{{ route('arazi-groups.index') }}" class="btn btn-outline-secondary btn-sm ms-auto">
            <i class="bi bi-arrow-left"></i> Back to Groups
        </a>
    </div>

    <div class="card shadow-sm">
        <div class="card-body">
            <form action="{{ route('arazi-groups.update', $group->id) }}" method="POST">
                @csrf
                @method('PUT')

                @php $selected = collect(old('arazi_ids', $selectedIds ?? [])); @endphp

                <div class="row g-3">
                    <div class="col-md-4">
                        <label class="form-label fw-semibold">Map Name <span class="text-danger">*</span></label>
                        <select name="map_name" id="map_name" class="form-select @error('map_name') is-invalid @enderror" required>
                            <option value="">Select map…</option>
                            @foreach($mapNames as $name)
                                <option value="{{ $name }}" @selected(old('map_name', $group->map_name) === $name)>{{ $name }}</option>
                            @endforeach
                        </select>
                        @error('map_name')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        <div class="form-text">Folders found under <code>arazis-map</code>.</div>
                    </div>

                    <div class="col-md-4">
                        <label class="form-label fw-semibold">Group Name</label>
                        <input type="text" name="name" value="{{ old('name', $group->name) }}"
                               class="form-control @error('name') is-invalid @enderror"
                               placeholder="Optional label for this group">
                        @error('name')<div class="invalid-feedback">{{ $message }}</div>@enderror
                    </div>

                    <div class="col-md-4">
                        <label class="form-label fw-semibold">Notes</label>
                        <input type="text" name="notes" value="{{ old('notes', $group->notes) }}"
                               class="form-control @error('notes') is-invalid @enderror"
                               placeholder="Optional notes">
                        @error('notes')<div class="invalid-feedback">{{ $message }}</div>@enderror
                    </div>

                    <div class="col-12">
                        <label class="form-label fw-semibold">Select Arazis to Merge <span class="text-danger">*</span></label>
                        <select name="arazi_ids[]" id="arazi_ids" class="form-select @error('arazi_ids') is-invalid @enderror"
                                multiple data-placeholder="Select arazis to merge…" required>
                            @foreach($arazis as $arazi)
                                <option value="{{ $arazi->id }}" @selected($selected->contains($arazi->id))>
                                    {{ $arazi->legacy_arazi_code ?: ('#'.$arazi->id) }}
                                    @if($arazi->location) — {{ $arazi->location }} @endif
                                    @if($arazi->size) ({{ $arazi->size }}) @endif
                                </option>
                            @endforeach
                        </select>
                        @error('arazi_ids')<div class="invalid-feedback d-block">{{ $message }}</div>@enderror
                        @error('arazi_ids.*')<div class="invalid-feedback d-block">{{ $message }}</div>@enderror
                        <div class="form-text">Pick two or more arazis to merge into this group.</div>
                    </div>
                </div>

                <div class="mt-4 d-flex gap-2">
                    <button type="submit" class="btn btn-primary">
                        <i class="bi bi-save"></i> Update Group
                    </button>
                    <a href="{{ route('arazi-groups.index') }}" class="btn btn-outline-secondary">Cancel</a>
                </div>
            </form>
        </div>
    </div>
</div>
@endsection

@push('scripts')
<script>
(function(){
    function initSelect2(){
        if (!(window.jQuery && jQuery.fn && jQuery.fn.select2)) return;
        ['#map_name', '#arazi_ids'].forEach(function(sel){
            var $el = jQuery(sel);
            if (!$el.length || $el.hasClass('select2-hidden-accessible')) return;
            $el.select2({
                theme: 'bootstrap-5',
                width: '100%',
                placeholder: $el.data('placeholder') || 'Select…',
                allowClear: !$el.prop('multiple')
            });
        });
    }
    if (document.readyState !== 'loading') initSelect2();
    else document.addEventListener('DOMContentLoaded', initSelect2);
})();
</script>
@endpush
