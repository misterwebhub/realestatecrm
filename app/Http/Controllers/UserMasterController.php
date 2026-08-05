<?php

namespace App\Http\Controllers;

use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Crypt;
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
            'roles'  => \App\Models\Role::orderBy('display_name')->get(),
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
            'role_id'          => ['required', 'exists:roles,id'],
            'is_active'        => ['nullable', 'boolean'],
            'office_latitude'       => ['nullable', 'numeric', 'between:-90,90', 'required_with:office_longitude,allowed_radius_meters'],
            'office_longitude'      => ['nullable', 'numeric', 'between:-180,180', 'required_with:office_latitude,allowed_radius_meters'],
            'allowed_radius_meters' => ['nullable', 'integer', 'min:1', 'max:200000', 'required_with:office_latitude,office_longitude'],
            'office_start_time'     => ['nullable', 'date_format:H:i', 'required_with:office_end_time'],
            'office_end_time'       => ['nullable', 'date_format:H:i', 'required_with:office_start_time'],
            'allow_after_hours'     => ['nullable', 'boolean'],
            'disable_radius_login'  => ['nullable', 'boolean'],
            'allow_backdated_payments' => ['nullable', 'boolean'],
        ]);

        // Keep a reversible copy alongside the one-way hash so it can be
        // revealed later from the User Master list (Super Admin only).
        $validated['password_encrypted'] = Crypt::encryptString($validated['password']);
        $validated['password']  = Hash::make($validated['password']);
        $validated['is_active'] = $request->boolean('is_active', true);
        $validated['allow_after_hours'] = $request->boolean('allow_after_hours', false);
        $validated['disable_radius_login'] = $request->boolean('disable_radius_login', false);
        $validated['allow_backdated_payments'] = $request->boolean('allow_backdated_payments', false);
        $validated['role']      = $this->legacyRoleFor($validated['role_id']);
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
            'roles'  => \App\Models\Role::orderBy('display_name')->get(),
        ]);
    }

    public function update(Request $request, User $userMaster)
    {
        // Only a Super Admin may change another user's password from the edit
        // form. Anyone else with access to this controller must not be able
        // to silently reset someone else's credentials, so the field is
        // ignored entirely (even if somehow submitted) for non-Super-Admins.
        $isSuperAdmin = (bool) auth()->user()?->isSuperAdmin();

        $rules = [
            'name'             => ['required', 'string', 'max:150'],
            'username'         => ['required', 'string', 'max:50', 'unique:users,username,' . $userMaster->id],
            'email'            => ['nullable', 'email', 'max:150', 'unique:users,email,' . $userMaster->id],
            'mobile'           => ['required', 'string', 'max:20'],
            'secondary_mobile' => ['nullable', 'string', 'max:20'],
            'address'          => ['nullable', 'string', 'max:300'],
            'role_id'          => ['required', 'exists:roles,id'],
            'is_active'        => ['nullable', 'boolean'],
            'office_latitude'       => ['nullable', 'numeric', 'between:-90,90', 'required_with:office_longitude,allowed_radius_meters'],
            'office_longitude'      => ['nullable', 'numeric', 'between:-180,180', 'required_with:office_latitude,allowed_radius_meters'],
            'allowed_radius_meters' => ['nullable', 'integer', 'min:1', 'max:200000', 'required_with:office_latitude,office_longitude'],
            'office_start_time'     => ['nullable', 'date_format:H:i', 'required_with:office_end_time'],
            'office_end_time'       => ['nullable', 'date_format:H:i', 'required_with:office_start_time'],
            'allow_after_hours'     => ['nullable', 'boolean'],
            'disable_radius_login'  => ['nullable', 'boolean'],
            'allow_backdated_payments' => ['nullable', 'boolean'],
        ];
        if ($isSuperAdmin) {
            $rules['password'] = ['nullable', 'string', 'min:6', 'confirmed'];
        }

        $validated = $request->validate($rules);

        if ($isSuperAdmin && !empty($validated['password'])) {
            $validated['password_encrypted'] = Crypt::encryptString($validated['password']);
            $validated['password'] = Hash::make($validated['password']);
        } else {
            unset($validated['password']);
        }
        $validated['is_active'] = $request->boolean('is_active', true);
        $validated['allow_after_hours'] = $request->boolean('allow_after_hours', false);
        $validated['disable_radius_login'] = $request->boolean('disable_radius_login', false);
        $validated['allow_backdated_payments'] = $request->boolean('allow_backdated_payments', false);
        $validated['role']      = $this->legacyRoleFor($validated['role_id']);

        $userMaster->update($validated);

        return redirect()->route('user-master.index')->with('success', 'User updated successfully.');
    }

    /**
     * Super-Admin-only quick password reset from the User Master list —
     * lets a Super Admin set a new password for any user without going
     * through the full edit form.
     */
    public function resetPassword(Request $request, User $userMaster)
    {
        if (! auth()->user()?->isSuperAdmin()) {
            abort(403);
        }

        $validated = $request->validate([
            'password' => ['required', 'string', 'min:6', 'confirmed'],
        ]);

        $userMaster->update([
            'password'           => Hash::make($validated['password']),
            'password_encrypted' => Crypt::encryptString($validated['password']),
        ]);

        return redirect()->route('user-master.index')->with('success', "Password reset for {$userMaster->name}.");
    }

    /**
     * Reveal a user's password on the User Master list (eye-icon toggle).
     * Restricted to Super Admins — anyone with plain `auth` access to this
     * controller must NOT be able to read other users' passwords.
     */
    public function password(User $userMaster)
    {
        if (! auth()->user()?->isSuperAdmin()) {
            abort(403);
        }

        if (empty($userMaster->password_encrypted)) {
            return response()->json([
                'available' => false,
                'message'   => 'Not available — set/reset this user\'s password to enable reveal.',
            ]);
        }

        try {
            $plain = Crypt::decryptString($userMaster->password_encrypted);
        } catch (\Throwable $e) {
            return response()->json(['available' => false, 'message' => 'Unable to decrypt password.']);
        }

        return response()->json(['available' => true, 'password' => $plain]);
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

    /**
     * Map an assigned role (roles table) to the legacy users.role enum
     * so the legacy column stays valid. Super Admin -> admin, otherwise
     * match by slug, falling back to 'staff'.
     */
    protected function legacyRoleFor($roleId): string
    {
        $role = \App\Models\Role::find($roleId);
        if (!$role) {
            return 'staff';
        }
        if ($role->name === \App\Models\Role::SUPER_ADMIN) {
            return 'admin';
        }
        return in_array($role->name, ['admin', 'manager', 'accountant', 'staff'], true)
            ? $role->name
            : 'staff';
    }

    /**
     * Consolidated report: how much each user collected, broken down by bond.
     */
    public function report(Request $request)
    {
        $dateFrom = $request->query('date_from', '');
        $dateTo   = $request->query('date_to', '');
        $userId   = $request->query('user_id', '');

        $payments = \App\Models\CustomerBondPayment::with([
                'takenByUser',
                'customerBond.customer',
                'customerBond.arazi',
                'customerBond.plots',
            ])
            ->whereNotNull('taken_by_user_id')
            ->when($userId,   fn ($q) => $q->where('taken_by_user_id', $userId))
            ->when($dateFrom, fn ($q) => $q->whereDate('entry_date', '>=', $dateFrom))
            ->when($dateTo,   fn ($q) => $q->whereDate('entry_date', '<=', $dateTo))
            ->orderBy('entry_date')
            ->orderBy('id')
            ->get();

        $isDebit = fn ($p) => in_array($p->entry_type, ['return', 'discount'], true);

        // Group by user, then by bond
        $byUser = $payments->groupBy('taken_by_user_id')->map(function ($userPayments) use ($isDebit) {
            $user = $userPayments->first()->takenByUser;

            $bonds = $userPayments->groupBy('customer_bond_id')->map(function ($entries) use ($isDebit) {
                $bond   = $entries->first()->customerBond;
                $credit = $entries->reject($isDebit)->sum('amount');
                $debit  = $entries->filter($isDebit)->sum('amount');
                return [
                    'bond'   => $bond,
                    'count'  => $entries->count(),
                    'credit' => $credit,
                    'debit'  => $debit,
                    'net'    => $credit - $debit,
                ];
            })->values();

            $credit = $userPayments->reject($isDebit)->sum('amount');
            $debit  = $userPayments->filter($isDebit)->sum('amount');

            return [
                'user'    => $user,
                'bonds'   => $bonds,
                'count'   => $userPayments->count(),
                'credit'  => $credit,
                'debit'   => $debit,
                'net'     => $credit - $debit,
            ];
        })->sortByDesc('net')->values();

        $grandCredit = $payments->reject($isDebit)->sum('amount');
        $grandDebit  = $payments->filter($isDebit)->sum('amount');

        return view('user_master.report', [
            'title'       => 'User Master Report — Collections by User & Bond',
            'byUser'      => $byUser,
            'users'       => User::orderBy('name')->get(['id', 'name']),
            'grandCredit' => $grandCredit,
            'grandDebit'  => $grandDebit,
            'grandNet'    => $grandCredit - $grandDebit,
            'totalCount'  => $payments->count(),
            'dateFrom'    => $dateFrom,
            'dateTo'      => $dateTo,
            'userId'      => $userId,
        ]);
    }

    /** JSON list for select boxes */
    public function list()
    {
        $users = User::where('is_active', true)->orderBy('name')->get(['id', 'name', 'username', 'mobile']);
        return response()->json($users);
    }
}
