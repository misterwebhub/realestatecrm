<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up()
    {
        Schema::table('customer_bond_payments', function (Blueprint $table) {
            if (!Schema::hasColumn('customer_bond_payments', 'customer_bond_cheque_id')) {
                $table->unsignedBigInteger('customer_bond_cheque_id')->nullable()->after('customer_bond_id');
                $table->foreign('customer_bond_cheque_id')
                    ->references('id')
                    ->on('customer_bond_cheques')
                    ->nullOnDelete();
            }
        });
    }

    public function down()
    {
        Schema::table('customer_bond_payments', function (Blueprint $table) {
            if (Schema::hasColumn('customer_bond_payments', 'customer_bond_cheque_id')) {
                $table->dropForeign(['customer_bond_cheque_id']);
                $table->dropColumn('customer_bond_cheque_id');
            }
        });
    }
};
