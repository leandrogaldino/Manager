ALTER TABLE `manager`.`personcompressor` ADD COLUMN `controlledid` INT NOT NULL AFTER `compressorid`;
SET SQL_SAFE_UPDATES = 0;
UPDATE personcompressor pc
JOIN person p ON pc.personid = p.id
SET pc.controlledid = 1 - p.controlmaintenance;
SET SQL_SAFE_UPDATES = 1;
ALTER TABLE `manager`.`person` DROP COLUMN `controlmaintenance`;
