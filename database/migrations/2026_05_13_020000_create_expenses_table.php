<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (! Schema::hasTable('expenses')) {
            Schema::create('expenses', function (Blueprint $table) {
                $table->id();
                $table->unsignedBigInteger('arazi_id')->nullable();
                $table->string('type')->default('personal'); // 'arazi' or 'personal'
                $table->string('label')->nullable();
                $table->decimal('amount', 14, 2)->default(0);
                $table->date('incurred_at')->nullable();
                $table->text('notes')->nullable();
                $table->unsignedBigInteger('created_by')->nullable();
                $table->timestamps();

                $table->foreign('arazi_id')->references('id')->on('arazis')->onDelete('cascade');
            });
        }
    }

    public function down(): void
    {
        Schema::dropIfExists('expenses');
    }
};
