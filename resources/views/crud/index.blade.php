@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-header d-flex align-items-center justify-content-between flex-wrap gap-2">
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

            @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                <div class="d-flex flex-wrap gap-2 align-items-center">
                    @if(isset($exportCsvUrl) && $exportCsvUrl)
                        <a href="{{ $exportCsvUrl }}" class="btn btn-outline-success btn-sm">
                            <i class="bi bi-filetype-csv"></i> Export CSV
                        </a>
                    @endif
                    @php $isCustomerBondIndex = $isCustomerBondIndex ?? str_contains($title, 'Customer Bond'); @endphp
                    <a href="{{ $createUrl }}" @if($isCustomerBondIndex) target="_blank" rel="noopener" @endif class="btn btn-primary btn-sm">
                        <i class="bi bi-plus-lg"></i> Add New
                    </a>
                </div>
            @endif
        </div>

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
                        <select id="filter-arazi" name="arazi_id" class="form-select form-select-sm">
                            <option value="">All</option>
                            @foreach($arazis ?? [] as $id => $label)
                                <option value="{{ $id }}" @selected((string)$filter_arazi === (string)$id)>{{ $label }}</option>
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
                        <label class="form-label small">Plot (id or title)</label>
                        <input type="text" name="plot" value="{{ $filter_plot ?? '' }}" class="form-control form-control-sm" placeholder="Plot id or title">
                    </div>
                    <div class="col-auto">
                        <button class="btn btn-sm btn-primary">Filter</button>
                        <a href="{{ route('customer-bonds.index') }}" class="btn btn-sm btn-outline-secondary ms-1">Clear</a>
                    </div>
                </form>
            </div>
        @endif

        <div class="card-body table-responsive p-0">
          
            <table class="table table-striped table-hover mb-0 align-middle">
                <thead>
                <tr>
                    @foreach($columns as $column)
                        <th>{{ $column }}</th>
                    @endforeach
                    <th class="text-end">Actions</th>
                </tr>
                </thead>
                <tbody>
                @forelse($rows as $row)
                    <tr>
                        @foreach($row['cells'] as $cell)
                            <td>{{ $cell }}</td>
                        @endforeach
                        <td class="text-end" style="white-space:nowrap;">
                            @if(!empty($row['print_url']))
                                <a href="{{ $row['print_url'] }}?print=1" target="_blank" class="btn btn-outline-success btn-sm">Print</a>
                            @endif
                            @if(!empty($row['pdf_url']))
                                <a href="{{ $row['pdf_url'] }}" target="_blank" class="btn btn-outline-secondary btn-sm ms-1">PDF</a>
                            @endif
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
                            @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                                <a href="{{ $row['edit_url'] }}" @if(!empty($row['open_in_new_tab'])) target="_blank" rel="noopener" @endif class="btn btn-outline-secondary btn-sm">Edit</a>
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
    </div>

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
