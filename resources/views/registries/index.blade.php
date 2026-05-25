@extends('layouts.app')

@section('content')
    <div class="d-flex align-items-center justify-content-between mb-3">
        <h4 class="mb-0">Plot Registry</h4>
        <div>
            <a href="{{ $createUrl }}" class="btn btn-primary btn-sm"><i class="bi bi-plus-lg"></i> Add New Registry</a>
        </div>
    </div>

    <div class="card mb-3">
        <div class="card-body">
            <form method="GET" class="row g-2">
                <div class="col-md-3">
                    <input name="arazi_number" value="{{ $filters['arazi_number'] ?? '' }}" placeholder="Arazi number" class="form-control">
                </div>
                <div class="col-md-3">
                    <input name="customer_name" value="{{ $filters['customer_name'] ?? '' }}" placeholder="Customer name" class="form-control">
                </div>
                <div class="col-md-2">
                    <input name="broker_name" value="{{ $filters['broker_name'] ?? '' }}" placeholder="Broker name" class="form-control">
                </div>
                <div class="col-md-2">
                    <input name="plot_number" value="{{ $filters['plot_number'] ?? '' }}" placeholder="Plot number/title" class="form-control">
                </div>
                <div class="col-md-3 d-flex gap-2">
                    <button class="btn btn-outline-primary">Search</button>
                    <a href="{{ route('registries.index') }}" class="btn btn-outline-secondary">Reset</a>
                </div>
            </form>
        </div>
    </div>

    <div class="card">
        <div class="card-body table-responsive p-0">
            <table class="table table-striped table-hover mb-0 align-middle">
                <thead>
                <tr>
                    @foreach($columns as $column)
                        <th>{{ $column }}</th>
                    @endforeach
                    <th class="text-end">Actions</th>
                </tr>
                </thead>
                <tbody>
                @forelse($rows as $row)
                    <tr>
                        @foreach($row['cells'] as $cell)
                            <td>{{ $cell }}</td>
                        @endforeach
                        <td class="text-end">
                            @if(!empty($row['print_url']))
                                <a href="{{ $row['print_url'] }}?print=1" target="_blank" class="btn btn-outline-success btn-sm">Print</a>
                            @endif
                            @if(!empty($row['pdf_url']))
                                <a href="{{ $row['pdf_url'] }}" target="_blank" class="btn btn-outline-secondary btn-sm ms-1">PDF</a>
                            @endif
                            <a href="{{ $row['edit_url'] }}" class="btn btn-outline-secondary btn-sm ms-1">Edit</a>
                            <form action="{{ $row['delete_url'] }}" method="POST" class="d-inline-block ms-1" onsubmit="return confirm('Delete this registry?');">
                                @csrf
                                @method('DELETE')
                                <button class="btn btn-outline-danger btn-sm">Delete</button>
                            </form>
                        </td>
                    </tr>
                @empty
                    <tr>
                        <td colspan="{{ count($columns) + 1 }}" class="text-center py-4">No records found.</td>
                    </tr>
                @endforelse
                </tbody>
            </table>
        </div>
    </div>

@endsection
