<?php

/*
|--------------------------------------------------------------------------
| Modules & Permissions
|--------------------------------------------------------------------------
| Each module gets CRUD permissions (view, create, edit, delete) generated
| from this list. Permission names are "{module}.{action}", e.g. "arazis.view".
| Add a new module here and run `php artisan db:seed --class=PermissionSeeder`
| (or `php artisan permissions:sync`) to register its permissions.
*/

return [
    // Default CRUD actions applied to every module unless overridden.
    'actions' => ['view', 'create', 'edit', 'delete'],

    'modules' => [
        'arazis'             => ['label' => 'Arazis'],
        'plots'              => ['label' => 'Plots'],
        'registries'         => ['label' => 'Plot Registry'],
        'customers'          => ['label' => 'Customers'],
        'customer_bonds'     => ['label' => 'Customer Bonds'],
        'customer_payments'  => ['label' => 'Customer Payments'],
        'kisans'             => ['label' => 'Kisans'],
        'kisan_registries'   => ['label' => 'Kisan Registries'],
        'kisan_bonds'        => ['label' => 'Kisan Bonds'],
        'kisan_payments'     => ['label' => 'Kisan Payments'],
        'agents'             => ['label' => 'Brokers / Agents'],
        'investors'          => ['label' => 'Investors'],
        'partners'           => ['label' => 'Partners'],
        'expenses'           => ['label' => 'Expenses'],
        'cheques'            => ['label' => 'Cheques'],
        'connected_accounts' => ['label' => 'Connected Accounts'],
        'reports'            => ['label' => 'Reports', 'actions' => ['view']],
        'user_master'        => ['label' => 'User Master'],
        'roles'              => ['label' => 'Roles & Permissions'],
    ],
];
