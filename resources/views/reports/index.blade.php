@extends('layouts.app')

@section('content')
<div class="d-flex align-items-center gap-2 mb-3">
    <div>
        <h5 class="mb-0 fw-bold">Reports</h5>
        <small class="text-muted">Reporting &amp; analytics hub</small>
    </div>
</div>

@php
    $reports = [
        [
            'title' => 'Plot Details',
            'desc'  => 'Detailed plot listing with arazi, status and area.',
            'url'   => route('reports.plot.details'),
            'icon'  => 'bi-grid-3x3-gap',
            'color' => '#0d6efd',
        ],
        [
            'title' => 'User Collections',
            'desc'  => 'How much each user collected, broken down by bond.',
            'url'   => route('user-master.report'),
            'icon'  => 'bi-cash-coin',
            'color' => '#16a34a',
        ],
        [
            'title' => 'Customer Payments by User',
            'desc'  => 'Detailed customer payments grouped by user, with filters for customer, bond, arazi, type, method &amp; date.',
            'url'   => route('reports.customer-payments.by-user'),
            'icon'  => 'bi-receipt',
            'color' => '#9333ea',
        ],
    ];
@endphp

<div class="row g-3">
    @foreach($reports as $r)
    <div class="col-sm-6 col-lg-4">
        <a href="{{ $r['url'] }}" class="text-decoration-none">
            <div class="card border-0 shadow-sm h-100 report-card">
                <div class="card-body d-flex align-items-start gap-3">
                    <span class="d-inline-flex align-items-center justify-content-center rounded"
                          style="width:46px;height:46px;background:{{ $r['color'] }}1a;color:{{ $r['color'] }};font-size:22px;flex:0 0 auto;">
                        <i class="bi {{ $r['icon'] }}"></i>
                    </span>
                    <div>
                        <div class="fw-bold text-dark">{{ $r['title'] }}</div>
                        <div class="text-muted" style="font-size:12px;">{{ $r['desc'] }}</div>
                    </div>
                </div>
            </div>
        </a>
    </div>
    @endforeach
</div>

@push('styles')
<style>
.report-card { transition: transform .12s ease, box-shadow .12s ease; }
.report-card:hover { transform: translateY(-2px); box-shadow: 0 .5rem 1rem rgba(0,0,0,.1) !important; }
</style>
@endpush
@endsection
