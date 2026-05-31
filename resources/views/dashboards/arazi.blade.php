@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-header d-flex justify-content-between align-items-center">
            <h5 class="card-title mb-0">Arazi Dashboard — {{ $arazi->legacy_arazi_code ?? ($arazi->plot_number ?? 'Arazi-'.$arazi->id) }}</h5>
            <div>
                <a href="{{ $shareUrl }}" class="btn btn-outline-secondary btn-sm" target="_blank">Shareable Link</a>
            </div>
        </div>

        <div class="card-body">
            <div class="row g-3 mb-3">
                <div class="col-md-3">
                    <div class="small-box text-bg-info">
                        <div class="inner">
                            <h4>{{ $totalPlots }}</h4>
                            <p>Total Plots</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="small-box text-bg-success">
                        <div class="inner">
                            <h4>{{ $soldPlots }}</h4>
                            <p>Sold Plots</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="small-box text-bg-warning">
                        <div class="inner">
                            <h4>{{ $leftPlots }}</h4>
                            <p>Plots Left</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="small-box text-bg-secondary">
                        <div class="inner">
                            <h4>{{ $customers }}</h4>
                            <p>Customers</p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <h6>Bonds ({{ $totalBonds }})</h6>
                    <div class="table-responsive">
                        <table class="table table-sm table-striped">
                            <thead><tr><th>Bond No</th><th>Customer</th><th>Broker Paid</th></tr></thead>
                            <tbody>
                                @foreach($bonds as $b)
                                    <tr>
                                        <td>{{ $b->bond_no }}</td>
                                        <td>{{ $b->customer?->name ?? '-' }}</td>
                                        <td>{{ number_format((float) $b->broker_paid, 2) }}</td>
                                    </tr>
                                @endforeach
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-md-6">
                    <h6>Map</h6>
                    <div id="araziMap" style="height:360px;border:1px solid #ddd;background:#f8f9fa;display:flex;align-items:center;justify-content:center">
                        <div class="text-muted">Map placeholder — integrate Leaflet/Google Maps here</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
@endsection
