<?php

namespace App\Http\Controllers;

use App\Services\AreaConverter;
use Illuminate\Http\Request;

class AreaConverterController extends Controller
{
    public function index()
    {
        return view('converter.form', ['result' => null, 'unit' => session('last_unit')]);
    }

    public function convert(Request $request)
    {
        $validated = $request->validate([
            'value' => ['required', 'numeric'],
            'unit' => ['required', 'string'],
        ]);

        $result = AreaConverter::toGaz($validated['value'], $validated['unit']);

        // remember last selected unit for convenience
        session(['last_unit' => $validated['unit']]);

        return view('converter.form', [
            'result' => $result,
            'value' => $validated['value'],
            'unit' => $validated['unit'],
        ]);
    }
}
