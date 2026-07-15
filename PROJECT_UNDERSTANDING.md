# Project Understanding - Real Estate CRM / Kisan Land Management

This document explains the overall understanding of this Laravel project.  
Ye file project ko quickly samajhne ke liye banayi gayi hai: purpose, modules, routes, database, views, important flows, and current local setup.

## Simple Functional Working Steps

This section explains how the project works in simple business language, not technical language.

1. User logs in to the system.

2. After login, user sees the dashboard. Dashboard gives quick summary of land, customers, payments, registry, and other business records.

3. Admin or manager first adds Kisan details. Kisan means the land owner or person from whom land is managed/purchased.

4. After adding Kisan, user adds Arazi details. Arazi means land details such as land size, road area, unit, and related Kisan.

5. From Arazi, user creates Plots. Plot means smaller parts of the land that can be sold or assigned to customers.

6. System checks available saleable land before allowing plot area. This helps avoid creating plots bigger than available land.

7. User adds Customers. Customers are people who buy or book plots/land.

8. User adds Brokers/Agents if a deal is handled by a broker.

9. When customer wants land/plot, user can create Customer Bond, Booking, Sale, or Registry depending on the business process.

10. In Customer Bond or payment forms, user selects Arazi and Plot. System automatically loads related plots and land size.

11. User records payments. Payments can be related to Kisan, Customer, Registry, Bond, or Plot depending on the module.

12. If registry process is required, user creates Registry entry with customer, arazi, amount, agent, witness, and other details.

13. User can print certificates, receipts, bonds, and registry documents whenever needed.

14. User can upload Arazi documents, so land-related papers stay linked with the Arazi record.

15. Area Converter helps convert land measurement units when entering or checking land/plot size.

16. Investors and partners can also be managed if land/business investment is shared.

17. Accountant or authorized user can check payments, receipts, pending payments, and financial records.

18. Admin/manager controls main master data like Kisans, Arazis, Plots, Customers, Agents, Bonds, Registries, Sales, and Reports.

Simple business flow:

```text
Login
→ Add Kisan
→ Add Arazi/Land
→ Create Plots
→ Add Customer
→ Create Bond/Booking/Sale/Registry
→ Record Payments
→ Print Receipt/Certificate
→ Track Pending Work and Reports
```

## 1. Project Purpose

This is a Laravel based Real Estate CRM / Kisan Land Management System.

Main business domain:

- Kisan / land owner management
- Arazi / land parcel management
- Plot creation and saleable area tracking
- Customer management
- Agent / broker management
- Customer bonds and Kisan bonds
- Payments, receipts, bookings, sales, registries
- Investor and partner management
- Arazi document upload/download
- Area conversion between land units
- Printable certificates and PDF documents

In short: ye app land purchase/sale, plot distribution, customers, brokers, bonds, payments aur registry process ko manage karta hai.

## 2. Technology Stack

- Backend framework: Laravel 10
- PHP version requirement: PHP 8.1+
- Database: MySQL/MariaDB, configured through `.env`
- Frontend: Blade templates
- UI assets: AdminLTE and Bootstrap Icons
- PDF generation: `barryvdh/laravel-dompdf`
- Local server: XAMPP/Apache

Important files:

- `composer.json` - PHP dependencies
- `.env` - environment and database configuration
- `routes/web.php` - web routes
- `app/Http/Controllers` - application controllers
- `app/Models` - Eloquent models
- `database/migrations` - database schema
- `resources/views` - Blade views
- `public` - web assets

## 3. Local URL / Public Folder Setup

Laravel normally runs from the `public` folder. Is project me user requirement ke according URL me `/public` nahi chahiye.

Current setup:

- Root front controller: `index.php`
- Root rewrite file: `.htaccess`
- Application URL in `.env`:

```env
APP_URL=http://localhost/realestatecrm-run
```

Expected local URL:

```text
http://localhost/realestatecrm-run/
```

Dashboard URL:

```text
http://localhost/realestatecrm-run/dashboard
```

The root `.htaccess` internally serves public assets like:

```text
http://localhost/realestatecrm-run/vendor/adminlte/css/adminlte.css
```

Actual file location:

```text
public/vendor/adminlte/css/adminlte.css
```

Note: This is a non-standard Laravel deployment workaround. Production me safest approach hota hai Apache/Nginx document root ko `public` folder par point karna.

## 4. Authentication and Roles

Authentication is handled by:

