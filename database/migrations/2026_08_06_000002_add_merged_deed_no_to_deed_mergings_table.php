<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * The new, single deed no that a merge consolidates its member rows
     * into. User-entered at merge time, unique like any other deed no.
     */
    public function up(): void
    {
        if (Schema::hasColumn('deed_mergings', 'merged_deed_no')) {
            return;
        }

        Schema::table('deed_mergings', function (Blueprint $table) {
            $table->string('merged_deed_no', 100)->unique()->after('arazi_code');
        });
    }

    public function down(): void
    {
        Schema::table('deed_mergings', function (Blueprint $table) {
            $table->dropUnique(['merged_deed_no']);
            $table->dropColumn('merged_deed_no');
        });
    }
};
