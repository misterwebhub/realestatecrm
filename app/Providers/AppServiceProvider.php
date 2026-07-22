<?php

namespace App\Providers;

use App\Models\AuditLog;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Pagination\Paginator;
use Illuminate\Support\Facades\Event;
use Illuminate\Support\ServiceProvider;

class AppServiceProvider extends ServiceProvider
{
    /**
     * Models that should never be audited (log tables, auth noise, etc.).
     */
    protected array $auditExcept = [
        \App\Models\AuditLog::class,
        \App\Models\ActivityLog::class,
    ];

    /**
     * Attribute names to redact from the stored diff.
     */
    protected array $auditHidden = [
        'password', 'remember_token', 'api_token', 'two_factor_secret',
    ];

    /**
     * Register any application services.
     */
    public function register(): void
    {
        //
    }

    /**
     * Bootstrap any application services.
     */
    public function boot(): void
    {
        Paginator::useBootstrapFive();

        $this->registerOwnershipStamping();
        $this->registerAuditLogging();
    }

    /**
     * Stamp `created_by` with the current user on any model that has the column,
     * so records can later be scoped to the user who created them. Admins are
     * still able to see everything (scoping is enforced at read time).
     */
    protected function registerOwnershipStamping(): void
    {
        static $hasColumn = [];

        Event::listen('eloquent.creating: *', function ($eventName, $data) use (&$hasColumn) {
            $model = $data[0] ?? null;
            if (! $model instanceof Model) {
                return;
            }

            $userId = auth()->id();
            if (! $userId) {
                return; // console / seed / unauthenticated — leave it null
            }

            $table = $model->getTable();
            if (! array_key_exists($table, $hasColumn)) {
                try {
                    $hasColumn[$table] = \Illuminate\Support\Facades\Schema::hasColumn($table, 'created_by');
                } catch (\Throwable $e) {
                    $hasColumn[$table] = false;
                }
            }

            if ($hasColumn[$table] && empty($model->getAttribute('created_by'))) {
                $model->setAttribute('created_by', $userId);
            }
        });
    }

    /**
     * Record every model create/update/delete into the audit_logs table.
     */
    protected function registerAuditLogging(): void
    {
        // NOTE: these MUST be wildcard event listeners. Registering via
        // Model::created()/updated()/deleted() only fires for the base Model
        // class, NOT its subclasses, so nothing would ever be logged.
        Event::listen('eloquent.created: *', function ($eventName, $data) {
            $model = $data[0] ?? null;
            if ($model instanceof Model) {
                $this->writeAudit('created', $model, null, $this->cleanAttrs($model->getAttributes()));
            }
        });

        Event::listen('eloquent.updated: *', function ($eventName, $data) {
            $model = $data[0] ?? null;
            if (! $model instanceof Model) {
                return;
            }
            $changes = $model->getChanges();
            unset($changes['updated_at']);

            // Drop "changes" where the value is only formatted differently
            // (e.g. "350000.00" -> 350000, "50.00" -> 50). These are not real edits.
            $old = [];
            foreach (array_keys($changes) as $key) {
                $originalVal = $model->getOriginal($key);
                if ($this->valuesEquivalent($originalVal, $changes[$key])) {
                    unset($changes[$key]);
                    continue;
                }
                $old[$key] = $originalVal;
            }

            if (empty($changes)) {
                return;
            }

            $this->writeAudit('updated', $model, $this->cleanAttrs($old), $this->cleanAttrs($changes));
        });

        Event::listen('eloquent.deleted: *', function ($eventName, $data) {
            $model = $data[0] ?? null;
            if ($model instanceof Model) {
                $this->writeAudit('deleted', $model, $this->cleanAttrs($model->getOriginal()), null);
            }
        });
    }

    protected function writeAudit(string $action, Model $model, ?array $old, ?array $new): void
    {
        if (in_array(get_class($model), $this->auditExcept, true)) {
            return;
        }

        try {
            AuditLog::create([
                'user_id' => auth()->id(),
                'auditable_type' => get_class($model),
                'auditable_id' => $model->getKey(),
                'action' => $action,
                'meta' => array_filter([
                    'user_name' => auth()->user()?->name,
                    'table' => $model->getTable(),
                    'ip' => request()?->ip(),
                    'old' => $old,
                    'new' => $new,
                ], fn ($v) => $v !== null),
            ]);
        } catch (\Throwable $e) {
            // Auditing must never break the request.
        }
    }

    /**
     * True when two values differ only in formatting (e.g. "350000.00" vs 350000,
     * "50.00" vs 50, null vs "", trailing whitespace) and not in actual meaning.
     */
    protected function valuesEquivalent($a, $b): bool
    {
        if ($a === $b) {
            return true;
        }

        // Treat null and empty string as the same "empty" value.
        $aEmpty = $a === null || $a === '';
        $bEmpty = $b === null || $b === '';
        if ($aEmpty && $bEmpty) {
            return true;
        }
        if ($aEmpty !== $bEmpty) {
            return false;
        }

        // Numeric values that are equal in value but differ in formatting
        // ("350000.00" == 350000, "50.00" == 50).
        if (is_numeric($a) && is_numeric($b)) {
            return (float) $a === (float) $b;
        }

        // Fall back to trimmed string comparison.
        return trim((string) $a) === trim((string) $b);
    }

    protected function cleanAttrs(array $attrs): array
    {
        foreach ($this->auditHidden as $key) {
            if (array_key_exists($key, $attrs)) {
                $attrs[$key] = '••••';
            }
        }

        return $attrs;
    }
}
