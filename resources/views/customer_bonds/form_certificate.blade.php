@php
    $isEdit = isset($item) && $item->exists;
    $action = $action ?? route('customer-bonds.store');
    $method = $method ?? 'POST';
    $customers = $customers ?? [];
    $arazis = $arazis ?? [];
    $agents = $agents ?? [];
@endphp
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>{{ $isEdit ? 'Edit' : 'Create' }} Customer Bond</title>
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .wrrper{width:990px;margin:0 auto;border:5px solid black;padding:8px}
        table {border-collapse: collapse;width:100%;}
        table, td, th {border: 1px solid black;text-align:center;}
        th{padding:5px;background:#ececec}
        td{padding:10px}
        .style4{height:237px}
        .style3{height:131px}
        .style1{height:78px}
        .style5{width:415px;text-align:left}
        .textboxmain{width:100%}
        .small{font-size:12px;color:#555}
        label{font-weight:700}
        .form-row{margin-bottom:8px}
    </style>
</head>
<body>
<div class="wrrper" id="main">
    <form action="{{ $action }}" method="POST">
        @csrf
        @if($method !== 'POST')
            @method($method)
        @endif

        <table>
            <tr>
                <td style="font-weight:bold;">CIN-U45201UP2019PTC123734</td>
                <td bgcolor="#00FFCC"><strong>CUSTOMER REG. NO</strong>&nbsp;
                    <input type="text" name="bond_no" value="{{ old('bond_no', $item->bond_no ?? '') }}" />
                </td>
                <td style="text-align:right;font-weight:bold;">MOB. +91-9696446268, 9935142277</td>
            </tr>
            <tr>
                <td colspan="3" class="style4" style="text-align:center">
                    <div style="display:block;text-align:center">
                        <p style="font-size:37pt;color:red;font-weight:bold;margin:0;line-height:1;">HEED REAL</p>
                        <p style="font-size:21pt;margin:0;line-height:1;">ESTATE PRIVATE LIMITED</p>
                        <p style="display:inline-block;padding:6px 8px;background-color:#000080;color:white;font-size:15pt;margin-top:6px;">19A, New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</p>
                    </div>
                    <div style="margin-top:10px;text-align:justify;font-size:13pt;line-height:1.45;padding:8px;">
                        <strong>CERTIFIED</strong> that the associate described in the Schedule here to is registered in the Joint Venture of Consideration as shown in the Schedule under the Plan of the Company, subject to the regular payment of subscription(s) mentioned in the said Schedule and also subject to the "General Terms & Conditions" printed overleaf and the terms and conditions as per the rules book, as may be amended from time to time. The Company shall pay in Indian currency at its associate service center through the corporate office the amount due under this certificate in accordance with the terms of the said Schedule to the person to whom the same is expressly made payable. It is hereby declared that the Schedule, the "General Terms & Conditions" and other terms of the rules book, as amended from time to time, shall be deemed to be a part of this certificate.
                    </div>
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <th>Regd.No & Date of Commencement</th>
                <th>Plan Name / Term</th>
                <th>Mode of Payment</th>
                <th>Consideration Amount</th>
                <th>Installment of subscription Payment</th>
            </tr>
            <tr>
                <td><input type="date" name="bond_date" value="{{ old('bond_date', optional($item->bond_date)->format('Y-m-d') ?? '') }}" /></td>
                <td><input type="text" name="bond_type" value="{{ old('bond_type', $item->bond_type ?? '') }}" /></td>
                <td>
                    <select name="bayana_mode">
                        <option value="">--Select--</option>
                        <option value="cash" {{ old('bayana_mode', $item->bayana_mode ?? '') == 'cash' ? 'selected' : '' }}>CASH</option>
                        <option value="cheque" {{ old('bayana_mode', $item->bayana_mode ?? '') == 'cheque' ? 'selected' : '' }}>CHEQUE</option>
                    </select>
                </td>
                <td><input type="number" step="0.01" name="total_amount" value="{{ old('total_amount', $item->total_amount ?? $item->bond_amount ?? 0) }}" /></td>
                <td><input type="number" step="0.01" name="amount" value="{{ old('amount', $item->amount ?? '') }}" /></td>
            </tr>
        </table>

        <table>
            <tr>
                <th>Installment Due Date</th>
                <th>Booking Amount</th>
                <th>Date Of Last Payment</th>
                <th>Expiry Date</th>
                <th>Agency ID</th>
            </tr>
            <tr>
                <td><input type="date" name="last_date" value="{{ old('last_date', optional($item->last_date)->format('Y-m-d') ?? '') }}" /></td>
                <td><input type="number" step="0.01" name="amount" value="{{ old('amount', $item->amount ?? '') }}" /></td>
                <td>-</td>
                <td>-</td>
                <td>
                    <select name="broker_id">
                        <option value="">--Select--</option>
                        @foreach($agents as $id => $name)
                            <option value="{{ $id }}" {{ (string)$id === (string) old('broker_id', $item->broker_id ?? '') ? 'selected' : '' }}>{{ $name }}</option>
                        @endforeach
                    </select>
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <th rowspan="4">Name, D.O.B and Address of Associate</th>
                <td rowspan="4" class="style5">
                    <select name="customer_id">
                        <option value="">--Select Customer--</option>
                        @foreach($customers as $id => $name)
                            <option value="{{ $id }}" {{ (string)$id === (string) old('customer_id', $item->customer_id ?? '') ? 'selected' : '' }}>{{ $name }}</option>
                        @endforeach
                    </select>
                    <br><textarea name="customer_address" class="textboxmain" rows="4">{{ old('customer_address', $item->customer?->address ?? '') }}</textarea>
                </td>
                <th colspan="2">Arazi No.</th>
            </tr>
            <tr>
                <td colspan="2">
                    <select name="arazi_id">
                        <option value="">--Select Arazi--</option>
                        @foreach($arazis as $id => $label)
                            <option value="{{ $id }}" {{ (string)$id === (string) old('arazi_id', $item->arazi_id ?? '') ? 'selected' : '' }}>{{ $label }}</option>
                        @endforeach
                    </select>
                </td>
            </tr>
            <tr>
                <th colspan="2">Plot No./Plot Size</th>
            </tr>
            <tr>
                <td colspan="2">{{ $item->arazi?->plot_number ?? '-' }} / <input type="text" name="land_size" value="{{ old('land_size', $item->land_size ?? $item->arazi?->size ?? '') }}" /></td>
            </tr>
            <tr>
                <th>Nominee's Name D.O.B and Relationship</th>
                <td colspan="2" class="style5">-</td>
                <td>Aadhar/PAN/Voter/D.L NO</td>
                <td><input type="text" name="id_card_no" value="{{ old('id_card_no', $item->customer?->id_document_no ?? '') }}" /></td>
            </tr>
        </table>

        <table>
            <tr>
                <th>EXPECTED SUM PAYABLE RUPEES</th>
                <td><input type="number" step="0.01" name="total_amount" value="{{ old('total_amount', $item->total_amount ?? $item->bond_amount ?? 0) }}" /></td>
            </tr>
        </table>

        <div style="margin-top:12px">
            <label>Witnesses (one per line)</label>
            <textarea name="witnesses" rows="4" class="textboxmain">{{ old('witnesses', isset($item) ? implode("\n", $item->witnesses->pluck('name')->all()) : '') }}</textarea>
        </div>

        <div style="margin-top:12px">
            <label>Notes</label>
            <textarea name="notes" rows="4" class="textboxmain">{{ old('notes', $item->notes ?? '') }}</textarea>
        </div>

        <div style="margin-top:12px;text-align:center">
            <button type="submit" class="btn btn-primary">{{ $isEdit ? 'Update' : 'Create' }}</button>
            <a href="{{ route('customer-bonds.index') }}" class="btn btn-secondary">Cancel</a>
        </div>
    </form>
</div>
</body>
</html>
