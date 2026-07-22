<?php

namespace App\Http\Controllers;

use App\Models\Expense;
use App\Models\Arazi;
use Illuminate\Http\Request;

class ExpenseController extends Controller
{
    public function index(Request $request)
    {
        $query = Expense::with('arazi')->latest();
        $user = auth()->user();
        if ($user && ! $user->isSuperAdmin()) {
            $query->where('expenses.created_by', $user->getKey());
        }
        if ($request->filled('arazi_code')) {
            $query->where('arazi_code', $request->arazi_code);
        }
        if ($request->filled('type')) {
            $query->where('type', $request->type);
        }
        $expenses = $query->paginate(30)->withQueryString();
        $arazis = Arazi::whereNotNull('legacy_arazi_code')->where('legacy_arazi_code','<>','')
            ->orderBy('legacy_arazi_code')->pluck('legacy_arazi_code')->unique()->values();
        $types = \App\Models\ExpenseType::orderBy('name')->pluck('name','id');
        return view('expenses.index', compact('expenses','arazis','types'));
    }

    public function create(Request $request)
    {
        $arazis = Arazi::whereNotNull('legacy_arazi_code')->where('legacy_arazi_code','<>','')
            ->orderBy('legacy_arazi_code')->pluck('legacy_arazi_code')->unique()->values();
        $types = \App\Models\ExpenseType::orderBy('name')->pluck('name','id');
        $selectedType = $request->query('selected_type');
        return view('expenses.create', compact('arazis','types','selectedType'));
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'arazi_code' => 'nullable|string|exists:arazis,legacy_arazi_code',
            'scope' => 'required|string|in:personal,arazi',
            'expense_type_id' => 'required|exists:expense_types,id',
            'label' => 'nullable|string|max:191',
            'amount' => 'required|numeric|min:0',
            'incurred_at' => 'nullable|date',
            'notes' => 'nullable|string',
        ]);

        if (($request->input('scope') ?? '') === 'arazi') {
            $request->validate(['arazi_code' => 'required|string|exists:arazis,legacy_arazi_code']);
        }

        $data = [
            'arazi_code' => $request->input('arazi_code'),
            'type' => $request->input('scope'),
            'expense_type_id' => $request->input('expense_type_id'),
            'label' => $request->input('label'),
            'amount' => $request->input('amount'),
            'incurred_at' => $request->input('incurred_at'),
            'notes' => $request->input('notes'),
            'created_by' => auth()->id(),
        ];

        Expense::create($data);

        return redirect()->route('expenses.index')->with('success','Expense recorded');
    }
}
