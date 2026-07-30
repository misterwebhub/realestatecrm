<?php

namespace App\Http\Middleware;

use App\Models\AuditLog;
use Carbon\Carbon;
use Closure;
use Illuminate\Support\Facades\Auth;

/**
 * Server-side safety net for the office-hours restriction: if the
 * authenticated user's 30-minute post-office-hours grace period has fully
 * expired (see User::officeHoursGraceDeadline()) and they are not exempt and
 * not allowed to work after hours, force-log them out — even if the
 * client-side countdown/auto-logout JS never ran (JS disabled, tab left
 * open, clock skew, etc.).
 *
 * Super Admin / Admin accounts, and any user with "allow after hours"
 * enabled, or no office-hours window configured at all, are left untouched.
 */
class EnforceOfficeHours
{
    public function handle($request, Closure $next)
    {
        $user = $request->user();

        if ($user
            && ! $user->isExemptFromRestrictions()
            && $user->hasOfficeHoursRestriction()
            && ! $user->allow_after_hours
        ) {
            $deadline = $user->officeHoursGraceDeadline();

            if ($deadline && Carbon::now()->greaterThanOrEqualTo($deadline)) {
                $userId = $user->id;
                $userName = $user->name;

                Auth::logout();
                $request->session()->invalidate();
                $request->session()->regenerateToken();

                try {
                    AuditLog::create([
                        'user_id'        => $userId,
                        'auditable_type' => \App\Models\User::class,
                        'auditable_id'   => $userId,
                        'action'         => 'auto_logout_office_hours',
                        'meta'           => ['reason' => 'office_hours_grace_expired', 'ip' => $request->ip()],
                    ]);
                } catch (\Throwable $e) {
                    // Never let audit-logging failures break the redirect.
                }

                return redirect()->route('login')->with('error', "Your office hours have ended and your session ({$userName}) was automatically logged out.");
            }
        }

        return $next($request);
    }
}
