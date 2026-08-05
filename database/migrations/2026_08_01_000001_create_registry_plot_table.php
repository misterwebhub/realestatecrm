<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

/**
 * Pivot table so a single Registry can cover multiple plots — mirrors the
 * customer_bond_plot pattern used for CustomerBond <-> Plot. When a bond has
 * more than one plot, the Registry create form creates ONE Registry row and
 * attaches every plot here (with each plot's own area), instead of the old
 * behaviour of only registering the first plot.
 *
 * registries.plot_id is still populated (with the "primary"/first plot) for
 * backward compatibility with existing single-plot code paths; this table is
 * the source of truth for the full set of plots a registry covers.
 */
return new class extends Migration
{
    public function up(): void
    {
        if (! Schema::hasTable('registry_plot')) {
            Schema::create('registry_plot', function (Blueprint $table) {
                $table->id();
                $table->foreignId('registry_id')->constrained('registries')->cascadeOnDelete();
                $table->foreignId('plot_id')->constrained('plots')->cascadeOnDelete();
                $table->decimal('area', 15, 2)->nullable();
                $table->timestamps();

                $table->unique(['registry_id', 'plot_id'], 'registry_plot_unique');
            });
        }
    }

    public function down(): void
    {
        Schema::dropIfExists('registry_plot');
    }
};
