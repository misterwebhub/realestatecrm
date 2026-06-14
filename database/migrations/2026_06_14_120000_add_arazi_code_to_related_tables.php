<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;
use Illuminate\Support\Facades\DB;

return new class extends Migration
{
    /**
     * Tables that currently reference arazi_id and need an arazi_code column.
     * Each will get a nullable arazi_code (string) backfilled from
     * arazis.legacy_arazi_code via the existing arazi_id link.
     */
    private array $tables = [
        'plots',
        'registries',
        'arazi_documents',
        'customer_bonds',
        'kisan_bonds',
        'arazi_investor',
        'customer_bond_payments',
        'uploads',
        'expenses',
        'kisan_registries',
        'kisan_bond_arazi',
    ];

    public function up(): void
    {
        foreach ($this->tables as $table) {
            if (!Schema::hasTable($table)) {
                continue;
            }
            if (!Schema::hasColumn($table, 'arazi_code')) {
                Schema::table($table, function (Blueprint $t) use ($table) {
                    $t->string('arazi_code', 40)->nullable()->after('arazi_id');
                    $t->index('arazi_code', $table . '_arazi_code_idx');
                });
            }
        }

        // Backfill arazi_code from arazis.legacy_arazi_code using arazi_id.
        foreach ($this->tables as $table) {
            if (!Schema::hasTable($table) || !Schema::hasColumn($table, 'arazi_id')) {
                continue;
            }
            DB::statement("
                UPDATE `{$table}` AS rel
                INNER JOIN `arazis` AS a ON a.id = rel.arazi_id
                SET rel.arazi_code = a.legacy_arazi_code
                WHERE rel.arazi_id IS NOT NULL
                  AND (a.legacy_arazi_code IS NOT NULL AND a.legacy_arazi_code <> '')
            ");
        }
    }

    public function down(): void
    {
        foreach ($this->tables as $table) {
            if (Schema::hasTable($table) && Schema::hasColumn($table, 'arazi_code')) {
                Schema::table($table, function (Blueprint $t) use ($table) {
                    $t->dropIndex($table . '_arazi_code_idx');
                    $t->dropColumn('arazi_code');
                });
            }
        }
    }
};
