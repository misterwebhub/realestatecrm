@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3 flex-wrap gap-2">
        <h5 class="mb-0">{{ $title }}</h5>
        <div class="ms-auto d-flex gap-2 no-print">
            <a href="{{ route('reports.index') }}" class="btn btn-outline-secondary btn-sm">Back</a>
            <button onclick="window.print()" class="btn btn-outline-primary btn-sm"><i class="bi bi-printer"></i></button>
        </div>
    </div>

    {{-- Filters --}}
    <form method="GET" class="row g-2 align-items-end mb-3 no-print">
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">User</label>
            <select name="user_id" class="form-select form-select-sm js-select2">
                <option value="">All Users</option>
                @foreach($users as $u)
                    <option value="{{ $u->id }}" @selected((string)$userId === (string)$u->id)>{{ $u->name }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Customer</label>
            <select name="customer_id" class="form-select form-select-sm js-select2">
                <option value="">All Customers</option>
                @foreach($customers as $c)
                    <option value="{{ $c->id }}" @selected((string)$customerId === (string)$c->id)>{{ $c->name }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Bond</label>
            <select name="bond_id" class="form-select form-select-sm js-select2">
                <option value="">All Bonds</option>
                @foreach($bondsList as $b)
                    <option value="{{ $b->id }}" @selected((string)$bondId === (string)$b->id)>{{ $b->bond_no }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Arazi</label>
            <select name="arazi_code" id="bc-arazi" class="form-select form-select-sm js-select2">
                <option value="">All Arazi</option>
                @foreach($araziCodes as $code)
                    <option value="{{ $code }}" @selected((string)$araziCode === (string)$code)>{{ $code }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Deed No</label>
            <select name="deed_no" id="bc-deed" class="form-select form-select-sm js-select2" data-url="{{ route('reports.deeds-by-arazi') }}">
                <option value="">All Deeds</option>
                @foreach($deedNos as $d)
                    <option value="{{ $d }}" @selected((string)$deedNo === (string)$d)>{{ $d }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Type</label>
            <select name="entry_type" class="form-select form-select-sm js-select2">
                <option value="">All Types</option>
                @foreach($entryTypes as $t)
                    <option value="{{ $t }}" @selected((string)$entryType === (string)$t)>{{ ucfirst($t) }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Method</label>
            <select name="payment_method" class="form-select form-select-sm js-select2">
                <option value="">All Methods</option>
                @foreach($paymentMethods as $m)
                    <option value="{{ $m }}" @selected((string)$paymentMethod === (string)$m)>{{ ucfirst($m) }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Broker</label>
            <select name="broker_id" class="form-select form-select-sm js-select2">
                <option value="">All Brokers</option>
                @foreach($brokers as $a)
                    <option value="{{ $a->id }}" @selected((string)$brokerId === (string)$a->id)>{{ $a->name }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Partner</label>
            <select name="partner_id" class="form-select form-select-sm js-select2">
                <option value="">All Partners</option>
                @foreach($partners as $pn)
                    <option value="{{ $pn->id }}" @selected((string)$partnerId === (string)$pn->id)>{{ $pn->name }}</option>
                @endforeach
            </select>
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Date From</label>
            <input type="date" name="date_from" value="{{ $dateFrom }}" class="form-control form-control-sm">
        </div>
        <div class="col-md-2 col-sm-4">
            <label class="form-label small fw-semibold mb-1">Date To</label>
            <input type="date" name="date_to" value="{{ $dateTo }}" class="form-control form-control-sm">
        </div>
        <div class="col-auto d-flex gap-2">
            <button class="btn btn-primary btn-sm">Apply</button>
            <a href="{{ route('reports.bonds-cumulative') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
        </div>
    </form>

    <div class="card">
        <div class="table-responsive">
            <table class="table table-sm table-hover align-middle mb-0" style="font-size:12px;">
                <thead class="table-light">
                    <tr>
                        <th>#</th>
                        <th>Bond</th>
                        <th>Customer</th>
                        <th>Arazi</th>
                        <th>Plot (gaz)</th>
                        <th>Broker</th>
                        <th class="text-end">Bond Amount</th>
                        <th class="text-end">Paid <span class="text-muted">(cash)</span></th>
                        <th class="text-end">Cheque Paid</th>
                        <th class="text-end">Cheque Balance</th>
                        <th class="text-center">Registry</th>
                        <th class="text-center">Cheque / Account</th>
                        <th class="text-end">Total Paid <span class="text-muted">(all)</span></th>
                        <th class="text-end">Total Balance <span class="text-muted">(all)</span></th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($rows as $i => $r)
                        <tr>
                            <td>{{ $i + 1 }}</td>
                            <td class="fw-semibold">{{ $r['bond_no'] }}</td>
                            <td>{{ $r['customer'] }}</td>
                            <td><span class="badge bg-primary-subtle text-primary-emphasis">{{ $r['arazi'] }}</span></td>
                            <td style="min-width:120px;">
                                @if(count($r['plots']) === 0)
                                    <span class="text-muted">—</span>
                                @else
                                    @php $plotTotal = collect($r['plots'])->sum('gaz'); @endphp
                                    <table style="width:100%;border-collapse:collapse;font-size:10px;border:1px solid #d0ddf0;border-radius:4px;overflow:hidden;">
                                        <thead>
                                            <tr style="background:#1a3a6b;">
                                                <th style="padding:1px 5px;color:rgba(255,255,255,.8);font-size:9px;font-weight:600;text-transform:uppercase;letter-spacing:.3px;border-right:1px solid rgba(255,255,255,.12);text-align:left;">Plot</th>
                                                <th style="padding:1px 5px;color:rgba(255,255,255,.8);font-size:9px;font-weight:600;text-transform:uppercase;letter-spacing:.3px;text-align:right;">Gaz</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            @foreach($r['plots'] as $j => $pl)
                                                <tr style="background:{{ $j % 2 === 0 ? '#fff' : '#f6f9ff' }};border-bottom:1px solid #e4ecf7;">
                                                    <td style="padding:1px 5px;border-right:1px solid #e4ecf7;font-weight:600;color:#1a3a6b;white-space:nowrap;">{{ $pl['label'] ?: '—' }}</td>
                                                    <td style="padding:1px 5px;text-align:right;color:#374151;white-space:nowrap;">{{ rtrim(rtrim(number_format($pl['gaz'],2),'0'),'.') }}</td>
                                                </tr>
                                            @endforeach
                                            @if(count($r['plots']) > 1)
                                                <tr style="background:#eef4ff;border-top:1px solid #d0ddf0;">
                                                    <td style="padding:1px 5px;border-right:1px solid #e4ecf7;font-weight:700;color:#15803d;text-align:right;">Total</td>
                                                    <td style="padding:1px 5px;text-align:right;font-weight:700;color:#15803d;white-space:nowrap;">{{ rtrim(rtrim(number_format($plotTotal,2),'0'),'.') }}</td>
                                                </tr>
                                            @endif
                                        </tbody>
                                    </table>
                                @endif
                            </td>
                            <td>{{ $r['broker'] }}</td>
                            <td class="text-end">{{ number_format($r['total'],2) }}</td>
                            <td class="text-end text-success">{{ number_format($r['paid'],2) }}</td>
                            <td class="text-end text-success">{{ number_format($r['cheque_paid'],2) }}</td>
                            <td class="text-end {{ $r['cheque_balance'] > 0 ? 'text-warning-emphasis' : '' }}">{{ number_format($r['cheque_balance'],2) }}</td>
                            <td class="text-center">
                                @if($r['reg_status'] === 'Done')
                                    <span class="badge bg-success">Done</span>
                                @elseif($r['reg_status'] === 'Pending')
                                    <span class="badge bg-warning text-dark">Pending</span>
                                @else
                                    <span class="text-muted">—</span>
                                @endif
                            </td>
                            <td class="text-center">
                                @if(!empty($r['account_name']))
                                    <div class="small text-muted">{{ $r['account_name'] }}</div>
                                @endif
                                <div class="fw-semibold">{{ number_format($r['cheque_total'],2) }}</div>
                                <button type="button" class="btn btn-outline-primary btn-sm py-0 px-2 mt-1 no-print js-see-cheque"
                                        data-bond="{{ $r['bond_id'] }}" data-bondno="{{ $r['bond_no'] }}">
                                    See ({{ $r['cheque_count'] }})
                                </button>
                            </td>
                            <td class="text-end fw-bold">{{ number_format($r['paid_all'],2) }}</td>
                            <td class="text-end fw-bold {{ $r['balance'] > 0 ? 'text-danger' : '' }}">{{ number_format($r['balance'],2) }}</td>
                        </tr>
                    @empty
                        <tr><td colspan="14" class="text-center text-muted py-4">No bonds found.</td></tr>
                    @endforelse
                </tbody>
                @if(count($rows))
                <tfoot class="table-light">
                    <tr class="fw-bold">
                        <td colspan="6" class="text-end">GRAND TOTAL</td>
                        <td class="text-end">{{ number_format($g_total,2) }}</td>
                        <td class="text-end text-success">{{ number_format($g_paid,2) }}</td>
                        <td class="text-end text-success">{{ number_format($g_cheque_paid,2) }}</td>
                        <td class="text-end">{{ number_format($g_cheque_balance,2) }}</td>
                        <td></td>
                        <td class="text-center">{{ number_format($g_cheque_total,2) }}</td>
                        <td class="text-end">{{ number_format($g_paid_all,2) }}</td>
                        <td class="text-end text-danger">{{ number_format($g_balance,2) }}</td>
                    </tr>
                </tfoot>
                @endif
            </table>
        </div>
    </div>
</div>

{{-- Cheque modal --}}
<div class="modal fade" id="chequeModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-scrollable">
        <div class="modal-content">
            <div class="modal-header py-2">
                <h6 class="modal-title mb-0">Cheques — Bond <span id="cm-bondno"></span></h6>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body">
                <div id="cm-loading" class="text-center py-3 text-muted">Loading…</div>
                <div id="cm-content" class="d-none">
                    <div class="d-flex flex-wrap gap-3 mb-2 small">
                        <span>Entries: <strong id="cm-count">0</strong></span>
                        <span>Total: <strong id="cm-total">0</strong></span>
                        <span class="text-success">Cleared: <strong id="cm-cleared">0</strong></span>
                        <span class="text-warning-emphasis">Pending: <strong id="cm-pending">0</strong></span>
                    </div>
                    <table class="table table-sm table-bordered mb-0" style="font-size:12px;">
                        <thead class="table-light">
                            <tr><th>Cheque No</th><th>Bank</th><th>Date</th><th class="text-end">Amount</th><th class="text-center">Status</th></tr>
                        </thead>
                        <tbody id="cm-rows"></tbody>
                    </table>
                    <div id="cm-empty" class="text-center text-muted py-3 d-none">No cheques for this bond in the selected range.</div>
                </div>
            </div>
        </div>
    </div>
</div>
@endsection

@push('styles')
<style>
@media print {
    .no-print { display: none !important; }
    .card { box-shadow: none !important; border: 1px solid #ddd !important; }
}
</style>
@endpush

@push('scripts')
<script>
(function(){
    function ready(cb){ if(window.jQuery){ jQuery(cb); } else { setTimeout(function(){ ready(cb); }, 100); } }
    ready(function($){
        // Arazi -> Deed dependent dropdown
        var $arazi = $('#bc-arazi'), $deed = $('#bc-deed');
        if($arazi.length && $deed.length){
            var url = $deed.data('url');
            var allOptions = $deed.find('option').clone();
            function refresh(){ if($deed.hasClass('select2-hidden-accessible')){ $deed.trigger('change.select2'); } }
            $arazi.on('change', function(){
                var code = $(this).val();
                if(!code){ $deed.empty().append(allOptions.clone()); refresh(); return; }
                $.getJSON(url, { arazi_code: code }).done(function(res){
                    var deeds = (res && res.deeds) ? res.deeds : [];
                    $deed.empty().append($('<option>').val('').text('All'));
                    $.each(deeds, function(i,d){ $deed.append($('<option>').val(d).text(d)); });
                    refresh();
                });
            });
        }

        // See-all-cheque modal
        var chequeUrl = "{{ route('reports.bond-cheques') }}";
        var modalEl = document.getElementById('chequeModal');
        var modal = modalEl ? bootstrap.Modal.getOrCreateInstance(modalEl) : null;

        $('.js-see-cheque').on('click', function(){
            var bondId = $(this).data('bond');
            $('#cm-bondno').text($(this).data('bondno'));
            $('#cm-loading').removeClass('d-none');
            $('#cm-content').addClass('d-none');
            $('#cm-rows').empty();
            if(modal) modal.show();

            $.getJSON(chequeUrl, { bond_id: bondId }).done(function(res){
                $('#cm-loading').addClass('d-none');
                $('#cm-content').removeClass('d-none');
                var s = res.summary || {};
                $('#cm-count').text(s.count || 0);
                $('#cm-total').text(Number(s.total||0).toLocaleString('en-IN',{minimumFractionDigits:2}));
                $('#cm-cleared').text(Number(s.cleared||0).toLocaleString('en-IN',{minimumFractionDigits:2}));
                $('#cm-pending').text(Number(s.pending||0).toLocaleString('en-IN',{minimumFractionDigits:2}));
                var rows = res.cheques || [];
                if(!rows.length){ $('#cm-empty').removeClass('d-none'); return; }
                $('#cm-empty').addClass('d-none');
                $.each(rows, function(i,c){
                    var badge = c.status === 'Cleared' ? 'bg-success' : 'bg-warning text-dark';
                    $('#cm-rows').append(
                        '<tr><td>'+c.cheque_number+'</td><td>'+c.bank_name+'</td><td>'+c.cheque_date+'</td>'+
                        '<td class="text-end">'+Number(c.amount).toLocaleString('en-IN',{minimumFractionDigits:2})+'</td>'+
                        '<td class="text-center"><span class="badge '+badge+'">'+c.status+'</span></td></tr>'
                    );
                });
            }).fail(function(){
                $('#cm-loading').addClass('d-none');
                $('#cm-content').removeClass('d-none');
                $('#cm-empty').removeClass('d-none').text('Failed to load cheques.');
            });
        });
    });
})();
</script>
@endpush
