<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class KisanRegistry extends Model
{
    use HasFactory;

    protected $fillable = [
        'arazi_id',
        'arazi_deed_no',
        'name_deed_no',
        'sale_by',
        'buy_by',
        'total_gaz',
        'road_land_gaj',
        'registry_date',
        'registry_file_path',
        'registry_file_name',
        'stamp',
        'registrar_fees',
        'khasra',
        'commission',
        'brokari',
        'broker_name',
    ];

    protected $casts = [
        'registry_date' => 'date',
        'total_gaz'     => 'decimal:2',
        'road_land_gaj' => 'decimal:2',
        'stamp'         => 'decimal:2',
        'registrar_fees'=> 'decimal:2',
        'khasra'        => 'decimal:2',
        'commission'    => 'decimal:2',
        'brokari'       => 'decimal:2',
    ];

    public function arazi()
    {
        return $this->belongsTo(\App\Models\Arazi::class);
    }

    public function getTotalExpensesAttribute(): float
    {
        return (float) $this->stamp
            + (float) $this->registrar_fees
            + (float) $this->khasra
            + (float) $this->commission
            + (float) $this->brokari;
    }
}
