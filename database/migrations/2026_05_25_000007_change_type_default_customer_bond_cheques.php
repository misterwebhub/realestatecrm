<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Support\Facades\DB;

return new class extends Migration
{
    public function up(): void
    {
        // Change default to 'mentioned'
        DB::statement("ALTER TABLE customer_bond_cheques MODIFY `type` ENUM('mentioned','not_mentioned') NOT NULL DEFAULT 'mentioned'");
    }

    public function down(): void
    {
        // Revert default to 'not_mentioned'
        DB::statement("ALTER TABLE customer_bond_cheques MODIFY `type` ENUM('mentioned','not_mentioned') NOT NULL DEFAULT 'not_mentioned'");
    }
};
