<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        $indexes = collect(\DB::select("SHOW INDEX FROM arazis WHERE Key_name = 'arazis_legacy_arazi_code_unique'"));
        if ($indexes->isNotEmpty()) {
            Schema::table('arazis', function (Blueprint $table) {
                $table->dropUnique(['legacy_arazi_code']);
            });
        }
    }

    public function down(): void
    {
        Schema::table('arazis', function (Blueprint $table) {
            $table->unique('legacy_arazi_code');
        });
    }
};
