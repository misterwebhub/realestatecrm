<?php

namespace App\Http\Controllers;

use App\Models\AuditLog;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class AuthController extends Controller
{
    public function showLogin()
    {
        return view('auth.login');
    }

    public function login(Request $request)
    {
        $credentials = $request->validate([
            'email' => ['required', 'email'],
            'password' => ['required'],
        ]);

        $latitude  = $request->input('latitude');
        $longitude = $request->input('longitude');

        if (Auth::attempt($credentials, $request->boolean('remember'))) {
            $user = Auth::user();

            if (! $user->isExemptFromRestrictions()) {
                // Location (GPS radius) check.
                if ($user->hasLocationRestriction()) {
                    if ($latitude === null || $longitude === null || $latitude === '' || $longitude === '') {
                        Auth::logout();
                        $this->logDenied($user, 'login_denied_no_location');

                        return back()
                            ->withErrors(['email' => 'Location access is required to log in. Please enable location services in your browser and try again.'])
                            ->onlyInput('email');
                    }

                    if (! $user->isWithinAllowedDistance((float) $latitude, (float) $longitude)) {
                        Auth::logout();
                        $this->logDenied($user, 'login_denied_out_of_range', [
                            'latitude' => (float) $latitude,
                            'longitude' => (float) $longitude,
                        ]);

                        return back()
                            ->withErrors(['email' => 'You are outside the allowed login location for your account.'])
                            ->onlyInput('email');
                    }
                }

                // Office-hours window check (skipped when after-hours work is allowed).
                if ($user->hasOfficeHoursRestriction() && ! $user->allow_after_hours && ! $user->isWithinOfficeHours()) {
                    Auth::logout();
                    $this->logDenied($user, 'login_denied_outside_office_hours');

                    return back()
                        ->withErrors(['email' => 'You can only log in during your configured office hours.'])
                        ->onlyInput('email');
                }
            }

            $request->session()->regenerate();
            // Reset the "shown once per session" office-hours reminder flag for this fresh session.
            $request->session()->forget('office_hours_reminder_shown');

            return redirect()->intended(route('dashboard'));
        }

        return back()->withErrors(['email' => 'Invalid credentials'])->onlyInput('email');
    }

    /**
     * Record a denied-login event (location/office-hours restriction) to the
     * audit log, for the same audit trail used for auto-logout events.
     */
    protected function logDenied($user, string $action, array $extra = []): void
    {
        try {
            AuditLog::create([
                'user_id'        => $user->id,
                'auditable_type' => get_class($user),
                'auditable_id'   => $user->id,
                'action'         => $action,
                'meta'           => array_merge(['ip' => request()->ip()], $extra),
            ]);
        } catch (\Throwable $e) {
            // Never let audit-logging failures block/break the login flow.
        }
    }

    public function logout(Request $request)
    {
        Auth::logout();
        $request->session()->invalidate();
        $request->session()->regenerateToken();

        return redirect()->route('login');
    }

    /**
     * Called by the client-side office-hours countdown (see layouts/app.blade.php)
     * once the 30-minute post-office-hours grace period has fully elapsed.
     * The EnforceOfficeHours middleware is the server-side safety net for this
     * same deadline; this endpoint just lets the browser act on it immediately
     * instead of waiting for the user's next navigation.
     */
    public function autoLogout(Request $request)
    {
        $user = $request->user();

        if ($user) {
            $this->logDenied($user, 'auto_logout_office_hours', ['reason' => 'client_countdown_expired']);
        }

        Auth::logout();
        $request->session()->invalidate();
        $request->session()->regenerateToken();

        return redirect()->route('login')->with('error', 'Your office hours have ended. You have been automatically logged out.');
    }
}
