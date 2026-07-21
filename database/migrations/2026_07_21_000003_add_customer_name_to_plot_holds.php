<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('plot_holds', function (Blueprint $table) {
            // Free-text customer name for holds where the customer is not a saved record.
            $table->string('customer_name', 150)->nullable()->after('customer_id');
        });
    }

    public function down(): void
    {
        Schema::table('plot_holds', function (Blueprint $table) {
            $table->dropColumn('customer_name');
        });
    }
};
