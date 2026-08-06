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

    <div class="card shadow-sm mb-3">
        <div class="card-body">
            <div class="row g-3">
                <div class="col-auto">
                    <label class="form-label fw-semibold">Select Arazi <span class="text-danger">*</span></label>
                    <select id="arazi_select" class="form-select js-select2" style="width:420px;">
                        <option value="">-- Select Arazi --</option>
                        @foreach($arazis as $arazi)
                            <option value="{{ $arazi->legacy_arazi_code }}" @selected($selectedCode === $arazi->legacy_arazi_code)>
                                {{ $arazi->legacy_arazi_code }}
                                @if($arazi->location) — {{ $arazi->location }} @endif
                            </option>
                        @endforeach
                    </select>
                    <div class="form-text">Pulls every kisan row's deed mapping under this arazi. Rows sharing a partner are pre-checked, but you can check/uncheck any deed-mapped row before merging.</div>
                </div>
                <div class="col-auto">
                    <label class="form-label fw-semibold">Search Merged Deed No</label>
                    <select id="merged_deed_no_select" class="form-select js-select2" style="width:320px;">
                        <option value="">-- Search Merged Deed No --</option>
                        @foreach($merges as $m)
                            <option value="{{ $m->merged_deed_no }}" data-arazi-code="{{ $m->arazi_code }}">
                                {{ $m->merged_deed_no }} (Arazi {{ $m->arazi_code }})
                            </option>
                        @endforeach
                    </select>
                    <div class="form-text">Jump straight to a merge by its new Deed No.</div>
                </div>
            </div>
        </div>
    </div>

    <div id="resultWrapper" class="d-none">
        <div id="resultAlert" class="alert"></div>

        <form id="mergeForm" method="POST" action="{{ route('deed-merges.store') }}">
            @csrf
            <input type="hidden" name="arazi_code" id="mergeAraziCode">

            <div class="card shadow-sm d-none" id="resultCardWrap">
                <div class="card-header d-flex align-items-center gap-2 flex-wrap">
                    <span class="fw-bold">Arazi <span id="resultCode"></span></span>
                    <span class="badge" id="resultPartnerBadge"></span>
                    <div class="d-flex align-items-center gap-2 ms-auto">
                        <input type="text" class="form-control form-control-sm" name="merged_deed_no" id="mergedDeedNo" placeholder="New Merged Deed No" style="width:220px;" required>
                        <button type="submit" class="btn btn-primary btn-sm" id="mergeSubmitBtn" disabled>
                            <i class="bi bi-arrow-down-up"></i> Merge Selected
                        </button>
                    </div>
                </div>
                <div class="table-responsive">
                    <table class="table table-sm mb-0 align-middle">
                        <thead class="table-light">
                            <tr>
                                <th class="ps-3" style="width:40px;"></th>
                                <th style="width:60px;">#</th>
                                <th>Kisan</th>
                                <th>Deed No</th>
                                <th>Partner</th>
                                <th style="width:230px;">Merged Deed No</th>
                                <th style="width:130px;">Status</th>
                            </tr>
                        </thead>
                        <tbody id="resultRows"></tbody>
                    </table>
                </div>
            </div>
        </form>
    </div>
</div>
@endsection

