<?php

namespace App\Http\Middleware;

use Closure;
use Illuminate\Http\Request;

class CheckRole
{
    /**
     * Handle an incoming request.
     * Roles parameter can be comma separated, e.g. 'admin,manager'
     */
    public function handle(Request $request, Closure $next, string $roles = null)
    {
        $user = $request->user();

        if (! $user) {
            abort(403);
        }

        if (empty($roles)) {
            return $next($request);
        }

        $allowed = array_map('trim', explode(',', $roles));

        if (! in_array($user->role, $allowed, true)) {
            abort(403);
        }

        return $next($request);
    }
}
