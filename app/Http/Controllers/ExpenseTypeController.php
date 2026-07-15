<?php

namespace App\Http\Controllers;

use App\Models\ExpenseType;
use Illuminate\Http\Request;

class ExpenseTypeController extends Controller
{
    public function ajaxStore(Request $request)
    {
        $data = $request->validate(['name' => 'required|string|max:100|unique:expense_types,name']);
        $type = ExpenseType::create($data);
        return response()->json(['success' => true, 'type' => $type]);
    }

    public function create()
    {
        return view('expense_types.create');
    }

    public function store(Request $request)
    {
        $data = $request->validate(['name' => 'required|string|max:100|unique:expense_types,name']);
        $type = ExpenseType::create($data);

        // Redirect back to expense creation page and pre-select the new type
        return redirect()->route('expenses.create', ['selected_type' => $type->id])->with('success', 'Expense type created');
    }
}
