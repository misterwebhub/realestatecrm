@extends('layouts.app')

@section('content')
    @php
        // Resolve the permission module: prefer the value passed by the controller,
        // otherwise derive it from the current route name (e.g. "kisans.index" -> "kisans").
        $pmMap = [
            'customer-bonds'         => 'customer_bonds',
            'customer-bond-payments' => 'customer_payments',
            'customer-bond-cheques'  => 'cheques',
            'kisan-payment'          => 'kisan_payments',
        ];
        $pm = $permModule ?? null;
        if (!$pm) {
            $rn   = optional(request()->route())->getName() ?? '';
            $base = \Illuminate\Support\Str::beforeLast($rn, '.');
            $pm   = $base ? ($pmMap[$base] ?? str_replace('-', '_', $base)) : null;
        }
        $authUser  = auth()->user();
        $legacyOk  = $authUser && in_array($authUser->role, ['admin', 'manager']);
        $canCreate = $authUser ? ($pm ? $authUser->can($pm . '.create') : $legacyOk) : false;
        $canEdit   = $authUser ? ($pm ? $authUser->can($pm . '.edit')   : $legacyOk) : false;
        $canDelete = $authUser ? ($pm ? $authUser->can($pm . '.delete') : $legacyOk) : false;
    @endphp
    <style>
        /* Compact, tidy layout for the wide Customer Bond Payments table */
        .cbp-table { font-size: 12.5px; }
        .cbp-table thead th {
            font-size: 11px;
            font-weight: 700;
            text-transform: uppercase;
            letter-spacing: .3px;
            color: #475569;
            white-space: nowrap;
            vertical-align: middle;
        }
        .cbp-table tbody td {
            padding: 7px 9px;
            vertical-align: middle;
            white-space: nowrap;
        }
        /* Allow long free-text columns to wrap instead of stretching the table */
        .cbp-table tbody td.cbp-wrap { white-space: normal; min-width: 120px; }
        .cbp-table .btn-sm { padding: 2px 8px; font-size: 11.5px; }
    </style>
    <div class="card card-outline card-primary">
        <div class="card-header d-flex align-items-center flex-wrap gap-2">
            @if(!empty($searchInHeader))
                <div class="d-flex align-items-center gap-3 flex-grow-1">

                    <form method="get" class="d-flex ms-3" action="{{ url()->current() }}">
                        <input name="q" value="{{ $searchQuery ?? '' }}" placeholder="Search by Arazi code, plot no or title" class="form-control form-control-sm" style="min-width:320px;" />
                        <button class="btn btn-sm btn-outline-secondary ms-2" type="submit">Search</button>
                        @if(!empty($searchQuery))
                            <a href="{{ url()->current() }}" class="btn btn-sm btn-outline-secondary ms-2">Clear</a>
                        @endif
                    </form>
                </div>
            @else
                <h5 class="card-title mb-0 fw-bold">{{ $title }}</h5>
            @endif

            @if(($exportCsvUrl ?? null) || $canCreate)
                <div class="d-flex flex-wrap gap-2 align-items-center ms-auto">
                    @if(isset($exportCsvUrl) && $exportCsvUrl)
                        <a href="{{ $exportCsvUrl }}" class="btn btn-outline-success btn-sm">
                            <i class="bi bi-filetype-csv"></i> Export CSV
                        </a>
                    @endif
                    @php $isCustomerBondIndex = $isCustomerBondIndex ?? str_contains($title, 'Customer Bond'); @endphp
                    @if($canCreate)
                        <a href="{{ $createUrl }}" @if($isCustomerBondIndex) target="_blank" rel="noopener" @endif class="btn btn-primary btn-sm">
                            <i class="bi bi-plus-lg"></i> Add New
                        </a>
                    @endif
                </div>
            @endif
        </div>

        @if(!empty($isCustomerPaymentIndex))
            <div class="card-body border-top py-2 px-3">
                @if(empty($cp_show_all))
                    <div class="small text-muted mb-2">
                        <i class="bi bi-info-circle"></i>
                        Showing entries for the current month ({{ now()->format('F Y') }}) by default (fastest). Pick a date range or click <strong>Show All</strong> to widen it.
                    </div>
                @endif
                <form method="GET" class="row g-2 align-items-end">
                    <div class="col-md-3">
                        <label class="form-label small fw-semibold mb-1">Name / Mobile</label>
                        <input type="text" name="q" value="{{ $cp_q ?? '' }}"
                               class="form-control form-control-sm" placeholder="Customer name or mobile…">
                    </div>
                    <div class="col-md-2">
                        <label class="form-label small fw-semibold mb-1">Bond No</label>
                        <input type="text" name="bond" value="{{ $cp_bond ?? '' }}"
                               class="form-control form-control-sm" placeholder="e.g. CB00001…">
                    </div>
                    <div class="col-md-2">
                        <label class="form-label small fw-semibold mb-1">Arazi No</label>
                        <input type="text" name="arazi_code" value="{{ $cp_arazi ?? '' }}"
                               class="form-control form-control-sm" placeholder="e.g. 419…">
                    </div>
                    <div class="col-md-2">
                        <label class="form-label small fw-semibold mb-1">Plot Title</label>
                        <input type="text" name="plot" value="{{ $cp_plot ?? '' }}"
                               class="form-control form-control-sm" placeholder="Plot title…">
                    </div>
                    <div class="col-md-2">
                        <label class="form-label small fw-semibold mb-1">Broker</label>
                        <select name="broker_id" class="form-select form-select-sm js-select2" data-placeholder="All Brokers">
                            <option value="">All Brokers</option>
                            @foreach($brokers ?? [] as $b)
                                <option value="{{ $b->id }}" @selected((string)($cp_broker_id ?? '') === (string)$b->id)>{{ $b->name }}</option>
                            @endforeach
                        </select>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label small fw-semibold mb-1">Type</label>
                        <select name="entry_type" class="form-select form-select-sm">
                            <option value="">All Types</option>
                            @foreach(['advance'=>'Advance','installment'=>'Installment','final'=>'Final','penalty'=>'Penalty','return'=>'Return','discount'=>'Discount','other'=>'Other'] as $val => $label)
                                <option value="{{ $val }}" {{ ($cp_entry_type ?? '') === $val ? 'selected' : '' }}>{{ $label }}</option>
                            @endforeach
                        </select>
                    </div>
                    <div class="col-md-1">
                        <label class="form-label small fw-semibold mb-1">Credit/Debit</label>
                        <select name="credit_debit" class="form-select form-select-sm">
                            <option value="">All</option>
                            <option value="credit" {{ ($cp_credit_debit ?? '') === 'credit' ? 'selected' : '' }}>Credit</option>
                            <option value="debit"  {{ ($cp_credit_debit ?? '') === 'debit'  ? 'selected' : '' }}>Debit</option>
                        </select>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label small fw-semibold mb-1">Created From</label>
                        <input type="date" name="date_from" value="{{ $cp_date_from ?? '' }}"
                               class="form-control form-control-sm">
                    </div>
                    <div class="col-md-2">
                        <label class="form-label small fw-semibold mb-1">Created To</label>
                        <input type="date" name="date_to" value="{{ $cp_date_to ?? '' }}"
                               class="form-control form-control-sm">
                    </div>
                    <div class="col-auto d-flex gap-2">
                        <button type="submit" class="btn btn-primary btn-sm">Search</button>
                        <a href="{{ route('customer-bond-payments.index') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                        @if(empty($cp_show_all))
                            <a href="{{ route('customer-bond-payments.index', array_merge(request()->except(['date_from','date_to','page']), ['all' => 1])) }}"
                               class="btn btn-outline-warning btn-sm" title="Load every entry regardless of date — may be slow">
                                Show All
                            </a>
                        @else
                            <span class="badge text-bg-warning align-self-center">Showing all dates</span>
                        @endif
                    </div>
                    <div class="col-auto ms-auto">
                        <label class="form-label small fw-semibold mb-1">Delete by Entry No</label>
                        <div class="d-flex gap-1">
                            <input type="text" id="del-entry-no" class="form-control form-control-sm"
                                   placeholder="e.g. CP00952" style="max-width:140px;">
                            <button type="button" id="del-entry-btn" class="btn btn-danger btn-sm">
                                <i class="bi bi-trash"></i> Delete
                            </button>
                        </div>
                    </div>
                </form>
            </div>

            {{-- Cumulative summary of the filtered result set --}}
            @if(!empty($cpSummary))
            <div class="row g-2 mb-3">
                <div class="col-6 col-md-3">
                    <div class="card shadow-sm border-start border-4 border-secondary h-100">
                        <div class="card-body py-2">
                            <div class="small text-muted text-uppercase">Entries</div>
                            <div class="fs-6 fw-bold">{{ number_format($cpSummary['count']) }}</div>
                        </div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="card shadow-sm border-start border-4 border-success h-100">
                        <div class="card-body py-2">
                            <div class="small text-muted text-uppercase">Total Credit</div>
                            <div class="fs-6 fw-bold text-success">₹{{ number_format($cpSummary['credit'],2) }}</div>
                        </div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="card shadow-sm border-start border-4 border-danger h-100">
                        <div class="card-body py-2">
                            <div class="small text-muted text-uppercase">Total Debit</div>
                            <div class="fs-6 fw-bold text-danger">₹{{ number_format($cpSummary['debit'],2) }}</div>
                        </div>
                    </div>
                </div>
                <div class="col-6 col-md-3">
                    <div class="card shadow-sm border-start border-4 border-primary h-100">
                        <div class="card-body py-2">
                            <div class="small text-muted text-uppercase">Net Total</div>
                            <div class="fs-6 fw-bold {{ $cpSummary['net'] < 0 ? 'text-danger' : 'text-primary' }}">₹{{ number_format($cpSummary['net'],2) }}</div>
                        </div>
                    </div>
                </div>
            </div>
            @endif

            {{-- Delete-by-entry confirmation modal --}}
            <div class="modal fade" id="deleteEntryModal" tabindex="-1" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header bg-danger text-white">
                            <h5 class="modal-title">Confirm Delete Payment Entry</h5>
                            <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div id="del-entry-loading" class="text-center py-3 d-none">
                                <div class="spinner-border text-danger" role="status"></div>
                            </div>
                            <div id="del-entry-notfound" class="alert alert-warning mb-0 d-none">
                                No payment found for that entry number.
                            </div>
                            <div id="del-entry-details" class="d-none">
                                <p class="mb-2">Do you want to delete this entry?</p>
                                <table class="table table-sm mb-2">
                                    <tbody>
                                        <tr><th style="width:130px;">Entry No</th><td id="de-entry-no" class="fw-semibold"></td></tr>
                                        <tr><th>Bond No</th><td id="de-bond-no"></td></tr>
                                        <tr><th>Customer</th><td id="de-customer"></td></tr>
                                        <tr><th>Arazi</th><td id="de-arazi"></td></tr>
                                        <tr><th>Type</th><td id="de-type"></td></tr>
                                        <tr><th>Amount</th><td id="de-amount" class="fw-semibold text-danger"></td></tr>
                                        <tr><th>Entry Date</th><td id="de-date"></td></tr>
                                    </tbody>
                                </table>
                                <div class="small text-muted">This action cannot be undone.</div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline-secondary btn-sm" data-bs-dismiss="modal">Cancel</button>
                            <form id="del-entry-form" action="{{ route('customer-bond-payments.delete-by-entry') }}" method="POST" class="d-inline">
                                @csrf
                                @method('DELETE')
                                <input type="hidden" name="entry_no" id="del-entry-hidden">
                                <button type="submit" id="del-entry-proceed" class="btn btn-danger btn-sm" disabled>Proceed &amp; Delete</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

            <script>
                (function(){
                    var LOOKUP_URL = @json(route('customer-bond-payments.lookup-entry'));
                    var input   = document.getElementById('del-entry-no');
                    var btn     = document.getElementById('del-entry-btn');
                    var modalEl = document.getElementById('deleteEntryModal');
                    if(!btn || !modalEl) return;

                    var elLoading  = document.getElementById('del-entry-loading');
                    var elNotFound = document.getElementById('del-entry-notfound');
                    var elDetails  = document.getElementById('del-entry-details');
                    var elProceed  = document.getElementById('del-entry-proceed');
                    var elHidden   = document.getElementById('del-entry-hidden');

                    function show(el, on){ el.classList.toggle('d-none', !on); }

                    function openModal(){
                        if(window.bootstrap && bootstrap.Modal){
                            bootstrap.Modal.getOrCreateInstance(modalEl).show();
                        }
                    }

                    function lookup(){
                        var entry = (input.value || '').trim();
                        if(!entry){ input.focus(); return; }
                        show(elLoading, true); show(elNotFound, false); show(elDetails, false);
                        elProceed.disabled = true;
                        openModal();
                        fetch(LOOKUP_URL + '?entry_no=' + encodeURIComponent(entry), {headers:{'Accept':'application/json'}})
                            .then(function(r){ return r.json(); })
                            .then(function(d){
                                show(elLoading, false);
                                if(!d || !d.found){ show(elNotFound, true); return; }
                                document.getElementById('de-entry-no').textContent = d.entry_no;
                                document.getElementById('de-bond-no').textContent  = d.bond_no;
                                document.getElementById('de-customer').textContent = d.customer;
                                document.getElementById('de-arazi').textContent    = d.arazi_code;
                                document.getElementById('de-type').textContent     = d.entry_type;
                                document.getElementById('de-amount').textContent   = d.amount;
                                document.getElementById('de-date').textContent     = d.entry_date;
                                elHidden.value = d.entry_no;
                                show(elDetails, true);
                                elProceed.disabled = false;
                            })
                            .catch(function(){ show(elLoading, false); show(elNotFound, true); });
                    }

                    btn.addEventListener('click', lookup);
                    input.addEventListener('keydown', function(e){ if(e.key === 'Enter'){ e.preventDefault(); lookup(); } });
                })();
            </script>
        @endif

        @if(!empty($isKisanPaymentIndex))
            <div class="card-body border-top py-2 px-3">
                <form method="GET" class="row g-2 align-items-end">
                    <div class="col-md-5">
                        <label class="form-label small fw-semibold mb-1">Kisan Name / Mobile</label>
                        <input type="text" name="q" value="{{ $kp_q ?? '' }}"
                               class="form-control form-control-sm" placeholder="Search kisan name or mobile…">
                    </div>
                    <div class="col-md-4">
                        <label class="form-label small fw-semibold mb-1">Arazi No</label>
                        <input type="text" name="arazi_code" value="{{ $kp_arazi ?? '' }}"
                               class="form-control form-control-sm" placeholder="e.g. 419, 375KA…">
                    </div>
                    <div class="col-auto d-flex gap-2">
                        <button type="submit" class="btn btn-primary btn-sm">Search</button>
                        <a href="{{ route('kisan-payment.index') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                    </div>
                </form>
            </div>
        @endif

        @if(!empty($isKisanBondIndex))
            <div class="card-body border-top py-2 px-3">
                <form method="GET" class="row g-2 align-items-end">
                    <div class="col-md-5">
                        <label class="form-label small fw-semibold mb-1">Kisan Name / Mobile</label>
                        <input type="text" name="q" value="{{ $kb_q ?? '' }}"
                               class="form-control form-control-sm" placeholder="Search kisan name or mobile…">
                    </div>
                    <div class="col-md-4">
                        <label class="form-label small fw-semibold mb-1">Arazi No</label>
                        <input type="text" name="arazi_code" value="{{ $kb_arazi ?? '' }}"
                               class="form-control form-control-sm" placeholder="e.g. 419, 375KA…">
                    </div>
                    <div class="col-auto d-flex gap-2">
                        <button type="submit" class="btn btn-primary btn-sm">Search</button>
                        <a href="{{ route('kisan-bonds.index') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                    </div>
                </form>
            </div>
        @endif

        @if(!empty($isKisanIndex))
            <div class="card-body border-top py-2 px-3">
                <form method="GET" class="row g-2 align-items-end">
                    <div class="col-md-5">
                        <label class="form-label small fw-semibold mb-1">Name / Mobile / Reg. No</label>
                        <input type="text" name="q" value="{{ $kisan_q ?? '' }}"
                               class="form-control form-control-sm" placeholder="Search name, mobile, reg no…">
                    </div>
                    <div class="col-md-4">
                        <label class="form-label small fw-semibold mb-1">Arazi No</label>
                        <input type="text" name="arazi_code" value="{{ $kisan_arazi ?? '' }}"
                               class="form-control form-control-sm" placeholder="e.g. 419, 375KA…">
                    </div>
                    <div class="col-auto d-flex gap-2">
                        <button type="submit" class="btn btn-primary btn-sm">Search</button>
                        <a href="{{ route('kisans.index') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
                    </div>
                </form>
            </div>
        @endif

        @if(!empty($isCustomerBondIndex))
            <div class="card-body border-top">
                <form class="row g-2 align-items-end" method="GET">
                    <div class="col-2">
                        <label class="form-label small">Arazi</label>
                        <select id="filter-arazi" name="arazi_code" class="form-select form-select-sm">
                            <option value="">All</option>
                            @foreach($arazis ?? [] as $code => $label)
                                <option value="{{ $code }}" @selected((string)$filter_arazi === (string)$code)>{{ $label }}</option>
                            @endforeach
                        </select>
                    </div>
                    <script>
                        (function(){
                            try{
                                if(window.jQuery && jQuery.fn.select2){
                                    jQuery(function(){
                                        jQuery('#filter-arazi').select2({
                                            theme: 'bootstrap-5',
                                            placeholder: 'All Arazis',
                                            allowClear: true,
                                            minimumResultsForSearch: 0,
                                            dropdownParent: jQuery(document.body),
                                            matcher: function(params, data){
                                                if(!params || !params.term) return data;
                                                var term = params.term.toString().toLowerCase();
                                                var txt = (data.text || '').toString().toLowerCase();
                                                if(txt.indexOf(term) !== -1) return data;
                                                return null;
                                            }
                                        });
                                    });
                                }
                            }catch(e){ /* ignore */ }
                        })();
                    </script>
                    <div class="col-auto">
                        <label class="form-label small">Plot Title</label>
                        <input type="text" name="plot" value="{{ $filter_plot ?? '' }}" class="form-control form-control-sm" placeholder="Plot title…">
                    </div>
                    <div class="col-auto">
                        <label class="form-label small">Customer</label>
                        <input type="text" name="q" value="{{ $filter_q ?? '' }}" class="form-control form-control-sm" placeholder="Name or mobile…">
                    </div>
                    <div class="col-auto">
                        <label class="form-label small">Bond No</label>
                        <input type="text" name="bond_no" value="{{ $filter_bond_no ?? '' }}" class="form-control form-control-sm" placeholder="Bond no…">
                    </div>
                    <div class="col-2">
                        <label class="form-label small">Broker</label>
                        <select id="filter-broker" name="broker_id" class="form-select form-select-sm">
                            <option value="">All</option>
                            @foreach($brokers ?? [] as $b)
                                <option value="{{ $b->id }}" @selected((string)($filter_broker_id ?? '') === (string)$b->id)>{{ $b->name }}</option>
                            @endforeach
                        </select>
                    </div>
                    <script>
                        (function(){
                            try{
                                if(window.jQuery && jQuery.fn.select2){
                                    jQuery(function(){
                                        jQuery('#filter-broker').select2({
                                            theme: 'bootstrap-5',
                                            placeholder: 'All Brokers',
                                            allowClear: true,
                                            dropdownParent: jQuery(document.body)
                                        });
                                    });
                                }
                            }catch(e){ /* ignore */ }
                        })();
                    </script>
                    <div class="col-auto">
                        <label class="form-label small">Bond Date From</label>
                        <input type="date" name="date_from" value="{{ $filter_date_from ?? '' }}" class="form-control form-control-sm">
                    </div>
                    <div class="col-auto">
                        <label class="form-label small">Bond Date To</label>
                        <input type="date" name="date_to" value="{{ $filter_date_to ?? '' }}" class="form-control form-control-sm">
                    </div>
                    <div class="col-auto">
                        <button class="btn btn-sm btn-primary">Filter</button>
                        <a href="{{ route('customer-bonds.index') }}" class="btn btn-sm btn-outline-secondary ms-1">Clear</a>
                    </div>
                    <div class="col-auto ms-auto">
                        <label class="form-label small fw-semibold mb-1">Delete by Bond No</label>
                        <div class="d-flex gap-1">
                            <input type="text" id="del-bond-no" class="form-control form-control-sm"
                                   placeholder="e.g. CB00001" style="max-width:140px;">
                            <button type="button" id="del-bond-btn" class="btn btn-danger btn-sm">
                                <i class="bi bi-trash"></i> Delete
                            </button>
                        </div>
                    </div>
                </form>
            </div>

            {{-- Delete-by-bond-no confirmation modal --}}
            <div class="modal fade" id="deleteBondModal" tabindex="-1" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header bg-danger text-white">
                            <h5 class="modal-title">Confirm Delete Bond</h5>
                            <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div id="del-bond-loading" class="text-center py-3 d-none">
                                <div class="spinner-border text-danger" role="status"></div>
                            </div>
                            <div id="del-bond-notfound" class="alert alert-warning mb-0 d-none">
                                No bond found for that bond number.
                            </div>
                            <div id="del-bond-details" class="d-none">
                                <p class="mb-2">Do you want to delete this bond?</p>
                                <table class="table table-sm mb-2">
                                    <tbody>
                                        <tr><th style="width:130px;">Bond No</th><td id="db-bond-no" class="fw-semibold"></td></tr>
                                        <tr><th>Customer</th><td id="db-customer"></td></tr>
                                        <tr><th>Arazi</th><td id="db-arazi"></td></tr>
                                        <tr><th>Plots</th><td id="db-plots"></td></tr>
                                        <tr><th>Amount</th><td id="db-amount" class="fw-semibold text-danger"></td></tr>
                                        <tr><th>Bond Date</th><td id="db-date"></td></tr>
                                    </tbody>
                                </table>
                                <div class="small text-muted">This action cannot be undone. All plots, payments and cheques linked to this bond may be affected.</div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline-secondary btn-sm" data-bs-dismiss="modal">Cancel</button>
                            <form id="del-bond-form" action="{{ route('customer-bonds.delete-by-bond') }}" method="POST" class="d-inline">
                                @csrf
                                @method('DELETE')
                                <input type="hidden" name="bond_no" id="del-bond-hidden">
                                <button type="submit" id="del-bond-proceed" class="btn btn-danger btn-sm" disabled>Proceed &amp; Delete</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

            <script>
                (function(){
                    var LOOKUP_URL = @json(route('customer-bonds.lookup-bond'));
                    var input   = document.getElementById('del-bond-no');
                    var btn     = document.getElementById('del-bond-btn');
                    var modalEl = document.getElementById('deleteBondModal');
                    if(!btn || !modalEl) return;

                    var elLoading  = document.getElementById('del-bond-loading');
                    var elNotFound = document.getElementById('del-bond-notfound');
                    var elDetails  = document.getElementById('del-bond-details');
                    var elProceed  = document.getElementById('del-bond-proceed');
                    var elHidden   = document.getElementById('del-bond-hidden');

                    function show(el, on){ el.classList.toggle('d-none', !on); }

                    function openModal(){
                        if(window.bootstrap && bootstrap.Modal){
                            bootstrap.Modal.getOrCreateInstance(modalEl).show();
                        }
                    }

                    function lookup(){
                        var bondNo = (input.value || '').trim();
                        if(!bondNo){ input.focus(); return; }
                        show(elLoading, true); show(elNotFound, false); show(elDetails, false);
                        elProceed.disabled = true;
                        openModal();
                        fetch(LOOKUP_URL + '?bond_no=' + encodeURIComponent(bondNo), {headers:{'Accept':'application/json'}})
                            .then(function(r){ return r.json(); })
                            .then(function(d){
                                show(elLoading, false);
                                if(!d || !d.found){ show(elNotFound, true); return; }
                                document.getElementById('db-bond-no').textContent  = d.bond_no;
                                document.getElementById('db-customer').textContent = d.customer;
                                document.getElementById('db-arazi').textContent    = d.arazi_code;
                                document.getElementById('db-plots').textContent    = d.plots;
                                document.getElementById('db-amount').textContent   = d.amount;
                                document.getElementById('db-date').textContent     = d.bond_date;
                                elHidden.value = d.bond_no;
                                show(elDetails, true);
                                elProceed.disabled = false;
                            })
                            .catch(function(){ show(elLoading, false); show(elNotFound, true); });
                    }

                    btn.addEventListener('click', lookup);
                    input.addEventListener('keydown', function(e){ if(e.key === 'Enter'){ e.preventDefault(); lookup(); } });
                })();
            </script>
        @endif

        @if(!empty($isPlotIndex))
            <div class="card-body border-top">
                <form class="row g-2 align-items-end" method="GET" action="{{ url()->current() }}">
                    <div class="col-md-4">
                        <label class="form-label small fw-semibold mb-1">Filter by Arazi</label>
                        <select id="plot-filter-arazi" name="arazi_code" class="form-select form-select-sm">
                            <option value="">All Arazis</option>
                            @foreach($araziOptions ?? [] as $code => $label)
                                <option value="{{ $code }}" @selected((string)($filterArazi ?? '') === (string)$code)>{{ $label }}</option>
                            @endforeach
                        </select>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label small fw-semibold mb-1">Filter by Plot</label>
                        <select id="plot-filter-plot" name="plot_id" class="form-select form-select-sm" @if(empty($filterArazi)) disabled @endif>
                            <option value="">All Plots</option>
                            @foreach($filterPlots ?? [] as $p)
                                <option value="{{ $p['id'] }}" @selected((string)($filterPlotId ?? '') === (string)$p['id'])>{{ $p['label'] }}</option>
                            @endforeach
                        </select>
                    </div>
                    <div class="col-auto">
                        <button class="btn btn-sm btn-primary">Filter</button>
                        <a href="{{ url()->current() }}" class="btn btn-sm btn-outline-secondary ms-1">Clear</a>
                    </div>
                </form>
            </div>
            <script>
                (function(){
                    var PLOTS_BASE = @json($plotsByCodeBase ?? url('arazi-no'));
                    var $arazi = document.getElementById('plot-filter-arazi');
                    var $plot  = document.getElementById('plot-filter-plot');

                    function resetPlots(placeholder){
                        $plot.innerHTML = '<option value="">' + placeholder + '</option>';
                    }

                    function refreshSelect2(){
                        if(window.jQuery && jQuery.fn.select2){ jQuery($plot).trigger('change.select2'); }
                    }

                    function loadPlots(code){
                        if(!code){ resetPlots('All Plots'); $plot.disabled = true; refreshSelect2(); return; }
                        $plot.disabled = true;
                        resetPlots('Loading…');
                        refreshSelect2();
                        fetch(PLOTS_BASE + '/' + encodeURIComponent(code) + '/plots', {headers:{'Accept':'application/json'}})
                            .then(function(r){ return r.json(); })
                            .then(function(data){
                                resetPlots('All Plots');
                                (data.plots || []).forEach(function(p){
                                    var opt = document.createElement('option');
                                    opt.value = p.id;
                                    opt.textContent = p.label || ('Plot #' + p.id);
                                    $plot.appendChild(opt);
                                });
                                $plot.disabled = false;
                                refreshSelect2();
                            })
                            .catch(function(){ resetPlots('All Plots'); $plot.disabled = false; refreshSelect2(); });
                    }

                    var bound = false;
                    function bindNative(){
                        if(bound || !$arazi) return;
                        bound = true;
                        $arazi.addEventListener('change', function(){ loadPlots(this.value); });
                    }
                    function initSelect2(){
                        if(!(window.jQuery && jQuery.fn && jQuery.fn.select2)) return false;
                        var $a = jQuery('#plot-filter-arazi');
                        var $p = jQuery('#plot-filter-plot');
                        if(!$a.length) return true;
                        var opts = {
                            theme: 'bootstrap-5',
                            allowClear: true,
                            width: '100%',
                            dropdownParent: jQuery(document.body),
                            minimumResultsForSearch: 0,
                            matcher: function(params, data){
                                if(!params || !params.term) return data;
                                var term = params.term.toString().toLowerCase();
                                var txt = (data.text || '').toString().toLowerCase();
                                return txt.indexOf(term) !== -1 ? data : null;
                            }
                        };
                        if(!$a.hasClass('select2-hidden-accessible')) $a.select2(opts);
                        if(!$p.hasClass('select2-hidden-accessible')) $p.select2(opts);
                        // Select2 fires jQuery 'change'; bind here so AJAX always fires on selection.
                        bound = true;
                        $a.off('change.plotfilter').on('change.plotfilter', function(){ loadPlots(this.value); });
                        return true;
                    }

                    // Wait until jQuery + Select2 are ready (they load in the page footer).
                    var tries = 0;
                    var timer = setInterval(function(){
                        tries++;
                        if(initSelect2() || tries > 50){
                            clearInterval(timer);
                            if(!bound) bindNative(); // fallback to plain <select>
                        }
                    }, 100);
                })();
            </script>
        @endif

        <div class="card-body table-responsive p-0">

            <table class="table table-striped table-hover mb-0 align-middle {{ !empty($isCustomerPaymentIndex) ? 'cbp-table' : '' }}">
                <thead>
                <tr>
                    @foreach($columns as $column)
                        <th class="text-nowrap">{{ $column }}</th>
                    @endforeach
                    <th class="text-end text-nowrap">Actions</th>
                </tr>
                </thead>
                <tbody>
                @forelse($rows as $row)
                    @php $hasBondArazi = isset($row['bond_arazi']); @endphp
                    <tr class="{{ $hasBondArazi ? 'align-top' : 'align-middle' }}" style="{{ $hasBondArazi ? 'border-top:2px solid #d0ddf0;' : '' }}">
                        @foreach($row['cells'] as $colIndex => $cell)
                            @if($hasBondArazi && $colIndex === 2)
                                {{-- Arazi column --}}
                                <td style="padding:10px 8px;">
                                    <span style="background:#1a3a6b;color:#fff;border-radius:4px;padding:3px 10px;font-size:11.5px;font-weight:700;letter-spacing:.3px;white-space:nowrap;">
                                        {{ $row['bond_arazi'] }}
                                    </span>
                                </td>
                            @elseif($hasBondArazi && $colIndex === 3)
                                {{-- Plots column --}}
                                <td style="padding:8px;min-width:200px;">
                                    @if(empty($row['bond_plots']))
                                        <span class="text-muted px-2" style="font-size:12px;">—</span>
                                    @else
                                        <table style="width:100%;border-collapse:collapse;font-size:12px;border:1px solid #d0ddf0;border-radius:6px;overflow:hidden;box-shadow:0 1px 4px rgba(26,58,107,.09);">
                                            <thead>
                                                <tr style="background:linear-gradient(90deg,#1a3a6b,#2a52a0);">
                                                    <th style="padding:4px 8px;color:rgba(255,255,255,.75);font-size:10px;font-weight:600;text-transform:uppercase;letter-spacing:.5px;border-right:1px solid rgba(255,255,255,.12);">Plot</th>
                                                    <th style="padding:4px 8px;color:rgba(255,255,255,.75);font-size:10px;font-weight:600;text-transform:uppercase;letter-spacing:.5px;">Area</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                @foreach($row['bond_plots'] as $pi => $plot)
                                                    <tr style="background:{{ $pi % 2 === 0 ? '#fff' : '#f6f9ff' }};border-bottom:1px solid #e4ecf7;"
                                                        onmouseover="this.style.background='#edf3ff'" onmouseout="this.style.background='{{ $pi % 2 === 0 ? '#fff' : '#f6f9ff' }}'">
                                                        <td style="padding:4px 8px;font-weight:600;color:#1a3a6b;border-right:1px solid #e4ecf7;white-space:nowrap;">{{ $plot['title'] }}</td>
                                                        <td style="padding:4px 8px;color:#374151;white-space:nowrap;">{{ $plot['area'] }}</td>
                                                    </tr>
                                                @endforeach
                                            </tbody>
                                        </table>
                                    @endif
                                </td>
                            @elseif(!empty($isCustomerPaymentIndex) && $colIndex === 3)
                                <td>
                                    <span class="cbp-cust-name" tabindex="0" role="button"
                                          data-bs-toggle="popover" data-bs-trigger="hover focus"
                                          data-bs-placement="top" data-bs-content="{{ $cell }}"
                                          title="Customer">{{ \Illuminate\Support\Str::limit($cell, 15) }}</span>
                                </td>
                            @elseif(is_array($cell) && ($cell['type'] ?? null) === 'arazi_plot_broker')
                                {{-- Merged Arazi / Plot / Broker column --}}
                                <td style="padding:8px;min-width:220px;">
                                    <div class="d-flex flex-wrap gap-1 mb-1">
                                        <span style="background:#1a3a6b;color:#fff;border-radius:4px;padding:2px 8px;font-size:11px;font-weight:700;letter-spacing:.3px;white-space:nowrap;">
                                            Arazi: {{ $cell['arazi'] }}
                                        </span>
                                        <span style="background:#6b4f1a;color:#fff;border-radius:4px;padding:2px 8px;font-size:11px;font-weight:700;letter-spacing:.3px;white-space:nowrap;">
                                            Broker: {{ $cell['broker'] }}
                                        </span>
                                    </div>
                                    @if(empty($cell['plots']))
                                        <span class="text-muted px-2" style="font-size:12px;">No plots</span>
                                    @else
                                        <table style="width:100%;border-collapse:collapse;font-size:12px;border:1px solid #d0ddf0;border-radius:6px;overflow:hidden;box-shadow:0 1px 4px rgba(26,58,107,.09);">
                                            <thead>
                                                <tr style="background:linear-gradient(90deg,#1a3a6b,#2a52a0);">
                                                    <th style="padding:4px 8px;color:rgba(255,255,255,.75);font-size:10px;font-weight:600;text-transform:uppercase;letter-spacing:.5px;border-right:1px solid rgba(255,255,255,.12);">Plot</th>
                                                    <th style="padding:4px 8px;color:rgba(255,255,255,.75);font-size:10px;font-weight:600;text-transform:uppercase;letter-spacing:.5px;">Area</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                @foreach($cell['plots'] as $pi => $plot)
                                                    <tr style="background:{{ $pi % 2 === 0 ? '#fff' : '#f6f9ff' }};border-bottom:1px solid #e4ecf7;"
                                                        onmouseover="this.style.background='#edf3ff'" onmouseout="this.style.background='{{ $pi % 2 === 0 ? '#fff' : '#f6f9ff' }}'">
                                                        <td style="padding:4px 8px;font-weight:600;color:#1a3a6b;border-right:1px solid #e4ecf7;white-space:nowrap;">{{ $plot['title'] }}</td>
                                                        <td style="padding:4px 8px;color:#374151;white-space:nowrap;">{{ $plot['area'] }}</td>
                                                    </tr>
                                                @endforeach
                                            </tbody>
                                        </table>
                                    @endif
                                </td>
                            @elseif(!empty($isCustomerPaymentIndex) && $colIndex === 8 && $cell !== '—')
                                <td class="text-success fw-semibold">{{ $cell }}</td>
                            @elseif(!empty($isCustomerPaymentIndex) && $colIndex === 9 && $cell !== '—')
                                <td class="text-danger fw-semibold">{{ $cell }}</td>
                            @else
                                <td style="{{ $hasBondArazi ? 'padding:10px 8px;' : '' }}">{{ $cell }}</td>
                            @endif
                        @endforeach
                        <td class="text-end" style="white-space:nowrap;">
                            @if(!empty($row['print_url']))
                                <a href="{{ $row['print_url'] }}?print=1" target="_blank" class="btn btn-outline-success btn-sm">Print</a>
                            @endif
                            {{-- @if(!empty($row['pdf_url']))
                                <a href="{{ $row['pdf_url'] }}" target="_blank" class="btn btn-outline-secondary btn-sm ms-1">PDF</a>
                            @endif --}}
                            @if(!empty($row['add_url']))
                                <a href="{{ $row['add_url'] }}" @if(!empty($row['open_in_new_tab'])) target="_blank" rel="noopener" @endif class="btn btn-outline-primary btn-sm ms-1">Add Bond</a>
                            @endif
                            @foreach($row['action_buttons'] ?? [] as $button)
                                <a href="{{ $button['url'] }}" 
                                   class="btn {{ $button['class'] ?? 'btn-outline-primary' }} btn-sm ms-1"
                                   @if(!empty($button['data_modal'])) data-bs-toggle="modal" data-bs-target="#{{ $button['data_target'] ?? 'modal' }}" @endif>
                                    {{ $button['label'] }}
                                </a>
                            @endforeach
                            @if($canEdit && !empty($row['edit_url']))
                                <a href="{{ $row['edit_url'] }}" @if(!empty($row['open_in_new_tab'])) target="_blank" rel="noopener" @endif class="btn btn-outline-secondary btn-sm">Edit</a>
                            @endif
                            @if($canDelete && !empty($row['delete_url']) && empty($isCustomerBondIndex))
                                <form action="{{ $row['delete_url'] }}" method="POST" class="d-inline-block" onsubmit="return confirm('Delete this record?');">
                                    @csrf
                                    @method('DELETE')
                                    <button type="submit" class="btn btn-outline-danger btn-sm">Delete</button>
                                </form>
                            @endif
                        </td>
                    </tr>
                @empty
                    <tr>
                        <td colspan="{{ count($columns) + 1 }}" class="text-center py-4">No records found.</td>
                    </tr>
                @endforelse
                </tbody>
            </table>
        </div>
        @if(!empty($paginator) && $paginator->hasPages())
            <div class="card-footer d-flex justify-content-between align-items-center flex-wrap gap-2">
                <div class="small text-muted">
                    Showing {{ number_format($paginator->firstItem() ?? 0) }}–{{ number_format($paginator->lastItem() ?? 0) }}
                    of {{ number_format($paginator->total()) }}
                </div>
                <div>{{ $paginator->links() }}</div>
            </div>
        @endif
    </div>

    @if(!empty($isCustomerPaymentIndex))
        <script>
            (function(){
                function initCustNamePopovers(){
                    if(!(window.bootstrap && bootstrap.Popover)) return;
                    document.querySelectorAll('.cbp-cust-name[data-bs-toggle="popover"]').forEach(function(el){
                        if(el._popoverInit) return;
                        el._popoverInit = true;
                        new bootstrap.Popover(el, {container:'body'});
                    });
                }
                if(document.readyState !== 'loading') initCustNamePopovers();
                else document.addEventListener('DOMContentLoaded', initCustNamePopovers);
            })();
        </script>
    @endif

    <!-- Change Log Modal -->
    <div class="modal fade" id="changeLogModal" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header bg-light">
                    <h5 class="modal-title fw-bold">
                        <i class="bi bi-clock-history me-1"></i> Change Log — <span id="clHeading" class="text-primary">Loading…</span>
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" id="changeLogBody">
                    <div class="text-center py-4"><div class="spinner-border text-primary" role="status"></div></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        (function(){
            var modalEl = document.getElementById('changeLogModal');
            if(!modalEl) return;
            var actionColors = { created:'success', updated:'info', deleted:'danger' };

            function esc(s){ return (s == null ? '' : String(s)).replace(/[&<>"]/g, function(c){ return {'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;'}[c]; }); }

            function render(data){
                var body = document.getElementById('changeLogBody');
                document.getElementById('clHeading').textContent = data.heading || '';
                if(!data.found || !data.entries || !data.entries.length){
                    body.innerHTML = '<p class="text-center text-muted py-4">No changes logged yet.</p>';
                    return;
                }
                var rows = '';
                data.entries.forEach(function(e){
                    var changes = e.changes || [];
                    if(!changes.length){
                        // created / deleted with no field diff — still show the action as one row
                        rows += '<tr><td>'+esc(e.user)+'</td><td class="text-nowrap">'+esc(e.when)+'</td>'
                             + '<td colspan="3" class="text-muted text-capitalize">'+esc(e.action)+'</td></tr>';
                        return;
                    }
                    changes.forEach(function(c){
                        rows += '<tr><td>'+esc(e.user)+'</td><td class="text-nowrap">'+esc(e.when)+'</td>'
                             + '<td class="fw-semibold">'+esc(c.field)+'</td>'
                             + '<td class="text-muted">'+esc(c.old)+'</td>'
                             + '<td>'+esc(c.new)+'</td></tr>';
                    });
                });
                body.innerHTML = '<div class="table-responsive"><table class="table table-sm table-bordered mb-0 small align-middle">'
                    + '<thead class="table-light"><tr><th>User</th><th>Date</th><th>Field</th><th>Old</th><th>New</th></tr></thead>'
                    + '<tbody>'+rows+'</tbody></table></div>';
            }

            modalEl.addEventListener('show.bs.modal', function(ev){
                var trigger = ev.relatedTarget;
                var url = trigger ? trigger.getAttribute('href') || trigger.getAttribute('data-url') : null;
                var body = document.getElementById('changeLogBody');
                document.getElementById('clHeading').textContent = 'Loading…';
                body.innerHTML = '<div class="text-center py-4"><div class="spinner-border text-primary" role="status"></div></div>';
                if(!url) return;
                fetch(url, {headers:{'Accept':'application/json'}})
                    .then(function(r){ return r.json(); })
                    .then(render)
                    .catch(function(){ body.innerHTML = '<div class="alert alert-danger m-2">Failed to load change log.</div>'; });
            });
        })();
    </script>

    <!-- Cheques Modal -->
    <div class="modal fade" id="chequesModal" tabindex="-1" role="dialog" aria-labelledby="chequesModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header bg-light">
                    <div>
                        <h4 class="modal-title mb-1 fw-bold" id="chequesModalLabel">
                            Bond Cheques — <span id="modalBondNo" class="text-primary">Loading...</span>
                        </h4>
                        <div class="text-muted" style="font-size:16px;" id="modalCustomerName"></div>
                    </div>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body p-0">

                    {{-- Bond summary strip --}}
                    <div id="modalBondSummary" style="display:none; background:#f8fafc; border-bottom:1px solid #e2e8f0; padding:18px 22px;">
                        <div class="row g-3 align-items-start">
                            <div class="col-6 col-md-3">
                                <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Bond Date</div>
                                <div class="fw-semibold" style="font-size:16px;" id="mBondDate">—</div>
                            </div>
                            <div class="col-6 col-md-3">
                                <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">End Date</div>
                                <div class="fw-semibold" style="font-size:16px;" id="mEndDate">—</div>
                            </div>
                            <div class="col-6 col-md-3">
                                <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Arazi</div>
                                <div class="fw-semibold" style="font-size:16px;" id="mArazi">—</div>
                            </div>
                            <div class="col-6 col-md-3">
                                <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Plot(s)</div>
                                <div class="fw-semibold" style="font-size:16px;" id="mPlots">—</div>
                            </div>
                            <div class="col-6 col-md-3 mt-1">
                                <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Total Amount</div>
                                <div class="fw-bold text-primary" style="font-size:16px;" id="mTotal">—</div>
                            </div>
                            <div class="col-6 col-md-3 mt-1">
                                <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Paid</div>
                                <div class="fw-bold text-success" style="font-size:16px;" id="mPaid">—</div>
                            </div>
                            <div class="col-6 col-md-3 mt-1">
                                <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Balance</div>
                                <div class="fw-bold text-danger" style="font-size:16px;" id="mBalance">—</div>
                            </div>
                            <div class="col-6 col-md-3 mt-1">
                                <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Last Installment</div>
                                <div class="fw-semibold" style="font-size:16px;" id="mLastPayment">—</div>
                            </div>
                        </div>
                    </div>

                    {{-- Cheques body --}}
                    <div id="chequesModalBody" class="p-3">
                        <div class="text-center py-4">
                            <div class="spinner-border text-primary" role="status">
                                <span class="visually-hidden">Loading...</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <a href="#" id="manageChequesBtnLink" target="_blank" class="btn btn-primary">Manage Cheques</a>
                </div>
            </div>
        </div>
    </div>

    <script>
        document.getElementById('chequesModal').addEventListener('show.bs.modal', function (e) {
            const button = e.relatedTarget;
            const modalUrl = button.getAttribute('href');
            const modalBody = document.getElementById('chequesModalBody');

            // reset
            document.getElementById('modalBondNo').textContent = 'Loading...';
            document.getElementById('modalCustomerName').textContent = '';
            document.getElementById('modalBondSummary').style.display = 'none';
            modalBody.innerHTML = '<div class="text-center py-4"><div class="spinner-border text-primary" role="status"></div></div>';

            fetch(modalUrl)
                .then(r => { if (!r.ok) throw new Error('Network error'); return r.json(); })
                .then(data => {
                    // header
                    document.getElementById('modalBondNo').textContent     = data.bond_no || '-';
                    document.getElementById('modalCustomerName').textContent = data.customer_name || '';

                    // bond summary strip
                    document.getElementById('mBondDate').textContent    = data.bond_date || '-';
                    document.getElementById('mEndDate').textContent      = data.end_date || '-';
                    document.getElementById('mArazi').textContent        = data.arazi || '-';
                    document.getElementById('mPlots').textContent        = data.plots || '-';
                    document.getElementById('mTotal').textContent        = '₹' + (data.total_amount || '0.00');
                    document.getElementById('mPaid').textContent         = '₹' + (data.paid_amount  || '0.00');
                    document.getElementById('mBalance').textContent      = '₹' + (data.balance      || '0.00');
                    const lastPmt = data.last_payment_date !== '-'
                        ? data.last_payment_date + ' · ₹' + data.last_payment_amt
                        : 'No payments yet';
                    document.getElementById('mLastPayment').textContent  = lastPmt;
                    document.getElementById('modalBondSummary').style.display = '';

                    // manage button
                    document.getElementById('manageChequesBtnLink').href = data.manage_url;

                    // cheques table
                    if (!data.cheques || data.cheques.length === 0) {
                        modalBody.innerHTML = '<p class="text-center text-muted py-4">No cheques recorded yet.</p>';
                        return;
                    }

                    const statusColors = { pending:'warning', cleared:'success', bounced:'danger', cancelled:'secondary' };
                    let rows = '';
                    data.cheques.forEach(c => {
                        const color = statusColors[c.status] || 'info';
                        rows += `<tr>
                            <td class="ps-3 fw-semibold" style="font-size:16px;">${c.cheque_number || '-'}</td>
                            <td style="font-size:16px;">${c.cheque_date || '-'}</td>
                            <td class="fw-bold" style="font-size:16px;">₹${c.amount}</td>
                            <td><span class="badge bg-${color}-subtle text-${color} border border-${color}-subtle" style="font-size:13px;padding:5px 11px;">${c.status}</span></td>
                            <td style="font-size:16px;" class="text-muted">${c.type || '-'}</td>
                            <td style="font-size:16px;">${c.account_name || '-'}</td>
                            <td style="font-size:16px;color:#64748b;">${c.notes || ''}</td>
                        </tr>`;
                    });

                    modalBody.innerHTML = `
                        <div class="table-responsive">
                            <table class="table table-hover mb-0 align-middle">
                                <thead style="background:#f8fafc;">
                                    <tr>
                                        <th class="ps-3 py-3" style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.5px;">Cheque #</th>
                                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.5px;">Date</th>
                                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.5px;">Amount</th>
                                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.5px;">Status</th>
                                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.5px;">Type</th>
                                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.5px;">Account</th>
                                        <th style="font-size:12px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.5px;">Notes</th>
                                    </tr>
                                </thead>
                                <tbody>${rows}</tbody>
                            </table>
                        </div>`;
                })
                .catch(err => {
                    console.error(err);
                    modalBody.innerHTML = '<div class="alert alert-danger m-3">Error loading cheques data.</div>';
                });
        });
    </script>
@endsection
