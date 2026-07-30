<?php

namespace App\Models;

// use Illuminate\Contracts\Auth\MustVerifyEmail;
use Carbon\Carbon;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Illuminate\Notifications\Notifiable;
use Laravel\Sanctum\HasApiTokens;

class User extends Authenticatable
{
    use HasApiTokens, HasFactory, Notifiable;

    /**
     * The attributes that are mass assignable.
     *
     * @var array<int, string>
     */
    protected $fillable = [
        'name',
        'username',
        'email',
        'password',
        'password_encrypted',
        'role',
        'role_id',
        'mobile',
        'secondary_mobile',
        'address',
        'is_active',
        'office_latitude',
        'office_longitude',
        'allowed_radius_meters',
        'office_start_time',
        'office_end_time',
        'allow_after_hours',
        'disable_radius_login',
    ];

    /**
     * The attributes that should be hidden for serialization.
     *
     * @var array<int, string>
     */
    protected $hidden = [
        'password',
        'password_encrypted',
        'remember_token',
    ];

    /**
     * The attributes that should be cast.
     *
     * @var array<string, string>
     */
    protected $casts = [
        'email_verified_at' => 'datetime',
        'password' => 'hashed',
        'office_latitude' => 'decimal:7',
        'office_longitude' => 'decimal:7',
        'allowed_radius_meters' => 'integer',
        'allow_after_hours' => 'boolean',
        'disable_radius_login' => 'boolean',
    ];

    public function payments()
    {
        return $this->hasMany(\App\Models\CustomerBondPayment::class, 'taken_by_user_id');
    }

    public function roleModel()
    {
        return $this->belongsTo(\App\Models\Role::class, 'role_id');
    }

    /**
     * Super Admin via the assigned role, or the legacy 'role' string === 'admin'/'super_admin'.
     */
    public function isSuperAdmin(): bool
    {
        if ($this->roleModel && $this->roleModel->isSuperAdmin()) {
            return true;
        }

        return in_array($this->role, ['super_admin', 'admin'], true)
            && $this->role_id === null; // legacy admins with no assigned role
    }

    /**
     * Check a single permission name (e.g. "arazis.create").
     * Super Admin always passes (also enforced by Gate::before).
     */
    public function hasPermission(string $permission): bool
    {
        if ($this->isSuperAdmin()) {
            return true;
        }

        return (bool) $this->roleModel?->hasPermission($permission);
    }

    /**
     * Super Admin and (legacy) Admin accounts are exempt from every
     * location / office-hours restriction below — no GPS check, no office
     * hours window, no auto-logout, no reminder notifications.
     */
    public function isExemptFromRestrictions(): bool
    {
        return $this->isSuperAdmin();
    }

    /**
     * True when the GPS-radius login restriction should be enforced for
     * this user: the global "radius login enabled" switch is on, this user
     * hasn't been individually exempted via "Disable Radius Login", and an
     * effective office point + radius is configured (their own, or —
     * failing that — the company-wide default from Settings).
     */
    public function hasLocationRestriction(): bool
    {
        if (! self::radiusLoginGloballyEnabled()) {
            return false;
        }

        if ($this->disable_radius_login) {
            return false;
        }

        return $this->effectiveOfficeLatitude() !== null
            && $this->effectiveOfficeLongitude() !== null
            && $this->effectiveAllowedRadiusMeters() !== null;
    }

    /**
     * Master on/off switch (Settings, Super Admin only) for the entire
     * GPS-radius login restriction feature, across all users.
     */
    public static function radiusLoginGloballyEnabled(): bool
    {
        return AppSetting::get(AppSetting::RADIUS_LOGIN_ENABLED, '1') !== '0';
    }

    /**
     * This user's office latitude: their own if set, otherwise the
     * company-wide default from Settings.
     */
    public function effectiveOfficeLatitude(): ?float
    {
        if ($this->office_latitude !== null) {
            return (float) $this->office_latitude;
        }

        $default = AppSetting::get(AppSetting::DEFAULT_OFFICE_LATITUDE);

        return $default !== null && $default !== '' ? (float) $default : null;
    }

    /**
     * This user's office longitude: their own if set, otherwise the
     * company-wide default from Settings.
     */
    public function effectiveOfficeLongitude(): ?float
    {
        if ($this->office_longitude !== null) {
            return (float) $this->office_longitude;
        }

        $default = AppSetting::get(AppSetting::DEFAULT_OFFICE_LONGITUDE);

        return $default !== null && $default !== '' ? (float) $default : null;
    }

    /**
     * This user's allowed login radius (meters): their own if set,
     * otherwise the company-wide default from Settings.
     */
    public function effectiveAllowedRadiusMeters(): ?int
    {
        if ($this->allowed_radius_meters !== null) {
            return (int) $this->allowed_radius_meters;
        }

        $default = AppSetting::get(AppSetting::DEFAULT_ALLOWED_RADIUS_METERS);

        return $default !== null && $default !== '' ? (int) $default : null;
    }

