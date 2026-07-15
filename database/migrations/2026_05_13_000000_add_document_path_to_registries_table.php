<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up()
    {
        Schema::table('registries', function (Blueprint $table) {
            if (!Schema::hasColumn('registries', 'document_path')) {
                $table->string('document_path')->nullable();
            }
        });
    }

    public function down()
    {
        Schema::table('registries', function (Blueprint $table) {
            if (Schema::hasColumn('registries', 'document_path')) {
                $table->dropColumn('document_path');
            }
        });
    }
};
