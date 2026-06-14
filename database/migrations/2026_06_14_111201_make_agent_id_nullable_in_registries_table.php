<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::table('registries', function (Blueprint $table) {
            $table->dropForeign(['agent_id']);
            $table->unsignedBigInteger('agent_id')->nullable()->change();
            $table->foreign('agent_id')->references('id')->on('agents')->nullOnDelete();
        });
    }

    public function down(): void
    {
        Schema::table('registries', function (Blueprint $table) {
            $table->dropForeign(['agent_id']);
            $table->unsignedBigInteger('agent_id')->nullable(false)->change();
            $table->foreign('agent_id')->references('id')->on('agents')->onDelete('cascade');
        });
    }
};
