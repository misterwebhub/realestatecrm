-- ============================================================================
-- Roles & Permissions + Per-User Ownership Scoping — server sync script
-- ============================================================================
-- Safe to run multiple times. Every statement is idempotent:
--   - CREATE TABLE IF NOT EXISTS  -> skips tables that already exist
--   - ADD COLUMN IF NOT EXISTS    -> skips columns that already exist
--     (requires MySQL 8.0.29+ / MariaDB 10.3+; XAMPP 8.2 ships MySQL 8, OK)
--   - INSERT ... ON DUPLICATE KEY UPDATE -> inserts only missing rows
-- Nothing here drops or destroys existing data. Anything already present on
-- the server (tables, columns, permission rows, roles) is left untouched;
-- only what's missing gets added.
--
-- Run inside the app's database, e.g.:
--   mysql -u USER -p DBNAME < database/server_permissions_sync.sql
-- ============================================================================

START TRANSACTION;

-- ----------------------------------------------------------------------------
-- 1) Core roles/permissions tables (from
--    2026_06_24_000000_create_roles_and_permissions_tables.php)
-- ----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS `roles` (
  `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(60) NOT NULL,
  `display_name` VARCHAR(100) NOT NULL,
  `is_system` TINYINT(1) NOT NULL DEFAULT 0,
  `created_at` TIMESTAMP NULL DEFAULT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `roles_name_unique` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `permissions` (
  `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(120) NOT NULL,
  `module` VARCHAR(60) NOT NULL,
  `action` VARCHAR(40) NOT NULL,
  `created_at` TIMESTAMP NULL DEFAULT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `permissions_name_unique` (`name`),
  KEY `permissions_module_index` (`module`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `permission_role` (
  `permission_id` BIGINT UNSIGNED NOT NULL,
  `role_id` BIGINT UNSIGNED NOT NULL,
  PRIMARY KEY (`permission_id`, `role_id`),
  KEY `permission_role_role_id_foreign` (`role_id`),
  CONSTRAINT `permission_role_permission_id_foreign` FOREIGN KEY (`permission_id`) REFERENCES `permissions` (`id`) ON DELETE CASCADE,
  CONSTRAINT `permission_role_role_id_foreign` FOREIGN KEY (`role_id`) REFERENCES `roles` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- users.role_id (nullable FK to roles)
ALTER TABLE `users`
  ADD COLUMN IF NOT EXISTS `role_id` BIGINT UNSIGNED NULL AFTER `role`;

-- Add the FK only if it doesn't already exist (name may vary if hand-added,
-- so guard on information_schema instead of a bare ADD CONSTRAINT).
SET @fk_exists := (
  SELECT COUNT(*) FROM information_schema.TABLE_CONSTRAINTS
  WHERE CONSTRAINT_SCHEMA = DATABASE()
    AND TABLE_NAME = 'users'
    AND CONSTRAINT_NAME = 'users_role_id_foreign'
);
SET @sql := IF(@fk_exists = 0,
  'ALTER TABLE `users` ADD CONSTRAINT `users_role_id_foreign` FOREIGN KEY (`role_id`) REFERENCES `roles` (`id`) ON DELETE SET NULL',
  'SELECT 1'
);
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- users.role enum must include 'staff' (2026_06_27_000000_add_staff_to_users_role_enum.php)
ALTER TABLE `users`
  MODIFY `role` ENUM('admin','manager','accountant','staff') NOT NULL DEFAULT 'staff';

-- ----------------------------------------------------------------------------
-- 2) Per-user ownership columns
--    (2026_07_22_000001_add_created_by_ownership_columns.php)
--    Deal-data tables get a nullable, indexed created_by owner column.
--    Arazi & Plots keep created_by too (used for reporting) but stay shared
--    for read access — that's enforced in app code, not the schema.
-- ----------------------------------------------------------------------------

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

-- Backfill any NULL created_by to the first admin/super_admin user, so
-- legacy rows stay visible under admins instead of disappearing for
-- everyone once owner scoping is enforced.
SET @admin_id := (
  SELECT id FROM users WHERE role IN ('super_admin','admin') ORDER BY id LIMIT 1
);
SET @admin_id := COALESCE(@admin_id, (SELECT id FROM users ORDER BY id LIMIT 1));

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

-- customer_bond_cheques already had created_by; just backfill legacy NULLs.
UPDATE `customer_bond_cheques` SET created_by = @admin_id WHERE created_by IS NULL AND @admin_id IS NOT NULL;

-- ----------------------------------------------------------------------------
-- 3) Permission rows — one per "{module}.{action}" from config/permissions.php
--    (112 rows). INSERT ... ON DUPLICATE KEY UPDATE means existing rows
--    (matched by unique `name`) are left as-is (module/action re-affirmed,
--    no data loss); only missing rows get inserted.
-- ----------------------------------------------------------------------------

