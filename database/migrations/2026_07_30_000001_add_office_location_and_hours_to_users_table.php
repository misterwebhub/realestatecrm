<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('users', function (Blueprint $table) {
            if (! Schema::hasColumn('users', 'office_latitude')) {
                $table->decimal('office_latitude', 10, 7)->nullable()->after('address');
            }
            if (! Schema::hasColumn('users', 'office_longitude')) {
                $table->decimal('office_longitude', 10, 7)->nullable()->after('office_latitude');
            }
            if (! Schema::hasColumn('users', 'allowed_radius_meters')) {
                // Allowed login distance from the office point, in meters.
                $table->unsignedInteger('allowed_radius_meters')->nullable()->after('office_longitude');
            }
            if (! Schema::hasColumn('users', 'office_start_time')) {
                $table->time('office_start_time')->nullable()->after('allowed_radius_meters');
            }
            if (! Schema::hasColumn('users', 'office_end_time')) {
                $table->time('office_end_time')->nullable()->after('office_start_time');
            }
            if (! Schema::hasColumn('users', 'allow_after_hours')) {
                $table->boolean('allow_after_hours')->default(false)->after('office_end_time');
            }
        });
    }

    public function down(): void
    {
        Schema::table('users', function (Blueprint $table) {
            foreach (['office_latitude', 'office_longitude', 'allowed_radius_meters', 'office_start_time', 'office_end_time', 'allow_after_hours'] as $col) {
                if (Schema::hasColumn('users', $col)) {
                    $table->dropColumn($col);
                }
            }
        });
    }
};