@push('scripts')
<script>
(function () {
    var araziSelect          = document.getElementById('arazi_select');
    var mergedDeedNoSearch   = document.getElementById('merged_deed_no_select');
    var resultWrapper        = document.getElementById('resultWrapper');
    var resultAlert          = document.getElementById('resultAlert');
    var resultCardWrap       = document.getElementById('resultCardWrap');
    var resultCode           = document.getElementById('resultCode');
    var resultPartnerBadge   = document.getElementById('resultPartnerBadge');
    var resultRows           = document.getElementById('resultRows');
    var mergeAraziCode       = document.getElementById('mergeAraziCode');
    var mergedDeedNo         = document.getElementById('mergedDeedNo');
    var mergeSubmitBtn       = document.getElementById('mergeSubmitBtn');
    var checkUrl             = @json(route('deed-merges.check'));
    var updateUrlTpl         = @json(route('deed-merges.update', ['deedMerging' => '__ID__']));
    var destroyUrlTpl        = @json(route('deed-merges.destroy', ['deedMerging' => '__ID__']));
    var csrfMeta             = document.querySelector('meta[name="csrf-token"]');
    var csrfToken            = csrfMeta ? csrfMeta.getAttribute('content') : '';
    var currentCode          = '';
    var pendingHighlightDeedNo = '';
    var suppressMergedDeedNoReset = false;

    function esc(v) {
        return (v === null || v === undefined) ? '' : String(v).replace(/[&<>"']/g, function (c) {
            return { '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;' }[c];
        });
    }

    function updateSubmitState() {
        var anyChecked = !!resultRows.querySelector('input[type="checkbox"]:checked');
        var hasDeedNo = mergedDeedNo.value.trim() !== '';
        mergeSubmitBtn.disabled = !(anyChecked && hasDeedNo);
    }

    // The Merged Deed No column: unmerged/singleton rows just show a dash.
    // A merge's head row (first row of its group) renders the badge plus
    // Edit/Unmerge actions — disabled (and titled) once the merge is locked
    // because its Deed No is already used on a Customer Registry row.
    function mergeCellHtml(row) {
        if (!row.merge_id) {
            return '<span class="text-muted">—</span>';
        }
        var lockAttr = row.merge_locked ? ' disabled title="Used in Customer Registry — locked"' : '';
        return '' +
            '<div class="d-flex align-items-center gap-1 merge-cell" data-merge-id="' + row.merge_id + '" data-deed-no="' + esc(row.merged_deed_no) + '">' +
                '<span class="badge bg-primary-subtle text-primary-emphasis merge-badge">' + esc(row.merged_deed_no) + '</span>' +
                '<button type="button" class="btn btn-link btn-sm p-0 merge-edit-btn"' + lockAttr + '><i class="bi bi-pencil"></i></button>' +
                '<button type="button" class="btn btn-link btn-sm p-0 text-danger merge-unmerge-btn"' + lockAttr + '><i class="bi bi-x-circle"></i></button>' +
            '</div>';
    }

    function renderRows(rows) {
        resultRows.innerHTML = '';
        rows.forEach(function (row, i) {
            var tr = document.createElement('tr');

            var checkboxCell = row.selectable
                ? '<input type="checkbox" class="form-check-input" name="arazi_ids[]" value="' + row.arazi_id + '"' + (row.suggested ? ' checked' : '') + '>'
                : '';

            var statusCell;
            if (row.merged) {
                statusCell = '<span class="badge bg-secondary">Already Merged</span>';
            } else if (row.suggested) {
                statusCell = '<span class="badge bg-success-subtle text-success border border-success-subtle">Suggested</span>';
            } else if (row.selectable) {
                statusCell = '<span class="badge bg-info-subtle text-info-emphasis border border-info-subtle">Selectable</span>';
            } else {
                statusCell = '<span class="badge bg-light text-muted border">Not eligible</span>';
            }

            var cells =
                '<td class="ps-3">' + checkboxCell + '</td>' +
                '<td>' + (i + 1) + '</td>' +
                '<td>' + esc(row.kisan_name || '—') + '</td>' +
                '<td>' + (row.deed_no ? '<span class="badge bg-primary-subtle text-primary-emphasis">' + esc(row.deed_no) + '</span>' : '<span class="text-muted">Not mapped</span>') + '</td>' +
                '<td>' + (row.partner_name ? esc(row.partner_name) : '<span class="text-muted">—</span>') + '</td>';

            // Only the merge-group's head row emits the Merged Deed No <td>,
            // with a rowspan covering the rest of its group — the other
            // member rows simply don't get this cell so the span covers them.
            if (row.is_merge_head) {
                var rowspanAttr = row.merge_group_size > 1 ? ' rowspan="' + row.merge_group_size + '"' : '';
                cells += '<td' + rowspanAttr + '>' + mergeCellHtml(row) + '</td>';
            }

            cells += '<td>' + statusCell + '</td>';

            tr.innerHTML = cells;
            resultRows.appendChild(tr);
        });

        resultRows.querySelectorAll('input[type="checkbox"]').forEach(function (cb) {
            cb.addEventListener('change', updateSubmitState);
        });
        updateSubmitState();
    }

    // After a table render, if the user got here via the "Search Merged
    // Deed No" dropdown, scroll to and briefly flash that merge's row so
    // it's easy to spot among the rest of the arazi's rows.
    function highlightPendingDeedNo() {
        if (!pendingHighlightDeedNo) {
            return;
        }
        var target = resultRows.querySelector('.merge-cell[data-deed-no="' + CSS.escape(pendingHighlightDeedNo) + '"]');
        pendingHighlightDeedNo = '';
        if (!target) {
            return;
        }
        var tr = target.closest('tr');
        if (!tr) {
            return;
        }
        tr.scrollIntoView({ behavior: 'smooth', block: 'center' });
        tr.classList.add('table-warning');
        setTimeout(function () { tr.classList.remove('table-warning'); }, 2500);
    }

    function mergeCellError(cell, message) {
        var td = cell.parentElement;
        var err = td.querySelector('.merge-cell-error');
        if (!err) {
            err = document.createElement('div');
            err.className = 'merge-cell-error text-danger small mt-1';
            td.appendChild(err);
        }
        err.textContent = message;
    }

    function extractErrorMessage(data, fallback) {
        if (data && data.errors && data.errors.merged_deed_no && data.errors.merged_deed_no[0]) {
            return data.errors.merged_deed_no[0];
        }
        return (data && data.message) || fallback;
    }

    // Delegated click handling for the dynamically-rendered Merged Deed No
    // cell: Edit swaps the badge for an inline input + Save/Cancel, Unmerge
    // deletes the merge outright (after confirmation). Delegation is needed
    // because renderRows() rebuilds the table's innerHTML on every check().
    resultRows.addEventListener('click', function (e) {
        var editBtn    = e.target.closest('.merge-edit-btn');
        var unmergeBtn = e.target.closest('.merge-unmerge-btn');
        var saveBtn    = e.target.closest('.merge-save-btn');
        var cancelBtn  = e.target.closest('.merge-cancel-btn');

        if (editBtn && !editBtn.disabled) {
            var cell = editBtn.closest('.merge-cell');
            var existingErr = cell.parentElement.querySelector('.merge-cell-error');
            if (existingErr) existingErr.remove();

            var deedNo = cell.getAttribute('data-deed-no');
            cell.innerHTML =
                '<input type="text" class="form-control form-control-sm merge-edit-input" value="' + esc(deedNo) + '" style="width:150px;">' +
                '<button type="button" class="btn btn-success btn-sm merge-save-btn"><i class="bi bi-check-lg"></i></button>' +
                '<button type="button" class="btn btn-secondary btn-sm merge-cancel-btn"><i class="bi bi-x-lg"></i></button>';
            cell.querySelector('.merge-edit-input').focus();
            return;
        }

        if (cancelBtn) {
            check(currentCode);
            return;
        }

        if (saveBtn) {
            var saveCell = saveBtn.closest('.merge-cell');
            var mergeId  = saveCell.getAttribute('data-merge-id');
            var input    = saveCell.querySelector('.merge-edit-input');
            var newDeedNo = input.value.trim();

            if (!newDeedNo) {
                mergeCellError(saveCell, 'Deed No is required.');
                return;
            }

            fetch(updateUrlTpl.replace('__ID__', mergeId), {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                    'X-CSRF-TOKEN': csrfToken,
                },
                body: JSON.stringify({ merged_deed_no: newDeedNo }),
                credentials: 'same-origin',
            })
                .then(function (res) { return res.json().then(function (data) { return { ok: res.ok, data: data }; }); })
                .then(function (r) {
                    if (r.ok && r.data.ok) {
                        check(currentCode);
                    } else {
                        mergeCellError(saveCell, extractErrorMessage(r.data, 'Could not update this Deed No.'));
                    }
                })
                .catch(function () { mergeCellError(saveCell, 'Something went wrong while saving.'); });
            return;
        }

        if (unmergeBtn && !unmergeBtn.disabled) {
            if (!confirm('Undo this merge? Its rows will become selectable again.')) {
                return;
            }
            var unmergeCell = unmergeBtn.closest('.merge-cell');
            var unmergeId   = unmergeCell.getAttribute('data-merge-id');

            fetch(destroyUrlTpl.replace('__ID__', unmergeId), {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'X-CSRF-TOKEN': csrfToken,
                },
                credentials: 'same-origin',
            })
                .then(function (res) { return res.json().then(function (data) { return { ok: res.ok, data: data }; }); })
                .then(function (r) {
                    if (r.ok && r.data.ok) {
                        check(currentCode);
                    } else {
                        alert(extractErrorMessage(r.data, 'Could not unmerge.'));
                    }
                })
                .catch(function () { alert('Something went wrong while unmerging.'); });
        }
    });

    function check(code) {
        if (!code) {
            resultWrapper.classList.add('d-none');
            return;
        }
        currentCode = code;
        mergeAraziCode.value = code;
        mergedDeedNo.value = '';
        fetch(checkUrl + '?arazi_code=' + encodeURIComponent(code), { headers: { 'Accept': 'application/json' } })
            .then(function (res) { return res.json(); })
            .then(function (data) {
                resultWrapper.classList.remove('d-none');
                resultCode.textContent = code;

                if (data.ok) {
                    resultAlert.className = 'alert alert-success';
                    resultAlert.textContent = 'Suggested rows are pre-checked and ready to merge — adjust the selection if needed.';
                    resultPartnerBadge.className = 'badge bg-success-subtle text-success border border-success-subtle';
                    resultPartnerBadge.textContent = 'Partner: ' + (data.partner ? data.partner.name : '—');
                    resultCardWrap.classList.remove('d-none');
                    renderRows(data.rows || []);
                } else if (data.manual) {
                    resultAlert.className = 'alert alert-info';
                    resultAlert.textContent = data.message;
                    resultPartnerBadge.className = 'badge bg-info-subtle text-info-emphasis border border-info-subtle';
                    resultPartnerBadge.textContent = 'Manual selection';
                    resultCardWrap.classList.remove('d-none');
                    renderRows(data.rows || []);
                } else if (data.allMerged) {
                    // Not an error — every row for this arazi is already
                    // folded into a merge, so there's simply nothing left to
                    // select. Styled calmly (not red) with the table still
                    // shown so the Merged Deed No column/edit actions work.
                    resultAlert.className = 'alert alert-secondary';
                    resultAlert.textContent = data.message;
                    resultPartnerBadge.className = 'badge bg-secondary-subtle text-secondary-emphasis border border-secondary-subtle';
                    resultPartnerBadge.textContent = 'All Merged';
                    resultCardWrap.classList.remove('d-none');
                    renderRows(data.rows || []);
                } else {
                    resultAlert.className = 'alert alert-danger';
                    resultAlert.textContent = data.message || "Can't merge due to not relevant records.";

                    if (data.rows && data.rows.length) {
                        resultPartnerBadge.className = 'badge bg-danger-subtle text-danger border border-danger-subtle';
                        resultPartnerBadge.textContent = 'Not mergeable';
                        resultCardWrap.classList.remove('d-none');
                        renderRows(data.rows);
                    } else {
                        resultCardWrap.classList.add('d-none');
                    }
                }

                highlightPendingDeedNo();
            })
            .catch(function () {
                resultWrapper.classList.remove('d-none');
                resultAlert.className = 'alert alert-danger';
                resultAlert.textContent = 'Something went wrong while checking this arazi.';
                resultCardWrap.classList.add('d-none');
            });
    }

    mergedDeedNo.addEventListener('input', updateSubmitState);

    // Resets the "Search Merged Deed No" dropdown back to its placeholder.
    // Triggering "change.select2" (namespaced) only notifies Select2 itself
    // so it redraws its display text — our own plain "change" listener below
    // is bound without a namespace and is intentionally NOT re-fired here,
    // otherwise this would immediately loop back into onMergedDeedNoSearchChange.
    function resetMergedDeedNoSearch() {
        mergedDeedNoSearch.value = '';
        if (window.jQuery && jQuery.fn.select2) {
            jQuery(mergedDeedNoSearch).val('').trigger('change.select2');
        }
    }

    function onAraziChange() {
        // Skip the reset when this change was itself triggered by picking a
        // Merged Deed No search result (that flow already set the search box
        // to the value the user just chose — resetting it would erase it).
        if (!suppressMergedDeedNoReset) {
            resetMergedDeedNoSearch();
        }
        suppressMergedDeedNoReset = false;
        check(araziSelect.value);
    }

    // Plain change listener covers a native <select>. Select2 (initialized
    // globally on this element via the "js-select2" class) fires its change
    // notification through jQuery's own event system, not a real DOM event,
    // so addEventListener alone never sees it — bind through jQuery too.
    araziSelect.addEventListener('change', onAraziChange);
    if (window.jQuery && jQuery.fn.select2) {
        jQuery(araziSelect).on('change', onAraziChange);
    }

    // Searching by Merged Deed No just re-selects the arazi that merge
    // belongs to (reusing the exact same load path as picking it directly),
    // then flashes/scrolls to that merge's row once the table renders.
    function onMergedDeedNoSearchChange() {
        var opt = mergedDeedNoSearch.options[mergedDeedNoSearch.selectedIndex];
        var araziCode = opt ? opt.getAttribute('data-arazi-code') : '';
        if (!araziCode) {
            return;
        }
        pendingHighlightDeedNo = mergedDeedNoSearch.value;
        suppressMergedDeedNoReset = true;
        if (window.jQuery && jQuery.fn.select2) {
            jQuery(araziSelect).val(araziCode).trigger('change');
        } else {
            araziSelect.value = araziCode;
            suppressMergedDeedNoReset = false;
            check(araziCode);
        }
    }

    mergedDeedNoSearch.addEventListener('change', onMergedDeedNoSearchChange);
    if (window.jQuery && jQuery.fn.select2) {
        jQuery(mergedDeedNoSearch).on('change', onMergedDeedNoSearchChange);
    }

    if (araziSelect.value) {
        check(araziSelect.value);
    }
})();
</script>
@endpush
