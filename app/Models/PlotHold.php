<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class PlotHold extends Model
{
    use HasFactory;

    protected $fillable = [
        'plot_id',
        'arazi_code',
        'agent_id',
        'days',
        'start_date',
        'end_date',
        'customer_id',
        'customer_name',
        'customer_phone',
        'notes',
        'status',
        'created_by',
    ];

    protected $casts = [
        'start_date' => 'date',
        'end_date' => 'date',
    ];

    public function plot()
    {
        return $this->belongsTo(Plot::class);
    }

    public function agent()
    {
        return $this->belongsTo(Agent::class);
    }

    public function arazi()
    {
        return $this->belongsTo(Arazi::class, 'arazi_code', 'legacy_arazi_code');
    }

    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }

    public function creator()
    {
        return $this->belongsTo(\App\Models\User::class, 'created_by');
    }
}
