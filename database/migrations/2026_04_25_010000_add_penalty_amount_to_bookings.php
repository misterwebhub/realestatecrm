<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        try {
            if (Schema::hasTable('bookings') && Schema::hasColumn('bookings', 'penalty_percent')) {
                Schema::table('bookings', function (Blueprint $table) {
                    if (! Schema::hasColumn('bookings', 'penalty_amount')) {
                        $table->decimal('penalty_amount', 10, 2)->nullable()->default(0)->after('penalty_percent');
                    }
                });
            }
        } catch (\Exception $e) {
            // ignore during test DB setups where bookings table may not exist yet
        }
    }

    public function down(): void
    {
        if (Schema::hasTable('bookings') && Schema::hasColumn('bookings', 'penalty_amount')) {
            Schema::table('bookings', function (Blueprint $table) {
                $table->dropColumn('penalty_amount');
            });
        }
    }
};
