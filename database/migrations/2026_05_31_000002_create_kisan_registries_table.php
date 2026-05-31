<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::create('kisan_registries', function (Blueprint $table) {
            $table->id();
            $table->string('arazi_deed_no')->nullable();          // ARAZI DEED No.
            $table->string('name_deed_no')->nullable();           // NAME DEED No.
            $table->string('sale_by')->nullable();                // SALE BY (seller name)
            $table->string('buy_by')->nullable();                 // BUY BY (buyer name)
            $table->decimal('total_gaz', 12, 2)->nullable();     // Total GAZ
            $table->decimal('road_land_gaj', 12, 2)->nullable(); // ROAD LAND (GAJ)
            $table->date('registry_date')->nullable();            // DATE
            $table->string('registry_file_path')->nullable();     // UPLOAD REGISTRY (file)
            $table->string('registry_file_name')->nullable();     // original filename

            // Registry Expenses
            $table->decimal('stamp', 12, 2)->default(0);          // STAMP
            $table->decimal('registrar_fees', 12, 2)->default(0); // REGISTRAR FEES
            $table->decimal('khasra', 12, 2)->default(0);         // KHASRA
            $table->decimal('commission', 12, 2)->default(0);     // COMMISSION
            $table->decimal('brokari', 12, 2)->default(0);        // BROKARI

            $table->string('broker_name')->nullable();            // Broker Name

            $table->timestamps();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('kisan_registries');
    }
};
