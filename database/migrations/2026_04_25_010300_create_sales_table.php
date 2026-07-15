<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::create('sales', function (Blueprint $table) {
            $table->id();
            $table->foreignId('plot_id')->constrained()->cascadeOnDelete();
            $table->foreignId('customer_id')->constrained()->cascadeOnDelete();
            $table->foreignId('broker_id')->nullable()->constrained('agents')->nullOnDelete();
            $table->decimal('total_price', 14, 2)->default(0);
            $table->foreignId('booking_id')->nullable()->constrained()->nullOnDelete();
            $table->enum('registry_status', ['pending','allowed','done'])->default('pending');
            $table->date('registry_date')->nullable();
            $table->timestamps();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('sales');
    }
};
