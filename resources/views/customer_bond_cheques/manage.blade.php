@extends('layouts.app')

@section('content')
@php
    $connectedAccounts = \App\Models\ConnectedAccount::orderBy('name')->get();
    $b = $bond;
    $plots     = $b->plots ?? collect();
    $witnesses = $b->witnesses ?? collect();
@endphp

{{-- Bond Info Strip --}}
<div class="d-flex align-items-start flex-wrap gap-2 mb-3">
    <div>
        <h5 class="fw-bold mb-0">Manage Cheques — {{ $b->bond_no }}</h5>
    </div>
    <div class="d-flex gap-2 ms-auto">
        <button type="button" class="btn btn-outline-success btn-sm" data-bs-toggle="modal" data-bs-target="#addAccountModal">
            <i class="bi bi-plus"></i> Add Account
        </button>
        <a href="{{ route('customer-bonds.index') }}" class="btn btn-secondary btn-sm">Back to Bonds</a>
    </div>
</div>

<div style="background:#fff; border:1px solid #e2e8f0; border-radius:8px; padding:16px 20px; margin-bottom:18px;">
    <div class="row g-3">
        <div class="col-6 col-md-3">
            <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Customer</div>
            <div class="fw-semibold" style="font-size:15px;">{{ $b->customer?->name ?? '—' }}</div>
            @if($b->mobile)<div style="font-size:12px;color:#64748b;">{{ $b->mobile }}</div>@endif
        </div>
        <div class="col-6 col-md-3">
            <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Arazi</div>
            <div class="fw-semibold" style="font-size:15px;">{{ $b->arazi?->name ?? '—' }}</div>
        </div>
        <div class="col-6 col-md-3">
            <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Plot(s)</div>
            @forelse($plots as $p)
                <div class="fw-semibold" style="font-size:15px;">{{ $p->plot_number ?? $p->name ?? 'Plot #'.$p->id }}
                    @if($p->land_size)<span class="text-muted fw-normal" style="font-size:12px;">({{ $p->land_size }})</span>@endif
                </div>
            @empty
                <div class="fw-semibold" style="font-size:15px;">—</div>
            @endforelse
        </div>
        <div class="col-6 col-md-3">
            <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Bond Date</div>
            <div class="fw-semibold" style="font-size:15px;">{{ $b->bond_date?->format('d M Y') ?? '—' }}</div>
        </div>
        <div class="col-6 col-md-3">
            <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">End Date</div>
            <div class="fw-semibold" style="font-size:15px;">{{ $b->expiry_date?->format('d M Y') ?? ($b->last_date?->format('d M Y') ?? '—') }}</div>
        </div>
        <div class="col-6 col-md-3">
            <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Total Amount</div>
            <div class="fw-bold text-primary" style="font-size:15px;">₹{{ number_format((float)($b->total_amount ?? 0), 2) }}</div>
        </div>
        <div class="col-6 col-md-3">
            <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Paid</div>
            <div class="fw-bold text-success" style="font-size:15px;">₹{{ number_format($netPaid, 2) }}</div>
        </div>
        <div class="col-6 col-md-3">
            <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Balance</div>
            <div class="fw-bold {{ $balance > 0 ? 'text-danger' : 'text-success' }}" style="font-size:15px;">₹{{ number_format($balance, 2) }}</div>
        </div>
        <div class="col-6 col-md-3">
            <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Installments Paid</div>
            <div class="fw-semibold" style="font-size:15px;">{{ $installmentNo }}
                @if($b->installment_amount)<span class="text-muted fw-normal" style="font-size:12px;">· ₹{{ number_format((float)$b->installment_amount,2) }}/inst</span>@endif
            </div>
        </div>
        @if($witnesses->count())
        <div class="col-6 col-md-3">
            <div class="text-muted" style="font-size:11px;font-weight:700;text-transform:uppercase;letter-spacing:.5px;">Witnesses</div>
            @foreach($witnesses as $w)
                <div class="fw-semibold" style="font-size:15px;">{{ $w->name }}
                    @if($w->mobile)<span class="text-muted fw-normal" style="font-size:12px;">· {{ $w->mobile }}</span>@endif
                </div>
            @endforeach
        </div>
        @endif
    </div>
</div>

