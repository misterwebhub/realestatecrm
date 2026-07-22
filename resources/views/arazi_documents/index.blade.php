@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-header d-flex align-items-center gap-2">
            <h5 class="card-title mb-0 fw-bold">{{ $title }}</h5>
            @can('arazis.create')
                <a href="{{ $createUrl }}" class="btn btn-primary btn-sm ms-auto">
                    <i class="bi bi-plus-lg"></i> Add Arazi Registry
                </a>
            @endcan
        </div>

        <div class="card-body border-bottom">
            <form method="GET" action="{{ route('arazi-documents.index') }}" class="row g-3 align-items-end">
                <div class="col-md-4">
                    <label for="arazi_number" class="form-label">Search by Arazi Number</label>
                    <input
                        type="text"
                        id="arazi_number"
                        name="arazi_number"
                        class="form-control"
                        value="{{ $filters['arazi_number'] ?? '' }}"
                        placeholder="Arazi number"
                    >
                </div>
                <div class="col-md-4">
                    <label for="kisan_id" class="form-label">Filter by Kisan</label>
                    <select id="kisan_id" name="kisan_id" class="form-select">
                        <option value="">All Kisans</option>
                        @foreach($kisans as $id => $name)
                            <option value="{{ $id }}" @selected((string) ($filters['kisan_id'] ?? '') === (string) $id)>{{ $name }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-4 d-flex gap-2">
                    <button type="submit" class="btn btn-outline-primary">
                        <i class="bi bi-search"></i> Search
                    </button>
                    <a href="{{ route('arazi-documents.index') }}" class="btn btn-outline-secondary">Reset</a>
                </div>
            </form>
        </div>

        <div class="card-body table-responsive p-0">
            <table class="table table-striped table-hover mb-0 align-middle">
                <thead>
                    <tr>
                        <th>Arazi Number</th>
                        <th>Kisan</th>
                        <th>Document Name</th>
                        <th>File</th>
                        <th>Type</th>
                        <th>Size KB</th>
                        <th>Uploaded At</th>
                        <th class="text-end">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($documents as $document)
                        <tr>
                            <td>{{ $document->arazi?->legacy_arazi_code ?: ($document->arazi?->plot_number ?? '-') }}</td>
                            <td>{{ $document->arazi?->kisan?->name ?? '-' }}</td>
                            <td>{{ $document->document_name }}</td>
                            <td>{{ basename($document->file_path) }}</td>
                            <td>{{ $document->mime_type ?? '-' }}</td>
                            <td>{{ $document->file_size ? number_format($document->file_size / 1024, 2) : '-' }}</td>
                            <td>{{ optional($document->uploaded_at)->format('d-m-Y h:i A') ?? '-' }}</td>
                            <td class="text-end" style="white-space:nowrap;">
                                <a href="{{ route('arazi-documents.download', $document) }}" class="btn btn-outline-success btn-sm">Download</a>
                                @can('arazis.edit')
                                    <a href="{{ route('arazi-documents.edit', $document) }}" class="btn btn-outline-secondary btn-sm">Edit</a>
                                @endcan
                                @can('arazis.delete')
                                    <form action="{{ route('arazi-documents.destroy', $document) }}" method="POST" class="d-inline-block" onsubmit="return confirm('Delete this registry document?');">
                                        @csrf
                                        @method('DELETE')
                                        <button type="submit" class="btn btn-outline-danger btn-sm">Delete</button>
                                    </form>
                                @endcan
                            </td>
                        </tr>
                    @empty
                        <tr>
                            <td colspan="8" class="text-center py-4">No Arazi registry uploads found.</td>
                        </tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
@endsection
