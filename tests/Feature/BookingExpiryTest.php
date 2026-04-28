<?php

namespace Tests\Feature;

use App\Models\Booking;
use App\Models\Plot;
use App\Models\User;
use Carbon\Carbon;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Tests\TestCase;

class BookingExpiryTest extends TestCase
{
    use RefreshDatabase;

    public function test_expire_bookings_sets_status_and_penalty()
    {
        // create an arazi and a plot, then booking
        $kisan = \App\Models\Kisan::create([
            'name' => 'Test Kisan',
            'mobile' => '03001234567',
            'location' => 'Test Location',
        ]);

        $arazi = \App\Models\Arazi::create([
            'kisan_id' => $kisan->id,
            'plot_number' => 'A-100',
            'size' => '10 marla',
            'location' => 'Test Location',
            'status' => 'available',
        ]);

        $plot = \App\Models\Plot::create([
            'arazi_id' => $arazi->id,
            'title' => 'P-100',
            'coordinates' => null,
            'description' => 'Test plot',
        ]);

        $booking = Booking::create([
            'plot_id' => $plot->id,
            'customer_id' => null,
            'advance_amount' => 1000,
            'booking_date' => Carbon::now()->subDays(10)->toDateString(),
            'expiry_date' => Carbon::now()->subDays(1)->toDateString(),
            'penalty_percent' => 10,
            'status' => 'active',
        ]);

        $this->artisan('bookings:expire')->assertExitCode(0);

        $booking->refresh();

        $this->assertEquals('expired', $booking->status);
        $this->assertEquals(100.00, (float) $booking->penalty_amount);
    }
}
