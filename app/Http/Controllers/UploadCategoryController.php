<?php

namespace App\Http\Controllers;

use App\Models\UploadCategory;
use Illuminate\Http\Request;

class UploadCategoryController extends Controller
{
    public function index()
    {
        $cats = UploadCategory::latest()->get();
        return view('uploads.categories.index', compact('cats'));
    }

    public function store(Request $request)
    {
        $data = $request->validate([
            'name' => 'required|string|max:191',
            'description' => 'nullable|string',
        ]);

        $cat = UploadCategory::create($data);

        return redirect()->back()->with('success', 'Category created');
    }

    public function ajaxStore(Request $request)
    {
        $data = $request->validate(['name' => 'required|string|max:191']);
        $cat = UploadCategory::create($data);
        return response()->json(['success' => true, 'category' => $cat]);
    }
}
