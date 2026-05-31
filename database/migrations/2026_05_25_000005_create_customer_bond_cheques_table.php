<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::create('customer_bond_cheques', function (Blueprint $table) {
            $table->id();
            $table->foreignId('customer_bond_id')->constrained('customer_bonds')->cascadeOnDelete();
            $table->foreignId('customer_id')->nullable()->constrained('customers')->nullOnDelete();
            $table->string('cheque_number', 100)->nullable();
            $table->string('bank_name')->nullable();
            $table->string('branch_name')->nullable();
            $table->date('cheque_date')->nullable();
            $table->decimal('amount', 15, 2)->default(0);
            $table->enum('status', ['pending', 'cleared', 'bounced', 'cancelled'])->default('pending');
            $table->text('notes')->nullable();
            $table->foreignId('created_by')->nullable()->constrained('users')->nullOnDelete();
            $table->timestamps();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('customer_bond_cheques');
    }
};
