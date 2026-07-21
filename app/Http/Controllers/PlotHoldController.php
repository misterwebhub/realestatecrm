<?php

namespace App\Http\Controllers;

use App\Models\Arazi;
use App\Models\Plot;
use App\Models\PlotHold;
use Illuminate\Http\Request;

class PlotHoldController extends Controller
{
    public function index(Request $request)
    {
        $status = trim((string) $request->query('status', 'active'));
        $araziCode = trim((string) $request->query('arazi_code', ''));
        $q = trim((string) $request->query('q', ''));

        $query = PlotHold::with(['plot', 'agent', 'customer', 'arazi'])->latest();

        if ($status !== '' && $status !== 'all') {
            $query->where('status', $status);
        }
        if ($araziCode !== '') {
            $query->where('arazi_code', $araziCode);
        }
        if ($q !== '') {
            $query->where(function ($sub) use ($q) {
                $sub->where('customer_phone', 'like', '%' . $q . '%')
                    ->orWhere('customer_name', 'like', '%' . $q . '%')
                    ->orWhereHas('plot', fn ($p) => $p->where('title', $q)) // exact — plot title behaves like a plot number
                    ->orWhereHas('agent', fn ($a) => $a->where('name', 'like', '%' . $q . '%'))
                    ->orWhereHas('customer', fn ($c) => $c->where('name', 'like', '%' . $q . '%'));
            });
        }

        $holds = $query->paginate(25)->withQueryString();

        $araziOptions = Arazi::whereNotNull('legacy_arazi_code')
            ->where('legacy_arazi_code', '!=', '')
            ->orderBy('legacy_arazi_code')
            ->get()
            ->groupBy('legacy_arazi_code')
            ->mapWithKeys(function ($group, $code) {
                $first = $group->first();
                return [$code => ($first->araziNoCode() ?: $code)];
            })->all();

        $agents = \App\Models\Agent::orderBy('name')
            ->get(['id', 'name', 'rank_title'])
            ->mapWithKeys(function (\App\Models\Agent $a) {
                return [$a->id => $a->name . ($a->rank_title ? ' — ' . $a->rank_title : '')];
            })->all();

        $customers = \App\Models\Customer::orderBy('name')
            ->get(['id', 'name', 'mobile'])
            ->mapWithKeys(function (\App\Models\Customer $c) {
                return [$c->id => $c->name . ($c->mobile ? ' (' . $c->mobile . ')' : '')];
            })->all();

        return view('plot_holds.index', [
            'title' => 'Plot Holds',
            'holds' => $holds,
            'status' => $status,
            'araziCode' => $araziCode,
            'q' => $q,
            'araziOptions' => $araziOptions,
            'agents' => $agents,
            'customers' => $customers,
        ]);
    }

    public function store(Request $request)
    {
        $data = $request->validate([
            'arazi_code' => ['required', 'string', 'exists:arazis,legacy_arazi_code'],
            'plot_id' => ['required', 'array', 'min:1'],
            'plot_id.*' => ['integer', 'exists:plots,id'],
            'agent_id' => ['required', 'integer', 'exists:agents,id'],
            'days' => ['required', 'integer', 'min:1'],
            'start_date' => ['required', 'date'],
            'end_date' => ['required', 'date', 'after_or_equal:start_date'],
            'customer_id' => ['nullable', 'integer', 'exists:customers,id'],
            'customer_name' => ['nullable', 'string', 'max:150'],
            'customer_phone' => ['nullable', 'string', 'max:30'],
            'notes' => ['nullable', 'string'],
        ]);

        $plots = Plot::whereIn('id', $data['plot_id'])->get();

        foreach ($plots as $plot) {
            // Only one active hold per plot — release any existing one first.
            PlotHold::where('plot_id', $plot->id)
                ->where('status', 'active')
                ->update(['status' => 'released']);

            PlotHold::create([
                'plot_id' => $plot->id,
                'arazi_code' => $plot->arazi_code ?: $data['arazi_code'],
                'agent_id' => $data['agent_id'],
                'days' => $data['days'],
                'start_date' => $data['start_date'],
                'end_date' => $data['end_date'],
                'customer_id' => $data['customer_id'] ?? null,
                'customer_name' => $data['customer_name'] ?? null,
                'customer_phone' => $data['customer_phone'] ?? null,
                'notes' => $data['notes'] ?? null,
                'status' => 'active',
                'created_by' => auth()->id(),
            ]);

            // Adding a hold here auto-sets the plot to "hold".
            if ($plot->status !== 'hold') {
                $plot->update(['status' => 'hold']);
            }
        }

        $count = $plots->count();

        return redirect()
            ->route('plot-holds.index')
            ->with('success', $count . ' plot' . ($count === 1 ? '' : 's') . ' set to hold.');
    }

    public function release(PlotHold $plotHold)
    {
        $plotHold->update(['status' => 'released']);

        // Free the plot if it is still marked as hold.
        if ($plotHold->plot && $plotHold->plot->status === 'hold') {
            $plotHold->plot->update(['status' => 'available']);
        }

        return redirect()
            ->route('plot-holds.index')
            ->with('success', 'Hold released.');
    }
}
