<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('customer_bond_payments', function (Blueprint $table) {
            $table->decimal('land_size', 10, 2)->nullable()->after('entry_type');
            $table->string('witness_name', 150)->nullable()->after('land_size');
        });
    }

    public function down(): void
    {
        Schema::table('customer_bond_payments', function (Blueprint $table) {
            $table->dropColumn(['land_size', 'witness_name']);
        });
    }
};
