-- ============================================================================
-- Deed Mapping — server sync script
-- ============================================================================
-- Safe to run multiple times. Every statement is idempotent:
--   - CREATE TABLE IF NOT EXISTS  -> skips the table if it already exists
--   - Guards on information_schema before ADD UNIQUE KEY, so re-running
--     never fails even if the index was already added
-- Nothing here drops or destroys existing data.
--
-- Requires: arazis, partners, users tables must already exist.
--
-- Run inside the app's database, e.g.:
--   mysql -u USER -p DBNAME < database/server_deed_mappings_sync.sql
-- ============================================================================

START TRANSACTION;

-- ----------------------------------------------------------------------------
-- 1) deed_mappings table (2026_08_05_000000_create_deed_mappings_table.php)
--    One row per Arazi row (i.e. per kisan share of an arazi code) —
--    records which Deed No and Partner that row has been mapped to.
-- ----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS `deed_mappings` (
  `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `arazi_id` BIGINT UNSIGNED NOT NULL,
  `deed_no` VARCHAR(100) NOT NULL,
  `partner_id` BIGINT UNSIGNED NOT NULL,
  `created_by` BIGINT UNSIGNED NULL,
  `created_at` TIMESTAMP NULL DEFAULT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `deed_mappings_arazi_id_unique` (`arazi_id`),
  KEY `deed_mappings_partner_id_foreign` (`partner_id`),
  KEY `deed_mappings_created_by_foreign` (`created_by`),
  CONSTRAINT `deed_mappings_arazi_id_foreign` FOREIGN KEY (`arazi_id`) REFERENCES `arazis` (`id`) ON DELETE CASCADE,
  CONSTRAINT `deed_mappings_partner_id_foreign` FOREIGN KEY (`partner_id`) REFERENCES `partners` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `deed_mappings_created_by_foreign` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------------------------------------------------------
-- 2) deed_mappings.deed_no must be unique
--    (2026_08_05_000001_add_unique_deed_no_to_deed_mappings_table.php)
--    Guarded via information_schema in case the table above already existed
--    (from an earlier partial deploy) without this index yet.
-- ----------------------------------------------------------------------------

SET @idx_exists := (
  SELECT COUNT(*) FROM information_schema.STATISTICS
  WHERE TABLE_SCHEMA = DATABASE()
    AND TABLE_NAME = 'deed_mappings'
    AND INDEX_NAME = 'deed_mappings_deed_no_unique'
);
SET @sql := IF(@idx_exists = 0,
  'ALTER TABLE `deed_mappings` ADD UNIQUE KEY `deed_mappings_deed_no_unique` (`deed_no`)',
  'SELECT 1'
);
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

COMMIT;
