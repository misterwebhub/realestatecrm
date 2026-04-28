<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Commission extends Model
{
    use HasFactory;

    protected $fillable = [
        'sale_id', 'agent_id', 'percentage', 'amount', 'paid_at',
    ];

    protected $casts = [
        'paid_at' => 'date',
    ];

    public function sale()
    {
        return $this->belongsTo(Sale::class);
    }

    public function agent()
    {
        return $this->belongsTo(Agent::class);
    }
}
