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
            <input type="hidden" name="arazi_id"          id="h_arazi_id"     value="{{ old('arazi_id', $item->arazi_id ?? '') }}">
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
                <span><strong>Plot:</strong> <span id="b_plot">{{ $item->plot?->title ?? $item->plot?->plot_number ?? '-' }}</span></span>
                <button type="button" id="clearBondBtn" class="btn btn-outline-secondary btn-sm py-0 ms-auto">
                    <i class="bi bi-x"></i> Clear
                </button>
            </div>

            @error('customer_id')
                <div class="alert alert-danger py-2 small">Please search and select a bond first. ({{ $message }})</div>
            @enderror
            @error('arazi_id')
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
                    <input type="text" class="form-control form-control-sm bg-light" id="d_arazi_code"
                        value="{{ $item->arazi?->legacy_arazi_code ?: ($item->arazi?->plot_number ?? '') }}" readonly placeholder="Auto-filled">
                </div>
                <div class="col-md-4">
                    <label class="form-label small fw-semibold">Plots in Bond</label>
                    <div id="d_plots_info" class="form-control form-control-sm bg-light" style="min-height:31px; height:auto; white-space:normal;">
                        @if($isEdit && $item->plot)
                            <span class="badge bg-secondary me-1">{{ $item->plot->title ?? $item->plot->plot_number }}</span>
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
            <div class="row g-3 mb-2">
                <div class="col-md-2">
                    <label class="form-label small fw-semibold">Registry Date <span class="text-danger">*</span></label>
                    <input type="date" name="registry_date" id="d_registry_date"
                        value="{{ old('registry_date', optional($item->registry_date)->format('Y-m-d') ?? date('Y-m-d')) }}"
                        class="form-control form-control-sm @error('registry_date') is-invalid @enderror">
                    @error('registry_date')<div class="invalid-feedback">{{ $message }}</div>@enderror
                </div>
            </div>

            {{-- ── Low Payment Warning ── --}}
            <div id="lowPaymentAlert" class="alert alert-warning d-flex align-items-center gap-2 py-2 mb-3 d-none" style="font-size:13px;">
                <i class="bi bi-exclamation-triangle-fill text-warning fs-5"></i>
                <span><strong>Less than 50% paid</strong> — Paid: ₹<span id="w_paid">0</span> out of ₹<span id="w_total">0</span> &nbsp;(<span id="w_pct">0</span>% paid &nbsp;|&nbsp; Balance: ₹<span id="w_bal">0</span>)</span>
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
                            <a href="{{ asset('storage/' . $item->document_path) }}" target="_blank" class="fw-semibold">View / Download</a>
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
    const CSRF       = document.querySelector('meta[name="csrf-token"]')?.content ?? '';

    /* ── helpers ── */
    const $  = id => document.getElementById(id);
    const fmt = n  => Number(n||0).toLocaleString('en-IN',{minimumFractionDigits:2});

    function applyBond(b){
        $('h_bond_id').value      = b.bond_id    || '';
        $('h_customer_id').value  = b.customer_id || '';
        $('h_arazi_id').value     = b.arazi_id   || '';
        $('h_bond_amount').value  = b.bond_amount || '';
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

        const plotLabel = plots.map(p => p.title).join(', ') || '-';
        $('b_plot').textContent = plotLabel;

        // Display fields
        $('d_customer_name').value = b.customer_name || '';
        $('d_mobile').value        = b.mobile        || '';
        $('d_alt_mobile').value    = b.secondary_mobile || '';
        $('d_arazi_code').value    = b.arazi_code    || '';
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
        ['h_bond_id','h_customer_id','h_arazi_id','h_plot_id','h_bond_amount','h_pending'].forEach(id => {
            const el=$(id); if(el) el.value='';
        });
        ['d_customer_name','d_mobile','d_alt_mobile','d_arazi_code','d_plot_title','d_bond_amount','d_pending'].forEach(id => {
            const el=$(id); if(el) el.value='';
        });
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
})();
</script>
@endpush
