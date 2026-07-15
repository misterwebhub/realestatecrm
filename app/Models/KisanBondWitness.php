<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class KisanBondWitness extends Model
{
    use HasFactory;

    protected $fillable = [
        'kisan_bond_id',
        'name',
        'id_no',
        'mobile',
    ];

    public function bond()
    {
        return $this->belongsTo(KisanBond::class, 'kisan_bond_id');
    }
}
