<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Sale;
use App\Models\Plot;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Validation\Rule;

class SaleController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Sale';
    }

    protected function resourceModel(): string
    {
        return Sale::class;
    }

    protected function resourceRouteName(): string
    {
        return 'sales';
    }

    protected function resourceColumns(): array
    {
        return ['ID', 'Plot', 'Customer', 'Broker', 'Total Price', 'Registry'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            ['name' => 'plot_id', 'label' => 'Plot', 'type' => 'select', 'options' => Plot::with('arazi')->get()->mapWithKeys(function ($p) { return [$p->id => (($p->arazi?->legacy_arazi_code ? $p->arazi->legacy_arazi_code.' - ' : '') . ($p->title ?? ('Plot-' . $p->id)))]; })->all(), 'value' => $item?->plot_id],
            ['name' => 'customer_id', 'label' => 'Customer', 'type' => 'text', 'value' => $item?->customer_id],
            ['name' => 'broker_id', 'label' => 'Broker', 'type' => 'text', 'value' => $item?->broker_id],
            ['name' => 'total_price', 'label' => 'Total Price', 'type' => 'number', 'step' => '0.01', 'value' => $item?->total_price],
            ['name' => 'booking_id', 'label' => 'Booking', 'type' => 'text', 'value' => $item?->booking_id],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'plot_id' => ['required', 'exists:plots,id'],
            'customer_id' => ['required', 'exists:customers,id'],
            'broker_id' => ['nullable', 'exists:agents,id'],
            'total_price' => ['required', 'numeric', 'min:0'],
            'booking_id' => ['nullable', 'exists:bookings,id'],
        ];
    }

    protected function resourceAfterSave(Model $item, Request $request, array $validated, ?Model $original = null): void
    {
        // Mark plot as sold inside transaction
        DB::transaction(function () use ($item) {
            $plot = Plot::find($item->plot_id);
            if ($plot) {
                $plot->status = 'sold';
                $plot->save();
            }
        });
    }
}
