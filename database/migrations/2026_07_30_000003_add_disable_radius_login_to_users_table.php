<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('users', function (Blueprint $table) {
            if (! Schema::hasColumn('users', 'disable_radius_login')) {
                // Per-user override: when true, this user is exempt from the
                // GPS radius login check regardless of the global default
                // location/radius or the global "radius login enabled" switch.
                $table->boolean('disable_radius_login')->default(false)->after('allow_after_hours');
            }
        });
    }

    public function down(): void
    {
        Schema::table('users', function (Blueprint $table) {
            if (Schema::hasColumn('users', 'disable_radius_login')) {
                $table->dropColumn('disable_radius_login');
            }
        });
    }
};
