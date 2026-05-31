@extends('layouts.app')

@section('content')
    @php
        $overallTotal = $bonds->sum('total');
        $overallPaid = $bonds->sum('paid');
        $overallBalance = $bonds->sum('balance');
    @endphp

    <div class="card card-outline card-primary mb-3">
        <div class="card-header d-flex align-items-center justify-content-between flex-wrap gap-2">
            <h5 class="card-title mb-0">{{ $title }}</h5>
            <div class="d-flex flex-wrap gap-2 align-items-center">
                @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                    @if(isset($exportLedgerCsvUrl) && $exportLedgerCsvUrl)
                        <a href="{{ $exportLedgerCsvUrl }}" class="btn btn-outline-success btn-sm">
                            <i class="bi bi-filetype-csv"></i> Export entries (CSV)
                        </a>
                    @endif
                @endif
                <button type="button" class="btn btn-outline-secondary btn-sm" onclick="window.print()">Print</button>
            </div>
        </div>
        <div class="card-body">
            <form method="GET" class="row g-3 align-items-end">
                @if(!empty($selectedPartyId))
                    <input type="hidden" name="{{ $partyFilterName }}" value="{{ $selectedPartyId }}">
                @endif
                <div class="col-md-6">
                    <label for="bond_id" class="form-label">Bond Wise Filter</label>
                    <select name="{{ $filterName }}" id="bond_id" class="form-select">
                        <option value="">Overall Ledger</option>
                        @foreach($bonds as $bond)
                            <option value="{{ $bond['id'] }}" @selected((string) $selectedBondId === (string) $bond['id'])>
                                {{ $bond['bond_no'] }} - {{ $bond['party'] }}
                            </option>
                        @endforeach
                    </select>
                </div>
                <div class="col-md-3">
                    <button type="submit" class="btn btn-primary w-100">Show Ledger</button>
                </div>
                <div class="col-md-3">
                    <a href="{{ url()->current() }}" class="btn btn-outline-secondary w-100">Reset</a>
                </div>
            </form>
        </div>
    </div>

    <div class="row g-3 mb-3">
        <div class="col-md-4">
            <div class="small-box text-bg-primary">
                <div class="inner">
                    <h4>{{ number_format((float) $overallTotal, 2) }}</h4>
                    <p>Total Amount</p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="small-box text-bg-success">
                <div class="inner">
                    <h4>{{ number_format((float) $overallPaid, 2) }}</h4>
                    <p>Total Paid</p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="small-box text-bg-danger">
                <div class="inner">
                    <h4>{{ number_format((float) $overallBalance, 2) }}</h4>
                    <p>Total Balance</p>
                </div>
            </div>
        </div>
    </div>

    <div class="card card-outline card-info mb-3">
        <div class="card-header">
            <h5 class="card-title mb-0">Overall Bond Summary</h5>
        </div>
        <div class="card-body table-responsive p-0">
            <table class="table table-striped table-hover mb-0 align-middle">
                <thead>
                    <tr>
                        <th>{{ $bondLabel }}</th>
                        <th>{{ $partyLabel }}</th>
                        <th class="text-end">Total Amount</th>
                        <th class="text-end">Paid</th>
                        <th class="text-end">Balance</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($bonds as $bond)
                        <tr>
                            <td>{{ $bond['bond_no'] }}</td>
                            <td>{{ $bond['party'] }}</td>
                            <td class="text-end">{{ number_format((float) $bond['total'], 2) }}</td>
                            <td class="text-end">{{ number_format((float) $bond['paid'], 2) }}</td>
                            <td class="text-end">{{ number_format((float) $bond['balance'], 2) }}</td>
                        </tr>
                    @empty
                        <tr>
                            <td colspan="5" class="text-center py-4">No bonds found.</td>
                        </tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>

    <div class="card card-outline card-secondary">
        <div class="card-header">
            <h5 class="card-title mb-0">{{ $selectedBondId ? 'Bond Wise Payment Entries' : 'All Payment Entries' }}</h5>
        </div>
        <div class="card-body table-responsive p-0">
            <table class="table table-striped table-hover mb-0 align-middle">
                <thead>
                    <tr>
                        <th>Entry No</th>
                        <th>{{ $bondLabel }}</th>
                        <th>{{ $partyLabel }}</th>
                        <th>Date</th>
                        <th>Type</th>
                        <th class="text-end">Amount</th>
                        <th>Method</th>
                        <th>Remarks</th>
                    </tr>
                </thead>
                <tbody>
                    @forelse($entries as $entry)
                        <tr>
                            <td>{{ $entry['entry_no'] }}</td>
                            <td>{{ $entry['bond_no'] }}</td>
                            <td>{{ $entry['party'] }}</td>
                            <td>{{ $entry['date'] }}</td>
                            <td>{{ $entry['type'] }}</td>
                            <td class="text-end">{{ number_format((float) $entry['amount'], 2) }}</td>
                            <td>
                                {{ $entry['method'] }}
                                @if(!empty($entry['cheque_number']))
                                    — {{ $entry['cheque_number'] }}
                                @endif
                            </td>
                            <td>{{ $entry['remarks'] }}</td>
                        </tr>
                    @empty
                        <tr>
                            <td colspan="8" class="text-center py-4">No payment entries found.</td>
                        </tr>
                    @endforelse
                </tbody>
            </table>
        </div>
    </div>
@endsection
