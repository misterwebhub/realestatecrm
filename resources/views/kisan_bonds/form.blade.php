@extends('layouts.app')

@section('content')
@php
    $selectedArazis = $selectedArazis ?? [];
@endphp

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

        <form action="{{ $action }}" method="POST" id="kisan-bond-form">
            @csrf
            @if($method !== 'POST')
                @method($method)
            @endif

            <div class="row g-3">
                <div class="col-md-4">
                    <label class="form-label" for="bond_no">Bond Number</label>
                    <input type="text" name="bond_no" id="bond_no" class="form-control" value="{{ old('bond_no', $item->bond_no ?? '') }}" readonly>
                </div>

                <div class="col-md-4">
                    <label class="form-label" for="bond_date">Bond Date</label>
                    <input type="date" name="bond_date" id="bond_date" class="form-control" value="{{ old('bond_date', optional($item->bond_date)->format('Y-m-d') ?? now()->format('Y-m-d')) }}" required>
                </div>

                <div class="col-md-4">
                    <label class="form-label" for="kisan_id">Kisan</label>
                    <select name="kisan_id" id="kisan_id" class="form-select" required>
                        <option value="">Select Kisan</option>
                        @foreach($kisans as $id => $name)
                            <option value="{{ $id }}" @selected((string) old('kisan_id', $item->kisan_id ?? '') === (string) $id)>{{ $name }}</option>
                        @endforeach
                    </select>
                </div>
            </div>

            <hr>

            <div class="row g-3 align-items-end">
                <div class="col-md-5">
                    <label class="form-label" for="arazi_search">Search Arazi</label>
                    <div style="position:relative;">
                        <input type="text" id="arazi_search" class="form-control" placeholder="Type Arazi number/location to search" autocomplete="off">
                        <div id="arazi_suggestions" class="list-group position-absolute" style="z-index:3000; width:100%; display:none; max-height:240px; overflow:auto;"></div>
                    </div>
                </div>
                <div class="col-md-5">
                    <label class="form-label" for="available_arazi">Available Arazis</label>
                    <select id="available_arazi" class="form-select">
                        <option value="">Select Kisan first</option>
                    </select>
                </div>
                <div class="col-md-2">
                    <button type="button" class="btn btn-outline-primary w-100" id="add-arazi-btn">Add Arazi</button>
                </div>
            </div>

            <div class="table-responsive mt-3">
                <table class="table table-bordered align-middle">
                    <thead class="table-light">
                        <tr>
                            <th style="width:28%">Arazi</th>
                            <th style="width:14%">Land Size</th>
                            <th style="width:14%">Sale Land</th>
                            <th style="width:14%">Sale Rate</th>
                            <th style="width:16%">Sale Amount</th>
                            <th style="width:10%">Action</th>
                        </tr>
                    </thead>
                    <tbody id="arazi-rows"></tbody>
                    <tfoot>
                        <tr class="table-light">
                            <th>Total</th>
                            <th><input type="text" name="land_size" id="land_size" class="form-control" value="{{ old('land_size', $item->land_size ?? '') }}" readonly></th>
                            <th><input type="number" step="0.01" name="sale_land" id="sale_land" class="form-control" value="{{ old('sale_land', $item->sale_land ?? 0) }}" readonly></th>
                            <th></th>
                            <th>
                                <input type="number" step="0.01" name="total_amount" id="total_amount" class="form-control" value="{{ old('total_amount', $item->total_amount ?? $item->bond_amount ?? 0) }}" readonly>
                                <input type="hidden" name="bond_amount" id="bond_amount" value="{{ old('bond_amount', $item->bond_amount ?? 0) }}">
                            </th>
                            <th></th>
                        </tr>
                    </tfoot>
                </table>
            </div>

            <div class="row g-3">
                <div class="col-md-3">
                    <label class="form-label" for="amount">Amount Paid</label>
                    <input type="number" step="0.01" name="amount" id="amount" class="form-control" value="{{ old('amount', $item->amount ?? 0) }}">
                </div>
                <div class="col-md-3">
                    <label class="form-label" for="balance">Balance</label>
                    <input type="number" step="0.01" name="balance" id="balance" class="form-control" value="{{ old('balance', $item->balance ?? 0) }}" readonly>
                </div>
                <div class="col-md-3">
                    <label class="form-label" for="bayana_mode">Bayana Mode</label>
                    <select name="bayana_mode" id="bayana_mode" class="form-select">
                        <option value="">Select Mode</option>
                        <option value="cash" @selected(old('bayana_mode', $item->bayana_mode ?? '') === 'cash')>Cash</option>
                        <option value="cheque" @selected(old('bayana_mode', $item->bayana_mode ?? '') === 'cheque')>Cheque</option>
                    </select>
                </div>
                <div class="col-md-3">
                    <label class="form-label" for="last_date">Last Date</label>
                    <input type="date" name="last_date" id="last_date" class="form-control" value="{{ old('last_date', optional($item->last_date)->format('Y-m-d') ?? '') }}">
                </div>
                {{-- hide bond type and keep its value as hidden field --}}
                <input type="hidden" name="bond_type" id="bond_type" value="{{ old('bond_type', $item->bond_type ?? '') }}">

                {{-- Group Broker, Mobile, Broker Payment, Broker Paid, Broker Balance in one row --}}
                <div class="col-12">
                    <div class="row g-3">
                        <div class="col-md-2">
                            <label class="form-label" for="broker_id">Broker</label>
                            <select name="broker_id" id="broker_id" class="form-select">
                                <option value="">Select Broker</option>
                                @foreach($agents as $id => $name)
                                    <option value="{{ $id }}" @selected((string) old('broker_id', $item->broker_id ?? '') === (string) $id)>{{ $name }}</option>
                                @endforeach
                            </select>
                        </div>
                        <div class="col-md-2">
                            <label class="form-label" for="mobile">Mobile</label>
                            <input type="text" name="mobile" id="mobile" class="form-control" value="{{ old('mobile', $item->mobile ?? '') }}">
                        </div>
                        <div class="col-md-2">
                            <label class="form-label" for="broker_payment">Broker Payment</label>
                            <input type="number" step="0.01" name="broker_payment" id="broker_payment" class="form-control" value="{{ old('broker_payment', $item->broker_payment ?? '') }}">
                        </div>
                        <div class="col-md-2">
                            <label class="form-label" for="broker_paid">Broker Paid</label>
                            <input type="number" step="0.01" name="broker_paid" id="broker_paid" class="form-control" value="{{ old('broker_paid', $item->broker_paid ?? '') }}">
                        </div>
                        <div class="col-md-4">
                            <label class="form-label" for="broker_balance">Broker Balance</label>
                            <input type="number" step="0.01" name="broker_balance" id="broker_balance" class="form-control" value="{{ old('broker_balance', $item->broker_balance ?? '') }}">
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <label class="form-label" for="broker_comment">Broker Comment</label>
                    <textarea name="broker_comment" id="broker_comment" class="form-control" rows="3">{{ old('broker_comment', $item->broker_comment ?? '') }}</textarea>
                </div>
                <div class="col-md-6">
                    <label class="form-label" for="kisan_comment">Kisan Comment</label>
                    <textarea name="kisan_comment" id="kisan_comment" class="form-control" rows="3">{{ old('kisan_comment', $item->kisan_comment ?? '') }}</textarea>
                </div>
                <div class="col-md-6">
                    <label class="form-label" for="witnesses">Witnesses</label>
                    <textarea name="witnesses" id="witnesses" class="form-control" rows="4">{{ old('witnesses', $item->exists ? implode("\n", $item->witnesses->pluck('name')->all()) : '') }}</textarea>
                    <div class="form-text">One witness per line.</div>
                </div>
                <div class="col-md-6">
                    <label class="form-label" for="notes">Notes</label>
                    <textarea name="notes" id="notes" class="form-control" rows="4">{{ old('notes', $item->notes ?? '') }}</textarea>
                </div>
            </div>

            <div class="mt-4 d-flex gap-2">
                <button type="submit" class="btn btn-primary">Save</button>
                <a href="{{ route('kisan-bonds.index') }}" class="btn btn-outline-secondary">Cancel</a>
            </div>
        </form>
    </div>
