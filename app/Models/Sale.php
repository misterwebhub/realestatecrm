<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Sale extends Model
{
    use HasFactory;

    protected $fillable = [
        'plot_id', 'customer_id', 'broker_id', 'total_price', 'booking_id', 'registry_status', 'registry_date',
    ];

    protected $casts = [
        'registry_date' => 'date',
    ];

    public function plot()
    {
        return $this->belongsTo(Plot::class);
    }

    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }

    public function broker()
    {
        return $this->belongsTo(Agent::class, 'broker_id');
    }

    public function installments()
    {
        return $this->hasMany(Installment::class);
    }
}
