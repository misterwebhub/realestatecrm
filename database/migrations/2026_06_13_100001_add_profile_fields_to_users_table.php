<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('users', function (Blueprint $table) {
            $table->string('username')->unique()->nullable()->after('name');
            $table->string('mobile')->nullable()->after('email');
            $table->string('secondary_mobile')->nullable()->after('mobile');
            $table->string('address')->nullable()->after('secondary_mobile');
            $table->boolean('is_active')->default(true)->after('address');
        });
    }

    public function down(): void
    {
        Schema::table('users', function (Blueprint $table) {
            $table->dropColumn(['username', 'mobile', 'secondary_mobile', 'address', 'is_active']);
        });
    }
};
