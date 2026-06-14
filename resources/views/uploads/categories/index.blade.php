@extends('layouts.app')

@section('content')
<div class="container py-3">
    <div class="d-flex align-items-center gap-2 mb-3">
        <h4>Upload Categories</h4>
        <a href="{{ route('uploads.index') }}" class="btn btn-sm btn-secondary ms-auto">Back to Uploads</a>
    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <form action="{{ route('upload-categories.store') }}" method="post">
                        @csrf
                        <div class="mb-2">
                            <label class="form-label">Name</label>
                            <input type="text" name="name" class="form-control" required>
                        </div>
                        <div class="mb-2">
                            <label class="form-label">Description</label>
                            <textarea name="description" class="form-control" rows="3"></textarea>
                        </div>
                        <button class="btn btn-primary">Create Category</button>
                    </form>
                </div>
            </div>
        </div>

        <div class="col-md-8">
            <div class="card">
                <div class="card-body">
                    <table class="table table-sm">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Name</th>
                                <th>Description</th>
                                <th>Created</th>
                            </tr>
                        </thead>
                        <tbody>
                            @foreach($cats as $cat)
                                <tr>
                                    <td>{{ $cat->id }}</td>
                                    <td>{{ $cat->name }}</td>
                                    <td>{{ $cat->description }}</td>
                                    <td>{{ $cat->created_at->diffForHumans() }}</td>
                                </tr>
                            @endforeach
                        </tbody>
                    </table>

                    @if($cats->isEmpty())
                        <div class="text-muted">No categories yet.</div>
                    @endif
                </div>
            </div>
        </div>
    </div>
</div>
@endsection
