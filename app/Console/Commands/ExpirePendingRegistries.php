<?php

namespace App\Console\Commands;

use App\Services\RegistryLifecycleService;
use Illuminate\Console\Command;

class ExpirePendingRegistries extends Command
{
    protected $signature = 'registries:expire-pending';

    protected $description = 'Expire pending registries past due date and release arazi back to available status';

    public function handle(RegistryLifecycleService $registryLifecycleService): int
    {
        $expiredCount = $registryLifecycleService->expirePendingRegistries();

        $this->info("Expired pending registries: {$expiredCount}");

        return self::SUCCESS;
    }
}
