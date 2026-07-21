<?php

namespace App\Http\Controllers;

use App\Models\ActivityLog;
use Illuminate\Http\Request;

class ActivityLogController extends Controller
{
    public function index(Request $request)
    {
        $userId = trim((string) $request->query('user_id', ''));
        $module = trim((string) $request->query('module', ''));
        $method = trim((string) $request->query('method', ''));
        $q = trim((string) $request->query('q', ''));

        $query = ActivityLog::query()->latest('id');

        if ($userId !== '') {
            $query->where('user_id', $userId);
        }
        if ($module !== '') {
            $query->where('module', $module);
        }
        if ($method !== '') {
            $query->where('method', $method);
        }
        if ($q !== '') {
            $query->where(function ($sub) use ($q) {
                $sub->where('url', 'like', '%' . $q . '%')
                    ->orWhere('route_name', 'like', '%' . $q . '%')
                    ->orWhere('user_name', 'like', '%' . $q . '%')
                    ->orWhere('ip', 'like', '%' . $q . '%');
            });
        }

        $logs = $query->paginate(50)->withQueryString();

        $users = \App\Models\User::orderBy('name')
            ->get(['id', 'name'])
            ->mapWithKeys(fn ($u) => [$u->id => $u->name])
            ->all();

        $modules = ActivityLog::query()
            ->whereNotNull('module')
            ->distinct()
            ->orderBy('module')
            ->pluck('module')
            ->all();

        return view('activity_logs.index', [
            'title' => 'Activity Logs',
            'logs' => $logs,
            'users' => $users,
            'modules' => $modules,
            'userId' => $userId,
            'module' => $module,
            'method' => $method,
            'q' => $q,
        ]);
    }
}
