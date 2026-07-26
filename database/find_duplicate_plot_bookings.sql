-- ============================================================================
-- Find duplicate plot bookings for an arazi
-- Identifies plots by `plots.title` (never plot_number) scoped to the arazi's
-- `legacy_arazi_code` (never internal id), per project convention.
--
-- Set the arazi code you want to check here:
-- ============================================================================
SET @arazi_code = '357';   -- change to the legacy_arazi_code you want to check

-- ----------------------------------------------------------------------------
-- 1) Same plot booked more than once with an active (non-expired) booking.
--    A plot should only ever have ONE currently-active booking.
-- ----------------------------------------------------------------------------
SELECT
    a.legacy_arazi_code                AS arazi_code,
    p.title                            AS plot_title,
    COUNT(*)                           AS active_booking_count,
    GROUP_CONCAT(b.id ORDER BY b.id)   AS booking_ids,
    GROUP_CONCAT(b.customer_id ORDER BY b.id) AS customer_ids,
    GROUP_CONCAT(b.status ORDER BY b.id)      AS statuses
FROM bookings b
JOIN plots  p ON p.id = b.plot_id
JOIN arazis a ON a.id = p.arazi_id
WHERE a.legacy_arazi_code = @arazi_code
  AND (b.status IS NULL OR b.status <> 'expired')
GROUP BY a.legacy_arazi_code, p.id, p.title
HAVING COUNT(*) > 1
ORDER BY p.title;

-- ----------------------------------------------------------------------------
-- 2) Same plot has BOTH an active booking AND a completed registry
--    (i.e. it was sold/registered but still shows an open booking - conflict).
-- ----------------------------------------------------------------------------
SELECT
    a.legacy_arazi_code                    AS arazi_code,
    p.title                                AS plot_title,
    b.id                                   AS booking_id,
    b.status                               AS booking_status,
    r.id                                   AS registry_id,
    r.status                               AS registry_status,
    r.payment_status                       AS registry_payment_status
FROM plots  p
JOIN arazis a ON a.id = p.arazi_id
JOIN bookings  b ON b.plot_id = p.id AND (b.status IS NULL OR b.status <> 'expired')
JOIN registries r ON r.plot_id = p.id AND (r.status = 'completed' OR r.payment_status = 'completed')
WHERE a.legacy_arazi_code = @arazi_code
ORDER BY p.title;

-- ----------------------------------------------------------------------------
-- 3) Same plot has more than one completed registry (double-sold).
-- ----------------------------------------------------------------------------
SELECT
    a.legacy_arazi_code                     AS arazi_code,
    p.title                                 AS plot_title,
    COUNT(*)                                AS completed_registry_count,
    GROUP_CONCAT(r.id ORDER BY r.id)         AS registry_ids,
    GROUP_CONCAT(r.customer_id ORDER BY r.id) AS customer_ids
FROM registries r
JOIN plots  p ON p.id = r.plot_id
JOIN arazis a ON a.id = p.arazi_id
WHERE a.legacy_arazi_code = @arazi_code
  AND (r.status = 'completed' OR r.payment_status = 'completed')
GROUP BY a.legacy_arazi_code, p.id, p.title
HAVING COUNT(*) > 1
ORDER BY p.title;

-- ----------------------------------------------------------------------------
-- 4) Duplicate plot TITLES within the same arazi (data-entry duplicates).
--    Note: plots has a unique constraint on (arazi_id, plot_number) but NOT
--    on (arazi_id, title) - so title collisions are possible and should be
--    checked/cleaned separately.
-- ----------------------------------------------------------------------------
SELECT
    a.legacy_arazi_code             AS arazi_code,
    p.title                         AS plot_title,
    COUNT(*)                        AS plot_row_count,
    GROUP_CONCAT(p.id ORDER BY p.id) AS plot_ids
FROM plots  p
JOIN arazis a ON a.id = p.arazi_id
WHERE a.legacy_arazi_code = @arazi_code
GROUP BY a.legacy_arazi_code, p.title
HAVING COUNT(*) > 1
ORDER BY p.title;

-- ----------------------------------------------------------------------------
-- 5) All-arazi sweep (no @arazi_code filter) - run this to find EVERY arazi
--    that has any duplicate active booking, useful for a site-wide audit.
-- ----------------------------------------------------------------------------
SELECT
    a.legacy_arazi_code                AS arazi_code,
    p.title                            AS plot_title,
    COUNT(*)                           AS active_booking_count,
    GROUP_CONCAT(b.id ORDER BY b.id)   AS booking_ids
FROM bookings b
JOIN plots  p ON p.id = b.plot_id
JOIN arazis a ON a.id = p.arazi_id
WHERE (b.status IS NULL OR b.status <> 'expired')
GROUP BY a.legacy_arazi_code, p.id, p.title
HAVING COUNT(*) > 1
ORDER BY a.legacy_arazi_code, p.title;
