@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-header d-flex justify-content-between align-items-center">
            <h5 class="card-title mb-0">Manage Cheques for {{ $bond->bond_no }} - {{ $bond->customer?->name ?? '-' }}</h5>
            <div>
                <a href="{{ route('customer-bonds.index') }}" class="btn btn-secondary btn-sm">Back to Bonds</a>
            </div>
        </div>

        <div class="card-body">
            @if(session('success'))
                <div class="alert alert-success">{{ session('success') }}</div>
            @endif

            <form method="POST" action="{{ route('customer-bond-cheques.bulk-save') }}">
                @csrf
                <input type="hidden" name="customer_bond_id" value="{{ $bond->id }}">

                <table class="table table-sm table-bordered" id="chequesTable">
                    <thead>
                        <tr>
                            <th style="width:40px">#</th>
                            <th style="width:120px">Cheque No *</th>
                            <th style="width:110px">Cheque Date</th>
                            <th style="width:170px">Amount</th>
                            <th style="width:150px">Status</th>
                            <th style="width:100px">Type</th>
                            <th style="width:220px">Notes</th>
                            <th style="width:80px">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        @foreach($cheques as $i => $c)
                            <tr data-id="{{ $c->id }}">
                                <td class="align-middle">{{ $i+1 }}</td>
                                <td style="width:120px">
                                    <input type="hidden" name="cheques[{{ $i }}][id]" value="{{ $c->id }}">
                                    <input name="cheques[{{ $i }}][cheque_number]" required class="form-control" value="{{ $c->cheque_number }}">
                                </td>
                                <td style="width:110px"><input type="date" name="cheques[{{ $i }}][cheque_date]" class="form-control" value="{{ optional($c->cheque_date)->format('Y-m-d') ?: \Carbon\Carbon::now()->format('Y-m-d') }}"></td>
                                <td style="width:170px"><input type="number" step="0.01" name="cheques[{{ $i }}][amount]" required class="form-control" value="{{ $c->amount }}"></td>
                                <td style="width:150px">
                                    <select name="cheques[{{ $i }}][status]" class="form-select">
                                        <option value="pending" @selected($c->status==='pending')>Pending</option>
                                        <option value="cleared" @selected($c->status==='cleared')>Clear</option>
                                        <option value="bounced" @selected($c->status==='bounced')>Bounced</option>
                                        <option value="cancelled" @selected($c->status==='cancelled')>Cancelled</option>
                                    </select>
                                </td>
                                <td style="width:100px">
                                    <select name="cheques[{{ $i }}][type]" class="form-select">
                                        <option value="mentioned" @selected(($c->type ?? 'mentioned')==='mentioned')>Mentioned</option>
                                        <option value="not_mentioned" @selected(($c->type ?? 'mentioned')==='not_mentioned')>Not Mentioned</option>
                                    </select>
                                </td>
                                <td style="width:220px"><input name="cheques[{{ $i }}][notes]" class="form-control" value="{{ $c->notes }}"></td>
                                <td class="text-center"><button type="button" class="btn btn-danger btn-sm btn-remove">Remove</button></td>
                            </tr>
                        @endforeach
                    </tbody>
                </table>

                <div class="d-flex gap-2">
                    <button type="button" id="addRow" class="btn btn-outline-primary btn-sm">Add Row</button>
                    <button type="submit" class="btn btn-primary btn-sm">Save All</button>
                </div>
            </form>
        </div>
    </div>

    <template id="rowTemplate">
        <tr>
            <td class="align-middle">__IDX__</td>
            <td style="width:120px">
                <input name="cheques[__IDX0__][cheque_number]" required class="form-control">
            </td>
            <td style="width:110px"><input type="date" name="cheques[__IDX0__][cheque_date]" class="form-control" value="{{ \Carbon\Carbon::now()->format('Y-m-d') }}"></td>
            <td style="width:170px"><input type="number" step="0.01" name="cheques[__IDX0__][amount]" required class="form-control"></td>
            <td style="width:150px">
                <select name="cheques[__IDX0__][status]" class="form-select">
                    <option value="pending">Pending</option>
                    <option value="cleared">Clear</option>
                    <option value="bounced">Bounced</option>
                    <option value="cancelled">Cancelled</option>
                </select>
            </td>
            <td style="width:100px">
                <select name="cheques[__IDX0__][type]" class="form-select">
                    <option value="mentioned" selected>Mentioned</option>
                    <option value="not_mentioned">Not Mentioned</option>
                </select>
            </td>
            <td style="width:220px"><input name="cheques[__IDX0__][notes]" class="form-control"></td>
            <td class="text-center"><button type="button" class="btn btn-danger btn-sm btn-remove">Remove</button></td>
        </tr>
    </template>

    <script>
        (function(){
            const table = document.getElementById('chequesTable').querySelector('tbody');
            const tpl = document.getElementById('rowTemplate').innerHTML;
            const addBtn = document.getElementById('addRow');

            function reindex(){
                Array.from(table.querySelectorAll('tr')).forEach(function(row, idx){
                    row.querySelector('td').textContent = idx+1;
                    // rename inputs
                    Array.from(row.querySelectorAll('input, select')).forEach(function(inp){
                        const name = inp.name || '';
                        if(!name) return;
                        const newName = name.replace(/cheques\[\d+\]/, 'cheques['+idx+']');
                        inp.name = newName;
                    });
                });
            }

            addBtn.addEventListener('click', function(){
                const idx = table.querySelectorAll('tr').length;
                const html = tpl.replace(/__IDX__/g, idx+1).replace(/__IDX0__/g, idx);
                const tmp = document.createElement('tbody');
                tmp.innerHTML = html;
                const tr = tmp.querySelector('tr');
                table.appendChild(tr);
                reindex();
            });

            table.addEventListener('click', function(e){
                const btn = e.target.closest('.btn-remove');
                if(!btn) return;
                const tr = btn.closest('tr');
                if(!tr) return;

                // If this row corresponds to an existing DB record, add its id to deleted_ids[] so server deletes it.
                const existingId = tr.getAttribute('data-id');
                if (existingId) {
                    const form = table.closest('form');
                    const hidden = document.createElement('input');
                    hidden.type = 'hidden';
                    hidden.name = 'deleted_ids[]';
                    hidden.value = existingId;
                    form.appendChild(hidden);
                }

                tr.remove();
                reindex();
            });
        })();
    </script>
@endsection
