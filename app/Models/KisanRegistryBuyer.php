<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class KisanRegistryBuyer extends Model
{
    use HasFactory;

    protected $fillable = [
        'kisan_registry_id',
        'partner_id',
        'partner_name',
        'area',
    ];

    protected $casts = [
        'area' => 'decimal:2',
    ];

    public function kisanRegistry()
    {
        return $this->belongsTo(KisanRegistry::class);
    }

    public function partner()
    {
        return $this->belongsTo(Partner::class);
    }
}
