@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary mb-3">
        <div class="card-header d-flex align-items-center justify-content-between">
            <h5 class="card-title mb-0 fw-bold">Expenses</h5>
            <a href="{{ route('expenses.create') }}" class="btn btn-primary btn-sm"><i class="bi bi-plus-lg"></i> New Expense</a>
        </div>
        <div class="card-body border-bottom py-2 px-3">
            <input id="expenses-search" type="search" class="form-control form-control-sm" placeholder="Search expenses (label, arazi, type)..." style="max-width:320px;">
        </div>

        <div class="card-body p-0">
            <div class="table-responsive">
                <table class="table table-hover table-striped mb-0 align-middle">
                    <thead class="table-light small text-muted">
                        <tr>
                            <th style="width:60px">#</th>
                            <th style="width:140px">Type</th>
                            <th>Arazi</th>
                            <th>Label</th>
                            <th class="text-end" style="width:140px">Amount</th>
                            <th style="width:120px">Incurred</th>
                            <th style="width:180px">By</th>
                        </tr>
                    </thead>
                    <tbody id="expenses-table-body">
                        @forelse($expenses as $e)
                        <tr>
                            <td class="fw-semibold">{{ $e->id }}</td>
                            <td>
                                @if($e->type === 'arazi')
                                    <span class="badge bg-info text-dark">Arazi</span>
                                @else
                                    <span class="badge bg-secondary">Personal</span>
                                @endif
                                @if(!empty($e->expense_type_id) && $e->expenseType?->name)
                                    <div class="small text-muted mt-1">{{ $e->expenseType?->name }}</div>
                                @endif
                            </td>
                            <td>{{ $e->arazi?->legacy_arazi_code ?? '-' }}</td>
                            <td>{{ $e->label ?? '-' }}</td>
                            <td class="text-end">{{ number_format($e->amount,2) }}</td>
                            <td>{{ $e->incurred_at?->format('Y-m-d') ?? '-' }}</td>
                            <td>{{ $e->creator?->name ?? ($e->created_by ? 'User #'.$e->created_by : '-') }}</td>
                        </tr>
                        @empty
                        <tr>
                            <td colspan="7" class="text-center py-4 text-muted">No expenses recorded yet.</td>
                        </tr>
                        @endforelse
                    </tbody>
                </table>
            </div>
        </div>

        <div class="card-footer d-flex justify-content-between align-items-center">
            <div class="small text-muted">Showing {{ $expenses->firstItem() ?? 0 }} - {{ $expenses->lastItem() ?? 0 }} of {{ $expenses->total() }} expenses</div>
            <div>{{ $expenses->links() }}</div>
        </div>
    </div>

@push('scripts')
<script>
document.addEventListener('DOMContentLoaded', function(){
    var input = document.getElementById('expenses-search');
    if(!input) return;
    var tbody = document.getElementById('expenses-table-body');
    var rows = Array.from(tbody.querySelectorAll('tr'));
    function filter(){
        var q = input.value.trim().toLowerCase();
        if(q === ''){ rows.forEach(r=> r.style.display=''); return; }
        rows.forEach(function(r){
            r.style.display = r.textContent.toLowerCase().indexOf(q) !== -1 ? '' : 'none';
        });
    }
    var timer = null;
    input.addEventListener('input', function(){ clearTimeout(timer); timer = setTimeout(filter, 200); });
});
</script>
@endpush

@endsection

