@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-body">
            <h5 class="card-title">Plot Details Report</h5>

            <div class="row g-3 mb-3">
                <div class="col-md-6">
                    <label class="form-label">Arazi Number</label>
                    <div class="input-group">
                        <input type="text" id="arazi_input" class="form-control" placeholder="Enter Arazi no (legacy code)">
                        <button type="button" id="arazi_find" class="btn btn-outline-primary">Find</button>
                        <button type="button" id="show_plots_btn" class="btn btn-outline-secondary" title="Show plots for this Arazi">Show plots</button>
                    </div>
                    <input type="hidden" id="arazi_code_hidden" name="arazi_code">
                    <div id="arazi_label" class="form-text text-muted"></div>
                </div>
            </div>

            <div id="plots_container"></div>

            <div id="plots_table_wrapper" class="mt-3" style="display:none;">
                <div class="table-responsive">
                    <table class="table table-bordered table-striped" id="plots_table">
                        <thead class="table-light">
                            <tr>
                                <th>PLOT NO.</th>
                                <th>CUSTREG NO.</th>
                                <th>PLOT SIZE</th>
                                <th>DATE</th>
                                <th>NAME</th>
                                <th>CHECKBY</th>
                                <th>MOBILE</th>
                                <th>STATUS</th>
                                <th>RAGISTRY</th>
                                <th>Reg.AMOUNT</th>
                            </tr>
                        </thead>
                        <tbody id="plots_table_body"></tbody>
                        <tfoot>
                            <tr class="table-light">
                                <th colspan="2">Total plot size</th>
                                <th id="total_plot_size"></th>
                                <th colspan="7"></th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>

            <div id="arazi_details_wrapper" class="mt-4" style="display:none;">
                <h6>Arazi Details</h6>
                <div id="arazi_summary" class="mb-3"></div>

                <div id="arazi_bonds" class="mb-3"></div>

                <div id="arazi_transactions">
                    <h6>Transactions</h6>
                    <div class="table-responsive">
                        <table class="table table-sm table-striped">
                            <thead>
                                <tr><th>Date</th><th>Amount</th><th>Source</th><th>Bond No</th><th>Party</th><th>Notes</th></tr>
                            </thead>
                            <tbody id="arazi_transactions_body"></tbody>
                        </table>
                    </div>
                </div>
            </div>

        </div>
    </div>

    @include('partials.arazi_plots_modal')
    @include('partials.arazi_matches_modal')

    <script>
    (function(){
        const arazisByCodeUrl = @json(route('arazis.by-code'));

        document.getElementById('arazi_find').addEventListener('click', async function(){
            const code = document.getElementById('arazi_input').value.trim();
            document.getElementById('arazi_label').textContent = '';
            if(!code) return;
            try{
                const res = await fetch(arazisByCodeUrl + '?code=' + encodeURIComponent(code));
                if(!res.ok) return;
                const json = await res.json();
                if(!json.found){
                    document.getElementById('arazi_label').textContent = 'Arazi not found';
                    return;
                }
                if(json.matches && Array.isArray(json.matches) && json.matches.length > 0){
                    try{ showAraziMatches(json.matches); }catch(e){ console.debug(e); }
                    return;
                }
                // found a single arazi
                document.getElementById('arazi_label').textContent = json.arazi_label || '';
                document.getElementById('arazi_code_hidden').value = json.arazi_code || '';
                        if(json.arazi_id){
                            try{ showAraziPlots(json.arazi_id); }catch(e){ }
                        }
            }catch(e){ console.error(e); }
        });

        document.getElementById('show_plots_btn').addEventListener('click', function(){
            const code = document.getElementById('arazi_code_hidden').value || document.getElementById('arazi_input').value;
            if(!code) return alert('Select or find an Arazi first');
            // showAraziPlots needs an arazi ID; if we only have code, use it directly (plots-by-code handles it)
            try{ showAraziPlots(code); }catch(e){ console.debug(e); }
        });

        // Render plots into table when showAraziPlots is called
        const plotsBody = document.getElementById('plots_table_body');
        const plotsWrapper = document.getElementById('plots_table_wrapper');
        const totalSizeEl = document.getElementById('total_plot_size');

        // override existing showAraziPlots to also populate the page table
        const originalShowAraziPlots = window.showAraziPlots;
        window.showAraziPlots = async function(araziId){
            if(!araziId) return;
            try{
                // call existing function to show modal as well
                if(typeof originalShowAraziPlots === 'function') originalShowAraziPlots(araziId);
            }catch(e){ }

            try{
                const url = @json(route('arazis.plots', ['arazi' => '__ARAZI_ID__'])).replace('__ARAZI_ID__', encodeURIComponent(araziId));
                const res = await fetch(url);
                if(!res.ok) throw new Error('Failed to load plots');
                const plots = await res.json();
                plotsBody.innerHTML = '';
                let total = 0;
                (plots || []).forEach(function(p){
                    const plotNo = p.plot_number || p.plot_no || p.label || '';
                    const custReg = p.custregno || p.CUSTREGNO || p.customer_reg_no || p.customer_reg || '';
                    const area = (p.area !== undefined && p.area !== null) ? Number(p.area) : (p.PLOTSIZE !== undefined ? Number(p.PLOTSIZE) : '');
                    const date = p.date || p.created_at || p.date3 || '';
                    const name = p.NAMEDOBADDRESS || p.customer_label || p.title || p.name || '';
                    const checkby = p.checkby || p.CHECKBY || '';
                    const mobile = p.mobile || '';
                    const status = p.status || '';
                    const registry = p.ragistry || p.registry || '';
                    const registryAmt = p.ragistryamt || p.registry_amount || p.ragistryamt || '';

                    const tr = document.createElement('tr');
                    tr.innerHTML = `
                        <td>${plotNo}</td>
                        <td>${custReg}</td>
                        <td>${area !== '' ? (isFinite(area) ? area.toFixed(2) : area) : '-'}</td>
                        <td>${date ?? ''}</td>
                        <td>${escapeHtml(name)}</td>
                        <td>${checkby}</td>
                        <td>${mobile}</td>
                        <td>${status}</td>
                        <td>${registry}</td>
                        <td>${registryAmt}</td>
                    `;
                    plotsBody.appendChild(tr);
                    if(typeof area === 'number' && isFinite(area)) total += area;
                });
                plotsWrapper.style.display = (plots && plots.length) ? '' : 'none';
                totalSizeEl.textContent = (total ? total.toFixed(2) : '0');
                // fetch comprehensive arazi details (bonds, payments)
                try{
                    const detailsUrl = @json(route('arazis.details', ['arazi' => '__ARAZI_ID__'])).replace('__ARAZI_ID__', encodeURIComponent(araziId));
                    const dres = await fetch(detailsUrl);
                    if(dres.ok){
                        const data = await dres.json();
                        renderAraziDetails(data);
                    }
                }catch(e){ console.debug('Details fetch failed', e); }
            }catch(e){
                console.error('Failed to render plots table', e);
            }
        };

        function renderAraziDetails(data){
            if(!data) return;
            const wrapper = document.getElementById('arazi_details_wrapper');
            const sum = document.getElementById('arazi_summary');
            const bonds = document.getElementById('arazi_bonds');
            const txBody = document.getElementById('arazi_transactions_body');
            sum.innerHTML = '';
            bonds.innerHTML = '';
            txBody.innerHTML = '';

            const a = data.arazi || {};
            const html = `<div><strong>Code:</strong> ${escapeHtml(a.legacy_arazi_code || '')} &nbsp; <strong>Location:</strong> ${escapeHtml(a.location||'')} &nbsp; <strong>Size:</strong> ${a.size||''} ${a.unit||''}</div>`;
            sum.innerHTML = html;

            // kisan bonds
            if(Array.isArray(data.kisan_bonds) && data.kisan_bonds.length){
                const kbHtml = ['<h6>Kisan Bonds</h6>','<ul class="list-unstyled small">'];
                data.kisan_bonds.forEach(function(b){
                    kbHtml.push(`<li><strong>${escapeHtml(b.bond_no || '')}</strong> (${b.bond_date || ''}) - Kisan: ${escapeHtml((b.kisan && b.kisan.name) || '')} - Amount: ${b.sale_amount ?? b.total_amount ?? ''}</li>`);
                });
                kbHtml.push('</ul>');
                bonds.innerHTML += kbHtml.join('\n');
            }
            // customer bonds
            if(Array.isArray(data.customer_bonds) && data.customer_bonds.length){
                const cbHtml = ['<h6>Customer Bonds</h6>','<ul class="list-unstyled small">'];
                data.customer_bonds.forEach(function(b){
                    cbHtml.push(`<li><strong>${escapeHtml(b.bond_no || '')}</strong> (${b.bond_date || ''}) - Customer: ${escapeHtml((b.customer && b.customer.name) || '')} - Amount: ${b.total_amount ?? ''}</li>`);
                });
                cbHtml.push('</ul>');
                bonds.innerHTML += cbHtml.join('\n');
            }

            // transactions
            (data.transactions || []).forEach(function(t){
                const date = t.payment_date || t.entry_date || '';
                const amount = t.amount || '';
                const source = t.source || '';
                const bondNo = t.bond_no || '';
                const party = t.party || '';
                const notes = t.notes || t.entry_no || '';
                const tr = document.createElement('tr');
                tr.innerHTML = `<td>${date}</td><td>${amount}</td><td>${source}</td><td>${escapeHtml(bondNo)}</td><td>${escapeHtml(party)}</td><td>${escapeHtml(notes)}</td>`;
                txBody.appendChild(tr);
            });

            wrapper.style.display = '';
        }

        function escapeHtml(s){ if(!s) return ''; return String(s).replace(/[&<>"]+/g, function(ch){ return {'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;'}[ch]; }); }
    })();
    </script>

@endsection
