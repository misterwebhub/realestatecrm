@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">
    <div class="card-header">
        <h3 class="card-title mb-0"><i class="bi bi-activity me-1"></i> Activity Logs</h3>
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
                <label class="form-label mb-1">Module</label>
                <select name="module" class="form-select">
                    <option value="">All Modules</option>
                    @foreach($modules as $m)
                        <option value="{{ $m }}" @selected($module === $m)>{{ $m }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-2">
                <label class="form-label mb-1">Method</label>
                <select name="method" class="form-select">
                    <option value="">All</option>
                    @foreach(['GET','POST','PUT','PATCH','DELETE'] as $mth)
                        <option value="{{ $mth }}" @selected($method === $mth)>{{ $mth }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-2">
                <label class="form-label mb-1">Search</label>
                <input type="text" name="q" value="{{ $q }}" class="form-control" placeholder="URL, route, user, IP">
            </div>
            <div class="col-md-2 d-flex align-items-end gap-2">
                <button type="submit" class="btn btn-primary">Filter</button>
                <a href="{{ route('activity-logs.index') }}" class="btn btn-outline-secondary">Reset</a>
            </div>
        </form>

        <div class="table-responsive">
            <table class="table table-hover table-sm align-middle">
                <thead>
                    <tr>
                        <th>When</th>
                        <th>User</th>
                        <th>Module</th>
                        <th>Method</th>
                        <th>URL</th>
                        <th>Route</th>
                        <th>Status</th>
                        <th>IP</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($logs as $log)
                        <tr>
                            <td class="text-nowrap">{{ optional($log->created_at)->format('d-m-Y H:i:s') }}</td>
                            <td>{{ $log->user_name ?: ($log->user_id ? '#' . $log->user_id : 'Guest') }}</td>
                            <td>{{ $log->module ?: '-' }}</td>
                            <td>
                                @php($mc = ['GET' => 'secondary', 'POST' => 'success', 'PUT' => 'info', 'PATCH' => 'info', 'DELETE' => 'danger'][$log->method] ?? 'secondary')
                                <span class="badge bg-{{ $mc }}">{{ $log->method }}</span>
                            </td>
                            <td class="text-truncate" style="max-width: 340px;" title="{{ $log->url }}">{{ $log->url }}</td>
                            <td>{{ $log->route_name ?: '-' }}</td>
                            <td>
                                @php($sc = $log->status_code)
                                @php($scc = $sc >= 500 ? 'danger' : ($sc >= 400 ? 'warning' : ($sc >= 300 ? 'info' : 'success')))
                                <span class="badge bg-{{ $scc }}">{{ $sc ?: '-' }}</span>
                            </td>
                            <td>{{ $log->ip ?: '-' }}</td>
                        </tr>
                    @empty
                        <tr><td colspan="8" class="text-center text-muted py-4">No activity logged yet.</td></tr>
                    @endforelse
                </tbody>
            </table>
        </div>

        {{ $logs->links() }}
    </div>
</div>
@endsection
