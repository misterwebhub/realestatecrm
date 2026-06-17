@extends('layouts.app')

@push('styles')
<style>
    .qa-section-title {
        font-size: 0.78rem;
        font-weight: 700;
        letter-spacing: 0.08em;
        text-transform: uppercase;
        color: #6c757d;
        padding: 0.35rem 0.5rem;
        border-left: 3px solid currentColor;
        margin-bottom: 0.75rem;
        margin-top: 0.25rem;
    }
    .qa-card {
        border: none;
        border-radius: 10px;
        box-shadow: 0 1px 4px rgba(0,0,0,.08);
        transition: box-shadow .18s, transform .18s;
        height: 100%;
        text-decoration: none;
        color: inherit;
        display: flex;
        flex-direction: column;
    }
    .qa-card:hover {
        box-shadow: 0 4px 18px rgba(0,0,0,.14);
        transform: translateY(-2px);
        color: inherit;
    }
    .qa-icon-wrap {
        width: 44px;
        height: 44px;
        border-radius: 10px;
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 1.35rem;
        flex-shrink: 0;
    }
    .qa-card-body {
        padding: 0.85rem 0.9rem;
        display: flex;
        align-items: flex-start;
        gap: 0.7rem;
        flex: 1;
    }
    .qa-card-footer {
        padding: 0.4rem 0.9rem 0.55rem;
        border-top: 1px solid rgba(0,0,0,.05);
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
    .qa-title { font-size: 0.88rem; font-weight: 600; margin-bottom: 0.15rem; line-height: 1.3; }
    .qa-desc  { font-size: 0.74rem; color: #6c757d; line-height: 1.35; margin: 0; }

    /* color palette helpers */
    .bg-teal-soft   { background: #d0f0f0; color: #0d9488; }
    .bg-indigo-soft  { background: #e0e7ff; color: #4f46e5; }
    .bg-orange-soft  { background: #fff0d9; color: #ea580c; }
    .bg-purple-soft  { background: #f0e6ff; color: #7c3aed; }
    .bg-success-soft { background: #d1f5d3; color: #16a34a; }
    .bg-info-soft    { background: #dbeafe; color: #0369a1; }
    .bg-warning-soft { background: #fef9c3; color: #ca8a04; }
    .bg-danger-soft  { background: #ffe4e6; color: #dc2626; }
    .bg-primary-soft { background: #dbeafe; color: #1d4ed8; }
    .bg-secondary-soft { background: #f1f3f5; color: #495057; }
    .bg-dark-soft    { background: #e2e8f0; color: #1e293b; }
</style>
@endpush

@section('content')
<div class="d-flex align-items-center mb-3 gap-2">
    <i class="bi bi-grid-3x3-gap-fill fs-4 text-primary"></i>
    <div>
        <h5 class="mb-0 fw-bold">Quick Access</h5>
        <small class="text-muted">All modules at a glance — click any card to open</small>
    </div>
</div>

@foreach($sections as $section)
    @if(!empty($section['cards']))
    <div class="mb-4">
        <div class="qa-section-title">
            <i class="bi {{ $section['icon'] }} me-1"></i>{{ $section['title'] }}
        </div>
        <div class="row g-2">
            @foreach($section['cards'] as $card)
                @if(!empty($card['url']))
                <div class="col-6 col-sm-4 col-md-3 col-xl-2">
                    <div class="card qa-card">
                        <a href="{{ $card['url'] }}" class="qa-card-body text-decoration-none text-reset">
                            <div class="qa-icon-wrap bg-{{ $card['color'] ?? 'primary' }}-soft">
                                <i class="bi {{ $card['icon'] }}"></i>
                            </div>
                            <div class="flex-1 min-w-0">
                                <div class="qa-title">{{ $card['title'] }}</div>
                                <p class="qa-desc">{{ $card['desc'] }}</p>
                            </div>
                        </a>
                        <div class="qa-card-footer">
                            <a href="{{ $card['url'] }}" class="text-decoration-none text-muted small">
                                <i class="bi bi-arrow-right-short"></i> View
                            </a>
                            @if(!empty($card['add_url']))
                            <a href="{{ $card['add_url'] }}" class="btn btn-sm btn-outline-{{ $card['color'] ?? 'primary' }} py-0 px-2" style="font-size:0.72rem;" title="Add new">
                                <i class="bi bi-plus-lg"></i> New
                            </a>
                            @endif
                        </div>
                    </div>
                </div>
                @endif
            @endforeach
        </div>
    </div>
    @endif
@endforeach

{{-- Quick Stats bar ──────────────────────────────────────────── --}}
@php
    try {
        $stats = [
            ['label' => 'Arazis',          'val' => \App\Models\Arazi::count(),                        'icon' => 'bi-map-fill',           'color' => 'success'],
            ['label' => 'Kisans',          'val' => \App\Models\Kisan::count(),                        'icon' => 'bi-person-fill',        'color' => 'primary'],
            ['label' => 'Plots',           'val' => \App\Models\Plot::count(),                         'icon' => 'bi-pin-map-fill',       'color' => 'info'],
            ['label' => 'Customer Bonds',  'val' => \App\Models\CustomerBond::count(),                 'icon' => 'bi-receipt-cutoff',     'color' => 'orange'],
            ['label' => 'Kisan Bonds',     'val' => \App\Models\KisanBond::count(),                    'icon' => 'bi-file-earmark-ruled', 'color' => 'primary'],
        ];
    } catch(\Exception $e) {
        $stats = [];
    }
@endphp

@if(!empty($stats))
<div class="card border-0 shadow-sm mt-2">
    <div class="card-body py-3">
        <div class="row g-2 text-center">
            @foreach($stats as $s)
            <div class="col">
                <div class="fw-bold fs-5 text-{{ $s['color'] }}">{{ number_format($s['val']) }}</div>
                <div class="small text-muted"><i class="bi {{ $s['icon'] }} me-1"></i>{{ $s['label'] }}</div>
            </div>
            @endforeach
        </div>
    </div>
</div>
@endif

@endsection
