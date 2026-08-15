<?php

namespace App\Http\Controllers;

use App\Models\Upload;
use App\Models\UploadCategory;
use App\Models\Arazi;
use App\Models\Kisan;
use App\Models\Partner;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Storage;

class UploadController extends Controller
{
    public function index()
    {
        $query = Upload::with('category')->latest();

        $category = request()->input('category');
        $araziCode  = trim((string) request()->input('arazi_code', ''));
        $kisanName  = trim((string) request()->input('kisan_name', ''));
        $partnerName = trim((string) request()->input('partner_name', ''));
        $unassigned = request()->boolean('unassigned');
        $q = request()->input('q');
        $dateFrom = request()->input('date_from');
        $dateTo = request()->input('date_to');

        if ($category) {
            $query->where('upload_category_id', $category);
        }

        if ($araziCode !== '') {
            $query->where('arazi_code', 'like', '%'.$araziCode.'%');
        }

        if ($kisanName !== '') {
            $query->where('kisan_name', 'like', '%'.$kisanName.'%');
        }

        if ($partnerName !== '') {
            $query->where('partner_name', 'like', '%'.$partnerName.'%');
        }

        if ($unassigned) {
            $query->whereNull('arazi_code')->whereNull('kisan_name')->whereNull('partner_name');
        }

        if ($q) {
            $query->where(function($r) use ($q) {
                $r->where('label','like','%'.$q.'%')
                  ->orWhere('reason','like','%'.$q.'%')
                  ->orWhere('file_path','like','%'.$q.'%');
            });
        }

        if ($dateFrom) {
            $query->whereDate('created_at', '>=', $dateFrom);
        }

        if ($dateTo) {
            $query->whereDate('created_at', '<=', $dateTo);
        }

        $uploads = $query->paginate(40)->withQueryString();

        $categories  = UploadCategory::orderBy('name')->get();

        return view('uploads.index', compact('uploads', 'categories', 'araziCode', 'kisanName', 'partnerName'));
    }

    public function create()
    {
        $categories = UploadCategory::orderBy('name')->pluck('name', 'id')->all();

        return view('uploads.create', compact('categories'));
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'upload_category_id' => 'required|exists:upload_categories,id',
            'arazi_code'         => 'nullable|string|max:40',
            'kisan_name'         => 'nullable|string|max:191',
            'partner_name'       => 'nullable|string|max:191',
            'label'              => 'nullable|string|max:191',
            'reason'             => 'nullable|string|max:500',
            'file'               => 'required|file|max:10240',
        ]);

        $file = $request->file('file');
        $path = $file->store('uploads', 'public');

        // Free-text only — these fields are for the user's own record-keeping
        // and are never resolved/linked to real Kisan/Partner rows.
        $upload = Upload::create([
            'upload_category_id' => $validated['upload_category_id'],
            'arazi_code'         => $validated['arazi_code'] ?? null,
            'kisan_name'         => $validated['kisan_name'] ?? null,
            'partner_name'       => $validated['partner_name'] ?? null,
            'label' => $validated['label'] ?? null,
            'reason' => $validated['reason'] ?? null,
            'file_path' => $path,
            'mime' => $file->getClientMimeType(),
            'size' => $file->getSize(),
        ]);

        return redirect()->route('uploads.index')->with('success','File uploaded');
    }

    public function edit(Upload $upload)
    {
        $categories = UploadCategory::orderBy('name')->pluck('name', 'id')->all();

        return view('uploads.edit', compact('upload', 'categories'));
    }

    public function update(Request $request, Upload $upload)
    {
        $validated = $request->validate([
            'upload_category_id' => 'required|exists:upload_categories,id',
            'arazi_code'         => 'nullable|string|max:40',
            'kisan_name'         => 'nullable|string|max:191',
            'partner_name'       => 'nullable|string|max:191',
            'label'              => 'nullable|string|max:191',
            'reason'             => 'nullable|string|max:500',
            'file'               => 'nullable|file|max:10240',
        ]);

        $data = [
            'upload_category_id' => $validated['upload_category_id'],
            'arazi_code'         => $validated['arazi_code'] ?? null,
            'kisan_name'         => $validated['kisan_name'] ?? null,
            'partner_name'       => $validated['partner_name'] ?? null,
            'label'              => $validated['label'] ?? null,
            'reason'             => $validated['reason'] ?? null,
        ];

        // Replacing the file is optional — only swap it (and clean up the old
        // one) when a new file was actually submitted.
        if ($request->hasFile('file')) {
            $file = $request->file('file');
            $newPath = $file->store('uploads', 'public');

            if ($upload->file_path && Storage::disk('public')->exists($upload->file_path)) {
                Storage::disk('public')->delete($upload->file_path);
            }

            $data['file_path'] = $newPath;
            $data['mime']      = $file->getClientMimeType();
            $data['size']      = $file->getSize();
        }

        $upload->update($data);

        return redirect()->route('uploads.index')->with('success', 'Upload updated');
    }

    public function destroy(Upload $upload)
    {
        if ($upload->file_path && Storage::disk('public')->exists($upload->file_path)) {
            Storage::disk('public')->delete($upload->file_path);
        }

        $upload->delete();

        return redirect()->route('uploads.index')->with('success', 'Upload deleted');
    }

    public function ajaxAraziSearch(Request $request)
    {
        $q = $request->input('q');
        $query = Arazi::query();
        if ($q) {
            $query->where('legacy_arazi_code','like','%'.$q.'%')
                ->orWhere('plot_number','like','%'.$q.'%');
        }
        $results = $query->limit(20)->get()->map(function($a){
            return ['id'=>$a->id,'text'=>$a->araziNoCode()];
        });
        return response()->json(['results'=>$results]);
    }

    public function download(Upload $upload)
    {
        return Storage::disk('public')->download($upload->file_path);
    }

    /**
     * Stream the file inline (Content-Disposition: inline) so previewable
     * types (PDF, images) open/render directly in a new browser tab instead
     * of forcing a download.
     */
    public function view(Upload $upload)
    {
        if (! Storage::disk('public')->exists($upload->file_path)) {
            abort(404);
        }

        return Storage::disk('public')->response($upload->file_path);
    }
}
