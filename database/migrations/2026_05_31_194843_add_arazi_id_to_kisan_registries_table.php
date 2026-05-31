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
        Schema::table('kisan_registries', function (Blueprint $table) {
            $table->unsignedBigInteger('arazi_id')->nullable()->after('id');
            $table->foreign('arazi_id')->references('id')->on('arazis')->nullOnDelete();
        });
    }

    public function down(): void
    {
        Schema::table('kisan_registries', function (Blueprint $table) {
            $table->dropForeign(['arazi_id']);
            $table->dropColumn('arazi_id');
        });
    }
};
