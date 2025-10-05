ALTER TABLE `manager`.`personcompressor` ADD COLUMN `controlledid` INT NOT NULL AFTER `compressorid`;
SET SQL_SAFE_UPDATES = 0;
UPDATE personcompressor pc
JOIN person p ON pc.personid = p.id
SET pc.controlledid = 1 - p.controlmaintenance;
SET SQL_SAFE_UPDATES = 1;
ALTER TABLE `manager`.`person` DROP COLUMN `controlmaintenance`;
SET SQL_SAFE_UPDATES = 0;
UPDATE evaluation SET documentname = NULL where sourceid = 1;
SET SQL_SAFE_UPDATES = 1;


DROP TRIGGER IF EXISTS `manager`.`personupdate`;
DROP TRIGGER IF EXISTS `manager`.`personcompressorupdate`;
DELIMITER $$

CREATE TRIGGER `personupdate` AFTER UPDATE ON `person` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 2, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.entityid <> NEW.entityid THEN INSERT INTO log VALUES (NULL, 2, NEW.id, 'Entidade', CASE WHEN OLD.entityid = 0 THEN 'PESSOA JURÍDICA' WHEN OLD.entityid = 1 THEN 'PESSOA FÍSICA' END, CASE WHEN NEW.entityid = 0 THEN 'PESSOA JURÍDICA' WHEN NEW.entityid = 1 THEN 'PESSOA FÍSICA' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.iscustomer <> NEW.iscustomer THEN INSERT INTO log VALUES (NULL, 2, NEW.id, 'Cliente', CASE WHEN OLD.iscustomer = TRUE THEN 'SIM' WHEN OLD.iscustomer = FALSE THEN 'NÃO' END, CASE WHEN NEW.iscustomer = TRUE THEN 'SIM' WHEN NEW.iscustomer = FALSE THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.isprovider <> NEW.isprovider THEN INSERT INTO log VALUES (NULL, 2, NEW.id, 'Fornecedor', CASE WHEN OLD.isprovider = TRUE THEN 'SIM' WHEN OLD.isprovider = FALSE THEN 'NÃO' END, CASE WHEN NEW.isprovider = TRUE THEN 'SIM' WHEN NEW.isprovider = FALSE THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.isemployee <> NEW.isemployee THEN INSERT INTO log VALUES (NULL, 2, NEW.id, 'Funcionário', CASE WHEN OLD.isemployee = TRUE THEN 'SIM' WHEN OLD.isemployee = FALSE THEN 'NÃO' END, CASE WHEN NEW.isemployee = TRUE THEN 'SIM' WHEN NEW.isemployee = FALSE THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.istechnician <> NEW.istechnician THEN INSERT INTO log VALUES (NULL, 2, NEW.id, 'Técnico', CASE WHEN OLD.istechnician = TRUE THEN 'SIM' WHEN OLD.istechnician = FALSE THEN 'NÃO' END, CASE WHEN NEW.istechnician = TRUE THEN 'SIM' WHEN NEW.istechnician = FALSE THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.iscarrier <> NEW.iscarrier THEN INSERT INTO log VALUES (NULL, 2, NEW.id, 'Transportadora', CASE WHEN OLD.iscarrier = TRUE THEN 'SIM' WHEN OLD.iscarrier = FALSE THEN 'NÃO' END, CASE WHEN NEW.iscarrier = TRUE THEN 'SIM' WHEN NEW.iscarrier = FALSE THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.document <> NEW.document THEN INSERT INTO log VALUES (NULL, 2, NEW.id, 'CPF/CNPJ', OLD.document, NEW.document, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.name <> NEW.name THEN INSERT INTO log VALUES (NULL, 2, NEW.id, 'Nome', OLD.name, NEW.name, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.shortname <> NEW.shortname THEN INSERT INTO log VALUES (NULL, 2, NEW.id, 'Nome Curto', OLD.shortname, NEW.shortname, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.note, '') <> IFNULL(NEW.note, '') THEN INSERT INTO log VALUES (NULL, 2, NEW.id, 'Observação', OLD.note, NEW.note, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
CREATE TRIGGER `personcompressorupdate` AFTER UPDATE ON `personcompressor` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.controlledid <> NEW.controlledid THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Controlado', CASE WHEN OLD.controlledid = 0 THEN 'SIM' WHEN OLD.controlledid = 1 THEN 'NÃO' END, CASE WHEN NEW.controlledid = 0 THEN 'SIM' WHEN NEW.controlledid = 1 THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.compressorid <> NEW.compressorid THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Compressor', CONCAT(OLD.compressorid, ' - ', (SELECT compressor.name FROM compressor WHERE compressor.id = OLD.compressorid)), CONCAT(NEW.compressorid, ' - ', (SELECT compressor.name FROM compressor WHERE compressor.id = NEW.compressorid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.serialnumber, '') <> IFNULL(NEW.serialnumber, '') THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Nº de Série', OLD.serialnumber, NEW.serialnumber, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.patrimony, '') <> IFNULL(NEW.patrimony, '') THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Patrimônio', OLD.patrimony, NEW.patrimony, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.sector, '') <> IFNULL(NEW.sector, '') THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Setor', OLD.sector, NEW.sector, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.unitcapacity <> NEW.unitcapacity THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Cap. Und.', OLD.unitcapacity, NEW.unitcapacity, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.note, '') <> IFNULL(NEW.note, '') THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Observação', OLD.note, NEW.note, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;
