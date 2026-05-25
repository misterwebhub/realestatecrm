<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('kisan_bond_arazi', function (Blueprint $table) {
            if (! Schema::hasColumn('kisan_bond_arazi', 'land_size')) {
                $table->decimal('land_size', 12, 2)->default(0)->after('arazi_id');
            }

            if (! Schema::hasColumn('kisan_bond_arazi', 'sale_land')) {
                $table->decimal('sale_land', 12, 2)->default(0)->after('land_size');
            }

            if (! Schema::hasColumn('kisan_bond_arazi', 'sale_rate')) {
                $table->decimal('sale_rate', 12, 2)->default(0)->after('sale_land');
            }

            if (! Schema::hasColumn('kisan_bond_arazi', 'sale_amount')) {
                $table->decimal('sale_amount', 14, 2)->default(0)->after('sale_rate');
            }
        });
    }

    public function down(): void
    {
        Schema::table('kisan_bond_arazi', function (Blueprint $table) {
            $table->dropColumn(['land_size', 'sale_land', 'sale_rate', 'sale_amount']);
        });
    }
};
