<?php

namespace App\Models;

use App\Models\Concerns\HasAraziCode;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class CustomerBond extends Model
{
    use HasFactory;
    use HasAraziCode;

    protected $fillable = [
        'customer_id',
        'arazi_id',
        'arazi_code',
        'bond_no',
        'bond_date',
        'bond_amount',
        'witness_name',
        'notes',
        'mobile',
        'land_size',
        'sale_land',
        'sale_rate',
        'total_amount',
        'bayana_mode',
        'bond_type',
        'amount',
        'installment_amount',
        'balance',
        'last_date',
        'no_of_months',
        'expiry_date',
        'broker_id',
        'broker_payment',
        'broker_paid',
        'broker_balance',
        'broker_comment',
        'customer_comment',
        'nominee_details',
    ];

    protected $casts = [
        'bond_date' => 'date',
        'last_date' => 'date',
        'expiry_date' => 'date',
    ];

    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }

    public function arazi()
    {
        return $this->belongsTo(Arazi::class, 'arazi_code', 'legacy_arazi_code');
    }

    public function plots()
    {
        return $this->belongsToMany(Plot::class, 'customer_bond_plot')
            ->withPivot(['sale_amount'])
            ->withTimestamps();
    }

    public function witnesses()
    {
        return $this->hasMany(CustomerBondWitness::class);
    }

    public function payments()
    {
        return $this->hasMany(CustomerBondPayment::class);
    }

    public function cheques()
    {
        return $this->hasMany(CustomerBondCheque::class);
    }

    public function broker()
    {
        return $this->belongsTo(Agent::class, 'broker_id');
    }

    protected static function booted(): void
    {
        // Intentionally left blank: do not change Arazi.status here.
    }
}
