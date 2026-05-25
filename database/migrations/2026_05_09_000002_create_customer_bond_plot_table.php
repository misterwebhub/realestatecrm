<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (! Schema::hasTable('customer_bond_plot')) {
            Schema::create('customer_bond_plot', function (Blueprint $table) {
                $table->id();
                $table->foreignId('customer_bond_id')->constrained('customer_bonds')->cascadeOnDelete();
                $table->foreignId('plot_id')->constrained('plots')->cascadeOnDelete();
                $table->timestamps();

                $table->unique(['customer_bond_id', 'plot_id'], 'customer_bond_plot_unique');
            });
        }
    }

    public function down(): void
    {
        Schema::dropIfExists('customer_bond_plot');
    }
};
