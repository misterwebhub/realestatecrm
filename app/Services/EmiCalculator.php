<?php

namespace App\Services;

use App\Models\CustomerBond;
use Carbon\Carbon;

/**
 * Dynamic EMI engine for CustomerBond installment schedules.
 *
 * No individual installment rows are stored anywhere — everything here is
 * derived on the fly from the bond's own fields (bond amount, booking
 * amount, installment count, first due date) and its payment history
 * (CustomerBondPayment rows). This lets customers pay less than, more than,
 * or across several EMIs in a single transaction and still have accurate
 * Outstanding/Credit/Next-EMI figures without any manual reconciliation.
 *
 * Terminology:
 *  - "Bond Amount"     total_amount (falls back to bond_amount for legacy rows).
 *  - "Advance Amount"  booking/advance money, excluded from EMI math entirely.
 *                      Preferring the sum of entry_type=advance payments (which
 *                      also covers any extra advance taken after booking) and
 *                      falling back to the bond's `amount` (booking) field for
 *                      legacy bonds that predate the auto-advance payment row.
 *  - "Finance Amount"  Bond Amount - Advance Amount — the amount actually repaid
 *                      via EMIs.
 *  - No. of installments is stored in the legacy `installment_amount` column
 *    (a historical misnomer — it holds a month count, not a rupee amount),
 *    falling back to `no_of_months` for safety.
 */
class EmiCalculator
{
    public const DEBIT_TYPES = ['return', 'discount'];
    public const ADVANCE_TYPES = ['advance'];

    public const STATUS_FULLY_PAID = 'fully_paid';
    public const STATUS_OVERDUE = 'overdue';
    public const STATUS_PARTIAL = 'partial';
    public const STATUS_AHEAD = 'ahead';
    public const STATUS_ON_TIME = 'on_time';

    /**
     * Full breakdown for one bond as of a given date (defaults to today).
     * Expects `payments` to already be eager-loaded on the bond to avoid N+1s.
     */
    public static function calculate(CustomerBond $bond, ?Carbon $asOf = null, int $overdueDaysThreshold = 0): array
    {
        $asOf = ($asOf ?? now())->copy()->startOfDay();
        $payments = $bond->payments;

        $bondAmount = round((float) ($bond->total_amount ?? $bond->bond_amount ?? 0), 2);

        $advanceAmount = (float) $payments->whereIn('entry_type', self::ADVANCE_TYPES)->sum('amount');
        if ($advanceAmount <= 0.009 && (float) ($bond->amount ?? 0) > 0) {
            // Legacy safety net: bonds created before the auto-advance payment
            // existed may not have an `advance` payment row at all.
            $advanceAmount = (float) $bond->amount;
        }
        $advanceAmount = round($advanceAmount, 2);

        $financeAmount = round(max($bondAmount - $advanceAmount, 0), 2);

        $totalInstallments = (int) ($bond->installment_amount ?? $bond->no_of_months ?? 0);

        $monthlyEmi = $totalInstallments > 0 ? round($financeAmount / $totalInstallments, 2) : 0.0;

        // Everything that isn't the advance/booking payment counts toward the
        // EMI schedule; return/discount entries are debits netted out of it.
        $emiPayments = $payments->reject(fn ($p) => in_array($p->entry_type, self::ADVANCE_TYPES, true));
        $totalPaid = round(
            (float) $emiPayments->whereNotIn('entry_type', self::DEBIT_TYPES)->sum('amount')
            - (float) $emiPayments->whereIn('entry_type', self::DEBIT_TYPES)->sum('amount'),
            2
        );
        $totalPaid = max($totalPaid, 0.0);

        $dueDate = $bond->last_date
            ? ($bond->last_date instanceof Carbon ? $bond->last_date->copy()->startOfDay() : Carbon::parse($bond->last_date)->startOfDay())
            : null;

        // How many installments have a due date on or before "today".
        $emisDue = 0;
        if ($dueDate && $totalInstallments > 0 && ! $dueDate->greaterThan($asOf)) {
            $emisDue = min($dueDate->diffInMonths($asOf) + 1, $totalInstallments);
        }

        $expectedTillDate = round($emisDue * $monthlyEmi, 2);

        $outstanding = round(max($expectedTillDate - $totalPaid, 0), 2);
        $credit = round(max($totalPaid - $expectedTillDate, 0), 2);

        $remainingBalance = round(max($financeAmount - $totalPaid, 0), 2);

        // How many installments are fully covered by what's actually been paid
        // (independent of what's "due" — this is what makes bulk/advance
        // payments push the customer ahead without changing the EMI amount).
        $fullyPaidCount = $monthlyEmi > 0 ? (int) floor(($totalPaid + 0.0001) / $monthlyEmi) : 0;
        $fullyPaidCount = max(0, min($fullyPaidCount, $totalInstallments));

        $isFullyPaid = $financeAmount > 0 && $remainingBalance <= 0.009;
        if ($totalInstallments === 0) {
            $isFullyPaid = false; // no EMI schedule at all — nothing to be "fully paid" against.
        }

        $lastEmiNumber = $fullyPaidCount > 0 ? $fullyPaidCount : null;
        $lastEmiAmount = $lastEmiNumber ? self::installmentAmountForPosition($lastEmiNumber, $monthlyEmi, $financeAmount, $totalInstallments) : null;
        $lastEmiDate = null;
        $lastPayment = $emiPayments->whereNotIn('entry_type', self::DEBIT_TYPES)
            ->sortByDesc(fn ($p) => optional($p->entry_date instanceof Carbon ? $p->entry_date : ($p->entry_date ? Carbon::parse($p->entry_date) : null))->timestamp)
            ->first();
        if ($lastPayment && $lastPayment->entry_date) {
            $lastEmiDate = $lastPayment->entry_date instanceof Carbon ? $lastPayment->entry_date : Carbon::parse($lastPayment->entry_date);
        }

        $nextEmiNumber = null;
        $nextEmiAmount = null;
        $nextDueDate = null;
        if (! $isFullyPaid && $totalInstallments > 0 && $dueDate) {
            $candidate = $fullyPaidCount + 1;
            if ($candidate <= $totalInstallments) {
                $nextEmiNumber = $candidate;
                $nextEmiAmount = self::installmentAmountForPosition($nextEmiNumber, $monthlyEmi, $financeAmount, $totalInstallments);
                $nextDueDate = $dueDate->copy()->addMonths($nextEmiNumber - 1);
            }
        }

        $overdueDays = 0;
        $overdueHuman = null;
        if ($nextDueDate && $nextDueDate->lessThan($asOf) && $outstanding > 0.009) {
            $overdueDays = $nextDueDate->diffInDays($asOf);
            $overdueHuman = self::humanizeDuration($nextDueDate, $asOf);
        }

        if ($isFullyPaid) {
            $status = self::STATUS_FULLY_PAID;
        } elseif ($outstanding > 0.009) {
            $status = $overdueDays > $overdueDaysThreshold ? self::STATUS_OVERDUE : self::STATUS_PARTIAL;
        } elseif ($credit > 0.009) {
            $status = self::STATUS_AHEAD;
        } else {
            $status = self::STATUS_ON_TIME;
        }

        return [
            'bond_amount'         => $bondAmount,
            'advance_amount'      => $advanceAmount,
            'finance_amount'      => $financeAmount,
            'total_installments'  => $totalInstallments,
            'monthly_emi'         => $monthlyEmi,
            'due_date'            => $dueDate,
            'emis_due'            => $emisDue,
            'expected_till_date'  => $expectedTillDate,
            'total_paid'          => $totalPaid,
            'outstanding'         => $outstanding,
            'credit'              => $credit,
            'remaining_balance'   => $remainingBalance,
            'fully_paid_count'    => $fullyPaidCount,
            'last_emi_number'     => $lastEmiNumber,
            'last_emi_amount'     => $lastEmiAmount,
            'last_emi_date'       => $lastEmiDate,
            'next_emi_number'     => $nextEmiNumber,
            'next_emi_amount'     => $nextEmiAmount,
            'next_due_date'       => $nextDueDate,
            'overdue_days'        => $overdueDays,
            'overdue_human'       => $overdueHuman,
            'is_fully_paid'       => $isFullyPaid,
            'status'              => $status,
        ];
    }

