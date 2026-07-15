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

                @if($isAraziForm && $method === 'POST')
                    <hr />
                    <h5 class="mt-3">Plots</h5>
                    <div class="row g-3 mb-2">
                        <div class="col-md-3 d-none">
                            <label class="form-label">Number of Plots</label>
                            <input id="no_of_plots_ui" type="number" min="0" class="form-control" value="0">
                        </div>
                        <div class="col-md-4 d-flex align-items-end gap-2">
                            <button type="button" id="generatePlotsBtn" class="btn btn-secondary d-none">Generate</button>
                            <button type="button" id="addPlotRowBtn" class="btn btn-outline-secondary">Add Plot</button>
                            <button type="button" id="resequenceBtn" class="btn btn-outline-primary">Re-sequence</button>
                        </div>
                    </div>

                    <div id="plotsContainer" class="mb-3"></div>

                    <script>
                        (function(){
                            const container = document.getElementById('plotsContainer');
                            const genBtn = document.getElementById('generatePlotsBtn');
                            const addBtn = document.getElementById('addPlotRowBtn');
                            const numInput = document.getElementById('no_of_plots_ui');

                            function createRow(index, plotNumber = '', area = ''){
                                const row = document.createElement('div');
                                row.className = 'row g-2 align-items-end mb-2';
                                row.innerHTML = `
                                    <div class="col-md-6">
                                        <label class="form-label">Plot Number <span class="text-danger">*</span></label>
                                        <input name="plots[${index}][plot_number]" class="form-control" required value="${plotNumber}">
                                    </div>
                                    <div class="col-md-4">
                                        <label class="form-label">Area (optional)</label>
                                        <input name="plots[${index}][area]" type="number" step="0.01" class="form-control" value="${area}">
                                    </div>
                                    <div class="col-md-2">
                                        <button type="button" class="btn btn-outline-danger btn-sm remove-plot">Remove</button>
                                    </div>
                                `;
                                container.appendChild(row);
                                row.querySelector('.remove-plot').addEventListener('click', function(){
                                    row.remove();
                                    // reindex names
                                    reindexRows();
                                });
                            }

                            function reindexRows(){
                                Array.from(container.children).forEach(function(row, idx){
                                    const pn = row.querySelector('input[name^="plots"][name$="[plot_number]"]') || row.querySelector('input[name^="plots"][name$="[title]"]');
                                    const area = row.querySelector('input[name^="plots"][name$="[area]"]');
                                    if(pn) pn.setAttribute('name', `plots[${idx}][plot_number]`);
                                    if(area) area.setAttribute('name', `plots[${idx}][area]`);
                                });
                            }

                            function generateFromNumber(){
                                const n = parseInt(numInput.value || '0', 10) || 0;
                                container.innerHTML = '';
                                for(let i=0;i<n;i++) createRow(i, (i+1));
                            }

                            // auto-generate when number input changes
                            numInput.addEventListener('input', function(){
                                // small debounce
                                if(this._genTimeout) clearTimeout(this._genTimeout);
                                this._genTimeout = setTimeout(generateFromNumber, 250);
                            });

                            genBtn.addEventListener('click', generateFromNumber);

                            addBtn.addEventListener('click', function(){
                                const idx = container.children.length;
                                createRow(idx, (idx+1));
                            });

                            // (page re-sequence wired in page script block below)

                            // Re-sequence button: continue numeric sequence after last custom label (e.g., 3a,3b -> 4,5...)
                            const resequenceBtn = document.getElementById('resequenceBtn');
                            if(resequenceBtn){
                                resequenceBtn.addEventListener('click', function(){
                                    const rows = Array.from(container.children);
                                    let nextBase = 1;
                                    let prevOriginalBase = null;
                                    let prevAssignedBase = null;
                                    rows.forEach(function(row, i){
                                        const inp = row.querySelector('input[name^="plots"][name$="[plot_number]"]') || row.querySelector('input[name^="plots"][name$="[title]"]');
                                        const orig = (inp?.value || '').toString().trim();
                                        const m = orig.match(/^([0-9]+)(.*)$/);
                                        if(m){
                                            const ob = parseInt(m[1], 10);
                                            const suffix = (m[2] || '').toString();
                                            if(suffix){
                                                // has suffix
                                                if(i>0){
                                                    const prevOrig = (rows[i-1].querySelector('input[name^="plots"][name$="[plot_number]"]') || rows[i-1].querySelector('input[name^="plots"][name$="[title]"]')).value || '';
                                                    const pm = prevOrig.toString().trim().match(/^([0-9]+)(.*)$/);
                                                    if(pm && parseInt(pm[1],10) === ob){
                                                        // extra split of same numeric prefix -> assign same base as previous assigned
                                                        if(prevAssignedBase !== null){
                                                            inp.value = String(prevAssignedBase) + suffix;
                                                            // do not change nextBase
                                                            prevOriginalBase = ob;
                                                            return;
                                                        }
                                                    }
                                                }
                                                if(ob === nextBase){
                                                    // first occurrence for this base
                                                    inp.value = String(nextBase) + suffix;
                                                    prevAssignedBase = nextBase;
                                                    prevOriginalBase = ob;
                                                    nextBase++;
                                                } else if(ob > nextBase){
                                                    // mislabeled higher, assume they meant nextBase
                                                    inp.value = String(nextBase) + suffix;
                                                    prevAssignedBase = nextBase;
                                                    prevOriginalBase = ob;
                                                    nextBase++;
                                                } else {
                                                    // ob < nextBase, treat as split of previous assigned base
                                                    const assignBase = prevAssignedBase ?? ob;
                                                    inp.value = String(assignBase) + suffix;
                                                    prevOriginalBase = ob;
                                                }
                                            } else {
                                                // no suffix -> it's a full number, assign nextBase regardless
                                                inp.value = String(nextBase);
                                                prevAssignedBase = nextBase;
                                                prevOriginalBase = ob;
                                                nextBase++;
                                            }
                                        } else {
                                            // no numeric prefix, assign nextBase
                                            inp.value = String(nextBase);
                                            prevAssignedBase = nextBase;
                                            prevOriginalBase = null;
                                            nextBase++;
                                        }
                                    });
                                    reindexRows();
                                });
                            }

                            

                            
                        })();
                    </script>
                @endif
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
                                            const selectName = isKisan ? 'kisan_id' : 'arazi_code';
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
                        <div class="col-md-6 {{ !empty($field['hidden']) ? 'd-none' : '' }}">
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
                                    @if(!empty($field['readonly'])) readonly @endif
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
                                    <select id="{{ $field['name'] }}" @if(empty($field['readonly'])) name="{{ $field['name'] }}" @endif class="form-select" @if(!empty($field['required'])) required @endif @if(!empty($field['readonly'])) disabled tabindex="-1" @endif>
                                        <option value="">Select {{ $field['label'] }}</option>
                                        @foreach($field['options'] ?? [] as $optionValue => $optionLabel)
                                            <option value="{{ $optionValue }}" @selected((string) $value === (string) $optionValue)>{{ $optionLabel }}</option>
                                        @endforeach
                                    </select>
                                    @if(!empty($field['readonly']))
                                        <input type="hidden" name="{{ $field['name'] }}" value="{{ $value }}">
                                    @endif
                                    @if(($field['name'] ?? '') === 'arazi_code' && empty($field['readonly']))
                                        <a href="#" class="btn btn-outline-primary btn-sm btn-new-arazi" data-create-url="{{ route('arazis.create-fragment') }}" title="Create new Arazi">New</a>
                                    @endif
                                    @if(($field['name'] ?? '') === 'kisan_id' && empty($field['readonly']))
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

                @if($isAraziForm)
                    <hr />
                    <h5 class="mt-3">Area Converter <small class="text-muted">(for reference only — not saved)</small></h5>
                    <div class="row g-3 mb-2">
                        <div class="col-md-3">
                            <label class="form-label">Value</label>
                            <input type="number" step="any" id="ac_value" class="form-control" placeholder="Enter value">
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">From Unit</label>
                            <select id="ac_unit" class="form-select">
                                <option value="gaz">Gaz</option>
                                <option value="marla">Marla</option>
                                <option value="kanal">Kanal</option>
                                <option value="sqft">Sq Ft</option>
                                <option value="m2">Sq Meter</option>
                                <option value="ha">Hectare</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label class="form-label">Result (Gaz)</label>
                            <input type="text" id="ac_result" class="form-control" readonly value="—">
                        </div>
                    </div>
                    <script>
                        (function(){
                            var val = document.getElementById('ac_value');
                            var unit = document.getElementById('ac_unit');
                            var out = document.getElementById('ac_result');
                            if (!val || !unit || !out) return;
                            function toGaz(){
                                var v = parseFloat(val.value);
                                if (isNaN(v)) { out.value = '—'; return; }
                                var u = unit.value, r;
                                switch(u){
                                    case 'gaz': r = v; break;
                                    case 'marla': r = v * 30.25; break;
                                    case 'kanal': r = v * 605; break;
                                    case 'sqft': r = v / 9; break;
                                    case 'm2': r = v / 0.83612736; break;
                                    case 'ha': r = (v * 10000) / 0.83612736; break;
                                    default: r = v;
                                }
                                out.value = (Math.round(r * 100) / 100) + ' gaz';
                            }
                            val.addEventListener('input', toGaz);
                            unit.addEventListener('change', toGaz);
                        })();
                    </script>
                @endif

                @if($isAraziForm && $method === 'POST')
                    <hr />
                    <h5 class="mt-3">Plots</h5>
                    <div class="row g-3 mb-2">
                        <div class="col-md-3">
                            <label class="form-label">Number of Plots</label>
                            <input id="page_no_of_plots_ui" type="number" min="0" class="form-control" value="0">
                        </div>
                        <div class="col-md-4 d-flex align-items-end gap-2">
                            <button type="button" id="page_generatePlotsBtn" class="btn btn-secondary">Generate</button>
                            <button type="button" id="page_addPlotRowBtn" class="btn btn-outline-secondary">Add Plot</button>
                            <button type="button" id="page_resequenceBtn" class="btn btn-outline-primary">Re-sequence</button>
                        </div>
                    </div>

                    <div id="page_plotsContainer" class="mb-3"></div>

                    <script>
                        (function(){
                            const container = document.getElementById('page_plotsContainer');
                            const genBtn = document.getElementById('page_generatePlotsBtn');
                            const addBtn = document.getElementById('page_addPlotRowBtn');
                            const numInput = document.getElementById('page_no_of_plots_ui');

                            function createRow(index, plotNumber = '', area = ''){
                                const row = document.createElement('div');
                                row.className = 'row g-2 align-items-end mb-2';
                                row.innerHTML = `
                                    <div class="col-md-6">
                                        <label class="form-label">Plot Number <span class="text-danger">*</span></label>
                                        <input name="plots[${index}][plot_number]" class="form-control" required value="${plotNumber}">
                                    </div>
                                    <div class="col-md-4">
                                        <label class="form-label">Area (optional)</label>
                                        <input name="plots[${index}][area]" type="number" step="0.01" class="form-control" value="${area}">
                                    </div>
                                    <div class="col-md-2">
                                        <button type="button" class="btn btn-outline-danger btn-sm remove-plot">Remove</button>
                                    </div>
                                `;
                                container.appendChild(row);
                                row.querySelector('.remove-plot').addEventListener('click', function(){
                                    row.remove();
                                    // reindex names
                                    reindexRows();
                                });
                            }

                            function reindexRows(){
                                Array.from(container.children).forEach(function(row, idx){
                                    const pn = row.querySelector('input[name^="plots"][name$="[plot_number]"]') || row.querySelector('input[name^="plots"][name$="[title]"]');
                                    const area = row.querySelector('input[name^="plots"][name$="[area]"]');
                                    if(pn) pn.setAttribute('name', `plots[${idx}][plot_number]`);
                                    if(area) area.setAttribute('name', `plots[${idx}][area]`);
                                });
                            }

                            function generateFromNumber(){
                                const n = parseInt(numInput.value || '0', 10) || 0;
                                container.innerHTML = '';
                                for(let i=0;i<n;i++) createRow(i, (i+1));
                            }

                            // auto-generate when number input changes
                            numInput.addEventListener('input', function(){
                                if(this._genTimeout) clearTimeout(this._genTimeout);
                                this._genTimeout = setTimeout(generateFromNumber, 250);
                            });

                            genBtn.addEventListener('click', generateFromNumber);

                            addBtn.addEventListener('click', function(){
                                const idx = container.children.length;
                                createRow(idx, (idx+1));
                            });

                            const reseqBtn = document.getElementById('page_resequenceBtn');
                            if(reseqBtn){
                                reseqBtn.addEventListener('click', function(){
                                    const rows = Array.from(container.children);
                                    let nextNum = 1;
                                    let prevOriginalBase = null;
                                    let prevAssignedBase = null;
                                    rows.forEach(function(row){
                                        const inp = row.querySelector('input[name$="[plot_number]"]');
                                        if(!inp) return;
                                        const val = (inp.value || '').toString().trim();
                                        const m = val.match(/^(\d+)([A-Za-z]*)$/);
                                        if(!m){
                                            inp.value = String(nextNum);
                                            prevOriginalBase = null;
                                            prevAssignedBase = nextNum;
                                            nextNum++;
                                            return;
                                        }
                                        const origBase = parseInt(m[1], 10);
                                        const suffix = m[2];
                                        if(!suffix){
                                            inp.value = String(nextNum);
                                            prevOriginalBase = origBase;
                                            prevAssignedBase = nextNum;
                                            nextNum++;
                                        } else {
                                            if(prevOriginalBase !== null && origBase === prevOriginalBase){
                                                inp.value = String(prevAssignedBase) + suffix;
                                            } else {
                                                inp.value = String(nextNum) + suffix;
                                                prevOriginalBase = origBase;
                                                prevAssignedBase = nextNum;
                                                nextNum++;
                                            }
                                        }
                                    });
                                    reindexRows();
                                });
                            }
                        })();
                    </script>
                @endif

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
            const araziSelect = document.querySelector('select[name="arazi_code"]');
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
                            opt.value = a.arazi_code || a.label;
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
                jQuery('select[name="kisan_id"], select[name="kisan_bond_id"], select[name="customer_id"], select[name="customer_bond_id"], select[name="customer_bond_cheque_id"]').select2({
                    theme: 'bootstrap-5',
                    width: '100%',
                    placeholder: function(){ return jQuery(this).data('placeholder') || 'Select'; },
                    allowClear: true,
                    minimumResultsForSearch: 0
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

            const araziSaleableUrl = @json(route('arazis.saleable-by-code', ['code' => '__ARAZI_CODE__']));
            const araziPlotsUrl = @json(route('arazis.plots-by-code', ['code' => '__ARAZI_CODE__']));
            const paymentCtxUrl = @json(route('customer-bonds.payment-context', ['customer_bond' => '__BOND_ID__']));
            const customerBondChequesUrl = @json(route('customer-bond-cheques.for-bond', ['customer_bond' => '__BOND_ID__']));
            const hiddenArazi = document.querySelector('input#arazi_code[type="hidden"]');
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
                    if(hiddenArazi && ctx.arazi_code !== undefined) hiddenArazi.value = ctx.arazi_code ?? '';
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
                    // load cheques for selected bond
                    loadChequesForBond(this.value);
                });
                if(customerPaymentBondSelect.value){
                    applyCustomerBondPaymentContext(customerPaymentBondSelect.value);
                    loadChequesForBond(customerPaymentBondSelect.value);
                }
            }

            async function loadChequesForBond(bondId){
                const select = document.querySelector('select[name="customer_bond_cheque_id"]');
                if(!select) return;
                select.innerHTML = '<option value="">Select Cheque (optional)</option>';
                if(!bondId) return;
                try{
                    // request only pending (unpaid) cheques by default
                    const url = customerBondChequesUrl.replace('__BOND_ID__', encodeURIComponent(bondId)) + '?status=pending';
                    const res = await fetch(url);
                    if(!res.ok) return;
                    const data = await res.json();
                    if(!Array.isArray(data)) return;
                    data.forEach(function(c){
                        const opt = document.createElement('option');
                        opt.value = c.id;
                        opt.textContent = c.label;
                        // include amount for client-side autofill when provided
                        opt.dataset.amount = (c.amount !== undefined && c.amount !== null) ? c.amount : '';
                        select.appendChild(opt);
                    });
                    if(window.jQuery && jQuery.fn.select2) jQuery(select).trigger('change.select2');

                    // when a cheque is selected, autofill amount and make it readonly
                    const amountInput = document.querySelector('input[name="amount"]');
                    const paymentInput = document.querySelector('input[name="payment_method"]');

                    // default to cash if nothing selected
                    if(paymentInput && !paymentInput.value) paymentInput.value = 'cash';

                    select.addEventListener('change', function(){
                        const sel = this.options[this.selectedIndex];
                        if(sel && sel.value){
                            let amt = sel.dataset.amount || '';
                            if(!amt){
                                const m = (sel.textContent || '').match(/₹\s*([\d,\.]+)/);
                                if(m) amt = m[1].replace(/,/g, '');
                            }
                            if(amountInput && amt !== ''){
                                amountInput.value = amt;
                                amountInput.setAttribute('readonly', 'readonly');
                                amountInput.classList.add('bg-light');
                            }
                            // force payment method to cheque and disable editing
                            if(paymentInput){
                                paymentInput.value = 'cheque';
                                paymentInput.setAttribute('readonly', 'readonly');
                                paymentInput.classList.add('bg-light');
                            }
                        } else {
                            // no cheque selected -> make amount editable and default payment to cash
                            if(amountInput){
                                amountInput.removeAttribute('readonly');
                                amountInput.classList.remove('bg-light');
                            }
                            if(paymentInput){
                                paymentInput.removeAttribute('readonly');
                                paymentInput.classList.remove('bg-light');
                                paymentInput.value = 'cash';
                            }
                        }
                    });
                }catch(e){}
            }

            if(customerPaymentCustomerSelect && hiddenArazi){
                customerPaymentCustomerSelect.addEventListener('change', function(){
                    applyCustomerBondPaymentContext('');
                });
            }

            const select = document.querySelector('select[name="arazi_code"]');
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

            async function fetchSaleable(code){
                if(!code){ info.textContent=''; return; }
                try{
                    const res = await fetch(araziSaleableUrl.replace('__ARAZI_CODE__', encodeURIComponent(code)));
                    if(!res.ok) throw new Error('Fetch failed');
                    const json = await readJsonSafe(res);
                    if(!json) throw new Error('Invalid response');
                    const totalGaz = (json.saleable_gaz !== undefined) ? json.saleable_gaz : (json.saleable_total || 0);
                    const remainingGaz = (json.remaining_gaz !== undefined) ? json.remaining_gaz : (json.remaining || 0);
                    const unit = json.unit || 'gaz';
                    info.innerHTML = `<small class="text-muted">Saleable: <strong>${totalGaz}</strong> gaz — Available: <strong>${remainingGaz}</strong> gaz</small>`;
                }catch(e){
                    info.textContent = '';
                }
            }

            // load plots for arazi into any plot_id select on the form
            async function loadPlotsInto(araziCode, selectedPlotId){
                const plotSelect = document.querySelector('select[name="plot_id"]');
                const landSize = document.querySelector('input[name="land_size"]');
                if(!plotSelect) return;
                plotSelect.innerHTML = '<option value="">Select Plot</option>';
                if(!araziCode) return;
                try{
                    const res = await fetch(araziPlotsUrl.replace('__ARAZI_CODE__', encodeURIComponent(araziCode)));
                    if(!res.ok) return;
                    const raw = await res.json();
                    // plots-by-code returns { found, plots } while older endpoint returned a flat array
                    const data = Array.isArray(raw) ? raw : (raw.plots || []);
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
    <script>
        // Payment method → show/require MTR Transaction No. + Account/Payee Name
        (function(){
            const method = document.getElementById('payment_method');
            const mtr    = document.getElementById('mtr_transaction_no');
            const payee  = document.getElementById('account_payee_name');
            if(!method || !mtr) return;

            function groupOf(el){
                if(!el) return null;
                return el.closest('.mb-3, .form-group, .col, .col-md-6, .col-md-4, .row > div') || el.parentElement;
            }
            const mtrGroup   = groupOf(mtr);
            const payeeGroup = groupOf(payee);

            function toggle(){
                const m = (method.value || '').toLowerCase();
                const needs = ['imps','rtgs','upi'].includes(m);
                if(mtrGroup) mtrGroup.style.display = needs ? '' : 'none';
                if(needs){ mtr.setAttribute('required','required'); }
                else { mtr.removeAttribute('required'); }
                if(payeeGroup) payeeGroup.style.display = needs ? '' : 'none';
            }
            method.addEventListener('change', toggle);
            if(window.jQuery){ try{ jQuery(method).on('select2:select', toggle); }catch(e){} }
            toggle();
        })();
    </script>
@endsection
