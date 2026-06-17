<?php

namespace App\Http\Controllers;

use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Hash;
use Illuminate\Validation\Rules\Password;

class UserMasterController extends Controller
{
    public function index()
    {
        $users = User::withCount(['payments as receipt_count'])->orderBy('name')->get();
        return view('user_master.index', ['users' => $users]);
    }

    public function create()
    {
        return view('user_master.form', [
            'title'  => 'Add User',
            'action' => route('user-master.store'),
            'method' => 'POST',
            'item'   => null,
        ]);
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'name'             => ['required', 'string', 'max:150'],
            'username'         => ['required', 'string', 'max:50', 'unique:users,username'],
            'email'            => ['nullable', 'email', 'max:150', 'unique:users,email'],
            'mobile'           => ['required', 'string', 'max:20'],
            'secondary_mobile' => ['nullable', 'string', 'max:20'],
            'address'          => ['nullable', 'string', 'max:300'],
            'password'         => ['required', 'string', 'min:6', 'confirmed'],
            'role'             => ['nullable', 'in:admin,manager,accountant,staff'],
            'is_active'        => ['nullable', 'boolean'],
        ]);

        $validated['password']  = Hash::make($validated['password']);
        $validated['is_active'] = $request->boolean('is_active', true);
        if (empty($validated['email'])) unset($validated['email']);

        User::create($validated);

        return redirect()->route('user-master.index')->with('success', 'User created successfully.');
    }

    public function edit(User $userMaster)
    {
        return view('user_master.form', [
            'title'  => 'Edit User — ' . $userMaster->name,
            'action' => route('user-master.update', $userMaster),
            'method' => 'PUT',
            'item'   => $userMaster,
        ]);
    }

    public function update(Request $request, User $userMaster)
    {
        $validated = $request->validate([
            'name'             => ['required', 'string', 'max:150'],
            'username'         => ['required', 'string', 'max:50', 'unique:users,username,' . $userMaster->id],
            'email'            => ['nullable', 'email', 'max:150', 'unique:users,email,' . $userMaster->id],
            'mobile'           => ['required', 'string', 'max:20'],
            'secondary_mobile' => ['nullable', 'string', 'max:20'],
            'address'          => ['nullable', 'string', 'max:300'],
            'password'         => ['nullable', 'string', 'min:6', 'confirmed'],
            'role'             => ['nullable', 'in:admin,manager,accountant,staff'],
            'is_active'        => ['nullable', 'boolean'],
        ]);

        if (!empty($validated['password'])) {
            $validated['password'] = Hash::make($validated['password']);
        } else {
            unset($validated['password']);
        }
        $validated['is_active'] = $request->boolean('is_active', true);

        $userMaster->update($validated);

        return redirect()->route('user-master.index')->with('success', 'User updated successfully.');
    }

    public function destroy(User $userMaster)
    {
        if ($userMaster->id === auth()->id()) {
            return redirect()->back()->with('error', 'You cannot delete your own account.');
        }
        $userMaster->delete();
        return redirect()->route('user-master.index')->with('success', 'User deleted.');
    }

    public function receipts(Request $request, User $userMaster)
    {
        $dateFrom = $request->query('date_from', '');
        $dateTo   = $request->query('date_to', '');

        $payments = \App\Models\CustomerBondPayment::with([
                'customerBond.customer',
                'customerBond.arazi',
                'customerBond.plots',
            ])
            ->where('taken_by_user_id', $userMaster->id)
            ->when($dateFrom, fn ($q) => $q->whereDate('entry_date', '>=', $dateFrom))
            ->when($dateTo,   fn ($q) => $q->whereDate('entry_date', '<=', $dateTo))
            ->orderBy('entry_date')
            ->orderBy('id')
            ->get();

        // Group by bond
        $byBond = $payments->groupBy('customer_bond_id')->map(function ($entries) {
            $bond       = $entries->first()->customerBond;
            $totalCredit = $entries->whereNotIn('entry_type', ['return','discount'])->sum('amount');
            $totalDebit  = $entries->whereIn('entry_type', ['return','discount'])->sum('amount');
            return [
                'bond'        => $bond,
                'entries'     => $entries,
                'credit'      => $totalCredit,
                'debit'       => $totalDebit,
                'net'         => $totalCredit - $totalDebit,
            ];
        })->values();

        $grandCredit = $payments->whereNotIn('entry_type', ['return','discount'])->sum('amount');
        $grandDebit  = $payments->whereIn('entry_type', ['return','discount'])->sum('amount');

        return view('user_master.receipts', [
            'user'        => $userMaster,
            'byBond'      => $byBond,
            'payments'    => $payments,
            'grandCredit' => $grandCredit,
            'grandDebit'  => $grandDebit,
            'grandNet'    => $grandCredit - $grandDebit,
            'dateFrom'    => $dateFrom,
            'dateTo'      => $dateTo,
            'title'       => 'Receipt Dashboard — ' . $userMaster->name,
        ]);
    }

    /** JSON list for select boxes */
    public function list()
    {
        $users = User::where('is_active', true)->orderBy('name')->get(['id', 'name', 'username', 'mobile']);
        return response()->json($users);
    }
}
