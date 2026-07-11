<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class AraziGroup extends Model
{
    use HasFactory;

    protected $fillable = [
        'name',
        'map_name',
        'notes',
        'created_by',
    ];

    public function items()
    {
        return $this->hasMany(AraziGroupItem::class);
    }

    public function arazis()
    {
        return $this->belongsToMany(Arazi::class, 'arazi_group_items', 'arazi_group_id', 'arazi_id')
            ->withTimestamps();
    }

    public function creator()
    {
        return $this->belongsTo(User::class, 'created_by');
    }
}
