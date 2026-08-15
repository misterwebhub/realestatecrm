<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;

/**
 * The Uploads module is a private filing cabinet — records aren't meant to
 * link/connect to real Kisan or Partner rows anywhere else in the app. The
 * old kisan_id/partner_id select-dropdowns are replaced with plain free-text
 * boxes, so we add matching free-text columns and backfill from any existing
 * linked names before the FK columns are dropped from use.
 */
return new class extends Migration
{
    public function up(): void
    {
        Schema::table('uploads', function (Blueprint $table) {
            if (! Schema::hasColumn('uploads', 'kisan_name')) {
                $table->string('kisan_name')->nullable()->after('arazi_code');
            }
            if (! Schema::hasColumn('uploads', 'partner_name')) {
                $table->string('partner_name')->nullable()->after('kisan_name');
            }
        });

        // Backfill free-text names from the old FK links (if any exist) so
        // nothing already recorded looks blank after the switch.
        if (Schema::hasColumn('uploads', 'kisan_id') && Schema::hasColumn('uploads', 'kisan_name')) {
            DB::statement('UPDATE uploads u JOIN kisans k ON k.id = u.kisan_id SET u.kisan_name = k.name WHERE u.kisan_name IS NULL');
        }
        if (Schema::hasColumn('uploads', 'partner_id') && Schema::hasColumn('uploads', 'partner_name')) {
            DB::statement('UPDATE uploads u JOIN partners p ON p.id = u.partner_id SET u.partner_name = p.name WHERE u.partner_name IS NULL');
        }
    }

    public function down(): void
    {
        Schema::table('uploads', function (Blueprint $table) {
            if (Schema::hasColumn('uploads', 'kisan_name')) {
                $table->dropColumn('kisan_name');
            }
            if (Schema::hasColumn('uploads', 'partner_name')) {
                $table->dropColumn('partner_name');
            }
        });
    }
};
