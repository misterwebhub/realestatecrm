@extends('layouts.app')

@section('content')
    @php $isCustomerBondForm = str_contains($title ?? '', 'Customer Bond'); @endphp
    @php($hasFiles = collect($fields)->contains(fn ($field) => ($field['type'] ?? 'text') === 'file'))

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

            <form action="{{ $action }}" method="POST" @if($hasFiles) enctype="multipart/form-data" @endif>
                @csrf
                @if($method !== 'POST')
                    @method($method)
                @endif

                <div class="row g-3">
                    @foreach($fields as $field)
                        @php($value = old($field['name'], $field['value'] ?? data_get($item, $field['name'])))
                        <div class="col-md-6">
                            <label class="form-label" for="{{ $field['name'] }}">{{ $field['label'] }}</label>

                            @if(($field['type'] ?? 'text') === 'textarea')
                                <textarea
                                    id="{{ $field['name'] }}"
                                    name="{{ $field['name'] }}"
                                    class="form-control"
                                    rows="4"
                                >{{ $value }}</textarea>
                            @elseif(($field['type'] ?? 'text') === 'select')
                                <select id="{{ $field['name'] }}" name="{{ $field['name'] }}" class="form-select">
                                    <option value="">Select {{ $field['label'] }}</option>
                                    @foreach($field['options'] ?? [] as $optionValue => $optionLabel)
                                        <option value="{{ $optionValue }}" @selected((string) $value === (string) $optionValue)>{{ $optionLabel }}</option>
                                    @endforeach
                                </select>
                            @elseif(($field['type'] ?? 'text') === 'file')
                                <input
                                    id="{{ $field['name'] }}"
                                    name="{{ $field['name'] }}"
                                    type="file"
                                    class="form-control"
                                    @if(!empty($field['accept'])) accept="{{ $field['accept'] }}" @endif
                                >
                            @else
                                <input
                                    id="{{ $field['name'] }}"
                                    name="{{ $field['name'] }}"
                                    type="{{ $field['type'] ?? 'text' }}"
                                    value="{{ $value }}"
                                    class="form-control"
                                    @if(isset($field['step'])) step="{{ $field['step'] }}" @endif
                                    @if(isset($field['placeholder'])) placeholder="{{ $field['placeholder'] }}" @endif
                                >
                            @endif
                        </div>
                    @endforeach
                </div>

                <div class="mt-4 d-flex gap-2">
                    <button type="submit" class="btn btn-primary">Save</button>
                    <a href="{{ url()->previous() }}" class="btn btn-outline-secondary">Cancel</a>
                    @if($isCustomerBondForm)
                        <button type="button" class="btn btn-outline-secondary" id="backBtn">Back</button>
                    @endif
                </div>
            </form>
        </div>
    </div>
    @if($isCustomerBondForm)
    <script>
        (function(){
            const kisanArazisUrl = @json(route('kisans.arazis', ['kisan' => '__KISAN_ID__']));

            // if there is a kisan select and an arazi select, fetch arazis when kisan changes
            const kisanSelect = document.querySelector('select[name="kisan_id"]');
            const araziSelect = document.querySelector('select[name="arazi_id"]');
            if(kisanSelect && araziSelect){
                kisanSelect.addEventListener('change', async function(){
                    const kisanId = this.value;
                    // clear arazi options
                    araziSelect.innerHTML = '<option value="">Select Arazi</option>';
                    if(!kisanId) return;
                    try{
                        const res = await fetch(kisanArazisUrl.replace('__KISAN_ID__', encodeURIComponent(kisanId)));
                        if(!res.ok) return;
                        const data = await res.json();
                        data.forEach(function(a){
                            const opt = document.createElement('option');
                            opt.value = a.id;
                            opt.textContent = a.label;
                            araziSelect.appendChild(opt);
                        });
                    }catch(e){}
                });
            }
            const back = document.getElementById('backBtn');
            if(!back) return;
            back.addEventListener('click', function(){
                try{
                    if(window.opener && !window.opener.closed){
                        window.close();
                        return;
                    }
                }catch(e){}
                history.back();
            });
        })();
    </script>
    @endif
    <script>
        (function(){
            const araziSaleableUrl = @json(route('arazis.saleable', ['arazi' => '__ARAZI_ID__']));
            const araziPlotsUrl = @json(route('arazis.plots', ['arazi' => '__ARAZI_ID__']));
            const select = document.querySelector('select[name="arazi_id"]');
            if(!select) return;

            const infoId = 'arazi-saleable-info';
            let info = document.getElementById(infoId);
            if(!info){
                info = document.createElement('div');
                info.id = infoId;
                info.style.marginTop = '0.5rem';
                select.parentNode.appendChild(info);
            }

            async function fetchSaleable(id){
                if(!id){ info.textContent=''; return; }
                try{
                    const res = await fetch(araziSaleableUrl.replace('__ARAZI_ID__', encodeURIComponent(id)));
                    if(!res.ok) throw new Error('Fetch failed');
                    const json = await res.json();
                    const total = (json.saleable_total !== undefined) ? json.saleable_total : (json.saleable || 0);
                    const remaining = (json.remaining !== undefined) ? json.remaining : (json.saleable || 0);
                    const totalGaz = (json.saleable_gaz !== undefined) ? json.saleable_gaz : (json.saleable_gaz || 0);
                    const remainingGaz = (json.remaining_gaz !== undefined) ? json.remaining_gaz : (json.saleable_gaz || 0);
                    const unit = json.unit || 'gaz';
                    info.innerHTML = `<small class="text-muted">Saleable: <strong>${totalGaz}</strong> gaz — Available: <strong>${remainingGaz}</strong> gaz</small>`;
                }catch(e){
                    info.textContent = '';
                }
            }

            // load plots for arazi into any plot_id select on the form
            async function loadPlotsInto(araziId, selectedPlotId){
                const plotSelect = document.querySelector('select[name="plot_id"]');
                const landSize = document.querySelector('input[name="land_size"]');
                if(!plotSelect) return;
                plotSelect.innerHTML = '<option value="">Select Plot</option>';
                if(!araziId) return;
                try{
                    const res = await fetch(araziPlotsUrl.replace('__ARAZI_ID__', encodeURIComponent(araziId)));
                    if(!res.ok) return;
                    const data = await res.json();
                    data.forEach(function(p){
                        const opt = document.createElement('option');
                        opt.value = p.id;
                        opt.textContent = p.label;
                        if(p.area !== undefined) opt.dataset.area = p.area;
                        if(String(p.id) === String(selectedPlotId)) opt.selected = true;
                        plotSelect.appendChild(opt);
                    });
                    const sel = plotSelect.options[plotSelect.selectedIndex];
                    if(sel && sel.dataset && sel.dataset.area) landSize.value = sel.dataset.area;
                }catch(e){ }
            }

            // initial
            fetchSaleable(select.value);

            // if there's an arazi select on the page, also wire plot loading
            const plotSelect = document.querySelector('select[name="plot_id"]');
            const selectedPlot = plotSelect ? '{{ old('plot_id', $item->plot_id ?? '') }}' : null;

            // initial load for plots
            if(select.value){
                loadPlotsInto(select.value, selectedPlot);
            }

            select.addEventListener('change', function(){
                fetchSaleable(this.value);
                loadPlotsInto(this.value, null);
            });

            if(plotSelect){
                plotSelect.addEventListener('change', function(){
                    const opt = this.options[this.selectedIndex];
                    const landSize = document.querySelector('input[name="land_size"]');
                    if(opt && opt.dataset && opt.dataset.area) landSize.value = opt.dataset.area;
                });
            }
        })();
    </script>
@endsection
