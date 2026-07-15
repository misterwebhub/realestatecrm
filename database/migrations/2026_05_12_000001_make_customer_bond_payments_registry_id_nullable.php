<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (! Schema::hasTable('customer_bond_payments') || ! Schema::hasColumn('customer_bond_payments', 'registry_id')) {
            return;
        }

        $driver = Schema::getConnection()->getDriverName();

        if ($driver === 'mysql') {
            Schema::table('customer_bond_payments', function (Blueprint $table) {
                $table->dropForeign(['registry_id']);
            });

            DB::statement('ALTER TABLE customer_bond_payments MODIFY registry_id BIGINT UNSIGNED NULL');

            Schema::table('customer_bond_payments', function (Blueprint $table) {
                $table->foreign('registry_id')->references('id')->on('registries')->nullOnDelete();
            });
        } elseif ($driver === 'sqlite') {
            // SQLite: recreate table is heavy; skip if not needed in local sqlite tests
        }
    }

    public function down(): void
    {
        // Reverting NOT NULL may fail if bond-only payments exist; leave schema forward-compatible.
    }
};
