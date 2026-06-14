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

    /**
     * The "Arazi No" code used to identify this record in selects/lookups: legacy_arazi_code,
     * falling back to plot_number. If neither is set, returns a visible error placeholder
     * instead of inventing a synthetic code.
     */
    public function araziNoCode(): string
    {
        if ($this->legacy_arazi_code) {
            return $this->legacy_arazi_code;
        }

        if ($this->plot_number) {
            return $this->plot_number;
        }

        return '⚠ Missing Arazi No (#' . $this->id . ')';
    }

    /**
     * All Arazi records matching the given "Arazi No" code (legacy_arazi_code, falling back to
     * plot_number).
     */
    public static function arazisForCode(string $code): \Illuminate\Support\Collection
    {
        $code = trim($code);
        if ($code === '') {
            return collect();
        }

        $byLegacy = static::where('legacy_arazi_code', $code)->get();
        if ($byLegacy->isNotEmpty()) {
            return $byLegacy;
        }

        return static::where('plot_number', $code)->get();
    }

    /**
     * IDs of all Arazi records matching the given "Arazi No" code.
     */
    public static function idsForCode(string $code): array
    {
        return static::arazisForCode($code)->pluck('id')->all();
    }

    /**
     * All Plot records belonging to any Arazi record matching the given "Arazi No" code
     * (legacy_arazi_code, falling back to plot_number).
     */
    public static function plotsForCode(string $code): \Illuminate\Support\Collection
    {
        $araziIds = static::idsForCode($code);
        if (empty($araziIds)) {
            return collect();
        }

        return Plot::whereIn('arazi_id', $araziIds)->get();
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
