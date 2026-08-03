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
            ->with(['arazi', 'plot', 'plots'])
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

                // Registry expired without completion — release every plot it
                // covers back to available (only if it was locked as
                // 'registry' by us).
                foreach ($registry->allPlots() as $plot) {
                    if ($plot->status === 'registry') {
                        $plot->forceFill(['status' => 'available'])->save();
                    }
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
     * Whenever a registry is created/confirmed, every plot it covers should
     * automatically be marked as "Registry" (locked) so none of them show up
     * as available/booked elsewhere in the app — not just the first plot.
     */
    public function markPlotRegistryDone(Registry $registry): void
    {
        foreach ($registry->allPlots() as $plot) {
            if ($plot->status !== 'registry') {
                $plot->forceFill(['status' => 'registry'])->save();
            }
        }
    }
}
