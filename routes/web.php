<?php

use App\Http\Controllers\AgentController;
use App\Http\Controllers\AraziController;
use App\Http\Controllers\AraziDocumentController;
use App\Http\Controllers\AuthController;
use App\Http\Controllers\CustomerBondPaymentController;
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
use Illuminate\Support\Facades\Route;

Route::get('/login', [AuthController::class, 'showLogin'])->name('login');
Route::post('/login', [AuthController::class, 'login'])->name('login.post');
Route::post('/logout', [AuthController::class, 'logout'])->name('logout');

Route::middleware('auth')->group(function () {
    Route::redirect('/', '/dashboard');

    Route::get('/dashboard', [DashboardController::class, 'index'])->name('dashboard');

    Route::resource('kisans', KisanController::class)->except(['show']);
    Route::resource('arazis', AraziController::class)->except(['show'])->middleware('role:admin,manager');
    Route::resource('plots', PlotController::class)->except(['show']);
    Route::resource('customers', CustomerController::class)->except(['show']);
    Route::resource('agents', AgentController::class)->except(['show']);
    Route::resource('registries', RegistryController::class)->except(['show']);
    Route::get('registries/{registry}/print', [RegistryController::class, 'print'])->name('registries.print');
    Route::get('registries/{registry}/pdf', [RegistryController::class, 'pdf'])->name('registries.pdf');
    Route::post('registries/{registry}/esign', [RegistryController::class, 'esign'])->name('registries.esign');
    Route::get('registries/waiting-payments', [RegistryController::class, 'waitingPayments'])->name('registries.waiting-payments');
    Route::get('payments/print', [PaymentController::class, 'printReceipt'])->name('payments.print');
    Route::resource('payments', PaymentController::class)->except(['show']);
    Route::resource('kisan-bonds', KisanBondController::class)->except(['show']);
    Route::resource('customer-bonds', CustomerBondController::class)->except(['show']);
    Route::get('kisan-bonds/{kisan_bond}/print', [KisanBondController::class, 'print'])->name('kisan-bonds.print');
    Route::get('kisan-bonds/{kisan_bond}/pdf', [KisanBondController::class, 'pdf'])->name('kisan-bonds.pdf');
    Route::get('customer-bonds/{customer_bond}/print', [CustomerBondController::class, 'print'])->name('customer-bonds.print');
    Route::get('customer-bonds/{customer_bond}/pdf', [CustomerBondController::class, 'pdf'])->name('customer-bonds.pdf');
    Route::resource('bookings', BookingController::class)->except(['show']);
    Route::resource('sales', SaleController::class)->except(['show']);
    Route::resource('customer-bond-payments', CustomerBondPaymentController::class)->except(['show']);
    Route::resource('investors', InvestorController::class)->except(['show']);
    Route::resource('partners', PartnerController::class)->except(['show']);
    Route::resource('arazi-documents', AraziDocumentController::class)->parameters([
        'arazi-documents' => 'araziDocument',
    ])->except(['show']);
    Route::get('arazi-documents/{arazi_document}/download', [AraziDocumentController::class, 'download'])->name('arazi-documents.download');
});