- `app/Http/Controllers/AuthController.php`
- `resources/views/auth/login.blade.php`

Routes:

- `GET /login`
- `POST /login`
- `POST /logout`

After login, user goes to dashboard:

```text
/dashboard
```

User roles are stored on the `users` table through migration:

```text
database/migrations/2026_04_25_020000_add_role_to_users.php
```

Known roles:

- `admin`
- `manager`
- `accountant`

UI menu visibility is role based in:

```text
resources/views/layouts/app.blade.php
```

Example:

- Arazi and Plots are visible mainly for `admin` and `manager`.
- Bonds and Payments are visible for `admin`, `manager`, and `accountant`.

Some routes also use role middleware, for example:

```php
Route::resource('arazis', AraziController::class)->except(['show'])->middleware('role:admin,manager');
```

## 5. Main Route Structure

Main routes are in:

```text
routes/web.php
```

Most modules are inside `auth` middleware, so login is required.

Important route groups/modules:

- `dashboard`
- `kisans`
- `arazis`
- `plots`
- `customers`
- `agents`
- `registries`
- `payments`
- `kisan-bonds`
- `customer-bonds`
- `bookings`
- `sales`
- `customer-bond-payments`
- `investors`
- `partners`
- `arazi-documents`
- `converter`

Important custom AJAX/API style routes:

```text
GET kisans/{kisan}/arazis
GET arazi/{arazi}/plots
GET arazi/{arazi}/saleable
```

These are used by forms to dynamically load related data.

## 6. Controller Pattern

Many controllers use a shared CRUD trait:

```text
app/Http/Controllers/Concerns/ManagesCrud.php
```

This trait handles common CRUD methods:

- `index`
- `create`
- `store`
- `edit`
- `update`
- `destroy`

Controllers define module-specific details such as:

- model class
- route name
- page title
- table columns
- form fields
- validation rules
- query customization
- row formatting
- after-save logic

This means many controllers are small because common CRUD behavior is centralized.

## 7. Main Controllers

Important controllers:

- `DashboardController` - dashboard summary
- `AuthController` - login/logout
- `KisanController` - Kisan CRUD and Kisan related Arazis
- `AraziController` - Arazi CRUD, plots endpoint, saleable area endpoint
- `PlotController` - Plot CRUD and saleable area validation
- `CustomerController` - Customer CRUD
- `AgentController` - Broker/agent CRUD
- `RegistryController` - Registry CRUD, print, PDF, e-sign, waiting payments
- `PaymentController` - Kisan/registry payments and receipt printing
- `KisanBondController` - Kisan bond CRUD, print/PDF
- `CustomerBondController` - Customer bond CRUD, print/PDF
- `CustomerBondPaymentController` - Customer receipt/payment CRUD
- `BookingController` - Booking CRUD
- `SaleController` - Sale CRUD
- `InvestorController` - Investor CRUD
- `PartnerController` - Partner CRUD
- `AraziDocumentController` - Arazi document upload/download
- `AreaConverterController` - Area conversion form and calculation

## 8. Main Models

Important models:

- `User`
- `Kisan`
- `Arazi`
- `Plot`
- `Customer`
- `Agent`
- `Registry`
- `Payment`
- `KisanBond`
- `KisanBondWitness`
- `CustomerBond`
- `CustomerBondWitness`
- `CustomerBondPayment`
- `Booking`
- `Sale`
- `Investor`
- `Partner`
- `AraziDocument`
- `Commission`
- `Installment`
- `AuditLog`
- `AraziInvestor`

## 9. Important Relationships

High-level relationship understanding:

- One Kisan can have many Arazis.
- One Arazi belongs to one Kisan.
- One Arazi can have many Plots.
- One Plot belongs to one Arazi.
- A Registry belongs to Customer, Arazi, and Agent.
- A Payment can belong to Registry, Kisan, and Customer depending on flow.
- A Customer Bond belongs to Customer, Arazi, and broker/Agent.
- A Customer Bond can have witnesses.
- A Customer Bond Payment can link Customer, Arazi, and Plot.
- Arazi can have uploaded documents.
- Arazi can be connected with investors through pivot/investor tables.

## 10. Arazi, Plot and Saleable Area Logic

Arazi represents land. Recent logic includes:

- `size`
- `road_area`
- `unit`
- computed saleable area

In `Arazi` model, saleable area is calculated approximately as:

```text
saleable_area = size - road_area
```

Plot logic:

