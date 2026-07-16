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
        [
            'title' => 'Bond Cumulative Report',
            'desc'  => 'Cumulative per-bond totals: amount, paid, balance, cheque paid/balance, registry status &amp; all cheques.',
            'url'   => route('reports.bonds-cumulative'),
            'icon'  => 'bi-collection',
            'color' => '#0891b2',
        ],
        [
            'title' => 'Partner-wise Report',
            'desc'  => 'Area purchased &amp; sold by each partner, per arazi, with remaining area and registry status.',
            'url'   => route('reports.partners'),
            'icon'  => 'bi-people',
            'color' => '#0d6efd',
        ],
        [
            'title' => 'Arazi-wise Report',
            'desc'  => 'Every arazi: total, saleable, sold, remaining area with plots and registry counts.',
            'url'   => route('reports.arazis'),
            'icon'  => 'bi-map',
            'color' => '#16a34a',
        ],
        [
            'title' => 'Broker Report',
            'desc'  => 'Bonds, commission, payments and registries handled by each broker.',
            'url'   => route('reports.brokers'),
            'icon'  => 'bi-person-badge',
            'color' => '#d97706',
        ],
        [
            'title' => 'Registry Report',
            'desc'  => 'Registry pipeline by status with amounts, plus the latest registries.',
            'url'   => route('reports.registries'),
            'icon'  => 'bi-file-earmark-text',
            'color' => '#0891b2',
        ],
        [
            'title' => 'Payment Collection',
            'desc'  => 'Customer payments collected by month and by entry type, with a date filter.',
            'url'   => route('reports.payments'),
            'icon'  => 'bi-cash-stack',
            'color' => '#dc2626',
        ],
        [
            'title' => 'Sales Summary',
            'desc'  => 'Overall sold vs available area and revenue across all arazis.',
            'url'   => route('reports.sales'),
            'icon'  => 'bi-graph-up-arrow',
            'color' => '#4b5563',
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
