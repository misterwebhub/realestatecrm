<?php

namespace Database\Seeders;

use App\Models\Permission;
use App\Models\Role;
use App\Models\User;
use Illuminate\Database\Seeder;

class RolePermissionSeeder extends Seeder
{
    public function run(): void
    {
        // 1. Sync permissions from config/permissions.php
        $defaultActions = config('permissions.actions', ['view', 'create', 'edit', 'delete']);
        $modules = config('permissions.modules', []);

        $validNames = [];
        foreach ($modules as $key => $meta) {
            $actions = $meta['actions'] ?? $defaultActions;
            foreach ($actions as $action) {
                $name = "{$key}.{$action}";
                $validNames[] = $name;
                Permission::firstOrCreate(
                    ['name' => $name],
                    ['module' => $key, 'action' => $action]
                );
            }
        }

        // Remove stale permissions no longer present in config.
        Permission::whereNotIn('name', $validNames)->delete();

        // 2. Ensure the Super Admin role exists (bypasses all checks via Gate::before).
        $superAdmin = Role::firstOrCreate(
            ['name' => Role::SUPER_ADMIN],
            ['display_name' => 'Super Admin', 'is_system' => true]
        );
        // Keep Super Admin attached to every permission for clarity in the UI.
        $superAdmin->permissions()->sync(Permission::pluck('id')->all());

        // 3. A couple of sensible starter roles (optional, editable in the UI).
        Role::firstOrCreate(['name' => 'manager'], ['display_name' => 'Manager', 'is_system' => false]);
        Role::firstOrCreate(['name' => 'staff'], ['display_name' => 'Staff', 'is_system' => false]);

        // 4. Promote existing legacy admins to Super Admin role if unassigned.
        User::whereNull('role_id')
            ->where('role', 'admin')
            ->update(['role_id' => $superAdmin->id]);
    }
}
