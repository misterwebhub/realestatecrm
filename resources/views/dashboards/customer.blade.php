@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-header d-flex justify-content-between align-items-center">
            <h5 class="card-title mb-0">Customer Dashboard — {{ $customer->name }}</h5>
            <div>
                <a href="{{ $shareUrl }}" class="btn btn-outline-secondary btn-sm" target="_blank">Shareable Link</a>
            </div>
        </div>

        <div class="card-body">
            <div class="row g-3 mb-3">
                <div class="col-md-3">
                    <div class="small-box text-bg-info">
                        <div class="inner">
                            <h4>{{ $bondsCount }}</h4>
                            <p>Bonds Created</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="small-box text-bg-success">
                        <div class="inner">
                            <h4>{{ number_format((float)$totalBondAmount,2) }}</h4>
                            <p>Total Bond Amount</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="small-box text-bg-warning">
                        <div class="inner">
                            <h4>{{ number_format((float)$totalPaid,2) }}</h4>
                            <p>Total Paid</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="small-box text-bg-secondary">
                        <div class="inner">
                            <h4>{{ $cheques->count() }}</h4>
                            <p>Cheque Entries</p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-7">
                    <h6>Recent Payments</h6>
                    <div class="table-responsive">
                        <table class="table table-sm table-striped">
                            <thead><tr><th>Entry</th><th>Date</th><th>Amount</th><th>Method</th></tr></thead>
                            <tbody>
                                @foreach($payments as $p)
                                    <tr>
                                        <td>{{ $p->entry_no }}</td>
                                        <td>{{ optional($p->entry_date)->format('d-m-Y') }}</td>
                                        <td class="text-end">{{ number_format((float)$p->amount,2) }}</td>
                                        <td>{{ $p->payment_method ?? '-' }}</td>
                                    </tr>
                                @endforeach
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-md-5">
                    <h6>Recent Cheques</h6>
                    <div class="table-responsive">
                        <table class="table table-sm table-striped">
                            <thead><tr><th>Cheque No</th><th>Date</th><th>Amount</th></tr></thead>
                            <tbody>
                                @foreach($cheques as $c)
                                    <tr>
                                        <td>{{ $c->cheque_number }}</td>
                                        <td>{{ optional($c->cheque_date)->format('d-m-Y') }}</td>
                                        <td class="text-end">{{ number_format((float)$c->amount,2) }}</td>
                                    </tr>
                                @endforeach
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="mt-3">
                <a href="{{ route('customer-bond-payments.ledger', ['customer_id' => $customer->id]) }}" class="btn btn-outline-primary btn-sm">Open Customer Ledger</a>
                <a href="{{ route('customers.bonds', ['customer' => $customer->id]) }}" class="btn btn-outline-secondary btn-sm">Customer Bonds</a>
            </div>
        </div>
    </div>
@endsection
