<?php

namespace App\Http\Controllers;

use App\Models\Arazi;
use App\Models\DeedMapping;
use App\Models\DeedMerging;
use App\Models\DeedMergingItem;
use App\Models\Registry;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\DB;
use Illuminate\Validation\Rule;
use Illuminate\Validation\ValidationException;

class DeedMergeController extends Controller
{
    /**
     * Deed Merging: pick an arazi (by legacy code) and pull every one of its
     * kisan rows' deed mappings. Every deed-mapped row that isn't already
     * merged gets a checkbox — the "suggested" group (the largest set of
     * rows sharing one partner) is pre-checked, but the user can freely
     * check/uncheck any row before merging. On submit the user also names a
     * brand-new merged Deed No that the selected rows are consolidated into.
     */
    public function index(Request $request)
    {
        $arazis = Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '!=', '')
            ->orderBy('legacy_arazi_code')
            ->get(['id', 'legacy_arazi_code', 'location'])
            ->unique('legacy_arazi_code')
            ->values();

        // Powers a second, searchable "Merged Deed No" dropdown so a merge
        // can be jumped to directly without knowing its arazi code first —
        // picking one just re-selects the matching arazi above.
        $merges = DeedMerging::whereNotNull('merged_deed_no')
            ->where('merged_deed_no', '!=', '')
            ->orderBy('merged_deed_no')
            ->get(['id', 'arazi_code', 'merged_deed_no']);

