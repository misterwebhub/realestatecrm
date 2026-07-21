@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">
    <div class="card-header">
        <h3 class="card-title mb-0"><i class="bi bi-database-check me-1"></i> Database Log</h3>
    </div>
    <div class="card-body">
        <form method="GET" class="row g-2 mb-3">
            <div class="col-md-3">
                <label class="form-label mb-1">User</label>
                <select name="user_id" class="form-select">
                    <option value="">All Users</option>
                    @foreach($users as $id => $name)
                        <option value="{{ $id }}" @selected((string)$userId === (string)$id)>{{ $name }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-3">
                <label class="form-label mb-1">Table / Model</label>
                <select name="model" class="form-select">
                    <option value="">All</option>
                    @foreach($models as $val => $label)
                        <option value="{{ $val }}" @selected($model === $val)>{{ $label }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-2">
                <label class="form-label mb-1">Action</label>
                <select name="action" class="form-select">
                    <option value="">All</option>
                    @foreach(['created','updated','deleted'] as $a)
                        <option value="{{ $a }}" @selected($action === $a)>{{ ucfirst($a) }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-2">
                <label class="form-label mb-1">Search</label>
                <input type="text" name="q" value="{{ $q }}" class="form-control" placeholder="Field, value, id">
            </div>
            <div class="col-md-2 d-flex align-items-end gap-2">
                <button type="submit" class="btn btn-primary">Filter</button>
                <a href="{{ route('audit-logs.index') }}" class="btn btn-outline-secondary">Reset</a>
            </div>
        </form>

        <div class="table-responsive">
            <table class="table table-hover table-sm align-middle">
                <thead>
                    <tr>
                        <th>When</th>
                        <th>User</th>
                        <th>Table</th>
                        <th>Record</th>
                        <th>Action</th>
                        <th>Changes</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($logs as $log)
                        @php($meta = $log->meta ?? [])
                        <tr>
                            <td class="text-nowrap">{{ optional($log->created_at)->format('d-m-Y H:i:s') }}</td>
                            <td>{{ $log->user?->name ?? ($meta['user_name'] ?? ($log->user_id ? '#' . $log->user_id : 'System')) }}</td>
                            <td>{{ $meta['table'] ?? class_basename($log->auditable_type) }}</td>
                            <td>#{{ $log->auditable_id }}</td>
                            <td>
                                @php($ac = ['created' => 'success', 'updated' => 'info', 'deleted' => 'danger'][$log->action] ?? 'secondary')
                                <span class="badge bg-{{ $ac }}">{{ ucfirst($log->action) }}</span>
                            </td>
                            <td>
                                @php($old = $meta['old'] ?? [])
                                @php($new = $meta['new'] ?? [])
                                @if($log->action === 'updated' && !empty($new))
                                    <table class="table table-sm mb-0 small">
                                        @foreach($new as $field => $val)
                                            <tr>
                                                <td class="fw-semibold text-nowrap">{{ $field }}</td>
                                                <td class="text-muted">{{ Illuminate\Support\Str::limit((string)($old[$field] ?? ''), 60) }}</td>
                                                <td>&rarr;</td>
                                                <td>{{ Illuminate\Support\Str::limit((string)$val, 60) }}</td>
                                            </tr>
                                        @endforeach
                                    </table>
                                @elseif($log->action === 'created' && !empty($new))
                                    <span class="text-muted small">{{ count($new) }} field(s) set</span>
                                @elseif($log->action === 'deleted')
                                    <span class="text-muted small">Record removed</span>
                                @else
                                    -
                                @endif
                            </td>
                        </tr>
                    @empty
                        <tr><td colspan="6" class="text-center text-muted py-4">No database changes logged yet.</td></tr>
                    @endforelse
                </tbody>
            </table>
        </div>

        {{ $logs->links() }}
    </div>
</div>
@endsection
