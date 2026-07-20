@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 gap-2 flex-wrap">
        <h5 class="fw-bold mb-0"><i class="bi bi-link-45deg me-2 text-success"></i>{{ $title }}</h5>
        <div class="ms-auto d-flex gap-2 flex-wrap">
            <a href="{{ route('customer-bond-cheques.manual') }}" class="btn btn-outline-primary btn-sm">Manual Entries</a>
            <a href="{{ route('customer-bond-cheques.index') }}" class="btn btn-secondary btn-sm">Back to Cheques</a>
        </div>
    </div>

    @if(session('success'))
        <div class="alert alert-success py-2">{{ session('success') }}</div>
    @endif
    @if($errors->any())
        <div class="alert alert-danger py-2">
            <ul class="mb-0">@foreach($errors->all() as $e)<li>{{ $e }}</li>@endforeach</ul>
        </div>
    @endif

    {{-- Filters --}}
    <div class="card border-0 shadow-sm mb-3">
        <div class="card-body p-3">
            <form method="GET" action="{{ route('customer-bond-cheques.assign') }}" class="row g-2 align-items-end">
                <div class="col-md-3">
                    <label class="form-label small mb-1">Cheque No</label>
                    <input type="text" name="cheque_number" value="{{ $filterNumber }}" class="form-control form-control-sm" placeholder="Cheque number">
                </div>
                <div class="col-md-3">
                    <label class="form-label small mb-1">Connected Account</label>
                    <select name="account_id" class="form-select form-select-sm">
                        <option value="">— All —</option>
                        @foreach($accounts as $acc)
                            <option value="{{ $acc->id }}" @selected((string)$filterAccount === (string)$acc->id)>{{ $acc->name }} / {{ $acc->mobile }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small mb-1">Status</label>
                    <select name="status" class="form-select form-select-sm">
                        <option value="">— All —</option>
                        @foreach(['pending','cleared','bounced','cancelled'] as $st)
                            <option value="{{ $st }}" @selected($filterStatus === $st)>{{ ucfirst($st) }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small mb-1">Assignment</label>
                    <select name="assignment" class="form-select form-select-sm">
                        <option value="">— All —</option>
                        <option value="assigned" @selected($filterAssign === 'assigned')>Assigned</option>
                        <option value="unassigned" @selected($filterAssign === 'unassigned')>Not Assigned</option>
                    </select>
                </div>
                <div class="col-md-2">
                    <label class="form-label small mb-1">From</label>
                    <input type="date" name="date_from" value="{{ $filterFrom }}" class="form-control form-control-sm">
                </div>
                <div class="col-md-2">
                    <label class="form-label small mb-1">To</label>
                    <input type="date" name="date_to" value="{{ $filterTo }}" class="form-control form-control-sm">
                </div>
                <div class="col-12">
                    <button type="submit" class="btn btn-primary btn-sm"><i class="bi bi-funnel me-1"></i>Filter</button>
                    <a href="{{ route('customer-bond-cheques.assign') }}" class="btn btn-outline-secondary btn-sm">Reset</a>
                </div>
            </form>
        </div>
    </div>

    {{-- Assign form --}}
    <form method="POST" action="{{ route('customer-bond-cheques.assign-store') }}">
        @csrf
        <div class="card border-0 shadow-sm">
            <div class="card-body p-3">
                <div class="row g-2 align-items-end mb-3">
                    <div class="col-md-6">
                        <label class="form-label small fw-semibold mb-1">Assign selected cheque(s) to bond <span class="text-danger">*</span></label>
                        <select name="customer_bond_id" required class="form-select form-select-sm bond-select">
                            <option value="">— Select bond —</option>
                            @foreach($bonds as $b)
                                <option value="{{ $b['id'] }}">{{ $b['label'] }}</option>
                            @endforeach
                        </select>
                    </div>
                    <div class="col-md-auto">
                        <button type="submit" class="btn btn-success btn-sm px-4"><i class="bi bi-check2-circle me-1"></i>Assign Selected</button>
                    </div>
                    <div class="col-md-auto">
                        <button type="submit" formaction="{{ route('customer-bond-cheques.bulk-delete') }}" formnovalidate
                            onclick="return confirm('Delete the selected cheque(s)? This cannot be undone.');"
                            class="btn btn-danger btn-sm px-4"><i class="bi bi-trash me-1"></i>Delete Selected</button>
                    </div>
                </div>

                <div class="table-responsive">
                    <table class="table table-sm table-bordered align-middle">
                        <thead class="table-light">
                            <tr>
                                <th style="width:36px"><input type="checkbox" id="checkAll"></th>
                                <th>Cheque No</th>
                                <th>Amount</th>
                                <th>Assignment</th>
                                <th>Current Bond</th>
                                <th>Customer</th>
                                <th>Account</th>
                                <th>Cheque Date</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            @forelse($cheques as $c)
                                <tr>
                                    <td class="text-center"><input type="checkbox" class="row-check" name="cheque_ids[]" value="{{ $c->id }}"></td>
                                    <td>{{ $c->cheque_number }}</td>
                                    <td>{{ number_format((float)$c->amount, 2) }}</td>
                                    <td>
                                        @if($c->customer_bond_id)
                                            <span class="badge bg-success">Assigned</span>
                                        @else
                                            <span class="badge bg-warning text-dark">Not Assigned</span>
                                        @endif
                                    </td>
                                    <td>{{ optional($c->customerBond)->bond_no ?: '—' }}</td>
                                    <td>{{ optional(optional($c->customerBond)->customer)->name ?: '—' }}</td>
                                    <td>{{ optional($c->connectedAccount)->name ?: '—' }}</td>
                                    <td>{{ $c->cheque_date ? \Carbon\Carbon::parse($c->cheque_date)->format('Y-m-d') : '—' }}</td>
                                    <td><span class="badge bg-secondary">{{ ucfirst($c->status) }}</span></td>
                                </tr>
                            @empty
                                <tr><td colspan="9" class="text-center text-muted py-3">No cheques match the current filters.</td></tr>
                            @endforelse
                        </tbody>
                    </table>
                </div>
                <div class="text-muted small"><i class="bi bi-info-circle me-1"></i>Showing up to 500 cheques. Cheque numbers already present on the target bond are skipped.</div>
            </div>
        </div>
    </form>
</div>
@endsection

@push('scripts')
<script>
(function(){
    var checkAll = document.getElementById('checkAll');
    if(checkAll){
        checkAll.addEventListener('change', function(){
            document.querySelectorAll('.row-check').forEach(function(cb){ cb.checked = checkAll.checked; });
        });
    }
    if(window.jQuery && jQuery.fn.select2){
        try{ jQuery('.bond-select').select2({ theme:'bootstrap-5', width:'100%', placeholder:'— Select bond —' }); }catch(e){}
    }
})();
</script>
@endpush
