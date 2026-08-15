<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('uploads', function (Blueprint $table) {
            if (! Schema::hasColumn('uploads', 'reason')) {
                $table->string('reason', 500)->nullable()->after('label');
            }
        });
    }

    public function down(): void
    {
        Schema::table('uploads', function (Blueprint $table) {
            if (Schema::hasColumn('uploads', 'reason')) {
                $table->dropColumn('reason');
            }
        });
    }
};
