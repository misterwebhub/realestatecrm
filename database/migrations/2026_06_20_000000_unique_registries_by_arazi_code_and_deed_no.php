<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Replace the single-column unique on arazi_id with a composite unique on
     * (arazi_code, deed_no), so each Arazi may have multiple registries as long
     * as the deed number differs.
     */
    public function up(): void
    {
        // The unique index on arazi_id backs the foreign key, so the FK must be
        // dropped first; we re-add it afterwards on a plain (non-unique) index.
        $fkExists = collect(DB::select(
            "SELECT CONSTRAINT_NAME FROM information_schema.KEY_COLUMN_USAGE
             WHERE TABLE_NAME='registries' AND TABLE_SCHEMA=DATABASE()
             AND CONSTRAINT_NAME='registries_arazi_id_foreign'"
        ))->isNotEmpty();

        Schema::table('registries', function (Blueprint $table) use ($fkExists) {
            if ($fkExists) {
                $table->dropForeign('registries_arazi_id_foreign');
            }
        });

        $indexes = collect(DB::select('SHOW INDEX FROM registries'))->pluck('Key_name')->unique();
        Schema::table('registries', function (Blueprint $table) use ($indexes) {
            if ($indexes->contains('registries_arazi_id_unique')) {
                $table->dropUnique('registries_arazi_id_unique');
            }
        });

        // Re-create a plain index for the FK and restore the FK constraint.
        $indexes = collect(DB::select('SHOW INDEX FROM registries'))->pluck('Key_name')->unique();
        Schema::table('registries', function (Blueprint $table) use ($indexes) {
            if (! $indexes->contains('registries_arazi_id_index')) {
                $table->index('arazi_id', 'registries_arazi_id_index');
            }
            $table->foreign('arazi_id', 'registries_arazi_id_foreign')
                ->references('id')->on('arazis');
        });

        $indexes = collect(DB::select('SHOW INDEX FROM registries'))->pluck('Key_name')->unique();
        if (! $indexes->contains('registries_arazi_code_deed_no_unique')) {
            Schema::table('registries', function (Blueprint $table) {
                $table->unique(['arazi_code', 'deed_no'], 'registries_arazi_code_deed_no_unique');
            });
        }
    }

    public function down(): void
    {
        $fkExists = collect(DB::select(
            "SELECT CONSTRAINT_NAME FROM information_schema.KEY_COLUMN_USAGE
             WHERE TABLE_NAME='registries' AND TABLE_SCHEMA=DATABASE()
             AND CONSTRAINT_NAME='registries_arazi_id_foreign'"
        ))->isNotEmpty();

        Schema::table('registries', function (Blueprint $table) use ($fkExists) {
            if ($fkExists) {
                $table->dropForeign('registries_arazi_id_foreign');
            }
        });

        $indexes = collect(DB::select('SHOW INDEX FROM registries'))->pluck('Key_name')->unique();
        Schema::table('registries', function (Blueprint $table) use ($indexes) {
            if ($indexes->contains('registries_arazi_code_deed_no_unique')) {
                $table->dropUnique('registries_arazi_code_deed_no_unique');
            }
            if ($indexes->contains('registries_arazi_id_index')) {
                $table->dropIndex('registries_arazi_id_index');
            }
        });

        $indexes = collect(DB::select('SHOW INDEX FROM registries'))->pluck('Key_name')->unique();
        Schema::table('registries', function (Blueprint $table) use ($indexes) {
            if (! $indexes->contains('registries_arazi_id_unique')) {
                $table->unique('arazi_id', 'registries_arazi_id_unique');
            }
            $table->foreign('arazi_id', 'registries_arazi_id_foreign')
                ->references('id')->on('arazis');
        });
    }
};
