<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        // Allow cheques to exist without a bond (unassigned). Drop the FK,
        // make the column nullable, then re-add the FK with nullOnDelete.
        Schema::table('customer_bond_cheques', function ($table) {
            $table->dropForeign(['customer_bond_id']);
        });

        DB::statement('ALTER TABLE customer_bond_cheques MODIFY customer_bond_id BIGINT UNSIGNED NULL');

        Schema::table('customer_bond_cheques', function ($table) {
            $table->foreign('customer_bond_id')->references('id')->on('customer_bonds')->nullOnDelete();
        });
    }

    public function down(): void
    {
        Schema::table('customer_bond_cheques', function ($table) {
            $table->dropForeign(['customer_bond_id']);
        });

        DB::statement('ALTER TABLE customer_bond_cheques MODIFY customer_bond_id BIGINT UNSIGNED NOT NULL');

        Schema::table('customer_bond_cheques', function ($table) {
            $table->foreign('customer_bond_id')->references('id')->on('customer_bonds')->cascadeOnDelete();
        });
    }
};
