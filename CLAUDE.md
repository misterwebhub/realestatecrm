# Project Conventions — Real Estate CRM

## Plot identification: always use the `title` field, never `plot_number`

Whenever a plot is displayed, labelled, searched, matched, or exported anywhere
in the app, use the plot's **`title`** column. **Do not use `plot_number`**
anywhere (labels, dropdown options, CSV import/export columns, lookups).

### Rules

1. **Display/labels** — show `plot->title` in tables, badges, dropdowns.
2. **Lookups/matching** — resolve a plot by `title` (scoped to its `arazi_code`),
   e.g. `Plot::where('arazi_code', $code)->where('title', $title)`.
3. **CSV import/export** — the plot column is `plot_title` (value = `title`),
   never `plot_number`.
4. Internally a plot is still referenced by its `id` (FK `plot_id`); `title` is
   the human-facing identifier, the same way `legacy_arazi_code` is for arazi.

## Arazi identification: always use the arazi CODE, never the arazi ID

Whenever "arazi" is referenced anywhere in the app, use the **legacy arazi code**
(`legacy_arazi_code`), **not** the internal database `id`.

### Rules

1. **Filters & query params** — every arazi filter must use `arazi_code`
   (the legacy code) as the option value and the query-string key. Never expose
   or filter by the internal `id`.

2. **Any table/relation linked to arazi** must join and display via the arazi
   **code**, not the id. Foreign-key columns that reference an arazi should be
   resolved to and shown as the legacy code.
   - `KisanRegistry.arazi()` = `belongsTo(Arazi::class, 'arazi_code', 'legacy_arazi_code')`.

3. **Routes** — prefer code-based endpoints for arazi lookups:
   - `arazis.plots-by-code`  → `arazi-no/{code}/plots`
   - `arazis.details-by-code` → `arazi-no/{code}/details`
   Use these instead of the id-bound `arazis.plots` / `arazis.details`.

4. **Display** — show the arazi code (e.g. via `araziNoCode()`) in tables,
   badges, dropdowns, and drill-down links.

### Known pitfall: numeric codes become integer keys

When grouping a collection by the code (`groupBy('legacy_arazi_code')` /
`groupBy('arazi_code')`), numeric codes become **integer** array keys, while a
query param arrives as a **string**. A strict comparison then silently skips all
rows. **Always cast both sides to string** when comparing:

```php
if ($araziCode !== '' && (string) $araziCode !== (string) $code) {
    continue;
}
```

And in Blade `@selected`:

```blade
<option value="{{ $c }}" @selected((string)$araziCode === (string)$c)>{{ $c }}</option>
```
