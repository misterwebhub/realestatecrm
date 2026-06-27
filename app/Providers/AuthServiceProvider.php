<?php

namespace App\Providers;

use App\Models\Permission;
use App\Models\User;
use Illuminate\Foundation\Support\Providers\AuthServiceProvider as ServiceProvider;
use Illuminate\Support\Facades\Gate;

class AuthServiceProvider extends ServiceProvider
{
    /**
     * The model to policy mappings for the application.
     *
     * @var array<class-string, class-string>
     */
    protected $policies = [
        //
    ];

    /**
     * Register any authentication / authorization services.
     */
    public function boot(): void
    {
        // Super Admin bypasses every permission check.
        Gate::before(function (User $user, string $ability) {
            return $user->isSuperAdmin() ? true : null;
        });

        // Register a gate ability for every "module.action" permission so that
        // @can('arazis.view'), $user->can('arazis.view') and the
        // 'permission:arazis.view' middleware all resolve against the user's role.
        try {
            foreach (Permission::pluck('name') as $name) {
                Gate::define($name, fn (User $user) => $user->hasPermission($name));
            }
        } catch (\Throwable $e) {
            // Tables not migrated yet (e.g. during initial migrate) — ignore.
        }
    }
}
