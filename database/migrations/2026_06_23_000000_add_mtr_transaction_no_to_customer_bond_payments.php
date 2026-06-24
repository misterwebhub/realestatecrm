<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Add MTR Transaction No. column used for IMPS / RTGS / UPI payments.
     */
    public function up(): void
    {
        if (! Schema::hasColumn('customer_bond_payments', 'mtr_transaction_no')) {
            Schema::table('customer_bond_payments', function (Blueprint $table) {
                $table->string('mtr_transaction_no', 100)->nullable()->after('payment_method');
            });
        }
    }

    public function down(): void
    {
        if (Schema::hasColumn('customer_bond_payments', 'mtr_transaction_no')) {
            Schema::table('customer_bond_payments', function (Blueprint $table) {
                $table->dropColumn('mtr_transaction_no');
            });
        }
    }
};
