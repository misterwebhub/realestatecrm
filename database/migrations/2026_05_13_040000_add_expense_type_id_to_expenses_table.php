<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (Schema::hasTable('expenses') && ! Schema::hasColumn('expenses','expense_type_id')) {
            Schema::table('expenses', function (Blueprint $table) {
                $table->unsignedBigInteger('expense_type_id')->nullable()->after('type');
                $table->foreign('expense_type_id')->references('id')->on('expense_types')->onDelete('set null');
            });
        }
    }

    public function down(): void
    {
        if (Schema::hasTable('expenses') && Schema::hasColumn('expenses','expense_type_id')) {
            Schema::table('expenses', function (Blueprint $table) {
                $table->dropForeign(['expense_type_id']);
                $table->dropColumn('expense_type_id');
            });
        }
    }
};
