<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('plots', function (Blueprint $table) {
            $table->string('plot_number')->nullable()->after('arazi_id');
            $table->decimal('size', 12, 2)->nullable()->after('plot_number');
            $table->string('size_unit')->default('gaz')->after('size');
            $table->enum('type', ['residential', 'commercial'])->default('residential')->after('size_unit');
            $table->enum('status', ['available','locked','sold'])->default('available')->after('type');
            $table->decimal('price', 14, 2)->default(0)->after('status');
            $table->unique(['arazi_id', 'plot_number'], 'plots_arazi_plot_unique');
        });
    }

    public function down(): void
    {
        Schema::table('plots', function (Blueprint $table) {
            $table->dropUnique('plots_arazi_plot_unique');
            $table->dropColumn(['plot_number','size','size_unit','type','status','price']);
        });
    }
};
