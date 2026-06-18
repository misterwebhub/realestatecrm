@extends('layouts.app')

@section('content')
<div class="row g-3 align-items-start">

    {{-- LEFT: Payment Form --}}
    <div class="col-lg-8">
        <div class="card card-outline card-primary h-100">
            <div class="card-header"><h5 class="card-title mb-0 fw-bold">{{ $title }}</h5></div>
            <div class="card-body">
                <form action="{{ $action }}" method="POST" id="compact_payment_form">
                    @csrf
                    <input type="hidden" name="customer_id"       id="customer_id">
                    <input type="hidden" name="customer_bond_id"  id="customer_bond_id">
                    <input type="hidden" name="arazi_code"        id="arazi_code_hidden">
                    <input type="hidden" name="plot_id"           id="plot_id_hidden">

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
                                <option value="return">Return (Debit)</option>
                                <option value="discount">Discount (Debit)</option>
                                <option value="other">Other</option>
                            </select>
                        </div>
                    </div>

                    {{-- Arazi lookup row --}}
                    <div class="row g-3 mb-3">
                        <div class="col-md-6">
                            <label class="form-label">Arazi Number</label>
                            <div class="input-group">
                                <input type="text" id="arazi_input" class="form-control" placeholder="Enter Arazi code">
                                <button type="button" id="arazi_find" class="btn btn-outline-primary">Find</button>
                                <button type="button" id="show_plots_btn" class="btn btn-outline-secondary" title="Show plots">Show plots</button>
                            </div>
                            <div id="arazi_label" class="form-text text-muted"></div>
                        </div>

                        <div class="col-md-6">
                            <label class="form-label">Plot</label>
                            <select id="plot_select" name="plot_id" class="form-select">
                                <option value="">Select Plot</option>
                            </select>
                        </div>
                    </div>

                    {{-- Auto-filled info row --}}
                    <div class="row g-3 mb-3">
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
                    </div>

                    <div class="row g-3 mb-3">
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
                        <div class="col-md-4">
                            <label class="form-label fw-semibold">Taken By <span class="text-danger">*</span></label>
                            <select name="taken_by_user_id" id="taken_by_user_id" class="form-select" required>
                                <option value="">— Select User —</option>
                                @foreach($activeUsers as $user)
                                    <option value="{{ $user->id }}">{{ $user->name }}{{ $user->username ? ' ('.$user->username.')' : '' }}</option>
                                @endforeach
                            </select>
                        </div>
                        <div class="col-md-12">
                            <label class="form-label">Remarks</label>
                            <textarea name="remarks" id="remarks" class="form-control" rows="2" placeholder="Optional remarks"></textarea>
                        </div>
                    </div>

                    <div class="mt-3">
                        <button type="submit" id="submit_btn" class="btn btn-primary">Save Payment</button>
                        <a href="{{ url()->previous() }}" class="btn btn-outline-secondary ms-2">Cancel</a>
                    </div>
                </form>
            </div>
        </div>
    </div>

    {{-- RIGHT: Bond Lookup + Summary Panel --}}
    <div class="col-lg-4">
        <div class="card card-outline card-success">
            <div class="card-header"><h5 class="card-title mb-0 fw-bold">Quick Bond Lookup</h5></div>
            <div class="card-body pb-2">
                <p class="text-muted small mb-2">Enter Bond No. OR select Arazi → Plot to auto-fill.</p>
                <div class="input-group mb-2">
                    <input type="text" id="bond_no_input" class="form-control form-control-sm" placeholder="e.g. CB-0012">
                    <button type="button" id="bond_find_btn" class="btn btn-success btn-sm">Fill</button>
                </div>
                <div id="bond_lookup_msg" class="form-text mb-2"></div>
            </div>
        </div>

        {{-- Bond Details Summary Card --}}
        <div id="bond_info_card" class="card card-outline card-info mt-3" style="display:none;">
            <div class="card-header py-2"><h6 class="card-title mb-0 fw-bold">Bond Summary</h6></div>
            <div class="card-body p-0">
                <table class="table table-sm mb-0">
                    <tbody>
                        <tr><th class="text-muted fw-normal ps-3" style="width:48%">Bond No</th><td id="bi_bond_no" class="fw-semibold"></td></tr>
                        <tr><th class="text-muted fw-normal ps-3">Customer</th><td id="bi_customer"></td></tr>
                        <tr><th class="text-muted fw-normal ps-3">Bond Date</th><td id="bi_bond_date"></td></tr>
                        <tr><th class="text-muted fw-normal ps-3">Installment No</th><td id="bi_inst_no" class="fw-semibold text-primary"></td></tr>
                        <tr><th class="text-muted fw-normal ps-3">End Date</th><td id="bi_end_date"></td></tr>
                        <tr class="table-success"><th class="ps-3">Total Amount</th><td id="bi_total" class="fw-bold"></td></tr>
                        <tr class="table-primary"><th class="ps-3">Paid</th><td id="bi_paid" class="fw-bold text-success"></td></tr>
                        <tr class="table-danger"><th class="ps-3">Balance Left</th><td id="bi_balance" class="fw-bold text-danger"></td></tr>
                    </tbody>
                </table>
            </div>
        </div>

        {{-- Witnesses Card --}}
        <div id="bond_witnesses_card" class="card card-outline card-warning mt-3" style="display:none;">
            <div class="card-header py-2"><h6 class="card-title mb-0 fw-bold">Witnesses</h6></div>
            <div class="card-body p-0">
                <table class="table table-sm mb-0" id="witnesses_table">
                    <thead><tr><th class="ps-3">Name</th><th>Mobile</th></tr></thead>
                    <tbody id="witnesses_tbody"></tbody>
                </table>
            </div>
        </div>
    </div>