{{-- ═══════════════════════════════════════════════════════ --}}
{{-- CHEQUES TABLE --}}
{{-- ═══════════════════════════════════════════════════════ --}}
<div class="card border-0 shadow-sm">
    <div class="card-header py-2 px-3 d-flex align-items-center gap-2 bg-white border-bottom">
        <span class="fw-bold" style="font-size:15px;"><i class="bi bi-credit-card-2-front me-1 text-primary"></i>Cheque Entries</span>
        @if($connectedAccounts->isEmpty())
            <span class="text-warning ms-auto" style="font-size:13px;"><i class="bi bi-exclamation-triangle me-1"></i>
                No accounts found. <a href="#" data-bs-toggle="modal" data-bs-target="#addAccountModal" class="fw-semibold">Add one</a> first.
            </span>
        @endif
    </div>

    <div class="card-body p-3">
        <form method="POST" action="{{ route('customer-bond-cheques.bulk-save') }}">
            @csrf
            <input type="hidden" name="customer_bond_id" value="{{ $bond->id }}">

            <div class="table-responsive">
                <table class="table table-sm table-bordered" id="chequesTable">
                    <thead>
                        <tr>
                            <th style="width:36px">#</th>
                            <th style="min-width:140px">Account <span class="text-danger">*</span></th>
                            <th style="width:140px">Cheque No <span class="text-danger">*</span></th>
                            <th style="width:130px">Cheque Date</th>
                            <th style="width:140px">Amount <span class="text-danger">*</span></th>
                            <th style="width:130px">Status</th>
                            <th style="width:120px">Type</th>
                            <th style="width:200px">Notes</th>
                            <th style="width:50px"></th>
                        </tr>
                    </thead>
                    <tbody>
                        @foreach($cheques as $i => $c)
                            <tr data-id="{{ $c->id }}">
                                <td class="align-middle text-center text-muted" style="font-size:12px;">{{ $i+1 }}</td>
                                <td>
                                    <input type="hidden" name="cheques[{{ $i }}][id]" value="{{ $c->id }}">
                                    <select name="cheques[{{ $i }}][connected_account_id]" class="form-select form-select-sm acc-select" required>
                                        <option value="">— Select —</option>
                                        @foreach($connectedAccounts as $acc)
                                            <option value="{{ $acc->id }}" @selected($c->connected_account_id == $acc->id)>
                                                {{ $acc->name }} / {{ $acc->mobile }}
                                            </option>
                                        @endforeach
                                    </select>
                                </td>
                                <td><input name="cheques[{{ $i }}][cheque_number]" required class="form-control form-control-sm" value="{{ $c->cheque_number }}"></td>
                                <td><input type="date" name="cheques[{{ $i }}][cheque_date]" class="form-control form-control-sm" value="{{ optional($c->cheque_date)->format('Y-m-d') ?: \Carbon\Carbon::now()->format('Y-m-d') }}"></td>
                                <td><input type="number" step="0.01" name="cheques[{{ $i }}][amount]" required class="form-control form-control-sm" value="{{ $c->amount }}"></td>
                                <td>
                                    <select name="cheques[{{ $i }}][status]" class="form-select form-select-sm">
                                        <option value="pending"   @selected($c->status==='pending')>Pending</option>
                                        <option value="cleared"   @selected($c->status==='cleared')>Cleared</option>
                                        <option value="bounced"   @selected($c->status==='bounced')>Bounced</option>
                                        <option value="cancelled" @selected($c->status==='cancelled')>Cancelled</option>
                                    </select>
                                </td>
                                <td>
                                    <select name="cheques[{{ $i }}][type]" class="form-select form-select-sm">
                                        <option value="mentioned"     @selected(($c->type ?? 'mentioned')==='mentioned')>Mentioned</option>
                                        <option value="not_mentioned" @selected(($c->type ?? 'mentioned')==='not_mentioned')>Not Mentioned</option>
                                    </select>
                                </td>
                                <td><input name="cheques[{{ $i }}][notes]" class="form-control form-control-sm" value="{{ $c->notes }}"></td>
                                <td class="text-center"><button type="button" class="btn btn-danger btn-sm btn-remove px-2">✕</button></td>
                            </tr>
                        @endforeach
                    </tbody>
                </table>
            </div>

            <div class="d-flex gap-2 mt-2">
                <button type="button" id="addRow" class="btn btn-outline-primary btn-sm">
                    <i class="bi bi-plus"></i> Add Row
                </button>
                <button type="submit" class="btn btn-primary btn-sm px-4">
                    <i class="bi bi-save me-1"></i> Save All
                </button>
            </div>
        </form>
    </div>
