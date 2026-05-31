<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('arazis', function (Blueprint $table) {
            // Drop the unique index if it exists (ignore if already dropped)
            try {
                $table->dropUnique(['legacy_arazi_code']);
            } catch (\Throwable $e) {
                // already removed or never existed
            }
        });
    }

    public function down(): void
    {
        Schema::table('arazis', function (Blueprint $table) {
            $table->unique('legacy_arazi_code');
        });
    }
};
