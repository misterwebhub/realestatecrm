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
        return $this->hasMany(Plot::class, 'arazi_code', 'legacy_arazi_code');
    }

    /**
     * The "Arazi No" code used to identify this record in selects/lookups: legacy_arazi_code.
     * If it is not set, returns a visible error placeholder instead of inventing a synthetic code.
     */
    public function araziNoCode(): string
    {
        if ($this->legacy_arazi_code) {
            return $this->legacy_arazi_code;
        }

        return '⚠ Missing Arazi No (#' . $this->id . ')';
    }

    /**
     * All Arazi records matching the given "Arazi No" code (legacy_arazi_code).
     */
    public static function arazisForCode(string $code): \Illuminate\Support\Collection
    {
        $code = trim($code);
        if ($code === '') {
            return collect();
        }

        return static::where('legacy_arazi_code', $code)->get();
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
        $code = trim($code);
        if ($code === '') {
            return collect();
        }

        return Plot::where('arazi_code', $code)->get();
    }

    public function registry()
    {
        return $this->hasOne(Registry::class, 'arazi_code', 'legacy_arazi_code');
    }

    /**
     * Deed Mapping: this arazi row's (i.e. this kisan's share's) assigned
     * Deed No + Partner. One-to-one — a given Arazi row has at most one
     * deed mapping.
     */
    public function deedMapping()
    {
        return $this->hasOne(DeedMapping::class);
    }

    public function documents()
    {
        return $this->hasMany(AraziDocument::class, 'arazi_code', 'legacy_arazi_code');
    }

    public function expenses()
    {
        // Aggregate expenses for all Arazi rows sharing the same legacy_arazi_code
        return $this->hasMany(\App\Models\Expense::class, 'arazi_code', 'legacy_arazi_code');
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
