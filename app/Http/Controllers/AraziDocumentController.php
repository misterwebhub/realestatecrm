<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Arazi;
use App\Models\AraziDocument;
use App\Models\Kisan;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Storage;

class AraziDocumentController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Arazi Document';
    }

    protected function resourceModel(): string
    {
        return AraziDocument::class;
    }

    protected function resourceRouteName(): string
    {
        return 'arazi-documents';
    }

    protected function resourceColumns(): array
    {
        return ['Arazi', 'Document Name', 'File', 'Type', 'Size KB'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            [
                'name' => 'arazi_id',
                'label' => 'Arazi',
                'type' => 'select',
                'options' => Arazi::orderBy('legacy_arazi_code')
                    ->get()
                    ->mapWithKeys(function (Arazi $arazi) {
                        return [$arazi->id => $arazi->araziNoCode()];
                    })
                    ->all(),
                'value' => $item?->arazi_id,
            ],
            ['name' => 'document_name', 'label' => 'Document Name', 'type' => 'text', 'value' => $item?->document_name ?? request('document_name', 'Arazi Registry')],
            ['name' => 'document_file', 'label' => 'File', 'type' => 'file', 'accept' => '.pdf,image/*'],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'arazi_id' => ['required', 'exists:arazis,id'],
            'document_name' => ['required', 'string', 'max:150'],
            'document_file' => [$item ? 'nullable' : 'required', 'file', 'mimes:pdf,jpg,jpeg,png,webp', 'max:10240'],
        ];
    }

    public function index(Request $request)
    {
        $araziNumber = trim((string) $request->query('arazi_number', ''));
        $kisanId = $request->query('kisan_id');

        $documents = AraziDocument::with(['arazi.kisan'])
            ->when($araziNumber !== '', function ($query) use ($araziNumber) {
                $query->whereHas('arazi', function ($araziQuery) use ($araziNumber) {
                    $araziQuery
                        ->where('legacy_arazi_code', 'like', '%' . $araziNumber . '%')
                        ->orWhere('plot_number', 'like', '%' . $araziNumber . '%');
                });
            })
            ->when($kisanId, function ($query) use ($kisanId) {
                $query->whereHas('arazi', fn ($araziQuery) => $araziQuery->where('kisan_id', $kisanId));
            })
            ->latest()
            ->get();

        return view('arazi_documents.index', [
            'title' => 'Arazi Registry Upload',
            'documents' => $documents,
            'kisans' => Kisan::orderBy('name')->pluck('name', 'id')->all(),
            'filters' => [
                'arazi_number' => $araziNumber,
                'kisan_id' => $kisanId,
            ],
            'createUrl' => route('arazi-documents.create', ['document_name' => 'Arazi Registry']),
        ]);
    }

    protected function resourceQuery()
    {
        return AraziDocument::with('arazi')->latest();
    }

    protected function resourceRow(Model $item): array
    {
        /** @var AraziDocument $item */
        return [
            'cells' => [
                $item->arazi?->legacy_arazi_code ?: ($item->arazi?->plot_number ?? '-'),
                $item->document_name,
                basename($item->file_path),
                $item->mime_type ?? '-',
                $item->file_size ? number_format($item->file_size / 1024, 2) : '-',
            ],
        ];
    }

    protected function resourcePrepareData(array $validated, Request $request, ?Model $item = null): array
    {
        $payload = $validated;

        if ($request->hasFile('document_file')) {
            $file = $request->file('document_file');
            $path = $file->store('arazi-documents', 'public');

            $payload['file_path'] = $path;
            $payload['mime_type'] = $file->getClientMimeType();
            $payload['file_size'] = $file->getSize();
            $payload['uploaded_at'] = now();
        }

        unset($payload['document_file']);

        return $payload;
    }

    protected function resourceAfterSave(Model $item, Request $request, array $validated, ?Model $original = null): void
    {
        if ($original && $original->file_path && $request->hasFile('document_file')) {
            Storage::disk('public')->delete($original->file_path);
        }
    }

    public function download($id)
    {
        $doc = AraziDocument::findOrFail($id);

        if (! Storage::disk('public')->exists($doc->file_path)) {
            abort(404);
        }

        return Storage::disk('public')->download($doc->file_path, basename($doc->file_path));
    }
}
