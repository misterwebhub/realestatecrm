<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class CustomerBond extends Model
{
    use HasFactory;

    protected $fillable = [
        'customer_id',
        'arazi_id',
        'bond_no',
        'bond_date',
        'bond_amount',
        'witness_name',
        'notes',
    ];

    protected $casts = [
        'bond_date' => 'date',
    ];

    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }

    public function arazi()
    {
        return $this->belongsTo(Arazi::class);
    }
}
