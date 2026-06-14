@php
    $isEdit = isset($item) && $item->exists;
    $action = $action ?? route('registries.store');
    $method = $method ?? 'POST';
    $customers = $customers ?? [];
    $arazis = $arazis ?? [];
    $agents = $agents ?? [];
@endphp

@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary receipt-like" style="max-width:720px;margin:12px auto;border:4px solid #000;background:#fff;color:#000;">
        <div class="card-header p-2 d-flex align-items-center gap-2" style="border-bottom:2px solid #000;">
            <div>
                <div style="font-size:18px;font-weight:800;">HEED REAL ESTATE</div>
                <div style="font-size:12px;">Registry / Receipt</div>
            </div>
            <div style="text-align:right;font-size:12px" class="ms-auto">{{ $isEdit ? 'Edit' : 'New' }}</div>
        </div>
        <div class="card-body p-2">
            <form action="{{ $action }}" method="POST" id="registryForm" enctype="multipart/form-data">
                @csrf
                @if($method !== 'POST') @method($method) @endif

                @if($errors->any())
                    <div class="alert alert-danger">
                        <ul class="mb-0">
                            @foreach($errors->all() as $error)
                                <li>{{ $error }}</li>
                            @endforeach
                        </ul>
                    </div>
                @endif

                <div class="receipt-fields" style="font-size:13px;">
                    <div style="display:flex;gap:8px;margin-bottom:6px;" class="field-group">
                        <div style="flex:1">
                            <div class="small-label">Mobile</div>
                            <input type="text" name="mobile" value="{{ old('mobile', $item->mobile ?? '') }}" class="form-control form-control-sm">
                        </div>
                        <div style="width:150px">
                            <div class="small-label">Receipt#</div>
                            <input type="text" name="receipt_no" value="{{ old('receipt_no', $item->receipt_no ?? '') }}" class="form-control form-control-sm bg-light" readonly>
                        </div>
                    </div>

                    <div style="margin-bottom:6px;" class="field-group">
                        <div class="small-label required">Associate</div>
                        <select name="customer_id" class="form-select form-select-sm mb-1 @error('customer_id') is-invalid @enderror">
                            <option value="">--Select Customer--</option>
                            @foreach($customers as $id => $name)
                                <option value="{{ $id }}" {{ (string)$id === (string) old('customer_id', $item->customer_id ?? '') ? 'selected' : '' }}>{{ $name }}</option>
                            @endforeach
                        </select>
                        @error('customer_id')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        <input type="text" name="associate_address" value="{{ old('associate_address', $item->associate_address ?? '') }}" class="form-control form-control-sm">
                    </div>

                    <div style="display:flex;gap:8px;margin-bottom:6px;align-items:center;" class="field-group">
                        <div style="flex:1">
                            <div class="small-label required">Arazi</div>
                            <select name="arazi_id" id="arazi_id" class="form-select form-select-sm @error('arazi_id') is-invalid @enderror">
                                <option value="">--Select Arazi--</option>
                                @foreach($arazis as $id => $label)
                                    <option value="{{ $id }}" {{ (string)$id === (string) old('arazi_id', $item->arazi_id ?? '') ? 'selected' : '' }}>{{ $label }}</option>
                                @endforeach
                            </select>
                            @error('arazi_id')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>

                        <div style="width:140px">
                            <div class="small-label">Plot</div>
                            <select name="plot_id" id="plot_id" class="form-select form-select-sm">
                                <option value="">--Select Plot--</option>
                            </select>
                        </div>

                        <div style="width:140px">
                            <div class="small-label required">Date</div>
                            <input type="date" name="registry_date" value="{{ old('registry_date', optional($item->registry_date)->format('Y-m-d') ?? '') }}" class="form-control form-control-sm @error('registry_date') is-invalid @enderror">
                            @error('registry_date')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                    </div>

                    <div style="display:flex;gap:8px;margin-bottom:6px;">
                        <div style="flex:1">
                            <div class="small-label required">Booking Mode</div>
                            <select name="booking_mode" class="form-select form-select-sm @error('booking_mode') is-invalid @enderror">
                                <option value="cash" @selected(old('booking_mode', $item->booking_mode ?? '')=='cash')>Cash</option>
                                <option value="emi" @selected(old('booking_mode', $item->booking_mode ?? '')=='emi')>EMI</option>
                                <option value="other" @selected(old('booking_mode', $item->booking_mode ?? '')=='other')>Other</option>
                            </select>
                            @error('booking_mode')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>

                        <div style="width:120px">
                            <div class="small-label required">Land Size</div>
                            <input type="number" step="0.01" name="land_size" value="{{ old('land_size', $item->land_size ?? '') }}" class="form-control form-control-sm text-end @error('land_size') is-invalid @enderror" placeholder="required">
                            @error('land_size')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>

                        <div style="width:120px">
                            <div class="small-label required">Broker %</div>
                            <input type="number" step="0.01" name="broker_commission" value="{{ old('broker_commission', $item->broker_commission ?? '') }}" class="form-control form-control-sm text-end @error('broker_commission') is-invalid @enderror" placeholder="0 - 100">
                            @error('broker_commission')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>

                        <div style="width:140px">
                            <div class="small-label">Registry Amount</div>
                            <input type="number" step="0.01" name="registry_amount" value="{{ old('registry_amount', $item->registry_amount ?? '') }}" class="form-control form-control-sm text-end @error('registry_amount') is-invalid @enderror">
                            @error('registry_amount')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                    </div>

                    <div style="margin-bottom:6px;">
                        <div class="small-label">Amount (words)</div>
                        <input type="text" name="payment_words" value="{{ old('payment_words', $item->payment_words ?? '') }}" class="form-control form-control-sm">
                    </div>

                    <div style="display:flex;gap:8px;margin-bottom:6px;">
                        <div style="width:120px">
                            <div class="small-label">Advance</div>
                            <input type="number" step="0.01" name="advance_amount" value="{{ old('advance_amount', $item->advance_amount ?? '') }}" class="form-control form-control-sm text-end @error('advance_amount') is-invalid @enderror">
                            @error('advance_amount')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                        <div style="width:120px">
                            <div class="small-label">Down Payment</div>
                            <input type="number" step="0.01" name="down_payment" value="{{ old('down_payment', $item->down_payment ?? '') }}" class="form-control form-control-sm text-end @error('down_payment') is-invalid @enderror">
                            @error('down_payment')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                        <div style="width:160px">
                            <div class="small-label">Installment</div>
                            <input type="number" step="0.01" name="installment_amount" value="{{ old('installment_amount', $item->installment_amount ?? '') }}" class="form-control form-control-sm text-end @error('installment_amount') is-invalid @enderror">
                            @error('installment_amount')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                        <div style="width:140px">
                            <div class="small-label">Due Date</div>
                            <input type="date" name="due_date" value="{{ old('due_date', optional($item->due_date)->format('Y-m-d') ?? '') }}" class="form-control form-control-sm @error('due_date') is-invalid @enderror">
                            @error('due_date')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                    </div>

                    <div style="display:flex;gap:8px;margin-bottom:6px;">
                        <div style="flex:1">
                            <div class="small-label">Registry Code</div>
                            <input type="text" name="registry_code" value="{{ old('registry_code', $item->registry_code ?? '') }}" class="form-control form-control-sm @error('registry_code') is-invalid @enderror">
                            @error('registry_code')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                        <div style="width:160px">
                            <div class="small-label">Customer Reg No</div>
                            <input type="text" name="customer_reg_no" value="{{ old('customer_reg_no', $item->customer_reg_no ?? '') }}" class="form-control form-control-sm @error('customer_reg_no') is-invalid @enderror">
                            @error('customer_reg_no')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                    </div>

                    <div style="display:flex;gap:8px;margin-bottom:6px;" class="field-group">
                        <div style="flex:1">
                            <div class="small-label required">Witness</div>
                            <input type="text" name="witness_name" value="{{ old('witness_name', $item->witness_name ?? '') }}" class="form-control form-control-sm @error('witness_name') is-invalid @enderror">
                            @error('witness_name')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                        <div style="flex:1">
                            <div class="small-label">Nominee</div>
                            <input type="text" name="nominee_name" value="{{ old('nominee_name', $item->nominee_name ?? '') }}" class="form-control form-control-sm @error('nominee_name') is-invalid @enderror">
                            @error('nominee_name')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                        <div style="width:160px">
                            <div class="small-label">Agent</div>
                            <select name="agent_id" class="form-select form-select-sm">
                                <option value="">--Select--</option>
                                @foreach($agents as $id => $name)
                                    <option value="{{ $id }}" @selected((string)$id===(string)old('agent_id',$item->agent_id ?? ''))>{{ $name }}</option>
                                @endforeach
                            </select>
                        </div>
                    </div>

                    <div style="margin-bottom:6px;">
                        <div class="small-label">Checked By</div>
                        <select name="check_by_agent_id" class="form-select form-select-sm">
                            <option value="">--Select Broker--</option>
                            @foreach($agents as $id => $name)
                                <option value="{{ $id }}" @selected((string)$id===(string)old('check_by_agent_id',$item->check_by_agent_id ?? ''))>{{ $name }}</option>
                            @endforeach
                        </select>
                    </div>

                    <div style="margin-bottom:6px;">
                        <div class="small-label">Registry Document</div>
                        @if(!empty($item->document_path))
                            <div style="margin-bottom:6px;"><a href="{{ asset('storage/' . $item->document_path) }}" target="_blank">Download existing document</a></div>
                        @endif
                        <input type="file" name="document" class="form-control form-control-sm @error('document') is-invalid @enderror">
                        @error('document')<div class="invalid-feedback">{{ $message }}</div>@enderror
                    </div>

                    <div style="display:flex;gap:8px;margin-bottom:6px;align-items:center;" class="field-group">
                        <div style="width:140px">
                            <div class="small-label required">Status</div>
                            <select name="status" class="form-select form-select-sm @error('status') is-invalid @enderror">
                                <option value="pending" @selected(old('status', $item->status ?? '')=='pending')>Pending</option>
                                <option value="completed" @selected(old('status', $item->status ?? '')=='completed')>Completed</option>
                                <option value="cancelled" @selected(old('status', $item->status ?? '')=='cancelled')>Cancelled</option>
                            </select>
                            @error('status')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>

                        <div style="width:160px">
                            <div class="small-label required">Payment Status</div>
                            <select name="payment_status" class="form-select form-select-sm @error('payment_status') is-invalid @enderror">
                                <option value="pending" @selected(old('payment_status', $item->payment_status ?? '')=='pending')>Pending</option>
                                <option value="partial" @selected(old('payment_status', $item->payment_status ?? '')=='partial')>Partial</option>
                                <option value="completed" @selected(old('payment_status', $item->payment_status ?? '')=='completed')>Completed</option>
                                <option value="expired" @selected(old('payment_status', $item->payment_status ?? '')=='expired')>Expired</option>
                            </select>
                            @error('payment_status')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>

                        <div style="width:120px">
                            <div class="small-label required">Lock</div>
                            <select name="lock_status" class="form-select form-select-sm @error('lock_status') is-invalid @enderror">
                                <option value="unlock" @selected(old('lock_status', $item->lock_status ?? '')=='unlock')>Unlock</option>
                                <option value="lock" @selected(old('lock_status', $item->lock_status ?? '')=='lock')>Lock</option>
                            </select>
                            @error('lock_status')<div class="invalid-feedback">{{ $message }}</div>@enderror
                        </div>
                    </div>
                </div>

                <div style="display:flex;gap:8px;justify-content:flex-end;margin-top:8px;">
                    <a href="{{ route('registries.index') }}" class="btn btn-sm btn-outline-secondary">Back</a>
                    @if($isEdit)
                        <button type="button" id="esignBtn" class="btn btn-sm btn-info">E-Sign</button>
                    @endif
                    <button type="submit" class="btn btn-sm btn-primary">{{ $isEdit ? 'Update' : 'Create' }}</button>
                </div>
            </form>
        </div>
    </div>

    @push('scripts')
    <script>
        (function(){
            const araziSelect = document.getElementById('arazi_id');
            const plotSelect = document.getElementById('plot_id');
            const csrf = document.querySelector('meta[name="csrf-token"]')?.getAttribute('content');

            async function loadPlots(araziId, selected){
                plotSelect.innerHTML = '<option value="">--Select Plot--</option>';
                if(!araziId) return;
                try{
                    const res = await fetch('{{ route('arazis.plots', ['arazi' => '__ARAZI__']) }}'.replace('__ARAZI__', encodeURIComponent(araziId)), { headers: { 'Accept': 'application/json' } });
                    if(!res.ok) return;
                    const data = await res.json();
                    data.forEach(function(p){
                        const opt = document.createElement('option');
                        opt.value = p.id;
                        opt.textContent = p.label + (p.block ? ' ('+p.block+')' : '');
                        if(String(p.id) === String(selected)) opt.selected = true;
                        plotSelect.appendChild(opt);
                    });
                }catch(e){ }
            }

            if(araziSelect){
                araziSelect.addEventListener('change', function(){ loadPlots(this.value, null); });
                if(araziSelect.value){ loadPlots(araziSelect.value, '{{ old('plot_id', $item->plot_id ?? '') }}'); }
            }

            const esignBtn = document.getElementById('esignBtn');
            if(esignBtn){
                esignBtn.addEventListener('click', function(){
                    if(!confirm('Apply e-signature placeholder for this registry?')) return;
                    fetch('{{ $isEdit ? route('registries.esign', $item->id) : '' }}', {method:'POST', headers:{'X-CSRF-TOKEN': csrf,'Content-Type':'application/json'}, body: JSON.stringify({placeholder: true})})
                        .then(r => r.json()).then(j => alert(j.message || 'Signed'))
                        .catch(e => alert('Error'));
                });
            }
        })();
    </script>
    @endpush

@endsection

@push('styles')
<style>
    .receipt-like { font-family: Arial, Helvetica, sans-serif; }
    .receipt-like .small-label { font-size:11px; font-weight:700; color:#111; margin-bottom:3px; }
    .receipt-like .small-label.required::after { content: " *"; color: #c0392b; margin-left:4px; font-weight:800; }
    .receipt-like .field-group { padding:6px 0; border-bottom:1px dashed rgba(0,0,0,0.06); }
    .receipt-like .card-body { padding:12px; }
    .receipt-like .form-control-sm, .receipt-like .form-select-sm { padding:4px 6px; height:32px; }
    .receipt-like input[type="file"] { padding:2px; }
    .receipt-like .text-end { text-align:right; }
    @media print {
        .receipt-like { max-width:720px; margin:0 auto; }
        .no-print { display:none !important; }
    }
</style>
@endpush
