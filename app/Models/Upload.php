<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Upload extends Model
{
    use HasFactory;

    protected $fillable = [
        'upload_category_id',
        'arazi_id',
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
