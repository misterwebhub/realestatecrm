<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class AraziGroupItem extends Model
{
    use HasFactory;

    protected $fillable = [
        'arazi_group_id',
        'arazi_id',
    ];

    public function group()
    {
        return $this->belongsTo(AraziGroup::class, 'arazi_group_id');
    }

    public function arazi()
    {
        return $this->belongsTo(Arazi::class, 'arazi_id');
    }
}
