<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Add Account / Payee Name column for IMPS / RTGS / UPI payments.
     */
    public function up(): void
    {
        if (! Schema::hasColumn('customer_bond_payments', 'account_payee_name')) {
            Schema::table('customer_bond_payments', function (Blueprint $table) {
                $table->string('account_payee_name', 150)->nullable()->after('mtr_transaction_no');
            });
        }
    }

    public function down(): void
    {
        if (Schema::hasColumn('customer_bond_payments', 'account_payee_name')) {
            Schema::table('customer_bond_payments', function (Blueprint $table) {
                $table->dropColumn('account_payee_name');
            });
        }
    }
};
