<?php

namespace App\Support;

use App\Models\CustomerBondPayment;
use App\Models\Payment;
use NumberFormatter;

class PaymentReceiptPresenter
{
    public static function amountInWordsInr(float $amount): string
    {
        if ($amount <= 0) {
            return 'Zero rupees only';
        }

        if (class_exists(NumberFormatter::class)) {
            $formatter = new NumberFormatter('en_IN', NumberFormatter::SPELLOUT);
            $whole = (int) floor($amount);
            $paise = (int) round(($amount - $whole) * 100);

            $words = ucfirst(trim((string) $formatter->format($whole))).' rupees';
            if ($paise > 0) {
                $words .= ' and '.ucfirst(trim((string) $formatter->format($paise))).' paise';
            }
            $words .= ' only';

            return $words;
        }

        return inr($amount, 2).' INR';
    }

    /**
     * @return array{cash: bool, transfer: bool, upi: bool, cheque: bool, other: bool}
     */
    public static function paymentMethodFlags(?string $method): array
    {
        $m = strtolower(trim((string) $method));

        $cash = str_contains($m, 'cash');
        $transfer = str_contains($m, 'transfer') || str_contains($m, 'bank') || str_contains($m, 'neft') || str_contains($m, 'rtgs') || str_contains($m, 'imps');
        $upi = str_contains($m, 'upi') || str_contains($m, 'phonepe') || str_contains($m, 'gpay') || str_contains($m, 'google pay');
        $cheque = str_contains($m, 'cheque') || str_contains($m, 'check');
        $other = $m !== '' && ! $cash && ! $transfer && ! $upi && ! $cheque;

        return [
            'cash' => $cash,
            'transfer' => $transfer,
            'upi' => $upi,
            'cheque' => $cheque,
            'other' => $other,
        ];
    }

    public static function fromKisanPayment(Payment $payment): array
    {
        $bond = $payment->kisanBond;
        $registry = $payment->registry;
        $kisan = $payment->kisan ?? $bond?->kisan ?? $registry?->arazi?->kisan;
        $amount = (float) ($payment->amount ?? 0);
        $method = $payment->payment_method ?? '';

        $receivedFrom = $kisan?->name
            ?? $payment->customer?->name
            ?? $registry?->customer?->name
            ?? '-';

        $desc = ucfirst((string) $payment->payment_type).' payment';
        if ($registry?->registry_code) {
            $desc .= ' — Registry '.$registry->registry_code;
        }
        if ($bond?->bond_no) {
            $desc .= ' — Kisan Bond '.$bond->bond_no;
        }
        if ($payment->notes) {
            $desc .= ' ('.$payment->notes.')';
        }

        return [
            'kind' => 'kisan',
            'receipt_no' => $payment->receipt_no ?? $payment->reference_no ?? '-',
            'receipt_date' => optional($payment->payment_date)->format('d-m-Y') ?? '-',
            'received_from' => $receivedFrom,
            'hand_in' => $desc,
            'amount' => $amount,
            'amount_formatted' => 'Rs. '.inr($amount, 2),
            'amount_in_words' => self::amountInWordsInr($amount),
            'method_flags' => self::paymentMethodFlags($method),
            'method_raw' => $method !== '' ? $method : '-',
            'payee_name' => config('app.name', 'Company'),
        ];
    }

    public static function fromCustomerPayment(CustomerBondPayment $payment): array
    {
        $payment->loadMissing(['customerBond.witnesses', 'customerBond.payments', 'customer']);
        $bond     = $payment->customerBond;
        $customer = $payment->customer ?? $bond?->customer;
        $amount   = (float) ($payment->amount ?? 0);
        $method   = $payment->payment_method ?? '';

        $desc = ucfirst((string) $payment->entry_type).' payment';
        if ($bond?->bond_no) {
            $desc .= ' — Customer Bond '.$bond->bond_no;
        }
        if ($payment->remarks) {
            $desc .= ' ('.$payment->remarks.')';
        }

        // bond summary for receipt
        $totalAmount   = (float) ($bond?->total_amount ?? $bond?->bond_amount ?? 0);
        $allPayments   = $bond?->payments ?? collect();
        $paidAmount    = (float) $allPayments->whereNotIn('entry_type', ['return','discount'])->sum('amount')
                       - (float) $allPayments->whereIn('entry_type', ['return','discount'])->sum('amount');
        $balance       = max($totalAmount - $paidAmount, 0);
        $paymentCount  = $allPayments->count();

        $witnesses = collect($bond?->witnesses ?? [])->map(fn ($w) => [
            'name'   => $w->name ?? '-',
            'mobile' => $w->mobile ?? null,
        ])->values()->all();

        return [
            'kind'             => 'customer',
            'receipt_no'       => $payment->entry_no ?? '-',
            'receipt_date'     => optional($payment->entry_date)->format('d-m-Y') ?? '-',
            'received_from'    => $customer?->name ?? '-',
            'hand_in'          => $desc,
            'amount'           => $amount,
            'amount_formatted' => 'Rs. '.inr($amount, 2),
            'amount_in_words'  => self::amountInWordsInr($amount),
            'method_flags'     => self::paymentMethodFlags($method),
            'method_raw'       => $method !== '' ? $method : '-',
            'payee_name'       => config('app.name', 'Company'),
            // bond details for receipt
            'bond_no'              => $bond?->bond_no ?? '-',
            'bond_date'            => optional($bond?->bond_date)->format('d-m-Y') ?? '-',
            'installment_end_date' => optional($bond?->expiry_date ?? $bond?->last_date)->format('d-m-Y') ?? '-',
            'installment_amount'   => (float) ($bond?->installment_amount ?? 0),
            'installment_no'       => $paymentCount,
            'total_amount'         => $totalAmount,
            'paid_amount'          => $paidAmount,
            'balance_amount'       => $balance,
            'witnesses'            => $witnesses,
        ];
    }
}
