-- ============================================================================
-- Deed Merging — server sync script
-- ============================================================================
-- Safe to run multiple times. Every statement is idempotent:
--   - CREATE TABLE IF NOT EXISTS  -> skips a table if it already exists
--   - ADD COLUMN IF NOT EXISTS    -> skips a column if it already exists
--     (requires MySQL 8.0.29+ / MariaDB 10.3+; XAMPP 8.2 ships MySQL 8, OK)
--   - Guards on information_schema before ADD UNIQUE KEY, so re-running
--     never fails even if the index was already added
-- Nothing here drops or destroys existing data.
--
-- Requires: arazis, partners, users tables must already exist. Run
-- database/server_deed_mappings_sync.sql first if this is a fresh DB.
--
-- Run inside the app's database, e.g.:
--   mysql -u USER -p DBNAME < database/server_deed_mergings_sync.sql
-- ============================================================================

START TRANSACTION;

-- ----------------------------------------------------------------------------
-- 1) deed_mergings table (2026_08_06_000000_create_deed_mergings_table.php)
--    One row per "merge" action performed on an arazi: the arazi code it
--    was performed against, and the single partner every merged row
--    resolved to.
-- ----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS `deed_mergings` (
  `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `arazi_code` VARCHAR(100) NOT NULL,
  `partner_id` BIGINT UNSIGNED NOT NULL,
  `created_by` BIGINT UNSIGNED NULL,
  `created_at` TIMESTAMP NULL DEFAULT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `deed_mergings_arazi_code_index` (`arazi_code`),
  KEY `deed_mergings_partner_id_foreign` (`partner_id`),
  KEY `deed_mergings_created_by_foreign` (`created_by`),
  CONSTRAINT `deed_mergings_partner_id_foreign` FOREIGN KEY (`partner_id`) REFERENCES `partners` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `deed_mergings_created_by_foreign` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------------------------------------------------------
-- 2) deed_mergings.merged_deed_no
--    (2026_08_06_000002_add_merged_deed_no_to_deed_mergings_table.php)
--    The new, single Deed No a merge consolidates its member rows into —
--    user-entered at merge time, unique like any other Deed No.
--    DEFAULT '' so this succeeds even against a table that already has
--    rows (matches what the equivalent Laravel migration produces).
-- ----------------------------------------------------------------------------

ALTER TABLE `deed_mergings`
  ADD COLUMN IF NOT EXISTS `merged_deed_no` VARCHAR(100) NOT NULL DEFAULT '' AFTER `arazi_code`;

SET @idx_exists := (
  SELECT COUNT(*) FROM information_schema.STATISTICS
  WHERE TABLE_SCHEMA = DATABASE()
    AND TABLE_NAME = 'deed_mergings'
    AND INDEX_NAME = 'deed_mergings_merged_deed_no_unique'
);
SET @sql := IF(@idx_exists = 0,
  'ALTER TABLE `deed_mergings` ADD UNIQUE KEY `deed_mergings_merged_deed_no_unique` (`merged_deed_no`)',
  'SELECT 1'
);
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- ----------------------------------------------------------------------------
-- 3) deed_merging_items table
--    (2026_08_06_000001_create_deed_merging_items_table.php)
--    Individual arazi rows (i.e. individual kisan shares) included in a
--    deed_merging. An arazi row can only belong to one merge — enforced by
--    the unique index on arazi_id — so it can't be double-merged.
-- ----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS `deed_merging_items` (
  `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `deed_merging_id` BIGINT UNSIGNED NOT NULL,
  `arazi_id` BIGINT UNSIGNED NOT NULL,
  `deed_no` VARCHAR(100) NOT NULL,
  `created_at` TIMESTAMP NULL DEFAULT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `deed_merging_items_arazi_id_unique` (`arazi_id`),
  KEY `deed_merging_items_deed_merging_id_foreign` (`deed_merging_id`),
  CONSTRAINT `deed_merging_items_deed_merging_id_foreign` FOREIGN KEY (`deed_merging_id`) REFERENCES `deed_mergings` (`id`) ON DELETE CASCADE,
  CONSTRAINT `deed_merging_items_arazi_id_foreign` FOREIGN KEY (`arazi_id`) REFERENCES `arazis` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

COMMIT;
