<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Plot extends Model
{
    use HasFactory;

    protected $fillable = [
        'arazi_id',
        'block',
        'title',
        'area',
        'coordinates',
        'latitude',
        'longitude',
        'description',
    ];

    public function arazi()
    {
        return $this->belongsTo(Arazi::class);
    }
}
