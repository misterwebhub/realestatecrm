<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::create('uploads', function (Blueprint $table) {
            $table->id();
            $table->foreignId('upload_category_id')->constrained('upload_categories')->onDelete('cascade');
            $table->unsignedBigInteger('arazi_id')->nullable();
            $table->string('label')->nullable();
            $table->string('file_path');
            $table->string('mime')->nullable();
            $table->bigInteger('size')->nullable();
            $table->foreign('arazi_id')->references('id')->on('arazis')->onDelete('set null');
            $table->timestamps();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('uploads');
    }
};