- Plots belong to Arazi.
- Plot has area.
- Plot may have block.
- Plot creation/update checks available saleable area.

Important routes:

```text
GET /arazi/{arazi}/saleable
GET /arazi/{arazi}/plots
```

These are used in forms to:

- show available saleable area
- load plots after selecting Arazi
- fill land size from selected plot

## 11. Area Converter

Area converter files:

- `app/Http/Controllers/AreaConverterController.php`
- `app/Services/AreaConverter.php`
- `resources/views/converter/form.blade.php`

Purpose:

- Convert land area between supported units.
- Internally uses conversion logic, commonly converting through gaz.

Important note:

- Conversion constants should match business/local land measurement rules.
- If business rules differ by region, update `AreaConverter` service carefully.

## 12. Customer Bond and Payments

Customer Bond module handles customer land/bond certificate style records.

Important files:

- `app/Http/Controllers/CustomerBondController.php`
- `app/Models/CustomerBond.php`
- `resources/views/customer_bonds/form_certificate.blade.php`
- `resources/views/prints/customer_bond_certificate.blade.php`

Customer Bond Payment module:

- `app/Http/Controllers/CustomerBondPaymentController.php`
- `app/Models/CustomerBondPayment.php`

Recent changes link customer bond payments with:

- Arazi
- Plot
- Customer

Migration:

```text
database/migrations/2026_05_05_000010_add_arazi_and_plot_to_customer_bond_payments_table.php
```

## 13. Registry Flow

Registry module handles registry entries and printable registry certificates.

Important files:

- `app/Http/Controllers/RegistryController.php`
- `app/Models/Registry.php`
- `resources/views/registries/add.blade.php`
- `resources/views/registries/waiting.blade.php`
- `resources/views/prints/registry_certificate.blade.php`

Important features:

- Add/edit registry
- Print registry certificate
- Generate PDF
- E-sign placeholder action
- Waiting payments page

Routes include:

```text
registries/{registry}/print
registries/{registry}/pdf
registries/{registry}/esign
registries/waiting-payments
```

## 14. Payment Flow

Payment module handles payment records and receipt printing.

Important files:

- `app/Http/Controllers/PaymentController.php`
- `app/Models/Payment.php`
- `resources/views/payments/print.blade.php`

Important routes:

```text
payments/print
kisans/{kisan}/payments
kisans/{kisan}/payments/create
```

## 15. Views and UI

Main layout:

```text
resources/views/layouts/app.blade.php
```

Generic CRUD views:

```text
resources/views/crud/index.blade.php
resources/views/crud/form.blade.php
```

Standalone/special views:

- `resources/views/auth/login.blade.php`
- `resources/views/dashboard.blade.php`
- `resources/views/customer_bonds/form_certificate.blade.php`
- `resources/views/registries/add.blade.php`
- `resources/views/converter/form.blade.php`
- `resources/views/prints/*.blade.php`

AdminLTE assets are loaded from:

```text
public/vendor/adminlte
```

Current layout uses:

```text
vendor/adminlte/css/adminlte.css
vendor/adminlte/js/adminlte.js
```

## 16. AJAX / Base URL Handling

Because project runs inside subfolder:

```text
http://localhost/realestatecrm-run
```

AJAX URLs should not use root-relative paths like:

```js
fetch('/arazi/1/plots')
```

That would call:

```text
http://localhost/arazi/1/plots
```

Correct approach used now:

```php
route('arazis.plots', ['arazi' => '__ARAZI_ID__'])
route('arazis.saleable', ['arazi' => '__ARAZI_ID__'])
route('kisans.arazis', ['kisan' => '__KISAN_ID__'])
```

Then JavaScript replaces placeholder IDs.

This keeps URLs correct with project folder:

```text
http://localhost/realestatecrm-run/arazi/1/plots
```

## 17. Database Migrations Overview

Migrations are in:

```text
database/migrations
```

Main tables/features:

- users
- password reset tokens
- failed jobs
- personal access tokens
- kisans
- agents
- customers
- arazis
- plots
- registries
- payments
- customer bonds
- customer bond payments
- kisan bonds
- investors
- partners
- arazi documents
- bookings
- sales
- installments
- commissions
- audit logs
- witnesses
- arazi investor pivot data

Recent migrations:

