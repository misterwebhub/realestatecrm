@extends('layouts.app')

@section('content')
    <div class="d-flex align-items-center gap-2 mb-3">
        <h4 class="mb-0">Plot Registry</h4>
        <div class="ms-auto">
            <a href="{{ $createUrl }}" class="btn btn-primary btn-sm"><i class="bi bi-plus-lg"></i> Add New Registry</a>
        </div>
    </div>

    <div class="card mb-3">
        <div class="card-body py-3">
            <form method="GET" id="registryFilterForm" class="d-flex gap-2 align-items-center flex-wrap">
                <div style="min-width:160px; flex:1 1 160px;">
                    <select name="arazi_code" id="filter_arazi_code" class="form-select form-select-sm">
                        <option value="">-- Arazi No. --</option>
                        @foreach($araziOptions as $code)
                            <option value="{{ $code }}" {{ $code === ($filterAraziCode ?? '') ? 'selected' : '' }}>{{ $code }}</option>
                        @endforeach
                    </select>
                </div>
                <div style="min-width:160px; flex:1 1 160px;">
                    <select name="plot_id" id="filter_plot_id" class="form-select form-select-sm" {{ empty($filterAraziCode) ? 'disabled' : '' }}>
                        <option value="">-- Plot No. --</option>
                        @foreach($filterPlots as $p)
                            <option value="{{ $p->id }}" {{ (string)$p->id === (string)($filterPlotId ?? '') ? 'selected' : '' }}>
                                {{ $p->title ?? ('Plot-'.$p->id) }}
                            </option>
                        @endforeach
                    </select>
                </div>
                <div style="min-width:160px; flex:1 1 160px;">
                    <input type="text" name="reg_no" value="{{ $filterRegNo ?? '' }}"
                        class="form-control form-control-sm" placeholder="Registry / Bond No.">
                </div>
                <div style="min-width:160px; flex:1 1 160px;">
                    <input type="text" name="deed_no" value="{{ $filterDeedNo ?? '' }}"
                        class="form-control form-control-sm" placeholder="Deed No.">
                </div>
                <button type="submit" class="btn btn-primary btn-sm"><i class="bi bi-search"></i> Search</button>
                <a href="{{ route('registries.index') }}" class="btn btn-outline-secondary btn-sm">Reset</a>
            </form>
        </div>
    </div>

    <div class="card">
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
                        <td class="text-end">
                            @if(!empty($row['print_url']))
                                <a href="{{ $row['print_url'] }}?print=1" target="_blank" class="btn btn-outline-success btn-sm">Print</a>
                            @endif
                            @if(!empty($row['doc_url']))
                                <a href="{{ $row['doc_url'] }}" class="btn btn-outline-primary btn-sm ms-1">
                                    <i class="bi bi-download"></i> Download
                                </a>
                            @else
                                <span class="btn btn-outline-secondary btn-sm ms-1 disabled" style="opacity:.4;">No Doc</span>
                            @endif
                            <a href="{{ $row['edit_url'] }}" class="btn btn-outline-secondary btn-sm ms-1">Edit</a>
                            <form action="{{ $row['delete_url'] }}" method="POST" class="d-inline-block ms-1" onsubmit="return confirm('Delete this registry?');">
                                @csrf
                                @method('DELETE')
                                <button class="btn btn-outline-danger btn-sm">Delete</button>
                            </form>
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

@endsection

@push('scripts')
<script>
(function(){
    const BYCODE_URL  = @json(route('arazis.plots-by-code', ['code' => '__CODE__']));
    const araziSel    = document.getElementById('filter_arazi_code');
    const plotSel     = document.getElementById('filter_plot_id');
    const savedPlotId = '{{ $filterPlotId ?? '' }}';

    async function loadPlotsByCode(code, selectedId){
        plotSel.innerHTML = '<option value="">-- All Plots --</option>';
        if(!code){ plotSel.disabled = true; return; }
        plotSel.disabled = false;
        try{
            const url = BYCODE_URL.replace('__CODE__', encodeURIComponent(code));
            const res = await fetch(url, {headers:{'Accept':'application/json'}});
            if(!res.ok) return;
            const data = await res.json();
            (data.plots || data).forEach(p => {
                const o = document.createElement('option');
                o.value = p.id;
                o.textContent = p.label || p.title || p.id;
                if(selectedId && String(p.id) === String(selectedId)) o.selected = true;
                plotSel.appendChild(o);
            });
            if(window.jQuery && jQuery.fn.select2){
                try{ jQuery(plotSel).trigger('change.select2'); }catch(e){}
            }
        }catch(e){}
    }

    araziSel.addEventListener('change', function(){ loadPlotsByCode(this.value, null); });
    if(araziSel.value){ loadPlotsByCode(araziSel.value, savedPlotId); }

    if(window.jQuery && jQuery.fn.select2){
        jQuery('#filter_arazi_code').select2({ theme:'bootstrap-5', width:'100%', allowClear:true, placeholder:'-- Arazi No. --' });
        jQuery('#filter_plot_id').select2({ theme:'bootstrap-5', width:'100%', allowClear:true, placeholder:'-- Plot No. --' });
        jQuery('#filter_arazi_code').on('change', function(){ loadPlotsByCode(this.value, null); });
    }
})();
</script>
@endpush
