<?php

namespace App\Providers;

use App\Models\AuditLog;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Pagination\Paginator;
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

        $this->registerAuditLogging();
    }

    /**
     * Record every model create/update/delete into the audit_logs table.
     */
    protected function registerAuditLogging(): void
    {
        Model::created(function (Model $model) {
            $this->writeAudit('created', $model, null, $this->cleanAttrs($model->getAttributes()));
        });

        Model::updated(function (Model $model) {
            $changes = $model->getChanges();
            unset($changes['updated_at']);
            if (empty($changes)) {
                return;
            }
            $old = [];
            foreach (array_keys($changes) as $key) {
                $old[$key] = $model->getOriginal($key);
            }
            $this->writeAudit('updated', $model, $this->cleanAttrs($old), $this->cleanAttrs($changes));
        });

        Model::deleted(function (Model $model) {
            $this->writeAudit('deleted', $model, $this->cleanAttrs($model->getAttributes()), null);
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
