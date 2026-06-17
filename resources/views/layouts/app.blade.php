<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="csrf-token" content="{{ csrf_token() }}">
    <title>{{ $title ?? 'Kisan Land Management System' }}</title>
    <link rel="stylesheet" href="{{ asset('vendor/adminlte/css/adminlte.css') }}">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/select2-bootstrap-5-theme@1.3.0/dist/select2-bootstrap-5-theme.min.css">
    @stack('styles')
</head>
<body class="layout-fixed sidebar-expand-lg bg-body-tertiary">
<div class="app-wrapper">
    <nav class="app-header navbar navbar-expand bg-body">
        <div class="container-fluid">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" data-lte-toggle="sidebar" href="#" role="button">
                        <i class="bi bi-list"></i>
                    </a>
                </li>
                <li class="nav-item d-none d-md-block">
                    <a href="{{ route('dashboard') }}" class="nav-link">Kisan Land Management System</a>
                </li>
            </ul>

            <ul class="navbar-nav ms-auto">
                <li class="nav-item">
                    <a class="nav-link" href="{{ route('dashboard') }}" title="Dashboard">
                        <i class="bi bi-speedometer2"></i>
                    </a>
                </li>
            </ul>
        </div>
    </nav>

    <aside class="app-sidebar bg-body-secondary shadow" data-bs-theme="dark">
        <div class="sidebar-brand">
            <a href="{{ route('dashboard') }}" class="brand-link text-decoration-none">
                <span class="brand-text fw-semibold">Kisan LMS</span>
            </a>
        </div>

        <div class="sidebar-wrapper">
            <nav class="mt-2">
                <ul class="nav sidebar-menu flex-column" data-lte-toggle="treeview" role="navigation" aria-label="Main navigation">
                    <li class="nav-item">
                        <a href="{{ route('dashboard') }}" class="nav-link {{ request()->routeIs('dashboard') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-speedometer2"></i>
                            <p>Dashboard</p>
                        </a>
                    </li>

                    <li class="nav-item">
                        <a href="{{ route('quick-access') }}" class="nav-link {{ request()->routeIs('quick-access') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-grid-3x3-gap-fill"></i>
                            <p>Quick Access</p>
                        </a>
                    </li>

                    @if(auth()->check() && (auth()->user()->role === 'admin' || auth()->user()->role === 'manager'))
                        <li class="nav-item">
                            <a href="{{ route('arazis.index') }}" class="nav-link {{ request()->routeIs('arazis.*') ? 'active' : '' }}">
                                <i class="nav-icon bi bi-map"></i>
                                <p>Arazi (Lands)</p>
                            </a>
                        </li>

                        <li class="nav-item">
                            <a href="{{ route('arazis.map.index') }}" class="nav-link {{ request()->routeIs('arazis.map.*') || request()->routeIs('arazis-map') ? 'active' : '' }}">
                                <i class="nav-icon bi bi-geo-alt"></i>
                                <p>Arazi Maps</p>
                            </a>
                        </li>

                        {{-- <li class="nav-item">
                            <a href="{{ route('arazi-documents.index') }}" class="nav-link {{ request()->routeIs('arazi-documents.*') ? 'active' : '' }}">
                                <i class="nav-icon bi bi-file-earmark-arrow-up"></i>
                                <p>Arazi Registry Upload</p>
                            </a>
                        </li> --}}

                        

                        <li class="nav-item">
                            <a href="{{ route('plots.index') }}" class="nav-link {{ request()->routeIs('plots.*') ? 'active' : '' }}">
                                <i class="nav-icon bi bi-pin-map"></i>
                                <p>Plots</p>
                            </a>
                        </li>
                    @endif

                    @if(auth()->check() && (auth()->user()->role === 'admin' || auth()->user()->role === 'manager'))
                        <li class="nav-item {{ request()->routeIs('kisans.*') || request()->routeIs('kisan-bonds.*') || request()->routeIs('kisan-payment.*') || request()->routeIs('kisan-payment.ledger') || request()->routeIs('kisan-registries.*') || (request()->routeIs('agents.type.index') && request()->route('type') === 'kisan') ? 'menu-open' : '' }}">
                        <a href="#" class="nav-link {{ request()->routeIs('kisans.*') || request()->routeIs('kisan-bonds.*') || request()->routeIs('kisan-payment.*') || request()->routeIs('kisan-payment.ledger') || request()->routeIs('kisan-registries.*') || (request()->routeIs('agents.type.index') && request()->route('type') === 'kisan') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-people-fill"></i>
                            <p>
                                Kisans & Bonds
                                <i class="nav-arrow bi bi-chevron-right"></i>
                            </p>
                        </a>
                        <ul class="nav nav-treeview">
                            <li class="nav-item"><a href="{{ route('kisans.index') }}" class="nav-link {{ request()->routeIs('kisans.*') && !request()->routeIs('kisans.kisan-payment.*') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Kisans</p></a></li>
                            <li class="nav-item"><a href="{{ route('kisan-registries.index') }}" class="nav-link {{ request()->routeIs('kisan-registries.*') ? 'active' : '' }}"><i class="nav-icon bi bi-file-earmark-text"></i><p>Kisan Registry</p></a></li>
                            <li class="nav-item"><a href="{{ route('kisan-bonds.index') }}" class="nav-link {{ request()->routeIs('kisan-bonds.*') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Kisan Bonds</p></a></li>
                            <li class="nav-item"><a href="{{ route('kisan-payment.index') }}" class="nav-link {{ request()->routeIs('kisan-payment.*') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Kisan Payment</p></a></li>
                            <li class="nav-item"><a href="{{ route('kisan-payment.ledger') }}" class="nav-link {{ request()->routeIs('kisan-payment.ledger') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Kisan Ledger</p></a></li>
                            <li class="nav-item"><a href="{{ route('agents.type.index', 'kisan') }}" class="nav-link {{ request()->routeIs('agents.type.index') && request()->route('type') === 'kisan' ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Kisan Broker</p></a></li>
                        </ul>
                        </li>
                    @endif

                    @if(auth()->check() && (auth()->user()->role === 'admin' || auth()->user()->role === 'manager' || auth()->user()->role === 'accountant'))
                        <li class="nav-item {{ request()->routeIs('customer-bonds.*') || request()->routeIs('customer-bond-payments.*') || request()->routeIs('customer-bond-payments.ledger') || (request()->routeIs('agents.type.index') && request()->route('type') === 'customer') ? 'menu-open' : '' }}">
                            <a href="#" class="nav-link {{ request()->routeIs('customer-bonds.*') || request()->routeIs('customer-bond-payments.*') || request()->routeIs('customer-bond-payments.ledger') || (request()->routeIs('agents.type.index') && request()->route('type') === 'customer') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-receipt"></i>
                            <p>
                                Customer Bond & Payments
                                <i class="nav-arrow bi bi-chevron-right"></i>
                            </p>
                            </a>
                            <ul class="nav nav-treeview">
                                <li class="nav-item"><a href="{{ route('customer-bonds.index') }}" class="nav-link {{ request()->routeIs('customer-bonds.*') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Customer Bonds</p></a></li>
                                <li class="nav-item"><a href="{{ route('customer-bond-payments.index') }}" class="nav-link {{ request()->routeIs('customer-bond-payments.*') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Customer Payment</p></a></li>
                                <li class="nav-item"><a href="{{ route('customer-bond-payments.ledger') }}" class="nav-link {{ request()->routeIs('customer-bond-payments.ledger') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Customer Ledger</p></a></li>
                                <li class="nav-item"><a href="{{ route('agents.type.index', 'customer') }}" class="nav-link {{ request()->routeIs('agents.type.index') && request()->route('type') === 'customer' ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Customer Broker</p></a></li>
                            </ul>
                        </li>
                    @endif

                    @if(auth()->check() && (auth()->user()->role === 'admin' || auth()->user()->role === 'manager'))
                        <li class="nav-item"><a href="{{ route('customers.index') }}" class="nav-link {{ request()->routeIs('customers.*') ? 'active' : '' }}"><i class="nav-icon bi bi-people"></i><p>Customers</p></a></li>

                        <li class="nav-item"><a href="{{ route('agents.type.index', 'office') }}" class="nav-link {{ request()->routeIs('agents.type.index') && request()->route('type') === 'office' ? 'active' : '' }}"><i class="nav-icon bi bi-person-badge"></i><p>Office Brokers</p></a></li>

                        <li class="nav-item"><a href="{{ route('registries.index') }}" class="nav-link {{ request()->routeIs('registries.*') ? 'active' : '' }}"><i class="nav-icon bi bi-journal-text"></i><p>Plot Registry</p></a></li>

                        <li class="nav-item"><a href="{{ route('investors.index') }}" class="nav-link {{ request()->routeIs('investors.*') ? 'active' : '' }}"><i class="nav-icon bi bi-graph-up"></i><p>Investors</p></a></li>

                            <li class="nav-item"><a href="{{ route('expenses.index') }}" class="nav-link {{ request()->routeIs('expenses.*') ? 'active' : '' }}"><i class="nav-icon bi bi-cash-stack"></i><p>Expenses</p></a></li>

                        <li class="nav-item"><a href="{{ route('partners.index') }}" class="nav-link {{ request()->routeIs('partners.*') ? 'active' : '' }}"><i class="nav-icon bi bi-diagram-3"></i><p>Partners</p></a></li>

                        <li class="nav-item {{ request()->routeIs('reports.*') ? 'menu-open' : '' }}">
                            <a href="#" class="nav-link {{ request()->routeIs('reports.*') ? 'active' : '' }}">
                                <i class="nav-icon bi bi-journal-text"></i>
                                <p>
                                    Reports
                                    <i class="nav-arrow bi bi-chevron-right"></i>
                                </p>
                            </a>
                            <ul class="nav nav-treeview">
                                <li class="nav-item"><a href="{{ route('reports.plot.details') }}" class="nav-link {{ request()->routeIs('reports.plot.details') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Plot Details</p></a></li>
                            </ul>
                        </li>

                        <li class="nav-item"><a href="{{ route('registries.waiting-payments') }}" class="nav-link {{ request()->routeIs('registries.waiting-payments') ? 'active' : '' }}"><i class="nav-icon bi bi-hourglass-split"></i><p>Waiting Payments</p></a></li>

                    @endif

                    <li class="nav-item">
                        <a href="{{ route('converter.index') }}" class="nav-link {{ request()->routeIs('converter.*') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-calculator"></i>
                            <p>Area Converter</p>
                        </a>
                    </li>
                    
                    @if(auth()->check() && (auth()->user()->role === 'admin' || auth()->user()->role === 'manager'))
                        <li class="nav-item">
                            <a href="{{ route('uploads.index') }}" class="nav-link {{ request()->routeIs('uploads.*') ? 'active' : '' }}">
                                <i class="nav-icon bi bi-folder2-open"></i>
                                <p>Uploads</p>
                            </a>
                        </li>

                        <li class="nav-item">
                            <a href="{{ route('upload-categories.index') }}" class="nav-link {{ request()->routeIs('upload-categories.*') ? 'active' : '' }}">
                                <i class="nav-icon bi bi-tags"></i>
                                <p>Upload Categories</p>
                            </a>
                        </li>
                    @endif

                    @if(auth()->check() && auth()->user()->role === 'admin')
                    <li class="nav-item">
                        <a href="{{ route('user-master.index') }}" class="nav-link {{ request()->routeIs('user-master.*') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-person-gear"></i>
                            <p>User Master</p>
                        </a>
                    </li>
                    @endif

                    <li class="nav-item {{ request()->routeIs('customer-bond-cheques.index') || request()->routeIs('connected-accounts.*') ? 'menu-open' : '' }}">
                        <a href="#" class="nav-link {{ request()->routeIs('customer-bond-cheques.index') || request()->routeIs('connected-accounts.*') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-credit-card-2-front"></i>
                            <p>
                                Cheques
                                <i class="nav-arrow bi bi-chevron-right"></i>
                            </p>
                        </a>
                        <ul class="nav nav-treeview">
                            <li class="nav-item">
                                <a href="{{ route('customer-bond-cheques.index') }}" class="nav-link {{ request()->routeIs('customer-bond-cheques.index') ? 'active' : '' }}">
                                    <i class="nav-icon bi bi-circle"></i><p>Account Cheques</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="{{ route('connected-accounts.index') }}" class="nav-link {{ request()->routeIs('connected-accounts.*') ? 'active' : '' }}">
                                    <i class="nav-icon bi bi-circle"></i><p>Connected Accounts</p>
                                </a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </nav>
        </div>
    </aside>

    <main class="app-main">
        <div class="app-content" style="padding-top:20px;">
            <div class="container-fluid pb-4">
                @if(session('success'))
                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                        {{ session('success') }}
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                @endif

                @yield('content')
            </div>
        </div>
    </main>

    {{-- Render view modals placed in a named section --}}
    @hasSection('modals')
        @yield('modals')
    @endif

    <footer class="app-footer">
        <div class="float-end d-none d-sm-inline">Kisan Land Management System</div>
        <strong>Copyright &copy; {{ date('Y') }} <a href="{{ route('dashboard') }}" class="text-decoration-none">Kisan LMS</a>.</strong>
        All rights reserved.
    </footer>
</div>

<script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>
<script src="{{ asset('vendor/adminlte/js/adminlte.js') }}"></script>
<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
<script>
    (function(){
        try{
            jQuery(function(){
                if(! (window.jQuery && jQuery.fn && jQuery.fn.select2)) return;
                jQuery('select[name="arazi_code"]').each(function(){
                    var $el = jQuery(this);
                    if($el.hasClass('select2-hidden-accessible')) return; // already initialized
                    $el.select2({
                        theme: 'bootstrap-5',
                        width: '100%',
                        placeholder: $el.data('placeholder') || 'Select Arazi',
                        allowClear: true,
                        minimumResultsForSearch: 0,
                        dropdownParent: ($el.closest('form').length ? $el.closest('form') : jQuery(document.body))
                    });
                });
            });
        }catch(e){ /* ignore */ }
    })();
</script>
@stack('scripts')
</body>
</html>
