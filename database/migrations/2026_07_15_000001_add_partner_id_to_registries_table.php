<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (! Schema::hasTable('registries') || Schema::hasColumn('registries', 'partner_id')) {
            return;
        }

        Schema::table('registries', function (Blueprint $table) {
            $table->unsignedBigInteger('partner_id')->nullable()->after('arazi_code');
            $table->index('partner_id');
        });
    }

    public function down(): void
    {
        if (Schema::hasColumn('registries', 'partner_id')) {
            Schema::table('registries', function (Blueprint $table) {
                $table->dropColumn('partner_id');
            });
        }
    }
};
