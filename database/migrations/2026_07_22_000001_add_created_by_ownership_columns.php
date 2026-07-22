<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Tables that get a `created_by` owner column so non-admin users can be
     * restricted to their own records. `customer_bond_cheques` already has one.
     */
    protected array $tables = [
        'agents',
        'arazis',
        'arazi_documents',
        'bookings',
        'customer_bonds',
        'customer_bond_payments',
        'customers',
        'investors',
        'kisan_bonds',
        'kisans',
        'partners',
        'payments',
        'plots',
        'registries',
        'sales',
    ];

    public function up(): void
    {
        foreach ($this->tables as $table) {
            if (! Schema::hasTable($table) || Schema::hasColumn($table, 'created_by')) {
                continue;
            }

            Schema::table($table, function (Blueprint $t) {
                $t->unsignedBigInteger('created_by')->nullable()->index()->after('id');
            });
        }

        // Backfill existing rows to an admin user so legacy data stays visible
        // to admins (and doesn't vanish for everyone under owner scoping).
        $adminId = DB::table('users')
            ->whereIn('role', ['super_admin', 'admin'])
            ->orderBy('id')
            ->value('id')
            ?? DB::table('users')->orderBy('id')->value('id');

        if ($adminId) {
            foreach ($this->tables as $table) {
                if (Schema::hasColumn($table, 'created_by')) {
                    DB::table($table)->whereNull('created_by')->update(['created_by' => $adminId]);
                }
            }

            // Cheques table already had the column but may hold legacy NULLs.
            if (Schema::hasColumn('customer_bond_cheques', 'created_by')) {
                DB::table('customer_bond_cheques')->whereNull('created_by')->update(['created_by' => $adminId]);
            }
        }
    }

    public function down(): void
    {
        foreach ($this->tables as $table) {
            if (Schema::hasColumn($table, 'created_by')) {
                Schema::table($table, function (Blueprint $t) {
                    $t->dropColumn('created_by');
                });
            }
        }
    }
};
