<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('agents', function (Blueprint $table) {
            if (! Schema::hasColumn('agents', 'broker_type')) {
                $table->enum('broker_type', ['kisan', 'customer', 'office'])->default('office')->after('id');
                $table->index('broker_type');
            }
        });
    }

    public function down(): void
    {
        Schema::table('agents', function (Blueprint $table) {
            if (Schema::hasColumn('agents', 'broker_type')) {
                $table->dropIndex(['broker_type']);
                $table->dropColumn('broker_type');
            }
        });
    }
};
