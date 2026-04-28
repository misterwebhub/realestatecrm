<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class CustomerBondWitness extends Model
{
    use HasFactory;

    protected $fillable = [
        'customer_bond_id',
        'name',
        'id_no',
        'mobile',
    ];

    public function bond()
    {
        return $this->belongsTo(CustomerBond::class, 'customer_bond_id');
    }
}
