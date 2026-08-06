<?php

/*
|--------------------------------------------------------------------------
| Modules & Permissions
|--------------------------------------------------------------------------
| Every menu AND sub-menu item is its own "module" so it can be toggled
| independently in Roles & Permissions. Permission names are
| "{module}.{action}", e.g. "arazi_maps.view", "cheque_manual.view".
|
| - Resource pages get full CRUD (view, create, edit, delete).
| - Display / report / tool pages get 'view' only (there is nothing to
|   create/edit/delete on them, so extra actions would be meaningless).
|
| After editing this file run:
|   php artisan permissions:sync   (or db:seed --class=RolePermissionSeeder)
*/

$crud = ['view', 'create', 'edit', 'delete'];
$view = ['view'];

return [
    // Default CRUD actions applied to every module unless overridden.
    'actions' => $crud,

    'modules' => [
        // ── Land & Plots ────────────────────────────────────────────────
        'arazis'            => ['label' => 'Arazi (Lands)',   'group' => 'Land & Plots', 'actions' => $crud],
        'arazi_maps'        => ['label' => 'Arazi Maps',      'group' => 'Land & Plots', 'actions' => $view],
        'arazi_groups'      => ['label' => 'Arazi Groups',    'group' => 'Land & Plots', 'actions' => $crud],
        'deed_mappings'     => ['label' => 'Deed Mapping',    'group' => 'Land & Plots', 'actions' => $crud],
        'deed_merges'       => ['label' => 'Deed Merging',    'group' => 'Land & Plots', 'actions' => $crud],
        'plots'             => ['label' => 'Plots',           'group' => 'Land & Plots', 'actions' => $crud],
        'plot_holds'        => ['label' => 'Plot Holds',      'group' => 'Land & Plots', 'actions' => $crud],
        'registries'        => ['label' => 'Plot Registry',   'group' => 'Land & Plots', 'actions' => $crud],
        'waiting_payments'  => ['label' => 'Waiting Payments','group' => 'Land & Plots', 'actions' => $view],

        // ── Kisans & Bonds ──────────────────────────────────────────────
        'kisans'            => ['label' => 'Kisans',          'group' => 'Kisans', 'actions' => $crud],
        'kisan_registries'  => ['label' => 'Kisan Registry',  'group' => 'Kisans', 'actions' => $crud],
        'kisan_bonds'       => ['label' => 'Kisan Bonds',     'group' => 'Kisans', 'actions' => $crud],
        'kisan_payments'    => ['label' => 'Kisan Payment',   'group' => 'Kisans', 'actions' => $crud],
        'kisan_ledger'      => ['label' => 'Kisan Ledger',    'group' => 'Kisans', 'actions' => $view],
        'kisan_brokers'     => ['label' => 'Kisan Brokers',   'group' => 'Kisans', 'actions' => $crud],

        // ── Customers & Bonds ───────────────────────────────────────────
        'customers'         => ['label' => 'Customers',        'group' => 'Customers', 'actions' => $crud],
        'customer_bonds'    => ['label' => 'Customer Bonds',   'group' => 'Customers', 'actions' => $crud],
        'customer_payments' => ['label' => 'Customer Payment', 'group' => 'Customers', 'actions' => $crud],
        'customer_ledger'   => ['label' => 'Customer Ledger',  'group' => 'Customers', 'actions' => $view],
        'customer_brokers'  => ['label' => 'Customer Brokers', 'group' => 'Customers', 'actions' => $crud],

        // ── Brokers & Finance ───────────────────────────────────────────
        'office_brokers'    => ['label' => 'Office Brokers',   'group' => 'Brokers & Finance', 'actions' => $crud],
        'investors'         => ['label' => 'Investors',        'group' => 'Brokers & Finance', 'actions' => $crud],
        'partners'          => ['label' => 'Partners',         'group' => 'Brokers & Finance', 'actions' => $crud],
        'expenses'          => ['label' => 'Expenses',         'group' => 'Brokers & Finance', 'actions' => $crud],

        // ── Cheques ─────────────────────────────────────────────────────
        'cheques'            => ['label' => 'Account Cheques',        'group' => 'Cheques', 'actions' => $crud],
        'cheque_manual'      => ['label' => 'Manual Cheque Entries',  'group' => 'Cheques', 'actions' => $view],
        'cheque_assign'      => ['label' => 'Assign Cheques to Bond', 'group' => 'Cheques', 'actions' => $view],
        'connected_accounts' => ['label' => 'Connected Accounts',     'group' => 'Cheques', 'actions' => $crud],

        // ── Reports (each report page is its own toggle) ─────────────────
        'reports'                  => ['label' => 'All Reports',            'group' => 'Reports', 'actions' => $view],
        'report_partners'          => ['label' => 'Partner-wise',          'group' => 'Reports', 'actions' => $view],
        'report_arazis'            => ['label' => 'Arazi-wise',            'group' => 'Reports', 'actions' => $view],
        'report_brokers'           => ['label' => 'Broker',               'group' => 'Reports', 'actions' => $view],
        'report_registries'        => ['label' => 'Registry',             'group' => 'Reports', 'actions' => $view],
        'report_payments'          => ['label' => 'Payment Collection',   'group' => 'Reports', 'actions' => $view],
        'report_sales'             => ['label' => 'Sales Summary',        'group' => 'Reports', 'actions' => $view],
        'report_payments_by_user'  => ['label' => 'Payments by User',     'group' => 'Reports', 'actions' => $view],
        'report_bonds_cumulative'  => ['label' => 'Bond Cumulative',      'group' => 'Reports', 'actions' => $view],
        'report_plot_details'      => ['label' => 'Plot Details',         'group' => 'Reports', 'actions' => $view],
        'report_deed_merge_breakdown' => ['label' => 'Deed Merge Breakdown', 'group' => 'Reports', 'actions' => $view],

        // ── System ──────────────────────────────────────────────────────
        'user_master'   => ['label' => 'User Master',           'group' => 'System', 'actions' => $crud],
        'roles'         => ['label' => 'Roles & Permissions',   'group' => 'System', 'actions' => $crud],
        'activity_logs' => ['label' => 'Activity Logs',         'group' => 'System', 'actions' => $view],
        'audit_logs'    => ['label' => 'Database Log',          'group' => 'System', 'actions' => $view],
        'converter'     => ['label' => 'Area Converter',        'group' => 'System', 'actions' => $view],
        'quick_access'  => ['label' => 'Quick Access',          'group' => 'System', 'actions' => $view],
    ],
];