    /**
     * True when this user has a configured office-hours window — either
     * their own (User Master form) or, if they have none of their own, the
     * company-wide default configured in Settings (@see AppSetting).
     */
    public function hasOfficeHoursRestriction(): bool
    {
        return ! empty($this->effectiveOfficeStartTime()) && ! empty($this->effectiveOfficeEndTime());
    }

    /**
     * This user's office opening time: their own if set, otherwise the
     * global default from Settings (applies to all users with no override).
     */
    public function effectiveOfficeStartTime(): ?string
    {
        return $this->office_start_time ?: AppSetting::get(AppSetting::DEFAULT_OFFICE_START_TIME);
    }

    /**
     * This user's office closing time: their own if set, otherwise the
     * global default from Settings (applies to all users with no override).
     */
    public function effectiveOfficeEndTime(): ?string
    {
        return $this->office_end_time ?: AppSetting::get(AppSetting::DEFAULT_OFFICE_END_TIME);
    }

    /**
     * Great-circle distance between two lat/lng points, in meters
     * (haversine formula).
     */
    public static function haversineMeters(float $lat1, float $lon1, float $lat2, float $lon2): float
    {
        $earthRadiusMeters = 6371000;

        $latDelta = deg2rad($lat2 - $lat1);
        $lonDelta = deg2rad($lon2 - $lon1);

        $a = sin($latDelta / 2) ** 2
            + cos(deg2rad($lat1)) * cos(deg2rad($lat2)) * sin($lonDelta / 2) ** 2;
        $c = 2 * atan2(sqrt($a), sqrt(1 - $a));

        return $earthRadiusMeters * $c;
    }

    /**
     * Distance (meters) from this user's effective office point (their own,
     * or the company-wide default) to the given coordinates, or null if no
     * office point is configured either way.
     */
    public function distanceFromOfficeMeters(float $lat, float $lng): ?float
    {
        $officeLat = $this->effectiveOfficeLatitude();
        $officeLng = $this->effectiveOfficeLongitude();

        if ($officeLat === null || $officeLng === null) {
            return null;
        }

        return self::haversineMeters($officeLat, $officeLng, $lat, $lng);
    }

    /**
     * True if the given coordinates are within this user's allowed login
     * radius. Always true when no location restriction is configured (or
     * when the restriction is disabled globally / for this specific user).
     */
    public function isWithinAllowedDistance(float $lat, float $lng): bool
    {
        if (! $this->hasLocationRestriction()) {
            return true;
        }

        $distance = $this->distanceFromOfficeMeters($lat, $lng);

        return $distance !== null && $distance <= (float) $this->effectiveAllowedRadiusMeters();
    }

    /**
     * The office-hours window (start/end Carbon instants) that "$at" falls
     * into (or that is upcoming today), handling overnight shifts where the
     * end time is numerically before the start time (e.g. 22:00 -> 06:00).
     * Returns null when no office-hours window is configured.
     *
     * @return array{0: Carbon, 1: Carbon}|null
     */
    public function currentOfficeWindow(?Carbon $at = null): ?array
    {
        if (! $this->hasOfficeHoursRestriction()) {
            return null;
        }

        $at = $at ?? Carbon::now();

        $todayStart = Carbon::parse($at->toDateString() . ' ' . $this->effectiveOfficeStartTime());
        $todayEnd = Carbon::parse($at->toDateString() . ' ' . $this->effectiveOfficeEndTime());

        if ($todayEnd->lessThanOrEqualTo($todayStart)) {
            // Overnight shift — the end time actually falls on the next day.
            $todayEnd = $todayEnd->copy()->addDay();

            // If "$at" is in the early-morning tail of YESTERDAY's overnight
            // shift (before today's start time, but before yesterday's end),
            // that's the window we actually want.
            $yesterdayStart = $todayStart->copy()->subDay();
            $yesterdayEnd = $todayEnd->copy()->subDay();
            if ($at->lessThan($todayStart) && $at->lessThan($yesterdayEnd)) {
                return [$yesterdayStart, $yesterdayEnd];
            }
        }

        return [$todayStart, $todayEnd];
    }

    /**
     * True if "$at" (default: now) falls inside this user's office-hours
     * window. Always true when no window is configured.
     */
    public function isWithinOfficeHours(?Carbon $at = null): bool
    {
        $window = $this->currentOfficeWindow($at);
        if (! $window) {
            return true;
        }

        $at = $at ?? Carbon::now();

        return $at->greaterThanOrEqualTo($window[0]) && $at->lessThanOrEqualTo($window[1]);
    }

    /**
     * The instant at which the 30-minute post-office-hours grace period
     * (see the logout-reminder feature) fully expires, or null when no
     * office-hours window is configured.
     */
    public function officeHoursGraceDeadline(?Carbon $at = null): ?Carbon
    {
        $window = $this->currentOfficeWindow($at);
        if (! $window) {
            return null;
        }

        return $window[1]->copy()->addMinutes(30);
    }
}
