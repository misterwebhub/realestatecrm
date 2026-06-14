<?php

namespace App\Models;

use App\Models\Concerns\HasAraziCode;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class KisanBond extends Model
{
    use HasFactory;
    use HasAraziCode;

    protected $fillable = [
        'kisan_id',
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
        'balance',
        'last_date',
        'broker_id',
        'broker_payment',
        'broker_paid',
        'broker_balance',
        'broker_comment',
        'kisan_comment',
    ];

    protected $casts = [
        'bond_date' => 'date',
    ];

    public function kisan()
    {
        return $this->belongsTo(Kisan::class);
    }

    public function arazi()
    {
        return $this->belongsTo(Arazi::class);
    }

    public function arazis()
    {
        return $this->belongsToMany(Arazi::class, 'kisan_bond_arazi')
            ->withPivot(['arazi_code', 'land_size', 'sale_land', 'sale_rate', 'sale_amount'])
            ->withTimestamps();
    }

    public function broker()
    {
        return $this->belongsTo(Agent::class, 'broker_id');
    }

    public function witnesses()
    {
        return $this->hasMany(KisanBondWitness::class);
    }

    public function payments()
    {
        return $this->hasMany(Payment::class);
    }

    public function getWitnessNamesAttribute()
    {
        return $this->witnesses->pluck('name')->all();
    }

    protected static function booted(): void
    {
        // Do not alter Arazi.status here; leave Arazi status management to controller logic if needed.
    }
}
