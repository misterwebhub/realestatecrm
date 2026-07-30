<?php

namespace App\Http\Controllers;

use App\Models\AppSetting;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Crypt;
use Illuminate\Support\Facades\Hash;

class SettingsController extends Controller
{
    /**
     * Settings page: change password + (read-only) view of the office
     * location/hours assigned to the current user, when configured. Super
     * Admins additionally see/manage the company-wide default office hours
     * applied to every user who has no office hours of their own.
     */
    public function index()
    {
        $user = auth()->user();

        return view('settings.index', [
            'title' => 'My Settings',
            'user'  => $user,
            'defaultOfficeStartTime'    => AppSetting::get(AppSetting::DEFAULT_OFFICE_START_TIME),
            'defaultOfficeEndTime'      => AppSetting::get(AppSetting::DEFAULT_OFFICE_END_TIME),
            'defaultOfficeLatitude'     => AppSetting::get(AppSetting::DEFAULT_OFFICE_LATITUDE),
            'defaultOfficeLongitude'    => AppSetting::get(AppSetting::DEFAULT_OFFICE_LONGITUDE),
            'defaultAllowedRadius'      => AppSetting::get(AppSetting::DEFAULT_ALLOWED_RADIUS_METERS),
            'radiusLoginEnabled'        => \App\Models\User::radiusLoginGloballyEnabled(),
            'installmentReminderDays'   => AppSetting::get(AppSetting::INSTALLMENT_REMINDER_DAYS),
            'installmentOverdueDays'    => AppSetting::get(AppSetting::INSTALLMENT_OVERDUE_DAYS),
        ]);
    }

    /**
     * Super-Admin-only: set the company-wide default office hours that
     * apply to every user who has no office_start_time/office_end_time of
     * their own configured on the User Master form. Each user's own
     * "Allow After Office Hours" toggle still overrides this regardless of
     * whether their effective hours come from here or their own profile.
     */
    public function updateOfficeHours(Request $request)
    {
        if (! auth()->user()?->isSuperAdmin()) {
            abort(403);
        }

        $validated = $request->validate([
            'default_office_start_time' => ['nullable', 'date_format:H:i', 'required_with:default_office_end_time'],
            'default_office_end_time'   => ['nullable', 'date_format:H:i', 'required_with:default_office_start_time'],
        ]);

        AppSetting::set(AppSetting::DEFAULT_OFFICE_START_TIME, $validated['default_office_start_time'] ?? null);
        AppSetting::set(AppSetting::DEFAULT_OFFICE_END_TIME, $validated['default_office_end_time'] ?? null);

        return back()->with('success', 'Default office hours updated for all users.');
    }

    /**
     * Super-Admin-only: set the company-wide default office point + login
     * radius (applies to every user who has no lat/lng/radius of their own
     * configured on the User Master form), and the master on/off switch for
     * the entire GPS-radius login restriction feature. A user's own
     * "Disable Radius Login" toggle still overrides this per user,
     * regardless of whether their effective location comes from here or
     * their own profile. Super Admin / Admin accounts are always exempt.
     */
    public function updateLocationDefaults(Request $request)
    {
        if (! auth()->user()?->isSuperAdmin()) {
            abort(403);
        }

        $validated = $request->validate([
            'default_office_latitude'       => ['nullable', 'numeric', 'between:-90,90', 'required_with:default_office_longitude,default_allowed_radius_meters'],
            'default_office_longitude'      => ['nullable', 'numeric', 'between:-180,180', 'required_with:default_office_latitude,default_allowed_radius_meters'],
            'default_allowed_radius_meters' => ['nullable', 'integer', 'min:1', 'max:200000', 'required_with:default_office_latitude,default_office_longitude'],
            'radius_login_enabled'          => ['nullable', 'boolean'],
        ]);

        AppSetting::set(AppSetting::DEFAULT_OFFICE_LATITUDE, $validated['default_office_latitude'] ?? null);
        AppSetting::set(AppSetting::DEFAULT_OFFICE_LONGITUDE, $validated['default_office_longitude'] ?? null);
        AppSetting::set(AppSetting::DEFAULT_ALLOWED_RADIUS_METERS, $validated['default_allowed_radius_meters'] ?? null);
        AppSetting::set(AppSetting::RADIUS_LOGIN_ENABLED, $request->boolean('radius_login_enabled', false) ? '1' : '0');

        return back()->with('success', 'Default login location/radius updated for all users.');
    }

    /**
     * Super-Admin-only: set the company-wide installment reminder/overdue
     * day counts used by the "Pending Installments" report. Reminder days
     * controls how many days before an installment's due date it should be
     * flagged as an upcoming reminder; overdue days controls how many days
     * past the due date an installment is treated as "Overdue" rather than
     * "Pending".
     */
    public function updateInstallmentSettings(Request $request)
    {
        if (! auth()->user()?->isSuperAdmin()) {
            abort(403);
        }

        $validated = $request->validate([
            'installment_reminder_days' => ['nullable', 'integer', 'min:0', 'max:365'],
            'installment_overdue_days'  => ['nullable', 'integer', 'min:0', 'max:365'],
        ]);

        AppSetting::set(AppSetting::INSTALLMENT_REMINDER_DAYS, $validated['installment_reminder_days'] ?? null);
        AppSetting::set(AppSetting::INSTALLMENT_OVERDUE_DAYS, $validated['installment_overdue_days'] ?? null);

        return back()->with('success', 'Installment reminder/overdue settings updated.');
    }

    public function updatePassword(Request $request)
    {
        $user = auth()->user();

        $validated = $request->validate([
            'current_password'      => ['required', 'string'],
            'password'               => ['required', 'string', 'min:6', 'confirmed'],
        ]);

        if (! Hash::check($validated['current_password'], $user->password)) {
            return back()->withErrors(['current_password' => 'Your current password is incorrect.']);
        }

        $user->update([
            'password'           => Hash::make($validated['password']),
            'password_encrypted' => Crypt::encryptString($validated['password']),
        ]);

        return back()->with('success', 'Password updated successfully.');
    }
}
