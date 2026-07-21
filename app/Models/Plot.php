<?php

namespace App\Models;

use App\Models\Concerns\HasAraziCode;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Plot extends Model
{
    use HasFactory;
    use HasAraziCode;

    protected $fillable = [
        'arazi_id',
        'arazi_code',
        'plot_number',
        'block',
        'title',
        'area',
        'coordinates',
        'latitude',
        'longitude',
        'description',
        'status',
    ];

    public function arazi()
    {
        return $this->belongsTo(Arazi::class, 'arazi_code', 'legacy_arazi_code');
    }

    public function holds()
    {
        return $this->hasMany(PlotHold::class);
    }

    public function activeHold()
    {
        return $this->hasOne(PlotHold::class)->where('status', 'active')->latestOfMany();
    }
}
