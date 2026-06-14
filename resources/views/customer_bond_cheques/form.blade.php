@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-header d-flex align-items-center gap-2">
            <h5 class="card-title mb-0 fw-bold">{{ $title }}</h5>
            <a href="{{ route('customer-bonds.index') }}" class="btn btn-secondary btn-sm ms-auto">Back to Bonds</a>
        </div>

        <div class="card-body">
            <form method="POST" action="{{ route('customer-bond-cheques.store') }}">
                @csrf

                <input type="hidden" name="customer_bond_id" value="{{ $bond?->id ?? old('customer_bond_id') }}">

                <div class="mb-3">
                    <label class="form-label">Customer Bond</label>
                    <div class="form-control bg-light">{{ $bond?->bond_no ?? '-' }} — {{ $bond?->customer?->name ?? '-' }}</div>
                </div>

                {{-- Connected Account (required) --}}
                <div class="mb-3">
                    <label class="form-label fw-semibold">
                        Connected Account <span class="text-danger">*</span>
                        <a href="{{ route('connected-accounts.create') }}" target="_blank" class="ms-2 small text-primary">+ Add new</a>
                    </label>
                    <select name="connected_account_id" id="connected_account_id" class="form-select @error('connected_account_id') is-invalid @enderror" required>
                        <option value="">— Select Account —</option>
                        @foreach(\App\Models\ConnectedAccount::orderBy('name')->get() as $acc)
                            <option value="{{ $acc->id }}" @selected(old('connected_account_id') == $acc->id)>
                                {{ $acc->name }} — {{ $acc->mobile }}
                            </option>
                        @endforeach
                    </select>
                    @error('connected_account_id')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>

                <div class="mb-3">
                    <label class="form-label">Cheque Number</label>
                    <input name="cheque_number" class="form-control" value="{{ old('cheque_number') }}">
                </div>

                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label class="form-label">Bank Name</label>
                        <input name="bank_name" class="form-control" value="{{ old('bank_name') }}">
                    </div>
                    <div class="col-md-6 mb-3">
                        <label class="form-label">Branch</label>
                        <input name="branch_name" class="form-control" value="{{ old('branch_name') }}">
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 mb-3">
                        <label class="form-label">Cheque Date</label>
                        <input type="date" name="cheque_date" class="form-control" value="{{ old('cheque_date') }}">
                    </div>
                    <div class="col-md-4 mb-3">
                        <label class="form-label">Amount</label>
                        <input type="number" step="0.01" name="amount" class="form-control" value="{{ old('amount') }}">
                    </div>
                    <div class="col-md-4 mb-3">
                        <label class="form-label">Status</label>
                        <select name="status" class="form-select">
                            <option value="pending">Pending</option>
                            <option value="cleared">Cleared</option>
                            <option value="bounced">Bounced</option>
                            <option value="cancelled">Cancelled</option>
                        </select>
                    </div>
                </div>

                <div class="mb-3">
                    <label class="form-label">Notes</label>
                    <textarea name="notes" class="form-control">{{ old('notes') }}</textarea>
                </div>

                <div class="d-flex gap-2">
                    <button class="btn btn-primary">Save Cheque</button>
                    <a href="{{ route('customer-bonds.index') }}" class="btn btn-secondary">Back</a>
                </div>
            </form>
        </div>
    </div>

@push('scripts')
<script>
$(function(){
    $('#connected_account_id').select2({
        theme: 'bootstrap-5',
        placeholder: '— Select Account —',
        allowClear: true,
        width: '100%',
    });
});
</script>
@endpush
@endsection
