@extends('layouts.app')

@section('content')
<div class="row g-3">
    <div class="col-lg-6">
        <div class="card card-outline card-primary">
            <div class="card-header">
                <h5 class="card-title mb-0 fw-bold">Change Password</h5>
            </div>
            <div class="card-body">
                @if($errors->any())
                    <div class="alert alert-danger">
                        <ul class="mb-0">@foreach($errors->all() as $e)<li>{{ $e }}</li>@endforeach</ul>
                    </div>
                @endif

                <form method="POST" action="{{ route('settings.password') }}">
                    @csrf
                    <div class="mb-3">
                        <label class="form-label fw-semibold">Current Password <span class="text-danger">*</span></label>
                        <input type="password" name="current_password" class="form-control @error('current_password') is-invalid @enderror" required>
                        @error('current_password')<div class="invalid-feedback">{{ $message }}</div>@enderror
                    </div>
                    <div class="mb-3">
                        <label class="form-label fw-semibold">New Password <span class="text-danger">*</span></label>
                        <input type="password" name="password" class="form-control @error('password') is-invalid @enderror" required placeholder="Min 6 chars">
                        @error('password')<div class="invalid-feedback">{{ $message }}</div>@enderror
                    </div>
                    <div class="mb-3">
                        <label class="form-label fw-semibold">Confirm New Password <span class="text-danger">*</span></label>
                        <input type="password" name="password_confirmation" class="form-control" required>
                    </div>
                    <button type="submit" class="btn btn-primary px-4">Update Password</button>
                </form>
            </div>
        </div>
    </div>

    <div class="col-lg-6">
        <div class="card card-outline card-info">
            <div class="card-header">
                <h5 class="card-title mb-0 fw-bold">My Office Location &amp; Hours</h5>
            </div>
            <div class="card-body">
                @if($user->isExemptFromRestrictions())
                    <div class="alert alert-light border mb-0">
                        As a Super Admin / Admin, no location or office-hours restrictions apply to your account.
                    </div>
                @else
                    <dl class="row mb-0">
                        <dt class="col-sm-5">Login Location &amp; Radius</dt>
                        <dd class="col-sm-7">
                            @if(! $radiusLoginEnabled)
                                <span class="text-muted">Disabled globally (see below)</span>
                            @elseif($user->disable_radius_login)
                                <span class="text-muted">Disabled for this user</span>
                            @elseif($user->effectiveOfficeLatitude() !== null && $user->effectiveOfficeLongitude() !== null && $user->effectiveAllowedRadiusMeters() !== null)
                                {{ $user->effectiveOfficeLatitude() }}, {{ $user->effectiveOfficeLongitude() }} &middot; {{ $user->effectiveAllowedRadiusMeters() }} m
                                @if($user->office_latitude !== null && $user->office_longitude !== null && $user->allowed_radius_meters !== null)
                                    <span class="text-muted" style="font-size:12px;">(set specifically for you)</span>
                                @else
                                    <span class="text-muted" style="font-size:12px;">(company default)</span>
                                @endif
                            @else
                                <span class="text-muted">Not configured</span>
                            @endif
                        </dd>

                        @if($user->hasOfficeHoursRestriction())
                            <dt class="col-sm-5">Office Hours</dt>
                            <dd class="col-sm-7">
                                {{ substr($user->effectiveOfficeStartTime(), 0, 5) }} – {{ substr($user->effectiveOfficeEndTime(), 0, 5) }}
                                @if(empty($user->office_start_time))
                                    <span class="text-muted" style="font-size:12px;">(company default)</span>
                                @endif
                            </dd>
                            <dt class="col-sm-5">Allowed After Hours</dt>
                            <dd class="col-sm-7">{{ $user->allow_after_hours ? 'Yes' : 'No' }}</dd>
                        @else
                            <dt class="col-sm-5">Office Hours</dt>
                            <dd class="col-sm-7"><span class="text-muted">Not configured</span></dd>
                        @endif
                    </dl>
                @endif
            </div>
        </div>
    </div>

    @if($user->isSuperAdmin())
    <div class="col-lg-6">
        <div class="card card-outline card-warning">
            <div class="card-header">
                <h5 class="card-title mb-0 fw-bold">Default Office Hours (All Users)</h5>
            </div>
            <div class="card-body">
                <div class="form-text mb-3">
                    Applies to every user who has no office hours of their own set on the User Master form.
                    A user's individual "Allow After Office Hours" setting always overrides this, whether their
                    hours come from here or from their own profile. Super Admin / Admin accounts are always exempt.
                </div>

                <form method="POST" action="{{ route('settings.office-hours') }}">
                    @csrf
                    <div class="row g-3">
                        <div class="col-md-6">
                            <label class="form-label fw-semibold">Default Opening Time</label>
                            <input type="time" name="default_office_start_time"
                                class="form-control @error('default_office_start_time') is-invalid @enderror"
                                value="{{ old('default_office_start_time', $defaultOfficeStartTime ? substr($defaultOfficeStartTime, 0, 5) : '') }}">
                            @error('default_office_start_time')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                        <div class="col-md-6">
                            <label class="form-label fw-semibold">Default Closing Time</label>
                            <input type="time" name="default_office_end_time"
                                class="form-control @error('default_office_end_time') is-invalid @enderror"
                                value="{{ old('default_office_end_time', $defaultOfficeEndTime ? substr($defaultOfficeEndTime, 0, 5) : '') }}">
                            @error('default_office_end_time')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                    </div>
                    <div class="mt-3">
                        <button type="submit" class="btn btn-warning px-4">Save Default Hours</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <div class="col-lg-6">
        <div class="card card-outline card-warning">
            <div class="card-header">
                <h5 class="card-title mb-0 fw-bold">Default Login Location &amp; Radius (All Users)</h5>
            </div>
            <div class="card-body">
                <div class="form-text mb-3">
                    Applies to every user who has no login location/radius of their own set on the User Master form.
                    A user's individual "Disable Radius Login" setting always overrides this, whether their location
                    comes from here or from their own profile. Super Admin / Admin accounts are always exempt.
                </div>

                <form method="POST" action="{{ route('settings.location-defaults') }}">
                    @csrf
                    <div class="form-check form-switch mb-3">
                        <input class="form-check-input" type="checkbox" name="radius_login_enabled" id="radius_login_enabled" value="1"
                            {{ old('radius_login_enabled', $radiusLoginEnabled) ? 'checked' : '' }}>
                        <label class="form-check-label fw-semibold" for="radius_login_enabled">Enable Radius Login Restriction (globally)</label>
                    </div>

                    <div class="row g-3">
                        <div class="col-md-4">
                            <label class="form-label fw-semibold">Default Latitude</label>
                            <input type="text" name="default_office_latitude" id="default_office_latitude"
                                class="form-control @error('default_office_latitude') is-invalid @enderror"
                                value="{{ old('default_office_latitude', $defaultOfficeLatitude) }}" placeholder="e.g. 28.6139000">
                            @error('default_office_latitude')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                        <div class="col-md-4">
                            <label class="form-label fw-semibold">Default Longitude</label>
                            <input type="text" name="default_office_longitude" id="default_office_longitude"
                                class="form-control @error('default_office_longitude') is-invalid @enderror"
                                value="{{ old('default_office_longitude', $defaultOfficeLongitude) }}" placeholder="e.g. 77.2090000">
                            @error('default_office_longitude')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                        <div class="col-md-4">
                            <label class="form-label fw-semibold">Allowed Radius (meters)</label>
                            <input type="number" name="default_allowed_radius_meters" min="1" max="200000"
                                class="form-control @error('default_allowed_radius_meters') is-invalid @enderror"
                                value="{{ old('default_allowed_radius_meters', $defaultAllowedRadius) }}" placeholder="e.g. 200">
                            @error('default_allowed_radius_meters')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                    </div>

                    <div class="mt-2">
                        <button type="button" id="use-current-location-btn" class="btn btn-outline-secondary btn-sm">Use current location</button>
                        <span id="use-current-location-status" class="text-muted" style="font-size:12px;"></span>
                    </div>

                    <div class="mt-3">
                        <button type="submit" class="btn btn-warning px-4">Save Default Location</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    @endif
</div>

@if($user->isSuperAdmin())
@push('scripts')
<script>
    document.getElementById('use-current-location-btn')?.addEventListener('click', function () {
        var status = document.getElementById('use-current-location-status');
        if (! navigator.geolocation) {
            status.textContent = 'Geolocation is not supported by this browser.';
            return;
        }
        status.textContent = 'Locating…';
        navigator.geolocation.getCurrentPosition(function (position) {
            document.getElementById('default_office_latitude').value = position.coords.latitude.toFixed(7);
            document.getElementById('default_office_longitude').value = position.coords.longitude.toFixed(7);
            status.textContent = 'Location captured.';
        }, function () {
            status.textContent = 'Unable to retrieve your location.';
        });
    });
</script>
@endpush
@endif
@endsection
