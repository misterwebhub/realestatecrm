/*
 * Click-to-view plot buyer/broker popup — shared by every arazi map page
 * (arazis-map/<folder>/index.php).
 *
 * These map pages are static legacy PHP files served directly by Apache,
 * not through Laravel routing, so they cannot check auth/roles themselves.
 * The actual "super admin only" restriction is enforced server-side by
 * ArazisMapPlotDetailsController (route: arazis-map/plot-details/{plotId}).
 * This script just wires up clicks and renders whatever the endpoint
 * returns — for anyone who isn't a super admin the endpoint responds 403
 * and this script does nothing at all (no popup, no hint the feature
 * exists).
 *
 * Each map page already builds `window.plots` (array of
 * {id, plot_number, title, status, area} from the DB) for its status
 * coloring script. This file reuses that same array to resolve a clicked
 * tile back to a real plot id.
 */
(function () {
    document.addEventListener('DOMContentLoaded', function () {
        var plots = window.plots || [];
        if (!plots.length) return;

        // Cache successful lookups for the lifetime of the page so
        // re-clicking the same tile opens instantly with no network wait.
        var detailsCache = {};

        var STATUS_COLORS = {
            booked: { bg: '#e6f4ea', border: '#34a853', text: '#1e7e34' },
            registry: { bg: '#e8f0fe', border: '#4285f4', text: '#1a56d6' },
            sold: { bg: '#e8f0fe', border: '#4285f4', text: '#1a56d6' },
            hold: { bg: '#fff4e5', border: '#fb8c00', text: '#b25a00' },
            available: { bg: '#f1f3f4', border: '#9aa0a6', text: '#5f6368' },
        };

        // Label (plot_number or title) -> plot record, plus a numeric-only
        // fallback map — mirrors the matching logic already used by each
        // page's status-coloring script.
        var byLabel = {};
        var byNumber = {};
        plots.forEach(function (p) {
            [p.plot_number, p.title].forEach(function (v) {
                var label = String(v || '').trim().toUpperCase();
                if (!label) return;
                byLabel[label] = p;
                if (/^\d+$/.test(label) && !byNumber[label]) {
                    byNumber[label] = p;
                }
            });
        });

        function resolvePlot(el) {
            var label = (el.textContent || '').trim().toUpperCase();
            if (label && byLabel[label]) return byLabel[label];

            var tileNum = null;
            if (el.hasAttribute('data-plot')) {
                tileNum = String(el.getAttribute('data-plot') || '').trim();
            } else {
                var m = (el.id || '').match(/^p(\d+)$/);
                if (m) tileNum = m[1];
            }
            if (tileNum && byNumber[tileNum]) return byNumber[tileNum];
            return null;
        }

        var tiles = Array.from(document.querySelectorAll('.marker[data-plot], div[id^="p"]'));

        // A few layouts (e.g. 319, 385) mark plot numbers with a bare
        // <span>NNN</span> inside the colored parent div instead of an id
        // or data-plot attribute — same pattern their status-coloring
        // script already matches on.
        Array.from(document.querySelectorAll('form span')).forEach(function (sp) {
            var txt = (sp.textContent || '').trim();
            if (!/^\d+$/.test(txt)) return;
            var parent = sp.closest('div');
            if (parent && tiles.indexOf(parent) === -1) tiles.push(parent);
        });

        tiles.forEach(function (el) {
            el.style.cursor = 'pointer';
            el.addEventListener('click', function (ev) {
                ev.preventDefault();
                var plot = resolvePlot(el);
                if (!plot || !plot.id) return;
                fetchAndShow(plot.id, ev);
            });
        });

        function fetchAndShow(plotId, ev) {
            // Cached — render instantly, no round trip, no loading flash.
            if (detailsCache[plotId]) {
                if (detailsCache[plotId] !== 'skip') showPopup(detailsCache[plotId]);
                return;
            }

            // Show a loading state immediately (0ms) so the click feels
            // instant even while the request is in flight, then swap its
            // content for the real popup — or quietly close it — once the
            // response lands.
            var overlay = showLoading();

            fetch('../plot-details/' + encodeURIComponent(plotId), {
                credentials: 'same-origin',
                headers: { 'X-Requested-With': 'XMLHttpRequest' },
            })
                .then(function (res) {
                    if (!res.ok) return null; // 403/404/etc — say nothing
                    return res.json();
                })
                .then(function (data) {
                    var hasDetails = data && data.ok && data.source !== 'none';
                    detailsCache[plotId] = hasDetails ? data : 'skip';
                    if (!hasDetails) {
                        closeOverlay(overlay);
                        return;
                    }
                    renderPopup(overlay, data);
                })
                .catch(function () {
                    // Network/error — fail silently, no popup.
                    closeOverlay(overlay);
                });
        }

        function row(label, value) {
            if (value === null || value === undefined || value === '') return '';
            return '<div style="display:flex;justify-content:space-between;gap:12px;padding:6px 0;border-bottom:1px solid #f0f1f3;">' +
                '<span style="color:#6b7280;">' + label + '</span>' +
                '<strong style="text-align:right;color:#1f2937;">' + String(value) + '</strong>' +
                '</div>';
        }

        function formatAmount(value) {
            var num = Number(value);
            if (!isFinite(num)) return '0.00';
            return num.toLocaleString('en-IN', {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2,
            });
        }

        function amountRow(label, value, words) {
            var display = formatAmount(value);
            var title = words ? ' title="' + String(words).replace(/"/g, '&quot;') + '"' : '';
            return '<div style="display:flex;justify-content:space-between;gap:12px;padding:6px 0;border-bottom:1px solid #f0f1f3;">' +
                '<span style="color:#6b7280;">' + label + '</span>' +
                '<strong style="text-align:right;color:#1f2937;cursor:help;"' + title + '>' + display + '</strong>' +
                '</div>';
        }

        function rowOrZero(label, value) {
            return '<div style="display:flex;justify-content:space-between;gap:12px;padding:6px 0;border-bottom:1px solid #f0f1f3;">' +
                '<span style="color:#6b7280;">' + label + '</span>' +
                '<strong style="text-align:right;color:#1f2937;">' + String(value === null || value === undefined || value === '' ? 0 : value) + '</strong>' +
                '</div>';
        }

        function overlayShell() {
            var existing = document.getElementById('plot-popup-overlay');
            if (existing) existing.remove();

            var overlay = document.createElement('div');
            overlay.id = 'plot-popup-overlay';
            overlay.style.cssText = 'position:fixed;inset:0;background:rgba(17,24,39,0.55);z-index:99999;display:flex;align-items:center;justify-content:center;';

            var box = document.createElement('div');
            box.id = 'plot-popup-box';
            box.style.cssText = 'background:#fff;border-radius:12px;min-width:280px;max-width:380px;width:90%;overflow:hidden;box-shadow:0 20px 45px rgba(0,0,0,0.35);font-family:Arial,Helvetica,sans-serif;font-size:14px;color:#212529;';

            overlay.appendChild(box);
            document.body.appendChild(overlay);

            overlay.addEventListener('click', function (e) {
                if (e.target === overlay) closeOverlay(overlay);
            });
            document.addEventListener('keydown', function escHandler(e) {
                if (e.key === 'Escape') { closeOverlay(overlay); document.removeEventListener('keydown', escHandler); }
            });

            return overlay;
        }

        function closeOverlay(overlay) {
            if (overlay && overlay.parentNode) overlay.remove();
        }

        function showLoading() {
            var overlay = overlayShell();
            var box = overlay.querySelector('#plot-popup-box');
            box.innerHTML =
                '<div style="background:linear-gradient(135deg,#4285f4,#34a853);padding:18px;text-align:center;">' +
                '<div style="width:28px;height:28px;margin:0 auto;border:3px solid rgba(255,255,255,0.4);border-top-color:#fff;border-radius:50%;animation:plotPopupSpin 0.7s linear infinite;"></div>' +
                '</div>' +
                '<div style="padding:14px 18px;text-align:center;color:#6b7280;">Loading plot details…</div>';

            if (!document.getElementById('plot-popup-keyframes')) {
                var style = document.createElement('style');
                style.id = 'plot-popup-keyframes';
                style.textContent = '@keyframes plotPopupSpin { to { transform: rotate(360deg); } }';
                document.head.appendChild(style);
            }

            return overlay;
        }

        function renderPopup(overlay, data) {
            if (!overlay || !overlay.parentNode) overlay = overlayShell();
            var box = overlay.querySelector('#plot-popup-box');

            var statusKey = String(data.status || '').toLowerCase();
            var palette = STATUS_COLORS[statusKey] || STATUS_COLORS.available;
            var statusLabel = String(data.status || '').replace(/_/g, ' ');
            statusLabel = statusLabel.charAt(0).toUpperCase() + statusLabel.slice(1);

            var html = '<div style="background:linear-gradient(135deg,#4285f4,#34a853);padding:16px 18px;display:flex;justify-content:space-between;align-items:center;color:#fff;">' +
                '<div>' +
                '<div style="font-size:12px;opacity:0.85;letter-spacing:0.04em;text-transform:uppercase;">Arazi ' + (data.arazi_code || '') + '</div>' +
                '<h3 style="margin:2px 0 0;font-size:19px;">Plot ' + (data.plot_title || data.plot_id) + '</h3>' +
                '</div>' +
                '<button id="plot-popup-close" style="border:none;background:rgba(255,255,255,0.2);width:28px;height:28px;border-radius:50%;font-size:18px;line-height:1;cursor:pointer;color:#fff;">&times;</button>' +
                '</div>';

            html += '<div style="padding:14px 18px 6px;">';
            html += '<span style="display:inline-block;padding:3px 10px;border-radius:999px;font-size:12px;font-weight:bold;background:' + palette.bg + ';color:' + palette.text + ';border:1px solid ' + palette.border + ';">' + statusLabel + '</span>';
            html += '</div>';

            html += '<div style="padding:4px 18px 16px;">';
            html += row('Area (gaz)', data.area);
            if (data.source === 'bond' || data.source === 'booking') {
                html += rowOrZero('Booking Date', data.booking_date);
                html += amountRow('Advance Amount', data.advance_amount, data.advance_amount_words);
                html += amountRow('Balance Amount', data.balance_amount !== undefined ? data.balance_amount : data.balance, data.balance_amount_words);
            }
            if (data.source === 'registry') {
                html += rowOrZero('Registry Date', data.registry_date);
            }

            if (data.bond_no) {
                var bondNoValue = data.bond_url
                    ? '<a href="' + data.bond_url + '" target="_blank" rel="noopener" style="color:#1a73e8;text-decoration:underline;">' + data.bond_no + '</a>'
                    : data.bond_no;
                html += row('Bond No', bondNoValue);
            }
            if (data.bond_date) html += row('Bond Date', data.bond_date);
            if (data.bond_amount !== undefined) html += amountRow('Bond Amount', data.bond_amount, data.bond_amount_words);
            if (data.last_date) html += row('Last Date', data.last_date);
            if (data.deed_no) html += row('Deed No', data.deed_no);
            if (data.source === 'booking') {
                html += '<div style="margin-top:8px;padding-top:10px;border-top:1px solid #eef0f3;font-size:12px;font-weight:bold;color:#111827;text-transform:uppercase;letter-spacing:0.04em;">Booking</div>';
                html += rowOrZero('Expiry Date', data.booking_expiry_date);
                html += rowOrZero('Booking Status', data.booking_status ? String(data.booking_status).replace(/_/g, ' ') : 0);
            }

            var customerValue = data.customer_name
                ? (data.customer_url
                    ? '<a href="' + data.customer_url + '" target="_blank" rel="noopener" style="color:#1a73e8;text-decoration:underline;">' + data.customer_name + '</a>'
                    : data.customer_name)
                : null;
            html += row('Customer', customerValue);

            html += row('Customer Mobile', data.customer_mobile);
            html += row('Broker', data.broker_name);
            if (data.gaz !== undefined) html += row('Gaz (' + (data.source === 'registry' ? 'Registry' : 'Booked') + ')', data.gaz);
            if (data.sale_amount) html += row('Sale Amount', data.sale_amount);

            if (data.source === 'hold' || data.hold_id) {
                html += '<div style="margin-top:8px;padding-top:10px;border-top:1px solid #eef0f3;font-size:12px;font-weight:bold;color:#111827;text-transform:uppercase;letter-spacing:0.04em;">Hold Details</div>';
                if (data.hold_days !== undefined) html += row('Hold Days', data.hold_days);
                if (data.hold_start_date) html += row('Hold From', data.hold_start_date);
                if (data.hold_end_date) html += row('Hold Till', data.hold_end_date);
                if (data.hold_agent_name) html += row('Hold Broker', data.hold_agent_name);
                if (data.hold_customer_name) html += row('Held For', data.hold_customer_name);
                if (data.hold_customer_phone) html += row('Phone', data.hold_customer_phone);
                if (data.hold_created_by) html += row('Held By', data.hold_created_by);
                if (data.hold_created_at) html += row('Held On', data.hold_created_at);
                if (data.hold_notes) html += row('Notes', data.hold_notes);
            }
            html += '</div>';

            box.innerHTML = html;

            box.querySelector('#plot-popup-close').addEventListener('click', function () {
                closeOverlay(overlay);
            });
        }
    });
})();
