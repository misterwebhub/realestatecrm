@extends('layouts.app')

@section('content')
@php $isSuper = $role && $role->name === \App\Models\Role::SUPER_ADMIN; @endphp
<div class="card card-outline card-primary">
    <div class="card-header">
        <h5 class="card-title mb-0 fw-bold">{{ $title }}</h5>
    </div>
    <form action="{{ $action }}" method="POST">
        @csrf
        @if(($method ?? 'POST') !== 'POST') @method($method) @endif

        <div class="card-body">
            <div class="row g-3 mb-3">
                <div class="col-md-5">
                    <label class="form-label fw-semibold">Role Name <span class="text-danger">*</span></label>
                    <input type="text" name="display_name" class="form-control @error('display_name') is-invalid @enderror"
                           value="{{ old('display_name', $role->display_name ?? '') }}" required @if($isSuper) readonly @endif>
                    @error('display_name')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
            </div>

            @if($isSuper)
                <div class="alert alert-success mb-0">
                    <i class="bi bi-shield-check"></i>
                    <strong>Super Admin</strong> automatically has access to every module and action. Permissions cannot be edited.
                </div>
            @else
                <div class="d-flex align-items-center mb-2">
                    <h6 class="fw-bold mb-0">Module Permissions</h6>
                    <div class="form-check ms-auto">
                        <input class="form-check-input" type="checkbox" id="check_all">
                        <label class="form-check-label small" for="check_all">Select / clear all</label>
                    </div>
                </div>

                <div class="table-responsive">
                    <table class="table table-bordered align-middle mb-0" style="font-size:13px;">
                        <thead class="table-light">
                            <tr>
                                <th style="min-width:180px;">Module</th>
                                <th class="text-center">View</th>
                                <th class="text-center">Create</th>
                                <th class="text-center">Edit</th>
                                <th class="text-center">Delete</th>
                            </tr>
                        </thead>
                        <tbody>
                        @foreach($grouped as $module => $data)
                            <tr>
                                <td class="fw-semibold">
                                    <div class="form-check">
                                        <input class="form-check-input row-toggle" type="checkbox"
                                               id="row_{{ $module }}" data-module="{{ $module }}">
                                        <label class="form-check-label" for="row_{{ $module }}">{{ $data['label'] }}</label>
                                    </div>
                                </td>
                                @foreach(['view','create','edit','delete'] as $action)
                                    @php $perm = $data['permissions']->firstWhere('action', $action); @endphp
                                    <td class="text-center">
                                        @if($perm)
                                            <input class="form-check-input perm-box mod-{{ $module }}" type="checkbox"
                                                   name="permissions[]" value="{{ $perm->id }}"
                                                   @checked(in_array($perm->id, old('permissions', $assigned)))>
                                        @else
                                            <span class="text-muted">—</span>
                                        @endif
                                    </td>
                                @endforeach
                            </tr>
                        @endforeach
                        </tbody>
                    </table>
                </div>
            @endif
        </div>

        <div class="card-footer">
            <button type="submit" class="btn btn-primary">Save Role</button>
            <a href="{{ route('roles.index') }}" class="btn btn-outline-secondary ms-2">Cancel</a>
        </div>
    </form>
</div>

@unless($isSuper)
<script>
(function(){
    // Row toggle: check/clear all actions for a module
    document.querySelectorAll('.row-toggle').forEach(function(rt){
        const boxes = document.querySelectorAll('.mod-' + rt.dataset.module);
        function syncRow(){ rt.checked = boxes.length && Array.from(boxes).every(b => b.checked); }
        rt.addEventListener('change', function(){ boxes.forEach(b => b.checked = rt.checked); });
        boxes.forEach(b => b.addEventListener('change', syncRow));
        syncRow();
    });
    // Master toggle
    const all = document.getElementById('check_all');
    if(all){
        const everyBox = document.querySelectorAll('.perm-box');
        const everyRow = document.querySelectorAll('.row-toggle');
        function syncAll(){ all.checked = everyBox.length && Array.from(everyBox).every(b => b.checked); }
        all.addEventListener('change', function(){
            everyBox.forEach(b => b.checked = all.checked);
            everyRow.forEach(r => r.checked = all.checked);
        });
        everyBox.forEach(b => b.addEventListener('change', syncAll));
        syncAll();
    }
})();
</script>
@endunless
@endsection
