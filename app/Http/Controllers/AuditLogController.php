<?php

namespace App\Http\Controllers;

use App\Models\AuditLog;
use Illuminate\Http\Request;
use Illuminate\Support\Str;

class AuditLogController extends Controller
{
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
