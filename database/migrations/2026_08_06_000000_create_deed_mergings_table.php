<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * One deed_mergings row per "merge" action performed on an arazi: the
     * arazi code it was performed against, and the single partner every
     * merged row resolved to.
     */
    public function up(): void
    {
        if (Schema::hasTable('deed_mergings')) {
            return;
        }

        Schema::create('deed_mergings', function (Blueprint $table) {
            $table->id();
            $table->string('arazi_code', 100);
            $table->foreignId('partner_id')->constrained('partners')->restrictOnDelete();
            $table->foreignId('created_by')->nullable()->constrained('users')->nullOnDelete();
            $table->timestamps();

            $table->index('arazi_code');
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('deed_mergings');
    }
};
