@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-header d-flex align-items-center gap-2">
            <h5 class="card-title mb-0 fw-bold">{{ $title }}</h5>
            @can($permModule.'.create')
                <button type="button" class="btn btn-primary btn-sm ms-auto" data-bs-toggle="modal" data-bs-target="#addBrokerModal">
                    <i class="bi bi-plus-lg"></i> Add {{ $typeLabel }} Broker
                </button>
            @endcan
        </div>

        <div class="card-body table-responsive p-0">
            <table class="table table-striped table-hover mb-0 align-middle">
                <thead>
                    <tr>
                        <th>Form Code</th>
                        <th>Name</th>
                        <th>Mobile</th>
                        <th>Rank</th>
                        <th>Sponsor</th>
                        <th>Commission %</th>
                        <th>Legacy %</th>
                        <th>Registries</th>
                        <th class="text-end">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($brokers as $broker)
                        <tr>
                            <td>{{ $broker->form_code ?? '-' }}</td>
                            <td>{{ $broker->name }}</td>
                            <td>{{ $broker->mobile }}</td>
                            <td>{{ $broker->rank_title ?? '-' }}</td>
                            <td>{{ $broker->sponsor?->name ?? '-' }}</td>
                            <td>{{ number_format((float) $broker->commission_percentage, 2) }}</td>
                            <td>{{ $broker->legacy_percent !== null ? number_format((float) $broker->legacy_percent, 2) : '-' }}</td>
                            <td>{{ $broker->registries_count }}</td>
                            <td class="text-end">
                                @can($permModule.'.edit')
                                    <a href="{{ route('agents.edit', $broker) }}" class="btn btn-outline-secondary btn-sm">Edit</a>
                                @endcan
                                @can($permModule.'.delete')
                                    <form action="{{ route('agents.destroy', $broker) }}" method="POST" class="d-inline-block" onsubmit="return confirm('Delete this broker?');">
                                        @csrf
                                        @method('DELETE')
                                        <button type="submit" class="btn btn-outline-danger btn-sm">Delete</button>
                                    </form>
                                @endcan
                            </td>
                        </tr>
                    @empty
                        <tr>
                            <td colspan="9" class="text-center py-4">No {{ strtolower($typeLabel) }} brokers found.</td>
                        </tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>

    <div class="modal fade" id="addBrokerModal" tabindex="-1" aria-labelledby="addBrokerModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <form method="POST" action="{{ route('agents.type.store', $type) }}">
                    @csrf
                    <div class="modal-header">
                        <h5 class="modal-title" id="addBrokerModalLabel">Add {{ $typeLabel }} Broker</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="row g-3">
                            <div class="col-md-4">
                                <label for="form_code" class="form-label">Broker Form Code</label>
                                <input type="text" name="form_code" id="form_code" class="form-control" value="{{ old('form_code', $nextFormCode) }}" readonly>
                            </div>
                            <div class="col-md-4">
                                <label for="name" class="form-label">Name</label>
                                <input type="text" name="name" id="name" class="form-control" value="{{ old('name') }}" required>
                            </div>
                            <div class="col-md-4">
                                <label for="mobile" class="form-label">Mobile</label>
                                <input type="text" name="mobile" id="mobile" class="form-control" value="{{ old('mobile') }}" required>
                            </div>
                            <div class="col-md-4">
                                <label for="rank_title" class="form-label">Rank/Level</label>
                                <input type="text" name="rank_title" id="rank_title" class="form-control" value="{{ old('rank_title') }}">
                            </div>
                            <div class="col-md-4">
                                <label for="sponsor_agent_id" class="form-label">Sponsor Broker</label>
                                <select name="sponsor_agent_id" id="sponsor_agent_id" class="form-select">
                                    <option value="">Select Sponsor</option>
                                    @foreach($sponsors as $id => $name)
                                        <option value="{{ $id }}" @selected((string) old('sponsor_agent_id') === (string) $id)>{{ $name }}</option>
                                    @endforeach
                                </select>
                            </div>
                            <div class="col-md-4">
                                <label for="commission_percentage" class="form-label">Commission Percentage</label>
                                <input type="number" step="0.01" name="commission_percentage" id="commission_percentage" class="form-control" value="{{ old('commission_percentage', 0) }}" required>
                            </div>
                            <div class="col-md-4">
                                <label for="legacy_percent" class="form-label">Legacy Percent</label>
                                <input type="number" step="0.01" name="legacy_percent" id="legacy_percent" class="form-control" value="{{ old('legacy_percent') }}">
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">Cancel</button>
                        <button type="submit" class="btn btn-primary">Save Broker</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
@endsection
