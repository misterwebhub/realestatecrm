<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::create('kisan_bond_witnesses', function (Blueprint $table) {
            $table->id();
            $table->foreignId('kisan_bond_id')->constrained('kisan_bonds')->cascadeOnDelete();
            $table->string('name');
            $table->string('id_no')->nullable();
            $table->string('mobile')->nullable();
            $table->timestamps();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('kisan_bond_witnesses');
    }
};
