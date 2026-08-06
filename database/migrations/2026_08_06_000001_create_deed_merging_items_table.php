<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Individual arazi rows (i.e. individual kisan shares) included in a
     * deed_merging. An arazi row can only belong to one merge — enforced by
     * the unique index on arazi_id — so it can't be double-merged.
     */
    public function up(): void
    {
        if (Schema::hasTable('deed_merging_items')) {
            return;
        }

        Schema::create('deed_merging_items', function (Blueprint $table) {
            $table->id();
            $table->foreignId('deed_merging_id')->constrained('deed_mergings')->cascadeOnDelete();
            $table->foreignId('arazi_id')->unique()->constrained('arazis')->cascadeOnDelete();
            $table->string('deed_no', 100);
            $table->timestamps();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('deed_merging_items');
    }
};
