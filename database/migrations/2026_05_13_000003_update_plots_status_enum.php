<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        // Convert status enum to a varchar to avoid enum-related truncation issues
        DB::statement("ALTER TABLE `plots` MODIFY `status` VARCHAR(50) NOT NULL DEFAULT 'available'");
    }

    public function down(): void
    {
        // Revert to original enum values (if rolling back)
        DB::statement("ALTER TABLE `plots` MODIFY `status` ENUM('available','locked','sold') NOT NULL DEFAULT 'available'");
    }
};
