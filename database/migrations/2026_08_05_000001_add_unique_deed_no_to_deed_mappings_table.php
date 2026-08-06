<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Deed No must be unique across all deed mappings (each deed document
     * number identifies exactly one mapping, never shared between rows).
     */
    public function up(): void
    {
        $indexes = collect(DB::select('SHOW INDEX FROM deed_mappings'))->pluck('Key_name')->unique();

        if (! $indexes->contains('deed_mappings_deed_no_unique')) {
            Schema::table('deed_mappings', function (Blueprint $table) {
                $table->unique('deed_no', 'deed_mappings_deed_no_unique');
            });
        }
    }

    public function down(): void
    {
        $indexes = collect(DB::select('SHOW INDEX FROM deed_mappings'))->pluck('Key_name')->unique();

        if ($indexes->contains('deed_mappings_deed_no_unique')) {
            Schema::table('deed_mappings', function (Blueprint $table) {
                $table->dropUnique('deed_mappings_deed_no_unique');
            });
        }
    }
};
