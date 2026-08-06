@php
    $isEdit = isset($item) && $item->exists;
    $action = $action ?? route('registries.store');
    $method = $method ?? 'POST';
@endphp

@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">
    <div class="card-header d-flex align-items-center gap-2">
        <h5 class="card-title mb-0 fw-bold">{{ $isEdit ? 'Edit Registry' : 'New Registry' }}</h5>
        <a href="{{ route('registries.index') }}" class="btn btn-outline-secondary btn-sm ms-auto">
            <i class="bi bi-arrow-left"></i> Back
        </a>
    </div>

    <div class="card-body">

        @if($errors->any())
            <div class="alert alert-danger">
                <ul class="mb-0">@foreach($errors->all() as $e)<li>{{ $e }}</li>@endforeach</ul>
            </div>
        @endif

        {{-- ══════════════════════════════════════════
             SEARCH BAR  (create only)
        ══════════════════════════════════════════ --}}
        @if(!$isEdit)
        <div class="card bg-light border-0 rounded-3 mb-4">
            <div class="card-body py-3">
                <p class="small fw-bold text-muted mb-2 text-uppercase" style="letter-spacing:.05em;">
                    <i class="bi bi-search me-1"></i> Search Bond to Auto-fill
                </p>
                <div class="d-flex gap-2 align-items-center flex-wrap">
                    {{-- <input type="text" id="s_name" class="form-control form-control-sm" placeholder="Name / Phone" style="max-width:160px;"> --}}
                    <input type="text" id="s_arazi"   class="form-control form-control-sm" placeholder="Arazi No"        style="max-width:140px;">
                    <input type="text" id="s_plot"    class="form-control form-control-sm" placeholder="Plot No / Title" style="max-width:160px;">
                    <input type="text" id="s_bond_no" class="form-control form-control-sm" placeholder="Bond No"         style="max-width:140px;">
                    <button type="button" id="searchBondBtn" class="btn btn-primary btn-sm">
                        <i class="bi bi-search"></i> Search
                    </button>
                    <button type="button" id="clearSearchBtn" class="btn btn-outline-secondary btn-sm">Clear</button>
                </div>

                {{-- Search Results --}}
                <div id="searchResults" class="mt-3 d-none">
                    <p class="small fw-semibold text-muted mb-1">Results — click to apply:</p>
                    <div id="resultsList" class="list-group" style="max-height:220px;overflow-y:auto;font-size:13px;"></div>
                </div>
                <div id="searchNoResult" class="mt-3 d-none">
                    <div class="alert alert-warning py-2 mb-0 small">No bond found. Try different keywords.</div>
                </div>
            </div>
        </div>
        @endif

        {{-- ══════════════════════════════════════════
             MAIN FORM
        ══════════════════════════════════════════ --}}
        <form action="{{ $action }}" method="POST" id="registryForm" enctype="multipart/form-data">
            @csrf
            @if($method !== 'POST') @method($method) @endif

            {{-- Hidden system fields --}}
            <input type="hidden" name="receipt_no"        id="h_receipt_no"   value="{{ old('receipt_no', $item->receipt_no ?? '') }}">
            <input type="hidden" name="customer_bond_id"  id="h_bond_id"      value="{{ old('customer_bond_id', '') }}">
            <input type="hidden" name="customer_id"       id="h_customer_id"  value="{{ old('customer_id', $item->customer_id ?? '') }}">
            {{-- Holds the bond's default arazi code; the visible Arazi No dropdown (name="arazi_code") is the submitted value --}}
            <input type="hidden"                          id="h_arazi_code"   value="{{ old('arazi_code', $item->arazi_code ?? '') }}">
            <input type="hidden" name="plot_id"           id="h_plot_id"      value="{{ old('plot_id', $item->plot_id ?? '') }}">
            <input type="hidden" name="registry_amount"   id="h_bond_amount"  value="{{ old('registry_amount', $item->registry_amount ?? '') }}">
            <input type="hidden" name="pending_amount"    id="h_pending"      value="">
            <input type="hidden" name="booking_mode"      value="other">
            <input type="hidden" name="land_size"         value="0">
            <input type="hidden" name="status"            value="pending">
            <input type="hidden" name="payment_status"    value="pending">
            <input type="hidden" name="lock_status"       value="unlock">

            {{-- ── Applied Bond Banner ── --}}
            <div id="bondAppliedBanner" class="alert alert-success d-flex align-items-center gap-3 py-2 mb-3 flex-wrap {{ old('customer_id', $item->customer_id ?? '') ? '' : 'd-none' }}" style="font-size:13px;">
                <i class="bi bi-patch-check-fill text-success fs-5"></i>
                <span><strong>Bond:</strong> <span id="b_bond_no">{{ $item->registry_code ?? '-' }}</span></span>
                <span><strong>Customer:</strong> <span id="b_customer">{{ $item->customer?->name ?? '-' }}</span></span>
                <span><strong>Arazi:</strong> <span id="b_arazi">{{ $item->arazi?->legacy_arazi_code ?? '-' }}</span></span>
                <span><strong>Plot:</strong> <span id="b_plot">{{ $item->plot?->title ?? '-' }}</span></span>
                <button type="button" id="clearBondBtn" class="btn btn-outline-secondary btn-sm py-0 ms-auto">
                    <i class="bi bi-x"></i> Clear
                </button>
            </div>

            @error('customer_id')
                <div class="alert alert-danger py-2 small">Please search and select a bond first. ({{ $message }})</div>
            @enderror
            @error('arazi_code')
                <div class="alert alert-danger py-2 small">{{ $message }}</div>
            @enderror

            {{-- ── Section: Auto-filled Info (read-only display) ── --}}
            <h6 class="fw-bold text-muted mb-3 border-bottom pb-1">Bond Information</h6>
            <div class="row g-3 mb-4">
                <div class="col-md-2">
                    <label class="form-label small fw-semibold">Receipt No</label>
                    <input type="text" class="form-control form-control-sm bg-light" id="d_receipt_no"
                        value="{{ old('receipt_no', $item->receipt_no ?? '') }}" readonly>
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold">Registry Code</label>
                    <input type="text" class="form-control form-control-sm bg-light"
                        value="{{ $isEdit ? ($item->registry_code ?? 'Auto') : 'Auto-generated' }}" readonly>
                </div>
                <div class="col-md-4">
                    <label class="form-label small fw-semibold">Customer Name</label>
                    <input type="text" class="form-control form-control-sm bg-light" id="d_customer_name"
                        value="{{ old('', $item->customer?->name ?? '') }}" readonly placeholder="Auto-filled from search">
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold">Mobile</label>
                    <input type="text" class="form-control form-control-sm bg-light" id="d_mobile"
                        value="{{ $item->customer?->mobile ?? '' }}" readonly placeholder="Auto-filled">
                </div>
                <div class="col-md-3">
                    <label class="form-label small fw-semibold">Alt. Mobile <span class="text-muted">(editable)</span></label>
                    <input type="text" name="secondary_mobile" id="d_alt_mobile"
                        value="{{ old('secondary_mobile', $item->customer?->secondary_mobile ?? '') }}"
                        class="form-control form-control-sm" placeholder="Alternate number">
                </div>
                <div class="col-md-3">
                    <label class="form-label small fw-semibold">Arazi No</label>
                    @php $presetAraziCode = old('arazi_code', $item->arazi_code ?? ($item->arazi?->legacy_arazi_code ?? '')); @endphp
                    <select name="arazi_code" id="arazi_code_select"
                        class="form-select form-select-sm @error('arazi_code') is-invalid @enderror"
                        data-placeholder="Auto-filled from bond">
                        @if($presetAraziCode !== '')
                            <option value="{{ $presetAraziCode }}" selected>{{ $presetAraziCode }}</option>
                        @endif
                    </select>
                    <div class="form-text" id="arazi_group_hint" style="display:none;">Grouped arazis available — you can pick a merged one.</div>
                </div>
                <div class="col-md-3">
                    <label class="form-label small fw-semibold">Partner <span class="text-danger">*</span></label>
                    @php $presetPartnerId = old('partner_id', $item->partner_id ?? ''); @endphp
                    <select name="partner_id" id="partner_id_select" required
                        class="form-select form-select-sm @error('partner_id') is-invalid @enderror"
                        data-preset="{{ $presetPartnerId }}"
                        data-placeholder="Select partner">
                        <option value="">-- select partner --</option>
                        @if($isEdit && $item->partner)
                            <option value="{{ $item->partner->id }}" selected>{{ $item->partner->name }}</option>
                        @endif
                    </select>
                    <div class="form-text" id="partner_hint" style="display:none;"></div>
                    @error('partner_id')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-4">
                    <label class="form-label small fw-semibold">Plots in Bond</label>
                    <div id="d_plots_info" class="form-control form-control-sm bg-light" style="min-height:31px; height:auto; white-space:normal;">
                        @if($isEdit && $item->plot)
                            <span class="badge bg-secondary me-1">{{ $item->plot->title ?? ('Plot-'.$item->plot->id) }}</span>
                        @else
                            <span class="text-muted" style="font-size:12px;">Auto-filled from bond</span>
                        @endif
                    </div>
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold">Bond Amount</label>
                    <input type="text" class="form-control form-control-sm bg-light" id="d_bond_amount"
                        value="{{ $item->registry_amount ? number_format($item->registry_amount,2) : '' }}" readonly placeholder="Auto-filled">
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold">Balance Amount</label>
                    <input type="text" class="form-control form-control-sm bg-light" id="d_pending"
                        value="" readonly placeholder="Auto-filled">
                </div>
            </div>

            {{-- ── Plot Sizes (editable — saved when the form is submitted) ── --}}
            <div class="row mb-4 d-none" id="plotsSizeSection">
                <div class="col-12">
                    <label class="form-label small fw-semibold">
                        Plot Sizes (gaz)
                        <span class="text-muted fw-normal">— editing a value here updates that plot's area when you click Save</span>
                    </label>
                    <table class="table table-sm table-bordered mb-0 bg-white" id="plotsSizeTable">
                        <thead class="table-light">
                            <tr>
                                <th>Plot</th>
                                <th style="width:160px;">Size (gaz)</th>
                            </tr>
                        </thead>
                        <tbody id="plotsSizeBody"></tbody>
                        <tfoot>
                            <tr>
                                <th>Total</th>
                                <th id="plotsSizeTotal">0.00</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>

            <div class="row g-3 mb-2">
                <div class="col-md-2">
                    <label class="form-label small fw-semibold">Registry Date <span class="text-danger">*</span></label>
                    <input type="date" name="registry_date" id="d_registry_date"
                        value="{{ old('registry_date', optional($item->registry_date)->format('Y-m-d') ?? date('Y-m-d')) }}"
                        class="form-control form-control-sm @error('registry_date') is-invalid @enderror">
                    @error('registry_date')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-3">
                    <label class="form-label small fw-semibold">Deed No <span class="text-danger">*</span></label>
                    <select name="deed_no" id="deed_no_select"
                        class="form-select form-select-sm @error('deed_no') is-invalid @enderror"
                        data-placeholder="Select a bond first" required>
                        @php $selectedDeed = old('deed_no', $item->deed_no ?? ''); @endphp
                        <option value=""></option>
                        @if($selectedDeed !== '')
                            <option value="{{ $selectedDeed }}" selected>{{ $selectedDeed }}</option>
                        @endif
                    </select>
                    @error('deed_no')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
                <div class="col-md-2">
                    <label class="form-label small fw-semibold">Circle Value</label>
                    <input type="number" name="circle_value" step="0.01" min="0"
                        value="{{ old('circle_value', $item->circle_value ?? '') }}"
                        class="form-control form-control-sm @error('circle_value') is-invalid @enderror"
                        placeholder="e.g. 50000.00">
                    @error('circle_value')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
            </div>

            {{-- ── Low Payment Warning ── --}}
            <div id="lowPaymentAlert" class="alert alert-warning d-flex align-items-center gap-2 py-2 mb-3 d-none" style="font-size:13px;">
                <i class="bi bi-exclamation-triangle-fill text-warning fs-5"></i>
                <span><strong>Less than 50% paid</strong> — Paid: ₹<span id="w_paid">0</span> out of ₹<span id="w_total">0</span> &nbsp;(<span id="w_pct">0</span>% paid &nbsp;|&nbsp; Balance: ₹<span id="w_bal">0</span>)</span>
            </div>

            {{-- ── Area Converter (reference only — not saved) ── --}}
            <h6 class="fw-bold text-muted mb-2 border-bottom pb-1">Area Converter <small class="text-muted">(for reference only — not saved)</small></h6>
            <div class="row g-2 mb-3" style="max-width:640px;">
                <div class="col-md-4">
                    <label class="form-label small fw-semibold">Value</label>
                    <input type="number" step="any" id="rac_value" class="form-control form-control-sm" placeholder="Enter value">
                </div>
                <div class="col-md-4">
                    <label class="form-label small fw-semibold">From Unit</label>
                    <select id="rac_unit" class="form-select form-select-sm">
                        <option value="gaz">Gaz</option>
                        <option value="marla">Marla</option>
                        <option value="kanal">Kanal</option>
                        <option value="sqft">Sq Ft</option>
                        <option value="m2">Sq Meter</option>
                        <option value="ha">Hectare</option>
                    </select>
                </div>
                <div class="col-md-4">
                    <label class="form-label small fw-semibold">Result (Gaz)</label>
                    <input type="text" id="rac_result" class="form-control form-control-sm bg-light" readonly value="—">
                </div>
            </div>

            {{-- ── Section: Witnesses ── --}}
            <h6 class="fw-bold text-muted mb-2 border-bottom pb-1">Witnesses <span class="text-danger">*</span></h6>
            <div class="mb-2">
                <table class="table table-sm table-bordered align-middle mb-1" style="font-size:13px;max-width:600px;">
                    <thead style="background:#f5f7fa;">
                        <tr>
                            <th style="width:36px;">#</th>
                            <th>Witness Name</th>
                            <th style="width:190px;">Mobile</th>
                            <th style="width:36px;"></th>
                        </tr>
                    </thead>
                    <tbody id="witnessBody">
                        @php
                            $witnessRows = old('witnesses', []);
                            if (empty($witnessRows) && !empty($item->witness_name)) {
                                // Try JSON first, fall back to comma-separated plain text
                                $decoded = json_decode($item->witness_name, true);
                                if (is_array($decoded)) {
                                    $witnessRows = $decoded;
                                } else {
                                    foreach (explode(',', $item->witness_name) as $wn) {
                                        $witnessRows[] = ['name' => trim($wn), 'mobile' => ''];
                                    }
                                }
                            }
                            if (empty($witnessRows)) $witnessRows = [['name'=>'','mobile'=>'']];
                        @endphp
                        @foreach($witnessRows as $wi => $wrow)
                        <tr class="witness-row">
                            <td class="text-muted text-center row-num">{{ $wi + 1 }}</td>
                            <td><input type="text" name="witnesses[{{ $wi }}][name]" value="{{ $wrow['name'] ?? '' }}" class="form-control form-control-sm witness-name-input" placeholder="Full name" required></td>
                            <td><input type="text" name="witnesses[{{ $wi }}][mobile]" value="{{ $wrow['mobile'] ?? '' }}" class="form-control form-control-sm" placeholder="Mobile number"></td>
                            <td class="text-center">
                                <button type="button" class="btn btn-outline-danger btn-sm py-0 px-1 remove-witness" title="Remove">
                                    <i class="bi bi-x-lg"></i>
                                </button>
                            </td>
                        </tr>
                        @endforeach
                    </tbody>
                </table>
            </div>
            <button type="button" id="addWitnessBtn" class="btn btn-outline-primary btn-sm mb-4">
                <i class="bi bi-plus-lg"></i> Add Witness
            </button>

            {{-- ── Registry Document Upload ── --}}
            <h6 class="fw-bold text-muted mb-2 border-bottom pb-1">Registry Document <span class="text-danger">*</span></h6>
            <div class="row g-3 mb-4">
                <div class="col-md-6">
                    <label class="form-label small fw-semibold">Upload Document <span class="text-muted">(PDF / Image)</span></label>
                    <input type="file" name="document" accept=".pdf,.jpg,.jpeg,.png"
                        class="form-control form-control-sm @error('document') is-invalid @enderror"
                        {{ $isEdit && !empty($item->document_path) ? '' : 'required' }}>
                    @error('document')<div class="invalid-feedback">{{ $message }}</div>@enderror
                    @if(!empty($item->document_path))
                        <div class="form-text mt-1">
                            <i class="bi bi-paperclip"></i> Existing file:
                            <a href="{{ route('registries.download', $item->id) }}" target="_blank" class="fw-semibold">View / Download</a>
                            <span class="text-muted ms-1">(upload new to replace)</span>
                        </div>
                    @endif
                </div>
            </div>

            {{-- ── Submit ── --}}
            <div class="d-flex gap-2">
                <button type="submit" class="btn btn-primary px-4">
                    <i class="bi bi-save"></i> {{ $isEdit ? 'Update Registry' : 'Save Registry' }}
                </button>
                <a href="{{ route('registries.index') }}" class="btn btn-outline-secondary">Cancel</a>
            </div>
        </form>

    </div>{{-- /card-body --}}
</div>{{-- /card --}}
@endsection

@push('styles')
<style>
#witnessBody tr:only-child .remove-witness { opacity:.35; pointer-events:none; }
</style>
@endpush

@push('scripts')
<script>
(function(){
    const LOOKUP_URL = @json(route('registries.bond-lookup'));
    const DEEDS_URL  = @json(route('registries.deeds-by-arazi'));
    const AGROUP_URL = @json(route('registries.arazi-group-options'));
    const PARTNERS_URL = @json(route('registries.partners-by-arazi'));
    const CSRF       = document.querySelector('meta[name="csrf-token"]')?.content ?? '';

    /* ── helpers ── */
    const $  = id => document.getElementById(id);
    const fmt = n  => Number(n||0).toLocaleString('en-IN',{minimumFractionDigits:2});

    /* ── Deed No (Select2) ── */
    const deedEl = $('deed_no_select');

    function initDeedSelect2(placeholderText){
        if (!(window.jQuery && jQuery.fn && jQuery.fn.select2)) return;
        const $el = jQuery(deedEl);
        const already = $el.hasClass('select2-hidden-accessible');

        // Select2 only reads data-placeholder at init time, so once a bond is applied
        // and deeds are loaded we need to destroy + reinit to swap the stale
        // "Select a bond first" text out for a live placeholder.
        if (placeholderText) $el.data('placeholder', placeholderText);
        if (already) {
            if (!placeholderText) return;
            $el.select2('destroy');
        }

        $el.select2({
            theme: 'bootstrap-5',
            width: '100%',
            placeholder: placeholderText || $el.data('placeholder') || 'Select Deed No',
            allowClear: true,
            dropdownParent: ($el.closest('form').length ? $el.closest('form') : jQuery(document.body))
        });
    }

    async function loadDeeds(araziCode, customerName){
        if (!deedEl) return;
        // keep currently-selected value (e.g. on validation redirect) so it isn't wiped
        const current = deedEl.value;

        if (!araziCode) {
            deedEl.innerHTML = '<option value=""></option>';
            if (window.jQuery) {
                initDeedSelect2('Select a bond first');
                jQuery(deedEl).val('').trigger('change');
            }
            return;
        }

        try {
            let url = DEEDS_URL + '?arazi_code=' + encodeURIComponent(araziCode);
            if (customerName) url += '&customer=' + encodeURIComponent(customerName);
            const res  = await fetch(url, {headers:{Accept:'application/json'}});
            const data = await res.json();
            // deeds: [{value, label, name, type: 'deed'|'merged'}, ...] from the real
            // Deed Mapping / Deed Merging feature — 'merged' entries (label like
            // "12343222-MERGED(123,131232312)") are listed first, followed by plain
            // 'deed' entries ("deed no - partner") for rows that aren't part of a merge.
            const deeds = data.deeds || [];

            const escHtml = s => String(s ?? '').replace(/[&<>"']/g, c => ({
                '&':'&amp;', '<':'&lt;', '>':'&gt;', '"':'&quot;', "'":'&#39;'
            }[c]));

            // If nothing is selected yet, auto-select the deed the backend picked as the
            // default for this bond's customer (preferring a merged deed no if found).
            const target = current || (data.default_value != null ? String(data.default_value) : '');

            let html = '<option value=""></option>';
            const set = new Set(deeds.map(d => String(d.value)));
            if (target && !set.has(String(target))) {
                html += `<option value="${escHtml(target)}" selected>${escHtml(target)}</option>`;
            }
            deeds.forEach(d => {
                const sel = String(d.value) === String(target) ? 'selected' : '';
                html += `<option value="${escHtml(d.value)}" ${sel}>${escHtml(d.label)}</option>`;
            });
            deedEl.innerHTML = html;

            if (window.jQuery) {
                initDeedSelect2(deeds.length ? 'Select Deed No' : 'No deeds found for this arazi');
                jQuery(deedEl).val(target || '').trigger('change');
            }
        } catch(e) { /* ignore */ }
    }

    // initialise on load so an old() / edit value still renders as Select2
    initDeedSelect2();

    /* ── Arazi No dropdown (default = bond arazi; extra options if it belongs to an Arazi Group) ── */
    const araziSelect = $('arazi_code_select');
    const araziHint   = $('arazi_group_hint');

    async function populateAraziOptions(defaultCode){
        if (!araziSelect) return;
        defaultCode = (defaultCode || '').trim();

        if (!defaultCode) {
            araziSelect.innerHTML = '<option value=""></option>';
            if (araziHint) araziHint.style.display = 'none';
            return;
        }

        // Show the default immediately so the field is never empty while fetching.
        araziSelect.innerHTML = `<option value="${defaultCode}" selected>${defaultCode}</option>`;

        try {
            const res  = await fetch(AGROUP_URL + '?arazi_code=' + encodeURIComponent(defaultCode), {headers:{Accept:'application/json'}});
            const data = await res.json();
            const options = data.options || [];

            if (options.length) {
                araziSelect.innerHTML = options.map(o => {
                    const sel = String(o.value) === String(defaultCode) ? 'selected' : '';
                    return `<option value="${o.value}" ${sel}>${o.label}</option>`;
                }).join('');
            }

            if (araziHint) araziHint.style.display = data.grouped ? '' : 'none';
        } catch(e) { /* keep the default option on failure */ }
    }

    /* ── Partner dropdown (only partners associated with the selected arazi) ── */
    const partnerSelect = $('partner_id_select');
    const partnerHint   = $('partner_hint');

    async function loadPartners(code, presetId){
        if (!partnerSelect) return;
        code = (code || '').trim();
        presetId = presetId || partnerSelect.dataset.preset || '';

        if (!code) {
            partnerSelect.innerHTML = '<option value="">-- select partner --</option>';
            if (partnerHint) partnerHint.style.display = 'none';
            return;
        }

        try {
            const res  = await fetch(PARTNERS_URL + '?arazi_code=' + encodeURIComponent(code), {headers:{Accept:'application/json'}});
            const data = await res.json();
            const partners = data.partners || [];

            let html = '<option value="">-- select partner --</option>';
            html += partners.map(p => {
                const sel = String(p.id) === String(presetId) ? 'selected' : '';
                return `<option value="${p.id}" ${sel}>${p.name}</option>`;
            }).join('');
            partnerSelect.innerHTML = html;

            if (partnerHint) {
                if (!partners.length) {
                    partnerHint.textContent = 'No partners associated with this arazi.';
                    partnerHint.className = 'form-text text-danger';
                    partnerHint.style.display = '';
                } else {
                    partnerHint.style.display = 'none';
                }
            }
        } catch(e) { /* leave existing options on failure */ }
    }

    // When the user picks a merged arazi, reload the matching deeds and sync the holder.
    araziSelect?.addEventListener('change', function(){
        const code = this.value || '';
        $('h_arazi_code').value = code;
        loadDeeds(code, $('d_customer_name')?.value || '');
        loadPartners(code);
    });

    /* ── Plot Sizes table (editable — submitted with the form, saved on click Save) ── */
    function recomputeLandSize(){
        let total = 0;
        $('plotsSizeBody')?.querySelectorAll('input.plot-size-input').forEach(inp => {
            const v = parseFloat(inp.value);
            if (!isNaN(v)) total += v;
        });
        const landSizeEl = document.querySelector('input[name="land_size"]');
        if (landSizeEl) landSizeEl.value = total;
        const totalEl = $('plotsSizeTotal');
        if (totalEl) totalEl.textContent = fmt(total);
    }

    function renderPlotsSizeTable(plots){
        const section = $('plotsSizeSection');
        const body    = $('plotsSizeBody');
        if (!section || !body) return;

        if (!plots.length) {
            section.classList.add('d-none');
            body.innerHTML = '';
            recomputeLandSize();
            return;
        }

        body.innerHTML = plots.map(p => {
            const locked = !!p.locked;
            const area   = p.area !== null && p.area !== undefined ? p.area : '';
            return `
                <tr data-plot-id="${p.id}">
                    <td>${p.title || ('Plot-'+p.id)}${locked ? ' <span class="text-muted small">(locked — registry done)</span>' : ''}</td>
                    <td>
                        <input type="number" step="0.01" min="0" class="form-control form-control-sm plot-size-input"
                            name="plot_sizes[${p.id}]" value="${area}" ${locked ? 'disabled' : ''}>
                    </td>
                </tr>`;
        }).join('');

        section.classList.remove('d-none');
        recomputeLandSize();

        body.querySelectorAll('input.plot-size-input').forEach(inp => {
            inp.addEventListener('input', recomputeLandSize);
        });
    }

    function applyBond(b){
        $('h_bond_id').value      = b.bond_id    || '';
        $('h_customer_id').value  = b.customer_id || '';
        $('h_arazi_code').value   = b.arazi_code || '';
        $('h_bond_amount').value  = b.bond_amount || '';

        // Load deed numbers for this bond's arazi into the Deed No dropdown, auto-selecting
        // the deed (preferring a merged one) that matches this bond's customer name.
        loadDeeds(b.arazi_code || '', b.customer_name || '');
        $('h_pending').value      = b.pending_amount || '';

        // ── Plot handling: show all as info badges ──
        const plots    = b.plots || [];
        const plotInfo = $('d_plots_info');

        if (plots.length === 0) {
            plotInfo.innerHTML = '<span class="text-muted" style="font-size:12px;">No plots found</span>';
            $('h_plot_id').value = '';
        } else {
            plotInfo.innerHTML = plots.map(p =>
                `<span class="badge bg-secondary me-1 mb-1">${p.title || p.id}</span>`
            ).join('');
            // Store first plot id as the primary (informational — all visible above)
            $('h_plot_id').value = plots[0].id;
        }

        renderPlotsSizeTable(plots);

        const plotLabel = plots.map(p => p.title).join(', ') || '-';
        $('b_plot').textContent = plotLabel;

        // Display fields
        $('d_customer_name').value = b.customer_name || '';
        $('d_mobile').value        = b.mobile        || '';
        $('d_alt_mobile').value    = b.secondary_mobile || '';
        // Populate the Arazi No dropdown (default = bond arazi, plus any grouped/merged options)
        populateAraziOptions(b.arazi_code || '');
        // Load partners associated with the bond's arazi
        loadPartners(b.arazi_code || '');
        $('d_bond_amount').value   = b.bond_amount   ? fmt(b.bond_amount)   : '';
        $('d_pending').value       = b.pending_amount !== undefined ? fmt(b.pending_amount) : '';

        // ── Low payment warning ──
        const total   = parseFloat(b.bond_amount    || 0);
        const paid    = parseFloat(b.paid_amount    || 0);
        const balance = parseFloat(b.pending_amount || 0);
        const pct     = total > 0 ? Math.round((paid / total) * 100) : 0;
        const alertEl = $('lowPaymentAlert');
        if (total > 0 && pct < 50) {
            $('w_paid').textContent  = fmt(paid);
            $('w_total').textContent = fmt(total);
            $('w_pct').textContent   = pct;
            $('w_bal').textContent   = fmt(balance);
            alertEl.classList.remove('d-none');
        } else {
            alertEl.classList.add('d-none');
        }

        // Banner
        $('b_bond_no').textContent  = b.bond_no      || '-';
        $('b_customer').textContent = b.customer_name || '-';
        $('b_arazi').textContent    = b.arazi_code   || '-';
        const banner = $('bondAppliedBanner');
        banner.classList.remove('d-none');
        banner.style.display = '';

        // Date default
        if (!$('d_registry_date').value)
            $('d_registry_date').value = new Date().toISOString().slice(0,10);

        // Hide results
        $('searchResults').classList.add('d-none');
        $('searchNoResult').classList.add('d-none');
    }

    /* ── Search ── */
    async function doSearch(){
        const name   = $('s_name')?.value.trim()    || '';
        const arazi  = $('s_arazi')?.value.trim()   || '';
        const plot   = $('s_plot')?.value.trim()    || '';
        const bondNo = $('s_bond_no')?.value.trim() || '';

        if (!name && !arazi && !plot && !bondNo) return;

        const btn = $('searchBondBtn');
        btn.disabled = true; btn.textContent = 'Searching…';

        try {
            const params = new URLSearchParams();
            if (name)   params.set('name',    name);
            if (arazi)  params.set('arazi',   arazi);
            if (plot)   params.set('plot',    plot);
            if (bondNo) params.set('bond_no', bondNo);

            const res  = await fetch(LOOKUP_URL + '?' + params.toString(), {headers:{Accept:'application/json'}});
            const data = await res.json();

            const listEl = $('resultsList');
            listEl.innerHTML = '';

            if (!data.found || !data.results?.length) {
                $('searchResults').classList.add('d-none');
                $('searchNoResult').classList.remove('d-none');
                return;
            }

            $('searchNoResult').classList.add('d-none');

            data.results.forEach(b => {
                const plot0 = b.plots?.[0];
                const item = document.createElement('button');
                item.type = 'button';
                item.className = 'list-group-item list-group-item-action py-2 px-3';
                item.innerHTML = `
                    <div class="d-flex justify-content-between align-items-start gap-2 flex-wrap">
                        <div>
                            <span class="badge bg-primary me-1">${b.bond_no||'-'}</span>
                            <strong>${b.customer_name||'-'}</strong>
                            <span class="text-muted ms-2">${b.mobile||''}</span>
                        </div>
                        <div class="text-end text-muted small">
                            Arazi: ${b.arazi_code||'-'} &nbsp;|&nbsp;
                            Plot: ${plot0?.title||'-'} &nbsp;|&nbsp;
                            Balance: ₹${fmt(b.pending_amount)}
                        </div>
                    </div>`;
                item.addEventListener('click', () => applyBond(b));
                listEl.appendChild(item);
            });

            $('searchResults').classList.remove('d-none');
        } catch(e) {
            $('searchNoResult').classList.remove('d-none');
        } finally {
            btn.disabled = false; btn.textContent = '';
            btn.innerHTML = '<i class="bi bi-search"></i> Search';
        }
    }

    $('searchBondBtn')?.addEventListener('click', doSearch);
    ['s_name','s_arazi','s_plot','s_bond_no'].forEach(id => {
        $(id)?.addEventListener('keydown', e => { if(e.key==='Enter'){ e.preventDefault(); doSearch(); } });
    });

    $('clearSearchBtn')?.addEventListener('click', () => {
        ['s_name','s_arazi','s_plot','s_bond_no'].forEach(id => { const el=$(id); if(el) el.value=''; });
        $('searchResults')?.classList.add('d-none');
        $('searchNoResult')?.classList.add('d-none');
    });

    /* ── Clear applied bond ── */
    $('clearBondBtn')?.addEventListener('click', () => {
        ['h_bond_id','h_customer_id','h_arazi_code','h_plot_id','h_bond_amount','h_pending'].forEach(id => {
            const el=$(id); if(el) el.value='';
        });
        ['d_customer_name','d_mobile','d_alt_mobile','d_plot_title','d_bond_amount','d_pending'].forEach(id => {
            const el=$(id); if(el) el.value='';
        });
        populateAraziOptions('');
        loadDeeds('');
        loadPartners('');
        renderPlotsSizeTable([]);
        $('bondAppliedBanner').classList.add('d-none');
    });

    /* ── Witnesses ── */
    const witnessBody = $('witnessBody');

    function reindex(){
        witnessBody.querySelectorAll('tr.witness-row').forEach((tr, i) => {
            tr.querySelector('.row-num').textContent = i + 1;
            tr.querySelectorAll('input').forEach(inp => {
                inp.name = inp.name.replace(/witnesses\[\d+\]/, 'witnesses['+i+']');
            });
        });
        // disable remove on last row
        const rows = witnessBody.querySelectorAll('tr.witness-row');
        rows.forEach((tr, i) => {
            const btn = tr.querySelector('.remove-witness');
            if (btn) { btn.style.opacity = rows.length === 1 ? '.35' : '1'; btn.style.pointerEvents = rows.length === 1 ? 'none' : 'auto'; }
        });
    }

    $('addWitnessBtn')?.addEventListener('click', () => {
        const idx = witnessBody.querySelectorAll('tr.witness-row').length;
        const tr  = document.createElement('tr');
        tr.className = 'witness-row';
        tr.innerHTML = `
            <td class="text-muted text-center row-num">${idx+1}</td>
            <td><input type="text" name="witnesses[${idx}][name]" class="form-control form-control-sm witness-name-input" placeholder="Full name" required></td>
            <td><input type="text" name="witnesses[${idx}][mobile]" class="form-control form-control-sm" placeholder="Mobile number"></td>
            <td class="text-center"><button type="button" class="btn btn-outline-danger btn-sm py-0 px-1 remove-witness" title="Remove"><i class="bi bi-x-lg"></i></button></td>`;
        witnessBody.appendChild(tr);
        reindex();
        tr.querySelector('input').focus();
    });

    witnessBody?.addEventListener('click', e => {
        const btn = e.target.closest('.remove-witness');
        if (!btn) return;
        const rows = witnessBody.querySelectorAll('tr.witness-row');
        if (rows.length <= 1) return;
        btn.closest('tr').remove();
        reindex();
    });

    reindex(); // init

    // Preload deed + arazi-group options if an arazi is already set (edit mode / validation redirect)
    const presetArazi = $('h_arazi_code')?.value || '';
    if (presetArazi) {
        loadDeeds(presetArazi, $('d_customer_name')?.value || '');
        populateAraziOptions(presetArazi);
        loadPartners(presetArazi);
    }

    // Edit mode: show the plot(s) already linked to this registry in the Plot Sizes table
    const plotsForSize = @json($plotsForSize ?? []);
    if (plotsForSize.length) {
        renderPlotsSizeTable(plotsForSize);
    }

    /* ── Area Converter (UI only — nothing submitted) ── */
    (function(){
        const val = document.getElementById('rac_value');
        const unit = document.getElementById('rac_unit');
        const out = document.getElementById('rac_result');
        if (!val || !unit || !out) return;
        function toGaz(){
            const v = parseFloat(val.value);
            if (isNaN(v)) { out.value = '—'; return; }
            let r;
            switch (unit.value) {
                case 'gaz':   r = v; break;
                case 'marla': r = v * 30.25; break;
                case 'kanal': r = v * 605; break;
                case 'sqft':  r = v / 9; break;
                case 'm2':    r = v / 0.83612736; break;
                case 'ha':    r = (v * 10000) / 0.83612736; break;
                default:      r = v;
            }
            out.value = (Math.round(r * 100) / 100) + ' gaz';
        }
        val.addEventListener('input', toGaz);
        unit.addEventListener('change', toGaz);
    })();
})();
</script>
@endpush
