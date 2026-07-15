<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Drop the composite unique on (arazi_code, deed_no) so multiple registries
     * may share the same Arazi + Deed No (duplicate validation removed).
     */
    public function up(): void
    {
        $indexes = collect(DB::select('SHOW INDEX FROM registries'))->pluck('Key_name')->unique();

        if ($indexes->contains('registries_arazi_code_deed_no_unique')) {
            Schema::table('registries', function (Blueprint $table) {
                $table->dropUnique('registries_arazi_code_deed_no_unique');
            });
        }
    }

    public function down(): void
    {
        $indexes = collect(DB::select('SHOW INDEX FROM registries'))->pluck('Key_name')->unique();

        if (! $indexes->contains('registries_arazi_code_deed_no_unique')) {
            Schema::table('registries', function (Blueprint $table) {
                $table->unique(['arazi_code', 'deed_no'], 'registries_arazi_code_deed_no_unique');
            });
        }
    }
};
