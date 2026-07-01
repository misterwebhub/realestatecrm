<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('customer_bond_cheques', function (Blueprint $table) {
            if (! Schema::hasColumn('customer_bond_cheques', 'action_due_date')) {
                $table->date('action_due_date')->nullable()->after('cheque_date');
            }
            if (! Schema::hasColumn('customer_bond_cheques', 'frequency_type')) {
                $table->string('frequency_type', 30)->nullable()->after('action_due_date');
            }
        });
    }

    public function down(): void
    {
        Schema::table('customer_bond_cheques', function (Blueprint $table) {
            foreach (['action_due_date', 'frequency_type'] as $column) {
                if (Schema::hasColumn('customer_bond_cheques', $column)) {
                    $table->dropColumn($column);
                }
            }
        });
    }
};
