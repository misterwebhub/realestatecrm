<?php

// Uploads controllers
use App\Http\Controllers\UploadController;
use App\Http\Controllers\UploadCategoryController;
use App\Http\Controllers\KisanRegistryController;

use App\Http\Controllers\AgentController;
use App\Http\Controllers\UserMasterController;
use App\Http\Controllers\AraziController;
use App\Http\Controllers\AraziDocumentController;
use App\Http\Controllers\AuthController;
use App\Http\Controllers\CustomerBondPaymentController;
use App\Http\Controllers\CustomerBondChequeController;
use App\Http\Controllers\CustomerController;
use App\Http\Controllers\DashboardController;
use App\Http\Controllers\InvestorController;
use App\Http\Controllers\KisanController;
use App\Http\Controllers\KisanBondController;
use App\Http\Controllers\CustomerBondController;
use App\Http\Controllers\BookingController;
use App\Http\Controllers\SaleController;
use App\Http\Controllers\PartnerController;
use App\Http\Controllers\PaymentController;
use App\Http\Controllers\PlotController;
use App\Http\Controllers\RegistryController;
use App\Http\Controllers\SettingsController;
use Illuminate\Support\Facades\Route;

Route::get('/login', [AuthController::class, 'showLogin'])->name('login');
Route::post('/login', [AuthController::class, 'login'])->name('login.post');
Route::post('/logout', [AuthController::class, 'logout'])->name('logout');

