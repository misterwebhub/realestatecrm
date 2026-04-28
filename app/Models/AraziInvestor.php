<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class AraziInvestor extends Model
{
    use HasFactory;

    protected $table = 'arazi_investor';

    protected $fillable = [
        'arazi_id', 'investor_id', 'amount', 'share_percent',
    ];

    public function arazi()
    {
        return $this->belongsTo(Arazi::class);
    }

    public function investor()
    {
        return $this->belongsTo(Investor::class);
    }
}
