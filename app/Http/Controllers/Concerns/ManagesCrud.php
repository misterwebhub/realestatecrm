<?php

namespace App\Http\Controllers\Concerns;

use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;
use Illuminate\Support\Str;

trait ManagesCrud
{
    abstract protected function resourceTitle(): string;

    abstract protected function resourceModel(): string;

    abstract protected function resourceRouteName(): string;

    abstract protected function resourceColumns(): array;

    abstract protected function resourceFields(?Model $item = null): array;

    abstract protected function resourceRules(?Model $item = null): array;

    protected function resourceQuery()
    {
        $modelClass = $this->resourceModel();

        return $modelClass::query()->latest();
    }

    protected function resourceRow(Model $item): array
    {
        return [];
    }

    protected function resourcePrepareData(array $validated, Request $request, ?Model $item = null): array
    {
        return $validated;
    }

    protected function resourceAfterSave(Model $item, Request $request, array $validated, ?Model $original = null): void
    {
    }

    /**
     * Override in controllers that support CSV download from the index page (e.g. payment lists).
     */
    protected function allowsCsvExport(): bool
    {
        return false;
    }

    /**
     * Override (e.g. PaymentController) to apply filters matching the index table.
     */
    protected function recordsForCsvExport(Request $request): Builder
    {
        return $this->resourceQuery();
    }

    public function exportCsv(Request $request)
    {
        if (! $this->allowsCsvExport()) {
            abort(404);
        }

        $records = $this->recordsForCsvExport($request)->get();
        $columns = $this->resourceColumns();
        $filename = Str::slug($this->resourceTitle()).'-'.now()->format('Y-m-d-His').'.csv';

        return response()->streamDownload(function () use ($records, $columns) {
            $out = fopen('php://output', 'w');
            fprintf($out, chr(0xEF).chr(0xBB).chr(0xBF));
            fputcsv($out, $columns);
            foreach ($records as $record) {
                $row = $this->resourceRow($record);
                $cells = array_map(function ($cell) {
                    if ($cell === null) {
                        return '';
                    }
                    if (is_int($cell) || is_float($cell)) {
                        return $cell;
                    }

                    return preg_replace('/\s+/', ' ', trim(strip_tags((string) $cell)));
                }, $row['cells'] ?? []);
                fputcsv($out, $cells);
            }
            fclose($out);
        }, $filename, [
            'Content-Type' => 'text/csv; charset=UTF-8',
        ]);
    }

    public function index()
    {
        $records = $this->resourceQuery()->get();
        $routeName = $this->resourceRouteName();

        $rows = $records->map(function (Model $record) use ($routeName) {
            return array_merge($this->resourceRow($record), [
                'edit_url' => route($routeName . '.edit', $record),
                'delete_url' => route($routeName . '.destroy', $record),
            ]);
        })->all();

        return view('crud.index', [
            'title' => $this->resourceTitle(),
            'columns' => $this->resourceColumns(),
            'rows' => $rows,
            'createUrl' => route($routeName . '.create'),
            'exportCsvUrl' => $this->allowsCsvExport() ? route($routeName.'.export.csv') : null,
            'permModule' => $this->resourcePermModule(),
        ]);
    }

    /**
     * Permission module key for this resource (used to gate create/edit/delete
     * buttons in the shared CRUD views). Defaults to the route name with dashes
     * converted to underscores; a few resources need an explicit mapping.
     */
    protected function resourcePermModule(): ?string
    {
        $map = [
            'customer-bonds'         => 'customer_bonds',
            'customer-bond-payments' => 'customer_payments',
            'customer-bond-cheques'  => 'cheques',
            'kisan-payment'          => 'kisan_payments',
        ];
        $route = $this->resourceRouteName();

        return $map[$route] ?? str_replace('-', '_', $route);
    }

    public function create()
    {
        $modelClass = $this->resourceModel();

        return view('crud.form', [
            'title' => 'Create ' . $this->resourceTitle(),
            'action' => route($this->resourceRouteName() . '.store'),
            'method' => 'POST',
            'fields' => $this->resourceFields(),
            'item' => new $modelClass(),
        ]);
    }

    public function store(Request $request)
    {
        $validated = $request->validate($this->resourceRules());
        $modelClass = $this->resourceModel();
        $payload = $this->resourcePrepareData($validated, $request);
        $item = $modelClass::create($payload);
        $this->resourceAfterSave($item, $request, $validated);

        return redirect()
            ->route($this->resourceRouteName() . '.index')
            ->with('success', $this->resourceTitle() . ' created successfully.');
    }

    public function edit($id)
    {
        $modelClass = $this->resourceModel();
        $item = $modelClass::findOrFail($id);

        return view('crud.form', [
            'title' => 'Edit ' . $this->resourceTitle(),
            'action' => route($this->resourceRouteName() . '.update', $item),
            'method' => 'PUT',
            'fields' => $this->resourceFields($item),
            'item' => $item,
        ]);
    }

    public function update(Request $request, $id)
    {
        $modelClass = $this->resourceModel();
        $item = $modelClass::findOrFail($id);
        $validated = $request->validate($this->resourceRules($item));
        $payload = $this->resourcePrepareData($validated, $request, $item);
        $item->update($payload);
        $this->resourceAfterSave($item, $request, $validated, $item);

        return redirect()
            ->route($this->resourceRouteName() . '.index')
            ->with('success', $this->resourceTitle() . ' updated successfully.');
    }

    public function destroy($id)
    {
        $modelClass = $this->resourceModel();
        $item = $modelClass::findOrFail($id);
        $item->delete();

        return redirect()
            ->route($this->resourceRouteName() . '.index')
            ->with('success', $this->resourceTitle() . ' deleted successfully.');
    }
}