</div>

{{-- Row template --}}
<template id="rowTemplate">
    <tr>
        <td class="align-middle text-center text-muted" style="font-size:12px;">__IDX__</td>
        <td>
            <select name="cheques[__IDX0__][connected_account_id]" class="form-select form-select-sm acc-select" required>
                <option value="">— Select —</option>
                @foreach($connectedAccounts as $acc)
                    <option value="{{ $acc->id }}">{{ $acc->name }} / {{ $acc->mobile }}</option>
                @endforeach
            </select>
        </td>
        <td><input name="cheques[__IDX0__][cheque_number]" required class="form-control form-control-sm"></td>
        <td><input type="date" name="cheques[__IDX0__][cheque_date]" class="form-control form-control-sm" value="{{ \Carbon\Carbon::now()->format('Y-m-d') }}"></td>
        <td><input type="number" step="0.01" name="cheques[__IDX0__][amount]" required class="form-control form-control-sm"></td>
        <td>
            <select name="cheques[__IDX0__][status]" class="form-select form-select-sm">
                <option value="pending">Pending</option>
                <option value="cleared">Cleared</option>
                <option value="bounced">Bounced</option>
                <option value="cancelled">Cancelled</option>
            </select>
        </td>
        <td>
            <select name="cheques[__IDX0__][type]" class="form-select form-select-sm">
                <option value="mentioned" selected>Mentioned</option>
                <option value="not_mentioned">Not Mentioned</option>
            </select>
        </td>
        <td><input name="cheques[__IDX0__][notes]" class="form-control form-control-sm"></td>
        <td class="text-center"><button type="button" class="btn btn-danger btn-sm btn-remove px-2">✕</button></td>
    </tr>
</template>

{{-- Add Connected Account Modal --}}
<div class="modal fade" id="addAccountModal" tabindex="-1" aria-labelledby="addAccountModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" style="max-width:480px;">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title fw-bold" id="addAccountModalLabel"><i class="bi bi-person-plus me-2"></i>Add Connected Account</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body">
                <div id="accModalAlert" class="alert alert-danger d-none"></div>
                <div class="mb-3">
                    <label class="form-label fw-semibold">Name <span class="text-danger">*</span></label>
                    <input type="text" id="accName" class="form-control" placeholder="Full name">
                </div>
                <div class="mb-3">
                    <label class="form-label fw-semibold">Mobile <span class="text-danger">*</span></label>
                    <input type="text" id="accMobile" class="form-control" placeholder="Mobile number">
                </div>
                <div class="mb-3">
                    <label class="form-label">Address</label>
                    <input type="text" id="accAddress" class="form-control" placeholder="Address (optional)">
                </div>
                <div class="mb-1">
                    <label class="form-label">Notes</label>
                    <textarea id="accNotes" class="form-control" rows="2" placeholder="Optional notes"></textarea>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                <button type="button" class="btn btn-success" id="saveAccountBtn">
                    <span id="saveAccSpinner" class="spinner-border spinner-border-sm d-none me-1"></span>
                    Save Account
                </button>
            </div>
        </div>
    </div>
</div>

