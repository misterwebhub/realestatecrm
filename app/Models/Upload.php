<?php

namespace App\Models;

use App\Models\Concerns\HasAraziCode;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Upload extends Model
{
    use HasFactory;
    use HasAraziCode;

    protected $fillable = [
        'upload_category_id',
        'arazi_id',
        'arazi_code',
        'label',
        'file_path',
        'mime',
        'size',
    ];

    public function category()
    {
        return $this->belongsTo(UploadCategory::class, 'upload_category_id');
    }

    public function arazi()
    {
        return $this->belongsTo(Arazi::class);
    }
}
