<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Expense extends Model
{
    use HasFactory;

    protected $fillable = [
        'arazi_id',
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
        return $this->belongsTo(Arazi::class);
    }

    public function creator()
    {
        return $this->belongsTo(\App\Models\User::class, 'created_by');
    }
}
