<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (Schema::hasTable('kisan_registry_buyers')) {
            return;
        }

        Schema::create('kisan_registry_buyers', function (Blueprint $table) {
            $table->id();
            $table->foreignId('kisan_registry_id')->constrained('kisan_registries')->cascadeOnDelete();
            $table->unsignedBigInteger('partner_id')->nullable();
            $table->string('partner_name')->nullable();
            $table->decimal('area', 12, 2)->default(0); // area to sell (gaz)
            $table->timestamps();

            $table->index('partner_id');
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('kisan_registry_buyers');
    }
};
