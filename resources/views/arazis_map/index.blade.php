@extends('layouts.app')

@section('content')
<div class="container-fluid">
    <div class="d-flex align-items-center gap-3 mb-3">
        <h4 class="mb-0">Arazi Maps</h4>
        <div class="w-50 ms-auto">
            <input id="map-search" class="form-control form-control-sm" placeholder="Search maps by name...">
        </div>
    </div>

    @if(empty($folders))
        <div class="alert alert-info">No Arazi maps found in the <code>arazis-map</code> folder.</div>
    @else
        <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 g-3" id="maps-grid">
            @foreach($folders as $f)
                <div class="col map-card" data-name="{{ strtolower($f['name']) }}">
                    <div class="card h-100 shadow-sm">
                        @if($f['preview'])
                            <img src="{{ $f['preview'] }}" class="card-img-top" style="object-fit:cover;height:140px;" alt="{{ $f['name'] }}">
                        @else
                            <div class="d-flex align-items-center justify-content-center bg-light" style="height:140px;">
                                <i class="bi bi-map" style="font-size:38px;opacity:0.6"></i>
                            </div>
                        @endif
                        <div class="card-body d-flex flex-column">
                            <h6 class="card-title mb-1">{{ $f['name'] }}</h6>
                            <p class="card-text text-muted small mb-2">{{ $f['files_count'] }} file(s) • {{ $f['modified'] ?? '—' }}</p>

                            <div class="mt-auto d-flex gap-2">
                                <a href="{{ $f['url'] }}" target="_blank" class="btn btn-sm btn-primary">Open Map</a>
                                <a href="{{ url('arazis-map/' . rawurlencode($f['name'])) }}" target="_blank" class="btn btn-sm btn-outline-secondary">Folder</a>
                            </div>
                        </div>
                    </div>
                </div>
            @endforeach
        </div>
    @endif

    <script>
        (function(){
            const input = document.getElementById('map-search');
            if(!input) return;
            input.addEventListener('input', function(){
                const q = this.value.trim().toLowerCase();
                document.querySelectorAll('.map-card').forEach(function(card){
                    const name = card.getAttribute('data-name') || '';
                    card.style.display = (q === '' || name.indexOf(q) !== -1) ? '' : 'none';
                });
            });
        })();
    </script>
</div>
@endsection
