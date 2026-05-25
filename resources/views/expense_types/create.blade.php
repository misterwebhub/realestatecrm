@extends('layouts.app')

@section('content')
<div class="container py-3">
    <div class="d-flex justify-content-between align-items-center mb-3">
        <h4 class="mb-0">Add Expense Type</h4>
        <a href="{{ url()->previous() }}" class="btn btn-sm btn-outline-secondary">Back</a>
    </div>

    <div class="card">
        <div class="card-body">
            <form action="{{ route('expense-types.store') }}" method="post">
                @csrf
                <div class="mb-3">
                    <label class="form-label">Name</label>
                    <input type="text" name="name" class="form-control" value="{{ old('name') }}" required>
                    @error('name') <div class="text-danger small">{{ $message }}</div> @enderror
                </div>

                <div class="d-flex gap-2">
                    <button class="btn btn-primary">Create</button>
                    <a href="{{ route('expenses.create') }}" class="btn btn-outline-secondary">Create Expense</a>
                </div>
            </form>
        </div>
    </div>
</div>
@endsection
