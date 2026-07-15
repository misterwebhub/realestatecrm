<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('customer_bonds', function (Blueprint $table) {
            if (! Schema::hasColumn('customer_bonds', 'installment_amount')) {
                $table->decimal('installment_amount', 15, 2)->nullable()->after('amount');
            }

            if (! Schema::hasColumn('customer_bonds', 'no_of_months')) {
                $table->unsignedInteger('no_of_months')->nullable()->after('last_date');
            }

            if (! Schema::hasColumn('customer_bonds', 'expiry_date')) {
                $table->date('expiry_date')->nullable()->after('no_of_months');
            }

            if (! Schema::hasColumn('customer_bonds', 'nominee_details')) {
                $table->text('nominee_details')->nullable()->after('customer_comment');
            }
        });
    }

    public function down(): void
    {
        Schema::table('customer_bonds', function (Blueprint $table) {
            foreach (['installment_amount', 'no_of_months', 'expiry_date', 'nominee_details'] as $column) {
                if (Schema::hasColumn('customer_bonds', $column)) {
                    $table->dropColumn($column);
                }
            }
        });
    }
};
