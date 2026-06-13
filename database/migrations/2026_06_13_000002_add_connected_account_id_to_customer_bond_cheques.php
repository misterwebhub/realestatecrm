<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('customer_bond_cheques', function (Blueprint $table) {
            $table->unsignedBigInteger('connected_account_id')->nullable()->after('customer_bond_id');
            $table->foreign('connected_account_id')->references('id')->on('connected_accounts')->nullOnDelete();
        });
    }

    public function down(): void
    {
        Schema::table('customer_bond_cheques', function (Blueprint $table) {
            $table->dropForeign(['connected_account_id']);
            $table->dropColumn('connected_account_id');
        });
    }
};