```text
2026_05_04_000001_add_road_area_to_arazis_table.php
2026_05_04_000002_add_area_to_plots_table.php
2026_05_04_000003_add_unit_to_arazis_table.php
2026_05_04_000004_add_block_to_plots_table.php
2026_05_05_000010_add_arazi_and_plot_to_customer_bond_payments_table.php
```

## 18. Important Local Commands

Install dependencies:

```bash
composer install
```

Run migrations:

```bash
php artisan migrate
```

Clear Laravel cache:

```bash
php artisan optimize:clear
```

Clear compiled views:

```bash
php artisan view:clear
```

List routes:

```bash
php artisan route:list
```

Check PHP syntax:

```bash
php -l path/to/file.php
```

## 19. Common Issues and Fixes

### URL goes to `http://localhost/dashboard`

Reason:

```env
APP_URL=http://localhost
```

Fix:

```env
APP_URL=http://localhost/realestatecrm-run
```

Then run:

```bash
php artisan optimize:clear
```

### CSS not loading

Check whether this URL returns 200:

```text
http://localhost/realestatecrm-run/vendor/adminlte/css/adminlte.css
```

If it returns 404, check root `.htaccess`.

### AJAX not working

Avoid hardcoded root URLs:

```js
fetch('/some-url')
```

Use Laravel generated URLs:

```php
route('route.name', ['id' => '__ID__'])
```

### Old URL still redirecting

Browser/session may cache old intended URL. Try:

- logout and login again
- hard refresh with `Ctrl + F5`
- clear browser cookies for localhost
- run `php artisan optimize:clear`

## 20. Current Important Caveats

- Project is running without `/public` in URL through root `index.php` and `.htaccess`.
- This works for local XAMPP but is not the default Laravel deployment style.
- Some screens use main AdminLTE layout; some certificate/registry screens are standalone HTML.
- There are legacy fields and older migration names in the project, so database history should be handled carefully.
- Any new JavaScript/AJAX code should use Laravel route-generated URLs.
- Any new asset should be placed under `public` and referenced with `asset()`.

## 21. Suggested Development Rules

Follow these rules while changing this project:

- Use named routes instead of hardcoded URLs.
- Use `asset()` for CSS/JS/images.
- Use `route()` for form actions and AJAX endpoints.
- Keep new modules consistent with `ManagesCrud` if they are simple CRUD modules.
- Validate plot area against Arazi saleable area.
- Clear cache after route/config/view changes.
- Do not change Apache config unless deployment changes are planned.
- Be careful with migrations because this is an active database-driven CRM.

## 22. Quick File Reference

Core:

- `routes/web.php`
- `.env`
- `.htaccess`
- `index.php`
- `composer.json`

Controllers:

- `app/Http/Controllers/AuthController.php`
- `app/Http/Controllers/DashboardController.php`
- `app/Http/Controllers/AraziController.php`
- `app/Http/Controllers/PlotController.php`
- `app/Http/Controllers/KisanController.php`
- `app/Http/Controllers/CustomerBondController.php`
- `app/Http/Controllers/CustomerBondPaymentController.php`
- `app/Http/Controllers/RegistryController.php`
- `app/Http/Controllers/PaymentController.php`
- `app/Http/Controllers/AreaConverterController.php`
- `app/Http/Controllers/Concerns/ManagesCrud.php`

Models:

- `app/Models/Kisan.php`
- `app/Models/Arazi.php`
- `app/Models/Plot.php`
- `app/Models/Customer.php`
- `app/Models/Agent.php`
- `app/Models/Registry.php`
- `app/Models/Payment.php`
- `app/Models/CustomerBond.php`
- `app/Models/CustomerBondPayment.php`
- `app/Models/KisanBond.php`

Views:

- `resources/views/layouts/app.blade.php`
- `resources/views/crud/index.blade.php`
- `resources/views/crud/form.blade.php`
- `resources/views/dashboard.blade.php`
- `resources/views/auth/login.blade.php`
- `resources/views/customer_bonds/form_certificate.blade.php`
- `resources/views/registries/add.blade.php`
- `resources/views/converter/form.blade.php`
- `resources/views/prints/customer_bond_certificate.blade.php`
- `resources/views/prints/registry_certificate.blade.php`

Services:

- `app/Services/AreaConverter.php`

## 23. One-Line Summary

This project is a Laravel 10 real estate and land management CRM for Kisans, Arazis, Plots, Customers, Bonds, Payments, Registries, and related documents, currently configured to run under XAMPP at `http://localhost/realestatecrm-run` without showing `/public` in the URL.
