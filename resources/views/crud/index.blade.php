@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-header d-flex align-items-center justify-content-between flex-wrap gap-2">
            <h5 class="card-title mb-0">{{ $title }}</h5>
            @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                <div class="d-flex flex-wrap gap-2 align-items-center">
                    @if(isset($exportCsvUrl) && $exportCsvUrl)
                        <a href="{{ $exportCsvUrl }}" class="btn btn-outline-success btn-sm">
                            <i class="bi bi-filetype-csv"></i> Export CSV
                        </a>
                    @endif
                    @php $isCustomerBondIndex = str_contains($title, 'Customer Bond'); @endphp
                    <a href="{{ $createUrl }}" @if($isCustomerBondIndex) target="_blank" rel="noopener" @endif class="btn btn-primary btn-sm">
                        <i class="bi bi-plus-lg"></i> Add New
                    </a>
                </div>
            @endif
        </div>

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
                            @if(!empty($row['add_url']))
                                <a href="{{ $row['add_url'] }}" @if(!empty($row['open_in_new_tab'])) target="_blank" rel="noopener" @endif class="btn btn-outline-primary btn-sm ms-1">Add Bond</a>
                            @endif
                            @foreach($row['action_buttons'] ?? [] as $button)
                                <a href="{{ $button['url'] }}" class="btn {{ $button['class'] ?? 'btn-outline-primary' }} btn-sm ms-1">
                                    {{ $button['label'] }}
                                </a>
                            @endforeach
                            @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                                <a href="{{ $row['edit_url'] }}" @if(!empty($row['open_in_new_tab'])) target="_blank" rel="noopener" @endif class="btn btn-outline-secondary btn-sm">Edit</a>
                                <form action="{{ $row['delete_url'] }}" method="POST" class="d-inline-block" onsubmit="return confirm('Delete this record?');">
                                    @csrf
                                    @method('DELETE')
                                    <button type="submit" class="btn btn-outline-danger btn-sm">Delete</button>
                                </form>
                            @endif
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
