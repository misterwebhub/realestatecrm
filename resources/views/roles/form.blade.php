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
                    <table id="permMatrix" class="table table-bordered align-middle mb-0" style="font-size:13px;">
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
                        @php $currentGroup = null; @endphp
                        @foreach($grouped as $module => $data)
                            @if(($data['group'] ?? 'Other') !== $currentGroup)
                                @php
                                    $currentGroup = $data['group'] ?? 'Other';
                                    $groupSlug = \Illuminate\Support\Str::slug($currentGroup);
                                @endphp
                                <tr class="table-secondary">
                                    <td colspan="5">
                                        <div class="form-check mb-0">
                                            <input class="form-check-input group-toggle" type="checkbox"
                                                   id="grp_{{ $groupSlug }}" data-group="{{ $groupSlug }}">
                                            <label class="form-check-label fw-bold text-uppercase small" for="grp_{{ $groupSlug }}">
                                                {{ $currentGroup }} <span class="text-muted">— select all</span>
                                            </label>
                                        </div>
                                    </td>
                                </tr>
                            @endif
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
                                            <input class="form-check-input perm-box mod-{{ $module }} grp-{{ $groupSlug }}" type="checkbox"
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

@endsection

@unless($isSuper)
@push('scripts')
<script>
(function(){
    var table = document.getElementById('permMatrix');
    if (!table) return;

    var all = document.getElementById('check_all');

    function boxesFor(sel){ return Array.prototype.slice.call(table.querySelectorAll(sel)); }

    // Recompute the state of every row-toggle, group-toggle and the master.
    function refresh(){
        boxesFor('.row-toggle').forEach(function(rt){
            var b = boxesFor('.mod-' + rt.dataset.module);
            rt.checked = b.length && b.every(function(x){ return x.checked; });
        });
        boxesFor('.group-toggle').forEach(function(gt){
            var b = boxesFor('.grp-' + gt.dataset.group);
            gt.checked = b.length && b.every(function(x){ return x.checked; });
        });
        if (all){
            var every = boxesFor('.perm-box');
            all.checked = every.length && every.every(function(x){ return x.checked; });
        }
    }

    // One delegated handler for the whole matrix.
    table.addEventListener('change', function(e){
        var t = e.target;
        if (t.classList.contains('group-toggle')){
            boxesFor('.grp-' + t.dataset.group).forEach(function(x){ x.checked = t.checked; });
        } else if (t.classList.contains('row-toggle')){
            boxesFor('.mod-' + t.dataset.module).forEach(function(x){ x.checked = t.checked; });
        }
        refresh();
    });

    if (all){
        all.addEventListener('change', function(){
            boxesFor('.perm-box').forEach(function(x){ x.checked = all.checked; });
            refresh();
        });
    }

    refresh();
})();
</script>
@endpush
@endunless
