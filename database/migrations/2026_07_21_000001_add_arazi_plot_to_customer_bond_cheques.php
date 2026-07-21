<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('customer_bond_cheques', function (Blueprint $table) {
            // Arazi is referenced by its legacy code (project convention), plot by id.
            $table->string('arazi_code', 100)->nullable()->after('customer_id');
            $table->unsignedBigInteger('plot_id')->nullable()->after('arazi_code');

            $table->index('arazi_code');
            $table->foreign('plot_id')->references('id')->on('plots')->nullOnDelete();
        });
    }

    public function down(): void
    {
        Schema::table('customer_bond_cheques', function (Blueprint $table) {
            $table->dropForeign(['plot_id']);
            $table->dropIndex(['arazi_code']);
            $table->dropColumn(['arazi_code', 'plot_id']);
        });
    }
};
