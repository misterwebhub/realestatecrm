<?php

namespace App\Http\Controllers;

use App\Models\CustomerBondCheque;
use App\Models\CustomerBond;
use Illuminate\Http\Request;
use Illuminate\Validation\Rule;
use Illuminate\Support\Facades\DB;

class CustomerBondChequeController extends Controller
{
    public function index(Request $request)
    {
        $filterStatus  = $request->query('status', '');
        $filterBond    = $request->query('bond_no', '');
        $filterAccount = $request->query('account_id', '');

        $query = CustomerBondCheque::with(['customerBond.customer', 'connectedAccount'])
            ->when($filterStatus,  fn ($q) => $q->where('status', $filterStatus))
            ->when($filterBond,    fn ($q) => $q->whereHas('customerBond', fn ($bq) => $bq->where('bond_no', 'like', '%' . $filterBond . '%')))
            ->when($filterAccount, fn ($q) => $q->where('connected_account_id', $filterAccount))
            ->latest('cheque_date')
            ->latest('id');

        $cheques = $query->get();

        // summary totals
        $all     = CustomerBondCheque::selectRaw('status, SUM(amount) as total, COUNT(*) as count')->groupBy('status')->get()->keyBy('status');
        $summary = [
            'pending'   => $all->get('pending'),
            'cleared'   => $all->get('cleared'),
            'bounced'   => $all->get('bounced'),
            'cancelled' => $all->get('cancelled'),
        ];

        $accounts = \App\Models\ConnectedAccount::orderBy('name')->get();

        return view('customer_bond_cheques.index', [
            'title'          => 'Connected Accounts Cheques',
            'cheques'        => $cheques,
            'summary'        => $summary,
            'filterStatus'   => $filterStatus,
            'filterBond'     => $filterBond,
            'filterAccount'  => $filterAccount,
            'accounts'       => $accounts,
        ]);
    }

    public function create(Request $request)
    {
        $bond = null;
        $bondId = $request->query('customer_bond_id') ?? $request->input('customer_bond_id');
        if ($bondId) {
            $bond = CustomerBond::with(['customer'])->find($bondId);
        }

        // If a bond is supplied, redirect to the manage screen which supports
        // adding multiple cheque entries in one go.
        if ($bondId) {
            return redirect()->route('customer-bond-cheques.manage', $bondId);
        }

        return view('customer_bond_cheques.form', [
            'title' => 'Create Cheque Entry',
            'item' => null,
            'bond' => $bond,
            'customers' => \App\Models\Customer::orderBy('name')->pluck('name', 'id')->all(),
        ]);
    }

    public function store(Request $request)
    {
        $bondId = $request->input('customer_bond_id');

        $data = $request->validate([
            'customer_bond_id' => ['required', 'exists:customer_bonds,id'],
            'customer_id' => ['nullable', 'exists:customers,id'],
            'cheque_number' => [
                'required',
                'string',
                'max:100',
                Rule::unique('customer_bond_cheques', 'cheque_number')->where(function ($q) use ($bondId) {
                    return $q->where('customer_bond_id', $bondId);
                }),
            ],
            'connected_account_id' => ['required', 'exists:connected_accounts,id'],
            'bank_name' => ['nullable', 'string', 'max:150'],
            'branch_name' => ['nullable', 'string', 'max:150'],
            'cheque_date' => ['nullable', 'date'],
            'amount' => ['required', 'numeric', 'min:0'],
            'status' => ['nullable', 'in:pending,cleared,bounced,cancelled'],
            'type' => ['nullable', 'in:mentioned,not_mentioned'],
            'notes' => ['nullable', 'string'],
        ]);

        $data['status'] = $data['status'] ?? 'pending';
        $data['type'] = $data['type'] ?? 'mentioned';
        $data['created_by'] = auth()->id() ?? null;

        $cheque = CustomerBondCheque::create($data);

        return redirect()->back()->with('success', 'Cheque entry created.');
    }

    public function forBond(CustomerBond $customer_bond)
    {
        $query = CustomerBondCheque::where('customer_bond_id', $customer_bond->id)->orderByDesc('id');

        // allow filtering by status (e.g., ?status=pending) so callers can request unpaid only
        if ($status = request()->query('status')) {
            $query->where('status', $status);
        }

        $cheques = $query->get()->map(function ($c) {
            return [
                'id' => $c->id,
                'label' => ($c->cheque_number ? $c->cheque_number . ' — ' : '') . '₹' . number_format((float)$c->amount, 2) . ' — ' . ucfirst($c->status),
                'amount' => (float) $c->amount,
                'status' => $c->status,
            ];
        })->values();

        return response()->json($cheques);
    }

