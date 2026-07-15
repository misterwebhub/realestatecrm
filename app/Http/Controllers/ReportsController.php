<?php

namespace App\Http\Controllers;

use App\Models\CustomerBondPayment;
use App\Models\User;
use Illuminate\Http\Request;

class ReportsController extends Controller
{
    public function index()
    {
        return view('reports.index');
    }

    public function plotDetails()
    {
        return view('reports.plot_details');
    }

    /**
     * Detailed customer-payment report, grouped by the user who took the payment.
     * Supports filtering by user, customer, bond, arazi, entry type, payment
     * method and date range — all filter option lists are derived from the data.
     */
    public function customerPaymentsByUser(Request $request)
    {
        $userId        = $request->query('user_id', '');
        $customerId    = $request->query('customer_id', '');
        $bondId        = $request->query('bond_id', '');
        $araziCode     = $request->query('arazi_code', '');
        $entryType     = $request->query('entry_type', '');
        $paymentMethod = $request->query('payment_method', '');
        $dateFrom      = $request->query('date_from', '');
        $dateTo        = $request->query('date_to', '');

        $payments = CustomerBondPayment::with([
                'takenByUser',
                'customer',
                'customerBond.customer',
                'customerBond.arazi',
                'customerBond.plots',
            ])
            ->whereNotNull('taken_by_user_id')
            ->when($userId,        fn ($q) => $q->where('taken_by_user_id', $userId))
            ->when($customerId,    fn ($q) => $q->whereHas('customerBond', fn ($b) => $b->where('customer_id', $customerId)))
            ->when($bondId,        fn ($q) => $q->where('customer_bond_id', $bondId))
            ->when($araziCode,     fn ($q) => $q->where('arazi_code', $araziCode))
            ->when($entryType,     fn ($q) => $q->where('entry_type', $entryType))
            ->when($paymentMethod, fn ($q) => $q->where('payment_method', $paymentMethod))
            ->when($dateFrom,      fn ($q) => $q->whereDate('entry_date', '>=', $dateFrom))
            ->when($dateTo,        fn ($q) => $q->whereDate('entry_date', '<=', $dateTo))
            ->orderBy('entry_date')
            ->orderBy('id')
            ->get();

        $isDebit = fn ($p) => in_array($p->entry_type, ['return', 'discount'], true);

        $byUser = $payments->groupBy('taken_by_user_id')->map(function ($userPayments) use ($isDebit) {
            $user   = $userPayments->first()->takenByUser;
            $credit = $userPayments->reject($isDebit)->sum('amount');
            $debit  = $userPayments->filter($isDebit)->sum('amount');

            return [
                'user'     => $user,
                'payments' => $userPayments,
                'count'    => $userPayments->count(),
                'credit'   => $credit,
                'debit'    => $debit,
                'net'      => $credit - $debit,
            ];
        })->sortByDesc('net')->values();

        $grandCredit = $payments->reject($isDebit)->sum('amount');
        $grandDebit  = $payments->filter($isDebit)->sum('amount');

        return view('reports.customer_payments_by_user', [
            'title'         => 'Customer Payments by User',
            'byUser'        => $byUser,
            'grandCredit'   => $grandCredit,
            'grandDebit'    => $grandDebit,
            'grandNet'      => $grandCredit - $grandDebit,
            'totalCount'    => $payments->count(),
            // Filter option lists (data-driven)
            'users'         => User::orderBy('name')->get(['id', 'name']),
            'customers'     => \App\Models\Customer::orderBy('name')->get(['id', 'name']),
            'bonds'         => \App\Models\CustomerBond::orderBy('bond_no')->get(['id', 'bond_no']),
            'araziCodes'    => CustomerBondPayment::whereNotNull('arazi_code')->distinct()->orderBy('arazi_code')->pluck('arazi_code'),
            'entryTypes'    => CustomerBondPayment::whereNotNull('entry_type')->distinct()->orderBy('entry_type')->pluck('entry_type'),
            'paymentMethods'=> CustomerBondPayment::whereNotNull('payment_method')->where('payment_method', '!=', '')->distinct()->orderBy('payment_method')->pluck('payment_method'),
            // Current filter values
            'userId'        => $userId,
            'customerId'    => $customerId,
            'bondId'        => $bondId,
            'araziCode'     => $araziCode,
            'entryType'     => $entryType,
            'paymentMethod' => $paymentMethod,
            'dateFrom'      => $dateFrom,
            'dateTo'        => $dateTo,
        ]);
    }
}
