-- ============================================================================
-- Ownership scoping: add `created_by` to deal-data tables + backfill.
-- Mirrors migration 2026_07_22_000001_add_created_by_ownership_columns.php
--
-- Safe to run more than once (idempotent):
--   * ADD COLUMN IF NOT EXISTS / ADD INDEX IF NOT EXISTS  (MySQL 8.0.29+ / MariaDB 10.3+)
--   * backfill only touches rows where created_by IS NULL
--
-- If your MySQL is OLDER than 8.0.29 and rejects "IF NOT EXISTS" on ADD COLUMN,
-- see the note at the bottom of this file.
-- ============================================================================

START TRANSACTION;

-- 1) Add the owner column (nullable + indexed) to each deal-data table --------
ALTER TABLE `agents`                 ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `agents_created_by_index` (`created_by`);
ALTER TABLE `arazis`                 ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `arazis_created_by_index` (`created_by`);
ALTER TABLE `arazi_documents`        ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `arazi_documents_created_by_index` (`created_by`);
ALTER TABLE `bookings`               ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `bookings_created_by_index` (`created_by`);
ALTER TABLE `customer_bonds`         ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `customer_bonds_created_by_index` (`created_by`);
ALTER TABLE `customer_bond_payments` ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `customer_bond_payments_created_by_index` (`created_by`);
ALTER TABLE `customers`              ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `customers_created_by_index` (`created_by`);
ALTER TABLE `investors`              ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `investors_created_by_index` (`created_by`);
ALTER TABLE `kisan_bonds`            ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `kisan_bonds_created_by_index` (`created_by`);
ALTER TABLE `kisans`                 ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `kisans_created_by_index` (`created_by`);
ALTER TABLE `partners`               ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `partners_created_by_index` (`created_by`);
ALTER TABLE `payments`               ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `payments_created_by_index` (`created_by`);
ALTER TABLE `plots`                  ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `plots_created_by_index` (`created_by`);
ALTER TABLE `registries`             ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `registries_created_by_index` (`created_by`);
ALTER TABLE `sales`                  ADD COLUMN IF NOT EXISTS `created_by` BIGINT UNSIGNED NULL AFTER `id`, ADD INDEX IF NOT EXISTS `sales_created_by_index` (`created_by`);

-- 2) Backfill existing rows to the first admin/super_admin user ---------------
--    (keeps legacy data visible to admins instead of vanishing under scoping).
SET @admin_id = (
    SELECT id FROM `users`
    WHERE role IN ('super_admin', 'admin')
    ORDER BY id LIMIT 1
);
-- fall back to the very first user if no admin role exists
SET @admin_id = COALESCE(@admin_id, (SELECT id FROM `users` ORDER BY id LIMIT 1));

UPDATE `agents`                 SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `arazis`                 SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `arazi_documents`        SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `bookings`               SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `customer_bonds`         SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `customer_bond_payments` SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `customers`              SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `investors`              SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `kisan_bonds`            SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `kisans`                 SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `partners`               SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `payments`               SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `plots`                  SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `registries`             SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;
UPDATE `sales`                  SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;

-- customer_bond_cheques already has a created_by column; clear any legacy NULLs.
UPDATE `customer_bond_cheques`  SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;

COMMIT;

-- ============================================================================
-- OLDER MySQL (< 8.0.29) fallback:
-- If "ADD COLUMN IF NOT EXISTS" errors, run each column add WITHOUT the guard,
-- e.g.:
--   ALTER TABLE `customers` ADD COLUMN `created_by` BIGINT UNSIGNED NULL AFTER `id`;
--   ALTER TABLE `customers` ADD INDEX `customers_created_by_index` (`created_by`);
-- and skip any table where the column already exists. The UPDATE backfill part
-- works on every MySQL version as-is.
-- ============================================================================
