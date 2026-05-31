@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-body">

            <form action="{{ $action }}" method="POST">
                @csrf
                <input type="hidden" name="customer_id" id="customer_id">
                <input type="hidden" name="customer_bond_id" id="customer_bond_id">

                <div class="row g-3 mb-3">
                    <div class="col-md-6">
                        <label class="form-label">Entry Date</label>
                        <input type="date" id="entry_date" name="entry_date" class="form-control" value="{{ now()->format('Y-m-d') }}">
                    </div>
                    <div class="col-md-6">
                        <label class="form-label">Entry Type</label>
                        <select id="entry_type" name="entry_type" class="form-select">
                            <option value="advance">Advance</option>
                            <option value="installment" selected>Installment</option>
                            <option value="final">Final</option>
                            <option value="penalty">Penalty</option>
                            <option value="other">Other</option>
                        </select>
                    </div>
                </div>

                <div class="row g-3 mb-3">
                    <div class="col-md-4">
                        <label class="form-label">Arazi Number</label>
                        <div class="input-group">
                            <input type="text" id="arazi_input" class="form-control" placeholder="Enter Arazi no (legacy code)">
                            <button type="button" id="arazi_find" class="btn btn-outline-primary">Find</button>
                            <button type="button" id="show_plots_btn" class="btn btn-outline-secondary" title="Show plots for this Arazi">Show plots</button>
                        </div>
                        <input type="hidden" id="arazi_id_hidden" name="arazi_id">
                        <div id="arazi_label" class="form-text text-muted"></div>
                    </div>

                    <div class="col-md-4">
                        <label class="form-label">Plot</label>
                        <select id="plot_select" name="plot_id" class="form-select">
                            <option value="">Select Plot</option>
                        </select>
                    </div>

                    <div class="col-md-4">
                        <label class="form-label">Customer</label>
                        <input type="text" id="customer_display" class="form-control bg-light" readonly>
                    </div>

                    <div class="col-md-4">
                        <label class="form-label">Land Size</label>
                        <input type="text" id="land_size" name="land_size" class="form-control">
                    </div>

                    <div class="col-md-4">
                        <label class="form-label">Payment Method</label>
                        <select id="payment_method" name="payment_method" class="form-select">
                            @foreach($paymentMethods as $key => $label)
                                <option value="{{ $key }}">{{ $label }}</option>
                            @endforeach
                        </select>
                    </div>

                    <div class="col-md-4" id="cheque_container" style="display:none;">
                        <label class="form-label">Cheque (unpaid)</label>
                        <select id="cheque_select" name="customer_bond_cheque_id" class="form-select">
                            <option value="">Select Cheque</option>
                        </select>
                    </div>

                    <div class="col-md-4">
                        <label class="form-label">Amount</label>
                        <input type="number" step="0.01" name="amount" id="amount_input" class="form-control">
                    </div>

                    <div class="col-md-12">
                        <label class="form-label">Remarks</label>
                        <textarea name="remarks" id="remarks" class="form-control" rows="2" placeholder="Optional remarks about this payment"></textarea>
                    </div>
                </div>

                <div class="mt-3">
                    <button type="submit" class="btn btn-primary">Save Payment</button>
                    <a href="{{ url()->previous() }}" class="btn btn-outline-secondary">Cancel</a>
                </div>
            </form>
        </div>
    </div>

            @include('partials.arazi_plots_modal')
            @include('partials.arazi_matches_modal')

            <script>
        (function(){
            const arazisPlotsUrl = @json(route('arazis.plots', ['arazi' => '__ARAZI_ID__']));
            const arazisByCodeUrl = @json(route('arazis.by-code'));
            // include matches modal helper
            const bondByPlotUrl = @json(route('customer-bonds.by-plot', ['plot' => '__PLOT_ID__']));
            const customerBondChequesUrl = @json(route('customer-bond-cheques.for-bond', ['customer_bond' => '__BOND_ID__']));

            const aSelect = document.getElementById('arazi_select');
            const pSelect = document.getElementById('plot_select');
            const customerDisplay = document.getElementById('customer_display');
            const customerIdInput = document.getElementById('customer_id');
            const bondIdInput = document.getElementById('customer_bond_id');
            const landSizeInput = document.getElementById('land_size');
            const paymentMethod = document.getElementById('payment_method');
            const chequeContainer = document.getElementById('cheque_container');
            const chequeSelect = document.getElementById('cheque_select');
            const amountInput = document.getElementById('amount_input');

            async function loadPlots(araziId){
                pSelect.innerHTML = '<option value="">Select Plot</option>';
                if(!araziId) return;
                try{
                    const res = await fetch(arazisPlotsUrl.replace('__ARAZI_ID__', encodeURIComponent(araziId)));
                    if(!res.ok) return;
                    const data = await res.json();
                    if(!Array.isArray(data)) return;
                    data.forEach(function(p){
                        const opt = document.createElement('option');
                        opt.value = p.id;
                        opt.textContent = p.label;
                        if(p.area !== undefined) opt.dataset.area = p.area;
                        pSelect.appendChild(opt);
                    });
                }catch(e){ }
            }

            // When user clicks Find, lookup arazi by code and load plots
            document.getElementById('arazi_find').addEventListener('click', async function(){
                const code = document.getElementById('arazi_input').value.trim();
                document.getElementById('arazi_label').textContent = '';
                pSelect.innerHTML = '<option value="">Select Plot</option>';
                if(!code) return;
                try{
                    const res = await fetch(arazisByCodeUrl + '?code=' + encodeURIComponent(code));
                    if(!res.ok) return;
                    const json = await res.json();
                    if(!json.found){
                        document.getElementById('arazi_label').textContent = 'Arazi not found';
                        return;
                    }
                    // if multiple matches returned, show modal for selection
                    if(json.matches && Array.isArray(json.matches) && json.matches.length > 0){
                        try{ showAraziMatches(json.matches); }catch(e){ console.debug('show matches failed', e); }
                        return;
                    }

                    document.getElementById('arazi_label').textContent = json.arazi_label || '';
                    document.getElementById('arazi_id_hidden').value = json.arazi_id || '';
                    // populate plots
                    (json.plots || []).forEach(function(p){
                        const opt = document.createElement('option');
                        opt.value = p.id;
                        opt.textContent = p.label;
                        if(p.area !== undefined) opt.dataset.area = p.area;
                        pSelect.appendChild(opt);
                    });
                }catch(e){}
            });

            // when user selects an arazi from matches modal, populate fields
            window.addEventListener('arazi:selected', function(evt){
                const a = evt.detail || {};
                if(!a || !a.id) return;
                document.getElementById('arazi_label').textContent = a.label || '';
                document.getElementById('arazi_id_hidden').value = a.id;
                // load plots for selected arazi id
                loadPlots(a.id);
            });

            pSelect.addEventListener('change', async function(){
                const sel = this.options[this.selectedIndex];
                const area = sel?.dataset?.area ?? '';
                landSizeInput.value = area || '';

                // reset customer/bond
                customerDisplay.value = '';
                customerIdInput.value = '';
                bondIdInput.value = '';
                chequeSelect.innerHTML = '<option value="">Select Cheque</option>';
                chequeContainer.style.display = 'none';

                if(!this.value) return;
                try{
                    const res = await fetch(bondByPlotUrl.replace('__PLOT_ID__', encodeURIComponent(this.value)));
                    if(!res.ok) return;
                    const json = await res.json();
                    if(!json.found){ return; }
                    bondIdInput.value = json.bond_id;
                    customerIdInput.value = json.customer_id ?? '';
                    customerDisplay.value = json.customer_label ?? '';
                    if(paymentMethod.value === 'cheque'){
                        loadChequesForBond(json.bond_id);
                    }
                }catch(e){}
            });

            // default to cash when no cheque selected
            paymentMethod.value = 'cash';

            paymentMethod.addEventListener('change', function(){
                if(this.value === 'cheque'){
                    chequeContainer.style.display = '';
                    const bid = bondIdInput.value;
                    if(bid) loadChequesForBond(bid);
                } else {
                    chequeContainer.style.display = 'none';
                    chequeSelect.innerHTML = '<option value="">Select Cheque</option>';
                    amountInput.removeAttribute('readonly');
                    amountInput.classList.remove('bg-light');
                }
            });

            async function loadChequesForBond(bondId){
                chequeSelect.innerHTML = '<option value="">Select Cheque</option>';
                if(!bondId) return;
                try{
                    const url = customerBondChequesUrl.replace('__BOND_ID__', encodeURIComponent(bondId)) + '?status=pending';
                    const res = await fetch(url);
                    if(!res.ok) return;
                    const data = await res.json();
                    if(!Array.isArray(data)) return;
                    data.forEach(function(c){
                        const opt = document.createElement('option');
                        opt.value = c.id;
                        opt.textContent = c.label;
                        opt.dataset.amount = (c.amount !== undefined && c.amount !== null) ? c.amount : '';
                        chequeSelect.appendChild(opt);
                    });
                    function handleChequeSelection(selElem){
                        try{
                            const s = selElem.options[selElem.selectedIndex];
                            console.debug('cheque select changed', s ? s.value : null, s ? s.dataset.amount : null, s ? s.textContent : null);
                            if(s && s.value){
                                let a = s.dataset.amount || '';
                                if(!a){
                                    const m = (s.textContent || '').match(/([\d,]+(?:\.\d+)?)/);
                                    if(m) a = m[1].replace(/,/g, '');
                                }
                                if(a !== ''){
                                    amountInput.value = a;
                                    amountInput.setAttribute('readonly', 'readonly');
                                    amountInput.classList.add('bg-light');
                                }
                                // force payment method to cheque and disable changing
                                paymentMethod.value = 'cheque';
                                paymentMethod.setAttribute('disabled', 'disabled');
                            } else {
                                // no cheque selected: default to cash and make editable
                                paymentMethod.removeAttribute('disabled');
                                paymentMethod.value = 'cash';
                                amountInput.removeAttribute('readonly');
                                amountInput.classList.remove('bg-light');
                            }
                        }catch(e){
                            console.error('handleChequeSelection error', e);
                        }
                    }

                    chequeSelect.addEventListener('change', function(){ handleChequeSelection(this); });
                    // also handle Select2 events if Select2 is active
                    if(window.jQuery && jQuery.fn.select2){
                        try{
                            jQuery('#cheque_select').on('select2:select select2:unselect', function(){ handleChequeSelection(chequeSelect); });
                        }catch(e){ console.debug('select2 bind failed', e); }
                    }
                    // initialize Select2 if available
                    if(window.jQuery && jQuery.fn.select2){
                        try{ jQuery('#cheque_select').select2({ theme: 'bootstrap-5', width: '100%', placeholder: 'Select Cheque', allowClear: true }); }catch(e){}
                    }
                }catch(e){}
            }

            // AJAX form submit to keep UI in sync
            const form = document.querySelector('form');
            const submitBtn = form.querySelector('button[type="submit"]');
            form.addEventListener('submit', async function(ev){
                ev.preventDefault();
                if(!confirm('Save payment?')) return;
                const fd = new FormData(form);
                // include payment_method value (select)
                fd.set('payment_method', paymentMethod.value || 'cash');

                submitBtn.disabled = true;
                submitBtn.textContent = 'Saving...';
                try{
                        const res = await fetch(form.action, {
                        method: 'POST',
                        headers: { 'X-Requested-With': 'XMLHttpRequest', 'X-CSRF-TOKEN': document.querySelector('meta[name="csrf-token"]').getAttribute('content') },
                        body: fd,
                        credentials: 'same-origin'
                    });
                    const json = await res.json();
                    if(res.ok && json.success){
                        alert('Payment saved.');
                        // if cheque was used, update its option to cleared
                        const chequeId = json.payment?.customer_bond_cheque_id;
                        if(chequeId){
                            const opt = Array.from(chequeSelect.options).find(o => o.value == String(chequeId));
                            if(opt){
                                opt.textContent = opt.textContent + ' — Cleared';
                                opt.disabled = true;
                            }
                        }
                        // open receipt in new tab if available
                        try{
                            const entryNo = json.payment?.entry_no || null;
                            if(entryNo){
                                const receiptBase = @json(route('customer-bond-payments.receipt'));
                                const url = receiptBase + '?entry_no=' + encodeURIComponent(entryNo) + '&print=1';
                                window.open(url, '_blank');
                            }
                        }catch(e){/* ignore */}
                        // reset form for next entry
                        form.reset();
                        // reset select2 if used
                        if(window.jQuery && jQuery.fn.select2){ try{ jQuery('#cheque_select').val(null).trigger('change'); }catch(e){} }
                        chequeSelect.innerHTML = '<option value="">Select Cheque</option>';
                        chequeContainer.style.display = 'none';
                        // ensure payment method and amount inputs are re-enabled after a cheque save
                        if(paymentMethod){
                            paymentMethod.removeAttribute('disabled');
                            paymentMethod.value = 'cash';
                        }
                        if(amountInput){
                            amountInput.removeAttribute('readonly');
                            amountInput.classList.remove('bg-light');
                            amountInput.value = '';
                        }
                    } else {
                        alert('Save failed: ' + (json.error || 'Unknown error'));
                    }
                }catch(e){
                    alert('Save failed.');
                } finally {
                    submitBtn.disabled = false;
                    submitBtn.textContent = 'Save Payment';
                }
            });
        })();
    </script>
@endsection
