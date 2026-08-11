<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('uploads', function (Blueprint $table) {
            if (! Schema::hasColumn('uploads', 'kisan_id')) {
                $table->unsignedBigInteger('kisan_id')->nullable()->after('arazi_code');
                $table->foreign('kisan_id')->references('id')->on('kisans')->onDelete('set null');
            }

            if (! Schema::hasColumn('uploads', 'partner_id')) {
                $table->unsignedBigInteger('partner_id')->nullable()->after('kisan_id');
                $table->foreign('partner_id')->references('id')->on('partners')->onDelete('set null');
            }
        });
    }

    public function down(): void
    {
        Schema::table('uploads', function (Blueprint $table) {
            if (Schema::hasColumn('uploads', 'kisan_id')) {
                $table->dropForeign(['kisan_id']);
                $table->dropColumn('kisan_id');
            }

            if (Schema::hasColumn('uploads', 'partner_id')) {
                $table->dropForeign(['partner_id']);
                $table->dropColumn('partner_id');
            }
        });
    }
};
