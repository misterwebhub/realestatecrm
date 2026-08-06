@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">
  
    <div class="card-body">
        <form action="{{ $action }}" method="POST" enctype="multipart/form-data">
            @csrf
            @if($method === 'PUT')
                @method('PUT')
            @endif

            @if($errors->any())
                <div class="alert alert-danger">
                    <ul class="mb-0">
                        @foreach($errors->all() as $error)
                            <li>{{ $error }}</li>
                        @endforeach
                    </ul>
                </div>
            @endif

            {{-- Main Info --}}
            <h6 class="fw-bold text-muted mt-2 mb-3 border-bottom pb-1">Registry Information</h6>
            <div class="row g-3">
                <div class="col-md-3">
                    <label class="form-label">Select Arazi</label>
                    @php
                        $selectedAraziCode = old('arazi_code', $item->arazi_code ?? null);
                        $groups = collect($arazis ?? [])->groupBy(function($a){ return $a->legacy_arazi_code ?: ('Arazi-' . $a->id); });
                    @endphp
                    <select id="arazi_select" name="arazi_code" class="form-select">
                        <option value="">-- choose arazi --</option>
                        @foreach($groups as $code => $group)
                            <option value="{{ $code }}" {{ (string)$selectedAraziCode === (string)$code ? 'selected' : '' }}>{{ $code }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-3">
                    <label class="form-label">ARAZI DEED No.</label>
                    <input type="text" id="deed_no_input" name="arazi_deed_no" required
                        @if(! old('arazi_deed_no') && ! $item->arazi_deed_no) readonly @endif
                        class="form-control @error('arazi_deed_no') is-invalid @enderror"
                        value="{{ old('arazi_deed_no', $item->arazi_deed_no) }}">
                    <select id="deed_no_select" name="arazi_deed_no" required disabled
                        class="form-select d-none @error('arazi_deed_no') is-invalid @enderror"></select>
                    <div class="form-text" id="deed_no_hint" style="display:none;">
                        This arazi row was merged — choose which Deed No to use for this registry.
                    </div>
                    @error('arazi_deed_no')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-3">
                    <label class="form-label">NAME DEED No. (select from Kisan)</label>
                    <select id="deed_name_select" name="name_deed_no" required class="form-select @error('name_deed_no') is-invalid @enderror">
                        @if(old('name_deed_no'))
                            <option value="{{ old('name_deed_no') }}" selected>{{ old('name_deed_no') }}</option>
                        @elseif($item->name_deed_no)
                            <option value="{{ $item->name_deed_no }}" selected>{{ $item->name_deed_no }}</option>
                        @endif
                    </select>
                    @error('name_deed_no')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-3">
                    <label class="form-label">Registry Date</label>
                          <input type="date" name="registry_date" required class="form-control @error('registry_date') is-invalid @enderror"
                              value="{{ old('registry_date', $item->registry_date?->format('Y-m-d')) }}">
                    @error('registry_date')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-3">
                    <label class="form-label">Total GAZ</label>
                          <input type="number" step="0.01" name="total_gaz" required class="form-control @error('total_gaz') is-invalid @enderror"
                              value="{{ old('total_gaz', $item->total_gaz) }}">
                    <div class="form-text" id="arazi_area_hint" style="display:none;">
                        Arazi area — Saleable: <strong id="hint_saleable">0</strong> gaz &middot; Remaining: <strong id="hint_remaining">0</strong> gaz
                    </div>
                    @error('total_gaz')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-3">
                    <label class="form-label">ROAD LAND (GAJ)</label>
                          <input type="number" step="0.01" name="road_land_gaj" required class="form-control @error('road_land_gaj') is-invalid @enderror"
                              value="{{ old('road_land_gaj', $item->road_land_gaj) }}">
                    @error('road_land_gaj')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <input type="hidden" id="sale_by_input" name="sale_by" value="{{ old('sale_by', $item->sale_by) }}">
            </div>

            {{-- BUY BY (Buyers) — dynamic rows --}}
            <h6 class="fw-bold text-muted mt-4 mb-2 border-bottom pb-1">BUY BY (Buyers)</h6>
            @php
                $partnerOptions = collect($partners ?? []);
                $oldBuyers = old('buyers');
                if (is_array($oldBuyers)) {
                    $buyerRows = array_values($oldBuyers);
                } elseif (!empty($item->buyers) && count($item->buyers)) {
                    $buyerRows = $item->buyers->map(fn($b) => ['partner_id' => $b->partner_id, 'area' => $b->area])->all();
                } else {
                    $buyerRows = [['partner_id' => '', 'area' => '']];
                }
            @endphp
            @error('buyers')<div class="alert alert-danger py-2">{{ $message }}</div>@enderror
            <div class="d-flex flex-wrap gap-3 mb-2" style="font-size:13px;">
                <span>Saleable (Total − Road): <strong id="buyers_saleable">0</strong> gaz</span>
                <span>Allocated: <strong id="buyers_allocated">0</strong> gaz</span>
                <span>Remaining: <strong id="buyers_remaining" class="text-success">0</strong> gaz</span>
            </div>
            <div id="buyers_container">
                @foreach($buyerRows as $bi => $row)
                <div class="row g-2 align-items-end buyer-row mb-2">
                    <div class="col-md-5">
                        @if($bi === 0)<label class="form-label">Partner</label>@endif
                        <select name="buyers[{{ $bi }}][partner_id]" class="form-select buyer-partner" required>
                            <option value="">-- select partner --</option>
                            @foreach($partnerOptions as $p)
                                <option value="{{ $p->id }}" {{ (string)($row['partner_id'] ?? '') === (string)$p->id ? 'selected' : '' }}>{{ $p->name }}</option>
                            @endforeach
                        </select>
                    </div>
                    <div class="col-md-4">
                        @if($bi === 0)<label class="form-label">Area to sell (gaz)</label>@endif
                        <input type="number" step="0.01" min="0" name="buyers[{{ $bi }}][area]" class="form-control buyer-area" value="{{ $row['area'] ?? '' }}" required>
                    </div>
                    <div class="col-md-3">
                        <button type="button" class="btn btn-outline-danger btn-remove-buyer"><i class="bi bi-trash"></i> Remove</button>
                    </div>
                </div>
                @endforeach
            </div>
            <button type="button" id="add_buyer_btn" class="btn btn-outline-primary btn-sm mt-1">
                <i class="bi bi-plus-lg"></i> Add Buyer
            </button>

            {{-- Registry File --}}
            <h6 class="fw-bold text-muted mt-4 mb-3 border-bottom pb-1">Upload Registry Document</h6>
            <div class="row g-3">
                <div class="col-md-6">
                    <label class="form-label">Registry File</label>
                    <input type="file" name="registry_file" @if($method !== 'PUT') required @endif class="form-control @error('registry_file') is-invalid @enderror">
                    @error('registry_file')<div class="invalid-feedback">{{ $message }}</div>@enderror
                    @if($item->registry_file_name)
                        <div class="form-text text-success mt-1">
                            <i class="bi bi-paperclip"></i> Current file: <strong>{{ $item->registry_file_name }}</strong>
                            &nbsp;<a href="{{ route('kisan-registries.download', $item) }}" class="btn btn-xs btn-outline-secondary btn-sm py-0 px-1">Download</a>
                        </div>
                    @endif
                </div>
            </div>

            {{-- Registry Expenses --}}
            <h6 class="fw-bold text-muted mt-4 mb-3 border-bottom pb-1">Registry Expenses</h6>
            <div class="row g-3">
                <div class="col-md-2">
                    <label class="form-label">STAMP</label>
                          <input type="number" step="0.01" name="stamp" required class="form-control @error('stamp') is-invalid @enderror"
                              value="{{ old('stamp', $item->stamp ?? 0) }}">
                    @error('stamp')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-2">
                    <label class="form-label">REGISTRAR FEES</label>
                          <input type="number" step="0.01" name="registrar_fees" required class="form-control @error('registrar_fees') is-invalid @enderror"
                              value="{{ old('registrar_fees', $item->registrar_fees ?? 0) }}">
                    @error('registrar_fees')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-2">
                    <label class="form-label">KHASRA</label>
                          <input type="number" step="0.01" name="khasra" required class="form-control @error('khasra') is-invalid @enderror"
                              value="{{ old('khasra', $item->khasra ?? 0) }}">
                    @error('khasra')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-2">
                    <label class="form-label">COMMISSION</label>
                          <input type="number" step="0.01" name="commission" required class="form-control @error('commission') is-invalid @enderror"
                              value="{{ old('commission', $item->commission ?? 0) }}">
                    @error('commission')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-2">
                    <label class="form-label">BROKARI</label>
                          <input type="number" step="0.01" name="brokari" required class="form-control @error('brokari') is-invalid @enderror"
                              value="{{ old('brokari', $item->brokari ?? 0) }}">
                    @error('brokari')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-4">
                    <label class="form-label">Broker Name</label>
                          <input type="text" name="broker_name" required class="form-control @error('broker_name') is-invalid @enderror"
                              value="{{ old('broker_name', $item->broker_name) }}">
                    @error('broker_name')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
            </div>

            <div class="mt-4 d-flex gap-2">
                <button type="submit" class="btn btn-primary">
                    <i class="bi bi-save"></i> Save Registry
                </button>
                <a href="{{ route('kisan-registries.index') }}" class="btn btn-outline-secondary">
                    <i class="bi bi-x-lg"></i> Cancel
                </a>
            </div>
        </form>
    </div>
</div>
@endsection

@push('scripts')
<script>
    (function(){
        const araziSelect = document.getElementById('arazi_select');
        const deedName = $('#deed_name_select');
        const araziInfoUrl = @json(route('arazis.info', ['arazi' => '__ARAZI_ID__']));

        // Show the arazi's saleable/remaining area as a hint (total_gaz is filled manually).
        function updateAraziAreaHint(info){
            const hint = document.getElementById('arazi_area_hint');
            if(!hint || !info) return;
            const saleable  = info.saleable_total_gaz ?? 0;
            const remaining = info.remaining_gaz ?? saleable;
            try{ document.getElementById('hint_saleable').textContent = saleable; }catch(e){}
            try{ document.getElementById('hint_remaining').textContent = remaining; }catch(e){}
            hint.style.display = '';
        }

        // ARAZI DEED No. resolution for the currently picked arazi row (i.e.
        // one specific kisan's share): if that row was folded into a Deed
        // Merging, offer a dropdown to pick between the Merged Deed No and
        // the plain Deed No (merged is the default). Otherwise, if a plain
        // Deed No mapping exists, auto-fill it and lock the field read-only
        // — there is nothing to choose. If neither exists, fall back to a
        // free-text field so the row can still be registered manually.
        function applyDeedNoOptions(info){
            info = info || {};
            const deedNo = (info.deed_no || '').trim();
            const mergedDeedNo = (info.merged_deed_no || '').trim();
            const input = document.getElementById('deed_no_input');
            const select = document.getElementById('deed_no_select');
            const hint = document.getElementById('deed_no_hint');
            if(!input || !select) return;

            if(mergedDeedNo){
                select.innerHTML = '';
                const addOpt = function(val, label){
                    const o = document.createElement('option');
                    o.value = val; o.textContent = label;
                    select.appendChild(o);
                };
                addOpt(mergedDeedNo, 'Merged Deed No: ' + mergedDeedNo);
                if(deedNo && deedNo !== mergedDeedNo){ addOpt(deedNo, 'Deed No: ' + deedNo); }
                select.value = mergedDeedNo;
                select.disabled = false;
                select.classList.remove('d-none', 'is-invalid');
                input.classList.add('d-none');
                input.disabled = true;
                input.required = false;
                select.required = true;
                if(hint) hint.style.display = '';
            } else {
                input.value = deedNo;
                input.readOnly = !!deedNo;
                input.disabled = false;
                input.required = true;
                input.classList.remove('d-none');
                select.disabled = true;
                select.required = false;
                select.classList.add('d-none');
                if(hint) hint.style.display = 'none';
            }
        }

        // Auto-select the Partner on the first Buyer row from this arazi
        // row's mapped/merged partner — but only if the user hasn't already
        // picked one, so it never clobbers a manual choice.
        function autoSelectPartner(partnerId){
            if(!partnerId) return;
            try{
                const firstPartnerSelect = document.querySelector('.buyer-partner');
                if(firstPartnerSelect && !firstPartnerSelect.value){
                    firstPartnerSelect.value = String(partnerId);
                    firstPartnerSelect.dispatchEvent(new Event('change', { bubbles: true }));
                }
            }catch(e){}
        }

        function resetKisanSelects(){
            try{ deedName.empty().append('<option></option>').val(null).trigger('change'); }catch(e){}
        }

        function populateKisans(list){
            resetKisanSelects();
            if(!list || !list.length) return;
            for(const k of list){
                const optName = $('<option>').val(k.name).text(k.name);
                deedName.append(optName);
            }
            // If exactly one kisan is available, auto-select it and copy to sale_by
            try{
                if(Array.isArray(list) && list.length === 1){
                    const single = list[0];
                    deedName.val(single.name).trigger('change');
                    try{ $('#sale_by_input').val(single.name); }catch(e){}
                }
            }catch(e){}
        }

        // initialize select2 first so jQuery .on('change') catches both native and Select2 events
        if(window.jQuery && jQuery.fn.select2){
            try{ deedName.select2({ theme: 'bootstrap-5', width: '100%', placeholder: 'Select Deed Name', allowClear: true }); }catch(e){}
            try{
                jQuery('#arazi_select').select2({
                    theme: 'bootstrap-5',
                    width: '100%',
                    placeholder: '-- choose arazi --',
                    allowClear: true
                });
            }catch(e){}
        }

        // Use jQuery .on('change') — fires exactly once whether user picks from Select2 or native select
        $(araziSelect).on('change', function(){
            const val = $(this).val();
            if(!val){ araziSelect.dataset.resolvedAraziId=''; araziSelect.dataset.resolvedForValue=''; resetKisanSelects(); return; }

            // If user re-selects the same grouped option already resolved from modal — skip modal
            if(araziSelect.dataset.resolvedAraziId && araziSelect.dataset.resolvedForValue === val){
                const rid = araziSelect.dataset.resolvedAraziId;
                $.getJSON("{{ route('ajax.kisans.by-arazi') }}", { arazi_code: val })
                    .done(function(data){ populateKisans(data || []); })
                    .fail(function(){ resetKisanSelects(); });
                (async function(){
                    try{
                        const res = await fetch(araziInfoUrl.replace('__ARAZI_ID__', encodeURIComponent(rid)));
                        if(!res.ok) return;
                        const info = await res.json();
                        if(info){
                            try{ applyDeedNoOptions(info); }catch(e){}
                            try{ autoSelectPartner(info.partner_id); }catch(e){}
                            try{ updateAraziAreaHint(info); }catch(e){}
                            try{ document.querySelector('input[name="road_land_gaj"]').value = info.road_area ?? 0; }catch(e){}
                        }
                    }catch(e){}
                })();
                return;
            }

            // New/different selection — clear stale resolved data
            araziSelect.dataset.resolvedAraziId = '';
            araziSelect.dataset.resolvedForValue = '';

            // Lookup by arazi code — val IS the legacy_arazi_code (option value = code)
            const code = val || '';
            if(code){
                (async function(){
                    try{
                        const res = await fetch("{{ route('arazis.by-code') }}?code=" + encodeURIComponent(code));
                        if(!res.ok) return;
                        const json = await res.json();
                        if(json.found && Array.isArray(json.matches) && json.matches.length > 0){
                            try{ showAraziMatches(json.matches); }catch(e){}
                            return;
                        }
                        const araziId = (json.found && json.arazi_id) ? json.arazi_id : null;
                        $.getJSON("{{ route('ajax.kisans.by-arazi') }}", { arazi_code: code })
                            .done(function(data){ populateKisans(data || []); })
                            .fail(function(){ resetKisanSelects(); });
                        // The single-match lookup already carries this row's deed/merge info.
                        try{ applyDeedNoOptions(json); }catch(e){}
                        try{ autoSelectPartner(json.partner_id); }catch(e){}
                        const infoRes = await fetch(araziInfoUrl.replace('__ARAZI_ID__', encodeURIComponent(araziId)));
                        if(infoRes && infoRes.ok){
                            const info = await infoRes.json();
                            if(info){
                                try{ updateAraziAreaHint(info); }catch(e){}
                                try{ document.querySelector('input[name="road_land_gaj"]').value = info.road_area ?? 0; }catch(e){}
                            }
                        }
                    }catch(e){}
                })();
            }
        });

        // When user selects a Name on Deed, copy it to Sale By (seller)
        $('#deed_name_select').on('change', function(){
            try{ $('#sale_by_input').val($(this).val()); }catch(e){}
        });

        // On page load (edit): fetch kisans directly by saved arazi_code — never open modal on load
        @if(!empty($item->arazi_code))
        (function(){
            const savedCode = @json((string)($item->arazi_code));
            const savedVal = araziSelect ? araziSelect.value : '';
            // Pre-mark as resolved so any subsequent re-selection also skips the modal
            if(araziSelect){
                araziSelect.dataset.resolvedAraziId = savedCode;
                araziSelect.dataset.resolvedForValue = savedVal;
            }
            $.getJSON("{{ route('ajax.kisans.by-arazi') }}", { arazi_code: savedCode })
                .done(function(data){
                    populateKisans(data || []);
                    // Re-select saved name_deed_no after kisans are populated
                    const savedName = @json($item->name_deed_no ?? '');
                    if(savedName){ try{ $('#deed_name_select').val(savedName).trigger('change'); }catch(e){} }
                })
                .fail(function(){ resetKisanSelects(); });
        })();
        @elseif(true)
        try{ if(araziSelect && araziSelect.value){ $(araziSelect).trigger('change'); } }catch(e){}
        @endif

        // If a deed name already present, copy it to sale_by on load
        try{ if($('#deed_name_select').val()){ $('#sale_by_input').val($('#deed_name_select').val()); } }catch(e){}

        // handle arazi selection from matches modal
        window.addEventListener('arazi:selected', function(evt){
            const a = evt.detail || {};
            if(!a || !a.id) return;
            try{
                // NOTE: we deliberately do NOT set window.__selectedFromModal / __skipAutoDeedFill
                // here. Those flags used to be consumed by the main arazi_select 'change' handler,
                // but this modal-selection code path never actually fires a real 'change' event
                // (it only syncs Select2's display via 'change.select2', which the plain
                // .on('change', fn) handler below does not receive). That left the flags dangling
                // as "true" until the NEXT time the user picked a different arazi code, at which
                // point the change handler wrongly treated that unrelated selection as if it came
                // from the modal and skipped the "multiple arazi found" popup entirely — e.g.
                // selecting 245 (multi-match) then switching straight to 239 (also multi-match)
                // would not reopen the popup for 239 until the dropdown was cleared first.
                // try to set the grouping option (match by code/label) so UI reflects selected group
                try{
                    const code = String(a.label ?? a.arazi_code ?? '');
                    let matched = false;
                    for(const opt of (araziSelect.options || [])){
                        if(String(opt.value) === code){
                            araziSelect.value = opt.value;
                            // Store resolved arazi ID so re-selecting this option skips the modal
                            araziSelect.dataset.resolvedAraziId = String(a.id);
                            araziSelect.dataset.resolvedForValue = opt.value;
                            // Sync Select2 display without re-triggering change logic
                            try{ jQuery('#arazi_select').trigger('change.select2'); }catch(e){}
                            matched = true;
                            break;
                        }
                    }
                    if(!matched){ /* leave select as-is */ }
                }catch(e){}

                // directly fetch kisans and arazi info for the exact arazi selected in modal
                try{
                    $.getJSON("{{ route('ajax.kisans.by-arazi') }}", { arazi_code: a.arazi_code || a.label })
                        .done(function(data){
                            populateKisans(data || []);
                            // Prefer the exact kisan tied to the row picked in the modal,
                            // when it's actually present in this arazi code's kisan list.
                            if(a.kisan){
                                try{
                                    const names = deedName.find('option').map(function(){ return this.value; }).get();
                                    if(names.indexOf(a.kisan) !== -1){ deedName.val(a.kisan).trigger('change'); }
                                }catch(e){}
                            }
                        })
                        .fail(function(){ resetKisanSelects(); });

                    // The modal row already carries this arazi row's Deed No /
                    // Merged Deed No / Partner — apply them straight away.
                    try{ applyDeedNoOptions(a); }catch(e){}
                    try{ autoSelectPartner(a.partner_id); }catch(e){}

                    (async function(){
                        try{
                            const res = await fetch(araziInfoUrl.replace('__ARAZI_ID__', encodeURIComponent(a.id)));
                            if(!res.ok) return;
                            const info = await res.json();
                            if(info){
                                try{ updateAraziAreaHint(info); }catch(e){}
                                try{ document.querySelector('input[name="road_land_gaj"]').value = info.road_area ?? 0; }catch(e){}
                            }
                        }catch(e){}
                    })();
                }catch(e){}
            }catch(e){}
        });

        // Client-side validation: validate required fields on submit (works for both create and edit)
        try{
            const formEl = document.querySelector('form[action="{{ $action }}"]') || document.querySelector('form');
            if(formEl){
                formEl.addEventListener('submit', function(e){
                    const requiredEls = Array.from(formEl.querySelectorAll('[required]')).filter(el => !el.disabled && el.offsetParent !== null);
                    let firstInvalid = null;
                    requiredEls.forEach(el => {
                        let valid = true;
                        if(el.type === 'file'){
                            valid = el.files && el.files.length > 0;
                        } else if(el.tagName === 'SELECT'){
                            valid = el.value !== '' && el.value !== null;
                        } else {
                            valid = String(el.value || '').trim() !== '';
                        }
                        if(!valid){
                            el.classList.add('is-invalid');
                            let fb = el.parentNode.querySelector('.invalid-feedback');
                            if(!fb){
                                fb = document.createElement('div');
                                fb.className = 'invalid-feedback';
                                fb.textContent = 'This field is required.';
                                el.parentNode.appendChild(fb);
                            }
                            if(!firstInvalid) firstInvalid = el;
                        } else {
                            el.classList.remove('is-invalid');
                            const fb = el.parentNode.querySelector('.invalid-feedback');
                            if(fb && fb.textContent === 'This field is required.') fb.remove();
                        }
                    });
                    if(firstInvalid){
                        e.preventDefault();
                        try{ firstInvalid.scrollIntoView({behavior:'smooth', block:'center'}); firstInvalid.focus(); }catch(e){}
                    }
                }, {capture:false});

                // remove invalid state on input/change
                formEl.addEventListener('input', function(ev){
                    const el = ev.target;
                    if(!el) return;
                    if(el.classList && el.classList.contains('is-invalid')){
                        if(el.type === 'file'){
                            if(el.files && el.files.length > 0){ el.classList.remove('is-invalid'); const fb = el.parentNode.querySelector('.invalid-feedback'); if(fb && fb.textContent === 'This field is required.') fb.remove(); }
                        } else if(String(el.value || '').trim() !== ''){
                            el.classList.remove('is-invalid'); const fb = el.parentNode.querySelector('.invalid-feedback'); if(fb && fb.textContent === 'This field is required.') fb.remove();
                        }
                    }
                }, true);
            }
        }catch(e){}
    })();
</script>
@endpush
@include('partials.arazi_matches_modal')

@push('scripts')
<script>
    (function(){
        const container = document.getElementById('buyers_container');
        const addBtn    = document.getElementById('add_buyer_btn');
        if(!container || !addBtn) return;

        const partnerOptionsHtml = @json(
            '<option value="">-- select partner --</option>' .
            collect($partners ?? [])->map(fn($p) => '<option value="'.$p->id.'">'.e($p->name).'</option>')->implode('')
        );

        const totalGazEl = document.querySelector('input[name="total_gaz"]');
        const roadEl     = document.querySelector('input[name="road_land_gaj"]');
        const saleableEl = document.getElementById('buyers_saleable');
        const allocEl    = document.getElementById('buyers_allocated');
        const remainEl   = document.getElementById('buyers_remaining');

        function num(v){ const n = parseFloat(v); return isNaN(n) ? 0 : n; }

        function reindex(){
            container.querySelectorAll('.buyer-row').forEach(function(row, idx){
                const sel = row.querySelector('.buyer-partner');
                const area = row.querySelector('.buyer-area');
                if(sel)  sel.name  = 'buyers['+idx+'][partner_id]';
                if(area) area.name = 'buyers['+idx+'][area]';
            });
        }

        function recalc(){
            const saleable = Math.max(num(totalGazEl && totalGazEl.value) - num(roadEl && roadEl.value), 0);
            let allocated = 0;
            container.querySelectorAll('.buyer-area').forEach(function(a){ allocated += num(a.value); });
            const remaining = saleable - allocated;

            saleableEl.textContent = (Math.round(saleable*100)/100);
            allocEl.textContent    = (Math.round(allocated*100)/100);
            remainEl.textContent   = (Math.round(remaining*100)/100);
            remainEl.className = remaining < -0.001 ? 'text-danger fw-bold' : 'text-success';

            container.querySelectorAll('.buyer-area').forEach(function(a){
                a.classList.toggle('is-invalid', remaining < -0.001);
            });
        }

        function addRow(){
            const row = document.createElement('div');
            row.className = 'row g-2 align-items-end buyer-row mb-2';
            row.innerHTML =
                '<div class="col-md-5"><select class="form-select buyer-partner" required>'+partnerOptionsHtml+'</select></div>'+
                '<div class="col-md-4"><input type="number" step="0.01" min="0" class="form-control buyer-area" required></div>'+
                '<div class="col-md-3"><button type="button" class="btn btn-outline-danger btn-remove-buyer"><i class="bi bi-trash"></i> Remove</button></div>';
            container.appendChild(row);
            reindex();
            recalc();
        }

        addBtn.addEventListener('click', addRow);

        container.addEventListener('click', function(e){
            const btn = e.target.closest('.btn-remove-buyer');
            if(!btn) return;
            const rows = container.querySelectorAll('.buyer-row');
            if(rows.length <= 1){
                // keep at least one row — just clear it
                const row = btn.closest('.buyer-row');
                row.querySelector('.buyer-partner').value = '';
                row.querySelector('.buyer-area').value = '';
            } else {
                btn.closest('.buyer-row').remove();
            }
            reindex();
            recalc();
        });

        container.addEventListener('input', function(e){
            if(e.target.classList.contains('buyer-area')) recalc();
        });
        if(totalGazEl) totalGazEl.addEventListener('input', recalc);
        if(roadEl)     roadEl.addEventListener('input', recalc);

        // Block submit when buyers exceed saleable area
        const formEl = container.closest('form');
        if(formEl){
            formEl.addEventListener('submit', function(e){
                const saleable = Math.max(num(totalGazEl && totalGazEl.value) - num(roadEl && roadEl.value), 0);
                let allocated = 0;
                container.querySelectorAll('.buyer-area').forEach(function(a){ allocated += num(a.value); });
                if(allocated > saleable + 0.001){
                    e.preventDefault();
                    e.stopImmediatePropagation();
                    recalc();
                    alert('Total buyer area ('+(Math.round(allocated*100)/100)+' gaz) cannot exceed saleable area of '+(Math.round(saleable*100)/100)+' gaz.');
                    remainEl.scrollIntoView({behavior:'smooth', block:'center'});
                }
            }, true);
        }

        recalc();
    })();
</script>
@endpush
