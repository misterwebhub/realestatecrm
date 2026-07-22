<?php

namespace App\Http\Controllers;

use App\Models\Agent;
use App\Models\Arazi;
use App\Models\CustomerBondPayment;
use App\Models\Customer;
use App\Models\Kisan;
use App\Models\KisanBond;
use App\Models\Payment;
use App\Models\Registry;
use App\Services\RegistryLifecycleService;
use Illuminate\View\View;

class DashboardController extends Controller
{
    public function index(RegistryLifecycleService $registryLifecycleService): View
    {
        $registryLifecycleService->expirePendingRegistries();

        return view('dashboard', [
            // Shared inventory / reference data — global counts for everyone.
            'totalKisans' => Kisan::count(),
            'totalArazis' => Arazi::count(),
            'availableArazis' => Arazi::where('status', 'available')->count(),
            'soldArazis' => Arazi::where('status', 'sold')->count(),
            'totalAgents' => Agent::count(),

            // Deal data — non-admins only see their own; admins see everything.
            'totalCustomers' => $this->ownScope(Customer::query())->count(),
            'totalKisanBonds' => $this->ownScope(KisanBond::query())->count(),
            // Registry is treated as arazi bond flow for legacy-compatible dashboard summary.
            'totalAraziBonds' => $this->ownScope(Registry::query())->count(),
            'totalBondReceipts' => $this->ownScope(CustomerBondPayment::query())->count(),
            'recentPayments' => $this->ownScope(
                    Payment::with(['customer', 'kisan', 'registry.arazi'])->latest()
                )
                ->take(5)
                ->get(),
        ]);
    }

    /**
     * Restrict a deal-data query to the current user's own records, unless they
     * are a Super Admin (who sees everything). No-ops when the model lacks the
     * created_by column or nobody is authenticated.
     */
    protected function ownScope($query)
    {
        $user = auth()->user();
        if (! $user || $user->isSuperAdmin()) {
            return $query;
        }

        $model = $query->getModel();
        try {
            $hasColumn = \Illuminate\Support\Facades\Schema::hasColumn($model->getTable(), 'created_by');
        } catch (\Throwable $e) {
            $hasColumn = false;
        }

        if ($hasColumn) {
            $query->where($model->qualifyColumn('created_by'), $user->getKey());
        }

        return $query;
    }
}
