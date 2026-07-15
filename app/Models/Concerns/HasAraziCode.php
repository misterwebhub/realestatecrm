<?php

namespace App\Models\Concerns;

use App\Models\Arazi;

/**
 * Keeps the denormalised `arazi_code` column in sync with `arazi_id`.
 *
 * Because legacy_arazi_code is NOT unique (one code can map to many arazi
 * rows), arazi_id remains the precise FK while arazi_code is the
 * human/lookup key used across the app. Whenever a model is saved with an
 * arazi_id, we (re)derive arazi_code from arazis.legacy_arazi_code.
 *
 * If a record is created with only an arazi_code (no arazi_id), we resolve
 * arazi_id to the first matching arazi row for that code.
 */
trait HasAraziCode
{
    public static function bootHasAraziCode(): void
    {
        static::saving(function ($model) {
            // arazi_id set but code missing/dirty -> derive code from id.
            if (!empty($model->arazi_id) && ($model->isDirty('arazi_id') || empty($model->arazi_code))) {
                $code = Arazi::whereKey($model->arazi_id)->value('legacy_arazi_code');
                if (!empty($code)) {
                    $model->arazi_code = $code;
                }
            }

            // Only code provided -> resolve to first matching arazi_id.
            if (empty($model->arazi_id) && !empty($model->arazi_code)) {
                $id = Arazi::where('legacy_arazi_code', $model->arazi_code)->value('id');
                if (!empty($id)) {
                    $model->arazi_id = $id;
                }
            }
        });
    }

    /**
     * Scope: filter records by arazi_code (the unique-ish lookup key).
     */
    public function scopeForAraziCode($query, ?string $code)
    {
        if ($code === null || $code === '') {
            return $query;
        }
        return $query->where($this->getTable() . '.arazi_code', $code);
    }
}