    public function manage(CustomerBond $customer_bond)
    {
        $customer_bond->loadMissing(['customer', 'arazi', 'plots', 'witnesses', 'payments']);

        $cheques = CustomerBondCheque::with('connectedAccount')
            ->where('customer_bond_id', $customer_bond->id)
            ->orderBy('id')
            ->get();

        // Payment summary (debit-aware)
        $debitTypes  = ['return', 'discount'];
        $totalPaid   = $customer_bond->payments->whereNotIn('entry_type', $debitTypes)->sum('amount');
        $totalDebit  = $customer_bond->payments->whereIn('entry_type', $debitTypes)->sum('amount');
        $netPaid     = $totalPaid - $totalDebit;
        $balance     = ($customer_bond->total_amount ?? 0) - $netPaid;
        $installmentNo = $customer_bond->payments->whereNotIn('entry_type', $debitTypes)->count();

        return view('customer_bond_cheques.manage', [
            'bond'          => $customer_bond,
            'cheques'       => $cheques,
            'netPaid'       => $netPaid,
            'balance'       => $balance,
            'installmentNo' => $installmentNo,
        ]);
    }

    public function storeBulk(Request $request)
    {
        $data = $request->validate([
            'customer_bond_id' => ['required', 'exists:customer_bonds,id'],
            'deleted_ids' => ['nullable', 'array'],
            'deleted_ids.*' => ['integer', 'exists:customer_bond_cheques,id'],
            'cheques' => ['nullable', 'array'],
            'cheques.*.id' => ['nullable', 'integer', 'exists:customer_bond_cheques,id'],
            'cheques.*.cheque_number' => ['required', 'string', 'max:100'],
            'cheques.*.bank_name' => ['nullable', 'string', 'max:150'],
            'cheques.*.branch_name' => ['nullable', 'string', 'max:150'],
            'cheques.*.cheque_date' => ['nullable', 'date'],
            'cheques.*.amount' => ['required', 'numeric', 'min:0'],
            'cheques.*.status' => ['nullable', 'in:pending,cleared,bounced,cancelled'],
            'cheques.*.type' => ['nullable', 'in:mentioned,not_mentioned'],
            'cheques.*.connected_account_id' => ['required', 'exists:connected_accounts,id'],
            'cheques.*.notes' => ['nullable', 'string'],
        ]);

        $bondId = $data['customer_bond_id'];

        // Process deletions first so replaced cheque_numbers are allowed
        $deletedIds = $data['deleted_ids'] ?? [];
        if (!empty($deletedIds)) {
            CustomerBondCheque::whereIn('id', $deletedIds)->where('customer_bond_id', $bondId)->delete();
        }

        $items = $data['cheques'] ?? [];

        // Prevent duplicate cheque numbers within the submitted payload
        $seen = [];
        foreach ($items as $idx => $row) {
            $num = trim((string) ($row['cheque_number'] ?? ''));
            if ($num === '') {
                return redirect()->back()->withErrors(['cheques.' . $idx . '.cheque_number' => 'Cheque number is required'])->withInput();
            }
            if (isset($seen[$num])) {
                return redirect()->back()->withErrors(['cheques.' . $idx . '.cheque_number' => 'Duplicate cheque number in request: ' . $num])->withInput();
            }
            $seen[$num] = $row['id'] ?? null;
        }

        // Check against existing DB rows for this bond (exclude rows being updated)
        if (!empty($seen)) {
            $existing = CustomerBondCheque::where('customer_bond_id', $bondId)
                ->whereIn('cheque_number', array_keys($seen))
                ->get();

            foreach ($existing as $ex) {
                $payloadId = $seen[$ex->cheque_number] ?? null;
                if (empty($payloadId) || $payloadId != $ex->id) {
                    return redirect()->back()->withErrors(['cheques' => 'Cheque number ' . $ex->cheque_number . ' already exists for this bond'])->withInput();
                }
            }
        }

        foreach ($items as $row) {
            // if id present, update existing; otherwise create
            if (!empty($row['id'])) {
                $c = CustomerBondCheque::where('id', $row['id'])->where('customer_bond_id', $bondId)->first();
                if (! $c) continue;
                $c->update([
                    'connected_account_id' => $row['connected_account_id'],
                    'cheque_number' => $row['cheque_number'],
                    'bank_name' => $row['bank_name'] ?? null,
                    'branch_name' => $row['branch_name'] ?? null,
                    'cheque_date' => $row['cheque_date'] ?? null,
                    'amount' => $row['amount'],
                    'status' => $row['status'] ?? 'pending',
                    'type' => $row['type'] ?? 'mentioned',
                    'notes' => $row['notes'] ?? null,
                ]);
            } else {
                CustomerBondCheque::create([
                    'customer_bond_id' => $bondId,
                    'customer_id' => CustomerBond::find($bondId)?->customer_id ?? null,
                    'connected_account_id' => $row['connected_account_id'],
                    'cheque_number' => $row['cheque_number'],
                    'bank_name' => $row['bank_name'] ?? null,
                    'branch_name' => $row['branch_name'] ?? null,
                    'cheque_date' => $row['cheque_date'] ?? null,
                    'amount' => $row['amount'],
                    'status' => $row['status'] ?? 'pending',
                    'type' => $row['type'] ?? 'mentioned',
                    'notes' => $row['notes'] ?? null,
                    'created_by' => auth()->id() ?? null,
                ]);
            }
        }

        return redirect()->route('customer-bond-cheques.manage', $bondId)->with('success', 'Cheques saved.');
    }

    public function destroy(CustomerBondCheque $customerBondCheque)
    {
        $customerBondCheque->delete();
        return redirect()->back()->with('success', 'Cheque entry deleted.');
    }
}
