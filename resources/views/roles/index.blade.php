@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">
    <div class="card-header d-flex align-items-center">
        <h5 class="card-title mb-0 fw-bold">Roles &amp; Permissions</h5>
        <a href="{{ route('roles.create') }}" class="btn btn-primary btn-sm ms-auto">
            <i class="bi bi-plus-lg"></i> Add Role
        </a>
    </div>
    <div class="card-body table-responsive p-0">
        <table class="table table-striped table-hover mb-0 align-middle">
            <thead>
                <tr>
                    <th>Role</th>
                    <th>Slug</th>
                    <th class="text-center">Permissions</th>
                    <th class="text-center">Users</th>
                    <th class="text-end">Actions</th>
                </tr>
            </thead>
            <tbody>
            @forelse($roles as $role)
                <tr>
                    <td class="fw-semibold">
                        {{ $role->display_name }}
                        @if($role->is_system)
                            <span class="badge bg-secondary-subtle text-secondary border border-secondary-subtle ms-1">system</span>
                        @endif
                    </td>
                    <td><code>{{ $role->name }}</code></td>
                    <td class="text-center">
                        @if($role->name === \App\Models\Role::SUPER_ADMIN)
                            <span class="badge bg-success">All</span>
                        @else
                            {{ $role->permissions_count }}
                        @endif
                    </td>
                    <td class="text-center">{{ $role->users_count }}</td>
                    <td class="text-end" style="white-space:nowrap;">
                        <a href="{{ route('roles.edit', $role) }}" class="btn btn-outline-secondary btn-sm">Edit</a>
                        @unless($role->is_system)
                            <form action="{{ route('roles.destroy', $role) }}" method="POST" class="d-inline-block"
                                  onsubmit="return confirm('Delete this role?');">
                                @csrf @method('DELETE')
                                <button type="submit" class="btn btn-outline-danger btn-sm">Delete</button>
                            </form>
                        @endunless
                    </td>
                </tr>
            @empty
                <tr><td colspan="5" class="text-center py-4">No roles found.</td></tr>
            @endforelse
            </tbody>
        </table>
    </div>
</div>
@endsection
