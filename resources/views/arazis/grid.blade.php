@extends('layouts.app')

@section('content')
<div class="container-fluid p-3">
    <div class="d-flex justify-content-between align-items-center mb-3">
        <h3 class="mb-0">Plots for Arazi {{ $arazi->legacy_arazi_code ?? $arazi->id }}</h3>
        <div>
            <a href="{{ route('arazis.index') }}" class="btn btn-sm btn-outline-secondary">Back to Arazis</a>
        </div>
    </div>

    <div class="mb-3">
        <div class="d-flex gap-3 align-items-center">
            <div><strong>Original Value:</strong> {{ number_format($arazi->original_value,2) }}</div>
            <div><strong>After Expenses:</strong> {{ number_format($arazi->price_after_expenses,2) }}</div>
            <div class="text-muted small">(Includes {{ $arazi->expenses()->count() }} expense(s))</div>
        </div>
    </div>

    <div class="d-flex justify-content-between align-items-center mb-2">
        @php
            $totalPlots = count($plots ?? []);
            $statusCounts = collect($plots ?? [])->map(function($p){
                $s = strtolower(str_replace('_','-',$p['status'] ?? 'available'));
                return trim($s);
            })->countBy()->all();

            $c = fn($k) => isset($statusCounts[$k]) ? $statusCounts[$k] : 0;
        @endphp
        <div class="legend d-flex gap-3 align-items-center flex-wrap">
            <div class="legend-item" role="button" tabindex="0" data-status="all"><span class="legend-dot available"></span>All <small class="text-muted ms-1">({{ $totalPlots }})</small></div>
            <div class="legend-item" role="button" tabindex="0" data-status="available"><span class="legend-dot available"></span>Available <small class="text-muted ms-1">({{ $c('available') }})</small></div>
            <div class="legend-item" role="button" tabindex="0" data-status="booked-advance"><span class="legend-dot booked-advance"></span>Booked (advance) <small class="text-muted ms-1">({{ $c('booked-advance') }})</small></div>
            <div class="legend-item" role="button" tabindex="0" data-status="booked"><span class="legend-dot booked"></span>Booked <small class="text-muted ms-1">({{ $c('booked') }})</small></div>
            <div class="legend-item" role="button" tabindex="0" data-status="hold"><span class="legend-dot hold"></span>Hold <small class="text-muted ms-1">({{ $c('hold') }})</small></div>
            <div class="legend-item" role="button" tabindex="0" data-status="registry"><span class="legend-dot registry"></span>Registry done <small class="text-muted ms-1">({{ $c('registry') }})</small></div>
            <div class="legend-item" role="button" tabindex="0" data-status="not-for-sale"><span class="legend-dot not-for-sale"></span>Not for sale <small class="text-muted ms-1">({{ $c('not-for-sale') }})</small></div>
            <div class="legend-item" role="button" tabindex="0" data-status="blacklist"><span class="legend-dot blacklist"></span>Black listed <small class="text-muted ms-1">({{ $c('blacklist') }})</small></div>
            <div class="legend-item" role="button" tabindex="0" data-status="issue"><span class="legend-dot issue"></span>Issue <small class="text-muted ms-1">({{ $c('issue') }})</small></div>
        </div>
    </div>

    <div class="plots-grid row g-2">
        @foreach($plots as $plot)
            <div class="col-auto">
                @php $statusClass = str_replace('_','-',$plot['status'] ?? 'available'); $statusNorm = strtolower(trim($statusClass)); @endphp
                <div class="plot-card" tabindex="0" data-id="{{ $plot['id'] }}" data-plot-number="{{ $plot['plot_number'] }}" data-block="{{ $plot['block'] ?? '' }}" data-area="{{ $plot['area'] ?? '' }}" data-status="{{ $plot['status'] ?? 'available' }}" data-status-normalized="{{ $statusNorm }}">
                    <div class="plot-strip {{ $statusClass }}"></div>
                    <div class="plot-card-body text-center p-1">
                        <div class="plot-number">{{ $plot['plot_number'] }}</div>
                        @if(!empty($plot['block']))<div class="plot-block">{{ $plot['block'] }}</div>@endif
                        <div class="plot-area">{{ isset($plot['area']) ? (int) $plot['area'] : '-' }} gaz</div>
                        <div class="plot-status badge mt-1 {{ 
                            $statusClass === 'booked-advance' ? 'booked' : (
                            $statusClass === 'booked' ? 'booked' : (
                            $statusClass === 'registry' ? 'registry' : (
                            $statusClass === 'issue' ? 'issue' : 'available')))
                        }}">{{ ucfirst(str_replace(['-','_'], ' ', $plot['status'] ?? 'available')) }}</div>
                    </div>
                </div>
            </div>
        @endforeach
    </div>
