<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up()
    {
        Schema::table('registries', function (Blueprint $table) {
            if (! Schema::hasColumn('registries', 'plot_id')) {
                $table->foreignId('plot_id')->nullable()->constrained('plots')->nullOnDelete();
            }
        });
    }

    public function down()
    {
        Schema::table('registries', function (Blueprint $table) {
            if (Schema::hasColumn('registries', 'plot_id')) {
                $table->dropConstrainedForeignId('plot_id');
            }
        });
    }
};
