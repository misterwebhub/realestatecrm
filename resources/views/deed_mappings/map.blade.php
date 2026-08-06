@extends('layouts.app')

@section('content')
<div class="container-fluid py-3">
    <div class="d-flex align-items-center mb-3">
        <h4 class="mb-0">{{ $title }}</h4>
        <a href="{{ route('deed-mappings.index') }}" class="btn btn-outline-secondary btn-sm ms-auto">
            <i class="bi bi-arrow-left"></i> Back to Deed Mapping
        </a>
    </div>

    @if($errors->any())
        <div class="alert alert-danger">
            <ul class="mb-0">@foreach($errors->all() as $e)<li>{{ $e }}</li>@endforeach</ul>
        </div>
    @endif

    <div class="card shadow-sm">
        <div class="card-body">
            <form action="{{ route('deed-mappings.store') }}" method="POST" id="deedMappingForm">
                @csrf
                <input type="hidden" name="arazi_code" id="arazi_code_hidden" value="{{ $selectedCode }}">

                <div class="row g-3">
                    <div class="col-md-5">
                        <label class="form-label fw-semibold">Select Arazi <span class="text-danger">*</span></label>
                        <select id="arazi_select" class="form-select" required>
                            <option value="">-- Select Arazi --</option>
                            @foreach($arazis as $arazi)
                                <option value="{{ $arazi->legacy_arazi_code }}" @selected($selectedCode === $arazi->legacy_arazi_code)>
                                    {{ $arazi->legacy_arazi_code }}
                                    @if($arazi->location) — {{ $arazi->location }} @endif
                                </option>
                            @endforeach
                        </select>
                        <div class="form-text">Every kisan row under this arazi code will load below.</div>
                    </div>
                </div>

                <hr class="my-4">

                <div id="rowsWrapper">
                    <div id="rowsEmpty" class="text-center text-muted py-5">
                        Select an arazi above to load its kisan rows.
                    </div>
                    <div class="table-responsive d-none" id="rowsTableWrap">
                        <table class="table table-bordered align-middle mb-0">
                            <thead class="table-light">
                                <tr>
                                    <th style="width:60px;">#</th>
                                    <th>Kisan</th>
                                    <th style="width:260px;">Deed No <span class="text-danger">*</span></th>
                                    <th style="width:280px;">Partner <span class="text-danger">*</span></th>
                                </tr>
                            </thead>
                            <tbody id="rowsBody"></tbody>
                        </table>
                    </div>
                </div>

                <div class="mt-4 d-flex gap-2">
                    <button type="submit" class="btn btn-primary" id="saveBtn" disabled>
                        <i class="bi bi-save"></i> Save Deed Mapping
                    </button>
                    <a href="{{ route('deed-mappings.index') }}" class="btn btn-outline-secondary">Cancel</a>
                </div>
            </form>
        </div>
    </div>
</div>
@endsection

@push('scripts')
<script>
(function () {
    var partners     = @json($partners->map(fn($p) => ['id' => $p->id, 'name' => $p->name])->values());
    var initialRows   = @json($initialRows);
    var rowsUrl       = @json(route('deed-mappings.rows'));

    var araziSelect   = document.getElementById('arazi_select');
    var araziHidden    = document.getElementById('arazi_code_hidden');
    var rowsBody       = document.getElementById('rowsBody');
    var rowsEmpty      = document.getElementById('rowsEmpty');
    var rowsTableWrap  = document.getElementById('rowsTableWrap');
    var saveBtn        = document.getElementById('saveBtn');

    function partnerOptions(selectedId) {
        var html = '<option value="">-- Select Partner --</option>';
        partners.forEach(function (p) {
            var sel = String(p.id) === String(selectedId) ? 'selected' : '';
            html += '<option value="' + p.id + '" ' + sel + '>' + p.name + '</option>';
        });
        return html;
    }

    function renderRows(rows) {
        rowsBody.innerHTML = '';

        if (!rows || !rows.length) {
            rowsEmpty.textContent = araziSelect.value
                ? 'No kisan rows found for this arazi. Each arazi row needs a kisan assigned before it can be deed-mapped.'
                : 'Select an arazi above to load its kisan rows.';
            rowsEmpty.classList.remove('d-none');
            rowsTableWrap.classList.add('d-none');
            saveBtn.disabled = true;
            return;
        }

        rows.forEach(function (row, i) {
            var tr = document.createElement('tr');
            tr.innerHTML =
                '<td>' + (i + 1) + '</td>' +
                '<td>' +
                    '<div class="fw-semibold">' + row.kisan_name + '</div>' +
                    (row.kisan_mobile ? '<div class="text-muted" style="font-size:12px;">' + row.kisan_mobile + '</div>' : '') +
                    '<input type="hidden" name="rows[' + i + '][arazi_id]" value="' + row.arazi_id + '">' +
                '</td>' +
                '<td><input type="text" class="form-control" name="rows[' + i + '][deed_no]" value="' + (row.deed_no || '') + '" placeholder="Deed No"></td>' +
                '<td><select class="form-select" name="rows[' + i + '][partner_id]">' + partnerOptions(row.partner_id) + '</select></td>';
            rowsBody.appendChild(tr);
        });

        rowsEmpty.classList.add('d-none');
        rowsTableWrap.classList.remove('d-none');
        saveBtn.disabled = false;
    }

    function loadRows(code) {
        if (!code) {
            renderRows([]);
            return;
        }
        fetch(rowsUrl + '?arazi_code=' + encodeURIComponent(code), { headers: { 'Accept': 'application/json' } })
            .then(function (res) { return res.json(); })
            .then(function (data) { renderRows(data.rows || []); })
            .catch(function () { renderRows([]); });
    }

    araziSelect.addEventListener('change', function () {
        araziHidden.value = araziSelect.value;
        loadRows(araziSelect.value);
    });

    // Initial state: server already loaded rows for $selectedCode (edit mode).
    if (araziSelect.value) {
        renderRows(initialRows);
    }
})();
</script>
@endpush
