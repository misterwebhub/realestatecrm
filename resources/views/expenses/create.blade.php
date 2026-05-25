@extends('layouts.app')

@section('content')
<div class="container py-3">
    <div class="d-flex justify-content-between align-items-center mb-3">
        <h4 class="mb-0">New Expense</h4>
        <a href="{{ route('expenses.index') }}" class="btn btn-sm btn-outline-secondary">Back</a>
    </div>

    <div class="card">
        <div class="card-body">
            <form action="{{ route('expenses.store') }}" method="post">
                @csrf
                <div class="row g-2">
                    <div class="col-md-4">
                        <label class="form-label">Scope</label>
                        <select name="scope" class="form-select">
                            <option value="arazi">Arazi Expense</option>
                            <option value="personal">Personal Expense</option>
                        </select>
                    </div>

                    <div class="col-md-4">
                        <label class="form-label">Expense Type</label>
                        <select name="expense_type_id" class="form-select" required>
                            <option value="">Select type</option>
                            @foreach(($types ?? []) as $id => $name)
                                <option value="{{ $id }}" @selected(isset($selectedType) && (string)$selectedType === (string)$id)>{{ $name }}</option>
                            @endforeach
                        </select>
                    </div>

                    <div class="col-md-4" id="expense-arazi-wrapper">
                        <label class="form-label">Arazi (required for Arazi Expense)</label>
                        <select id="expense-arazi" name="arazi_id" class="form-select">
                            <option value="">None</option>
                            @foreach($arazis as $id => $code)
                                <option value="{{ $id }}">{{ $code }}</option>
                            @endforeach
                        </select>
                    </div>

                    <div class="col-md-4">
                        <label class="form-label">Amount</label>
                        <input type="number" step="0.01" name="amount" class="form-control" required>
                    </div>

                    <div class="col-md-12" id="expense-label-wrapper">
                        <label class="form-label">Label</label>
                        <input type="text" name="label" class="form-control" id="expense-label-input">
                    </div>

                    <div class="col-md-12">
                        <label class="form-label">Notes</label>
                        <textarea name="notes" class="form-control" rows="3"></textarea>
                    </div>

                    <div class="col-12 mt-2">
                        <button class="btn btn-primary">Save Expense</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</div>
@endsection

@push('scripts')
<script>
document.addEventListener('DOMContentLoaded', function(){
    // Initialize Select2 for arazi select
    var $sel = $('#expense-arazi');
    if ($sel.length && ! $sel.data('select2')) {
        $sel.select2({
            theme: 'bootstrap-5',
            placeholder: 'Select Arazi (search...)',
            allowClear: true,
            ajax: {
                url: '{{ route('ajax.arazi.search') }}',
                dataType: 'json',
                delay: 250,
                data: function(params){ return { q: params.term }; },
                processResults: function(data){ return { results: data.results }; }
            },
            width: '100%'
        });
    }

    // toggle arazi field and label visibility based on scope
    function toggleAraziField() {
        var scope = document.querySelector('select[name="scope"]')?.value;
        var wrapper = document.getElementById('expense-arazi-wrapper');
        var sel = document.getElementById('expense-arazi');
        var labelWrapper = document.getElementById('expense-label-wrapper');
        var labelInput = document.getElementById('expense-label-input');
        if (!wrapper || !sel || !labelWrapper) return;
        if (scope === 'personal') {
            wrapper.style.display = 'none';
            labelWrapper.style.display = 'none';
            sel.required = false;
            if(labelInput) labelInput.value = '';
            if(window.jQuery && jQuery.fn.select2) jQuery(sel).val(null).trigger('change');
        } else {
            wrapper.style.display = '';
            labelWrapper.style.display = '';
            sel.required = true;
        }
    }

    document.querySelector('select[name="scope"]')?.addEventListener('change', toggleAraziField);
    // run on load
    toggleAraziField();
});
</script>
@endpush
