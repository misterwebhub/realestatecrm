<?php

namespace App\Http\Controllers;

class QuickAccessController extends Controller
{
    public function index()
    {
        $user = auth()->user();
        $isAdmin    = $user && in_array($user->role, ['admin', 'manager']);
        $isAccounts = $user && in_array($user->role, ['admin', 'manager', 'accountant']);

        $sections = [];

        // ── Land Management ──────────────────────────────────────────────────
        if ($isAdmin) {
            $sections[] = [
                'title' => 'Land Management',
                'icon'  => 'bi-map',
                'color' => 'success',
                'cards' => [
                    ['icon' => 'bi-map-fill',            'color' => 'success',   'title' => 'Arazi (Lands)',        'desc' => 'View & manage all arazi land records',       'url' => route('arazis.index'),              'add_url' => route('arazis.create')],
                    ['icon' => 'bi-geo-alt-fill',         'color' => 'teal',     'title' => 'Arazi Maps',           'desc' => 'Visual map of all arazi parcels',            'url' => route('arazis.map.index'),          'add_url' => null],
                    ['icon' => 'bi-pin-map-fill',         'color' => 'info',     'title' => 'Plots',                'desc' => 'Individual plot records under each arazi',   'url' => route('plots.index'),               'add_url' => route('plots.create')],
                    ['icon' => 'bi-hourglass-split',      'color' => 'warning',  'title' => 'Plot Holds',           'desc' => 'Plots held by brokers with hold periods',    'url' => route('plot-holds.index'),          'add_url' => null],
                    ['icon' => 'bi-file-earmark-arrow-up','color' => 'secondary','title' => 'Arazi Documents',      'desc' => 'Uploaded documents for arazi records',       'url' => route('arazi-documents.index'),     'add_url' => route('arazi-documents.create')],
                    ['icon' => 'bi-journal-text',         'color' => 'dark',     'title' => 'Plot Registry',        'desc' => 'Registry records for sold plots',            'url' => route('registries.index'),          'add_url' => route('registries.create')],
                ],
            ];
        }

        // ── Kisan ─────────────────────────────────────────────────────────────
        if ($isAdmin) {
            $sections[] = [
                'title' => 'Kisan Management',
                'icon'  => 'bi-people-fill',
                'color' => 'primary',
                'cards' => [
                    ['icon' => 'bi-person-fill',          'color' => 'primary',  'title' => 'Kisans',               'desc' => 'All registered kisan (farmer) profiles',     'url' => route('kisans.index'),              'add_url' => route('kisans.create')],
                    ['icon' => 'bi-file-earmark-text',    'color' => 'indigo',   'title' => 'Kisan Registry',       'desc' => 'Kisan land registry documents',              'url' => route('kisan-registries.index'),    'add_url' => route('kisan-registries.create')],
                    ['icon' => 'bi-file-earmark-ruled',   'color' => 'primary',  'title' => 'Kisan Bonds',          'desc' => 'Land purchase bonds from kisans',            'url' => route('kisan-bonds.index'),         'add_url' => route('kisan-bonds.create')],
                    ['icon' => 'bi-cash-coin',            'color' => 'warning',  'title' => 'Kisan Payment',        'desc' => 'Record & view kisan payments',               'url' => route('kisan-payment.index'),       'add_url' => route('kisan-payment.create')],
                    ['icon' => 'bi-table',                'color' => 'warning',  'title' => 'Kisan Ledger',         'desc' => 'Full ledger for kisan transactions',         'url' => route('kisan-payment.ledger'),      'add_url' => null],
                    ['icon' => 'bi-person-badge',         'color' => 'secondary','title' => 'Kisan Broker',         'desc' => 'Broker agents assigned to kisans',           'url' => route('agents.type.index', 'kisan'),'add_url' => null],
                ],
            ];
        }

        // ── Customer ──────────────────────────────────────────────────────────
        if ($isAccounts) {
            $sections[] = [
                'title' => 'Customer Management',
                'icon'  => 'bi-receipt',
                'color' => 'orange',
                'cards' => [
                    ['icon' => 'bi-people',               'color' => 'orange',   'title' => 'Customers',            'desc' => 'Customer profiles and contact info',         'url' => $isAdmin ? route('customers.index') : null, 'add_url' => $isAdmin ? route('customers.create') : null],
                    ['icon' => 'bi-receipt-cutoff',       'color' => 'orange',   'title' => 'Customer Bonds',       'desc' => 'Bonds for customer plot purchases',          'url' => route('customer-bonds.index'),      'add_url' => route('customer-bonds.create')],
                    ['icon' => 'bi-currency-rupee',       'color' => 'orange',   'title' => 'Customer Payment',     'desc' => 'Record installments & advance payments',     'url' => route('customer-bond-payments.index'),'add_url' => route('customer-bond-payments.compact')],
                    ['icon' => 'bi-table',                'color' => 'warning',  'title' => 'Customer Ledger',      'desc' => 'Full payment ledger per customer/arazi',     'url' => route('customer-bond-payments.ledger'),'add_url' => null],
                    ['icon' => 'bi-person-badge',         'color' => 'secondary','title' => 'Customer Broker',      'desc' => 'Broker agents assigned to customers',        'url' => route('agents.type.index', 'customer'),'add_url' => null],
                ],
            ];
        }

        // ── Finance ───────────────────────────────────────────────────────────
        if ($isAdmin) {
            $sections[] = [
                'title' => 'Finance & Reports',
                'icon'  => 'bi-graph-up-arrow',
                'color' => 'danger',
                'cards' => [
                    ['icon' => 'bi-graph-up',             'color' => 'success',  'title' => 'Investors',            'desc' => 'Investor records & portfolio',               'url' => route('investors.index'),           'add_url' => route('investors.create')],
                    ['icon' => 'bi-cash-stack',           'color' => 'danger',   'title' => 'Expenses',             'desc' => 'Track arazi & operational expenses',         'url' => route('expenses.index'),            'add_url' => route('expenses.create')],
                    ['icon' => 'bi-diagram-3',            'color' => 'purple',   'title' => 'Partners',             'desc' => 'Business partners and revenue splits',       'url' => route('partners.index'),            'add_url' => route('partners.create')],
                    ['icon' => 'bi-hourglass-split',      'color' => 'warning',  'title' => 'Waiting Payments',     'desc' => 'Registry payments pending clearance',        'url' => route('registries.waiting-payments'),'add_url' => null],
                    ['icon' => 'bi-bar-chart-line',       'color' => 'info',     'title' => 'Plot Details Report',  'desc' => 'Detailed report by arazi / plot',            'url' => route('reports.plot.details'),      'add_url' => null],
                    ['icon' => 'bi-alarm',                'color' => 'danger',   'title' => 'Pending Installments',  'desc' => 'Overdue/pending installments by bond & customer', 'url' => route('reports.pending-installments'), 'add_url' => null],
                ],
            ];
        }

        // ── Cheques & Accounts ────────────────────────────────────────────────
        $sections[] = [
            'title' => 'Cheques & Accounts',
            'icon'  => 'bi-credit-card-2-front',
            'color' => 'info',
            'cards' => [
                ['icon' => 'bi-credit-card-fill',     'color' => 'info',     'title' => 'Account Cheques',      'desc' => 'Track cheques issued for bonds',             'url' => route('customer-bond-cheques.index'),'add_url' => route('customer-bond-cheques.create')],
                ['icon' => 'bi-bank',                 'color' => 'info',     'title' => 'Connected Accounts',   'desc' => 'Linked bank account records',                'url' => route('connected-accounts.index'),  'add_url' => route('connected-accounts.create')],
            ],
        ];

        // ── Utilities ─────────────────────────────────────────────────────────
        $utilCards = [
            ['icon' => 'bi-calculator',           'color' => 'secondary','title' => 'Area Converter',        'desc' => 'Convert between Gaz, Marla, Kanal, Bigha',   'url' => route('converter.index'),           'add_url' => null],
        ];
        if ($isAdmin) {
            $utilCards[] = ['icon' => 'bi-folder2-open', 'color' => 'secondary','title' => 'Uploads',           'desc' => 'File uploads linked to arazi records',       'url' => route('uploads.index'),             'add_url' => route('uploads.create')];
            $utilCards[] = ['icon' => 'bi-tags',         'color' => 'secondary','title' => 'Upload Categories', 'desc' => 'Manage document/upload categories',          'url' => route('upload-categories.index'),   'add_url' => null];
        }
        if ($user && $user->role === 'admin') {
            $utilCards[] = ['icon' => 'bi-person-gear',  'color' => 'dark',     'title' => 'User Master',       'desc' => 'Manage system users & roles',                'url' => route('user-master.index'),         'add_url' => route('user-master.create')];
        }
        $sections[] = [
            'title' => 'Utilities',
            'icon'  => 'bi-tools',
            'color' => 'secondary',
            'cards' => $utilCards,
        ];

        return view('quick_access', [
            'title'    => 'Quick Access',
            'sections' => $sections,
        ]);
    }
}
