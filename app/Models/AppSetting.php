<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

/**
 * Global key/value application settings — e.g. the company-wide default
 * office hours applied to every user who has no office hours of their own
 * configured on the User Master form.
 */
class AppSetting extends Model
{
    protected $fillable = ['key', 'value'];

    public const DEFAULT_OFFICE_START_TIME = 'default_office_start_time';
    public const DEFAULT_OFFICE_END_TIME = 'default_office_end_time';

    // Company-wide default office point + radius, applied to every user who
    // has no office_latitude/office_longitude/allowed_radius_meters of their
    // own configured on the User Master form.
    public const DEFAULT_OFFICE_LATITUDE = 'default_office_latitude';
    public const DEFAULT_OFFICE_LONGITUDE = 'default_office_longitude';
    public const DEFAULT_ALLOWED_RADIUS_METERS = 'default_allowed_radius_meters';

    // Master on/off switch for the entire GPS-radius login restriction
    // feature. Stored as the string '1' (enabled) or '0' (disabled). Absent
    // (null) is treated as enabled, so existing configured users keep
    // working the same way unless someone explicitly disables the feature.
    public const RADIUS_LOGIN_ENABLED = 'radius_login_enabled';

    public static function get(string $key, $default = null)
    {
        $row = static::query()->where('key', $key)->first();

        return $row ? $row->value : $default;
    }

    public static function set(string $key, $value): void
    {
        static::query()->updateOrCreate(['key' => $key], ['value' => $value]);
    }
}
