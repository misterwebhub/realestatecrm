@extends('layouts.app')

@section('content')

{{-- Header --}}
<div class="d-flex align-items-center gap-2 mb-3 flex-wrap">
    <a href="{{ url()->previous() !== url()->current() ? url()->previous() : route('customer-bond-payments.index') }}"
       class="btn btn-sm btn-outline-secondary">
        <i class="bi bi-arrow-left"></i> Back
    </a>
    <div class="ms-1">
        <h5 class="mb-0 fw-bold">{{ $title }}</h5>
        <small class="text-muted">
            {{ $bond->customer?->name }}
            @if($bond->customer?->mobile) · {{ $bond->customer->mobile }} @endif
        </small>
    </div>
    <div class="ms-auto d-flex gap-2">
        <a href="{{ route('customer-bond-payments.compact') }}?bond_id={{ $bond->id }}"
           class="btn btn-sm btn-outline-primary">
            <i class="bi bi-plus-lg"></i> Add Payment
        </a>
        <a href="{{ route('customer-bond-payments.ledger', ['bond_id' => $bond->id]) }}"
           class="btn btn-sm btn-outline-secondary">
            <i class="bi bi-layout-text-sidebar"></i> Full Ledger View
        </a>
    </div>
</div>

{{-- Bond summary strip --}}
<div class="row g-2 mb-3">
    <div class="col-auto">
        <div class="px-3 py-2 rounded border" style="font-size:12px;background:#f8fafc;">
            <span class="text-muted">Arazi</span>
            <span class="ms-2 fw-bold" style="background:#1a3a6b;color:#fff;border-radius:3px;padding:1px 7px;font-size:11px;">
                {{ $bond->arazi?->legacy_arazi_code ?? $bond->arazi_code ?? '-' }}
            </span>
        </div>
    </div>
    @if($bond->plots->isNotEmpty())
    <div class="col-auto">
        <div class="px-3 py-2 rounded border" style="font-size:12px;background:#f8fafc;">
            <span class="text-muted">Plot(s)</span>
            <span class="ms-2 fw-semibold">{{ $bond->plots->pluck('title')->implode(', ') }}</span>
        </div>
    </div>
    @endif
    <div class="col-auto">
        <div class="px-3 py-2 rounded border" style="font-size:12px;background:#f8fafc;">
            <span class="text-muted">Bond Total</span>
            <span class="ms-2 fw-bold text-primary">₹{{ number_format($totalAmount, 2) }}</span>
        </div>
    </div>
    <div class="col-auto">
        <div class="px-3 py-2 rounded border" style="font-size:12px;background:#dcfce7;">
            <span class="text-success fw-semibold">Paid</span>
            <span class="ms-2 fw-bold text-success">₹{{ number_format($totalPaid, 2) }}</span>
        </div>
    </div>
    <div class="col-auto">
        <div class="px-3 py-2 rounded border" style="font-size:12px;background:{{ $balance > 0 ? '#fee2e6' : '#dcfce7' }};">
            <span class="{{ $balance > 0 ? 'text-danger' : 'text-success' }} fw-semibold">Balance</span>
            <span class="ms-2 fw-bold {{ $balance > 0 ? 'text-danger' : 'text-success' }}">
                @if($balance > 0) ₹{{ number_format($balance, 2) }}
                @else <i class="bi bi-check-circle-fill"></i> Cleared
                @endif
            </span>
        </div>
    </div>
</div>

