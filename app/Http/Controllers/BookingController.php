<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Booking;
use App\Models\Plot;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Validation\Rule;

class BookingController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Booking';
    }

    protected function resourceModel(): string
    {
        return Booking::class;
    }

    protected function resourceRouteName(): string
    {
        return 'bookings';
    }

    protected function resourceColumns(): array
    {
        return ['ID', 'Plot', 'Customer', 'Advance', 'Booking Date', 'Expiry', 'Status'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            ['name' => 'plot_id', 'label' => 'Plot', 'type' => 'select', 'options' => Plot::with('arazi')->get()->mapWithKeys(function ($p) { return [$p->id => ($p->arazi?->plot_number ?? 'Arazi').' - '.($p->plot_number ?? $p->title)]; })->all(), 'value' => $item?->plot_id],
            ['name' => 'customer_id', 'label' => 'Customer', 'type' => 'text', 'value' => $item?->customer_id],
            ['name' => 'advance_amount', 'label' => 'Advance Amount', 'type' => 'number', 'step' => '0.01', 'value' => $item?->advance_amount],
            ['name' => 'booking_date', 'label' => 'Booking Date', 'type' => 'date', 'value' => optional($item?->booking_date)->format('Y-m-d')],
            ['name' => 'expiry_date', 'label' => 'Expiry Date', 'type' => 'date', 'value' => optional($item?->expiry_date)->format('Y-m-d')],
            ['name' => 'penalty_percent', 'label' => 'Penalty %', 'type' => 'number', 'step' => '0.01', 'value' => $item?->penalty_percent ?? 10],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'plot_id' => ['required', 'exists:plots,id'],
            'customer_id' => ['required', 'exists:customers,id'],
            'advance_amount' => ['required', 'numeric', 'min:0'],
            'booking_date' => ['required', 'date'],
            'expiry_date' => ['nullable', 'date'],
            'penalty_percent' => ['nullable', 'numeric', 'min:0', 'max:100'],
        ];
    }

    protected function resourcePrepareData(array $validated, Request $request, ?Model $item = null): array
    {
        return $validated;
    }

    protected function resourceAfterSave(Model $item, Request $request, array $validated, ?Model $original = null): void
    {
        // Lock plot when booking created
        DB::transaction(function () use ($item) {
            $plot = Plot::find($item->plot_id);
            if ($plot && $plot->status !== 'sold') {
                $plot->status = 'locked';
                $plot->save();
            }
        });
    }

    public function store(Request $request)
    {
        $validated = $request->validate($this->resourceRules());

        // Prevent double booking/locking
        $plot = Plot::findOrFail($validated['plot_id']);
        if (in_array($plot->status, ['locked', 'sold'])) {
            return back()->withErrors(['plot_id' => 'Selected plot is not available for booking.'])->withInput();
        }

        return parent::store($request);
    }
}