Route::middleware(['auth', 'office-hours'])->group(function () {
    Route::redirect('/', '/dashboard');

    Route::get('/dashboard', [DashboardController::class, 'index'])->name('dashboard');
    Route::get('/quick-access', [\App\Http\Controllers\QuickAccessController::class, 'index'])->name('quick-access');

    Route::get('/settings', [SettingsController::class, 'index'])->name('settings.index');
    Route::post('/settings/password', [SettingsController::class, 'updatePassword'])->name('settings.password');
    Route::post('/settings/office-hours', [SettingsController::class, 'updateOfficeHours'])->name('settings.office-hours');
    Route::post('/settings/location-defaults', [SettingsController::class, 'updateLocationDefaults'])->name('settings.location-defaults');

    Route::post('/session/auto-logout', [AuthController::class, 'autoLogout'])->name('session.auto-logout');

    Route::resource('kisans', KisanController::class)->except(['show']);
    // AJAX endpoints to support modal creation of Kisan from other forms
    Route::get('kisans/create-fragment', [KisanController::class, 'createFragment'])->name('kisans.create-fragment');
    Route::post('kisans/ajax-store', [KisanController::class, 'storeAjax'])->name('kisans.ajax-store');
    // AJAX endpoints to support modal creation of Arazi from other forms
    Route::get('arazis/create-fragment', [AraziController::class, 'createFragment'])->name('arazis.create-fragment')->middleware('permission:arazis.create');
    Route::post('arazis/ajax-store', [AraziController::class, 'storeAjax'])->name('arazis.ajax-store')->middleware('permission:arazis.create');

    Route::resource('arazis', AraziController::class)->except(['show'])->middleware('permission:arazis.view');

    // Arazi Groups: select a map name + merge multiple arazis (create/list/delete only, no edit)
    Route::get('arazi-groups', [\App\Http\Controllers\AraziGroupController::class, 'index'])->name('arazi-groups.index');
    Route::get('arazi-groups/create', [\App\Http\Controllers\AraziGroupController::class, 'create'])->name('arazi-groups.create');
    Route::post('arazi-groups', [\App\Http\Controllers\AraziGroupController::class, 'store'])->name('arazi-groups.store');
    Route::get('arazi-groups/{araziGroup}/edit', [\App\Http\Controllers\AraziGroupController::class, 'edit'])->name('arazi-groups.edit');
    Route::put('arazi-groups/{araziGroup}', [\App\Http\Controllers\AraziGroupController::class, 'update'])->name('arazi-groups.update');
    Route::delete('arazi-groups/{araziGroup}', [\App\Http\Controllers\AraziGroupController::class, 'destroy'])->name('arazi-groups.destroy');
    Route::resource('plots', PlotController::class)->except(['show']);
    Route::get('plot-holds', [\App\Http\Controllers\PlotHoldController::class, 'index'])->name('plot-holds.index');
    Route::post('plot-holds', [\App\Http\Controllers\PlotHoldController::class, 'store'])->name('plot-holds.store');
    Route::post('plot-holds/{plotHold}/release', [\App\Http\Controllers\PlotHoldController::class, 'release'])->name('plot-holds.release');

    Route::get('activity-logs', [\App\Http\Controllers\ActivityLogController::class, 'index'])->name('activity-logs.index');
    Route::get('audit-logs', [\App\Http\Controllers\AuditLogController::class, 'index'])->name('audit-logs.index');
    Route::get('change-log', [\App\Http\Controllers\AuditLogController::class, 'forRecord'])->name('change-log.record');
    Route::resource('customers', CustomerController::class)->except(['show']);
    Route::get('agents/type/{type}', [AgentController::class, 'typeIndex'])->name('agents.type.index');
    Route::post('agents/type/{type}', [AgentController::class, 'typeStore'])->name('agents.type.store');
    Route::resource('agents', AgentController::class)->except(['show']);
    Route::resource('registries', RegistryController::class)->except(['show']);
    Route::get('registries/{registry}/download', [RegistryController::class, 'download'])->name('registries.download');
    Route::get('registries/{registry}/print', [RegistryController::class, 'print'])->name('registries.print');
    Route::get('registries/{registry}/pdf', [RegistryController::class, 'pdf'])->name('registries.pdf');
    Route::post('registries/{registry}/esign', [RegistryController::class, 'esign'])->name('registries.esign');
    Route::get('registries/waiting-payments', [RegistryController::class, 'waitingPayments'])->name('registries.waiting-payments');
    Route::get('registries/bond-lookup', [RegistryController::class, 'bondLookup'])->name('registries.bond-lookup');
    Route::get('registries/deeds-by-arazi', [RegistryController::class, 'deedsByArazi'])->name('registries.deeds-by-arazi');
    Route::get('registries/arazi-group-options', [RegistryController::class, 'araziGroupOptions'])->name('registries.arazi-group-options');
    Route::get('registries/partners-by-arazi', [RegistryController::class, 'partnersByArazi'])->name('registries.partners-by-arazi');
    Route::get('kisan-payment/print', [PaymentController::class, 'printReceipt'])->name('kisan-payment.print');
    Route::get('kisan-payment/receipt-pdf', [PaymentController::class, 'receiptPdf'])->name('kisan-payment.receipt-pdf');
    // Kisan-scoped payment routes (list/create for a specific kisan)
    Route::get('kisans/{kisan}/kisan-payment', [PaymentController::class, 'index'])->name('kisans.kisan-payment.index');
    Route::get('kisans/{kisan}/kisan-payment/create', [PaymentController::class, 'create'])->name('kisans.kisan-payment.create');
    Route::post('kisans/{kisan}/kisan-payment', [PaymentController::class, 'store'])->name('kisans.kisan-payment.store');

    Route::get('kisan-payment-ledger', [PaymentController::class, 'ledger'])->name('kisan-payment.ledger');
    Route::get('kisan-payment-ledger/export/csv', [PaymentController::class, 'ledgerExportCsv'])->name('kisan-payment.ledger.export.csv');
    Route::get('kisan-payment/export/csv', [PaymentController::class, 'exportCsv'])->name('kisan-payment.export.csv');
    Route::resource('kisan-payment', PaymentController::class)->names('kisan-payment')->except(['show']);
    Route::resource('kisan-bonds', KisanBondController::class)->except(['show']);
    Route::get('customer-bonds/by-bond-no', [CustomerBondController::class, 'byBondNo'])->name('customer-bonds.by-bond-no');
    Route::get('customer-bonds/{customer_bond}/payment-context', [CustomerBondController::class, 'paymentContext'])->name('customer-bonds.payment-context');
    Route::get('customer-bonds/{customer_bond}/cheques-modal', [CustomerBondController::class, 'chequesModal'])->name('customer-bonds.cheques-modal');
    Route::resource('customer-bonds', CustomerBondController::class)->except(['show']);
    Route::get('kisan-bonds/{kisan_bond}/print', [KisanBondController::class, 'print'])->name('kisan-bonds.print');
    Route::get('kisan-bonds/{kisan_bond}/pdf', [KisanBondController::class, 'pdf'])->name('kisan-bonds.pdf');
    Route::get('customer-bonds/{customer_bond}/print', [CustomerBondController::class, 'print'])->name('customer-bonds.print');
    Route::get('customer-bonds/{customer_bond}/pdf', [CustomerBondController::class, 'pdf'])->name('customer-bonds.pdf');
    Route::resource('bookings', BookingController::class)->except(['show']);
    Route::resource('sales', SaleController::class)->except(['show']);
    Route::get('customer-payment-ledger', [CustomerBondPaymentController::class, 'ledger'])->name('customer-bond-payments.ledger');
    Route::get('customer-payment-ledger/export/csv', [CustomerBondPaymentController::class, 'ledgerExportCsv'])->name('customer-bond-payments.ledger.export.csv');
    Route::get('customer-bond-payments/compact', [CustomerBondPaymentController::class, 'compact'])->name('customer-bond-payments.compact');
    Route::get('customer-bond-payments/export/csv', [CustomerBondPaymentController::class, 'exportCsv'])->name('customer-bond-payments.export.csv');
    Route::get('customer-bond-payments/receipt', [CustomerBondPaymentController::class, 'printReceipt'])->name('customer-bond-payments.receipt');
    Route::get('customer-bond-payments/receipt-pdf', [CustomerBondPaymentController::class, 'receiptPdf'])->name('customer-bond-payments.receipt-pdf');
    Route::get('customer-bond-payments/lookup-entry', [CustomerBondPaymentController::class, 'lookupEntry'])->name('customer-bond-payments.lookup-entry');
    Route::delete('customer-bond-payments/delete-by-entry', [CustomerBondPaymentController::class, 'deleteByEntry'])->name('customer-bond-payments.delete-by-entry');
    Route::resource('customer-bond-payments', CustomerBondPaymentController::class)->except(['show']);
    Route::resource('customer-bond-cheques', CustomerBondChequeController::class)->except(['show']);
    Route::get('customer-bond-cheques/by-bond/{customer_bond}', [CustomerBondChequeController::class, 'forBond'])->name('customer-bond-cheques.for-bond');
    Route::get('customer-bond-cheques/manage/{customer_bond}', [CustomerBondChequeController::class, 'manage'])->name('customer-bond-cheques.manage');
    Route::post('customer-bond-cheques/bulk-save', [CustomerBondChequeController::class, 'storeBulk'])->name('customer-bond-cheques.bulk-save');
    Route::get('customer-bond-cheques/manual', [CustomerBondChequeController::class, 'manualCreate'])->name('customer-bond-cheques.manual');
    Route::post('customer-bond-cheques/manual', [CustomerBondChequeController::class, 'manualStore'])->name('customer-bond-cheques.manual-store');
    Route::get('customer-bond-cheques/manual/template', [CustomerBondChequeController::class, 'manualTemplate'])->name('customer-bond-cheques.manual-template');
    Route::post('customer-bond-cheques/manual/import', [CustomerBondChequeController::class, 'manualImport'])->name('customer-bond-cheques.manual-import');
    Route::get('customer-bond-cheques/assign', [CustomerBondChequeController::class, 'assignForm'])->name('customer-bond-cheques.assign');
    Route::post('customer-bond-cheques/assign', [CustomerBondChequeController::class, 'assignStore'])->name('customer-bond-cheques.assign-store');
    Route::post('customer-bond-cheques/bulk-delete', [CustomerBondChequeController::class, 'bulkDelete'])->name('customer-bond-cheques.bulk-delete');
    Route::post('customer-bond-cheques/unassign', [CustomerBondChequeController::class, 'unassign'])->name('customer-bond-cheques.unassign');
    Route::get('customer-bond-cheques/assign/export', [CustomerBondChequeController::class, 'assignExport'])->name('customer-bond-cheques.assign-export');
    Route::get('connected-accounts/list', [\App\Http\Controllers\ConnectedAccountController::class, 'list'])->name('connected-accounts.list');
    Route::resource('connected-accounts', \App\Http\Controllers\ConnectedAccountController::class)->except(['show']);
    Route::resource('investors', InvestorController::class)->except(['show']);
    Route::resource('partners', PartnerController::class)->except(['show']);
    Route::resource('arazi-documents', AraziDocumentController::class)->parameters([
        'arazi-documents' => 'araziDocument',
    ])->except(['show']);
    Route::get('arazi-documents/{arazi_document}/download', [AraziDocumentController::class, 'download'])->name('arazi-documents.download');
    
    // Uploads module
    Route::get('uploads', [UploadController::class, 'index'])->name('uploads.index');
    Route::get('uploads/create', [UploadController::class, 'create'])->name('uploads.create');
    Route::post('uploads', [UploadController::class, 'store'])->name('uploads.store');
    Route::get('uploads/{upload}/download', [UploadController::class, 'download'])->name('uploads.download');
    Route::get('ajax/arazi-search', [UploadController::class, 'ajaxAraziSearch'])->name('ajax.arazi.search');
    Route::get('ajax/kisans-by-arazi', [KisanController::class, 'byArazi'])->name('ajax.kisans.by-arazi');

    Route::get('upload-categories', [UploadCategoryController::class, 'index'])->name('upload-categories.index');
    Route::post('upload-categories', [UploadCategoryController::class, 'store'])->name('upload-categories.store');
    Route::post('upload-categories/ajax-store', [UploadCategoryController::class, 'ajaxStore'])->name('upload-categories.ajax-store');
    // Area converter
    Route::get('converter', [\App\Http\Controllers\AreaConverterController::class, 'index'])->name('converter.index');
    Route::post('converter', [\App\Http\Controllers\AreaConverterController::class, 'convert'])->name('converter.convert');
    Route::get('arazi/{arazi}/plots', [\App\Http\Controllers\AraziController::class, 'plots'])->name('arazis.plots');
    Route::get('arazi/{arazi}/info', [\App\Http\Controllers\AraziController::class, 'info'])->name('arazis.info');
    Route::get('arazi/{code}/dashboard', [\App\Http\Controllers\AraziDashboardController::class, 'show'])->name('arazi.dashboard');
    // Support both numeric id and legacy arazi code/plot_number via gridByIdentifier
    Route::get('arazi/{identifier}/grid', [\App\Http\Controllers\AraziController::class, 'gridByIdentifier'])->name('arazis.grid');
    Route::get('arazi/{arazi}/saleable', [\App\Http\Controllers\AraziController::class, 'saleable'])->name('arazis.saleable');
    Route::get('arazi/{arazi}/bond-info', [\App\Http\Controllers\AraziController::class, 'bondInfo'])->name('arazis.bond-info');
    Route::get('arazi/{arazi}/customers', [\App\Http\Controllers\AraziController::class, 'customers'])->name('arazis.customers');
    Route::get('arazi/{arazi}/details', [\App\Http\Controllers\AraziController::class, 'details'])->name('arazis.details');
    Route::get('arazi/by-code', [\App\Http\Controllers\AraziController::class, 'byCode'])->name('arazis.by-code');
    Route::get('arazi-no/{code}/plots', [\App\Http\Controllers\AraziController::class, 'plotsByAraziNo'])->name('arazis.plots-by-code');
    Route::get('arazi-no/{code}/details', [\App\Http\Controllers\AraziController::class, 'detailsByAraziNo'])->name('arazis.details-by-code');
    Route::get('arazi-code/{code}/saleable', [\App\Http\Controllers\AraziController::class, 'saleableByCode'])->name('arazis.saleable-by-code');
    Route::get('customer-bonds/by-plot/{plot}', [CustomerBondController::class, 'byPlot'])->name('customer-bonds.by-plot');
    
    // User Master
    Route::get('user-master/list', [UserMasterController::class, 'list'])->name('user-master.list');
    Route::get('user-master/report', [UserMasterController::class, 'report'])->name('user-master.report');
    Route::get('user-master/{userMaster}/receipts', [UserMasterController::class, 'receipts'])->name('user-master.receipts');
    Route::get('user-master/{userMaster}/password', [UserMasterController::class, 'password'])->name('user-master.password');
    Route::post('user-master/{userMaster}/reset-password', [UserMasterController::class, 'resetPassword'])->name('user-master.reset-password');
    Route::resource('user-master', UserMasterController::class)->except(['show'])->parameters(['user-master' => 'userMaster']);

    // Roles & Permissions (managed by users with the 'roles' permission; Super Admin always allowed)
    Route::resource('roles', \App\Http\Controllers\RoleController::class)
        ->except(['show'])
        ->middleware('permission:roles.view');

    // Expenses
    Route::get('expenses', [\App\Http\Controllers\ExpenseController::class, 'index'])->name('expenses.index');
    Route::get('expenses/create', [\App\Http\Controllers\ExpenseController::class, 'create'])->name('expenses.create');
    Route::post('expenses', [\App\Http\Controllers\ExpenseController::class, 'store'])->name('expenses.store');
    // Expense types (AJAX)
    Route::post('expense-types/ajax-store', [\App\Http\Controllers\ExpenseTypeController::class, 'ajaxStore'])->name('expense-types.ajax-store');
    // Expense types: separate page create + store
    Route::get('expense-types/create', [\App\Http\Controllers\ExpenseTypeController::class, 'create'])->name('expense-types.create');
    Route::post('expense-types', [\App\Http\Controllers\ExpenseTypeController::class, 'store'])->name('expense-types.store');
    // Kisan Registry
    Route::resource('kisan-registries', KisanRegistryController::class)->except(['show']);
    Route::get('kisan-registries/{kisanRegistry}/download', [KisanRegistryController::class, 'download'])->name('kisan-registries.download');

    Route::get('kisans/{kisan}/arazis', [\App\Http\Controllers\KisanController::class, 'arazis'])->name('kisans.arazis');
    Route::get('kisans/{kisan}/bonds', [\App\Http\Controllers\KisanController::class, 'bonds'])->name('kisans.bonds');
    Route::get('customers/{customer}/bonds', [\App\Http\Controllers\CustomerController::class, 'bonds'])->name('customers.bonds');
    Route::get('customers/{customer}/dashboard', [\App\Http\Controllers\CustomerDashboardController::class, 'show'])->name('customer.dashboard');
    // Reports
    Route::get('reports', [\App\Http\Controllers\ReportsController::class, 'index'])->name('reports.index');
    Route::get('reports/plot-details', [\App\Http\Controllers\ReportsController::class, 'plotDetails'])->name('reports.plot.details');
    Route::get('reports/customer-payments-by-user', [\App\Http\Controllers\ReportsController::class, 'customerPaymentsByUser'])->name('reports.customer-payments.by-user');
    Route::get('reports/deeds-by-arazi', [\App\Http\Controllers\ReportsController::class, 'deedsByArazi'])->name('reports.deeds-by-arazi');
    Route::get('reports/bonds-cumulative', [\App\Http\Controllers\ReportsController::class, 'bondsCumulative'])->name('reports.bonds-cumulative');
    Route::get('reports/bond-cheques', [\App\Http\Controllers\ReportsController::class, 'bondCheques'])->name('reports.bond-cheques');
    Route::get('reports/partners', [\App\Http\Controllers\ReportsController::class, 'partners'])->name('reports.partners');
    Route::get('reports/arazis', [\App\Http\Controllers\ReportsController::class, 'arazis'])->name('reports.arazis');
    Route::get('reports/brokers', [\App\Http\Controllers\ReportsController::class, 'brokers'])->name('reports.brokers');
    Route::get('reports/registries', [\App\Http\Controllers\ReportsController::class, 'registries'])->name('reports.registries');
    Route::get('reports/payments', [\App\Http\Controllers\ReportsController::class, 'payments'])->name('reports.payments');
    Route::get('reports/sales', [\App\Http\Controllers\ReportsController::class, 'sales'])->name('reports.sales');

    // Arazis Map index: list folders under project root `arazis-map` and link to their index.php
    // Serve legacy map PHP files through Laravel to ensure environment variables (DB_*) are available.
    Route::get('arazis-map/serve/{folder}/{file?}', function ($folder, $file = 'index.php') {
        $base = base_path('arazis-map');
        // basic sanitization: allow only simple folder names
        if (! preg_match('/^[a-zA-Z0-9_\-]+$/', $folder)) {
            abort(404);
        }

        $requested = realpath($base . DIRECTORY_SEPARATOR . $folder . DIRECTORY_SEPARATOR . $file);
        if (! $requested || ! str_starts_with($requested, realpath($base . DIRECTORY_SEPARATOR . $folder))) {
            abort(404);
        }

        // set DB env vars from Laravel config so legacy scripts relying on getenv/$_ENV find them
        $defaultConn = config('database.default');
        $conn = config('database.connections.' . $defaultConn, []);
        $map = [
            'DB_HOST' => $conn['host'] ?? env('DB_HOST'),
            'DB_PORT' => $conn['port'] ?? env('DB_PORT'),
            'DB_DATABASE' => $conn['database'] ?? env('DB_DATABASE'),
            'DB_USERNAME' => $conn['username'] ?? env('DB_USERNAME'),
            'DB_PASSWORD' => $conn['password'] ?? env('DB_PASSWORD'),
        ];
        foreach ($map as $k => $v) {
            if ($v !== null) {
                putenv("{$k}={$v}");
                $_ENV[$k] = $v;
                $_SERVER[$k] = $v;
            }
        }

        // include the legacy script inside its folder (adjust cwd so relative includes work)
        $cwd = getcwd();
        chdir(dirname($requested));
        ob_start();
        try {
            include $requested;
        } finally {
            $content = ob_get_clean();
            chdir($cwd);
        }

        return response($content, 200)->header('Content-Type', 'text/html');
    })->name('arazis.map.serve');
    Route::get('all-arazis-maps', function () {
        $base = base_path('arazis-map');
        $list = [];
        if (is_dir($base)) {
            $items = scandir($base);
            foreach ($items as $it) {
                if ($it === '.' || $it === '..') continue;
                if (in_array($it, ['assets', 'arazis-assets'])) continue;
                $path = $base . DIRECTORY_SEPARATOR . $it;
                if (! is_dir($path)) continue;

                $modified = file_exists($path) ? @filemtime($path) : null;

                // try to find a preview image inside the folder
                $previewFile = null;
                foreach (["preview.png", "preview.jpg", "thumb.png", "thumb.jpg", "screenshot.png"] as $cand) {
                    if (file_exists($path . DIRECTORY_SEPARATOR . $cand)) {
                        $previewFile = url('arazis-map/' . rawurlencode($it) . '/' . $cand);
                        break;
                    }
                }

                // count visible files
                $files = array_values(array_filter(scandir($path), function ($n) {
                    return $n !== '.' && $n !== '..';
                }));

                $list[] = [
                    'name' => $it,
                    'url' => url('arazis-map/' . rawurlencode($it) . '/index.php'),
                    'preview' => $previewFile,
                    'modified' => $modified ? date('d M Y H:i', $modified) : null,
                    'files_count' => count($files),
                ];
            }
        }

        usort($list, function ($a, $b) {
            // if both names numeric, sort numerically
            if (is_numeric($a['name']) && is_numeric($b['name'])) {
                return intval($a['name']) <=> intval($b['name']);
            }
            return strnatcmp($a['name'], $b['name']);
        });

        return view('arazis_map.index', ['folders' => $list]);
    })->name('arazis.map.index');
});
