<?php

namespace App\Http\Middleware;

use App\Models\ActivityLog;
use Closure;
use Illuminate\Http\Request;
use Illuminate\Support\Str;
use Symfony\Component\HttpFoundation\Response;

class LogActivity
{
    /**
     * Log every authenticated page access (which user hit which URL / module).
     * Runs after the response so we can capture the status code.
     */
    public function handle(Request $request, Closure $next): Response
    {
        $response = $next($request);

        try {
            $this->log($request, $response);
        } catch (\Throwable $e) {
            // Never let logging break a request.
        }

        return $response;
    }

    protected function log(Request $request, Response $response): void
    {
        // Skip noise: only log GET/POST/PUT/PATCH/DELETE for real pages/actions.
        if ($request->isMethod('OPTIONS') || $request->isMethod('HEAD')) {
            return;
        }

        $path = $request->path();

        // Skip static assets and framework noise.
        foreach (['_debugbar', 'livewire', 'sanctum', 'up', 'favicon.ico'] as $skip) {
            if (Str::startsWith($path, $skip)) {
                return;
            }
        }
        if (Str::contains($path, ['.css', '.js', '.png', '.jpg', '.jpeg', '.gif', '.svg', '.woff', '.ico', '.map'])) {
            return;
        }

        $user = $request->user();

        ActivityLog::create([
            'user_id' => $user?->id,
            'user_name' => $user?->name,
            'method' => $request->method(),
            'url' => Str::limit($request->fullUrl(), 2000, ''),
            'route_name' => optional($request->route())->getName(),
            'module' => $this->moduleFromPath($path),
            'status_code' => method_exists($response, 'getStatusCode') ? $response->getStatusCode() : null,
            'ip' => $request->ip(),
            'user_agent' => Str::limit((string) $request->userAgent(), 500, ''),
        ]);
    }

    /**
     * Derive a friendly module name from the first URL segment.
     */
    protected function moduleFromPath(string $path): string
    {
        $segment = explode('/', trim($path, '/'))[0] ?? '';

        if ($segment === '' || $segment === 'dashboard') {
            return 'Dashboard';
        }

        return Str::title(str_replace('-', ' ', $segment));
    }
}
