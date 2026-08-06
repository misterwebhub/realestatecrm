<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * One deed-mapping row per Arazi row (i.e. per kisan under an arazi
     * code) — records which Deed No and Partner that kisan's share of the
     * arazi has been mapped to.
     */
    public function up(): void
    {
        if (Schema::hasTable('deed_mappings')) {
            return;
        }

        Schema::create('deed_mappings', function (Blueprint $table) {
            $table->id();
            $table->foreignId('arazi_id')->unique()->constrained('arazis')->cascadeOnDelete();
            $table->string('deed_no', 100);
            $table->foreignId('partner_id')->constrained('partners')->restrictOnDelete();
            $table->foreignId('created_by')->nullable()->constrained('users')->nullOnDelete();
            $table->timestamps();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('deed_mappings');
    }
};
