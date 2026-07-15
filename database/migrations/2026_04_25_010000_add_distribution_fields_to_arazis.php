<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('arazis', function (Blueprint $table) {
            $table->string('government_number')->nullable()->after('id')->unique()->nullable();
            $table->decimal('total_area', 12, 2)->default(0)->after('plot_number');
            $table->decimal('road_area', 12, 2)->default(0)->after('total_area');
            $table->decimal('park_area', 12, 2)->default(0)->after('road_area');
            $table->decimal('other_area', 12, 2)->default(0)->after('park_area');
            $table->decimal('sellable_area', 12, 2)->default(0)->after('other_area');
            $table->boolean('distribution_locked')->default(false)->after('sellable_area');
        });
    }

    public function down(): void
    {
        Schema::table('arazis', function (Blueprint $table) {
            $table->dropColumn(['government_number','total_area','road_area','park_area','other_area','sellable_area','distribution_locked']);
        });
    }
};
