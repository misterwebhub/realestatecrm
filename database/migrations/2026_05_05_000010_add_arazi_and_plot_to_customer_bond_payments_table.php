<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('customer_bond_payments', function (Blueprint $table) {
            if (! Schema::hasColumn('customer_bond_payments', 'arazi_id')) {
                $table->foreignId('arazi_id')->nullable()->constrained('arazis')->nullOnDelete()->after('customer_id');
            }

            if (! Schema::hasColumn('customer_bond_payments', 'plot_id')) {
                $table->foreignId('plot_id')->nullable()->constrained('plots')->nullOnDelete()->after('arazi_id');
            }
        });
    }

    public function down(): void
    {
        Schema::table('customer_bond_payments', function (Blueprint $table) {
            if (Schema::hasColumn('customer_bond_payments', 'plot_id')) {
                $table->dropConstrainedForeignId('plot_id');
            }

            if (Schema::hasColumn('customer_bond_payments', 'arazi_id')) {
                $table->dropConstrainedForeignId('arazi_id');
            }
        });
    }
};
