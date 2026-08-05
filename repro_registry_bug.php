<?php
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Auth;

DB::beginTransaction();
try {
    $user = \App\Models\User::first();
    Auth::login($user);

    $partner = \App\Models\Partner::first();
    $agent = \App\Models\Agent::first();

    $payload = [
        'customer_id' => 107,
        'arazi_code' => '137',
        'partner_id' => $partner?->id,
        'agent_id' => $agent?->id,
        'plot_id' => 1221,
        'registry_date' => now()->format('Y-m-d'),
        'deed_no' => 'REPRO-DEED',
        'circle_value' => 0,
        'booking_mode' => 'other',
        'land_size' => 102,
        'registry_amount' => 100000,
        'witnesses' => [['name' => 'Test W']],
        'status' => 'pending',
        'payment_status' => 'pending',
        'lock_status' => 'unlock',
        'plot_sizes' => [
            '1221' => 51,
            '1222' => 51,
        ],
    ];

    $file = \Illuminate\Http\UploadedFile::fake()->create('doc.pdf', 10, 'application/pdf');
    $payload['document'] = $file;

    $request = \Illuminate\Http\Request::create('/registries', 'POST', $payload);
    $request->files->set('document', $file);
    app()->instance('request', $request);

    $controller = app(\App\Http\Controllers\RegistryController::class);
    $response = $controller->store($request);

    echo "Store response: " . get_class($response) . "\n";

    $item = \App\Models\Registry::where('deed_no', 'REPRO-DEED')->latest()->first();
    if (!$item) { throw new Exception('No registry created!'); }

    echo "Registry id: {$item->id}, plot_id: {$item->plot_id}\n";
    echo "Pivot plots: " . $item->plots()->pluck('plots.id')->implode(',') . "\n";
    echo "allPlots: " . $item->allPlots()->pluck('id')->implode(',') . "\n";
} catch (\Throwable $e) {
    echo "ERROR: " . $e->getMessage() . "\n";
    echo $e->getTraceAsString() . "\n";
} finally {
    DB::rollBack();
    echo "Rolled back.\n";
}
