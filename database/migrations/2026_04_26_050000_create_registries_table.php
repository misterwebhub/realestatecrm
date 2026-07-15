<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up()
    {
        if (Schema::hasTable('registries')) {
            return;
        }

        Schema::create('registries', function (Blueprint $table) {
            $table->id();
            $table->string('registry_code')->nullable()->unique();
            $table->string('customer_reg_no')->nullable()->unique();
            $table->foreignId('customer_id')->constrained()->onDelete('cascade');
            $table->foreignId('arazi_id')->constrained()->onDelete('cascade');
            $table->foreignId('agent_id')->constrained('agents')->onDelete('cascade');
            $table->foreignId('check_by_agent_id')->nullable()->constrained('agents')->nullOnDelete();
            $table->date('registry_date')->nullable();
            $table->string('booking_mode')->nullable();
            $table->decimal('land_size', 12, 2)->nullable();
            $table->decimal('registry_amount', 14, 2)->nullable();
            $table->string('payment_words')->nullable();
            $table->string('id_card_no')->nullable();
            $table->string('witness_name')->nullable();
            $table->string('nominee_name')->nullable();
            $table->decimal('broker_commission', 5, 2)->nullable();
            $table->decimal('advance_amount', 14, 2)->nullable();
            $table->decimal('installment_amount', 14, 2)->nullable();
            $table->decimal('down_payment', 14, 2)->nullable();
            $table->date('due_date')->nullable();
            $table->date('expected_registry_date')->nullable();
            $table->enum('status', ['pending','completed','cancelled'])->default('pending');
            $table->enum('payment_status', ['pending','partial','completed','expired'])->default('pending');
            $table->enum('lock_status', ['unlock','lock'])->default('unlock');
            // legacy/ux fields
            $table->string('mobile')->nullable();
            $table->string('receipt_no')->nullable();
            $table->text('associate_address')->nullable();
            $table->boolean('esign_signed')->default(false);
            $table->text('esign_data')->nullable();

            $table->timestamps();
        });
    }

    public function down()
    {
        Schema::dropIfExists('registries');
    }
};
