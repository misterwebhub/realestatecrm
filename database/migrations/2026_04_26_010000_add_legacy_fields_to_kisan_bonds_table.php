<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (! Schema::hasTable('kisan_bonds')) {
            return;
        }

        Schema::table('kisan_bonds', function (Blueprint $table) {
            $table->string('mobile')->nullable()->after('bond_amount');
            $table->string('land_size')->nullable()->after('mobile');
            $table->decimal('sale_land', 12, 2)->nullable()->after('land_size');
            $table->decimal('sale_rate', 12, 2)->nullable()->after('sale_land');
            $table->decimal('total_amount', 14, 2)->nullable()->after('sale_rate');
            $table->enum('bayana_mode', ['cash', 'cheque'])->nullable()->after('total_amount');
            $table->string('bond_type')->nullable()->after('bayana_mode');
            $table->decimal('amount', 12, 2)->nullable()->after('bond_type');
            $table->decimal('balance', 12, 2)->nullable()->after('amount');
            $table->date('last_date')->nullable()->after('balance');
            $table->foreignId('broker_id')->nullable()->constrained('agents')->nullOnDelete()->after('last_date');
            $table->decimal('broker_payment', 12, 2)->nullable()->after('broker_id');
            $table->decimal('broker_paid', 12, 2)->nullable()->after('broker_payment');
            $table->decimal('broker_balance', 12, 2)->nullable()->after('broker_paid');
            $table->text('broker_comment')->nullable()->after('broker_balance');
            $table->text('kisan_comment')->nullable()->after('broker_comment');
        });
    }

    public function down(): void
    {
        if (! Schema::hasTable('kisan_bonds')) {
            return;
        }

        Schema::table('kisan_bonds', function (Blueprint $table) {
            $table->dropColumn([
                'mobile', 'land_size', 'sale_land', 'sale_rate', 'total_amount', 'bayana_mode', 'bond_type', 'amount', 'balance', 'last_date', 'broker_payment', 'broker_paid', 'broker_balance', 'broker_comment', 'kisan_comment',
            ]);

            // drop foreign key if exists
            if (Schema::hasColumn('kisan_bonds', 'broker_id')) {
                $table->dropForeign(['broker_id']);
                $table->dropColumn('broker_id');
            }
        });
    }
};
