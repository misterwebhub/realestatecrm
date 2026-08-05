<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('users', function (Blueprint $table) {
            if (! Schema::hasColumn('users', 'allow_backdated_payments')) {
                // Per-user override: when true, this user may set a Customer
                // Payment's Entry Date earlier than today. Everyone else
                // (except Super Admin, who is always exempt) is blocked from
                // saving a back-dated entry.
                $table->boolean('allow_backdated_payments')->default(false)->after('disable_radius_login');
            }
        });
    }

    public function down(): void
    {
        Schema::table('users', function (Blueprint $table) {
            if (Schema::hasColumn('users', 'allow_backdated_payments')) {
                $table->dropColumn('allow_backdated_payments');
            }
        });
    }
};