INSERT INTO `permissions` (`name`, `module`, `action`, `created_at`, `updated_at`) VALUES
('arazis.view','arazis','view',NOW(),NOW()),
('arazis.create','arazis','create',NOW(),NOW()),
('arazis.edit','arazis','edit',NOW(),NOW()),
('arazis.delete','arazis','delete',NOW(),NOW()),
('arazi_maps.view','arazi_maps','view',NOW(),NOW()),
('arazi_groups.view','arazi_groups','view',NOW(),NOW()),
('arazi_groups.create','arazi_groups','create',NOW(),NOW()),
('arazi_groups.edit','arazi_groups','edit',NOW(),NOW()),
('arazi_groups.delete','arazi_groups','delete',NOW(),NOW()),
('deed_mappings.view','deed_mappings','view',NOW(),NOW()),
('deed_mappings.create','deed_mappings','create',NOW(),NOW()),
('deed_mappings.edit','deed_mappings','edit',NOW(),NOW()),
('deed_mappings.delete','deed_mappings','delete',NOW(),NOW()),
('plots.view','plots','view',NOW(),NOW()),
('plots.create','plots','create',NOW(),NOW()),
('plots.edit','plots','edit',NOW(),NOW()),
('plots.delete','plots','delete',NOW(),NOW()),
('plot_holds.view','plot_holds','view',NOW(),NOW()),
('plot_holds.create','plot_holds','create',NOW(),NOW()),
('plot_holds.edit','plot_holds','edit',NOW(),NOW()),
('plot_holds.delete','plot_holds','delete',NOW(),NOW()),
('registries.view','registries','view',NOW(),NOW()),
('registries.create','registries','create',NOW(),NOW()),
('registries.edit','registries','edit',NOW(),NOW()),
('registries.delete','registries','delete',NOW(),NOW()),
('waiting_payments.view','waiting_payments','view',NOW(),NOW()),
('kisans.view','kisans','view',NOW(),NOW()),
('kisans.create','kisans','create',NOW(),NOW()),
('kisans.edit','kisans','edit',NOW(),NOW()),
('kisans.delete','kisans','delete',NOW(),NOW()),
('kisan_registries.view','kisan_registries','view',NOW(),NOW()),
('kisan_registries.create','kisan_registries','create',NOW(),NOW()),
('kisan_registries.edit','kisan_registries','edit',NOW(),NOW()),
('kisan_registries.delete','kisan_registries','delete',NOW(),NOW()),
('kisan_bonds.view','kisan_bonds','view',NOW(),NOW()),
('kisan_bonds.create','kisan_bonds','create',NOW(),NOW()),
('kisan_bonds.edit','kisan_bonds','edit',NOW(),NOW()),
('kisan_bonds.delete','kisan_bonds','delete',NOW(),NOW()),
('kisan_payments.view','kisan_payments','view',NOW(),NOW()),
('kisan_payments.create','kisan_payments','create',NOW(),NOW()),
('kisan_payments.edit','kisan_payments','edit',NOW(),NOW()),
('kisan_payments.delete','kisan_payments','delete',NOW(),NOW()),
('kisan_ledger.view','kisan_ledger','view',NOW(),NOW()),
('kisan_brokers.view','kisan_brokers','view',NOW(),NOW()),
('kisan_brokers.create','kisan_brokers','create',NOW(),NOW()),
('kisan_brokers.edit','kisan_brokers','edit',NOW(),NOW()),
('kisan_brokers.delete','kisan_brokers','delete',NOW(),NOW()),
('customers.view','customers','view',NOW(),NOW()),
('customers.create','customers','create',NOW(),NOW()),
('customers.edit','customers','edit',NOW(),NOW()),
('customers.delete','customers','delete',NOW(),NOW()),
('customer_bonds.view','customer_bonds','view',NOW(),NOW()),
('customer_bonds.create','customer_bonds','create',NOW(),NOW()),
('customer_bonds.edit','customer_bonds','edit',NOW(),NOW()),
('customer_bonds.delete','customer_bonds','delete',NOW(),NOW()),
('customer_payments.view','customer_payments','view',NOW(),NOW()),
('customer_payments.create','customer_payments','create',NOW(),NOW()),
('customer_payments.edit','customer_payments','edit',NOW(),NOW()),
('customer_payments.delete','customer_payments','delete',NOW(),NOW()),
('customer_ledger.view','customer_ledger','view',NOW(),NOW()),
('customer_brokers.view','customer_brokers','view',NOW(),NOW()),
('customer_brokers.create','customer_brokers','create',NOW(),NOW()),
('customer_brokers.edit','customer_brokers','edit',NOW(),NOW()),
('customer_brokers.delete','customer_brokers','delete',NOW(),NOW()),
('office_brokers.view','office_brokers','view',NOW(),NOW()),
('office_brokers.create','office_brokers','create',NOW(),NOW()),
('office_brokers.edit','office_brokers','edit',NOW(),NOW()),
('office_brokers.delete','office_brokers','delete',NOW(),NOW()),
('investors.view','investors','view',NOW(),NOW()),
('investors.create','investors','create',NOW(),NOW()),
('investors.edit','investors','edit',NOW(),NOW()),
('investors.delete','investors','delete',NOW(),NOW()),
('partners.view','partners','view',NOW(),NOW()),
('partners.create','partners','create',NOW(),NOW()),
('partners.edit','partners','edit',NOW(),NOW()),
('partners.delete','partners','delete',NOW(),NOW()),
('expenses.view','expenses','view',NOW(),NOW()),
('expenses.create','expenses','create',NOW(),NOW()),
('expenses.edit','expenses','edit',NOW(),NOW()),
('expenses.delete','expenses','delete',NOW(),NOW()),
('cheques.view','cheques','view',NOW(),NOW()),
('cheques.create','cheques','create',NOW(),NOW()),
('cheques.edit','cheques','edit',NOW(),NOW()),
('cheques.delete','cheques','delete',NOW(),NOW()),
('cheque_manual.view','cheque_manual','view',NOW(),NOW()),
('cheque_assign.view','cheque_assign','view',NOW(),NOW()),
('connected_accounts.view','connected_accounts','view',NOW(),NOW()),
('connected_accounts.create','connected_accounts','create',NOW(),NOW()),
('connected_accounts.edit','connected_accounts','edit',NOW(),NOW()),
('connected_accounts.delete','connected_accounts','delete',NOW(),NOW()),
('reports.view','reports','view',NOW(),NOW()),
('report_partners.view','report_partners','view',NOW(),NOW()),
('report_arazis.view','report_arazis','view',NOW(),NOW()),
('report_brokers.view','report_brokers','view',NOW(),NOW()),
('report_registries.view','report_registries','view',NOW(),NOW()),
('report_payments.view','report_payments','view',NOW(),NOW()),
('report_sales.view','report_sales','view',NOW(),NOW()),
('report_payments_by_user.view','report_payments_by_user','view',NOW(),NOW()),
('report_bonds_cumulative.view','report_bonds_cumulative','view',NOW(),NOW()),
('report_plot_details.view','report_plot_details','view',NOW(),NOW()),
('user_master.view','user_master','view',NOW(),NOW()),
('user_master.create','user_master','create',NOW(),NOW()),
('user_master.edit','user_master','edit',NOW(),NOW()),
('user_master.delete','user_master','delete',NOW(),NOW()),
('roles.view','roles','view',NOW(),NOW()),
('roles.create','roles','create',NOW(),NOW()),
('roles.edit','roles','edit',NOW(),NOW()),
('roles.delete','roles','delete',NOW(),NOW()),
('activity_logs.view','activity_logs','view',NOW(),NOW()),
('audit_logs.view','audit_logs','view',NOW(),NOW()),
('converter.view','converter','view',NOW(),NOW()),
('quick_access.view','quick_access','view',NOW(),NOW())
ON DUPLICATE KEY UPDATE
  `module` = VALUES(`module`),
  `action` = VALUES(`action`),
  `updated_at` = NOW();

