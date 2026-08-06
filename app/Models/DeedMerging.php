<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class DeedMerging extends Model
{
    use HasFactory;

    protected $fillable = [
        'arazi_code',
        'merged_deed_no',
        'partner_id',
        'created_by',
    ];

    public function items()
    {
        return $this->hasMany(DeedMergingItem::class);
    }

    public function partner()
    {
        return $this->belongsTo(Partner::class);
    }

    public function creator()
    {
        return $this->belongsTo(User::class, 'created_by');
    }
}
