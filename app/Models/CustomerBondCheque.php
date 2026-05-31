<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class CustomerBondCheque extends Model
{
    use HasFactory;

    protected $fillable = [
        'customer_bond_id',
        'customer_id',
        'cheque_number',
        'bank_name',
        'branch_name',
        'cheque_date',
        'amount',
        'status',
        'type',
        'notes',
        'created_by',
    ];

    protected $casts = [
        'cheque_date' => 'date',
        'amount' => 'decimal:2',
    ];

    public function customerBond()
    {
        return $this->belongsTo(CustomerBond::class);
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
