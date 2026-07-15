<?php

namespace App\Http\Controllers;

use App\Http\Controllers\Concerns\ManagesCrud;
use App\Models\Agent;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;
use Illuminate\Validation\Rule;

class AgentController extends Controller
{
    use ManagesCrud;

    protected function resourceTitle(): string
    {
        return 'Broker';
    }

    protected function resourceModel(): string
    {
        return Agent::class;
    }

    protected function resourceRouteName(): string
    {
        return 'agents';
    }

    protected function resourceColumns(): array
    {
        return ['Type', 'Form Code', 'Name', 'Rank', 'Sponsor', 'Commission %', 'Registries'];
    }

    protected function resourceFields(?Model $item = null): array
    {
        return [
            [
                'name' => 'broker_type',
                'label' => 'Broker Type',
                'type' => 'select',
                'options' => $this->brokerTypeOptions(),
                'value' => $item?->broker_type ?? request('broker_type', 'office'),
            ],
            ['name' => 'form_code', 'label' => 'Broker Form Code', 'type' => 'text', 'value' => $item?->form_code],
            ['name' => 'name', 'label' => 'Name', 'type' => 'text', 'value' => $item?->name],
            ['name' => 'rank_title', 'label' => 'Rank/Level', 'type' => 'text', 'value' => $item?->rank_title],
            ['name' => 'mobile', 'label' => 'Mobile', 'type' => 'text', 'value' => $item?->mobile],
            [
                'name' => 'sponsor_agent_id',
                'label' => 'Sponsor Broker',
                'type' => 'select',
                'options' => Agent::query()
                    ->when($item, fn ($q) => $q->where('id', '!=', $item->id))
                    ->orderBy('name')
                    ->pluck('name', 'id')
                    ->all(),
                'value' => $item?->sponsor_agent_id,
            ],
            ['name' => 'commission_percentage', 'label' => 'Commission Percentage', 'type' => 'number', 'step' => '0.01', 'value' => $item?->commission_percentage],
            ['name' => 'legacy_percent', 'label' => 'Legacy Percent', 'type' => 'number', 'step' => '0.01', 'value' => $item?->legacy_percent],
        ];
    }

    protected function resourceRules(?Model $item = null): array
    {
        return [
            'broker_type' => ['required', Rule::in(array_keys($this->brokerTypeOptions()))],
            'form_code' => ['nullable', 'string', 'max:30', Rule::unique('agents', 'form_code')->ignore($item?->id)],
            'name' => ['required', 'string', 'max:150'],
            'rank_title' => ['nullable', 'string', 'max:60'],
            'mobile' => ['required', 'string', 'max:20'],
            'sponsor_agent_id' => ['nullable', 'exists:agents,id'],
            'commission_percentage' => ['required', 'numeric', 'min:0', 'max:100'],
            'legacy_percent' => ['nullable', 'numeric', 'min:0', 'max:100'],
        ];
    }

    protected function resourceQuery()
    {
        return Agent::with(['sponsor'])->withCount('registries')->latest();
    }

    protected function resourceRow(Model $item): array
    {
        /** @var Agent $item */
        return [
            'cells' => [
                $this->brokerTypeOptions()[$item->broker_type ?? 'office'] ?? 'Office',
                $item->form_code ?? '-',
                $item->name,
                $item->rank_title ?? '-',
                $item->sponsor?->name ?? '-',
                (string) $item->commission_percentage,
                (string) $item->registries_count,
            ],
        ];
    }

    public function typeIndex(string $type)
    {
        $this->abortInvalidType($type);

        return view('agents.type_index', [
            'title' => $this->brokerTypeOptions()[$type] . ' Brokers',
            'type' => $type,
            'typeLabel' => $this->brokerTypeOptions()[$type],
            'nextFormCode' => $this->nextBrokerCode($type),
            'brokers' => Agent::with('sponsor')
                ->where('broker_type', $type)
                ->withCount('registries')
                ->latest()
                ->get(),
            'sponsors' => Agent::where('broker_type', $type)->orderBy('name')->pluck('name', 'id')->all(),
        ]);
    }

    protected function resourcePrepareData(array $validated, \Illuminate\Http\Request $request, ?Model $item = null): array
    {
        $validated['broker_type'] = $validated['broker_type'] ?? 'office';
        $validated['form_code'] = ($validated['form_code'] ?? null) ?: $this->nextBrokerCode($validated['broker_type']);

        return $validated;
    }

    public function typeStore(Request $request, string $type)
    {
        $this->abortInvalidType($type);

        $validated = $request->validate([
            'form_code' => ['nullable', 'string', 'max:30', Rule::unique('agents', 'form_code')],
            'name' => ['required', 'string', 'max:150'],
            'rank_title' => ['nullable', 'string', 'max:60'],
            'mobile' => ['required', 'string', 'max:20'],
            'sponsor_agent_id' => ['nullable', 'exists:agents,id'],
            'commission_percentage' => ['required', 'numeric', 'min:0', 'max:100'],
            'legacy_percent' => ['nullable', 'numeric', 'min:0', 'max:100'],
        ]);

        $validated['broker_type'] = $type;
        $validated['form_code'] = ($validated['form_code'] ?? null) ?: $this->nextBrokerCode($type);
        $agent = Agent::create($validated);

        if ($request->expectsJson() || $request->ajax()) {
            return response()->json([
                'id' => $agent->id,
                'name' => $agent->name,
                'form_code' => $agent->form_code,
                'label' => trim($agent->form_code . ' - ' . $agent->name, ' -'),
            ]);
        }

        return redirect()
            ->route('agents.type.index', $type)
            ->with('success', $this->brokerTypeOptions()[$type] . ' Broker created successfully.');
    }

    private function brokerTypeOptions(): array
    {
        return [
            'kisan' => 'Kisan',
            'customer' => 'Customer',
            'office' => 'Office',
        ];
    }

    private function abortInvalidType(string $type): void
    {
        abort_unless(array_key_exists($type, $this->brokerTypeOptions()), 404);
    }

    private function nextBrokerCode(string $type): string
    {
        $prefix = match ($type) {
            'kisan' => 'BRK',
            'customer' => 'BRC',
            default => 'BRO',
        };

        $next = Agent::where('form_code', 'like', $prefix . '%')
            ->pluck('form_code')
            ->map(function ($formCode) use ($prefix) {
                return preg_match('/^' . preg_quote($prefix, '/') . '(\d+)$/', (string) $formCode, $matches)
                    ? (int) $matches[1]
                    : 0;
            })
            ->max() + 1;

        do {
            $formCode = $prefix . str_pad((string) $next, 5, '0', STR_PAD_LEFT);
            $next++;
        } while (Agent::where('form_code', $formCode)->exists());

        return $formCode;
    }
}
