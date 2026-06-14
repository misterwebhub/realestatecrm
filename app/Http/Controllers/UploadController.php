<?php

namespace App\Http\Controllers;

use App\Models\Upload;
use App\Models\UploadCategory;
use App\Models\Arazi;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Storage;

class UploadController extends Controller
{
    public function index()
    {
        $query = Upload::with('category','arazi')->latest();

        $category = request()->input('category');
        $araziCode  = trim((string) request()->input('arazi_code', ''));
        $unassigned = request()->boolean('unassigned');
        $q = request()->input('q');
        $dateFrom = request()->input('date_from');
        $dateTo = request()->input('date_to');

        if ($category) {
            $query->where('upload_category_id', $category);
        }

        if ($araziCode !== '') {
            $query->where('arazi_code', $araziCode);
        }

        if ($unassigned) {
            $query->whereNull('arazi_id');
        }

        if ($q) {
            $query->where(function($r) use ($q) {
                $r->where('label','like','%'.$q.'%')
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
        $araziOptions = Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '!=', '')
            ->orderBy('legacy_arazi_code')
            ->pluck('legacy_arazi_code')
            ->unique()
            ->values();

        return view('uploads.index', compact('uploads', 'categories', 'araziOptions', 'araziCode'));
    }

    public function create()
    {
        $categories   = UploadCategory::orderBy('name')->pluck('name', 'id')->all();
        $araziOptions = Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '!=', '')
            ->orderBy('legacy_arazi_code')
            ->pluck('legacy_arazi_code')
            ->unique()
            ->values();
        return view('uploads.create', compact('categories', 'araziOptions'));
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'upload_category_id' => 'required|exists:upload_categories,id',
            'arazi_code'         => 'nullable|string|max:40',
            'label'              => 'nullable|string|max:191',
            'file'               => 'required|file|max:10240',
        ]);

        // Resolve arazi_code → first matching arazi_id
        $araziId = null;
        if (!empty($validated['arazi_code'])) {
            $araziId = Arazi::where('legacy_arazi_code', $validated['arazi_code'])->value('id');
        }

        $file = $request->file('file');
        $path = $file->store('uploads', 'public');

        $upload = Upload::create([
            'upload_category_id' => $validated['upload_category_id'],
            'arazi_id'           => $araziId,
            'arazi_code'         => $validated['arazi_code'] ?? null,
            'label' => $validated['label'] ?? null,
            'file_path' => $path,
            'mime' => $file->getClientMimeType(),
            'size' => $file->getSize(),
        ]);

        return redirect()->route('uploads.index')->with('success','File uploaded');
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
}
