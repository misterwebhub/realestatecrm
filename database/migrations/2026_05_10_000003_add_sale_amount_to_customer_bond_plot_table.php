<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (Schema::hasTable('customer_bond_plot') && ! Schema::hasColumn('customer_bond_plot', 'sale_amount')) {
            Schema::table('customer_bond_plot', function (Blueprint $table) {
                $table->decimal('sale_amount', 15, 2)->nullable()->after('plot_id');
            });
        }
    }

    public function down(): void
    {
        if (Schema::hasTable('customer_bond_plot') && Schema::hasColumn('customer_bond_plot', 'sale_amount')) {
            Schema::table('customer_bond_plot', function (Blueprint $table) {
                $table->dropColumn('sale_amount');
            });
        }
    }
};
