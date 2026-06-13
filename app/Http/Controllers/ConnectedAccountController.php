<?php

namespace App\Http\Controllers;

use App\Models\ConnectedAccount;
use Illuminate\Http\Request;

class ConnectedAccountController extends Controller
{
    public function index()
    {
        $accounts = ConnectedAccount::withCount('cheques')->latest()->get();

        return view('connected_accounts.index', [
            'accounts' => $accounts,
        ]);
    }

    public function create()
    {
        return view('connected_accounts.form', [
            'title'  => 'Add Connected Account',
            'action' => route('connected-accounts.store'),
            'method' => 'POST',
            'item'   => null,
        ]);
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'name'    => ['required', 'string', 'max:150'],
            'mobile'  => ['required', 'string', 'max:20'],
            'address' => ['nullable', 'string', 'max:300'],
            'notes'   => ['nullable', 'string'],
        ]);

        $account = ConnectedAccount::create($validated);

        if ($request->wantsJson() || $request->ajax()) {
            return response()->json([
                'success' => true,
                'id'      => $account->id,
                'name'    => $account->name,
                'mobile'  => $account->mobile,
            ]);
        }

        return redirect()->route('connected-accounts.index')->with('success', 'Account created successfully.');
    }

    public function edit(ConnectedAccount $connectedAccount)
    {
        return view('connected_accounts.form', [
            'title'  => 'Edit Connected Account',
            'action' => route('connected-accounts.update', $connectedAccount),
            'method' => 'PUT',
            'item'   => $connectedAccount,
        ]);
    }

    public function update(Request $request, ConnectedAccount $connectedAccount)
    {
        $validated = $request->validate([
            'name'    => ['required', 'string', 'max:150'],
            'mobile'  => ['required', 'string', 'max:20'],
            'address' => ['nullable', 'string', 'max:300'],
            'notes'   => ['nullable', 'string'],
        ]);

        $connectedAccount->update($validated);

        return redirect()->route('connected-accounts.index')->with('success', 'Account updated successfully.');
    }

    public function destroy(ConnectedAccount $connectedAccount)
    {
        $connectedAccount->delete();

        return redirect()->route('connected-accounts.index')->with('success', 'Account deleted.');
    }

    /** JSON list for select boxes */
    public function list()
    {
        $accounts = ConnectedAccount::orderBy('name')->get(['id', 'name', 'mobile']);
        return response()->json($accounts);
    }
}
