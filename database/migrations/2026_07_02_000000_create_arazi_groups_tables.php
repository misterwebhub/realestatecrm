<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (! Schema::hasTable('arazi_groups')) {
            Schema::create('arazi_groups', function (Blueprint $table) {
                $table->id();
                $table->string('name')->nullable();
                $table->string('map_name');
                $table->text('notes')->nullable();
                $table->unsignedBigInteger('created_by')->nullable();
                $table->timestamps();
            });
        }

        if (! Schema::hasTable('arazi_group_items')) {
            Schema::create('arazi_group_items', function (Blueprint $table) {
                $table->id();
                $table->unsignedBigInteger('arazi_group_id');
                $table->unsignedBigInteger('arazi_id');
                $table->timestamps();

                $table->foreign('arazi_group_id')->references('id')->on('arazi_groups')->onDelete('cascade');
                $table->index('arazi_id');
            });
        }
    }

    public function down(): void
    {
        Schema::dropIfExists('arazi_group_items');
        Schema::dropIfExists('arazi_groups');
    }
};
