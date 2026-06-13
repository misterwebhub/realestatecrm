<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('customer_bond_payments', function (Blueprint $table) {
            $table->unsignedBigInteger('taken_by_user_id')->nullable()->after('payment_method');
            $table->foreign('taken_by_user_id')->references('id')->on('users')->nullOnDelete();
        });
    }

    public function down(): void
    {
        Schema::table('customer_bond_payments', function (Blueprint $table) {
            $table->dropForeign(['taken_by_user_id']);
            $table->dropColumn('taken_by_user_id');
        });
    }
};
