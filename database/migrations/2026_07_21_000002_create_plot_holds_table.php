<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::create('plot_holds', function (Blueprint $table) {
            $table->id();
            $table->unsignedBigInteger('plot_id');
            // Arazi is referenced by its legacy code (project convention).
            $table->string('arazi_code', 100)->nullable();
            $table->unsignedBigInteger('agent_id'); // broker holding the plot
            $table->unsignedInteger('days');
            $table->date('start_date');
            $table->date('end_date');
            $table->unsignedBigInteger('customer_id')->nullable();
            $table->string('customer_phone', 30)->nullable();
            $table->text('notes')->nullable();
            $table->string('status', 20)->default('active'); // active | released | expired
            $table->unsignedBigInteger('created_by')->nullable();
            $table->timestamps();

            $table->index('plot_id');
            $table->index('arazi_code');
            $table->index('status');

            $table->foreign('plot_id')->references('id')->on('plots')->cascadeOnDelete();
            $table->foreign('agent_id')->references('id')->on('agents')->cascadeOnDelete();
            $table->foreign('customer_id')->references('id')->on('customers')->nullOnDelete();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('plot_holds');
    }
};
