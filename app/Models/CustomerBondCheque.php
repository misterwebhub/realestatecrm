<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class CustomerBondCheque extends Model
{
    use HasFactory;

    protected $fillable = [
        'customer_bond_id',
        'connected_account_id',
        'customer_id',
        'arazi_code',
        'plot_id',
        'cheque_number',
        'bank_name',
        'branch_name',
        'cheque_date',
        'action_due_date',
        'frequency_type',
        'amount',
        'status',
        'type',
        'notes',
        'created_by',
    ];

    protected $casts = [
        'cheque_date' => 'date',
        'action_due_date' => 'date',
        'amount' => 'decimal:2',
    ];

    public function connectedAccount()
    {
        return $this->belongsTo(\App\Models\ConnectedAccount::class);
    }

    public function customerBond()
    {
        return $this->belongsTo(CustomerBond::class);
    }

    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }

    public function arazi()
    {
        return $this->belongsTo(Arazi::class, 'arazi_code', 'legacy_arazi_code');
    }

    public function plot()
    {
        return $this->belongsTo(Plot::class);
    }

    public function creator()
    {
        return $this->belongsTo(\App\Models\User::class, 'created_by');
    }
}
