<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class CustomerBondPayment extends Model
{
    use HasFactory;

    protected $fillable = [
        'customer_bond_id',
        'registry_id',
        'customer_id',
        'arazi_id',
        'plot_id',
        'entry_no',
        'entry_date',
        'entry_type',
        'land_size',
        'witness_name',
        'amount',
        'payment_method',
        'remarks',
    ];

    protected $casts = [
        'entry_date' => 'date',
    ];

    public function registry()
    {
        return $this->belongsTo(Registry::class);
    }

    public function customerBond()
    {
        return $this->belongsTo(CustomerBond::class);
    }

    public function arazi()
    {
        return $this->belongsTo(Arazi::class);
    }

    public function plot()
    {
        return $this->belongsTo(Plot::class);
    }

    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }
}
