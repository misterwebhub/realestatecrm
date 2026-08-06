<?php

namespace App\Http\Controllers;

use App\Models\Arazi;
use App\Models\DeedMapping;
use App\Models\Kisan;
use App\Models\Partner;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\DB;
use Illuminate\Validation\Rule;
use Illuminate\Validation\ValidationException;

class DeedMappingController extends Controller
{
    /**
     * Listing: every arazi code with how many of its kisan rows are mapped,
     * plus the mapped rows themselves (kisan, deed no, partner) so it reads
     * the same way the mapping form does. Supports searching by arazi code,
     * kisan, deed no, and partner — each rendered as a select2 dropdown of
     * actual values (exact match) rather than free-text.
     *
     * The Arazi filter is a "jump to this code" lookup (per CLAUDE.md, arazi
     * is always identified by its legacy code): picking one always shows
     * that arazi's block — mapped or not — same as browsing the unfiltered
     * list. Kisan/Deed No/Partner are substantive search filters: when any
     * of those is active (with or without an arazi code), only arazi codes
     * with at least one matching mapped row are shown.
     */
    public function index(Request $request)
    {
        $araziCode = trim((string) $request->query('arazi_code', ''));
        $kisanId   = trim((string) $request->query('kisan_id', ''));
        $deedNo    = trim((string) $request->query('deed_no', ''));
        $partnerId = trim((string) $request->query('partner_id', ''));
        $hasSearchFilter = $kisanId !== '' || $deedNo !== '' || $partnerId !== '';
        $hasFilter        = $araziCode !== '' || $hasSearchFilter;

        $mappingsQuery = DeedMapping::with(['arazi.kisan', 'partner']);

        if ($araziCode !== '') {
            $mappingsQuery->whereHas('arazi', fn ($q) => $q->where('legacy_arazi_code', $araziCode));
        }
        if ($kisanId !== '') {
            $mappingsQuery->whereHas('arazi', fn ($q) => $q->where('kisan_id', $kisanId));
        }
        if ($deedNo !== '') {
            $mappingsQuery->where('deed_no', $deedNo);
        }
        if ($partnerId !== '') {
            $mappingsQuery->where('partner_id', $partnerId);
        }

        $mappings = $mappingsQuery->get();
        $groups   = $mappings->groupBy(fn ($m) => $m->arazi?->legacy_arazi_code);

        $araziCodes = Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '!=', '')
            ->orderBy('legacy_arazi_code')
            ->pluck('legacy_arazi_code')
            ->unique()
            ->values();

        if ($araziCode !== '') {
            // Arazi code selected: always show that one code's block, whether
            // or not it (or its matching rows under other filters) is mapped.
            // An unrecognized/tampered code yields no block at all.
            $codes = $araziCodes->contains(fn ($c) => (string) $c === (string) $araziCode)
                ? collect([$araziCode])
                : collect();
        } elseif ($hasSearchFilter) {
            $codes = $groups->keys()->filter()->sort()->values();
        } else {
            $codes = $araziCodes;
        }

        $totalsByCode = Arazi::whereNotNull('legacy_arazi_code')
            ->select('legacy_arazi_code', DB::raw('count(*) as total'))
            ->groupBy('legacy_arazi_code')
            ->pluck('total', 'legacy_arazi_code');

        $summary = $codes->map(function ($code) use ($groups, $totalsByCode) {
            $rows = ($groups->get($code) ?? collect())->sortBy(fn ($r) => optional($r->arazi)->id)->values();

            return [
                'code'   => $code,
                'total'  => (int) ($totalsByCode[$code] ?? 0),
                'mapped' => $rows->count(),
                'rows'   => $rows,
            ];
        });