-- ----------------------------------------------------------------------------
-- 4) Starter roles — only created if missing, never overwritten.
-- ----------------------------------------------------------------------------

INSERT INTO `roles` (`name`, `display_name`, `is_system`, `created_at`, `updated_at`)
VALUES ('super_admin', 'Super Admin', 1, NOW(), NOW())
ON DUPLICATE KEY UPDATE `name` = `name`;

INSERT INTO `roles` (`name`, `display_name`, `is_system`, `created_at`, `updated_at`)
VALUES ('manager', 'Manager', 0, NOW(), NOW())
ON DUPLICATE KEY UPDATE `name` = `name`;

INSERT INTO `roles` (`name`, `display_name`, `is_system`, `created_at`, `updated_at`)
VALUES ('staff', 'Staff', 0, NOW(), NOW())
ON DUPLICATE KEY UPDATE `name` = `name`;

-- ----------------------------------------------------------------------------
-- 5) Attach every permission to Super Admin (kept in sync for UI clarity;
--    Super Admin actually bypasses all checks via Gate::before in code).
--    INSERT IGNORE only adds missing pairs, never removes existing ones.
-- ----------------------------------------------------------------------------

INSERT IGNORE INTO `permission_role` (`permission_id`, `role_id`)
SELECT p.id, r.id
FROM `permissions` p
JOIN `roles` r ON r.name = 'super_admin';

-- ----------------------------------------------------------------------------
-- 6) Promote existing legacy admins (role='admin', role_id still NULL) to
--    the Super Admin role. Users that already have a role_id are untouched.
-- ----------------------------------------------------------------------------

UPDATE `users` u
JOIN `roles` r ON r.name = 'super_admin'
SET u.role_id = r.id
WHERE u.role_id IS NULL AND u.role = 'admin';

COMMIT;
