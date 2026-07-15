<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (!Schema::hasColumn('arazis', 'unit')) {
            Schema::table('arazis', function (Blueprint $table) {
                $table->string('unit', 20)->default('gaz')->after('road_area');
            });
        }
    }

    public function down(): void
    {
        if (Schema::hasColumn('arazis', 'unit')) {
            Schema::table('arazis', function (Blueprint $table) {
                $table->dropColumn('unit');
            });
        }
    }
};
