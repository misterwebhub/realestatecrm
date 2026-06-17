@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">
    <div class="card-header d-flex align-items-center gap-2">
        <h5 class="card-title mb-0 fw-bold">User Master <span class="text-muted fw-normal" style="font-size:13px;">— {{ $users->count() }} user(s)</span></h5>
        <a href="{{ route('user-master.create') }}" class="btn btn-primary btn-sm ms-auto">
            <i class="bi bi-plus-lg"></i> Add User
        </a>
    </div>
    <div class="card-body p-0">
        <div class="table-responsive">
            <table class="table table-hover mb-0 align-middle">
                <thead style="background:#f8fafc;">
                    <tr>
                        <th class="ps-3" style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;">#</th>
                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;">Name</th>
                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;">Username</th>
                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;">Mobile</th>
                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;">Email</th>
                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;">Role</th>
                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;">Status</th>
                        <th class="text-center" style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;">Receipts</th>
                        <th class="text-end pe-3" style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($users as $i => $user)
                    <tr>
                        <td class="ps-3 text-muted" style="font-size:12px;">{{ $i + 1 }}</td>
                        <td>
                            <div class="fw-semibold">{{ $user->name }}</div>
                            @if($user->address)
                                <div class="text-muted" style="font-size:12px;">{{ $user->address }}</div>
                            @endif
                        </td>
                        <td class="fw-semibold">{{ $user->username ?? '—' }}</td>
                        <td>
                            <div>{{ $user->mobile ?? '—' }}</div>
                            @if($user->secondary_mobile)
                                <div class="text-muted" style="font-size:12px;">{{ $user->secondary_mobile }}</div>
                            @endif
                        </td>
                        <td class="text-muted">{{ $user->email ?? '—' }}</td>
                        <td>
                            <span class="badge {{ $user->role === 'admin' ? 'bg-danger' : ($user->role === 'manager' ? 'bg-warning text-dark' : ($user->role === 'accountant' ? 'bg-info text-dark' : 'bg-secondary')) }}">
                                {{ ucfirst($user->role ?? 'staff') }}
                            </span>
                        </td>
                        <td>
                            @if($user->is_active)
                                <span class="badge bg-success-subtle text-success border border-success-subtle">Active</span>
                            @else
                                <span class="badge bg-secondary-subtle text-secondary border border-secondary-subtle">Inactive</span>
                            @endif
                        </td>
                        <td class="text-center">
                            <a href="{{ route('user-master.receipts', $user) }}" class="text-decoration-none">
                                <span class="badge bg-info-subtle text-info border border-info-subtle" style="font-size:12px;">
                                    {{ $user->receipt_count ?? 0 }}
                                </span>
                            </a>
                        </td>
                        <td class="text-end pe-3" style="white-space:nowrap;">
                            <a href="{{ route('user-master.receipts', $user) }}" class="btn btn-outline-info btn-sm me-1" title="Receipt Dashboard">
                                <i class="bi bi-receipt"></i> View All Receipts
                            </a>
                            <a href="{{ route('user-master.edit', $user) }}" class="btn btn-outline-secondary btn-sm">Edit</a>
                            @if($user->id !== auth()->id())
                            <form action="{{ route('user-master.destroy', $user) }}" method="POST" class="d-inline-block ms-1" onsubmit="return confirm('Delete this user?')">
                                @csrf @method('DELETE')
                                <button class="btn btn-outline-danger btn-sm">Delete</button>
                            </form>
                            @endif
                        </td>
                    </tr>
                    @empty
                    <tr>
                        <td colspan="9" class="text-center py-5 text-muted">
                            <div style="font-size:32px;">👤</div>
                            <div class="mt-2">No users yet.</div>
                            <a href="{{ route('user-master.create') }}" class="btn btn-sm btn-primary mt-2">Add First User</a>
                        </td>
                    </tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
</div>
@endsection
