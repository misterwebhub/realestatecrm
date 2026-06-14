@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">

    {{-- Header --}}
    <div class="card-header d-flex align-items-center flex-wrap gap-2">
        <h5 class="card-title mb-0 fw-bold">Kisans</h5>
        <div class="d-flex gap-2 ms-auto">
            @if(!empty($exportCsvUrl))
                <a href="{{ $exportCsvUrl }}" class="btn btn-outline-success btn-sm"><i class="bi bi-filetype-csv"></i> Export CSV</a>
            @endif
            @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                <a href="{{ $createUrl }}" class="btn btn-primary btn-sm"><i class="bi bi-plus-lg"></i> Add New</a>
            @endif
        </div>
    </div>

    {{-- Filters --}}
    <div class="card-body border-bottom py-2 px-3">
        <form method="GET" class="row g-2 align-items-end">
            <div class="col-md-5">
                <label class="form-label small fw-semibold mb-1">Name / Mobile / Reg. No</label>
                <input type="text" name="q" value="{{ $q }}"
                       class="form-control form-control-sm"
                       placeholder="Search name, mobile, reg no…">
            </div>
            <div class="col-md-4">
                <label class="form-label small fw-semibold mb-1">Arazi No</label>
                <input type="text" name="arazi_code" value="{{ $arazi_code }}"
                       class="form-control form-control-sm"
                       placeholder="e.g. 419, 375KA…">
            </div>
            <div class="col-auto d-flex gap-2">
                <button type="submit" class="btn btn-primary btn-sm">Search</button>
                <a href="{{ route('kisans.index') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
            </div>
        </form>
        @if($q || $arazi_code)
            <div class="mt-2 small text-muted">
                {{ $kisans->total() }} result(s)
                @if($q) for <strong>"{{ $q }}"</strong>@endif
                @if($arazi_code) · Arazi <strong>{{ $arazi_code }}</strong>@endif
            </div>
        @endif
    </div>

    {{-- Table --}}
    <div class="card-body table-responsive p-0">
        <table class="table table-striped table-hover mb-0 align-middle" style="font-size:13px;">
            <thead class="table-light">
                <tr>
                    @foreach($columns as $col)
                        <th>{{ $col }}</th>
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
                        <td class="text-end" style="white-space:nowrap;">
                            @if(!empty($row['add_url']))
                                <a href="{{ $row['add_url'] }}" target="_blank" class="btn btn-outline-primary btn-sm">Add Bond</a>
                            @endif
                            @foreach($row['action_buttons'] ?? [] as $btn)
                                <a href="{{ $btn['url'] }}" class="btn {{ $btn['class'] ?? 'btn-outline-secondary' }} btn-sm ms-1">{{ $btn['label'] }}</a>
                            @endforeach
                            @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                                <a href="{{ $row['edit_url'] }}" class="btn btn-outline-secondary btn-sm ms-1">Edit</a>
                                <form action="{{ $row['delete_url'] }}" method="POST" class="d-inline-block ms-1" onsubmit="return confirm('Delete this kisan?');">
                                    @csrf @method('DELETE')
                                    <button class="btn btn-outline-danger btn-sm">Delete</button>
                                </form>
                            @endif
                        </td>
                    </tr>
                @empty
                    <tr>
                        <td colspan="{{ count($columns) + 1 }}" class="text-center py-4 text-muted">
                            No kisans found.
                            @if($q || $arazi_code)
                                <a href="{{ route('kisans.index') }}">Clear filters</a>
                            @endif
                        </td>
                    </tr>
                @endforelse
            </tbody>
        </table>
    </div>

    {{-- Pagination --}}
    <div class="card-footer d-flex justify-content-between align-items-center">
        <div class="small text-muted">
            Showing {{ $kisans->firstItem() ?? 0 }}–{{ $kisans->lastItem() ?? 0 }} of {{ $kisans->total() }}
        </div>
        <div>{{ $kisans->links() }}</div>
    </div>

</div>
@endsection
