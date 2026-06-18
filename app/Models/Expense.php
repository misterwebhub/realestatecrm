<?php

namespace App\Models;

use App\Models\Concerns\HasAraziCode;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Expense extends Model
{
    use HasFactory;
    use HasAraziCode;

    protected $fillable = [
        'arazi_id',
        'arazi_code',
        'type',
        'expense_type_id',
        'label',
        'amount',
        'incurred_at',
        'notes',
        'created_by',
    ];

    protected $dates = ['incurred_at'];

    public function arazi()
    {
        return $this->belongsTo(Arazi::class, 'arazi_code', 'legacy_arazi_code');
    }

    public function creator()
    {
        return $this->belongsTo(\App\Models\User::class, 'created_by');
    }
}
