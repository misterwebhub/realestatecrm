@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3">
        <h4 class="mb-0">{{ $title }}</h4>
        <a href="{{ route('arazi-groups.create') }}" class="btn btn-primary btn-sm ms-auto">
            <i class="bi bi-plus-lg"></i> Create Group
        </a>
    </div>

    <div class="card shadow-sm">
        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead class="table-light">
                    <tr>
                        <th style="width:60px;">#</th>
                        <th>Map Name</th>
                        <th>Group Name</th>
                        <th>Merged Arazis</th>
                        <th style="width:90px;" class="text-center">Count</th>
                        <th>Notes</th>
                        <th>Created By</th>
                        <th>Created</th>
                        <th style="width:90px;" class="text-end">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($groups as $group)
                        <tr>
                            <td>{{ $group->id }}</td>
                            <td><span class="badge bg-primary-subtle text-primary-emphasis">{{ $group->map_name }}</span></td>
                            <td>{{ $group->name ?: '—' }}</td>
                            <td>
                                @forelse($group->arazis as $arazi)
                                    <span class="badge bg-secondary-subtle text-secondary-emphasis me-1 mb-1">
                                        {{ $arazi->legacy_arazi_code ?: ('#'.$arazi->id) }}
                                    </span>
                                @empty
                                    <span class="text-muted">—</span>
                                @endforelse
                            </td>
                            <td class="text-center">{{ $group->items_count }}</td>
                            <td>{{ $group->notes ?: '—' }}</td>
                            <td>{{ optional($group->creator)->name ?? '—' }}</td>
                            <td>{{ optional($group->created_at)->format('d M Y H:i') }}</td>
                            <td class="text-end">
                                <form action="{{ route('arazi-groups.destroy', $group->id) }}" method="POST"
                                      onsubmit="return confirm('Delete this arazi group?');" class="d-inline">
                                    @csrf
                                    @method('DELETE')
                                    <button type="submit" class="btn btn-outline-danger btn-sm">
                                        <i class="bi bi-trash"></i> Delete
                                    </button>
                                </form>
                            </td>
                        </tr>
                    @empty
                        <tr>
                            <td colspan="9" class="text-center text-muted py-4">
                                No arazi groups yet. Click <strong>Create Group</strong> to add one.
                            </td>
                        </tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
</div>
@endsection
