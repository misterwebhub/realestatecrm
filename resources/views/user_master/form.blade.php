@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">
    <div class="card-header d-flex align-items-center gap-2">
        <h5 class="card-title mb-0 fw-bold">{{ $title }}</h5>
        <a href="{{ route('user-master.index') }}" class="btn btn-secondary btn-sm ms-auto">Back</a>
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
                <div class="col-md-4">
                    <label class="form-label fw-semibold">Name <span class="text-danger">*</span></label>
                    <input type="text" name="name" class="form-control @error('name') is-invalid @enderror"
                        value="{{ old('name', $item?->name) }}" required placeholder="Full name">
                    @error('name')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Username --}}
                <div class="col-md-4">
                    <label class="form-label fw-semibold">Username <span class="text-danger">*</span></label>
                    <input type="text" name="username" class="form-control @error('username') is-invalid @enderror"
                        value="{{ old('username', $item?->username) }}" required placeholder="e.g. john_doe">
                    @error('username')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Role (permissions) --}}
                <div class="col-md-4">
                    <label class="form-label fw-semibold">Role <span class="text-danger">*</span></label>
                    <select name="role_id" class="form-select @error('role_id') is-invalid @enderror" required>
                        <option value="">— Select role —</option>
                        @foreach(($roles ?? []) as $r)
                            <option value="{{ $r->id }}" @selected((string) old('role_id', $item?->role_id) === (string) $r->id)>
                                {{ $r->display_name }}
                            </option>
                        @endforeach
                    </select>
                    <div class="form-text">Controls which modules this user can access.</div>
                    @error('role_id')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Mobile --}}
                <div class="col-md-4">
                    <label class="form-label fw-semibold">Mobile (Primary) <span class="text-danger">*</span></label>
                    <input type="text" name="mobile" class="form-control @error('mobile') is-invalid @enderror"
                        value="{{ old('mobile', $item?->mobile) }}" required placeholder="Primary mobile">
                    @error('mobile')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Secondary Mobile --}}
                <div class="col-md-4">
                    <label class="form-label">Mobile (Secondary)</label>
                    <input type="text" name="secondary_mobile" class="form-control @error('secondary_mobile') is-invalid @enderror"
                        value="{{ old('secondary_mobile', $item?->secondary_mobile) }}" placeholder="Secondary mobile (optional)">
                    @error('secondary_mobile')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Email --}}
                <div class="col-md-4">
                    <label class="form-label">Email <span class="text-muted fw-normal" style="font-size:12px;">(optional)</span></label>
                    <input type="email" name="email" class="form-control @error('email') is-invalid @enderror"
                        value="{{ old('email', $item?->email) }}" placeholder="Email address">
                    @error('email')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Address --}}
                <div class="col-12">
                    <label class="form-label">Address</label>
                    <input type="text" name="address" class="form-control @error('address') is-invalid @enderror"
                        value="{{ old('address', $item?->address) }}" placeholder="Address (optional)">
                    @error('address')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Office Location & Hours --}}
                <div class="col-12">
                    <hr class="my-1">
                    <h6 class="fw-bold mb-1">Office Location &amp; Hours</h6>
                    <div class="form-text mb-2">
                        Used to restrict this user's login to a GPS radius and/or a daily working-hours window.
                        Leave all fields blank to skip these restrictions for this user. Super Admin / Admin
                        accounts are always exempt, regardless of these settings.
                    </div>
                </div>

                @php
                    $effectiveLat = $item ? $item->effectiveOfficeLatitude() : \App\Models\AppSetting::get(\App\Models\AppSetting::DEFAULT_OFFICE_LATITUDE);
                    $effectiveLng = $item ? $item->effectiveOfficeLongitude() : \App\Models\AppSetting::get(\App\Models\AppSetting::DEFAULT_OFFICE_LONGITUDE);
                    $effectiveRadius = $item ? $item->effectiveAllowedRadiusMeters() : \App\Models\AppSetting::get(\App\Models\AppSetting::DEFAULT_ALLOWED_RADIUS_METERS);
                    $isOwnLocationOverride = $item && $item->office_latitude !== null && $item->office_longitude !== null && $item->allowed_radius_meters !== null;
                    $radiusGloballyEnabled = \App\Models\User::radiusLoginGloballyEnabled();
                @endphp
                <div class="col-md-6">
                    <label class="form-label">Login Location &amp; Radius</label>
                    <div class="form-control-plaintext border rounded bg-light px-2 py-1">
                        @if(! $radiusGloballyEnabled)
                            <span class="text-muted">Radius login is currently disabled globally (see Settings).</span>
                        @elseif($effectiveLat !== null && $effectiveLng !== null && $effectiveRadius !== null)
                            {{ $effectiveLat }}, {{ $effectiveLng }} &middot; {{ $effectiveRadius }} m
                            @if($isOwnLocationOverride)
                                <span class="text-muted" style="font-size:12px;">(set specifically for this user)</span>
                            @else
                                <span class="text-muted" style="font-size:12px;">(company default)</span>
                            @endif
                        @else
                            <span class="text-muted">Not configured</span>
                        @endif
                    </div>
                    <div class="form-text">
                        Login location/radius is managed company-wide from
                        <a href="{{ route('settings.index') }}" target="_blank">Settings</a> and is not editable per-user here.
                    </div>
                </div>

                <div class="col-md-6 d-flex align-items-end">
                    <div>
                        <div class="form-check form-switch">
                            <input class="form-check-input" type="checkbox" name="disable_radius_login" id="disable_radius_login" value="1"
                                {{ old('disable_radius_login', $item?->disable_radius_login ?? false) ? 'checked' : '' }}>
                            <label class="form-check-label fw-semibold" for="disable_radius_login">Disable Radius Login for this user</label>
                        </div>
                        <div class="form-text">When enabled, this user can log in from any location, regardless of the company default radius.</div>
                    </div>
                </div>

                @php
                    $effectiveStart = $item
                        ? $item->effectiveOfficeStartTime()
                        : \App\Models\AppSetting::get(\App\Models\AppSetting::DEFAULT_OFFICE_START_TIME);
                    $effectiveEnd = $item
                        ? $item->effectiveOfficeEndTime()
                        : \App\Models\AppSetting::get(\App\Models\AppSetting::DEFAULT_OFFICE_END_TIME);
                    $isOwnOverride = $item && ! empty($item->office_start_time) && ! empty($item->office_end_time);
                @endphp
                <div class="col-md-6">
                    <label class="form-label">Office Hours</label>
                    <div class="form-control-plaintext border rounded bg-light px-2 py-1">
                        @if($effectiveStart && $effectiveEnd)
                            {{ substr($effectiveStart, 0, 5) }} – {{ substr($effectiveEnd, 0, 5) }}
                            @if($isOwnOverride)
                                <span class="text-muted" style="font-size:12px;">(set specifically for this user)</span>
                            @else
                                <span class="text-muted" style="font-size:12px;">(company default)</span>
                            @endif
                        @else
                            <span class="text-muted">Not configured</span>
                        @endif
                    </div>
                    <div class="form-text">
                        Office hours are managed company-wide from
                        <a href="{{ route('settings.index') }}" target="_blank">Settings</a> and are not editable per-user here.
                    </div>
                </div>

                <div class="col-md-6 d-flex align-items-end">
                    <div>
                        <div class="form-check form-switch">
                            <input class="form-check-input" type="checkbox" name="allow_after_hours" id="allow_after_hours" value="1"
                                {{ old('allow_after_hours', $item?->allow_after_hours ?? false) ? 'checked' : '' }}>
                            <label class="form-check-label fw-semibold" for="allow_after_hours">Allow After Office Hours</label>
                        </div>
                        <div class="form-text">When enabled, this user may continue working past their office closing time without being logged out.</div>
                    </div>
                </div>

                {{-- Password (create: always shown & required. edit: Super Admin only —
                     other users must use the account's own change-password flow, not
                     silently overwrite another user's credentials here.) --}}
                @if(!$item || auth()->user()?->isSuperAdmin())
                <div class="col-md-4">
                    <label class="form-label fw-semibold">
                        Password @if($item) <span class="text-muted fw-normal" style="font-size:12px;">(leave blank to keep)</span> @else <span class="text-danger">*</span> @endif
                    </label>
                    <input type="password" name="password" class="form-control @error('password') is-invalid @enderror"
                        placeholder="{{ $item ? 'New password (optional)' : 'Password (min 6 chars)' }}"
                        {{ $item ? '' : 'required' }}>
                    @error('password')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                {{-- Password Confirm --}}
                <div class="col-md-4">
                    <label class="form-label fw-semibold">Confirm Password @if(!$item)<span class="text-danger">*</span>@endif</label>
                    <input type="password" name="password_confirmation" class="form-control"
                        placeholder="Repeat password" @if(!$item) required @endif>
                </div>
                @elseif($item)
                <div class="col-12">
                    <div class="alert alert-light border mb-0 py-2 px-3" style="font-size:13px;">
                        Only a Super Admin can reset this user's password. Use the "Reset Password" action on the User Master list.
                    </div>
                </div>
                @endif

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
