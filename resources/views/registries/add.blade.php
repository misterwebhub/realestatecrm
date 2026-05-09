@php
    $isEdit = isset($item) && $item->exists;
    $action = $action ?? route('registries.store');
    $method = $method ?? 'POST';
    $customers = $customers ?? [];
    $arazis = $arazis ?? [];
    $agents = $agents ?? [];
@endphp
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="csrf-token" content="{{ csrf_token() }}">
    <title>{{ $isEdit ? 'Edit' : 'Add' }} Registry</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body{background:#fff;color:#000;font-family:Arial,Helvetica,sans-serif}
        .card{max-width:1100px;margin:12px auto;padding:14px;border:4px solid #000}
        table{width:100%;border-collapse:collapse}
        th,td{border:1px solid #000;padding:8px}
        .header{font-size:28px;text-align:center;margin-bottom:6px}
        .muted{color:#555}
        .actions{margin-top:12px;text-align:center}
    </style>
</head>
<body>
<div class="card">
    <div class="header">RAGISTRY / REGISTRY ENTRY</div>
    <form action="{{ $action }}" method="POST">
        @csrf
        @if($method !== 'POST') @method($method) @endif

        <table>
            <tr>
                <th>Mobile No</th>
                <td><input type="text" name="mobile" value="{{ old('mobile', $item->mobile ?? '') }}" /></td>
                <th>Receipt No</th>
                <td><input type="text" name="receipt_no" value="{{ old('receipt_no', $item->receipt_no ?? '') }}" /></td>
            </tr>
            <tr>
                <th>Name, D.O.B and Address of Associate</th>
                <td colspan="3"><select name="customer_id">
                    <option value="">--Select Customer--</option>
                    @foreach($customers as $id => $name)
                        <option value="{{ $id }}" {{ (string)$id === (string) old('customer_id', $item->customer_id ?? '') ? 'selected' : '' }}>{{ $name }}</option>
                    @endforeach
                </select>
                <br><textarea name="associate_address" rows="3">{{ old('associate_address', $item->associate_address ?? '') }}</textarea></td>
            </tr>
            <tr>
                <th>Arazi</th>
                <td><select name="arazi_id">
                    <option value="">--Select Arazi--</option>
                    @foreach($arazis as $id => $label)
                        <option value="{{ $id }}" {{ (string)$id === (string) old('arazi_id', $item->arazi_id ?? '') ? 'selected' : '' }}>{{ $label }}</option>
                    @endforeach
                </select></td>
                <th>Registry Date</th>
                <td><input type="date" name="registry_date" value="{{ old('registry_date', optional($item->registry_date)->format('Y-m-d') ?? '') }}" /></td>
            </tr>
            <tr>
                <th>Booking Mode</th>
                <td><select name="booking_mode"><option value="cash" @selected(old('booking_mode', $item->booking_mode ?? '')=='cash')>Cash</option><option value="emi" @selected(old('booking_mode', $item->booking_mode ?? '')=='emi')>EMI</option><option value="other" @selected(old('booking_mode', $item->booking_mode ?? '')=='other')>Other</option></select></td>
                <th>Registry Amount</th>
                <td><input type="number" step="0.01" name="registry_amount" value="{{ old('registry_amount', $item->registry_amount ?? '') }}" /></td>
            </tr>
            <tr>
                <th>Amount in Words</th>
                <td colspan="3"><input type="text" name="payment_words" value="{{ old('payment_words', $item->payment_words ?? '') }}" style="width:100%" /></td>
            </tr>
            <tr>
                <th>Witness</th>
                <td><input type="text" name="witness_name" value="{{ old('witness_name', $item->witness_name ?? '') }}" /></td>
                <th>Nominee</th>
                <td><input type="text" name="nominee_name" value="{{ old('nominee_name', $item->nominee_name ?? '') }}" /></td>
            </tr>
            <tr>
                <th>Agent</th>
                <td><select name="agent_id"><option value="">--Select Broker--</option>@foreach($agents as $id => $name)<option value="{{ $id }}" @selected((string)$id===(string)old('agent_id',$item->agent_id ?? ''))>{{ $name }}</option>@endforeach</select></td>
                <th>Checked By</th>
                <td><select name="check_by_agent_id"><option value="">--Select Broker--</option>@foreach($agents as $id => $name)<option value="{{ $id }}" @selected((string)$id===(string)old('check_by_agent_id',$item->check_by_agent_id ?? ''))>{{ $name }}</option>@endforeach</select></td>
            </tr>
        </table>

        <div class="actions">
            <button type="submit" class="btn btn-primary">{{ $isEdit ? 'Update' : 'Create' }}</button>
            <a href="{{ route('registries.index') }}" class="btn btn-secondary">Back to Registries</a>
            @if($isEdit)
                <button type="button" id="esignBtn" class="btn btn-info">E-Sign</button>
            @endif
        </div>
    </form>
</div>

<script>
    document.addEventListener('DOMContentLoaded', function(){
        const esignBtn = document.getElementById('esignBtn');
        if(!esignBtn) return;
        const esignUrl = '{{ $isEdit ? route('registries.esign', $item->id) : '' }}';
        esignBtn.addEventListener('click', function(){
            if(!confirm('Apply e-signature placeholder for this registry?')) return;
            fetch(esignUrl, {method:'POST', headers:{'X-CSRF-TOKEN': document.querySelector('meta[name="csrf-token"]').getAttribute('content'),'Content-Type':'application/json'}, body: JSON.stringify({placeholder: true})})
                .then(r => r.json()).then(j => alert(j.message || 'Signed'))
                .catch(e => alert('Error'));
        });
    });
</script>
</body>
</html>
