@extends('layouts.app')

@section('content')
@php
    $frequencyOptions = [
        'every_month'    => 'Every Month',
        'every_2_months' => 'Every 2 Months',
        'every_3_months' => 'Every 3 Months',
        'twice_a_month'  => 'Twice in a Month',
    ];
@endphp
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 gap-2 flex-wrap">
        <h5 class="fw-bold mb-0"><i class="bi bi-credit-card-2-front me-2 text-primary"></i>{{ $title }}</h5>
        <div class="ms-auto d-flex gap-2 flex-wrap">
            <a href="{{ route('customer-bond-cheques.assign') }}" class="btn btn-outline-success btn-sm"><i class="bi bi-link-45deg me-1"></i>Assign Cheques to Bond</a>
            <a href="{{ route('customer-bond-cheques.index') }}" class="btn btn-secondary btn-sm">Back to Cheques</a>
        </div>
    </div>

    <div class="card border-0 shadow-sm mb-3">
        <div class="card-body p-3">
            <form method="POST" action="{{ route('customer-bond-cheques.manual-import') }}" enctype="multipart/form-data" class="row g-2 align-items-end">
                @csrf
                <div class="col-md-6">
                    <label class="form-label small fw-semibold mb-1"><i class="bi bi-upload me-1"></i>Import cheques from CSV</label>
                    <input type="file" name="csv_file" accept=".csv,text/csv" required class="form-control form-control-sm">
                </div>
                <div class="col-md-auto">
                    <button type="submit" class="btn btn-success btn-sm"><i class="bi bi-box-arrow-in-down me-1"></i>Import CSV</button>
                </div>
                <div class="col-md-auto">
                    <a href="{{ route('customer-bond-cheques.manual-template') }}" class="btn btn-outline-secondary btn-sm"><i class="bi bi-download me-1"></i>Download Template</a>
                </div>
                <div class="col-12">
                    <span class="text-muted small"><i class="bi bi-info-circle me-1"></i>Columns: bond_no, account, cheque_number, amount, cheque_date, action_due_date, frequency_type, status, type, notes. Bonds are matched by bond number.</span>
                </div>
            </form>
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

    <div class="card border-0 shadow-sm">
        <div class="card-body p-3">
            <form method="POST" action="{{ route('customer-bond-cheques.manual-store') }}">
                @csrf
                <div class="table-responsive">
                    <table class="table table-sm table-bordered" id="chequesTable">
                        <thead>
                            <tr>
                                <th style="width:36px">#</th>
                                <th style="min-width:220px">Assign to Bond(s)</th>
                                <th style="min-width:150px">Account</th>
                                <th style="width:140px">Cheque No <span class="text-danger">*</span></th>
                                <th style="width:140px">Amount <span class="text-danger">*</span></th>
                                <th style="width:130px">Cheque Date</th>
                                <th style="width:130px">Due Date</th>
                                <th style="width:150px">Frequency</th>
                                <th style="width:130px">Status</th>
                                <th style="width:120px">Type</th>
                                <th style="width:180px">Notes</th>
                                <th style="width:50px"></th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>

                <div class="d-flex gap-2 mt-2">
                    <button type="button" id="addRow" class="btn btn-outline-primary btn-sm"><i class="bi bi-plus"></i> Add Row</button>
                    <button type="submit" class="btn btn-primary btn-sm px-4"><i class="bi bi-save me-1"></i> Save All</button>
                </div>
                <div class="text-muted small mt-2">
                    <i class="bi bi-info-circle me-1"></i>Tick one bond, or several — a separate cheque is created for each selected bond.
                </div>
            </form>
        </div>
    </div>
</div>

