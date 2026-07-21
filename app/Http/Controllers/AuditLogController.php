<?php

namespace App\Http\Controllers;

use App\Models\AuditLog;
use App\Models\Agent;
use App\Models\CustomerBond;
use App\Models\CustomerBondPayment;
use Illuminate\Http\Request;
use Illuminate\Support\Str;

class AuditLogController extends Controller
{
    /**
     * Short type => model class map for the per-record change log.
     */
    protected array $typeMap = [
        'bond'    => CustomerBond::class,
        'payment' => CustomerBondPayment::class,
    ];

    /**
     * Return the change log (who/when/what) for a single bond or payment.
     * For a bond it also folds in the audit trail of its payments.
     */
    public function forRecord(Request $request)
    {
        $type = (string) $request->query('type', '');
        $id = (int) $request->query('id', 0);

        if (! isset($this->typeMap[$type]) || $id <= 0) {
            return response()->json(['found' => false, 'entries' => []]);
        }

        $modelClass = $this->typeMap[$type];

        $query = AuditLog::with('user')->latest('id');

        if ($type === 'bond') {
            $bond = CustomerBond::find($id);
            $paymentIds = CustomerBondPayment::where('customer_bond_id', $id)->pluck('id')->all();

            $query->where(function ($w) use ($modelClass, $id, $paymentIds) {
                $w->where(function ($q) use ($modelClass, $id) {
                    $q->where('auditable_type', $modelClass)->where('auditable_id', $id);
                })->orWhere(function ($q) use ($id, $paymentIds) {
                    $q->where('auditable_type', CustomerBondPayment::class)
                        ->where(function ($qq) use ($id, $paymentIds) {
                            if (! empty($paymentIds)) {
                                $qq->whereIn('auditable_id', $paymentIds);
                            }
                            // Also catch deleted payments whose link only survives in the meta diff.
                            $qq->orWhere('meta', 'like', '%"customer_bond_id":' . $id . '%')
                               ->orWhere('meta', 'like', '%"customer_bond_id":"' . $id . '"%');
                        });
                });
            });

            $heading = 'Bond ' . ($bond?->bond_no ?: ('#' . $id));
        } else {
            $payment = CustomerBondPayment::find($id);
            $query->where('auditable_type', $modelClass)->where('auditable_id', $id);
            $heading = 'Payment ' . ($payment?->entry_no ?: ('#' . $id));
        }

        $entries = $query->limit(300)->get()->map(function (AuditLog $log) {
            $meta = $log->meta ?? [];
            $old = $meta['old'] ?? [];
            $new = $meta['new'] ?? [];

            // Only log the fields that actually changed (updates). Create/delete
            // are shown as a single summary row, not a full field dump.
            $changes = [];
            if ($log->action === 'updated') {
                foreach ($new as $field => $val) {
                    $oldVal = $old[$field] ?? null;

                    // Skip formatting-only "changes" (e.g. "350000.00" -> 350000)
                    // that slipped into historical rows before storage was cleaned.
                    if ($this->valuesEquivalent($oldVal, $val)) {
                        continue;
                    }

                    $changes[] = [
                        'field' => $this->fieldLabel($field),
                        'old' => $this->displayValue($field, $oldVal),
                        'new' => $this->displayValue($field, $val),
                    ];
                }
            }

            return [
                'when' => optional($log->created_at)->format('d-m-Y H:i:s'),
                'user' => $log->user?->name ?? ($meta['user_name'] ?? ($log->user_id ? '#' . $log->user_id : 'System')),
                'action' => $log->action,
                'model' => class_basename($log->auditable_type),
                'record_id' => $log->auditable_id,
                'ip' => $meta['ip'] ?? null,
                'changes' => $changes,
                'field_count' => $log->action === 'created' ? count($new) : ($log->action === 'deleted' ? count($old) : count($changes)),
            ];
        })
        // Only keep entries that represent an actual field change.
        ->filter(fn ($e) => ! empty($e['changes']))
        ->values()
        ->all();

        return response()->json([
            'found' => true,
            'heading' => $heading,
            'entries' => $entries,
        ]);
    }

    /**
     * Human-friendly label for a raw column name.
     */
    protected function fieldLabel(string $field): string
    {
        $labels = [
            'broker_id' => 'Broker',
            'agent_id' => 'Agent',
            'customer_id' => 'Customer',
        ];

        if (isset($labels[$field])) {
            return $labels[$field];
        }

        return Str::of($field)->replace('_', ' ')->title();
    }

    /**
     * Resolve a stored value for display, turning known FK ids into names.
     */
    protected function displayValue(string $field, $value): string
    {
        if ($value === null || $value === '') {
            return '';
        }

        if (in_array($field, ['broker_id', 'agent_id'], true)) {
            return $this->agentName($value);
        }

        return $this->stringify($value);
    }

    /**
     * Cached agent id => name lookup for broker/agent fields.
     */
    protected function agentName($id): string
    {
        static $cache = [];

        $id = (string) $id;
        if (! array_key_exists($id, $cache)) {
            $cache[$id] = optional(Agent::find($id))->name;
        }

        return $cache[$id] !== null && $cache[$id] !== ''
            ? $cache[$id]
            : ('#' . $id);
    }

    /**
     * True when two values differ only in formatting, not in meaning.
     */
    protected function valuesEquivalent($a, $b): bool
    {
        if ($a === $b) {
            return true;
        }

        $aEmpty = $a === null || $a === '';
        $bEmpty = $b === null || $b === '';
        if ($aEmpty && $bEmpty) {
            return true;
        }
        if ($aEmpty !== $bEmpty) {
            return false;
        }

        if (is_numeric($a) && is_numeric($b)) {
            return (float) $a === (float) $b;
        }

        return trim((string) $a) === trim((string) $b);
    }

    protected function stringify($v): string
    {
        if (is_null($v)) {
            return '';
        }
        if (is_bool($v)) {
            return $v ? 'true' : 'false';
        }
        if (is_array($v)) {
            return json_encode($v);
        }

        return Str::limit((string) $v, 80);
    }

    public function index(Request $request)
    {
        $userId = trim((string) $request->query('user_id', ''));
        $model = trim((string) $request->query('model', ''));
        $action = trim((string) $request->query('action', ''));
        $q = trim((string) $request->query('q', ''));

        $query = AuditLog::with('user')->latest('id');

        if ($userId !== '') {
            $query->where('user_id', $userId);
        }
        if ($model !== '') {
            $query->where('auditable_type', $model);
        }
        if ($action !== '') {
            $query->where('action', $action);
        }
        if ($q !== '') {
            $query->where(function ($sub) use ($q) {
                $sub->where('action', 'like', '%' . $q . '%')
                    ->orWhere('auditable_type', 'like', '%' . $q . '%')
                    ->orWhere('auditable_id', $q)
                    ->orWhere('meta', 'like', '%' . $q . '%');
            });
        }

        $logs = $query->paginate(50)->withQueryString();

        $users = \App\Models\User::orderBy('name')
            ->get(['id', 'name'])
            ->mapWithKeys(fn ($u) => [$u->id => $u->name])
            ->all();

        $models = AuditLog::query()
            ->whereNotNull('auditable_type')
            ->distinct()
            ->orderBy('auditable_type')
            ->pluck('auditable_type')
            ->mapWithKeys(fn ($m) => [$m => class_basename($m)])
            ->all();

        return view('audit_logs.index', [
            'title' => 'Database Log',
            'logs' => $logs,
            'users' => $users,
            'models' => $models,
            'userId' => $userId,
            'model' => $model,
            'action' => $action,
            'q' => $q,
        ]);
    }
}
