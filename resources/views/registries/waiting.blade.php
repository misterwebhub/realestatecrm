@extends('layouts.app')

@section('content')
    <div class="card card-outline card-warning">
        <div class="card-header d-flex align-items-center justify-content-between">
            <h5 class="card-title mb-0">Pending Customer Payments</h5>
            <a href="{{ route('registries.index') }}" class="btn btn-outline-secondary btn-sm">Back to Registries</a>
        </div>

        <div class="card-body table-responsive p-0">
            <table class="table table-striped table-hover mb-0 align-middle">
                <thead>
                <tr>
                    <th>Registry</th>
                    <th>Customer</th>
                    <th>Arazi</th>
                    <th>Due Date</th>
                    <th>Days Left</th>
                    <th>Broker</th>
                    <th>Status</th>
                </tr>
                </thead>
                <tbody>
                @forelse($records as $registry)
                    @php($daysLeft = now()->startOfDay()->diffInDays($registry->due_date, false))
                    <tr>
                        <td>{{ $registry->registry_code ?? ('REG-' . $registry->id) }}</td>
                        <td>{{ $registry->customer?->name ?? '-' }}</td>
                        <td>{{ $registry->arazi?->plot_number ?? '-' }}</td>
                        <td>{{ optional($registry->due_date)->format('d-m-Y') ?? '-' }}</td>
                        <td>
                            @if($daysLeft < 0)
                                <span class="badge text-bg-danger">Overdue {{ abs($daysLeft) }} day(s)</span>
                            @elseif($daysLeft <= 3)
                                <span class="badge text-bg-warning">{{ $daysLeft }} day(s)</span>
                            @else
                                <span class="badge text-bg-info">{{ $daysLeft }} day(s)</span>
                            @endif
                        </td>
                        <td>{{ $registry->agent?->name ?? '-' }}</td>
                        <td>
                            <span class="badge text-bg-secondary">{{ ucfirst($registry->status) }}</span>
                        </td>
                    </tr>
                @empty
                    <tr>
                        <td colspan="7" class="text-center py-4">No pending payments found.</td>
                    </tr>
                @endforelse
                </tbody>
            </table>
        </div>
    </div>
@endsection
