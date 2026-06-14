<?php

namespace App\Models;

use App\Models\Concerns\HasAraziCode;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class AraziInvestor extends Model
{
    use HasFactory;
    use HasAraziCode;

    protected $table = 'arazi_investor';

    protected $fillable = [
        'arazi_id', 'arazi_code', 'investor_id', 'amount', 'share_percent',
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
