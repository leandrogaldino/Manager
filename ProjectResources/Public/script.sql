/*Como a cryptokey foi alterada, a senha de todos os usuarios deve ser resetada*/
/*No caixa reicol comercio no mes 02/2024 tem um registro do expresso vedações que está sem responsavel, colocar reicol*/
/*No caixa reicol comercio no mes 08/2023 tem um registro da di napoli que está sem responsavel, colocar reicol*/
/*No caixa reicol comercio no mes 08/2023 tem um registro da di napoli que está sem responsavel, colocar reicol*/
/*No caixa aberto no mes 03/2024 tem um registro do almoço leandro que está sem responsavel, colocar leandro*/

CREATE TABLE `config` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `value` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO config VALUES
	(NULL, 'CloudLastSyncID', 0),
    (NULL, 'CloudOperationCount', 0),
    (NULL, 'CloudLastSyncDate', ''),
	(NULL, 'CloudMaxOperation', 2000);


ALTER TABLE personcompressorpart ADD COLUMN partbindid INT NOT NULL AFTER statusid;

ALTER TABLE `manager`.`agentevent` CHANGE COLUMN `description` `description` TEXT NULL DEFAULT NULL ;


DROP TRIGGER IF EXISTS `manager`.`personcompressorpartupdate`;

DELIMITER $$
USE `manager`$$
CREATE DEFINER=`root`@`localhost` TRIGGER `personcompressorpartupdate` AFTER UPDATE ON `personcompressorpart` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.partbindid <> NEW.partbindid THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Vínculo', CASE WHEN OLD.partbindid = 0 THEN 'NENHUM' WHEN OLD.partbindid = 1 THEN 'FILTRO DE AR' WHEN OLD.partbindid = 2 THEN 'FILTRO DE OLEO' WHEN OLD.partbindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN OLD.partbindid = 4 THEN 'OLEO' WHEN OLD.partbindid = 5 THEN 'COALESCENTE' END, CASE WHEN NEW.partbindid = 0 THEN 'NENHUM' WHEN NEW.partbindid = 1 THEN 'FILTRO DE AR' WHEN NEW.partbindid = 2 THEN 'FILTRO DE OLEO' WHEN NEW.partbindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN NEW.partbindid = 4 THEN 'OLEO' WHEN NEW.partbindid = 5 THEN 'COALESCENTE' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.itemname, OLD.productid) <> IFNULL(NEW.itemname, NEW.productid) THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Item', IFNULL(OLD.itemname, (SELECT CONCAT(product.id, ' - ', product.name) FROM product WHERE product.id = OLD.productid)), IFNULL(NEW.itemname, (SELECT CONCAT(product.id, ' - ', product.name) FROM product WHERE product.id = NEW.productid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.quantity <> NEW.quantity THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Qtd.', FORMAT(OLD.quantity, 2, 'pt_BR'), FORMAT(NEW.quantity, 2, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.capacity <> NEW.capacity THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Cap.', FORMAT(OLD.capacity, 0, 'pt_BR'), FORMAT(NEW.capacity, 0, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;

ALTER TABLE `manager`.`evaluation` CHANGE COLUMN `documentname` `documentpath` VARCHAR(255) NULL DEFAULT NULL;

ALTER TABLE `manager`.`evaluation` ADD COLUMN `signaturepath` VARCHAR(255) NULL DEFAULT NULL AFTER `documentpath`;

DROP TRIGGER IF EXISTS `manager`.`evaluationupdate`;

DELIMITER $$
USE `manager`$$
CREATE DEFINER=`root`@`localhost` TRIGGER `evaluationupdate` AFTER UPDATE ON `evaluation` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'DESAPROVADA' WHEN OLD.statusid = 1 THEN 'APROVADA' WHEN OLD.statusid = 2 THEN 'REJEITADA' WHEN OLD.statusid = 3 THEN 'REVISADA'END, CASE WHEN NEW.statusid = 0 THEN 'DESAPROVADA' WHEN NEW.statusid = 1 THEN 'APROVADA' WHEN NEW.statusid = 2 THEN 'REJEITADA' WHEN NEW.statusid = 3 THEN 'REVISADA' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.evaluationtypeid <> NEW.evaluationtypeid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Tipo de Avaliação', CASE WHEN OLD.evaluationtypeid = 0 THEN 'LEVANTAMENTO' WHEN OLD.evaluationtypeid = 1 THEN 'EXECUCAO' END, CASE WHEN NEW.evaluationtypeid = 0 THEN 'LEVANTAMENTO' WHEN NEW.evaluationtypeid = 1 THEN 'EXECUCAO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.evaluationdate <> NEW.evaluationdate THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Data Avaliação', DATE_FORMAT(OLD.evaluationdate,'%d/%m/%Y'), DATE_FORMAT(NEW.evaluationdate,'%d/%m/%Y'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.starttime <> NEW.starttime THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Inicio', OLD.starttime, NEW.starttime, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.endtime <> NEW.endtime THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Fim', OLD.endtime, NEW.endtime, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.evaluationnumber <> NEW.evaluationnumber THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Nº Avaliação', OLD.evaluationnumber, NEW.evaluationnumber, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.customerid <> NEW.customerid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Cliente', CONCAT(OLD.customerid, ' - ', (SELECT person.name FROM person WHERE person.id = OLD.customerid)), CONCAT(NEW.customerid, ' - ', (SELECT person.name FROM person WHERE person.id = NEW.customerid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.responsible, '') <> IFNULL(NEW.responsible, '') THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Responsável', OLD.responsible, NEW.responsible, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.personcompressorid <> NEW.personcompressorid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Compressor', CONCAT(OLD.personcompressorid, ' - ', (SELECT compressor.name FROM personcompressor LEFT JOIN compressor ON compressor.id = personcompressor.compressorid WHERE personcompressor.id = OLD.personcompressorid)), CONCAT(NEW.personcompressorid, ' - ', (SELECT compressor.name FROM personcompressor LEFT JOIN compressor ON compressor.id = personcompressor.compressorid WHERE personcompressor.id = NEW.personcompressorid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.horimeter <> NEW.horimeter THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Horímetro', FORMAT(OLD.horimeter, 0, 'pt_BR'), FORMAT(NEW.horimeter, 0, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.averageworkload <> NEW.averageworkload THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'MHD', FORMAT(OLD.averageworkload, 2, 'pt_BR'), FORMAT(NEW.averageworkload, 2, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.technicaladvice, '') <> IFNULL(NEW.technicaladvice, '') THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Parecer Técnico', OLD.technicaladvice, NEW.technicaladvice, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.documentpath, '') <> IFNULL(NEW.documentpath, '') THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Documento', NULL, 'Alterado', NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.signaturepath, '') <> IFNULL(NEW.signaturepath, '') THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Assinatura', NULL, 'Alterado', NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;

ALTER TABLE `manager`.`cash` CHANGE COLUMN `documentname` `documentpath` VARCHAR(255) NULL DEFAULT NULL;


DROP TRIGGER IF EXISTS `manager`.`cashupdate`;

DELIMITER $$
USE `manager`$$
CREATE DEFINER=`root`@`localhost` TRIGGER `cashupdate` AFTER UPDATE ON `cash` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 11, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ABERTO' WHEN OLD.statusid = 1 THEN 'FECHADO' END, CASE WHEN NEW.statusid = 0 THEN 'ABERTO' WHEN NEW.statusid = 1 THEN 'FECHADO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.note, '') <> IFNULL(NEW.note, '') THEN INSERT INTO log VALUES (NULL, 11, NEW.id, 'Observação', OLD.note, NEW.note, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.documentpath, '') <> IFNULL(NEW.documentpath, '') THEN INSERT INTO log VALUES (NULL, 11, NEW.id, 'Documento', NULL, 'Alterado', NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;


ALTER TABLE `manager`.`request` CHANGE COLUMN `documentname` `documentpath` VARCHAR(255) NULL DEFAULT NULL;


DROP TRIGGER IF EXISTS `manager`.`requestupdate`;

DELIMITER $$
USE `manager`$$
CREATE DEFINER=`root`@`localhost` TRIGGER `requestupdate` AFTER UPDATE ON `request` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 15, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'PENDENTE' WHEN OLD.statusid = 1 THEN 'PARC. CONCLUÍDO' WHEN OLD.statusid = 2 THEN 'CONCLUÍDO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' WHEN NEW.statusid = 2 THEN 'CONCLUÍDO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.destination <> NEW.destination THEN INSERT INTO log VALUES (NULL, 15, NEW.id, 'Destino', OLD.destination, NEW.destination, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.responsible <> NEW.responsible THEN INSERT INTO log VALUES (NULL, 15, NEW.id, 'Responsável', OLD.responsible, NEW.responsible, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.note, '') <> IFNULL(NEW.note, '') THEN INSERT INTO log VALUES (NULL, 15, NEW.id, 'Observação', OLD.note, NEW.note, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.documentpath, '') <> IFNULL(NEW.documentpath, '') THEN INSERT INTO log VALUES (NULL, 15, NEW.id, 'Documento', NULL, 'Alterado', NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;

ALTER TABLE `manager`.`productpicture` CHANGE COLUMN `picturename` `picturepath` VARCHAR(255) NOT NULL ;


DROP TRIGGER IF EXISTS `manager`.`productpictureupdate`;

DELIMITER $$
USE `manager`$$
CREATE DEFINER=`root`@`localhost` TRIGGER `productpictureupdate` AFTER UPDATE ON `productpicture` FOR EACH ROW BEGIN
IF OLD.picturepath <> NEW.picturepath THEN INSERT INTO log VALUES (NULL, 604, NEW.id, 'Foto Alterada', NULL, NULL, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.caption <> NEW.caption THEN INSERT INTO log VALUES (NULL, 604, NEW.id, 'Legenda', OLD.caption, NEW.caption, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;

ALTER TABLE `manager`.`emailsignature` CHANGE COLUMN `directoryname` `directorypath` VARCHAR(255) NULL DEFAULT NULL ;

DROP TRIGGER IF EXISTS `manager`.`emailsignatureupdate`;

DELIMITER $$
USE `manager`$$
CREATE DEFINER=`root`@`localhost` TRIGGER `emailsignatureupdate` AFTER UPDATE ON `emailsignature` FOR EACH ROW BEGIN
IF OLD.name <> NEW.name THEN INSERT INTO log VALUES (NULL, 20, NEW.id, 'Nome', OLD.name, NEW.name, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.directorypath, '') <> IFNULL(NEW.directorypath, '') THEN INSERT INTO log VALUES (NULL, 20, NEW.id, 'Assinatura Alterada', NULL, NULL, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;

CREATE TABLE `evaluationphoto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `creation` date NOT NULL,
  `evaluationid` int NOT NULL,
  `photopath` VARCHAR(255) NOT NULL,
  `userid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `evaluationid` (`evaluationid`),
  KEY `userid` (`userid`),
  CONSTRAINT `evaluationphoto_ibfk_1` FOREIGN KEY (`evaluationid`) REFERENCES `evaluation` (`id`) ON DELETE CASCADE,
  CONSTRAINT `evaluationphoto_ibfk_3` FOREIGN KEY (`userid`) REFERENCES `user` (`id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=3532 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TRIGGER IF EXISTS `manager`.`evaluationtephotoinsert`;

DELIMITER $$
USE `manager`$$
CREATE DEFINER=`root`@`localhost` TRIGGER `evaluationphotoinsert` AFTER INSERT ON `evaluationphoto` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1308, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$

CREATE DEFINER=`root`@`localhost` TRIGGER `evaluationphotoupdate` AFTER UPDATE ON `evaluationphoto` FOR EACH ROW BEGIN
IF OLD.photopath <> NEW.photopath THEN INSERT INTO log VALUES (NULL, 1308, NEW.id, 'Foto', NULL, 'Alterado', NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$

CREATE DEFINER=`root`@`localhost` TRIGGER `evaluationphotodelete` AFTER DELETE ON `evaluationphoto` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1308, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$

DELIMITER ;

