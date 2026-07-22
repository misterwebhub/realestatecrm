@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">
    <div class="card-header d-flex flex-wrap align-items-center gap-2">
        <h3 class="card-title mb-0"><i class="bi bi-hourglass-split me-1"></i> Plot Holds</h3>
        <button type="button" class="btn btn-sm btn-primary ms-auto" data-bs-toggle="collapse" data-bs-target="#addHoldForm">
            <i class="bi bi-plus-lg"></i> Add Hold
        </button>
    </div>
    <div class="card-body">
        <div class="collapse mb-4" id="addHoldForm">
            <div class="border rounded p-3 bg-light">
                <h5 class="mb-3">Set a plot on hold</h5>
                <form method="POST" action="{{ route('plot-holds.store') }}" class="row g-3" id="holdCreateForm">
                    @csrf
                    <div class="col-md-4">
                        <label class="form-label mb-1">Arazi <span class="text-danger">*</span></label>
                        <select name="arazi_code" id="hold_arazi_code" class="form-select" required>
                            <option value="">Select Arazi</option>
                            @foreach($araziOptions as $code => $label)
                                <option value="{{ $code }}">{{ $label }}</option>
                            @endforeach
                        </select>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label mb-1">Plot(s) <span class="text-danger">*</span></label>
                        <select name="plot_id[]" id="hold_plot_id" class="form-select" required disabled multiple>
                        </select>
                        <small class="text-muted">Select one or more plots in this arazi.</small>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label mb-1">Broker <span class="text-danger">*</span></label>
                        <select name="agent_id" id="hold_agent_id" class="form-select" required>
                            <option value="">Select Broker</option>
                            @foreach($agents as $id => $label)
                                <option value="{{ $id }}">{{ $label }}</option>
                            @endforeach
                        </select>
                    </div>
                    <div class="col-md-3">
                        <label class="form-label mb-1">Number of days <span class="text-danger">*</span></label>
                        <input type="number" min="1" name="days" id="hold_days" class="form-control" required>
                    </div>
                    <div class="col-md-3">
                        <label class="form-label mb-1">Start date <span class="text-danger">*</span></label>
                        <input type="date" name="start_date" id="hold_start_date" class="form-control" value="{{ now()->format('Y-m-d') }}" required>
                    </div>
                    <div class="col-md-3">
                        <label class="form-label mb-1">End date <span class="text-danger">*</span></label>
                        <input type="date" name="end_date" id="hold_end_date" class="form-control" required>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label mb-1">Customer name (optional)</label>
                        <input type="text" name="customer_name" class="form-control" placeholder="Enter customer name">
                    </div>
                    <div class="col-md-6">
                        <label class="form-label mb-1">Customer phone (optional)</label>
                        <input type="text" name="customer_phone" class="form-control">
                    </div>
                    <div class="col-12">
                        <label class="form-label mb-1">Notes (optional)</label>
                        <input type="text" name="notes" class="form-control">
                    </div>
                    <div class="col-12">
                        <button type="submit" class="btn btn-primary">Save Hold</button>
                        <span class="text-muted small ms-2">Saving auto-sets the plot status to <strong>Hold</strong>.</span>
                    </div>
                </form>
            </div>
        </div>

        <form method="GET" class="row g-2 mb-3">
            <div class="col-md-3">
                <label class="form-label mb-1">Status</label>
                <select name="status" class="form-select">
                    @foreach(['active' => 'Active', 'released' => 'Released', 'expired' => 'Expired', 'all' => 'All'] as $val => $lbl)
                        <option value="{{ $val }}" @selected($status === $val)>{{ $lbl }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-3">
                <label class="form-label mb-1">Arazi</label>
                <select name="arazi_code" class="form-select">
                    <option value="">All Arazi</option>
                    @foreach($araziOptions as $code => $label)
                        <option value="{{ $code }}" @selected((string)$araziCode === (string)$code)>{{ $label }}</option>
                    @endforeach
                </select>
            </div>
            <div class="col-md-4">
                <label class="form-label mb-1">Search</label>
                <input type="text" name="q" value="{{ $q }}" class="form-control" placeholder="Plot title, broker, customer, phone">
            </div>
            <div class="col-md-2 d-flex align-items-end gap-2">
                <button type="submit" class="btn btn-primary">Filter</button>
                <a href="{{ route('plot-holds.index') }}" class="btn btn-outline-secondary">Reset</a>
            </div>
        </form>

        <div class="table-responsive">
            <table class="table table-hover table-sm align-middle">
                <thead>
                    <tr>
                        <th>Arazi</th>
                        <th>Plot</th>
                        <th>Broker</th>
                        <th>Days</th>
                        <th>Start</th>
                        <th>End</th>
                        <th>Customer</th>
                        <th>Phone</th>
                        <th>Status</th>
                        <th class="text-end">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($holds as $hold)
                        <tr>
                            <td>{{ $hold->arazi?->araziNoCode() ?: ($hold->arazi_code ?: '-') }}</td>
                            <td>{{ $hold->plot?->title ?: ('#' . $hold->plot_id) }}</td>
                            <td>{{ $hold->agent?->name ?: '-' }}</td>
                            <td>{{ $hold->days }}</td>
                            <td>{{ optional($hold->start_date)->format('d-m-Y') }}</td>
                            <td>{{ optional($hold->end_date)->format('d-m-Y') }}</td>
                            <td>{{ $hold->customer?->name ?: ($hold->customer_name ?: '-') }}</td>
                            <td>{{ $hold->customer_phone ?: '-' }}</td>
                            <td>
                                @php($badge = ['active' => 'success', 'released' => 'secondary', 'expired' => 'warning'][$hold->status] ?? 'secondary')
                                <span class="badge bg-{{ $badge }}">{{ ucfirst($hold->status) }}</span>
                            </td>
                            <td class="text-end">
                                @can('plots.edit')
                                    <a href="{{ route('plots.edit', $hold->plot_id) }}" class="btn btn-sm btn-outline-primary">Edit Plot</a>
                                @endcan
                                @if($hold->status === 'active')
                                    <form method="POST" action="{{ route('plot-holds.release', $hold) }}" class="d-inline" onsubmit="return confirm('Release this hold and free the plot?');">
                                        @csrf
                                        <button type="submit" class="btn btn-sm btn-outline-danger">Release</button>
                                    </form>
                                @endif
                            </td>
                        </tr>
                    @empty
                        <tr><td colspan="10" class="text-center text-muted py-4">No plot holds found.</td></tr>
                    @endforelse
                </tbody>
            </table>
        </div>

        {{ $holds->links() }}
    </div>
</div>

@endsection

@push('scripts')
<script>
jQuery(function(){
    const plotsByCodeBase = @json(url('arazi-no'));

    // Init Select2 for the broker/customer selects (arazi_code is handled by the
    // global initializer in the layout).
    if(window.jQuery && jQuery.fn.select2){
        jQuery('#hold_agent_id').select2({
            theme: 'bootstrap-5', width: '100%', allowClear: true, placeholder: 'Select',
            dropdownParent: jQuery('#addHoldForm')
        });
    }

    function initPlotSelect2(){
        if(window.jQuery && jQuery.fn.select2){
            jQuery('#hold_plot_id').select2({
                theme: 'bootstrap-5', width: '100%', placeholder: 'Select plot(s)',
                dropdownParent: jQuery('#addHoldForm')
            });
        }
    }

    async function loadPlots(code){
        const plotSel = document.getElementById('hold_plot_id');
        if(!plotSel) return;
        plotSel.innerHTML = '';
        plotSel.disabled = true;
        if(!code){ initPlotSelect2(); return; }
        try{
            const res = await fetch(plotsByCodeBase + '/' + encodeURIComponent(code) + '/plots');
            const raw = await res.json();
            const data = Array.isArray(raw) ? raw : (raw.plots || []);
            plotSel.innerHTML = '';
            data.forEach(function(p){
                const opt = document.createElement('option');
                opt.value = p.id;
                opt.textContent = p.label || p.title;
                plotSel.appendChild(opt);
            });
            plotSel.disabled = false;
            initPlotSelect2();
        }catch(e){
            plotSel.innerHTML = '';
            initPlotSelect2();
        }
    }

    // Delegated binding — Select2 fires change through jQuery's event system,
    // which a directly-bound native listener would miss.
    jQuery(document).on('change', '#hold_arazi_code', function(){
        loadPlots(this.value);
    });

    function recalcEnd(){
        const daysInp  = document.getElementById('hold_days');
        const startInp = document.getElementById('hold_start_date');
        const endInp   = document.getElementById('hold_end_date');
        if(!daysInp || !startInp || !endInp) return;
        const d = parseInt(daysInp.value || '0', 10);
        if(!startInp.value || !d) return;
        const dt = new Date(startInp.value + 'T00:00:00');
        dt.setDate(dt.getDate() + d);
        endInp.value = dt.toISOString().slice(0, 10);
    }
    jQuery(document).on('input', '#hold_days', recalcEnd);
    jQuery(document).on('change', '#hold_start_date', recalcEnd);
});
</script>
@endpush