{{-- Entries table --}}
<div class="card border-0 shadow-sm">
    <div class="card-body p-0">
        <div class="table-responsive">
            <table class="table mb-0 align-middle" style="font-size:13px;">
                <thead style="background:#f8fafc;">
                    <tr>
                        <th class="ps-3 py-2" style="font-size:11px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.4px;width:36px;">#</th>
                        <th style="font-size:11px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Entry No</th>
                        <th style="font-size:11px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Date</th>
                        <th style="font-size:11px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Type</th>
                        <th class="text-end" style="font-size:11px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Credit</th>
                        <th class="text-end" style="font-size:11px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Debit</th>
                        <th class="text-end" style="font-size:11px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Running Balance</th>
                        <th style="font-size:11px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Method</th>
                        <th style="font-size:11px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.4px;">Remarks</th>
                        <th style="font-size:11px;font-weight:700;text-transform:uppercase;color:#64748b;letter-spacing:.4px;"></th>
                    </tr>
                </thead>
                <tbody>
                    @php $running = 0; @endphp
                    @forelse($entries as $i => $entry)
                    @php
                        $isDebit = in_array($entry->entry_type, ['return', 'discount']);
                        $amount  = (float) $entry->amount;
                        if ($isDebit) { $running -= $amount; } else { $running += $amount; }
                        $typeColors = [
                            'advance'     => 'background:#dbeafe;color:#1d4ed8;',
                            'installment' => 'background:#dcfce7;color:#15803d;',
                            'final'       => 'background:#f3e8ff;color:#7e22ce;',
                            'penalty'     => 'background:#fee2e2;color:#b91c1c;',
                            'return'      => 'background:#fff7ed;color:#c2410c;',
                            'discount'    => 'background:#fef9c3;color:#854d0e;',
                        ];
                        $typeStyle = $typeColors[$entry->entry_type] ?? 'background:#f1f5f9;color:#475569;';
                    @endphp
                    <tr style="border-bottom:1px solid #f1f5f9;">
                        <td class="ps-3 text-muted" style="font-size:11px;">{{ $i + 1 }}</td>
                        <td class="fw-semibold" style="font-size:12px;">{{ $entry->entry_no ?? '-' }}</td>
                        <td style="white-space:nowrap;">{{ optional($entry->entry_date)->format('d-m-Y') ?? '-' }}</td>
                        <td>
                            <span style="display:inline-block;padding:2px 9px;border-radius:20px;font-size:11px;font-weight:600;{{ $typeStyle }}">
                                {{ ucfirst($entry->entry_type ?? '-') }}
                            </span>
                        </td>
                        @if($isDebit)
                            <td class="text-end text-muted">—</td>
                            <td class="text-end text-danger fw-semibold">−₹{{ number_format($amount, 2) }}</td>
                        @else
                            <td class="text-end text-success fw-semibold">₹{{ number_format($amount, 2) }}</td>
                            <td class="text-end text-muted">—</td>
                        @endif
                        <td class="text-end fw-semibold" style="font-size:12px;color:{{ $running >= 0 ? '#1d4ed8' : '#b91c1c' }};">
                            ₹{{ number_format($running, 2) }}
                        </td>
                        <td style="font-size:12px;color:#475569;">{{ $entry->payment_method ?? '-' }}</td>
                        <td style="font-size:12px;color:#64748b;max-width:140px;overflow:hidden;text-overflow:ellipsis;white-space:nowrap;"
                            title="{{ $entry->remarks }}">
                            {{ $entry->remarks ?? '' }}
                        </td>
                        <td class="pe-2">
                            <div class="d-flex gap-1 justify-content-end">
                                @if($entry->entry_no)
                                <a href="{{ route('customer-bond-payments.receipt', ['entry_no' => $entry->entry_no, 'print' => 1]) }}"
                                   class="btn btn-xs btn-outline-secondary" target="_blank"
                                   style="font-size:10px;padding:1px 6px;" title="Print receipt">
                                    <i class="bi bi-printer"></i>
                                </a>
                                @endif
                                <a href="{{ route('customer-bond-payments.edit', $entry->id) }}"
                                   class="btn btn-xs btn-outline-primary"
                                   style="font-size:10px;padding:1px 6px;" title="Edit">
                                    <i class="bi bi-pencil"></i>
                                </a>
                            </div>
                        </td>
                    </tr>
                    @empty
                    <tr>
                        <td colspan="10" class="text-center py-5 text-muted">
                            <div style="font-size:28px;">📋</div>
                            <div class="mt-2">No payment entries yet for this bond.</div>
                            <a href="{{ route('customer-bond-payments.compact') }}"
                               class="btn btn-sm btn-primary mt-2">Add First Payment</a>
                        </td>
                    </tr>
                    @endforelse
                </tbody>
                @if($entries->isNotEmpty())
                <tfoot style="background:#f8fafc;border-top:2px solid #e2e8f0;">
                    <tr>
                        <td colspan="4" class="ps-3 py-2 text-end text-muted fw-semibold" style="font-size:12px;">TOTAL</td>
                        <td class="text-end text-success fw-bold" style="font-size:12px;">
                            ₹{{ number_format($entries->whereNotIn('entry_type', ['return','discount'])->sum('amount'), 2) }}
                        </td>
                        <td class="text-end text-danger fw-bold" style="font-size:12px;">
                            ₹{{ number_format($entries->whereIn('entry_type', ['return','discount'])->sum('amount'), 2) }}
                        </td>
                        <td class="text-end fw-bold" style="font-size:12px;color:{{ $balance > 0 ? '#b91c1c' : '#15803d' }};">
                            ₹{{ number_format($running, 2) }}
                        </td>
                        <td colspan="3"></td>
                    </tr>
                </tfoot>
                @endif
            </table>
        </div>
    </div>
</div>

@endsection
