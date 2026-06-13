@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary" style="max-width:680px;">
    <div class="card-header d-flex align-items-center justify-content-between">
        <h5 class="card-title mb-0 fw-bold">{{ $title }}</h5>
        <a href="{{ route('user-master.index') }}" class="btn btn-secondary btn-sm">Back</a>
    </div>
    <div class="card-body">
        @if($errors->any())
            <div class="alert alert-danger">
                <ul class="mb-0">@foreach($errors->all() as $e)<li>{{ $e }}</li>@endforeach</ul>
            </div>
        @endif

        <form method="POST" action="{{ $action }}">
            @csrf
            @if($method === 'PUT') @method('PUT') @endif

            <div class="row g-3">
                {{-- Name --}}
                <div class="col-md-6">
                    <label class="form-label fw-semibold">Name <span class="text-danger">*</span></label>
                    <input type="text" name="name" class="form-control @error('name') is-invalid @enderror"
                        value="{{ old('name', $item?->name) }}" required placeholder="Full name">
                    @error('name')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Username --}}
                <div class="col-md-6">
                    <label class="form-label fw-semibold">Username <span class="text-danger">*</span></label>
                    <input type="text" name="username" class="form-control @error('username') is-invalid @enderror"
                        value="{{ old('username', $item?->username) }}" required placeholder="e.g. john_doe">
                    @error('username')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Mobile --}}
                <div class="col-md-6">
                    <label class="form-label fw-semibold">Mobile (Primary) <span class="text-danger">*</span></label>
                    <input type="text" name="mobile" class="form-control @error('mobile') is-invalid @enderror"
                        value="{{ old('mobile', $item?->mobile) }}" required placeholder="Primary mobile">
                    @error('mobile')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Secondary Mobile --}}
                <div class="col-md-6">
                    <label class="form-label">Mobile (Secondary)</label>
                    <input type="text" name="secondary_mobile" class="form-control @error('secondary_mobile') is-invalid @enderror"
                        value="{{ old('secondary_mobile', $item?->secondary_mobile) }}" placeholder="Secondary mobile (optional)">
                    @error('secondary_mobile')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Email --}}
                <div class="col-md-6">
                    <label class="form-label">Email <span class="text-muted fw-normal" style="font-size:12px;">(optional)</span></label>
                    <input type="email" name="email" class="form-control @error('email') is-invalid @enderror"
                        value="{{ old('email', $item?->email) }}" placeholder="Email address">
                    @error('email')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Role --}}
                <div class="col-md-6">
                    <label class="form-label fw-semibold">Role</label>
                    <select name="role" class="form-select @error('role') is-invalid @enderror">
                        <option value="staff"      @selected(old('role', $item?->role ?? 'staff') === 'staff')>Staff</option>
                        <option value="accountant" @selected(old('role', $item?->role) === 'accountant')>Accountant</option>
                        <option value="manager"    @selected(old('role', $item?->role) === 'manager')>Manager</option>
                        <option value="admin"      @selected(old('role', $item?->role) === 'admin')>Admin</option>
                    </select>
                    @error('role')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Address --}}
                <div class="col-12">
                    <label class="form-label">Address</label>
                    <input type="text" name="address" class="form-control @error('address') is-invalid @enderror"
                        value="{{ old('address', $item?->address) }}" placeholder="Address (optional)">
                    @error('address')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Password --}}
                <div class="col-md-6">
                    <label class="form-label fw-semibold">
                        Password @if($item) <span class="text-muted fw-normal" style="font-size:12px;">(leave blank to keep)</span> @else <span class="text-danger">*</span> @endif
                    </label>
                    <input type="password" name="password" class="form-control @error('password') is-invalid @enderror"
                        placeholder="{{ $item ? 'New password (optional)' : 'Password (min 6 chars)' }}"
                        {{ $item ? '' : 'required' }}>
                    @error('password')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Password Confirm --}}
                <div class="col-md-6">
                    <label class="form-label fw-semibold">Confirm Password @if(!$item)<span class="text-danger">*</span>@endif</label>
                    <input type="password" name="password_confirmation" class="form-control"
                        placeholder="Repeat password" @if(!$item) required @endif>
                </div>

                {{-- Active toggle --}}
                <div class="col-12">
                    <div class="form-check form-switch">
                        <input class="form-check-input" type="checkbox" name="is_active" id="is_active" value="1"
                            {{ old('is_active', $item?->is_active ?? true) ? 'checked' : '' }}>
                        <label class="form-check-label fw-semibold" for="is_active">Active (can be selected in payment forms)</label>
                    </div>
                </div>
            </div>

            <div class="d-flex gap-2 mt-4">
                <button type="submit" class="btn btn-primary px-4">Save User</button>
                <a href="{{ route('user-master.index') }}" class="btn btn-outline-secondary">Cancel</a>
            </div>
        </form>
    </div>
</div>
@endsection