</div>
@endsection

@push('styles')
<style>
.root, :root{
    --status-available: #FFC107; /* bright amber */
    --status-booked: #28A745; /* vivid green */
    --status-booked-advance: #20C997; /* teal for advance */
    --status-not-for-sale: #9E9E9E; /* grey */
    --status-blacklist: #212529; /* dark */
    --status-hold: #A0522D; /* sienna */
    --status-registry: #E53935; /* vivid red */
    --status-issue: #6C757D; /* muted */
    --card-bg: linear-gradient(180deg,#ffffff, #fcfcfc);
    --muted: #5c6975;
}
.plot-card { background:var(--card-bg); border-radius:8px; overflow:hidden; box-shadow:0 6px 18px rgba(0,0,0,0.06); transition:transform .12s ease, box-shadow .12s ease; cursor:pointer; width:140px; }
.plot-card:focus, .plot-card:hover { transform:translateY(-6px); box-shadow:0 18px 40px rgba(0,0,0,0.10); outline:0; }
.plot-strip { height:9px; }
.plot-strip.available { background:var(--status-available); box-shadow:0 3px 8px rgba(255,193,7,0.12); }
.plot-strip.booked { background:var(--status-booked); box-shadow:0 3px 8px rgba(40,167,69,0.12); }
.plot-strip.booked-advance { background:var(--status-booked-advance); box-shadow:0 3px 8px rgba(32,201,151,0.14); }
.plot-strip.not_for_sale, .plot-strip.not-for-sale { background:var(--status-not-for-sale); box-shadow:0 3px 8px rgba(158,158,158,0.08); }
.plot-strip.blacklist { background:var(--status-blacklist); box-shadow:0 3px 8px rgba(0,0,0,0.12); }
.plot-strip.hold { background:var(--status-hold); box-shadow:0 3px 8px rgba(160,82,45,0.12); }
.plot-strip.registry { background:var(--status-registry); box-shadow:0 3px 8px rgba(229,57,53,0.12); }
.plot-strip.issue { background:var(--status-issue); box-shadow:0 3px 8px rgba(108,117,125,0.08); }
.plot-card-body { padding:0.5rem 0.35rem; }
.plot-number { font-weight:700; font-size:20px; line-height:1; }
.plot-block, .plot-area, .plot-title { color:var(--muted); font-size:15px; line-height:1.05; }
.plot-status { display:inline-block; padding:4px 8px; border-radius:10px; font-size:13px; }

.plots-grid { display:flex; gap:10px; flex-wrap:wrap; align-items:flex-start; }
.col-auto { padding-left:4px; padding-right:4px; }

.legend-item { display:inline-flex; align-items:center; gap:8px; padding:6px 10px; border-radius:8px; transition:background .12s ease, transform .08s ease; cursor:pointer; }
.legend-item.active { background:rgba(0,0,0,0.04); transform:translateY(-2px); }
.legend-dot { width:14px; height:14px; }

.plot-block { display:inline-block; background:rgba(0,0,0,0.04); color:var(--muted); padding:2px 8px; border-radius:999px; font-weight:600; margin:6px 0 4px; }
.plot-status.available { background:var(--status-available); color:#222; }
.plot-status.booked { background:var(--status-booked); color:#fff; }
.plot-status.not_for_sale, .plot-status.not-for-sale { background:var(--status-not-for-sale); color:#fff; }
.plot-status.blacklist { background:var(--status-blacklist); color:#fff; }
.plot-status.registry { background:var(--status-registry); color:#fff; }
.plot-status.hold { background:var(--status-hold); color:#fff; }
.legend-dot { display:inline-block; width:12px; height:12px; border-radius:50%; margin-right:6px; vertical-align:middle; }
.legend-dot.booked { background:var(--status-booked); }
.legend-dot.booked-advance { background:var(--status-booked-advance); }
.legend-dot.not-for-sale { background:var(--status-not-for-sale); }
.legend-dot.blacklist { background:var(--status-blacklist); }
.legend-dot.registry { background:var(--status-registry); }
.legend-dot.available { background:var(--status-available); }
.legend-dot.issue { background:var(--status-issue); }
.legend-dot.hold { background:var(--status-hold); }
.container-fluid { max-width:100%; }
/* spacing at bottom so legend and modal triggers don't overlap */
.plots-grid { padding-bottom:18px; }
</style>
@endpush

@push('scripts')
<script>
document.addEventListener('DOMContentLoaded', function(){
    var modalEl = document.getElementById('plotDetailModal');
    var bsModal = null;
    if (modalEl && window.bootstrap && bootstrap.Modal) {
        bsModal = new bootstrap.Modal(modalEl);
    }

    function openModalFromCard(card){
        var id = card.dataset.id;
        var plotNumber = card.dataset.plotNumber;
        var block = card.dataset.block;
        var area = card.dataset.area;
        var status = card.dataset.status;

        document.getElementById('plotDetailModalLabel').textContent = 'Plot ' + plotNumber;
        document.getElementById('md-plot-number').textContent = plotNumber;
        document.getElementById('md-block').textContent = block ? (' • ' + block) : '';
        document.getElementById('md-area').textContent = area ? (area + ' gaz') : '';
        var mdStatus = document.getElementById('md-status');
        mdStatus.textContent = status ? status.replace(/[-_]/g,' ') : '';
        mdStatus.className = 'badge ' + (status || 'available');

        var editLink = document.getElementById('md-edit');
        editLink.href = '/plots/' + id + '/edit';

        var createReg = document.getElementById('md-create-registry');
        createReg.href = '/registries/create?plot_id=' + id;

        if (bsModal) bsModal.show();
        else modalEl.style.display = 'block';
    }

    document.querySelectorAll('.js-plot-details').forEach(function(btn){
        btn.addEventListener('click', function(e){
            e.stopPropagation();
            var card = e.target.closest('.plot-card');
            if (card) openModalFromCard(card);
        });
    });

    // keyboard accessibility: open details on Enter
    document.querySelectorAll('.plot-card').forEach(function(card){
        card.addEventListener('keydown', function(e){
            if (e.key === 'Enter' || e.key === ' ') {
                openModalFromCard(card);
                e.preventDefault();
            }
        });
    });

    // Legend filtering
    function setLegendActive(el) {
        document.querySelectorAll('.legend-item').forEach(function(li){ li.classList.remove('active'); });
        if (el) el.classList.add('active');
    }

    function filterByStatus(status) {
        document.querySelectorAll('.plot-card').forEach(function(card){
            var s = (card.dataset.statusNormalized || card.dataset.status || 'available').toString().toLowerCase().replace(/_/g,'-').trim();
            if (status === 'all' || s === status) {
                card.style.display = '';
            } else {
                card.style.display = 'none';
            }
        });
    }

    // initialize: show all
    setLegendActive(document.querySelector('.legend-item[data-status="all"]'));

    document.querySelectorAll('.legend-item').forEach(function(li){
        li.style.cursor = 'pointer';
        li.addEventListener('click', function(){
            var status = (li.dataset.status || 'all').toString().toLowerCase();
            setLegendActive(li);
            filterByStatus(status);
        });
        // keyboard support
        li.addEventListener('keydown', function(e){
            if (e.key === 'Enter' || e.key === ' ') {
                e.preventDefault();
                li.click();
            }
        });
    });
});
</script>
@endpush
