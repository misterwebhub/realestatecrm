@extends('layouts.app')

@section('content')
    @php
        $isCustomerBondForm = str_contains($title ?? '', 'Customer Bond');
        $isPaymentForm = str_contains($title ?? '', 'Kisan Payment');
        $hasFiles = collect($fields ?? [])->contains(function ($field) { return (($field['type'] ?? 'text') === 'file'); });
        $isAraziForm = str_contains($title ?? '', 'Arazi');
    @endphp
    @if($isAraziForm)
        <script>window.__editingAraziId = '{{ $item->id ?? '' }}';</script>
    @endif
    <!-- Modal for AJAX create (global) -->
    <div class="modal fade" id="ajaxCreateModal" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Create Item</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="text-center py-4">Loading...</div>
                </div>
            </div>
        </div>
    </div>

    <script>
        (function(){
            const modalEl = document.getElementById('ajaxCreateModal');
            if(!modalEl) return;
            const modalBody = modalEl.querySelector('.modal-body');
            const modalInstance = (window.bootstrap && bootstrap.Modal && modalEl) ? bootstrap.Modal.getOrCreateInstance(modalEl) : null;

            function showModal(){
                if(modalInstance && typeof modalInstance.show === 'function'){
                    modalInstance.show();
                }else{
                    modalEl.classList.add('show','d-block');
                    modalEl.style.display = 'block';
                    document.body.classList.add('modal-open');
                }
            }

            function hideModal(){
                if(modalInstance && typeof modalInstance.hide === 'function'){
                    modalInstance.hide();
                }else{
                    modalEl.classList.remove('show','d-block');
                    modalEl.style.display = '';
                    document.body.classList.remove('modal-open');
                }
            }

            document.addEventListener('click', function(e){
                const btn = e.target.closest && (e.target.closest('.btn-new-arazi') || e.target.closest('.btn-new-kisan'));
                if(!btn) return;
                e.preventDefault();
                const url = btn.dataset.createUrl;
                if(!url) return;
                modalBody.innerHTML = '<div class="text-center py-4">Loading...</div>';
                // set modal title based on button
                const title = btn.getAttribute('title') || (btn.classList.contains('btn-new-kisan') ? 'Create Kisan' : 'Create Item');
                const titleEl = modalEl.querySelector('.modal-title');
                if(titleEl) titleEl.textContent = title;
                showModal();
                fetch(url, { headers: { 'Accept': 'application/json' } })
                    .then(async res => {
                        const ct = (res.headers.get('content-type') || '').toLowerCase();
                        if(ct.includes('application/json')) return res.json();
                        const txt = await res.text();
                        return { html: txt };
                    })
                    .then(data => {
                        modalBody.innerHTML = data.html || data;

                        const modalForm = modalBody.querySelector('form');
                        if(!modalForm) return;

                        modalForm.addEventListener('submit', async function(ev){
                            ev.preventDefault();
                            const fd = new FormData(modalForm);
                            const isKisan = btn.classList.contains('btn-new-kisan');
                            const action = modalForm.action || (isKisan ? @json(route('kisans.ajax-store')) : @json(route('arazis.ajax-store')));
                            const token = document.querySelector('meta[name="csrf-token"]')?.getAttribute('content');

                            try{
                                const res = await fetch(action, {
                                    method: 'POST',
                                    headers: {
                                        'X-CSRF-TOKEN': token,
                                        'X-Requested-With': 'XMLHttpRequest'
                                    },
                                    body: fd,
                                    credentials: 'same-origin'
                                });

                                if(res.ok){
                                    const ct = (res.headers.get('content-type') || '').toLowerCase();
                                    if(ct.includes('application/json')){
                                        const json = await res.json();
                                        if(json.success){
                                            const selectName = isKisan ? 'kisan_id' : 'arazi_id';
                                            const select = document.querySelector('select[name="' + selectName + '"]');
                                            const payloadKey = isKisan ? 'kisan' : 'arazi';
                                            if(select && json[payloadKey]){
                                                const opt = document.createElement('option');
                                                opt.value = json[payloadKey].id;
                                                opt.textContent = json[payloadKey].label || json[payloadKey].name || (json[payloadKey].reg_no || '');
                                                opt.selected = true;
                                                select.appendChild(opt);
                                                if(window.jQuery && jQuery.fn.select2) jQuery(select).trigger('change.select2');
                                            }
                                            hideModal();
                                        }else if(json.html){
                                            modalBody.innerHTML = json.html;
                                        }
                                    }else{
                                        const text = await res.text();
                                        modalBody.innerHTML = text;
                                    }
                                }else{
                                    const text = await res.text();
                                    modalBody.innerHTML = text;
                                }
                            }catch(err){
                                modalBody.innerHTML = '<div class="text-danger">An error occurred.</div>';
                            }
                        });
                    }).catch(()=>{
                        modalBody.innerHTML = '<div class="text-danger">Failed to load form.</div>';
                    });
            });
        })();
    </script>

    <div class="card card-outline card-primary">
        <div class="card-body">
            @if($errors->any())
                <div class="alert alert-danger">
                    <ul class="mb-0">
                        @foreach($errors->all() as $error)
                            <li>{{ $error }}</li>
                        @endforeach
                    </ul>
                </div>
            @endif

            <form action="{{ $action }}" method="POST" @if($hasFiles) enctype="multipart/form-data" @endif>
                @csrf
                @if($method !== 'POST')
                    @method($method)
                @endif

                <div class="row g-3">
                    @foreach($fields as $field)
                        @php($value = old($field['name'], $field['value'] ?? data_get($item, $field['name'])))
                        @if(($field['type'] ?? '') === 'hidden')
                            <input type="hidden" name="{{ $field['name'] }}" id="{{ $field['name'] }}" value="{{ $value }}">
                            @continue
                        @endif
                        <div class="col-md-6">
                            <label class="form-label" for="{{ $field['name'] }}">
                                {{ $field['label'] }}
                                @if(!empty($field['required']))
                                    <span class="text-danger">*</span>
                                @endif
                            </label>

                            @if(($field['type'] ?? 'text') === 'textarea')
                                <textarea
                                    id="{{ $field['name'] }}"
                                    name="{{ $field['name'] }}"
                                    class="form-control"
                                    rows="4"
                                    @if(!empty($field['required'])) required @endif
                                >{{ $value }}</textarea>
                            @elseif(($field['type'] ?? 'text') === 'readonly_text')
                                <input
                                    type="text"
                                    id="{{ $field['name'] }}"
                                    class="form-control bg-light"
                                    value="{{ $value }}"
                                    readonly
                                    tabindex="-1"
                                    autocomplete="off"
                                >
                                @if(!empty($field['help']))
                                    <div class="form-text">{{ $field['help'] }}</div>
                                @endif
                            @elseif(($field['type'] ?? 'text') === 'select')
                                <div class="d-flex align-items-center gap-2">
                                    <select id="{{ $field['name'] }}" name="{{ $field['name'] }}" class="form-select" @if(!empty($field['required'])) required @endif>
                                        <option value="">Select {{ $field['label'] }}</option>
                                        @foreach($field['options'] ?? [] as $optionValue => $optionLabel)
                                            <option value="{{ $optionValue }}" @selected((string) $value === (string) $optionValue)>{{ $optionLabel }}</option>
                                        @endforeach
                                    </select>
                                    @if(($field['name'] ?? '') === 'arazi_id')
                                        <a href="#" class="btn btn-outline-primary btn-sm btn-new-arazi" data-create-url="{{ route('arazis.create-fragment') }}" title="Create new Arazi">New</a>
                                    @endif
                                    @if(($field['name'] ?? '') === 'kisan_id')
                                        <a href="#" class="btn btn-outline-primary btn-sm btn-new-kisan" data-create-url="{{ route('kisans.create-fragment') }}" title="Create new Kisan">New</a>
                                    @endif
                                </div>
                            @elseif(($field['type'] ?? 'text') === 'multiselect')
                                @php($selectedValues = collect(is_array($value) ? $value : (filled($value) ? [$value] : []))->map(fn ($v) => (string) $v)->all())
                                <select id="{{ $field['name'] }}" name="{{ $field['name'] }}[]" class="form-select" multiple size="{{ $field['size'] ?? 6 }}" @if(!empty($field['required'])) required @endif>
                                    @foreach($field['options'] ?? [] as $optionValue => $optionLabel)
                                        <option value="{{ $optionValue }}" @selected(in_array((string) $optionValue, $selectedValues, true))>{{ $optionLabel }}</option>
                                    @endforeach
                                </select>
                                @if(!empty($field['help']))
                                    <div class="form-text">{{ $field['help'] }}</div>
                                @endif
                            @elseif(($field['type'] ?? 'text') === 'file')
                                <input
                                    id="{{ $field['name'] }}"
                                    name="{{ $field['name'] }}"
                                    type="file"
                                    class="form-control"
                                    @if(!empty($field['accept'])) accept="{{ $field['accept'] }}" @endif
                                    @if(!empty($field['required'])) required @endif
                                >
                            @else
                                <input
                                    id="{{ $field['name'] }}"
                                    name="{{ $field['name'] }}"
                                    type="{{ $field['type'] ?? 'text' }}"
                                    value="{{ $value }}"
                                    class="form-control"
                                    @if(isset($field['step'])) step="{{ $field['step'] }}" @endif
                                    @if(isset($field['placeholder'])) placeholder="{{ $field['placeholder'] }}" @endif
                                    @if(!empty($field['required'])) required @endif
                                    @if(!empty($field['readonly'])) readonly @endif
                                >
                            @endif

                            <!-- @if(($field['name'] ?? '') === 'sale_amount_per_gaz')
                                <div class="form-text" id="sale-amount-info" style="margin-top:0.5rem;">
                                    <small><span id="sale-amount-bond">Bond: —</span>
                                    <button type="button" class="btn btn-sm btn-link p-0 ms-2" id="sale-amount-apply">Use bond</button></small>
                                </div>
                            @endif -->
                        </div>
                    @endforeach
                </div>

                <div class="mt-4 d-flex gap-2 align-items-center">
                    <div class="form-check me-auto">
                        @if($isPaymentForm)
                            <input class="form-check-input" type="checkbox" value="1" id="autoPrint" name="print" checked>
                            <label class="form-check-label small" for="autoPrint">Print receipt after save</label>
                        @endif
                    </div>
                    <div class="d-flex gap-2">
                        <button type="submit" class="btn btn-primary">Save</button>
                        <a href="{{ url()->previous() }}" class="btn btn-outline-secondary">Cancel</a>
                        @if($isCustomerBondForm)
                            <button type="button" class="btn btn-outline-secondary" id="backBtn">Back</button>
                        @endif
                    </div>
                </div>
            </form>
        </div>
    </div>
    @if($isCustomerBondForm)
    <script>
        (function(){
            const kisanArazisUrl = @json(route('kisans.arazis', ['kisan' => '__KISAN_ID__']));

            // if there is a kisan select and an arazi select, fetch arazis when kisan changes
            const kisanSelect = document.querySelector('select[name="kisan_id"]');
            const araziSelect = document.querySelector('select[name="arazi_id"]');
            if(kisanSelect && araziSelect){
                kisanSelect.addEventListener('change', async function(){
                    const kisanId = this.value;
                    // clear arazi options
                    araziSelect.innerHTML = '<option value="">Select Arazi</option>';
                    if(!kisanId) return;
                    try{
                        const res = await fetch(kisanArazisUrl.replace('__KISAN_ID__', encodeURIComponent(kisanId)));
                        if(!res.ok) return;
                        const data = await res.json();
                        if(!Array.isArray(data)) return;
                        data.forEach(function(a){
                            const opt = document.createElement('option');
                            opt.value = a.id;
                            opt.textContent = a.label;
                            araziSelect.appendChild(opt);
                        });
                    }catch(e){}
                });
            }
            const back = document.getElementById('backBtn');
            if(!back) return;
            back.addEventListener('click', function(){
                try{
                    if(window.opener && !window.opener.closed){
                        window.close();
                        return;
                    }
                }catch(e){}
                history.back();
            });
        })();
    </script>
    <script>
        (function(){
            // Only run on Arazi form when editing an existing Arazi
            var araziId = window.__editingAraziId || '';
            if(!araziId) return;

            var bondInfoUrl = @json(route('arazis.bond-info', ['arazi' => '__ARAZI_ID__']));
            var sizeInput = document.getElementById('size');
            var roadInput = document.getElementById('road_area');
            var saleInput = document.getElementById('sale_amount_per_gaz');
            if(!saleInput) return;

            var userEdited = false;
            saleInput.addEventListener('input', function(){ userEdited = true; });
            var lastPivot = null;
            var lastBond = null;
            var infoSpan = document.getElementById('sale-amount-bond');
            var applyBtn = document.getElementById('sale-amount-apply');

            function updateInfo(pivot, bond){
                lastPivot = pivot || null;
                lastBond = bond || null;
                if(infoSpan){
                    if(pivot || bond){
                        var bondNo = bond?.bond_no || '-';
                        var bondDate = bond?.bond_date || '';
                        var saleAmt = pivot?.sale_amount ?? bond?.sale_amount ?? null;
                        var perGaz = null;
                        var denom = saleableArea();
                        if(pivot && pivot.sale_rate) perGaz = parseFloat(pivot.sale_rate);
                        else if(saleAmt !== null && denom > 0) perGaz = parseFloat(saleAmt) / denom;
                        var disp = 'Bond: ' + bondNo + (bondDate ? (' (' + bondDate + ')') : '');
                        if(saleAmt !== null) disp += ' — Amount: ₹' + Number(saleAmt).toLocaleString();
                        if(perGaz !== null) disp += ' — per Gaz: ₹' + Number(perGaz).toFixed(2);
                        infoSpan.textContent = disp;
                    } else {
                        infoSpan.textContent = 'Bond: —';
                    }
                }
            }

            if(applyBtn){
                applyBtn.addEventListener('click', function(){
                    if(lastPivot){
                        // force apply even if user edited
                        tryApplyFromPivot(lastPivot, true);
                    }
                });
            }

            function saleableArea(){
                var size = parseFloat(sizeInput?.value || '0') || 0;
                var road = parseFloat(roadInput?.value || '0') || 0;
                var val = size - road;
                return val > 0 ? val : 0;
            }

            function tryApplyFromPivot(pivot, force){
                if(!pivot) return;
                if(!force && userEdited) return; // don't overwrite manual edits unless forced
                var saleAmount = parseFloat(pivot.sale_amount || 0) || 0;
                var denom = saleableArea();
                if(denom <= 0) return;
                var perGaz = saleAmount / denom;
                if(isFinite(perGaz) && perGaz > 0){
                    saleInput.value = perGaz.toFixed(2);
                }
            }

            async function fetchBondAndApply(){
                try{
                    var res = await fetch(bondInfoUrl.replace('__ARAZI_ID__', encodeURIComponent(araziId)), { headers: { 'Accept': 'application/json' } });
                    if(!res.ok) return;
                    var json = await res.json();
                    if(!json.found) return;
                    var pivot = json.pivot || null;
                    // update info display
                    updateInfo(pivot, json.bond || null);
                    // apply only if sale input is empty
                    if((!saleInput.value || saleInput.value.trim() === '') && !userEdited){
                        tryApplyFromPivot(pivot, false);
                    }
                }catch(e){}
            }

            // on load try to fetch pivot and apply
            document.addEventListener('DOMContentLoaded', function(){
                fetchBondAndApply();
            });

            // recompute when size/road change if user hasn't edited manually
            [sizeInput, roadInput].forEach(function(inp){
                if(!inp) return;
                inp.addEventListener('input', function(){
                    if(userEdited) return;
                    // try to fetch and apply again (in case denom changed)
                    fetchBondAndApply();
                });
            });
        })();
    </script>
    @endif
    <script>
        (function(){
            const form = document.querySelector('form');

            if(form){
                form.addEventListener('submit', function(event){
                    let firstInvalid = null;

                    form.querySelectorAll('[required]').forEach(function(field){
                        field.classList.remove('is-invalid');
                        if(field.nextElementSibling && field.nextElementSibling.classList.contains('select2')){
                            field.nextElementSibling.classList.remove('is-invalid');
                        }

                        if(!field.value){
                            field.classList.add('is-invalid');
                            if(field.nextElementSibling && field.nextElementSibling.classList.contains('select2')){
                                field.nextElementSibling.classList.add('is-invalid');
                            }
                            firstInvalid = firstInvalid || field;
                        }
                    });

                    if(firstInvalid){
                        event.preventDefault();
                        firstInvalid.focus();
                        firstInvalid.reportValidity();
                    }
                });

                form.querySelectorAll('[required]').forEach(function(field){
                    field.addEventListener('change', function(){
                        if(field.value){
                            field.classList.remove('is-invalid');
                            if(field.nextElementSibling && field.nextElementSibling.classList.contains('select2')){
                                field.nextElementSibling.classList.remove('is-invalid');
                            }
                        }
                    });
                });
            }

            async function readJsonSafe(res){
                try{
                    const ct = (res.headers.get('content-type') || '').toLowerCase();
                    if(ct.includes('application/json')) return await res.json();
                    return null;
                }catch(e){
                    return null;
                }
            }

            const kisanBondsUrl = @json(route('kisans.bonds', ['kisan' => '__KISAN_ID__']));
            const customerBondsUrl = @json(route('customers.bonds', ['customer' => '__CUSTOMER_ID__']));
            const kisanPaymentKisanSelect = document.querySelector('select[name="kisan_id"]');
            const kisanPaymentBondSelect = document.querySelector('select[name="kisan_bond_id"]');
            const customerPaymentCustomerSelect = document.querySelector('select[name="customer_id"]');
            const customerPaymentBondSelect = document.querySelector('select[name="customer_bond_id"]');

            if(window.jQuery && jQuery.fn.select2){
                jQuery('select[name="kisan_id"], select[name="kisan_bond_id"], select[name="customer_id"], select[name="customer_bond_id"]').select2({
                    theme: 'bootstrap-5',
                    width: '100%'
                });
            }

            async function loadKisanBonds(kisanId, selectedBondId){
                if(!kisanPaymentBondSelect) return;

                kisanPaymentBondSelect.innerHTML = '<option value="">Select Kisan Bond</option>';
                if(!kisanId){
                    if(window.jQuery && jQuery.fn.select2) jQuery(kisanPaymentBondSelect).trigger('change.select2');
                    return;
                }

                try{
                    const res = await fetch(kisanBondsUrl.replace('__KISAN_ID__', encodeURIComponent(kisanId)));
                    if(!res.ok) return;
                    const data = await readJsonSafe(res);
                    if(!Array.isArray(data)) return;
                    data.forEach(function(bond){
                        const opt = document.createElement('option');
                        opt.value = bond.id;
                        opt.textContent = bond.label;
                        if(String(bond.id) === String(selectedBondId)) opt.selected = true;
                        kisanPaymentBondSelect.appendChild(opt);
                    });
                    if(window.jQuery && jQuery.fn.select2) jQuery(kisanPaymentBondSelect).trigger('change.select2');
                }catch(e){}
            }

            async function loadCustomerBonds(customerId, selectedBondId){
                if(!customerPaymentBondSelect) return;

                customerPaymentBondSelect.innerHTML = '<option value="">Select Customer Bond</option>';
                if(!customerId){
                    if(window.jQuery && jQuery.fn.select2) jQuery(customerPaymentBondSelect).trigger('change.select2');
                    return;
                }

                try{
                    const res = await fetch(customerBondsUrl.replace('__CUSTOMER_ID__', encodeURIComponent(customerId)));
                    if(!res.ok) return;
                    const data = await readJsonSafe(res);
                    if(!Array.isArray(data)) return;
                    data.forEach(function(bond){
                        const opt = document.createElement('option');
                        opt.value = bond.id;
                        opt.textContent = bond.label;
                        if(String(bond.id) === String(selectedBondId)) opt.selected = true;
                        customerPaymentBondSelect.appendChild(opt);
                    });
                    if(window.jQuery && jQuery.fn.select2) jQuery(customerPaymentBondSelect).trigger('change.select2');
                }catch(e){}
            }

            if(kisanPaymentKisanSelect && kisanPaymentBondSelect){
                const selectedBondId = '{{ old('kisan_bond_id', $item->kisan_bond_id ?? '') }}';
                kisanPaymentKisanSelect.addEventListener('change', function(){
                    loadKisanBonds(this.value, null);
                });

                if(kisanPaymentKisanSelect.value){
                    loadKisanBonds(kisanPaymentKisanSelect.value, selectedBondId);
                }
            }

            if(customerPaymentCustomerSelect && customerPaymentBondSelect){
                const selectedCustomerBondId = '{{ old('customer_bond_id', $item->customer_bond_id ?? '') }}';
                customerPaymentCustomerSelect.addEventListener('change', function(){
                    loadCustomerBonds(this.value, null);
                });

                if(customerPaymentCustomerSelect.value){
                    loadCustomerBonds(customerPaymentCustomerSelect.value, selectedCustomerBondId);
                }
            }

            const araziSaleableUrl = @json(route('arazis.saleable', ['arazi' => '__ARAZI_ID__']));
            const araziPlotsUrl = @json(route('arazis.plots', ['arazi' => '__ARAZI_ID__']));
            const paymentCtxUrl = @json(route('customer-bonds.payment-context', ['customer_bond' => '__BOND_ID__']));
            const hiddenArazi = document.querySelector('input#arazi_id[type="hidden"]');
            const hiddenPlot = document.querySelector('input#plot_id[type="hidden"]');
            const araziDisplayInput = document.getElementById('arazi_display');
            const plotDisplayInput = document.getElementById('plot_display');

            async function applyCustomerBondPaymentContext(bondId){
                if(!bondId || !hiddenArazi){
                    if(araziDisplayInput) araziDisplayInput.value = '';
                    if(plotDisplayInput) plotDisplayInput.value = '';
                    if(hiddenArazi) hiddenArazi.value = '';
                    if(hiddenPlot) hiddenPlot.value = '';
                    return;
                }
                try{
                    const res = await fetch(paymentCtxUrl.replace('__BOND_ID__', encodeURIComponent(bondId)), { headers: { 'Accept': 'application/json' } });
                    if(!res.ok) return;
                    const ctx = await readJsonSafe(res);
                    if(!ctx) return;
                    if(hiddenArazi && ctx.arazi_id !== undefined) hiddenArazi.value = ctx.arazi_id ?? '';
                    if(hiddenPlot){
                        hiddenPlot.value = (ctx.plot_id !== undefined && ctx.plot_id !== null && ctx.plot_id !== '') ? ctx.plot_id : '';
                    }
                    if(araziDisplayInput) araziDisplayInput.value = ctx.arazi_label ?? '';
                    if(plotDisplayInput) plotDisplayInput.value = ctx.plot_summary ?? '';
                    const landSize = document.querySelector('input[name="land_size"]');
                    if(landSize && ctx.land_size !== undefined && ctx.land_size !== null && ctx.land_size !== ''){
                        landSize.value = ctx.land_size;
                    }
                }catch(e){}
            }

            if(customerPaymentBondSelect && hiddenArazi){
                customerPaymentBondSelect.addEventListener('change', function(){
                    applyCustomerBondPaymentContext(this.value);
                });
                if(customerPaymentBondSelect.value){
                    applyCustomerBondPaymentContext(customerPaymentBondSelect.value);
                }
            }

            if(customerPaymentCustomerSelect && hiddenArazi){
                customerPaymentCustomerSelect.addEventListener('change', function(){
                    applyCustomerBondPaymentContext('');
                });
            }

            const select = document.querySelector('select[name="arazi_id"]');
            if(!select){
                return;
            }

            const infoId = 'arazi-saleable-info';
            let info = document.getElementById(infoId);
            if(!info){
                info = document.createElement('div');
                info.id = infoId;
                info.style.marginTop = '0.5rem';
                select.parentNode.appendChild(info);
            }

            async function fetchSaleable(id){
                if(!id){ info.textContent=''; return; }
                try{
                    const res = await fetch(araziSaleableUrl.replace('__ARAZI_ID__', encodeURIComponent(id)));
                    if(!res.ok) throw new Error('Fetch failed');
                    const json = await readJsonSafe(res);
                    if(!json) throw new Error('Invalid response');
                    const total = (json.saleable_total !== undefined) ? json.saleable_total : (json.saleable || 0);
                    const remaining = (json.remaining !== undefined) ? json.remaining : (json.saleable || 0);
                    const totalGaz = (json.saleable_gaz !== undefined) ? json.saleable_gaz : (json.saleable_gaz || 0);
                    const remainingGaz = (json.remaining_gaz !== undefined) ? json.remaining_gaz : (json.saleable_gaz || 0);
                    const unit = json.unit || 'gaz';
                    info.innerHTML = `<small class="text-muted">Saleable: <strong>${totalGaz}</strong> gaz — Available: <strong>${remainingGaz}</strong> gaz</small>`;
                }catch(e){
                    info.textContent = '';
                }
            }

            // load plots for arazi into any plot_id select on the form
            async function loadPlotsInto(araziId, selectedPlotId){
                const plotSelect = document.querySelector('select[name="plot_id"]');
                const landSize = document.querySelector('input[name="land_size"]');
                if(!plotSelect) return;
                plotSelect.innerHTML = '<option value="">Select Plot</option>';
                if(!araziId) return;
                try{
                    const res = await fetch(araziPlotsUrl.replace('__ARAZI_ID__', encodeURIComponent(araziId)));
                    if(!res.ok) return;
                    const data = await res.json();
                    data.forEach(function(p){
                        const opt = document.createElement('option');
                        opt.value = p.id;
                        opt.textContent = p.label;
                        if(p.area !== undefined) opt.dataset.area = p.area;
                        if(String(p.id) === String(selectedPlotId)) opt.selected = true;
                        plotSelect.appendChild(opt);
                    });
                    const sel = plotSelect.options[plotSelect.selectedIndex];
                    if(sel && sel.dataset && sel.dataset.area) landSize.value = sel.dataset.area;
                }catch(e){ }
            }

            // initial
            fetchSaleable(select.value);

            // if there's an arazi select on the page, also wire plot loading
            const plotSelect = document.querySelector('select[name="plot_id"]');
            const selectedPlot = plotSelect ? '{{ old('plot_id', $item->plot_id ?? '') }}' : null;

            // initial load for plots
            if(select.value){
                loadPlotsInto(select.value, selectedPlot);
            }

            select.addEventListener('change', function(){
                fetchSaleable(this.value);
                loadPlotsInto(this.value, null);
            });

            if(plotSelect){
                plotSelect.addEventListener('change', function(){
                    const opt = this.options[this.selectedIndex];
                    const landSize = document.querySelector('input[name="land_size"]');
                    if(opt && opt.dataset && opt.dataset.area) landSize.value = opt.dataset.area;
                });
            }
        })();
    </script>
@endsection