</div>

<script>
    (function(){
        const kisanArazisUrl = @json(route('kisans.arazis', ['kisan' => '__KISAN_ID__']));
        const initialRows = @json($selectedArazis);
        const oldRows = @json(old('arazi_items', []));
        const defaultRate = Number(@json(old('sale_rate', $item->sale_rate ?? 0))) || 0;

        const kisanSelect = document.getElementById('kisan_id');
        const searchInput = document.getElementById('arazi_search');
        const availableSelect = document.getElementById('available_arazi');
        const addButton = document.getElementById('add-arazi-btn');
        const rowsBody = document.getElementById('arazi-rows');
        const landSizeInput = document.getElementById('land_size');
        const saleLandInput = document.getElementById('sale_land');
        const totalAmountInput = document.getElementById('total_amount');
        const bondAmountInput = document.getElementById('bond_amount');
        const paidInput = document.getElementById('amount');
        const balanceInput = document.getElementById('balance');

        let availableArazis = [];
        let rowIndex = 0;

        function selectedAraziIds(){
            return Array.from(rowsBody.querySelectorAll('input[data-field="arazi_id"]')).map(input => String(input.value));
        }

        function renderAvailableOptions(){
            const selectedIds = selectedAraziIds();
            const term = searchInput.value.trim().toLowerCase();
            const filtered = availableArazis.filter(arazi => {
                if(selectedIds.includes(String(arazi.id))) return false;
                const haystack = [arazi.label, arazi.location, arazi.unit].filter(Boolean).join(' ').toLowerCase();
                return !term || haystack.includes(term);
            });

            availableSelect.innerHTML = '<option value="">Select Arazi</option>';
            filtered.forEach(arazi => {
                const opt = document.createElement('option');
                opt.value = arazi.id;
                opt.textContent = `${arazi.label}${arazi.location ? ' - ' + arazi.location : ''}`;
                availableSelect.appendChild(opt);
            });
        }

        function calculateRow(row){
            const saleLand = Number(row.querySelector('[data-field="sale_land"]').value) || 0;
            const saleRateEl = row.querySelector('[data-field="sale_rate"]');
            const saleAmountEl = row.querySelector('[data-field="sale_amount"]');
            let saleAmount = Number(saleAmountEl.value) || 0;

            if(saleLand > 0){
                // If user edited sale amount, compute rate; otherwise compute amount from rate
                if(!saleAmountEl.hasAttribute('readonly')){
                    const perGaz = saleAmount / saleLand;
                    saleRateEl.value = isFinite(perGaz) ? perGaz.toFixed(2) : '0.00';
                } else {
                    const rate = Number(saleRateEl.value) || 0;
                    saleAmount = saleLand * rate;
                    saleAmountEl.value = saleAmount.toFixed(2);
                }
            } else {
                saleRateEl.value = (saleAmount && saleLand === 0) ? '0.00' : saleRateEl.value;
            }

            calculateTotals();
        }

        function calculateTotals(){
            let totalLandSize = 0;
            let totalSaleLand = 0;
            let totalAmount = 0;

            rowsBody.querySelectorAll('tr').forEach(row => {
                totalLandSize += Number(row.querySelector('[data-field="land_size"]').value) || 0;
                totalSaleLand += Number(row.querySelector('[data-field="sale_land"]').value) || 0;
                totalAmount += Number(row.querySelector('[data-field="sale_amount"]').value) || 0;
            });

            landSizeInput.value = totalLandSize.toFixed(2);
            saleLandInput.value = totalSaleLand.toFixed(2);
            totalAmountInput.value = totalAmount.toFixed(2);
            bondAmountInput.value = totalAmount.toFixed(2);
            balanceInput.value = Math.max(totalAmount - (Number(paidInput.value) || 0), 0).toFixed(2);
        }

        function addAraziRow(arazi){
            if(!arazi || selectedAraziIds().includes(String(arazi.id))) return;

            const index = rowIndex++;
            const saleRate = Number(arazi.sale_rate ?? defaultRate) || 0;
            const saleLand = Number(arazi.sale_land ?? arazi.land_size ?? 0) || 0;
            const landSize = Number(arazi.land_size ?? saleLand) || 0;
            const saleAmount = Number(arazi.sale_amount ?? (saleLand * saleRate)) || 0;
            const row = document.createElement('tr');

            row.innerHTML = `
                <td>
                    <strong>${arazi.label || ('Arazi-' + arazi.id)}</strong>
                    ${arazi.location ? '<div class="text-muted small">' + arazi.location + '</div>' : ''}
                    <input type="hidden" name="arazi_items[${index}][arazi_id]" value="${arazi.id}" data-field="arazi_id">
                </td>
                <td>
                    <input type="number" step="0.01" name="arazi_items[${index}][land_size]" class="form-control" value="${landSize.toFixed(2)}" data-field="land_size" readonly>
                    <div class="text-muted small">${arazi.unit || 'gaz'}</div>
                </td>
                <td><input type="number" step="0.01" name="arazi_items[${index}][sale_land]" class="form-control" value="${saleLand.toFixed(2)}" data-field="sale_land" readonly></td>
                <td><input type="number" step="0.01" name="arazi_items[${index}][sale_rate]" class="form-control" value="${saleRate.toFixed(2)}" data-field="sale_rate" readonly></td>
                <td><input type="number" step="0.01" name="arazi_items[${index}][sale_amount]" class="form-control" value="${saleAmount.toFixed(2)}" data-field="sale_amount"></td>
                <td><button type="button" class="btn btn-sm btn-outline-danger" data-remove-row>Delete</button></td>
            `;

            // Sale Land and Sale Rate are readonly; user edits Sale Amount which recalculates Sale Rate
            row.querySelector('[data-field="sale_amount"]').addEventListener('input', () => calculateRow(row));
            row.querySelector('[data-remove-row]').addEventListener('click', () => {
                row.remove();
                renderAvailableOptions();
                calculateTotals();
            });

            rowsBody.appendChild(row);
            calculateRow(row);
            renderAvailableOptions();
        }

        function loadArazis(){
            const kisanId = kisanSelect.value;
            availableArazis = [];
            availableSelect.innerHTML = '<option value="">Loading...</option>';

            if(!kisanId){
                availableSelect.innerHTML = '<option value="">Select Kisan first</option>';
                return Promise.resolve([]);
            }

            return fetch(kisanArazisUrl.replace('__KISAN_ID__', encodeURIComponent(kisanId)))
                .then(res => res.ok ? res.json() : [])
                .then(data => {
                    availableArazis = Array.isArray(data) ? data : [];
                    renderAvailableOptions();
                    return availableArazis;
                })
                .catch(() => {
                    availableSelect.innerHTML = '<option value="">Unable to load Arazis</option>';
                    return [];
                });
        }

        kisanSelect.addEventListener('change', function(){
            rowsBody.innerHTML = '';
            rowIndex = 0;
            calculateTotals();
            loadArazis();
        });

        searchInput.addEventListener('input', renderAvailableOptions);
        paidInput.addEventListener('input', calculateTotals);

        addButton.addEventListener('click', function(){
            const arazi = availableArazis.find(item => String(item.id) === String(availableSelect.value));
            addAraziRow(arazi);
        });

        // Autocomplete for Arazi search
        (function(){
            const input = document.getElementById('arazi_search');
            const sugg = document.getElementById('arazi_suggestions');
            const ajaxUrl = @json(route('ajax.arazi.search'));
            let debounceTimer = null;

            function hideSuggestions(){ sugg.style.display = 'none'; sugg.innerHTML = ''; }
            function showSuggestions(items){
                sugg.innerHTML = '';
                if(!items || !items.length){ hideSuggestions(); return; }
                items.forEach(function(it){
                    const a = document.createElement('button');
                    a.type = 'button';
                    a.className = 'list-group-item list-group-item-action';
                    a.textContent = it.text || it.label || ('Arazi-' + (it.id || ''));
                    a.dataset.araziId = it.id;
                    a.addEventListener('click', function(){
                        const selectedId = this.dataset.araziId;
                        hideSuggestions();
                        input.value = this.textContent;
                        // fetch arazi info to determine kisan and then load arazis
                        (async function(){
                            try{
                                const infoRes = await fetch(@json(route('arazis.info', ['arazi' => '__ARAZI_ID__'])).replace('__ARAZI_ID__', encodeURIComponent(selectedId)));
                                if(!infoRes.ok) return;
                                const info = await infoRes.json();
                                if(info && info.kisan && info.kisan.id){
                                    // set kisan and reload arazis, then preselect this arazi
                                    kisanSelect.value = info.kisan.id;
                                    await loadArazis();
                                    // select the matched arazi in available list
                                    try{ availableSelect.value = String(selectedId); }catch(e){}
                                    renderAvailableOptions();
                                    // additionally check for customers who purchased this arazi
                                    try{
                                        const custRes = await fetch(@json(route('arazis.customers', ['arazi' => '__ARAZI_ID__'])).replace('__ARAZI_ID__', encodeURIComponent(selectedId)));
                                        if(custRes.ok){
                                            const custJson = await custRes.json();
                                            const customers = custJson.customers || [];
                                            if(Array.isArray(customers) && customers.length > 0){
                                                // If single customer with single purchase, auto-select bond/entry
                                                if(customers.length === 1 && customers[0].purchases === 1 && Array.isArray(customers[0].bonds) && customers[0].bonds.length === 1){
                                                    // auto-select kisan + arazi as above (already set)
                                                    // nothing else to do for now
                                                } else {
                                                    // show modal to allow user select relevant customer / bond
                                                    if(window.showAraziCustomers) window.showAraziCustomers(customers);
                                                    return;
                                                }
                                            }
                                        }
                                    }catch(e){}
                                } else {
                                    // fallback: if arazi code may match multiple entries, call by-code
                                    const code = input.value.trim();
                                    try{
                                        const res = await fetch(@json(route('arazis.by-code')) + '?code=' + encodeURIComponent(code));
                                        if(res.ok){
                                            const json = await res.json();
                                            if(json.found && Array.isArray(json.matches) && json.matches.length > 1){
                                                showAraziMatches(json.matches);
                                                return;
                                            }
                                            if(json.found && json.arazi_id){
                                                const aid = json.arazi_id;
                                                const info2 = await (await fetch(@json(route('arazis.info', ['arazi' => '__ARAZI_ID__'])).replace('__ARAZI_ID__', encodeURIComponent(aid)))).json();
                                                if(info2 && info2.kisan && info2.kisan.id){
                                                    kisanSelect.value = info2.kisan.id;
                                                    await loadArazis();
                                                    try{ availableSelect.value = String(aid); }catch(e){}
                                                    renderAvailableOptions();
                                                }
                                            }
                                        }
                                    }catch(e){}
                                }
                            }catch(e){}
                        })();
                    });
                    sugg.appendChild(a);
                });
                sugg.style.display = 'block';
            }

            input.addEventListener('input', function(){
                const q = this.value.trim();
                clearTimeout(debounceTimer);
                if(!q){ hideSuggestions(); return; }
                debounceTimer = setTimeout(async function(){
                    try{
                        const res = await fetch(ajaxUrl + '?q=' + encodeURIComponent(q));
                        if(!res.ok) return hideSuggestions();
                        const json = await res.json();
                        const items = json.results || [];
                        showSuggestions(items);
                    }catch(e){ hideSuggestions(); }
                }, 250);
            });

            document.addEventListener('click', function(ev){ if(!ev.target.closest || !ev.target.closest('#arazi_search') && !ev.target.closest('#arazi_suggestions')) hideSuggestions(); });
        })();

        // handle arazi:selected from modal (choose specific arazi)
        window.addEventListener('arazi:selected', async function(evt){
            try{
                const a = evt.detail || {};
                if(!a || !a.id) return;
                // fetch info and set kisan -> load arazis -> select this arazi
                const infoRes = await fetch(@json(route('arazis.info', ['arazi' => '__ARAZI_ID__'])).replace('__ARAZI_ID__', encodeURIComponent(a.id)));
                if(!infoRes.ok) return;
                const info = await infoRes.json();
                if(info && info.kisan && info.kisan.id){
                    kisanSelect.value = info.kisan.id;
                    await loadArazis();
                    try{ availableSelect.value = String(a.id); }catch(e){}
                    renderAvailableOptions();
                }
            }catch(e){}
        });

        const rowsToLoad = Object.keys(oldRows || {}).length
            ? Object.values(oldRows).map(row => ({
                id: row.arazi_id,
                label: 'Arazi-' + row.arazi_id,
                land_size: row.land_size,
                sale_land: row.sale_land,
                sale_rate: row.sale_rate,
                sale_amount: row.sale_amount,
                unit: 'gaz'
            }))
            : initialRows;

        rowsToLoad.forEach(addAraziRow);
        loadArazis();
        calculateTotals();
    })();
</script>
@include('partials.arazi_customers_modal')
@endsection
