<?php

namespace App\Services;

use App\Models\Registry;
use Carbon\Carbon;

class RegistryLifecycleService
{
    public function expirePendingRegistries(): int
    {
        $expiredCount = 0;

        Registry::query()
            ->with('arazi')
            ->where('status', 'pending')
            ->whereNotNull('due_date')
            ->whereDate('due_date', '<', Carbon::today())
            ->each(function (Registry $registry) use (&$expiredCount) {
                $registry->forceFill([
                    'status' => 'cancelled',
                    'payment_status' => 'expired',
                    'lock_status' => 'unlock',
                ])->save();

                if ($registry->arazi) {
                    $registry->arazi->forceFill(['status' => 'available'])->save();
                }

                // Registry expired without completion — release the plot back
                // to available (only if it was locked as 'registry' by us).
                if ($registry->plot && $registry->plot->status === 'registry') {
                    $registry->plot->forceFill(['status' => 'available'])->save();
                }

                $expiredCount++;
            });

        return $expiredCount;
    }

    public function markRegistryPending(Registry $registry): void
    {
        $registry->forceFill([
            'status' => 'pending',
            'payment_status' => 'pending',
            'due_date' => $registry->due_date ?? Carbon::now()->addDays(15),
            'lock_status' => 'lock',
        ])->save();

        if ($registry->arazi) {
            $registry->arazi->forceFill(['status' => 'sold'])->save();
        }

        $this->markPlotRegistryDone($registry);
    }

    public function markRegistryPaid(Registry $registry): void
    {
        $registry->forceFill([
            'status' => 'completed',
            'payment_status' => 'completed',
            'due_date' => $registry->due_date ?? Carbon::now()->addDays(15),
            'lock_status' => 'lock',
        ])->save();

        if ($registry->arazi) {
            $registry->arazi->forceFill(['status' => 'sold'])->save();
        }

        $this->markPlotRegistryDone($registry);
    }

    /**
     * Whenever a registry is created/confirmed for a plot, the plot(s) it
     * covers should automatically be marked as "Registry" (locked) so they
     * no longer show up as available/booked elsewhere in the app.
     */
    public function markPlotRegistryDone(Registry $registry): void
    {
        if ($registry->plot && $registry->plot->status !== 'registry') {
            $registry->plot->forceFill(['status' => 'registry'])->save();
        }
    }
}
