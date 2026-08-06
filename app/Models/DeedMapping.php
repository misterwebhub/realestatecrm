<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class DeedMapping extends Model
{
    use HasFactory;

    protected $fillable = [
        'arazi_id',
        'deed_no',
        'partner_id',
        'created_by',
    ];

    public function arazi()
    {
        return $this->belongsTo(Arazi::class);
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
