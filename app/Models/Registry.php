<?php

namespace App\Models;

use App\Models\Concerns\HasAraziCode;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Registry extends Model
{
    use HasFactory;
    use HasAraziCode;

    protected $fillable = [
        'registry_code',
        'receipt_no',
        'customer_reg_no',
        'plot_id',
        'customer_id',
        'arazi_id',
        'arazi_code',
        'partner_id',
        'agent_id',
        'check_by_agent_id',
        'registry_date',
        'deed_no',
        'circle_value',
        'booking_mode',
        'land_size',
        'registry_amount',
        'payment_words',
        'id_card_no',
        'associate_address',
        'witness_name',
        'nominee_name',
        'document_path',
        'broker_commission',
        'advance_amount',
        'installment_amount',
        'down_payment',
        'due_date',
        'expected_registry_date',
        'status',
        'payment_status',
        'lock_status',
    ];

    protected $casts = [
        'registry_date' => 'date',
        'due_date' => 'date',
        'expected_registry_date' => 'date',
    ];

    public function customer()
    {
        return $this->belongsTo(Customer::class);
    }

    public function plot()
    {
        return $this->belongsTo(Plot::class);
    }

    /**
     * Every plot this registry covers (multi-plot registries). Mirrors
     * CustomerBond::plots(). plot_id above still points at the "primary"
     * (first) plot for backward compatibility with single-plot code paths.
     */
    public function plots()
    {
        return $this->belongsToMany(Plot::class, 'registry_plot')
            ->withPivot(['area'])
            ->withTimestamps();
    }

    /**
     * All plots this registry covers, whether tracked via the registry_plot
     * pivot (new multi-plot registries) or only via the legacy singular
     * plot_id column (older registries created before the pivot existed).
     */
    public function allPlots()
    {
        $plots = $this->relationLoaded('plots') ? $this->plots : $this->plots()->get();

        if ($plots->isEmpty() && $this->plot) {
            return collect([$this->plot]);
        }

        return $plots;
    }

    /**
     * Comma-separated plot titles for display (index listing, etc).
     */
    public function plotTitlesLabel(): string
    {
        $plots = $this->allPlots();

        if ($plots->isEmpty()) {
            return '-';
        }

        return $plots->map(fn ($p) => $p->title ?: ('Plot-' . $p->id))->implode(', ');
    }

    /**
     * Match registries covering a given plot, whether via the legacy
     * singular plot_id column or the registry_plot pivot table.
     */
    public function scopeForPlot($query, $plotId)
    {
        return $query->where(function ($q) use ($plotId) {
            $q->where('plot_id', $plotId)
              ->orWhereHas('plots', fn ($pq) => $pq->where('plots.id', $plotId));
        });
    }

    public function arazi()
    {
        return $this->belongsTo(Arazi::class, 'arazi_code', 'legacy_arazi_code');
    }

    public function agent()
    {
        return $this->belongsTo(Agent::class);
    }

    public function partner()
    {
        return $this->belongsTo(Partner::class);
    }

    public function checkByAgent()
    {
        return $this->belongsTo(Agent::class, 'check_by_agent_id');
    }

    public function payments()
    {
        return $this->hasMany(Payment::class);
    }
}