        return view('deed_merges.index', [
            'title'        => 'Deed Merging',
            'arazis'       => $arazis,
            'merges'       => $merges,
            'selectedCode' => trim((string) $request->query('arazi_code', '')),
        ]);
    }

    /**
     * AJAX: build the row list for the given arazi code, flagging which rows
     * are selectable (deed-mapped, not yet merged), which are already
     * merged, and which are "suggested" (the auto-detected same-partner
     * group) so the UI can pre-check them.
     */
    public function check(Request $request)
    {
        $code = trim((string) $request->query('arazi_code', ''));

        if ($code === '') {
            return response()->json(['ok' => false, 'message' => 'Select an arazi.']);
        }

        $data = $this->buildRows($code);

        if ($data === null) {
            return response()->json(['ok' => false, 'message' => 'Arazi not found.']);
        }

        [$rows] = $data;

        $selectableRows = $rows->filter(fn ($r) => $r['selectable'])->values();
        $suggestedRows  = $selectableRows->filter(fn ($r) => $r['suggested'])->values();

        if ($selectableRows->isEmpty()) {
            // Nothing left to select isn't necessarily a problem — if every
            // row is already folded into a merge, that's a normal, settled
            // state (not an error), so it's flagged separately from the
            // genuine "no relevant records" case for the UI to style calmly.
            if ($rows->contains(fn ($r) => $r['merged'])) {
                return response()->json([
                    'ok'        => false,
                    'allMerged' => true,
                    'message'   => 'All eligible rows for this arazi have already been merged.',
                    'rows'      => $rows,
                ]);
            }

            return response()->json([
                'ok'      => false,
                'message' => "Can't merge due to not relevant records.",
                'rows'    => $rows,
            ]);
        }

        if ($suggestedRows->count() >= 2) {
            return response()->json([
                'ok'      => true,
                'partner' => ['id' => $suggestedRows->first()['partner_id'], 'name' => $suggestedRows->first()['partner_name']],
                'rows'    => $rows,
            ]);
        }

        // Rows exist that *could* be merged (deed-mapped, not merged yet) but
        // none automatically share a partner in a group of 2+ — still show
        // the table so the user can hand-pick a same-partner combination.
        return response()->json([
            'ok'      => false,
            'manual'  => true,
            'message' => 'No rows automatically share a partner. You can still manually select rows to merge — they must all share the same partner.',
            'rows'    => $rows,
        ]);
    }

    /**
     * Persist a merge: the user's checked arazi_ids for the given arazi code
     * plus the new merged Deed No. Re-validated server-side against the same
     * "deed mapped, not already merged" eligibility used to render the
     * checkboxes, and requires every selected row to share one partner — a
     * tampered selection can never sneak in an unmapped/already-merged row
     * or mix partners.
     */
    public function store(Request $request)
    {
        $validated = $request->validate([
            'arazi_code'     => ['required', 'string', 'exists:arazis,legacy_arazi_code'],
            'merged_deed_no' => [
                'required', 'string', 'max:100',
                Rule::unique('deed_mergings', 'merged_deed_no'),
            ],
            'arazi_ids'      => ['required', 'array', 'min:1'],
            'arazi_ids.*'    => ['integer'],
        ], [
            'merged_deed_no.unique' => 'This Deed No is already used by another merge.',
        ]);

        $mergedDeedNo = trim($validated['merged_deed_no']);

        // Deed No must be unique across deed_mappings too — it's the same
        // "Deed No" identifier space, just consolidated onto a merge record.
        if (DeedMapping::where('deed_no', $mergedDeedNo)->exists()) {
            throw ValidationException::withMessages([
                'merged_deed_no' => 'This Deed No is already mapped to an existing row.',
            ]);
        }

        $code = $validated['arazi_code'];
        $selectedIds = collect($validated['arazi_ids'])->map(fn ($v) => (int) $v)->unique()->values();

        $data = $this->buildRows($code);
        if ($data === null) {
            throw ValidationException::withMessages(['arazi_code' => 'Arazi not found.']);
        }

        [$rows] = $data;

        $eligible = $rows->filter(fn ($r) => $r['selectable'])->keyBy('arazi_id');

        $invalid = $selectedIds->filter(fn ($id) => ! $eligible->has($id));
        if ($invalid->isNotEmpty() || $selectedIds->count() < 2) {
            throw ValidationException::withMessages([
                'arazi_ids' => "Can't merge due to not relevant records.",
            ]);
        }

        $selectedRows = $eligible->only($selectedIds->all())->values();

        $partnerIds = $selectedRows->pluck('partner_id')->unique();
        if ($partnerIds->count() !== 1) {
            throw ValidationException::withMessages([
                'arazi_ids' => 'Selected rows must all share the same partner to merge.',
            ]);
        }

        $merging = DB::transaction(function () use ($code, $mergedDeedNo, $partnerIds, $selectedRows) {
            $merging = DeedMerging::create([
                'arazi_code'     => $code,
                'merged_deed_no' => $mergedDeedNo,
                'partner_id'     => $partnerIds->first(),
                'created_by'     => Auth::id(),
            ]);

            foreach ($selectedRows as $row) {
                DeedMergingItem::create([
                    'deed_merging_id' => $merging->id,
                    'arazi_id'        => $row['arazi_id'],
                    'deed_no'         => $row['deed_no'],
                ]);
            }

            return $merging;
        });

        return redirect()
            ->route('deed-merges.index', ['arazi_code' => $code])
            ->with('success', 'Merged ' . $selectedRows->count() . ' row(s) for arazi ' . $code . ' into new Deed No ' . $mergedDeedNo . ' under partner ' . $selectedRows->first()['partner_name'] . '.');
    }

    /**
     * Rename an existing merge's Deed No. Blocked if that Deed No is already
     * referenced by a Customer Registry row — once a merged Deed No has been
     * used to register a customer, it's locked and can no longer be renamed.
     */
    public function update(Request $request, DeedMerging $deedMerging)
    {
        if ($this->isLocked($deedMerging)) {
            throw ValidationException::withMessages([
                'merged_deed_no' => 'This Deed No is used in Customer Registry and can no longer be edited.',
            ]);
        }

        $validated = $request->validate([
            'merged_deed_no' => [
                'required', 'string', 'max:100',
                Rule::unique('deed_mergings', 'merged_deed_no')->ignore($deedMerging->id),
            ],
        ], [
            'merged_deed_no.unique' => 'This Deed No is already used by another merge.',
        ]);

        $newDeedNo = trim($validated['merged_deed_no']);

        if ($newDeedNo !== $deedMerging->merged_deed_no && DeedMapping::where('deed_no', $newDeedNo)->exists()) {
            throw ValidationException::withMessages([
                'merged_deed_no' => 'This Deed No is already mapped to an existing row.',
            ]);
        }

        $deedMerging->update(['merged_deed_no' => $newDeedNo]);

        return response()->json(['ok' => true, 'message' => 'Merged Deed No updated to ' . $newDeedNo . '.']);
    }

    /**
     * Undo a merge: deletes the merge and its items, reverting the member
     * arazi rows back to selectable/unmerged. Blocked if the merge's Deed No
     * is already referenced by a Customer Registry row.
     */
    public function destroy(DeedMerging $deedMerging)
    {
        if ($this->isLocked($deedMerging)) {
            throw ValidationException::withMessages([
                'merged_deed_no' => 'This Deed No is used in Customer Registry and can no longer be unmerged.',
            ]);
        }

        $code = $deedMerging->arazi_code;

        DB::transaction(function () use ($deedMerging) {
            $deedMerging->items()->delete();
            $deedMerging->delete();
        });

        return response()->json(['ok' => true, 'message' => 'Merge undone for arazi ' . $code . '. Rows are selectable again.']);
    }

    /**
     * A merge is "locked" once its merged Deed No has been used on a
     * Customer Registry row — Registry.deed_no is a plain string column (no
     * FK), matched purely by value, so any match means it's in live use.
     */
    private function isLocked(DeedMerging $deedMerging): bool
    {
        return Registry::where('deed_no', $deedMerging->merged_deed_no)->exists();
    }

    /**
     * Shared row-builder for both check() (read) and store() (re-validate).
     * Returns [rows collection, dominantPartnerId] or null if the code
     * doesn't resolve to any arazi rows.
     */
    private function buildRows(string $code): ?array
    {
        $arazis = Arazi::where('legacy_arazi_code', $code)
            ->with(['kisan', 'deedMapping.partner', 'deedMergingItem.deedMerging'])
            ->orderBy('id')
            ->get();

        if ($arazis->isEmpty()) {
            return null;
        }

        $base = $arazis->map(fn (Arazi $arazi) => [
            'arazi_id'       => $arazi->id,
            'kisan_name'     => $arazi->kisan?->name ?? '—',
            'deed_no'        => $arazi->deedMapping?->deed_no,
            'partner_id'     => $arazi->deedMapping?->partner_id,
            'partner_name'   => $arazi->deedMapping?->partner?->name,
            'merged'         => (bool) $arazi->deedMergingItem,
            'merge_id'       => $arazi->deedMergingItem?->deed_merging_id,
            'merged_deed_no' => $arazi->deedMergingItem?->deedMerging?->merged_deed_no,
        ]);

        // A row is selectable (checkbox shown) once it's deed-mapped and not
        // already folded into a merge — regardless of what its partner group
        // looks like, so the user can hand-pick any combination.
        $base = $base->map(function ($r) {
            $r['selectable'] = ! empty($r['deed_no']) && ! empty($r['partner_id']) && ! $r['merged'];

            return $r;
        });

        // The "suggested" group is the largest set of still-selectable rows
        // that already share the exact same partner (min size 2 — a lone
        // row has nothing to merge with) — pre-checked as a convenience.
        // Ties broken by lowest partner_id for determinism.
        $selectableGroups = $base
            ->filter(fn ($r) => $r['selectable'])
            ->groupBy('partner_id')
            ->filter(fn ($g) => $g->count() >= 2);

        $dominantPartnerId = null;
        if ($selectableGroups->isNotEmpty()) {
            $maxCount = $selectableGroups->max(fn ($g) => $g->count());
            $dominantPartnerId = $selectableGroups
                ->filter(fn ($g) => $g->count() === $maxCount)
                ->keys()
                ->sort()
                ->first();
        }

        $rows = $base->map(function ($r) use ($dominantPartnerId) {
            $r['suggested'] = $r['selectable']
                && $dominantPartnerId !== null
                && (string) $r['partner_id'] === (string) $dominantPartnerId;

            return $r;
        })->values();

        // Rows belonging to the same merge must sit contiguously so the
        // "Merged Deed No" column can render a proper rowspan — group by
        // merge (or treat each unmerged row as its own singleton group)
        // while keeping each group's relative order of first appearance.
        $rows = $rows
            ->groupBy(fn ($r) => $r['merge_id'] ? 'm' . $r['merge_id'] : 'r' . $r['arazi_id'])
            ->flatMap(fn ($group) => $group)
            ->values();

        // A merge's Deed No is locked (can't be edited/unmerged) once it's
        // been used on a Customer Registry row. Batch-check once per unique
        // merged Deed No rather than per row.
        $mergedDeedNos = $rows->pluck('merged_deed_no')->filter()->unique()->values();
        $lockedDeedNos = $mergedDeedNos->isEmpty()
            ? collect()
            : Registry::whereIn('deed_no', $mergedDeedNos)->pluck('deed_no')->unique();

        $mergeGroupSizes = $rows->filter(fn ($r) => $r['merge_id'])->countBy('merge_id');

        $seenMergeIds = [];
        $rows = $rows->map(function ($r) use ($lockedDeedNos, $mergeGroupSizes, &$seenMergeIds) {
            if ($r['merge_id']) {
                $r['is_merge_head']    = empty($seenMergeIds[$r['merge_id']]);
                $seenMergeIds[$r['merge_id']] = true;
                $r['merge_group_size'] = $mergeGroupSizes[$r['merge_id']] ?? 1;
                $r['merge_locked']     = $lockedDeedNos->contains($r['merged_deed_no']);
            } else {
                $r['is_merge_head']    = true;
                $r['merge_group_size'] = 1;
                $r['merge_locked']     = false;
            }

            return $r;
        })->values();

        return [$rows, $dominantPartnerId];
    }
}
