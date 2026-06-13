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
        $users = User::orderBy('name')->get();
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

    /** JSON list for select boxes */
    public function list()
    {
        $users = User::where('is_active', true)->orderBy('name')->get(['id', 'name', 'username', 'mobile']);
        return response()->json($users);
    }
}