{{-- Row template --}}
<template id="rowTemplate">
    <tr>
        <td class="align-middle text-center text-muted" style="font-size:12px;">__IDX__</td>
        <td>
            <select name="entries[__IDX0__][bond_ids][]" class="form-select form-select-sm bond-select" multiple>
                @foreach($bonds as $b)
                    <option value="{{ $b['id'] }}">{{ $b['label'] }}</option>
                @endforeach
            </select>
        </td>
        <td>
            <select name="entries[__IDX0__][connected_account_id]" class="form-select form-select-sm acc-select">
                <option value="">— Select —</option>
                @foreach($accounts as $acc)
                    <option value="{{ $acc->id }}">{{ $acc->name }} / {{ $acc->mobile }}</option>
                @endforeach
            </select>
        </td>
        <td><input name="entries[__IDX0__][cheque_number]" required class="form-control form-control-sm"></td>
        <td><input type="number" step="0.01" name="entries[__IDX0__][amount]" required class="form-control form-control-sm"></td>
        <td><input type="date" name="entries[__IDX0__][cheque_date]" class="form-control form-control-sm" value="{{ \Carbon\Carbon::now()->format('Y-m-d') }}"></td>
        <td><input type="date" name="entries[__IDX0__][action_due_date]" class="form-control form-control-sm"></td>
        <td>
            <select name="entries[__IDX0__][frequency_type]" class="form-select form-select-sm">
                <option value="">—</option>
                @foreach($frequencyOptions as $val => $label)
                    <option value="{{ $val }}">{{ $label }}</option>
                @endforeach
            </select>
        </td>
        <td>
            <select name="entries[__IDX0__][status]" class="form-select form-select-sm">
                <option value="pending">Pending</option>
                <option value="cleared">Cleared</option>
                <option value="bounced">Bounced</option>
                <option value="cancelled">Cancelled</option>
            </select>
        </td>
        <td>
            <select name="entries[__IDX0__][type]" class="form-select form-select-sm">
                <option value="mentioned" selected>Mentioned</option>
                <option value="not_mentioned">Not Mentioned</option>
            </select>
        </td>
        <td><input name="entries[__IDX0__][notes]" class="form-control form-control-sm"></td>
        <td class="text-center"><button type="button" class="btn btn-danger btn-sm btn-remove px-2">✕</button></td>
    </tr>
</template>
@endsection

@push('scripts')
<script>
(function(){
    var table  = document.getElementById('chequesTable').querySelector('tbody');
    var tpl    = document.getElementById('rowTemplate').innerHTML;
    var addBtn = document.getElementById('addRow');

    function initSelect2($scope){
        if(!(window.jQuery && jQuery.fn.select2)) return;
        try{ jQuery($scope).find('.bond-select').select2({ theme:'bootstrap-5', width:'100%', placeholder:'Select bond(s)…', closeOnSelect:false }); }catch(e){}
        try{ jQuery($scope).find('.acc-select').select2({ theme:'bootstrap-5', width:'100%', placeholder:'— Select —' }); }catch(e){}
    }

    function reindex(){
        Array.from(table.querySelectorAll('tr')).forEach(function(row, idx){
            row.querySelector('td').textContent = idx + 1;
            Array.from(row.querySelectorAll('input, select')).forEach(function(inp){
                if(inp.name) inp.name = inp.name.replace(/entries\[\d+\]/, 'entries[' + idx + ']');
            });
        });
    }

    function firstRowAccount(){
        var first = table.querySelector('tr .acc-select');
        return first ? first.value : '';
    }

    function addRow(){
        var idx = table.querySelectorAll('tr').length;
        var html = tpl.replace(/__IDX__/g, idx + 1).replace(/__IDX0__/g, idx);
        var tmp = document.createElement('tbody');
        tmp.innerHTML = html.trim();
        var tr = tmp.querySelector('tr');
        // Inherit the account chosen in the first row.
        var acc = firstRowAccount();
        if(acc){ var sel = tr.querySelector('.acc-select'); if(sel) sel.value = acc; }
        table.appendChild(tr);
        initSelect2(tr);
        reindex();
    }

    addBtn.addEventListener('click', addRow);

    // When the first row's account changes, apply it to all other rows.
    table.addEventListener('change', function(e){
        var sel = e.target.closest && e.target.closest('.acc-select');
        if(!sel) return;
        var firstRow = table.querySelector('tr');
        if(!firstRow || !firstRow.contains(sel)) return;
        var val = sel.value;
        Array.from(table.querySelectorAll('tr')).forEach(function(row, i){
            if(i === 0) return;
            var s = row.querySelector('.acc-select');
            if(!s) return;
            s.value = val;
            if(window.jQuery && jQuery.fn.select2){ try{ jQuery(s).trigger('change.select2'); }catch(e){} }
        });
    });

    table.addEventListener('click', function(e){
        var btn = e.target.closest('.btn-remove');
        if(!btn) return;
        if(table.querySelectorAll('tr').length <= 1){ alert('At least one cheque row is required.'); return; }
        btn.closest('tr').remove();
        reindex();
    });

    addRow();
})();
</script>
@endpush
