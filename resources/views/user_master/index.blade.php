@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">
    <div class="card-header d-flex align-items-center gap-2">
        <h5 class="card-title mb-0 fw-bold">User Master <span class="text-muted fw-normal" style="font-size:13px;">— {{ $users->count() }} user(s)</span></h5>
        <a href="{{ route('user-master.report') }}" class="btn btn-outline-primary btn-sm ms-auto">
            <i class="bi bi-bar-chart-line"></i> User Report
        </a>
        <a href="{{ route('user-master.create') }}" class="btn btn-primary btn-sm">
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
                        @if(auth()->user()?->isSuperAdmin())
                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;">Password</th>
                        @endif
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
                        @if(auth()->user()?->isSuperAdmin())
                        <td>
                            <span class="password-mask font-monospace" data-user-id="{{ $user->id }}" data-revealed="0">••••••••</span>
                            <button type="button" class="btn btn-link btn-sm p-0 ms-1 toggle-password" data-user-id="{{ $user->id }}" data-url="{{ route('user-master.password', $user) }}" title="Show password">
                                <i class="bi bi-eye"></i>
                            </button>
                        </td>
                        @endif
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
                            @if(auth()->user()?->isSuperAdmin())
                            <button type="button" class="btn btn-outline-warning btn-sm ms-1 reset-password-btn"
                                data-user-name="{{ $user->name }}"
                                data-url="{{ route('user-master.reset-password', $user) }}"
                                title="Reset Password">
                                <i class="bi bi-key"></i> Reset Password
                            </button>
                            @endif
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
                        <td colspan="{{ auth()->user()?->isSuperAdmin() ? 10 : 9 }}" class="text-center py-5 text-muted">
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

@if(auth()->user()?->isSuperAdmin())
{{-- Reset Password modal (shared, populated per-user via JS) --}}
<div class="modal fade" id="resetPasswordModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <form method="POST" id="resetPasswordForm" autocomplete="off">
            @csrf
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Reset Password — <span id="resetPasswordUserName"></span></h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label class="form-label fw-semibold">New Password <span class="text-danger">*</span></label>
                        <input type="password" name="password" class="form-control" placeholder="New password (min 6 chars)" required minlength="6" autocomplete="new-password">
                    </div>
                    <div class="mb-3">
                        <label class="form-label fw-semibold">Confirm Password <span class="text-danger">*</span></label>
                        <input type="password" name="password_confirmation" class="form-control" placeholder="Repeat new password" required minlength="6" autocomplete="new-password">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">Cancel</button>
                    <button type="submit" class="btn btn-warning">Reset Password</button>
                </div>
            </div>
        </form>
    </div>
</div>
<script>
document.addEventListener('click', function (event) {
    const resetBtn = event.target.closest('.reset-password-btn');
    if (resetBtn) {
        const form = document.getElementById('resetPasswordForm');
        form.action = resetBtn.dataset.url;
        form.reset();
        document.getElementById('resetPasswordUserName').textContent = resetBtn.dataset.userName;
        var modalEl = document.getElementById('resetPasswordModal');
        var modal = bootstrap.Modal.getOrCreateInstance(modalEl);
        modal.show();
        return;
    }
});
</script>
<script>
document.addEventListener('click', function (event) {
    const btn = event.target.closest('.toggle-password');
    if (!btn) return;

    const userId = btn.dataset.userId;
    const mask = document.querySelector('.password-mask[data-user-id="' + userId + '"]');
    const icon = btn.querySelector('i');
    if (!mask) return;

    // Already revealed → just re-mask, no need to hit the server again.
    if (mask.dataset.revealed === '1') {
        mask.textContent = '••••••••';
        mask.dataset.revealed = '0';
        if (icon) { icon.classList.remove('bi-eye-slash'); icon.classList.add('bi-eye'); }
        btn.title = 'Show password';
        return;
    }

    btn.disabled = true;
    fetch(btn.dataset.url, { headers: { 'Accept': 'application/json' } })
        .then(function (res) { return res.json(); })
        .then(function (data) {
            if (data.available) {
                mask.textContent = data.password;
                mask.dataset.revealed = '1';
                if (icon) { icon.classList.remove('bi-eye'); icon.classList.add('bi-eye-slash'); }
                btn.title = 'Hide password';
            } else {
                mask.textContent = data.message || 'Not available';
            }
        })
        .catch(function () {
            mask.textContent = 'Error loading password';
        })
        .finally(function () {
            btn.disabled = false;
        });
});
</script>
@endif
@endsection
