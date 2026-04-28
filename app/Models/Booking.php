<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Booking extends Model
{
    use HasFactory;

    protected $fillable = [
        'plot_id', 'customer_id', 'advance_amount', 'booking_date', 'expiry_date', 'penalty_percent', 'status', 'locked_at',
    ];

    protected $casts = [
        'booking_date' => 'date',
        'expiry_date' => 'date',
        'locked_at' => 'datetime',
    ];

    public function plot()
    {
        return $this->belongsTo(Plot::class);
    }

    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }
}