</div>

@include('partials.arazi_plots_modal')

<script>
(function(){
    const arazisByCodeUrl       = @json(route('arazis.by-code'));
    const araziPlotsByCodeUrl   = @json(route('arazis.plots-by-code', ['code' => '__ARAZI_CODE__']));
    const bondByPlotUrl         = @json(route('customer-bonds.by-plot', ['plot' => '__PLOT_ID__']));
    const customerBondChequesUrl= @json(route('customer-bond-cheques.for-bond', ['customer_bond' => '__BOND_ID__']));
    const bondByBondNoUrl       = @json(route('customer-bonds.by-bond-no'));

    const pSelect          = document.getElementById('plot_select');
    const customerDisplay  = document.getElementById('customer_display');
    const customerIdInput  = document.getElementById('customer_id');
    const bondIdInput      = document.getElementById('customer_bond_id');
    const landSizeInput    = document.getElementById('land_size');
    const paymentMethod    = document.getElementById('payment_method');
    const chequeContainer  = document.getElementById('cheque_container');
    const chequeSelect     = document.getElementById('cheque_select');
    const amountInput      = document.getElementById('amount_input');
    const araziIdHidden    = document.getElementById('arazi_code_hidden');

    const bondInfoCard      = document.getElementById('bond_info_card');
    const bondWitnessesCard = document.getElementById('bond_witnesses_card');
    const witnessesTbody    = document.getElementById('witnesses_tbody');

    // ─── helpers ────────────────────────────────────────────────────────────

    function fmt(n){ return 'Rs. ' + parseFloat(n || 0).toLocaleString('en-IN', {minimumFractionDigits:2, maximumFractionDigits:2}); }

    function populatePlots(plots, selectFirst){
        pSelect.innerHTML = '<option value="">Select Plot</option>';
        (plots || []).forEach(function(p){
            const opt = document.createElement('option');
            opt.value = p.id;
            opt.textContent = p.label + (p.area ? ' / ' + p.area + ' gaz' : '');
            opt.dataset.area = p.area ?? '';
            pSelect.appendChild(opt);
        });
        if(selectFirst && plots && plots.length > 0){
            pSelect.value = plots[0].id;
            landSizeInput.value = plots[0].area ?? '';
        }
    }

    function fillRightPanel(json){
        document.getElementById('bi_bond_no').textContent   = json.bond_no ?? '-';
        document.getElementById('bi_customer').textContent  = json.customer_label ?? '-';
        document.getElementById('bi_bond_date').textContent = json.bond_date ?? '-';
        document.getElementById('bi_inst_no').textContent   = 'Installment #' + (json.next_installment_no ?? '-');
        document.getElementById('bi_end_date').textContent  = json.installment_end_date ?? '-';
        document.getElementById('bi_total').textContent     = fmt(json.total_amount);
        document.getElementById('bi_paid').textContent      = fmt(json.paid_amount);
        document.getElementById('bi_balance').textContent   = fmt(json.balance_amount);
        bondInfoCard.style.display = '';

        // witnesses
        witnessesTbody.innerHTML = '';
        const witnesses = json.witnesses || [];
        if(witnesses.length > 0){
            witnesses.forEach(function(w){
                const tr = document.createElement('tr');
                tr.innerHTML = '<td class="ps-3">' + (w.name || '-') + '</td><td>' + (w.mobile || '-') + '</td>';
                witnessesTbody.appendChild(tr);
            });
            bondWitnessesCard.style.display = '';
        } else {
            bondWitnessesCard.style.display = 'none';
        }
    }

    function applyBondData(json){
        araziIdHidden.value   = json.arazi_code ?? '';
        document.getElementById('arazi_label').textContent = json.arazi_label ?? '';
        bondIdInput.value     = json.bond_id ?? '';
        customerIdInput.value = json.customer_id ?? '';
        customerDisplay.value = json.customer_label ?? '';
        populatePlots(json.plots, true);
        if((!json.plots || json.plots.length === 0) && json.land_size){
            landSizeInput.value = json.land_size;
        }
        if(paymentMethod.value === 'cheque' && json.bond_id){
            loadChequesForBond(json.bond_id);
        }
        fillRightPanel(json);
    }

    // ─── Bond No lookup (right panel) ───────────────────────────────────────

    const bondNoInput   = document.getElementById('bond_no_input');
    const bondFindBtn   = document.getElementById('bond_find_btn');
    const bondLookupMsg = document.getElementById('bond_lookup_msg');

    async function lookupByBondNo(){
        const no = bondNoInput.value.trim();
        bondLookupMsg.textContent = '';
        bondInfoCard.style.display = 'none';
        bondWitnessesCard.style.display = 'none';
        if(!no) return;

        bondFindBtn.disabled = true;
        bondFindBtn.textContent = '...';
        try{
            const res  = await fetch(bondByBondNoUrl + '?bond_no=' + encodeURIComponent(no));
            const json = await res.json();
            if(!json.found){
                bondLookupMsg.innerHTML = '<span class="text-danger">' + (json.message || 'Bond not found.') + '</span>';
                return;
            }
            bondLookupMsg.innerHTML = '<span class="text-success">Bond found — fields filled.</span>';
            applyBondData(json);
        }catch(e){
            bondLookupMsg.innerHTML = '<span class="text-danger">Lookup failed.</span>';
        } finally {
            bondFindBtn.disabled = false;
            bondFindBtn.textContent = 'Fill';
        }
    }

    bondFindBtn.addEventListener('click', lookupByBondNo);
    bondNoInput.addEventListener('keydown', function(e){ if(e.key === 'Enter'){ e.preventDefault(); lookupByBondNo(); } });

    // ─── Arazi code lookup (left panel) ─────────────────────────────────────

    async function loadPlotsByCode(araziCode){
        pSelect.innerHTML = '<option value="">Select Plot</option>';
        if(!araziCode) return;
        try{
            const res  = await fetch(araziPlotsByCodeUrl.replace('__ARAZI_CODE__', encodeURIComponent(araziCode)));
            if(!res.ok) return;
            const json = await res.json();
            if(!json.found || !Array.isArray(json.plots)) return;
            populatePlots(json.plots, json.plots.length === 1);
        }catch(e){}
    }

    document.getElementById('arazi_find').addEventListener('click', async function(){
        const code = document.getElementById('arazi_input').value.trim();
        document.getElementById('arazi_label').textContent = '';
        pSelect.innerHTML = '<option value="">Select Plot</option>';
        if(!code) return;
        try{
            const res  = await fetch(araziPlotsByCodeUrl.replace('__ARAZI_CODE__', encodeURIComponent(code)));
            if(!res.ok) return;
            const json = await res.json();
            if(!json.found){
                document.getElementById('arazi_label').textContent = 'Arazi not found';
                return;
            }
            araziIdHidden.value = json.arazi_code || code;
            document.getElementById('arazi_label').textContent = json.arazi_code || code;
            populatePlots(json.plots || [], (json.plots || []).length === 1);
        }catch(e){}
    });

    window.addEventListener('arazi:selected', function(evt){
        const a = evt.detail || {};
        if(!a || !a.id) return;
        document.getElementById('arazi_label').textContent = a.label || '';
        araziIdHidden.value = a.arazi_code || a.label || '';
        loadPlotsByCode(a.arazi_code || a.label || '');
    });

    // ─── Plot select change ──────────────────────────────────────────────────

    pSelect.addEventListener('change', async function(){
        const sel  = this.options[this.selectedIndex];
        const area = sel?.dataset?.area ?? '';
        landSizeInput.value = area || '';

        customerDisplay.value = '';
        customerIdInput.value = '';
        bondIdInput.value = '';
        chequeSelect.innerHTML = '<option value="">Select Cheque</option>';
        chequeContainer.style.display = 'none';
        bondInfoCard.style.display = 'none';
        bondWitnessesCard.style.display = 'none';

        if(!this.value) return;
        try{
            const res  = await fetch(bondByPlotUrl.replace('__PLOT_ID__', encodeURIComponent(this.value)));
            if(!res.ok) return;
            const json = await res.json();
            if(!json.found) return;
            bondIdInput.value     = json.bond_id;
            customerIdInput.value = json.customer_id ?? '';
            customerDisplay.value = json.customer_label ?? '';
            if(paymentMethod.value === 'cheque') loadChequesForBond(json.bond_id);
            fillRightPanel(json);
        }catch(e){}
    });

    // ─── Payment method / cheque handling ───────────────────────────────────

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
            const url  = customerBondChequesUrl.replace('__BOND_ID__', encodeURIComponent(bondId)) + '?status=pending';
            const res  = await fetch(url);
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
                    if(s && s.value){
                        let a = s.dataset.amount || '';
                        if(!a){
                            const m = (s.textContent || '').match(/([\d,]+(?:\.\d+)?)/);
                            if(m) a = m[1].replace(/,/g, '');
                        }
                        if(a !== ''){ amountInput.value = a; amountInput.setAttribute('readonly','readonly'); amountInput.classList.add('bg-light'); }
                        paymentMethod.value = 'cheque'; paymentMethod.setAttribute('disabled','disabled');
                    } else {
                        paymentMethod.removeAttribute('disabled'); paymentMethod.value = 'cash';
                        amountInput.removeAttribute('readonly'); amountInput.classList.remove('bg-light');
                    }
                }catch(e){}
            }
            chequeSelect.addEventListener('change', function(){ handleChequeSelection(this); });
            if(window.jQuery && jQuery.fn.select2){
                try{ jQuery('#cheque_select').on('select2:select select2:unselect', function(){ handleChequeSelection(chequeSelect); }); }catch(e){}
                try{ jQuery('#cheque_select').select2({ theme:'bootstrap-5', width:'100%', placeholder:'Select Cheque', allowClear:true }); }catch(e){}
                try{ jQuery('#taken_by_user_id').select2({ theme:'bootstrap-5', width:'100%', placeholder:'— Select User —', allowClear:false }); }catch(e){}
            }
        }catch(e){}
    }

    // ─── AJAX submit ────────────────────────────────────────────────────────

    const form      = document.getElementById('compact_payment_form');
    const submitBtn = document.getElementById('submit_btn');

    form.addEventListener('submit', async function(ev){
        ev.preventDefault();
        if(!confirm('Save payment?')) return;
        const fd = new FormData(form);
        fd.set('payment_method', paymentMethod.value || 'cash');

        submitBtn.disabled = true; submitBtn.textContent = 'Saving...';
        try{
            const res  = await fetch(form.action, {
                method: 'POST',
                headers: { 'X-Requested-With':'XMLHttpRequest', 'X-CSRF-TOKEN': document.querySelector('meta[name="csrf-token"]').getAttribute('content') },
                body: fd, credentials: 'same-origin'
            });
            const json = await res.json();
            if(res.ok && json.success){
                alert('Payment saved.');
                const chequeId = json.payment?.customer_bond_cheque_id;
                if(chequeId){
                    const opt = Array.from(chequeSelect.options).find(o => o.value == String(chequeId));
                    if(opt){ opt.textContent += ' — Cleared'; opt.disabled = true; }
                }
                try{
                    const entryNo = json.payment?.entry_no || null;
                    if(entryNo){
                        const receiptBase = @json(route('customer-bond-payments.receipt'));
                        window.open(receiptBase + '?entry_no=' + encodeURIComponent(entryNo) + '&print=1', '_blank');
                    }
                }catch(e){}
                // soft reset: keep bond/arazi/customer, clear amount+remarks only
                amountInput.value = ''; document.getElementById('remarks').value = '';
                if(window.jQuery && jQuery.fn.select2){ try{ jQuery('#cheque_select').val(null).trigger('change'); }catch(e){} }
                chequeSelect.innerHTML = '<option value="">Select Cheque</option>';
                chequeContainer.style.display = 'none';
                paymentMethod.removeAttribute('disabled'); paymentMethod.value = 'cash';
                amountInput.removeAttribute('readonly'); amountInput.classList.remove('bg-light');
            } else {
                alert('Save failed: ' + (json.error || 'Unknown error'));
            }
        }catch(e){ alert('Save failed.'); }
        finally { submitBtn.disabled = false; submitBtn.textContent = 'Save Payment'; }
    });

})();
</script>
@endsection
