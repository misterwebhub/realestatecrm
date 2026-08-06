<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class DeedMergingItem extends Model
{
    use HasFactory;

    protected $fillable = [
        'deed_merging_id',
        'arazi_id',
        'deed_no',
    ];

    public function deedMerging()
    {
        return $this->belongsTo(DeedMerging::class);
    }

    public function arazi()
    {
        return $this->belongsTo(Arazi::class);
    }
}
