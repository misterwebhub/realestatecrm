@php
    $isEdit = isset($item) && $item->exists;
    $action = $action ?? route('customer-bonds.store');
    $method = $method ?? 'POST';
    $customers = $customers ?? [];
    $customerDetails = $customerDetails ?? [];
    $arazis = $arazis ?? [];
    $agents = $agents ?? [];
    $selectedPlotIds = old('plot_ids', isset($item) && $item->exists ? $item->plots->pluck('id')->map(fn ($id) => (string) $id)->all() : []);
    $selectedPlotIds = is_array($selectedPlotIds) ? array_map('strval', $selectedPlotIds) : array_filter([(string) $selectedPlotIds]);
    $selectedPlotAmounts = old('plot_amounts', isset($item) && $item->exists ? $item->plots->mapWithKeys(fn ($plot) => [$plot->id => $plot->pivot->sale_amount])->all() : []);
@endphp
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>{{ $isEdit ? 'Edit' : 'Create' }} Customer Bond</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        .wrrper{width:990px;margin:0 auto;border:5px solid black;padding:8px}
        table {border-collapse: collapse;width:100%;}
        table, td, th {border: 1px solid black;text-align:center;}
        th{padding:5px;background:#ececec}
        td{padding:10px}
        .style4{height:237px}
        .style3{height:131px}
        .style1{height:78px}
        .style5{width:415px;text-align:left}
        .textboxmain{width:100%}
        .small{font-size:12px;color:#555}
        label{font-weight:700}
        .form-row{margin-bottom:8px}
        .plot-panel{border:1px solid #d6d6d6;border-radius:8px;padding:12px;text-align:left;background:#fafafa}
        .plot-summary{display:grid;grid-template-columns:repeat(3,1fr);gap:10px;margin-top:10px}
        .plot-summary div{border:1px solid #ddd;border-radius:6px;padding:8px;background:white}
        .plot-detail{margin-top:8px;padding:8px;border-left:4px solid #0d6efd;background:#eef5ff}
        .selected-plots th,.selected-plots td{padding:6px}
        .clean-section{border:1px solid #bdbdbd;border-radius:8px;padding:12px;margin-top:12px;text-align:left;background:#fff}
        .clean-grid{display:grid;grid-template-columns:1fr 1fr;gap:12px}
        .hidden-summary{display:none}
    </style>
</head>
<body>
<div class="wrrper" id="main">
    <form action="{{ $action }}" method="POST">
        @csrf
        @if($method !== 'POST')
            @method($method)
        @endif

        <table>
            <tr>
                <td style="font-weight:bold;">CIN-U45201UP2019PTC123734</td>
                <td bgcolor="#00FFCC"><strong>CUSTOMER REG. NO</strong>&nbsp;
                    <input type="text" name="bond_no" value="{{ old('bond_no', $item->bond_no ?? '') }}" readonly />
                </td>
                <td style="text-align:right;font-weight:bold;">MOB. +91-9696446268, 9935142277</td>
            </tr>
            <tr>
                <td colspan="3" class="style4" style="text-align:center">
                    <div style="display:block;text-align:center">
                        <p style="font-size:37pt;color:red;font-weight:bold;margin:0;line-height:1;">HEED REAL</p>
                        <p style="font-size:21pt;margin:0;line-height:1;">ESTATE PRIVATE LIMITED</p>
                        <p style="display:inline-block;padding:6px 8px;background-color:#000080;color:white;font-size:15pt;margin-top:6px;">19A, New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</p>
                    </div>
                    <div style="margin-top:10px;text-align:justify;font-size:13pt;line-height:1.45;padding:8px;">
                        <strong>CERTIFIED</strong> that the associate described in the Schedule here to is registered in the Joint Venture of Consideration as shown in the Schedule under the Plan of the Company, subject to the regular payment of subscription(s) mentioned in the said Schedule and also subject to the "General Terms & Conditions" printed overleaf and the terms and conditions as per the rules book, as may be amended from time to time. The Company shall pay in Indian currency at its associate service center through the corporate office the amount due under this certificate in accordance with the terms of the said Schedule to the person to whom the same is expressly made payable. It is hereby declared that the Schedule, the "General Terms & Conditions" and other terms of the rules book, as amended from time to time, shall be deemed to be a part of this certificate.
                    </div>
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <th>Regd.No & Date of Commencement</th>
                <th>Plan Name / Term</th>
                <th>Mode of Payment</th>
                <th>Consideration Amount</th>
                <th>Installment of subscription Payment<br><span class="small">(No. of months)</span></th>
            </tr>
            <tr>
                <td><input type="date" name="bond_date" value="{{ old('bond_date', optional($item->bond_date)->format('Y-m-d') ?? '') }}" /></td>
                <td><input type="text" name="bond_type" value="{{ old('bond_type', $item->bond_type ?? '') }}" /></td>
                <td>
                    <select name="bayana_mode">
                        <option value="">--Select--</option>
                        <option value="cash" {{ old('bayana_mode', $item->bayana_mode ?? '') == 'cash' ? 'selected' : '' }}>CASH</option>
                        <option value="cheque" {{ old('bayana_mode', $item->bayana_mode ?? '') == 'cheque' ? 'selected' : '' }}>CHEQUE</option>
                    </select>
                </td>
                <td><input type="number" step="0.01" name="total_amount" class="total-amount-input" value="{{ old('total_amount', $item->total_amount ?? $item->bond_amount ?? 0) }}" readonly /></td>
                <td>
                    @php
                        $__instRaw = old('installment_amount', $item->installment_amount ?? $item->no_of_months ?? null);
                        $__instDisplay = ($__instRaw === null || $__instRaw === '') ? '' : min(84, max(0, (int) $__instRaw));
                        $__nmRaw = old('no_of_months', $item->no_of_months ?? $item->installment_amount ?? null);
                        $__nmSync = ($__nmRaw === null || $__nmRaw === '') ? '' : min(84, max(0, (int) $__nmRaw));
                    @endphp
                    <input type="number" min="0" max="84" step="1" name="installment_amount" id="installment-subscription-payment" value="{{ $__instDisplay }}" />
                    <input type="hidden" name="no_of_months" id="no-of-months-sync" value="{{ $__nmSync }}" />
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <th>Installment Due Date</th>
                <th>Booking Amount</th>
                <th>Expiry Date</th>
                <th>Customer Broker</th>
            </tr>
            <tr>
                <td><input type="date" name="last_date" id="installment-due-date" value="{{ old('last_date', optional($item->last_date)->format('Y-m-d') ?? '') }}" /></td>
                <td><input type="number" step="0.01" name="amount" class="booking-amount-input" value="{{ old('amount', $item->amount ?? '') }}" /></td>
                <td>
                    <input type="hidden" name="expiry_date" id="expiry-date" value="{{ old('expiry_date', optional($item->expiry_date)->format('Y-m-d') ?? '') }}" />
                    <span id="expiry-date-label">{{ old('expiry_date', optional($item->expiry_date)->format('Y-m-d') ?? '-') }}</span>
                </td>
                <td>
                    <div class="d-flex gap-2 justify-content-center">
                    <select name="broker_id" id="broker-select">
                        <option value="">--Select--</option>
                        @foreach($agents as $id => $name)
                            <option value="{{ $id }}" {{ (string)$id === (string) old('broker_id', $item->broker_id ?? '') ? 'selected' : '' }}>{{ $name }}</option>
                        @endforeach
                    </select>
                    <button type="button" class="btn btn-outline-primary btn-sm" data-bs-toggle="modal" data-bs-target="#addBrokerModal">Add Broker</button>
                    </div>
                </td>
            </tr>
        </table>

        <div class="clean-section">
            <div class="clean-grid">
                <div>
                    <label for="customer-select" class="form-label">Name, D.O.B and Address of Associate</label>
                    <select name="customer_id" id="customer-select" class="form-select">
                        <option value="">--Select Customer--</option>
                        @foreach($customers as $id => $name)
                            <option value="{{ $id }}" {{ (string)$id === (string) old('customer_id', $item->customer_id ?? '') ? 'selected' : '' }}>{{ $name }}</option>
                        @endforeach
                    </select>
                    <textarea name="customer_address" id="customer-address" class="form-control mt-2" rows="5">{{ old('customer_address', $item->customer?->address ?? '') }}</textarea>
                </div>
                <div>
                    <label for="arazi-select" class="form-label">Arazi No.</label>
                    <select name="arazi_id" id="arazi-select" class="form-select">
                        <option value="">--Select Arazi--</option>
                        @foreach($arazis as $id => $label)
                            <option value="{{ $id }}" {{ (string)$id === (string) old('arazi_id', $item->arazi_id ?? '') ? 'selected' : '' }}>{{ $label }}</option>
                        @endforeach
                    </select>

                    <div class="plot-panel mt-3">
                        <label for="plot-select" class="form-label">Available Plots For Selected Arazi</label>
                        <div class="d-flex gap-2">
                            <select id="plot-select" class="form-select form-select-sm">
                                <option value="">--Select Plot--</option>
                            </select>
                            <button type="button" id="add-plot" class="btn btn-primary btn-sm">Add Plot</button>
                        </div>
                        <div class="hidden-summary">
                            <input type="text" name="land_size" id="land-size" value="{{ old('land_size', $item->land_size ?? '') }}" readonly />
                            <input type="hidden" name="sale_land" id="sale-land" value="{{ old('sale_land', $item->sale_land ?? $item->land_size ?? '') }}">
                            <input type="number" step="0.01" name="total_amount" class="total-amount-input" value="{{ old('total_amount', $item->total_amount ?? $item->bond_amount ?? 0) }}" readonly />
                        </div>

                        <table class="table table-sm selected-plots mt-3 mb-0">
                            <thead>
                                <tr>
                                    <th>Plot</th>
                                    <th class="text-end">Gaz / Area</th>
                                    <th class="text-end">Plot Price<br><span class="small">(per gaz)</span></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody id="selected-plots-body">
                                <tr data-empty-row>
                                    <td colspan="4" class="text-center small">No plot selected.</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="mt-3">
                <label>Nominee's Name D.O.B and Relationship</label>
                <textarea name="nominee_details" class="form-control" rows="3">{{ old('nominee_details', $item->nominee_details ?? '') }}</textarea>
            </div>
            <div class="mt-3">
                <label>Aadhar/PAN/Voter/D.L NO</label>
                <input type="text" name="id_card_no" id="id-card-no" class="form-control" value="{{ old('id_card_no', $item->customer?->id_document_no ?? '') }}" />
            </div>
        </div>

        <table>
            <tr>
                <th>Total Payable Rupees</th>
                <td><input type="number" step="0.01" id="total-payable-label" value="0.00" readonly /></td>
            </tr>
            <tr>
                <th>EXPECTED SUM PAYABLE RUPEES</th>
                <td><input type="number" step="0.01" id="expected-sum" value="0.00" readonly /></td>
            </tr>
        </table>

        <div style="margin-top:12px">
            <label>Witnesses (one per line)</label>
            <textarea name="witnesses" rows="4" class="textboxmain">{{ old('witnesses', isset($item) ? implode("\n", $item->witnesses->pluck('name')->all()) : '') }}</textarea>
        </div>

        <div style="margin-top:12px">
            <label>Notes</label>
            <textarea name="notes" rows="4" class="textboxmain">{{ old('notes', $item->notes ?? '') }}</textarea>
        </div>

        <div style="margin-top:12px;text-align:center">
            <button type="submit" class="btn btn-primary">{{ $isEdit ? 'Update' : 'Create' }}</button>
            <a href="{{ route('customer-bonds.index') }}" class="btn btn-secondary">Cancel</a>
        </div>
    </form>
</div>

<div class="modal fade" id="addBrokerModal" tabindex="-1" aria-labelledby="addBrokerModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <form class="modal-content" id="add-broker-form">
            <div class="modal-header">
                <h5 class="modal-title" id="addBrokerModalLabel">Add Customer Broker</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="mb-2">
                    <label class="form-label">Name</label>
                    <input type="text" name="name" class="form-control" required>
                </div>
                <div class="mb-2">
                    <label class="form-label">Mobile</label>
                    <input type="text" name="mobile" class="form-control" required>
                </div>
                <div class="mb-2">
                    <label class="form-label">Rank/Level</label>
                    <input type="text" name="rank_title" class="form-control">
                </div>
                <div class="mb-2">
                    <label class="form-label">Commission %</label>
                    <input type="number" step="0.01" name="commission_percentage" class="form-control" value="0" required>
                </div>
                <div class="text-danger small d-none" id="broker-error"></div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                <button type="submit" class="btn btn-primary">Create Broker</button>
            </div>
        </form>
    </div>
</div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
<script>
    (function(){
        const araziPlotsUrl = @json(route('arazis.plots', ['arazi' => '__ARAZI_ID__']));
        const brokerStoreUrl = @json(route('agents.type.store', 'customer'));
        const csrfToken = @json(csrf_token());
        const customerDetails = @json($customerDetails);
        const selectedPlotIds = @json($selectedPlotIds);
        const selectedPlotAmounts = @json($selectedPlotAmounts);
        const customerSelect = document.getElementById('customer-select');
        const araziSelect = document.querySelector('select[name="arazi_id"]');
        const plotSelect = document.getElementById('plot-select');
        const addPlotButton = document.getElementById('add-plot');
        const selectedPlotsBody = document.getElementById('selected-plots-body');
        const landSize = document.getElementById('land-size');
        const saleLand = document.getElementById('sale-land');
        const totalAmountInputs = document.querySelectorAll('.total-amount-input');
        const bookingAmountInputs = document.querySelectorAll('.booking-amount-input');
        const totalPayableLabel = document.getElementById('total-payable-label');
        const expectedSum = document.getElementById('expected-sum');
        const customerAddress = document.getElementById('customer-address');
        const idCardNo = document.getElementById('id-card-no');
        const brokerSelect = document.getElementById('broker-select');
        const brokerForm = document.getElementById('add-broker-form');
        const brokerError = document.getElementById('broker-error');
        const installmentDueDate = document.getElementById('installment-due-date');
        const subscriptionMonthsInput = document.getElementById('installment-subscription-payment');
        const noOfMonthsSync = document.getElementById('no-of-months-sync');
        const expiryDate = document.getElementById('expiry-date');
        const expiryDateLabel = document.getElementById('expiry-date-label');
        const selectedPlots = new Map();
        let availablePlots = [];
        const bondForm = document.querySelector('#main > form');

        function escapeHtml(value){
            return String(value || '').replace(/[&<>"']/g, function(char){
                return {'&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#039;'}[char];
            });
        }

        function clearPlots(){
            plotSelect.innerHTML = '<option value="">--Select Plot--</option>';
            selectedPlots.clear();
            availablePlots = [];
            renderSelectedPlots();
            landSize.value = '';
            saleLand.value = '';
            updateTotals();
        }

        function formatAmount(value){
            return Number(value || 0).toFixed(2);
        }

        function formatGaz(value){
            const number = Number(value || 0);
            return Number.isInteger(number) ? String(number) : number.toFixed(2).replace(/\.?0+$/, '');
        }

        function plotLabel(plot){
            return plot.label || ('Plot-' + plot.id);
        }

        function renderAvailablePlots(){
            plotSelect.innerHTML = '<option value="">--Select Plot--</option>';

            availablePlots
                .filter(plot => !selectedPlots.has(String(plot.id)))
                .forEach(function(plot){
                    const opt = document.createElement('option');
                    opt.value = plot.id;
                    opt.textContent = plotLabel(plot) + ' | ' + formatGaz(plot.area) + ' gaz';
                    plotSelect.appendChild(opt);
                });
        }

        function bookingAmount(){
            return parseFloat(Array.from(bookingAmountInputs)[0]?.value || 0);
        }

        /** Line amount = (Gaz/Area) × (plot price per gaz). plot.amount is rate per gaz. */
        function linePayable(plot){
            const area = parseFloat(plot.area || 0);
            const rate = parseFloat(plot.amount || 0);
            if (Number.isNaN(area) || Number.isNaN(rate)) return 0;
            return area * rate;
        }

        function updateTotals(){
            let totalArea = 0;
            let totalPayable = 0;

            selectedPlots.forEach(function(plot){
                totalArea += parseFloat(plot.area || 0);
                totalPayable += linePayable(plot);
            });

            landSize.value = totalArea ? totalArea.toFixed(2) : '';
            saleLand.value = landSize.value;
            totalAmountInputs.forEach(input => {
                input.value = totalPayable ? totalPayable.toFixed(2) : '';
            });
            totalPayableLabel.value = formatAmount(totalPayable);
            expectedSum.value = formatAmount(Math.max(totalPayable - bookingAmount(), 0));
        }

        function syncBookingInputs(source){
            bookingAmountInputs.forEach(function(input){
                if(input !== source) input.value = source.value;
            });
            updateTotals();
        }

        function renderSelectedPlots(){
            selectedPlotsBody.innerHTML = '';

            if(!selectedPlots.size){
                selectedPlotsBody.innerHTML = '<tr data-empty-row><td colspan="4" class="text-center small">No plot selected.</td></tr>';
                updateTotals();
                renderAvailablePlots();
                return;
            }

            selectedPlots.forEach(function(plot){
                const tr = document.createElement('tr');
                tr.innerHTML = `
                    <td>
                        <input type="hidden" name="plot_ids[]" value="${plot.id}">
                        <strong>${escapeHtml(plotLabel(plot))}</strong>
                        <div class="small">${escapeHtml(plot.description || '')}</div>
                    </td>
                    <td class="text-end">${formatGaz(plot.area)}</td>
                    <td class="text-end">
                        <input type="number" step="0.01" min="0" name="plot_amounts[${plot.id}]" value="${plot.amount || ''}" class="form-control form-control-sm text-end" data-plot-amount="${plot.id}" placeholder="Rate / gaz">
                    </td>
                    <td class="text-end"><button type="button" class="btn btn-outline-danger btn-sm" data-remove-plot="${plot.id}">Delete</button></td>
                `;
                selectedPlotsBody.appendChild(tr);
            });

            updateTotals();
            renderAvailablePlots();
        }

        function addPlot(plotId){
            if(!plotId) return;
            const plot = availablePlots.find(item => String(item.id) === String(plotId));
            if(!plot || selectedPlots.has(String(plot.id))) return;

            const savedTotal = selectedPlotAmounts[String(plot.id)];
            if (savedTotal !== undefined && savedTotal !== null && savedTotal !== '') {
                const ar = parseFloat(plot.area || 0);
                plot.amount = ar > 0 ? (parseFloat(savedTotal) / ar).toFixed(2) : String(savedTotal);
            } else {
                plot.amount = plot.amount ?? '';
            }
            selectedPlots.set(String(plot.id), plot);
            renderSelectedPlots();
        }

        function loadPlots(araziId, selectPlotIds){
            clearPlots();
            if(!araziId) return;
            fetch(araziPlotsUrl.replace('__ARAZI_ID__', encodeURIComponent(araziId)))
                .then(r => r.json())
                .then(data => {
                    availablePlots = data;
                    renderAvailablePlots();
                    selectPlotIds.map(String).forEach(function(plotId){
                        addPlot(plotId);
                    });
                })
                .catch(()=>{});
        }

        // when arazi changes, load its plots
        araziSelect && araziSelect.addEventListener('change', function(){
            loadPlots(this.value, []);
        });

        addPlotButton && addPlotButton.addEventListener('click', function(){
            addPlot(plotSelect.value);
        });

        selectedPlotsBody && selectedPlotsBody.addEventListener('input', function(event){
            const amountInput = event.target.closest('[data-plot-amount]');
            if(!amountInput) return;

            const plot = selectedPlots.get(String(amountInput.dataset.plotAmount));
            if(!plot) return;

            plot.amount = amountInput.value;
            updateTotals();
        });

        selectedPlotsBody && selectedPlotsBody.addEventListener('click', function(event){
            const removeButton = event.target.closest('[data-remove-plot]');
            if(!removeButton) return;

            selectedPlots.delete(String(removeButton.dataset.removePlot));
            renderSelectedPlots();
        });

        bookingAmountInputs.forEach(function(input){
            input.addEventListener('input', function(){
                syncBookingInputs(input);
            });
        });

        bondForm && bondForm.addEventListener('submit', function(){
            selectedPlots.forEach(function(plot){
                const input = bondForm.querySelector('[name="plot_amounts[' + plot.id + ']"]');
                if (!input) return;
                const area = parseFloat(plot.area || 0);
                const rate = parseFloat(plot.amount || 0);
                input.value = (area * rate).toFixed(2);
            });
        });

        /** Whole calendar months between two Y-m-d strings (due → expiry). */
        var MAX_SUBSCRIPTION_MONTHS = 84;

        function monthsBetweenDueAndExpiry(dueStr, expiryStr){
            const start = new Date(dueStr + 'T12:00:00');
            const end = new Date(expiryStr + 'T12:00:00');
            if (Number.isNaN(start.getTime()) || Number.isNaN(end.getTime())) return 0;
            const y = end.getFullYear() - start.getFullYear();
            const m = end.getMonth() - start.getMonth();
            const total = y * 12 + m;
            return total >= 0 ? total : 0;
        }

        function subscriptionTermMonths(){
            if (!subscriptionMonthsInput || subscriptionMonthsInput.value === '') return 0;
            const m = parseInt(String(subscriptionMonthsInput.value), 10);
            return Number.isNaN(m) ? 0 : Math.min(MAX_SUBSCRIPTION_MONTHS, Math.max(0, m));
        }

        function clampSubscriptionMonthsField(){
            if (!subscriptionMonthsInput || subscriptionMonthsInput.value === '') return;
            const m = parseInt(String(subscriptionMonthsInput.value), 10);
            if (Number.isNaN(m)) return;
            const clamped = Math.min(MAX_SUBSCRIPTION_MONTHS, Math.max(0, m));
            if (clamped !== m) subscriptionMonthsInput.value = String(clamped);
        }

        function syncNoOfMonthsHidden(){
            if (!noOfMonthsSync || !subscriptionMonthsInput) return;
            const m = subscriptionTermMonths();
            noOfMonthsSync.value = m > 0 ? String(m) : '';
        }

        function formatYmdLocal(date){
            const y = date.getFullYear();
            const mo = String(date.getMonth() + 1).padStart(2, '0');
            const da = String(date.getDate()).padStart(2, '0');
            return y + '-' + mo + '-' + da;
        }

        /**
         * Expiry = Installment Due Date + installment months ("Installment of subscription Payment").
         * If that field empty but saved due + expiry exist, infer months once for edit screens.
         */
        function inferSubscriptionMonthsFromSavedSchedule(){
            if (!subscriptionMonthsInput || !installmentDueDate || !expiryDate) return;
            if (subscriptionMonthsInput.value !== '') return;
            if (!installmentDueDate.value || !expiryDate.value) return;
            let inferred = monthsBetweenDueAndExpiry(installmentDueDate.value, expiryDate.value);
            if (inferred > 0) subscriptionMonthsInput.value = String(Math.min(MAX_SUBSCRIPTION_MONTHS, inferred));
        }

        function updateExpiryDate(){
            if (!installmentDueDate || !expiryDate || !expiryDateLabel) return;
            clampSubscriptionMonthsField();
            syncNoOfMonthsHidden();

            const months = subscriptionTermMonths();
            if (!installmentDueDate.value){
                expiryDateLabel.textContent = expiryDate.value || '-';
                return;
            }

            if (!months || Number.isNaN(months)){
                expiryDateLabel.textContent = expiryDate.value || '-';
                return;
            }

            const date = new Date(installmentDueDate.value + 'T12:00:00');
            date.setMonth(date.getMonth() + months);
            const ymd = formatYmdLocal(date);
            expiryDate.value = ymd;
            expiryDateLabel.textContent = ymd;
        }

        installmentDueDate && installmentDueDate.addEventListener('change', updateExpiryDate);
        installmentDueDate && installmentDueDate.addEventListener('input', updateExpiryDate);
        subscriptionMonthsInput && subscriptionMonthsInput.addEventListener('input', function(){
            clampSubscriptionMonthsField();
            syncNoOfMonthsHidden();
            updateExpiryDate();
        });
        subscriptionMonthsInput && subscriptionMonthsInput.addEventListener('change', function(){
            clampSubscriptionMonthsField();
            syncNoOfMonthsHidden();
            updateExpiryDate();
        });

        inferSubscriptionMonthsFromSavedSchedule();
        syncNoOfMonthsHidden();
        updateExpiryDate();

        customerSelect && customerSelect.addEventListener('change', function(){
            const details = customerDetails[this.value];
            if(!details) return;

            customerAddress.value = [
                'Name: ' + (details.name || ''),
                'D.O.B: -',
                'Mobile: ' + (details.mobile || ''),
                'Address: ' + (details.address || ''),
            ].join("\n");
            idCardNo.value = details.id_document_no || '';
        });

        brokerForm && brokerForm.addEventListener('submit', function(event){
            event.preventDefault();
            brokerError.classList.add('d-none');
            brokerError.textContent = '';

            fetch(brokerStoreUrl, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'X-CSRF-TOKEN': csrfToken,
                },
                body: new FormData(brokerForm),
            })
                .then(async response => {
                    if(!response.ok){
                        const data = await response.json().catch(() => ({}));
                        throw new Error(Object.values(data.errors || {}).flat()[0] || 'Unable to create broker.');
                    }
                    return response.json();
                })
                .then(agent => {
                    const option = new Option(agent.label || agent.name, agent.id, true, true);
                    brokerSelect.appendChild(option);
                    brokerForm.reset();
                    bootstrap.Modal.getOrCreateInstance(document.getElementById('addBrokerModal')).hide();
                })
                .catch(error => {
                    brokerError.textContent = error.message;
                    brokerError.classList.remove('d-none');
                });
        });

        // on load, if arazi selected, load plots and preselect plot if any
        document.addEventListener('DOMContentLoaded', function(){
            const araziId = document.querySelector('select[name="arazi_id"]').value;
            if(araziId){
                loadPlots(araziId, selectedPlotIds);
            }
            updateTotals();
            inferSubscriptionMonthsFromSavedSchedule();
            syncNoOfMonthsHidden();
            updateExpiryDate();
        });
    })();
</script>
</body>
</html>