<script>
    (function(){
        const table  = document.getElementById('chequesTable').querySelector('tbody');
        const tpl    = document.getElementById('rowTemplate').innerHTML;
        const addBtn = document.getElementById('addRow');

        function reindex(){
            Array.from(table.querySelectorAll('tr')).forEach(function(row, idx){
                row.querySelector('td').textContent = idx + 1;
                Array.from(row.querySelectorAll('input, select')).forEach(function(inp){
                    const name = inp.name || '';
                    if(!name) return;
                    inp.name = name.replace(/cheques\[\d+\]/, 'cheques[' + idx + ']');
                });
            });
        }

        addBtn.addEventListener('click', function(){
            const idx = table.querySelectorAll('tr').length;
            const html = tpl.replace(/__IDX__/g, idx + 1).replace(/__IDX0__/g, idx);
            const tmp = document.createElement('tbody');
            tmp.innerHTML = html;
            const tr = tmp.querySelector('tr');
            table.appendChild(tr);
            if(window.jQuery && jQuery.fn.select2){
                try{ jQuery(tr).find('.acc-select').select2({ theme:'bootstrap-5', width:'100%', placeholder:'— Select —' }); }catch(e){}
            }
            reindex();
        });

        table.addEventListener('click', function(e){
            const btn = e.target.closest('.btn-remove');
            if(!btn) return;
            const tr = btn.closest('tr');
            const existingId = tr?.getAttribute('data-id');
            if(existingId){
                const hidden = document.createElement('input');
                hidden.type = 'hidden'; hidden.name = 'deleted_ids[]'; hidden.value = existingId;
                table.closest('form').appendChild(hidden);
            }
            tr?.remove();
            reindex();
        });

        // init select2 on existing rows
        if(window.jQuery && jQuery.fn.select2){
            try{
                jQuery('.acc-select').select2({ theme:'bootstrap-5', width:'100%', placeholder:'— Select —', allowClear:true });
            }catch(e){}
        }

        // ── Add Account Modal ──────────────────────────────────────────
        const addAccModal = document.getElementById('addAccountModal');
        const saveAccBtn  = document.getElementById('saveAccountBtn');
        const accAlert    = document.getElementById('accModalAlert');
        const accSpinner  = document.getElementById('saveAccSpinner');

        addAccModal.addEventListener('show.bs.modal', function(){
            document.getElementById('accName').value    = '';
            document.getElementById('accMobile').value  = '';
            document.getElementById('accAddress').value = '';
            document.getElementById('accNotes').value   = '';
            accAlert.classList.add('d-none');
            accAlert.textContent = '';
        });

        saveAccBtn.addEventListener('click', function(){
            const name    = document.getElementById('accName').value.trim();
            const mobile  = document.getElementById('accMobile').value.trim();
            const address = document.getElementById('accAddress').value.trim();
            const notes   = document.getElementById('accNotes').value.trim();

            accAlert.classList.add('d-none');
            if(!name){   accAlert.textContent = 'Name is required.';   accAlert.classList.remove('d-none'); return; }
            if(!mobile){ accAlert.textContent = 'Mobile is required.'; accAlert.classList.remove('d-none'); return; }

            saveAccBtn.disabled = true;
            accSpinner.classList.remove('d-none');

            fetch('{{ route("connected-accounts.store") }}', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-CSRF-TOKEN': document.querySelector('meta[name="csrf-token"]').content,
                    'Accept': 'application/json',
                },
                body: JSON.stringify({ name, mobile, address, notes })
            })
            .then(r => r.json())
            .then(function(json){
                saveAccBtn.disabled = false;
                accSpinner.classList.add('d-none');

                if(json.errors){
                    accAlert.textContent = Object.values(json.errors).flat().join(' ');
                    accAlert.classList.remove('d-none');
                    return;
                }
                if(!json.id){
                    accAlert.textContent = json.message || 'Failed to save account.';
                    accAlert.classList.remove('d-none');
                    return;
                }

                // Append new option to every .acc-select
                document.querySelectorAll('.acc-select').forEach(function(sel){
                    const opt = document.createElement('option');
                    opt.value = json.id;
                    opt.text  = json.name + ' / ' + json.mobile;
                    sel.appendChild(opt);
                    if(window.jQuery && jQuery.fn.select2){
                        try{ jQuery(sel).trigger('change'); }catch(e){}
                    }
                });

                bootstrap.Modal.getInstance(addAccModal).hide();

                const toast = document.createElement('div');
                toast.className = 'alert alert-success alert-dismissible position-fixed top-0 end-0 m-3 shadow';
                toast.style.zIndex = 9999;
                toast.innerHTML = '<i class="bi bi-check-circle me-1"></i> Account <strong>' + json.name + '</strong> added successfully.';
                toast.innerHTML += '<button type="button" class="btn-close" data-bs-dismiss="alert"></button>';
                document.body.appendChild(toast);
                setTimeout(function(){ toast.remove(); }, 4000);
            })
            .catch(function(){
                saveAccBtn.disabled = false;
                accSpinner.classList.add('d-none');
                accAlert.textContent = 'Network error. Please try again.';
                accAlert.classList.remove('d-none');
            });
        });
    })();
</script>
@endsection
