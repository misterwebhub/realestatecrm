<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('payments', function (Blueprint $table) {
            if (! Schema::hasColumn('payments', 'kisan_bond_id')) {
                $table->foreignId('kisan_bond_id')->nullable()->constrained('kisan_bonds')->nullOnDelete()->after('id');
            }
        });

        Schema::table('customer_bond_payments', function (Blueprint $table) {
            if (! Schema::hasColumn('customer_bond_payments', 'customer_bond_id')) {
                $table->foreignId('customer_bond_id')->nullable()->constrained('customer_bonds')->nullOnDelete()->after('id');
            }
        });
    }

    public function down(): void
    {
        Schema::table('customer_bond_payments', function (Blueprint $table) {
            if (Schema::hasColumn('customer_bond_payments', 'customer_bond_id')) {
                $table->dropConstrainedForeignId('customer_bond_id');
            }
        });

        Schema::table('payments', function (Blueprint $table) {
            if (Schema::hasColumn('payments', 'kisan_bond_id')) {
                $table->dropConstrainedForeignId('kisan_bond_id');
            }
        });
    }
};
