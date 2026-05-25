<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Arazi extends Model
{
    use HasFactory;

    protected $fillable = [
        'legacy_arazi_code',
        'kisan_id',
        'location',
        'unit',
        'size',
        'road_area',
        'sale_amount_per_gaz',
        'coordinates',
        'status',
    ];

    protected $appends = ['saleable_area'];

    public function kisan()
    {
        return $this->belongsTo(Kisan::class);
    }

    public function plots()
    {
        return $this->hasMany(Plot::class);
    }

    public function registry()
    {
        return $this->hasOne(Registry::class);
    }

    public function payments()
    {
        return $this->hasMany(Payment::class);
    }

    public function documents()
    {
        return $this->hasMany(AraziDocument::class);
    }

    public function expenses()
    {
        return $this->hasMany(\App\Models\Expense::class);
    }

    public function getOriginalValueAttribute()
    {
        $rate = (float) ($this->sale_amount_per_gaz ?? 0);
        $area = (float) $this->saleable_area;
        return round($rate * $area, 2);
    }

    public function getPriceAfterExpensesAttribute()
    {
        $original = $this->original_value;
        $expenses = $this->expenses()->sum('amount');
        return round($original + (float) $expenses, 2);
    }

    public function getSaleableAreaAttribute()
    {
        $size = (float) ($this->size ?? 0);
        $road = (float) ($this->road_area ?? 0);

        $saleable = $size - $road;

        return $saleable > 0 ? round($saleable, 2) : 0;
    }
}
