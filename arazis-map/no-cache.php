<?php
/*
 * Hard no-cache for the arazi map pages.
 *
 * These pages are static legacy files served directly by Apache, outside
 * Laravel. We previously relied on arazis-map/.htaccess for this, but a
 * server with AllowOverride off (or without mod_headers, or behind a
 * proxy/CDN) silently ignores it — and clients kept being served an old
 * popup. PHP's own header() calls do not depend on any of that, so the
 * no-cache guarantee now travels with the code itself.
 *
 * Must be required at the very top of the page, before any output.
 */

if (! headers_sent()) {
    header('Cache-Control: no-store, no-cache, must-revalidate, max-age=0');
    header('Pragma: no-cache');
    header('Expires: 0');
    header_remove('ETag');
    header_remove('Last-Modified');
}
