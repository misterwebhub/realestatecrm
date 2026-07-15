<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (! Schema::hasColumn('arazis', 'sale_amount_per_gaz')) {
            Schema::table('arazis', function (Blueprint $table) {
                $table->decimal('sale_amount_per_gaz', 12, 2)->nullable()->after('road_area');
            });
        }
    }

    public function down(): void
    {
        if (Schema::hasColumn('arazis', 'sale_amount_per_gaz')) {
            Schema::table('arazis', function (Blueprint $table) {
                $table->dropColumn('sale_amount_per_gaz');
            });
        }
    }
};
