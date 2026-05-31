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
                        $selectedAraziId = old('arazi_id', $item->arazi_id ?? null);
                        $groups = collect($arazis ?? [])->groupBy(function($a){ return $a->legacy_arazi_code ?: ('Arazi-' . $a->id); });
                    @endphp
                    <select id="arazi_select" name="arazi_id" class="form-select">
                        <option value="">-- choose arazi --</option>
                        @foreach($groups as $code => $group)
                            @php $first = $group->first(); @endphp
                            <option value="{{ $first->id }}" data-code="{{ $code }}" {{ (string)$selectedAraziId === (string)$first->id ? 'selected' : '' }}>{{ $code }}</option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-3">
                    <label class="form-label">ARAZI DEED No.</label>
                          <input type="text" id="deed_no_input" name="arazi_deed_no" required class="form-control @error('arazi_deed_no') is-invalid @enderror"
                              value="{{ old('arazi_deed_no', $item->arazi_deed_no) }}">
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
                    @error('total_gaz')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-3">
                    <label class="form-label">ROAD LAND (GAJ)</label>
                          <input type="number" step="0.01" name="road_land_gaj" required class="form-control @error('road_land_gaj') is-invalid @enderror"
                              value="{{ old('road_land_gaj', $item->road_land_gaj) }}">
                    @error('road_land_gaj')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-6">
                    <label class="form-label">BUY BY (Buyer)</label>
                          <input type="text" name="buy_by" required class="form-control @error('buy_by') is-invalid @enderror"
                              value="{{ old('buy_by', $item->buy_by) }}">
                    @error('buy_by')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <input type="hidden" id="sale_by_input" name="sale_by" value="{{ old('sale_by', $item->sale_by) }}">
            </div>

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

            // If selection was made from modal, use that arazi id directly
            if(window.__selectedFromModal){
                window.__selectedFromModal = false;
                $.getJSON("{{ route('ajax.kisans.by-arazi') }}", { arazi_id: val })
                    .done(function(data){ populateKisans(data || []); })
                    .fail(function(){ resetKisanSelects(); });
                (async function(){
                    try{
                        const res = await fetch(araziInfoUrl.replace('__ARAZI_ID__', encodeURIComponent(val)));
                        if(!res.ok) return;
                        const info = await res.json();
                        if(info){
                            if(!window.__skipAutoDeedFill) try{ document.getElementById('deed_no_input').value = info.legacy_arazi_code || ''; }catch(e){}
                            try{ document.querySelector('input[name="total_gaz"]').value = info.remaining_gaz ?? info.saleable_total_gaz ?? ''; }catch(e){}
                            try{ document.querySelector('input[name="road_land_gaj"]').value = info.road_area ?? 0; }catch(e){}
                            window.__skipAutoDeedFill = false;
                        }
                    }catch(e){}
                })();
                return;
            }

            // If user re-selects the same grouped option already resolved from modal — skip modal
            if(araziSelect.dataset.resolvedAraziId && araziSelect.dataset.resolvedForValue === val){
                const rid = araziSelect.dataset.resolvedAraziId;
                $.getJSON("{{ route('ajax.kisans.by-arazi') }}", { arazi_id: rid })
                    .done(function(data){ populateKisans(data || []); })
                    .fail(function(){ resetKisanSelects(); });
                (async function(){
                    try{
                        const res = await fetch(araziInfoUrl.replace('__ARAZI_ID__', encodeURIComponent(rid)));
                        if(!res.ok) return;
                        const info = await res.json();
                        if(info){
                            try{ document.querySelector('input[name="total_gaz"]').value = info.remaining_gaz ?? info.saleable_total_gaz ?? ''; }catch(e){}
                            try{ document.querySelector('input[name="road_land_gaj"]').value = info.road_area ?? 0; }catch(e){}
                        }
                    }catch(e){}
                })();
                return;
            }

            // New/different selection — clear stale resolved data
            araziSelect.dataset.resolvedAraziId = '';
            araziSelect.dataset.resolvedForValue = '';

            // Lookup by arazi code
            const opt = araziSelect.options[araziSelect.selectedIndex];
            const code = opt?.dataset?.code || '';
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
                        const araziId = (json.found && json.arazi_id) ? json.arazi_id : val;
                        $.getJSON("{{ route('ajax.kisans.by-arazi') }}", { arazi_id: araziId })
                            .done(function(data){ populateKisans(data || []); })
                            .fail(function(){ resetKisanSelects(); });
                        const infoRes = await fetch(araziInfoUrl.replace('__ARAZI_ID__', encodeURIComponent(araziId)));
                        if(infoRes && infoRes.ok){
                            const info = await infoRes.json();
                            if(info){
                                try{ document.getElementById('deed_no_input').value = info.legacy_arazi_code || ''; }catch(e){}
                                try{ document.querySelector('input[name="total_gaz"]').value = info.remaining_gaz ?? info.saleable_total_gaz ?? ''; }catch(e){}
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

        // On page load (edit): fetch kisans directly by saved arazi_id — never open modal on load
        @if(!empty($item->arazi_id))
        (function(){
            const savedId = @json((string)($item->arazi_id));
            const savedVal = araziSelect ? araziSelect.value : '';
            // Pre-mark as resolved so any subsequent re-selection also skips the modal
            if(araziSelect){
                araziSelect.dataset.resolvedAraziId = savedId;
                araziSelect.dataset.resolvedForValue = savedVal;
            }
            $.getJSON("{{ route('ajax.kisans.by-arazi') }}", { arazi_id: savedId })
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
                // indicate that auto-filling deed_no should be skipped for this programmatic selection
                window.__skipAutoDeedFill = true;
                window.__selectedFromModal = true;
                // try to set the grouping option (match by code/label) so UI reflects selected group
                try{
                    const code = a.label || '';
                    let matched = false;
                    for(const opt of (araziSelect.options || [])){
                        if(opt.dataset && opt.dataset.code === code){
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

                // directly fetch kisans and arazi info for the exact arazi id selected in modal
                try{
                    $.getJSON("{{ route('ajax.kisans.by-arazi') }}", { arazi_id: a.id })
                        .done(function(data){ populateKisans(data || []); })
                        .fail(function(){ resetKisanSelects(); });

                    (async function(){
                        try{
                            const res = await fetch(araziInfoUrl.replace('__ARAZI_ID__', encodeURIComponent(a.id)));
                            if(!res.ok) return;
                            const info = await res.json();
                            if(info){
                                // do NOT auto-fill deed_no or name_deed_no here
                                try{ document.querySelector('input[name="total_gaz"]').value = info.remaining_gaz ?? info.saleable_total_gaz ?? ''; }catch(e){}
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
