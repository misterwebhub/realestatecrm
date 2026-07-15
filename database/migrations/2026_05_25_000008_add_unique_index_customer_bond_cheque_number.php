<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;
use Illuminate\Support\Facades\DB;

return new class extends Migration
{
    public function up(): void
    {
        // Dedupe existing rows first: keep the latest (highest id) for each
        // (customer_bond_id, cheque_number) pair, delete older duplicates.
        DB::transaction(function () {
            $duplicates = DB::select(<<<'SQL'
SELECT customer_bond_id, cheque_number, GROUP_CONCAT(id ORDER BY id DESC) as ids, COUNT(*) as cnt
FROM customer_bond_cheques
WHERE cheque_number IS NOT NULL AND cheque_number != ''
GROUP BY customer_bond_id, cheque_number
HAVING cnt > 1
SQL
            );

            foreach ($duplicates as $d) {
                $ids = explode(',', $d->ids);
                // keep the first (largest id), delete the rest
                array_shift($ids);
                if (!empty($ids)) {
                    DB::table('customer_bond_cheques')->whereIn('id', $ids)->delete();
                }
            }
        });

        Schema::table('customer_bond_cheques', function (Blueprint $table) {
            $table->unique(['customer_bond_id', 'cheque_number'], 'customer_bond_cheque_number_unique');
        });
    }

    public function down(): void
    {
        Schema::table('customer_bond_cheques', function (Blueprint $table) {
            $table->dropUnique('customer_bond_cheque_number_unique');
        });
    }
};
