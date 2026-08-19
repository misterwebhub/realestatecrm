<?php

namespace App\Console\Commands;

use App\Models\Booking;
use App\Models\CustomerBond;
use App\Models\Plot;
use App\Models\Registry;
use Illuminate\Console\Command;

class FindOrphanedBookedPlots extends Command
{
    protected $signature = 'plots:find-orphaned-booked {--fix : Reset the found plots back to available}';

    protected $description = 'List plots whose status is "booked" but have no CustomerBond, Registry, or active Booking behind them (read-only unless --fix is passed)';

    public function handle(): int
    {
        $plots = Plot::where('status', 'booked')->get();
        $this->info('Total plots marked booked: ' . $plots->count());

        $orphans = $plots->filter(function (Plot $p) {
            $hasBond = CustomerBond::whereHas('plots', fn ($q) => $q->where('plots.id', $p->id))->exists();
            $hasRegistry = Registry::forPlot($p->id)->exists();
            $hasBooking = Booking::where('plot_id', $p->id)
                ->where(function ($q) {
                    $q->whereNull('status')->orWhere('status', '!=', 'expired');
                })->exists();

            return ! $hasBond && ! $hasRegistry && ! $hasBooking;
        })->values();

        $this->info('Booked but no bond / registry / active booking behind them: ' . $orphans->count());

        if ($orphans->isEmpty()) {
            return 0;
        }

        $this->table(
            ['Plot ID', 'Title', 'Arazi Code', 'Updated At'],
            $orphans->map(fn (Plot $p) => [$p->id, $p->title, $p->arazi_code, $p->updated_at])
        );

        if ($this->option('fix')) {
            if (! $this->confirm('Reset these ' . $orphans->count() . ' plot(s) to "available"? This writes to the DB.')) {
                $this->warn('Aborted — no changes made.');
                return 0;
            }

            Plot::whereIn('id', $orphans->pluck('id'))->update(['status' => 'available']);
            $this->info('Reset ' . $orphans->count() . ' plot(s) to available.');
        } else {
            $this->line('Run again with --fix to reset these plots back to available.');
        }

        return 0;
    }
}
