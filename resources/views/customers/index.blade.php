@extends('layouts.app')

@section('content')
<div class="card card-outline card-primary">

    {{-- Header --}}
    <div class="card-header d-flex align-items-center flex-wrap gap-2">
        <h5 class="card-title mb-0 fw-bold">Customers</h5>
        <div class="d-flex gap-2 ms-auto">
            @if(!empty($exportCsvUrl))
                <a href="{{ $exportCsvUrl }}" class="btn btn-outline-success btn-sm"><i class="bi bi-filetype-csv"></i> Export CSV</a>
            @endif
            @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                <a href="{{ $createUrl }}" class="btn btn-primary btn-sm"><i class="bi bi-plus-lg"></i> Add New</a>
            @endif
        </div>
    </div>

    {{-- Filters --}}
    <div class="card-body border-bottom py-2 px-3">
        <form method="GET" class="row g-2 align-items-end">
            <div class="col-md-4">
                <label class="form-label small fw-semibold mb-1">Name / Phone</label>
                <input type="text" name="q" value="{{ $q }}"
                       class="form-control form-control-sm"
                       placeholder="Search name, mobile…">
            </div>
            <div class="col-md-3">
                <label class="form-label small fw-semibold mb-1">Arazi No</label>
                <input type="text" name="arazi_code" value="{{ $arazi_code }}"
                       class="form-control form-control-sm"
                       placeholder="e.g. 419, 375KA…">
            </div>
            <div class="col-md-3">
                <label class="form-label small fw-semibold mb-1">Plot No / Title</label>
                <input type="text" name="plot" value="{{ $plot }}"
                       class="form-control form-control-sm"
                       placeholder="Plot number or title…">
            </div>
            <div class="col-auto d-flex gap-2">
                <button type="submit" class="btn btn-primary btn-sm">Search</button>
                <a href="{{ route('customers.index') }}" class="btn btn-outline-secondary btn-sm">Clear</a>
            </div>
        </form>
        @if($q || $arazi_code || $plot)
            <div class="mt-2 small text-muted">
                {{ $customers->total() }} result(s)
                @if($q) for <strong>"{{ $q }}"</strong>@endif
                @if($arazi_code) · Arazi <strong>{{ $arazi_code }}</strong>@endif
                @if($plot) · Plot <strong>"{{ $plot }}"</strong>@endif
            </div>
        @endif
    </div>

    {{-- Table --}}
    <div class="card-body table-responsive p-0">
        <table class="table table-hover mb-0 align-middle customers-table" style="font-size:13px;border-collapse:separate;border-spacing:0;">
            <thead class="table-light">
                <tr>
                    <th style="width:80px">Code</th>
                    <th style="min-width:130px">Name</th>
                    <th style="width:120px">Mobile</th>
                    <th style="width:120px">Secondary</th>
                    <th>Bonds / Arazi / Plots</th>
                    <th class="text-end" style="width:160px">Actions</th>
                </tr>
            </thead>
            <tbody>
                @forelse($rows as $row)
                    <tr class="align-top">
                        <td class="text-muted">{{ $row['cells'][0] }}</td>
                        <td class="fw-semibold" title="{{ $row['cells'][1] }}">{{ \Illuminate\Support\Str::limit($row['cells'][1], 35) }}</td>
                        <td>{{ $row['cells'][2] }}</td>
                        <td class="text-muted">{{ $row['cells'][3] }}</td>

                        {{-- Bond / Arazi / Plot / Registry summary --}}
                        <td style="padding:6px 8px;min-width:340px;">
                            @php $bonds = $row['bond_summary'] ?? []; @endphp
                            @if(count($bonds) === 0)
                                <span class="text-muted px-1" style="font-size:12px;">— No bonds</span>
                            @else
                            <table style="width:100%;border-collapse:collapse;font-size:12px;border-radius:6px;overflow:hidden;box-shadow:0 1px 4px rgba(26,58,107,.10);border:1px solid #d0ddf0;">
                                <thead>
                                    <tr style="background:linear-gradient(90deg,#1a3a6b 0%,#2a52a0 100%);">
                                        <th style="padding:5px 10px;color:rgba(255,255,255,.75);font-size:10px;font-weight:600;text-transform:uppercase;letter-spacing:.6px;border-right:1px solid rgba(255,255,255,.12);white-space:nowrap;">Bond No</th>
                                        <th style="padding:5px 10px;color:rgba(255,255,255,.75);font-size:10px;font-weight:600;text-transform:uppercase;letter-spacing:.6px;border-right:1px solid rgba(255,255,255,.12);">Arazi</th>
                                        <th style="padding:5px 10px;color:rgba(255,255,255,.75);font-size:10px;font-weight:600;text-transform:uppercase;letter-spacing:.6px;border-right:1px solid rgba(255,255,255,.12);">Plot(s) / Gaz</th>
                                        <th style="padding:5px 10px;color:rgba(255,255,255,.75);font-size:10px;font-weight:600;text-transform:uppercase;letter-spacing:.6px;border-right:1px solid rgba(255,255,255,.12);">Broker</th>
                                        <th style="padding:5px 10px;color:rgba(255,255,255,.75);font-size:10px;font-weight:600;text-transform:uppercase;letter-spacing:.6px;text-align:center;">Registry</th>
                                    </tr>
                                </thead>
                                <tbody>
                                @foreach($bonds as $i => $b)
                                    <tr style="background:{{ $i % 2 === 0 ? '#fff' : '#f6f9ff' }};border-bottom:1px solid #e4ecf7;"
                                        onmouseover="this.style.background='#edf3ff'" onmouseout="this.style.background='{{ $i % 2 === 0 ? '#fff' : '#f6f9ff' }}'">
                                        <td style="padding:5px 10px;border-right:1px solid #e4ecf7;white-space:nowrap;">
                                            <a href="{{ route('customer-bond-cheques.manage', $b['bond_id']) }}"
                                               target="_blank"
                                               style="color:#1a3a6b;font-weight:700;font-size:12px;text-decoration:none;letter-spacing:.2px;">
                                                {{ $b['bond_no'] }}
                                            </a>
                                        </td>
                                        <td style="padding:5px 10px;border-right:1px solid #e4ecf7;white-space:nowrap;">
                                            <span style="background:#1a3a6b;color:#fff;border-radius:4px;padding:2px 8px;font-size:11px;font-weight:700;letter-spacing:.3px;">{{ $b['arazi_code'] }}</span>
                                        </td>
                                        <td style="padding:5px 10px;border-right:1px solid #e4ecf7;color:#374151;max-width:220px;">
                                            @php $plotList = is_array($b['plots']) ? $b['plots'] : []; @endphp
                                            @if(count($plotList) === 0)
                                                <span class="text-muted">-</span>
                                            @else
                                                @foreach($plotList as $pl)
                                                    <div style="display:flex;justify-content:space-between;gap:8px;white-space:nowrap;{{ !$loop->last ? 'border-bottom:1px dashed #e4ecf7;padding-bottom:2px;margin-bottom:2px;' : '' }}">
                                                        <span style="font-weight:600;color:#1a3a6b;">{{ $pl['name'] }}</span>
                                                        <span style="color:#374151;">{{ $pl['gaz'] !== null ? rtrim(rtrim(number_format($pl['gaz'],2),'0'),'.').' gaz' : '—' }}</span>
                                                    </div>
                                                @endforeach
                                                @if(count($plotList) > 1)
                                                    <div style="text-align:right;margin-top:3px;padding-top:2px;border-top:1px solid #d0ddf0;font-weight:700;color:#15803d;">
                                                        Total: {{ rtrim(rtrim(number_format((float)($b['plots_gaz'] ?? 0),2),'0'),'.') }} gaz
                                                    </div>
                                                @endif
                                            @endif
                                        </td>
                                        <td style="padding:5px 10px;border-right:1px solid #e4ecf7;color:#374151;white-space:nowrap;">
                                            {{ $b['broker'] ?? '-' }}
                                        </td>
                                        <td style="padding:5px 10px;text-align:center;white-space:nowrap;">
                                            @if($b['has_registry'])
                                                <span style="display:inline-flex;align-items:center;gap:3px;background:#dcfce7;color:#15803d;border:1px solid #86efac;border-radius:4px;padding:2px 8px;font-size:11px;font-weight:700;">
                                                    <svg width="10" height="10" viewBox="0 0 12 12" fill="none"><path d="M2 6l3 3 5-5" stroke="#15803d" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg> Yes
                                                </span>
                                            @else
                                                <span style="display:inline-flex;align-items:center;gap:3px;background:#fef2f2;color:#b91c1c;border:1px solid #fca5a5;border-radius:4px;padding:2px 8px;font-size:11px;font-weight:700;">
                                                    <svg width="10" height="10" viewBox="0 0 12 12" fill="none"><path d="M3 3l6 6M9 3l-6 6" stroke="#b91c1c" stroke-width="2" stroke-linecap="round"/></svg> No
                                                </span>
                                            @endif
                                        </td>
                                    </tr>
                                @endforeach
                                </tbody>
                            </table>
                            @endif
                        </td>

                        {{-- Actions --}}
                        <td class="text-end" style="white-space:nowrap;">
                            @foreach($row['action_buttons'] ?? [] as $btn)
                                <a href="{{ $btn['url'] }}" class="btn {{ $btn['class'] ?? 'btn-outline-secondary' }} btn-sm">{{ $btn['label'] }}</a>
                            @endforeach
                            @if(auth()->check() && in_array(auth()->user()->role, ['admin','manager']))
                                <a href="{{ $row['edit_url'] }}" class="btn btn-outline-secondary btn-sm">Edit</a>
                                <form action="{{ $row['delete_url'] }}" method="POST" class="d-inline-block" onsubmit="return confirm('Delete this customer?');">
                                    @csrf @method('DELETE')
                                    <button class="btn btn-outline-danger btn-sm">Del</button>
                                </form>
                            @endif
                        </td>
                    </tr>
                @empty
                    <tr>
                        <td colspan="6" class="text-center py-4 text-muted">
                            No customers found.
                            @if($q || $arazi_code || $plot)
                                <a href="{{ route('customers.index') }}">Clear filters</a>
                            @endif
                        </td>
                    </tr>
                @endforelse
            </tbody>
        </table>
    </div>

    {{-- Pagination --}}
    <div class="card-footer d-flex justify-content-between align-items-center">
        <div class="small text-muted">
            Showing {{ $customers->firstItem() ?? 0 }}–{{ $customers->lastItem() ?? 0 }} of {{ $customers->total() }}
        </div>
        <div>{{ $customers->links() }}</div>
    </div>

</div>
@endsection

@push('styles')
<style>
    /* Customer index — row separators & cell padding */
    .customers-table > tbody > tr > td {
        padding-top: 10px;
        padding-bottom: 10px;
        vertical-align: top;
    }
    .customers-table > tbody > tr {
        border-top: 2px solid #d0ddf0 !important;
    }
    .customers-table > tbody > tr:first-child {
        border-top: none !important;
    }
    .customers-table > tbody > tr:hover > td {
        background: #f4f7fd !important;
    }
</style>
@endpush