    /**
     * Amount owed for a specific installment position. Every installment is
     * the flat monthly EMI except the last one, which absorbs the rounding
     * remainder so the schedule sums exactly to the finance amount.
     */
    public static function installmentAmountForPosition(int $position, float $monthlyEmi, float $financeAmount, int $totalInstallments): float
    {
        if ($totalInstallments <= 0) {
            return 0.0;
        }

        if ($position < $totalInstallments) {
            return round($monthlyEmi, 2);
        }

        return round($financeAmount - round($monthlyEmi, 2) * ($totalInstallments - 1), 2);
    }

    /**
     * "4 Years 6 Months 12 Days" style duration between two dates. Omits
     * zero-value units; falls back to "0 Days" when $to is not after $from.
     */
    public static function humanizeDuration(Carbon $from, Carbon $to): string
    {
        if ($to->lessThanOrEqualTo($from)) {
            return '0 Days';
        }

        $diff = $from->diff($to);
        $parts = [];

        if ($diff->y > 0) {
            $parts[] = $diff->y . ' Year' . ($diff->y > 1 ? 's' : '');
        }
        if ($diff->m > 0) {
            $parts[] = $diff->m . ' Month' . ($diff->m > 1 ? 's' : '');
        }
        if ($diff->d > 0 || empty($parts)) {
            $parts[] = $diff->d . ' Day' . ($diff->d !== 1 ? 's' : '');
        }

        return implode(' ', $parts);
    }

    /**
     * Display metadata (label / bootstrap color / emoji) for a status key.
     */
    public static function statusMeta(string $status): array
    {
        return match ($status) {
            self::STATUS_FULLY_PAID => ['label' => 'Fully Paid', 'emoji' => '🟣', 'color' => 'purple', 'badge' => 'bg-purple-subtle text-purple-emphasis'],
            self::STATUS_OVERDUE    => ['label' => 'Overdue', 'emoji' => '🔴', 'color' => 'danger', 'badge' => 'bg-danger'],
            self::STATUS_PARTIAL    => ['label' => 'Partial Payment', 'emoji' => '🟡', 'color' => 'warning', 'badge' => 'bg-warning text-dark'],
            self::STATUS_AHEAD      => ['label' => 'Ahead of Schedule', 'emoji' => '🔵', 'color' => 'info', 'badge' => 'bg-info-subtle text-info-emphasis'],
            self::STATUS_ON_TIME    => ['label' => 'On Time', 'emoji' => '🟢', 'color' => 'success', 'badge' => 'bg-success-subtle text-success-emphasis'],
            default                 => ['label' => ucfirst($status), 'emoji' => '', 'color' => 'secondary', 'badge' => 'bg-secondary'],
        };
    }
}
