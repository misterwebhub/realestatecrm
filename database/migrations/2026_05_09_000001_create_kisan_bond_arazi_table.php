<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        if (! Schema::hasTable('kisan_bond_arazi')) {
            Schema::create('kisan_bond_arazi', function (Blueprint $table) {
                $table->id();
                $table->foreignId('kisan_bond_id')->constrained('kisan_bonds')->cascadeOnDelete();
                $table->foreignId('arazi_id')->constrained('arazis')->cascadeOnDelete();
                $table->timestamps();

                $table->unique(['kisan_bond_id', 'arazi_id'], 'kisan_bond_arazi_unique');
            });
        }

        if (Schema::hasColumn('kisan_bonds', 'arazi_id')) {
            DB::table('kisan_bonds')
                ->whereNotNull('arazi_id')
                ->orderBy('id')
                ->select(['id', 'arazi_id'])
                ->chunk(100, function ($bonds) {
                    foreach ($bonds as $bond) {
                        DB::table('kisan_bond_arazi')->updateOrInsert(
                            [
                                'kisan_bond_id' => $bond->id,
                                'arazi_id' => $bond->arazi_id,
                            ],
                            [
                                'created_at' => now(),
                                'updated_at' => now(),
                            ]
                        );
                    }
                });
        }
    }

    public function down(): void
    {
        Schema::dropIfExists('kisan_bond_arazi');
    }
};
