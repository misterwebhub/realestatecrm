<?php

namespace App\Http\Middleware;

use Closure;
use Illuminate\Http\Request;

class CheckPermission
{
    /**
     * Usage: ->middleware('permission:arazis.view')
     * Multiple (any-of): ->middleware('permission:arazis.view,arazis.edit')
     */
    public function handle(Request $request, Closure $next, string $permissions = null)
    {
        $user = $request->user();

        if (! $user) {
            abort(403);
        }

        if ($user->isSuperAdmin() || empty($permissions)) {
            return $next($request);
        }

        $allowed = array_filter(array_map('trim', explode(',', $permissions)));

        foreach ($allowed as $permission) {
            if ($user->hasPermission($permission)) {
                return $next($request);
            }
        }

        abort(403, 'You do not have permission to access this section.');
    }
}