        return view('deed_mappings.index', [
            'title'      => 'Deed Mapping',
            'summary'    => $summary,
            'hasFilter'  => $hasFilter,
            'araziCodes' => $araziCodes,
            'kisans'     => Kisan::orderBy('name')->get(['id', 'name']),
            'deedNos'    => DeedMapping::whereNotNull('deed_no')->where('deed_no', '!=', '')->orderBy('deed_no')->pluck('deed_no')->unique()->values(),
            'partners'   => Partner::orderBy('name')->get(['id', 'name']),
            'filters'    => [
                'arazi_code' => $araziCode,
                'kisan_id'   => $kisanId,
                'deed_no'    => $deedNo,
                'partner_id' => $partnerId,
            ],
        ]);
    }

    /**
     * Shared create/edit screen: pick an arazi code, its kisan rows load
     * below, each row gets a Deed No + Partner, Save posts them all at once.
     * Passing $araziCode pre-selects and pre-loads that code's rows (edit).
     */
    public function map(?string $araziCode = null)
    {
        $arazis = Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '!=', '')
            ->orderBy('legacy_arazi_code')
            ->get(['id', 'legacy_arazi_code', 'location'])
            ->unique('legacy_arazi_code')
            ->values();

        $partners = Partner::orderBy('name')->get(['id', 'name']);

        return view('deed_mappings.map', [
            'title'        => $araziCode ? 'Edit Deed Mapping — ' . $araziCode : 'Deed Mapping',
            'arazis'       => $arazis,
            'partners'     => $partners,
            'selectedCode' => $araziCode,
            'initialRows'  => $araziCode ? $this->rowsPayload($araziCode) : [],
        ]);
    }

    /**
     * AJAX: kisan rows (+ any existing deed mapping) for the selected arazi code.
     */
    public function rows(Request $request)
    {
        $code = trim((string) $request->query('arazi_code', ''));

        if ($code === '') {
            return response()->json(['rows' => []]);
        }

        return response()->json(['rows' => $this->rowsPayload($code)]);
    }

    public function store(Request $request)
    {
        $rows = $request->input('rows', []);

        $rules = [
            'arazi_code'        => ['required', 'string', 'exists:arazis,legacy_arazi_code'],
            'rows'              => ['required', 'array', 'min:1'],
            'rows.*.arazi_id'   => ['required', 'integer', 'exists:arazis,id'],
            'rows.*.partner_id' => ['nullable', 'integer', 'exists:partners,id'],
        ];

        // Deed No must be globally unique. Build the unique rule per row so
        // each one ignores its *own* existing mapping (identified by the
        // row's arazi_id) — otherwise re-saving a row unchanged would trip
        // "already taken" against itself.
        foreach ($rows as $i => $row) {
            $deedNo = trim((string) ($row['deed_no'] ?? ''));
            if ($deedNo === '') {
                $rules["rows.$i.deed_no"] = ['nullable', 'string', 'max:100'];
                continue;
            }

            $uniqueRule = Rule::unique('deed_mappings', 'deed_no');
            $existingId = ! empty($row['arazi_id'])
                ? DeedMapping::where('arazi_id', $row['arazi_id'])->value('id')
                : null;
            if ($existingId) {
                $uniqueRule = $uniqueRule->ignore($existingId);
            }

            $rules["rows.$i.deed_no"] = ['string', 'max:100', $uniqueRule];
        }

        $validated = $request->validate($rules, [
            'rows.*.deed_no.unique' => 'This Deed No is already mapped to another row.',
        ]);

        // Deed No must also be unique *within this submission* — two rows
        // can't both claim the same brand-new deed no in one save.
        $deedNos = collect($validated['rows'])
            ->map(fn ($r) => trim((string) ($r['deed_no'] ?? '')))
            ->filter(fn ($v) => $v !== '');
        $dupes = $deedNos->duplicates()->unique();
        if ($dupes->isNotEmpty()) {
            throw ValidationException::withMessages([
                'rows' => 'Duplicate Deed No in this submission: ' . $dupes->implode(', '),
            ]);
        }

        // Deed No and Partner are required together per row — either both
        // filled in (to save/update the mapping) or both left blank (to
        // skip / clear it). Enforced here rather than in a static rule
        // array since it's a "both-or-neither" cross-field check.
        foreach ($validated['rows'] as $i => $row) {
            $hasDeed    = trim((string) ($row['deed_no'] ?? '')) !== '';
            $hasPartner = ! empty($row['partner_id']);

            if ($hasDeed !== $hasPartner) {
                throw ValidationException::withMessages([
                    "rows.$i.deed_no" => 'Enter both Deed No and Partner for this row (or leave both blank).',
                ]);
            }
        }

        // Only allow arazi rows that actually belong to the submitted code —
        // guards against a tampered arazi_id pointing at a different arazi.
        $validIds = Arazi::where('legacy_arazi_code', $validated['arazi_code'])->pluck('id')->all();

        DB::transaction(function () use ($validated, $validIds) {
            foreach ($validated['rows'] as $row) {
                if (! in_array((int) $row['arazi_id'], $validIds, true)) {
                    continue;
                }

                $hasDeed = trim((string) ($row['deed_no'] ?? '')) !== '';

                if ($hasDeed) {
                    DeedMapping::updateOrCreate(
                        ['arazi_id' => $row['arazi_id']],
                        [
                            'deed_no'    => trim($row['deed_no']),
                            'partner_id' => $row['partner_id'],
                            'created_by' => Auth::id(),
                        ]
                    );
                } else {
                    DeedMapping::where('arazi_id', $row['arazi_id'])->delete();
                }
            }
        });

        return redirect()
            ->route('deed-mappings.index')
            ->with('success', 'Deed mapping saved for arazi ' . $validated['arazi_code'] . '.');
    }

    /**
     * Kisan rows for an arazi code, each carrying its existing deed mapping
     * (if any) so the form pre-fills on edit.
     */
    private function rowsPayload(string $code): array
    {
        $arazis = Arazi::where('legacy_arazi_code', $code)
            ->with(['kisan', 'deedMapping'])
            ->orderBy('id')
            ->get();

        return $arazis->map(fn (Arazi $arazi) => [
            'arazi_id'     => $arazi->id,
            'kisan_name'   => $arazi->kisan?->name ?? '—',
            'kisan_mobile' => $arazi->kisan?->mobile ?? '',
            'deed_no'      => $arazi->deedMapping?->deed_no ?? '',
            'partner_id'   => $arazi->deedMapping?->partner_id,
        ])->values()->all();
    }
}
