<?php

namespace App\Http\Controllers;

use App\Models\Permission;
use App\Models\Role;
use Illuminate\Http\Request;
use Illuminate\Support\Str;
use Illuminate\Validation\Rule;

class RoleController extends Controller
{
    public function index()
    {
        $roles = Role::withCount(['permissions', 'users'])->orderBy('display_name')->get();

        return view('roles.index', ['roles' => $roles]);
    }

    public function create()
    {
        return view('roles.form', [
            'title'   => 'Add Role',
            'action'  => route('roles.store'),
            'method'  => 'POST',
            'role'    => null,
            'grouped' => $this->groupedPermissions(),
            'assigned' => [],
        ]);
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'display_name' => ['required', 'string', 'max:100'],
            'permissions'  => ['array'],
            'permissions.*' => ['integer', 'exists:permissions,id'],
        ]);

        $role = Role::create([
            'name'         => $this->uniqueSlug($validated['display_name']),
            'display_name' => $validated['display_name'],
            'is_system'    => false,
        ]);

        $role->permissions()->sync($validated['permissions'] ?? []);

        return redirect()->route('roles.index')->with('success', 'Role created successfully.');
    }

    public function edit(Role $role)
    {
        return view('roles.form', [
            'title'    => 'Edit Role — ' . $role->display_name,
            'action'   => route('roles.update', $role),
            'method'   => 'PUT',
            'role'     => $role,
            'grouped'  => $this->groupedPermissions(),
            'assigned' => $role->permissions->pluck('id')->all(),
        ]);
    }

    public function update(Request $request, Role $role)
    {
        $validated = $request->validate([
            'display_name' => ['required', 'string', 'max:100'],
            'permissions'  => ['array'],
            'permissions.*' => ['integer', 'exists:permissions,id'],
        ]);

        $role->update(['display_name' => $validated['display_name']]);

        // Super Admin always keeps every permission.
        if ($role->isSuperAdmin()) {
            $role->permissions()->sync(Permission::pluck('id')->all());
        } else {
            $role->permissions()->sync($validated['permissions'] ?? []);
        }

        return redirect()->route('roles.index')->with('success', 'Role updated successfully.');
    }

    public function destroy(Role $role)
    {
        if ($role->is_system) {
            return redirect()->route('roles.index')
                ->with('error', 'System roles cannot be deleted.');
        }

        if ($role->users()->exists()) {
            return redirect()->route('roles.index')
                ->with('error', 'Cannot delete a role that is still assigned to users.');
        }

        $role->delete();

        return redirect()->route('roles.index')->with('success', 'Role deleted successfully.');
    }

    /**
     * Permissions grouped by module for the checkbox matrix.
     */
    protected function groupedPermissions(): array
    {
        $labels = collect(config('permissions.modules', []))
            ->mapWithKeys(fn ($meta, $key) => [$key => $meta['label'] ?? Str::headline($key)]);

        return Permission::orderBy('module')->orderBy('id')->get()
            ->groupBy('module')
            ->map(fn ($perms, $module) => [
                'label'       => $labels[$module] ?? Str::headline($module),
                'permissions' => $perms,
            ])->all();
    }

    protected function uniqueSlug(string $name): string
    {
        $base = Str::slug($name, '_') ?: 'role';
        $slug = $base;
        $i = 1;
        while (Role::where('name', $slug)->exists()) {
            $slug = $base . '_' . $i++;
        }
        return $slug;
    }
}
