<?php

namespace App\Models;

use App\Models\Concerns\HasAraziCode;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class CustomerBondPayment extends Model
{
    use HasFactory;
    use HasAraziCode;

    protected $fillable = [
        'customer_bond_id',
        'customer_bond_cheque_id',
        'registry_id',
        'customer_id',
        'arazi_id',
        'arazi_code',
        'plot_id',
        'entry_no',
        'entry_date',
        'entry_type',
        'land_size',
        'witness_name',
        'amount',
        'payment_method',
        'taken_by_user_id',
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
        return $this->belongsTo(Arazi::class, 'arazi_code', 'legacy_arazi_code');
    }

    public function plot()
    {
        return $this->belongsTo(Plot::class);
    }

    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }

    public function takenByUser()
    {
        return $this->belongsTo(\App\Models\User::class, 'taken_by_user_id');
    }
}
