<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (!Schema::hasColumn('plots', 'area')) {
            Schema::table('plots', function (Blueprint $table) {
                $table->decimal('area', 10, 2)->default(0)->after('title');
            });
        }
    }

    public function down(): void
    {
        if (Schema::hasColumn('plots', 'area')) {
            Schema::table('plots', function (Blueprint $table) {
                $table->dropColumn('area');
            });
        }
    }
};
