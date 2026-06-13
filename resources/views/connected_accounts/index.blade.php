@extends('layouts.app')

@section('content')
<style>
.ca-table th { background:#f8fafc; font-size:12px; font-weight:700; text-transform:uppercase; letter-spacing:.4px; color:#64748b; white-space:nowrap; }
.ca-table td { font-size:15px; vertical-align:middle; border-bottom:1px solid #f1f5f9; }
.ca-table tr:last-child td { border-bottom:none; }
.ca-table tr:hover td { background:#fafbff; }
</style>

<div class="card card-outline card-primary">
    <div class="card-header d-flex align-items-center justify-content-between">
        <h5 class="card-title mb-0 fw-bold">Connected Accounts <span class="text-muted fw-normal" style="font-size:13px;">— {{ $accounts->count() }} account(s)</span></h5>
        <a href="{{ route('connected-accounts.create') }}" class="btn btn-primary btn-sm">
            <i class="bi bi-plus-lg"></i> Add Account
        </a>
    </div>
    <div class="card-body p-0">
        <div class="table-responsive">
            <table class="table ca-table mb-0">
                <thead>
                    <tr>
                        <th class="ps-3 py-3">#</th>
                        <th>Name</th>
                        <th>Mobile</th>
                        <th>Address</th>
                        <th>Cheques</th>
                        <th>Notes</th>
                        <th class="text-end pe-3">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($accounts as $i => $account)
                    <tr>
                        <td class="ps-3 text-muted" style="font-size:12px;">{{ $i + 1 }}</td>
                        <td class="fw-semibold">{{ $account->name }}</td>
                        <td>
                            <a href="tel:{{ $account->mobile }}" class="text-decoration-none">
                                <i class="bi bi-telephone text-muted me-1" style="font-size:13px;"></i>{{ $account->mobile }}
                            </a>
                        </td>
                        <td class="text-muted">{{ $account->address ?: '—' }}</td>
                        <td>
                            <span class="badge bg-primary-subtle text-primary" style="font-size:12px;padding:4px 10px;">
                                {{ $account->cheques_count }} cheque(s)
                            </span>
                        </td>
                        <td class="text-muted" style="font-size:13px; max-width:160px; overflow:hidden; text-overflow:ellipsis; white-space:nowrap;">
                            {{ $account->notes ?: '' }}
                        </td>
                        <td class="text-end pe-3" style="white-space:nowrap;">
                            <a href="{{ route('connected-accounts.edit', $account) }}" class="btn btn-outline-secondary btn-sm">Edit</a>
                            <form action="{{ route('connected-accounts.destroy', $account) }}" method="POST" class="d-inline-block ms-1" onsubmit="return confirm('Delete this account?')">
                                @csrf @method('DELETE')
                                <button class="btn btn-outline-danger btn-sm">Delete</button>
                            </form>
                        </td>
                    </tr>
                    @empty
                    <tr>
                        <td colspan="7" class="text-center py-5 text-muted">
                            <div style="font-size:32px;">👤</div>
                            <div class="mt-2" style="font-size:15px;">No accounts yet.</div>
                            <a href="{{ route('connected-accounts.create') }}" class="btn btn-sm btn-primary mt-2">Add First Account</a>
                        </td>
                    </tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
@endsection
