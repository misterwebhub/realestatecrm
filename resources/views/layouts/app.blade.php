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
    <style>
        /* Indent sidebar submenu items so they clearly nest under the parent menu */
        .app-sidebar .nav-treeview > .nav-item > .nav-link {
            padding-left: 2.25rem;
            position: relative;
        }
        .app-sidebar .nav-treeview > .nav-item > .nav-link > .nav-icon {
            font-size: .75rem;
            opacity: .8;
        }
        /* subtle guide line down the left of the submenu */
        .app-sidebar .nav-treeview {
            border-left: 1px solid rgba(255,255,255,.12);
            margin-left: 1.15rem;
        }
    </style>
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
                @auth
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle d-flex align-items-center gap-2" href="#" role="button"
                       data-bs-toggle="dropdown" aria-expanded="false">
                        <i class="bi bi-person-circle fs-5"></i>
                        <span class="d-none d-sm-inline fw-semibold">{{ auth()->user()->name }}</span>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-end shadow">
                        <li>
                            <span class="dropdown-item-text">
                                <span class="fw-semibold d-block">{{ auth()->user()->name }}</span>
                                <small class="text-muted">
                                    {{ auth()->user()->username }}
                                    @if(auth()->user()->roleModel)
                                        · {{ auth()->user()->roleModel->display_name }}
                                    @endif
                                </small>
                            </span>
                        </li>
                        <li><hr class="dropdown-divider"></li>
                        <li>
                            <form method="POST" action="{{ route('logout') }}">
                                @csrf
                                <button type="submit" class="dropdown-item text-danger">
                                    <i class="bi bi-box-arrow-right me-2"></i> Logout
                                </button>
                            </form>
                        </li>
                    </ul>
                </li>
                @endauth
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

                    @can('plots.view')
                    <li class="nav-item">
                        <a href="{{ route('plot-holds.index') }}" class="nav-link {{ request()->routeIs('plot-holds.*') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-hourglass-split"></i>
                            <p>Plot Holds</p>
                        </a>
                    </li>
                    @endcan

                    @can('arazis.view')
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

                        <li class="nav-item">
                            <a href="{{ route('arazi-groups.index') }}" class="nav-link {{ request()->routeIs('arazi-groups.*') ? 'active' : '' }}">
                                <i class="nav-icon bi bi-collection"></i>
                                <p>Arazi Groups</p>
                            </a>
                        </li>
                    @endcan

                    @can('plots.view')
                        <li class="nav-item">
                            <a href="{{ route('plots.index') }}" class="nav-link {{ request()->routeIs('plots.*') ? 'active' : '' }}">
                                <i class="nav-icon bi bi-pin-map"></i>
                                <p>Plots</p>
                            </a>
                        </li>
                    @endcan

                    @canany(['kisans.view', 'kisan_registries.view', 'kisan_bonds.view', 'kisan_payments.view', 'agents.view'])
                        <li class="nav-item {{ request()->routeIs('kisans.*') || request()->routeIs('kisan-bonds.*') || request()->routeIs('kisan-payment.*') || request()->routeIs('kisan-payment.ledger') || request()->routeIs('kisan-registries.*') || (request()->routeIs('agents.type.index') && request()->route('type') === 'kisan') ? 'menu-open' : '' }}">
                        <a href="#" class="nav-link {{ request()->routeIs('kisans.*') || request()->routeIs('kisan-bonds.*') || request()->routeIs('kisan-payment.*') || request()->routeIs('kisan-payment.ledger') || request()->routeIs('kisan-registries.*') || (request()->routeIs('agents.type.index') && request()->route('type') === 'kisan') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-people-fill"></i>
                            <p>
                                Kisans & Bonds
                                <i class="nav-arrow bi bi-chevron-right"></i>
                            </p>
                        </a>
                        <ul class="nav nav-treeview">
                            @can('kisans.view')<li class="nav-item"><a href="{{ route('kisans.index') }}" class="nav-link {{ request()->routeIs('kisans.*') && !request()->routeIs('kisans.kisan-payment.*') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Kisans</p></a></li>@endcan
                            @can('kisan_registries.view')<li class="nav-item"><a href="{{ route('kisan-registries.index') }}" class="nav-link {{ request()->routeIs('kisan-registries.*') ? 'active' : '' }}"><i class="nav-icon bi bi-file-earmark-text"></i><p>Kisan Registry</p></a></li>@endcan
                            @can('kisan_bonds.view')<li class="nav-item"><a href="{{ route('kisan-bonds.index') }}" class="nav-link {{ request()->routeIs('kisan-bonds.*') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Kisan Bonds</p></a></li>@endcan
                            @can('kisan_payments.view')<li class="nav-item"><a href="{{ route('kisan-payment.index') }}" class="nav-link {{ request()->routeIs('kisan-payment.*') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Kisan Payment</p></a></li>@endcan
                            @can('kisan_payments.view')<li class="nav-item"><a href="{{ route('kisan-payment.ledger') }}" class="nav-link {{ request()->routeIs('kisan-payment.ledger') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Kisan Ledger</p></a></li>@endcan
                            @can('agents.view')<li class="nav-item"><a href="{{ route('agents.type.index', 'kisan') }}" class="nav-link {{ request()->routeIs('agents.type.index') && request()->route('type') === 'kisan' ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Kisan Broker</p></a></li>@endcan
                        </ul>
                        </li>
                    @endcanany

                    @canany(['customer_bonds.view', 'customer_payments.view', 'agents.view'])
                        <li class="nav-item {{ request()->routeIs('customer-bonds.*') || request()->routeIs('customer-bond-payments.*') || request()->routeIs('customer-bond-payments.ledger') || (request()->routeIs('agents.type.index') && request()->route('type') === 'customer') ? 'menu-open' : '' }}">
                            <a href="#" class="nav-link {{ request()->routeIs('customer-bonds.*') || request()->routeIs('customer-bond-payments.*') || request()->routeIs('customer-bond-payments.ledger') || (request()->routeIs('agents.type.index') && request()->route('type') === 'customer') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-receipt"></i>
                            <p>
                                Customer Bond & Payments
                                <i class="nav-arrow bi bi-chevron-right"></i>
                            </p>
                            </a>
                            <ul class="nav nav-treeview">
                                @can('customer_bonds.view')<li class="nav-item"><a href="{{ route('customer-bonds.index') }}" class="nav-link {{ request()->routeIs('customer-bonds.*') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Customer Bonds</p></a></li>@endcan
                                @can('customer_payments.view')<li class="nav-item"><a href="{{ route('customer-bond-payments.index') }}" class="nav-link {{ request()->routeIs('customer-bond-payments.*') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Customer Payment</p></a></li>@endcan
                                @can('customer_payments.view')<li class="nav-item"><a href="{{ route('customer-bond-payments.ledger') }}" class="nav-link {{ request()->routeIs('customer-bond-payments.ledger') ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Customer Ledger</p></a></li>@endcan
                                @can('agents.view')<li class="nav-item"><a href="{{ route('agents.type.index', 'customer') }}" class="nav-link {{ request()->routeIs('agents.type.index') && request()->route('type') === 'customer' ? 'active' : '' }}"><i class="nav-icon bi bi-circle"></i><p>Customer Broker</p></a></li>@endcan
                            </ul>
                        </li>
                    @endcanany

                    @can('customers.view')
                        <li class="nav-item"><a href="{{ route('customers.index') }}" class="nav-link {{ request()->routeIs('customers.*') ? 'active' : '' }}"><i class="nav-icon bi bi-people"></i><p>Customers</p></a></li>
                    @endcan

                    @can('agents.view')
                        <li class="nav-item"><a href="{{ route('agents.type.index', 'office') }}" class="nav-link {{ request()->routeIs('agents.type.index') && request()->route('type') === 'office' ? 'active' : '' }}"><i class="nav-icon bi bi-person-badge"></i><p>Office Brokers</p></a></li>
                    @endcan

                    @can('registries.view')
                        <li class="nav-item"><a href="{{ route('registries.index') }}" class="nav-link {{ request()->routeIs('registries.*') ? 'active' : '' }}"><i class="nav-icon bi bi-journal-text"></i><p>Plot Registry</p></a></li>
                    @endcan

                    @can('investors.view')
                        <li class="nav-item"><a href="{{ route('investors.index') }}" class="nav-link {{ request()->routeIs('investors.*') ? 'active' : '' }}"><i class="nav-icon bi bi-graph-up"></i><p>Investors</p></a></li>
                    @endcan

                    @can('expenses.view')
                        <li class="nav-item"><a href="{{ route('expenses.index') }}" class="nav-link {{ request()->routeIs('expenses.*') ? 'active' : '' }}"><i class="nav-icon bi bi-cash-stack"></i><p>Expenses</p></a></li>
                    @endcan

                    @can('partners.view')
                        <li class="nav-item"><a href="{{ route('partners.index') }}" class="nav-link {{ request()->routeIs('partners.*') ? 'active' : '' }}"><i class="nav-icon bi bi-diagram-3"></i><p>Partners</p></a></li>
                    @endcan

                    @can('reports.view')
                        <li class="nav-item {{ request()->routeIs('reports.*') ? 'menu-open' : '' }}">
                            <a href="#" class="nav-link {{ request()->routeIs('reports.*') ? 'active' : '' }}">
                                <i class="nav-icon bi bi-journal-text"></i>
                                <p>
                                    Reports
                                    <i class="nav-arrow bi bi-chevron-right"></i>
                                </p>
                            </a>
                            <ul class="nav nav-treeview">
                                <li class="nav-item"><a href="{{ route('reports.index') }}" class="nav-link {{ request()->routeIs('reports.index') ? 'active' : '' }}"><i class="nav-icon bi bi-grid"></i><p>All Reports</p></a></li>
                                <li class="nav-item"><a href="{{ route('reports.partners') }}" class="nav-link {{ request()->routeIs('reports.partners') ? 'active' : '' }}"><i class="nav-icon bi bi-people"></i><p>Partner-wise</p></a></li>
                                <li class="nav-item"><a href="{{ route('reports.arazis') }}" class="nav-link {{ request()->routeIs('reports.arazis') ? 'active' : '' }}"><i class="nav-icon bi bi-map"></i><p>Arazi-wise</p></a></li>
                                <li class="nav-item"><a href="{{ route('reports.brokers') }}" class="nav-link {{ request()->routeIs('reports.brokers') ? 'active' : '' }}"><i class="nav-icon bi bi-person-badge"></i><p>Broker</p></a></li>
                                <li class="nav-item"><a href="{{ route('reports.registries') }}" class="nav-link {{ request()->routeIs('reports.registries') ? 'active' : '' }}"><i class="nav-icon bi bi-file-earmark-text"></i><p>Registry</p></a></li>
                                <li class="nav-item"><a href="{{ route('reports.payments') }}" class="nav-link {{ request()->routeIs('reports.payments') ? 'active' : '' }}"><i class="nav-icon bi bi-cash-stack"></i><p>Payment Collection</p></a></li>
                                <li class="nav-item"><a href="{{ route('reports.sales') }}" class="nav-link {{ request()->routeIs('reports.sales') ? 'active' : '' }}"><i class="nav-icon bi bi-graph-up-arrow"></i><p>Sales Summary</p></a></li>
                                <li class="nav-item"><a href="{{ route('reports.customer-payments.by-user') }}" class="nav-link {{ request()->routeIs('reports.customer-payments.by-user') ? 'active' : '' }}"><i class="nav-icon bi bi-receipt"></i><p>Payments by User</p></a></li>
                                <li class="nav-item"><a href="{{ route('reports.bonds-cumulative') }}" class="nav-link {{ request()->routeIs('reports.bonds-cumulative') ? 'active' : '' }}"><i class="nav-icon bi bi-collection"></i><p>Bond Cumulative</p></a></li>
                                <li class="nav-item"><a href="{{ route('reports.plot.details') }}" class="nav-link {{ request()->routeIs('reports.plot.details') ? 'active' : '' }}"><i class="nav-icon bi bi-grid-3x3-gap"></i><p>Plot Details</p></a></li>
                            </ul>
                        </li>
                    @endcan

                    @can('registries.view')
                        <li class="nav-item"><a href="{{ route('registries.waiting-payments') }}" class="nav-link {{ request()->routeIs('registries.waiting-payments') ? 'active' : '' }}"><i class="nav-icon bi bi-hourglass-split"></i><p>Waiting Payments</p></a></li>
                    @endcan

                    <li class="nav-item">
                        <a href="{{ route('converter.index') }}" class="nav-link {{ request()->routeIs('converter.*') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-calculator"></i>
                            <p>Area Converter</p>
                        </a>
                    </li>
                    
                    @if(auth()->check() && auth()->user()->isSuperAdmin())
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

                    @can('user_master.view')
                    <li class="nav-item">
                        <a href="{{ route('user-master.index') }}" class="nav-link {{ request()->routeIs('user-master.*') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-person-gear"></i>
                            <p>User Master</p>
                        </a>
                    </li>
                    @endcan

                    @can('roles.view')
                    <li class="nav-item">
                        <a href="{{ route('roles.index') }}" class="nav-link {{ request()->routeIs('roles.*') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-shield-lock"></i>
                            <p>Roles &amp; Permissions</p>
                        </a>
                    </li>
                    @endcan

                    @canany(['cheques.view', 'connected_accounts.view'])
                    <li class="nav-item {{ request()->routeIs('customer-bond-cheques.index') || request()->routeIs('customer-bond-cheques.manual') || request()->routeIs('customer-bond-cheques.assign') || request()->routeIs('connected-accounts.*') ? 'menu-open' : '' }}">
                        <a href="#" class="nav-link {{ request()->routeIs('customer-bond-cheques.index') || request()->routeIs('customer-bond-cheques.manual') || request()->routeIs('customer-bond-cheques.assign') || request()->routeIs('connected-accounts.*') ? 'active' : '' }}">
                            <i class="nav-icon bi bi-credit-card-2-front"></i>
                            <p>
                                Cheques
                                <i class="nav-arrow bi bi-chevron-right"></i>
                            </p>
                        </a>
                        <ul class="nav nav-treeview">
                            @can('cheques.view')
                            <li class="nav-item">
                                <a href="{{ route('customer-bond-cheques.index') }}" class="nav-link {{ request()->routeIs('customer-bond-cheques.index') ? 'active' : '' }}">
                                    <i class="nav-icon bi bi-circle"></i><p>Account Cheques</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="{{ route('customer-bond-cheques.manual') }}" class="nav-link {{ request()->routeIs('customer-bond-cheques.manual') ? 'active' : '' }}">
                                    <i class="nav-icon bi bi-pencil-square"></i><p>Create Manual Cheque Entries</p>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a href="{{ route('customer-bond-cheques.assign') }}" class="nav-link {{ request()->routeIs('customer-bond-cheques.assign') ? 'active' : '' }}">
                                    <i class="nav-icon bi bi-link-45deg"></i><p>Assign Cheques to Bond</p>
                                </a>
                            </li>
                            @endcan
                            @can('connected_accounts.view')
                            <li class="nav-item">
                                <a href="{{ route('connected-accounts.index') }}" class="nav-link {{ request()->routeIs('connected-accounts.*') ? 'active' : '' }}">
                                    <i class="nav-icon bi bi-circle"></i><p>Connected Accounts</p>
                                </a>
                            </li>
                            @endcan
                        </ul>
                    </li>
                    @endcanany
                </ul>
            </nav>
        </div>
    </aside>

    <main class="app-main">
        <div class="app-content" style="padding-top:20px;">
            <div class="container-fluid pb-4">
                @if(session('success'))
                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                        <i class="bi bi-check-circle-fill me-2"></i>{{ session('success') }}
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                @endif
                @if(session('error'))
                    <div class="alert alert-danger alert-dismissible fade show d-flex align-items-center gap-2" role="alert" id="sessionErrorAlert">
                        <i class="bi bi-exclamation-octagon-fill fs-5 flex-shrink-0"></i>
                        <div><strong>Error:</strong> {{ session('error') }}</div>
                        <button type="button" class="btn-close ms-auto" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                    <script>
                        setTimeout(function(){ var el=document.getElementById('sessionErrorAlert'); if(el){ var a=bootstrap.Alert.getOrCreateInstance(el); a.close(); } }, 7000);
                    </script>
                @endif
                @if($errors->any())
                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                        <div class="d-flex align-items-center gap-2">
                            <i class="bi bi-exclamation-octagon-fill fs-5 flex-shrink-0"></i>
                            <strong>Please fix the following:</strong>
                            <button type="button" class="btn-close ms-auto" data-bs-dismiss="alert" aria-label="Close"></button>
                        </div>
                        <ul class="mb-0 mt-2">
                            @foreach($errors->all() as $error)
                                <li>{{ $error }}</li>
                            @endforeach
                        </ul>
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
                jQuery('select[name="arazi_code"], select.js-select2').each(function(){
                    var $el = jQuery(this);
                    if($el.hasClass('select2-hidden-accessible')) return; // already initialized
                    $el.select2({
                        theme: 'bootstrap-5',
                        width: '100%',
                        placeholder: $el.data('placeholder') || $el.find('option:first').text() || 'Select',
                        allowClear: true,
                        minimumResultsForSearch: 0,
                        dropdownParent: ($el.closest('form').length ? $el.closest('form') : jQuery(document.body))
                    });
                });

                // Fix Select2 4.1.0-rc.0 bug: clicking the clear (×) button
                // reopens the dropdown instead of clearing. Suppress the reopen.
                jQuery(document).on('select2:clear', 'select[name="arazi_code"], select.js-select2', function(){
                    jQuery(this).on('select2:opening.cancelOpen', function(e){
                        e.preventDefault();
                        jQuery(this).off('select2:opening.cancelOpen');
                    });
                });
            });
        }catch(e){ /* ignore */ }
    })();
</script>
@stack('scripts')
</body>
</html>
