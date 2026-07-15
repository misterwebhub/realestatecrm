<?php

namespace App\Console\Commands;

use App\Models\AuditLog;
use App\Models\Booking;
use App\Models\Plot;
use Carbon\Carbon;
use Illuminate\Console\Command;
use Illuminate\Support\Facades\DB;

class ExpireBookings extends Command
{
    protected $signature = 'bookings:expire';

    protected $description = 'Expire bookings past their expiry date and release plots';

    public function handle(): int
    {
        $now = Carbon::now();
        $bookings = Booking::where('status', 'active')->whereNotNull('expiry_date')->where('expiry_date', '<', $now->toDateString())->get();

        foreach ($bookings as $booking) {
            DB::transaction(function () use ($booking) {
                // compute penalty (use booking.penalty_percent or default 10%)
                $percent = $booking->penalty_percent ?? 10;
                $advance = (float) $booking->advance_amount;
                $penalty = round($advance * ($percent / 100), 2);

                $booking->status = 'expired';
                $booking->penalty_amount = $penalty;
                $booking->save();

                // release plot
                $plot = Plot::find($booking->plot_id);
                if ($plot && $plot->status === 'locked') {
                    $plot->status = 'available';
                    $plot->save();
                }

                AuditLog::create([
                    'user_id' => null,
                    'auditable_type' => Booking::class,
                    'auditable_id' => $booking->id,
                    'action' => 'booking_expired',
                    'meta' => [
                        'advance_amount' => $advance,
                        'plot_id' => $booking->plot_id,
                        'penalty_percent' => $percent,
                        'penalty_amount' => $penalty,
                    ],
                ]);
            });
        }

        $this->info('Expired ' . $bookings->count() . ' bookings.');

        return 0;
    }
}
