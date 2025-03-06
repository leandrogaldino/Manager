/*Como a cryptokey foi alterada, a senha de todos os usuarios deve ser resetada*/
/*Como a cryptokey foi alterada, a senha de todos os e-mails cadastradosuser*/
/*No caixa reicol comercio no mes 02/2024 tem um registro do expresso vedações que está sem responsavel, colocar reicol*/
/*No caixa reicol comercio no mes 08/2023 tem um registro da di napoli que está sem responsavel, colocar reicol*/
/*No caixa reicol comercio no mes 08/2023 tem um registro da di napoli que está sem responsavel, colocar reicol*/
/*No caixa aberto no mes 03/2024 tem um registro do almoço leandro que está sem responsavel, colocar leandro*/
/*Deletar UserPrivilege e UserPriuvilegePreset, PrivilegePreset  e PrivilegePresetPrivilege


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
CREATE TRIGGER `personcompressorpartupdate` AFTER UPDATE ON `personcompressorpart` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.partbindid <> NEW.partbindid THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Vínculo', CASE WHEN OLD.partbindid = 0 THEN 'NENHUM' WHEN OLD.partbindid = 1 THEN 'FILTRO DE AR' WHEN OLD.partbindid = 2 THEN 'FILTRO DE OLEO' WHEN OLD.partbindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN OLD.partbindid = 4 THEN 'OLEO' WHEN OLD.partbindid = 5 THEN 'COALESCENTE' END, CASE WHEN NEW.partbindid = 0 THEN 'NENHUM' WHEN NEW.partbindid = 1 THEN 'FILTRO DE AR' WHEN NEW.partbindid = 2 THEN 'FILTRO DE OLEO' WHEN NEW.partbindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN NEW.partbindid = 4 THEN 'OLEO' WHEN NEW.partbindid = 5 THEN 'COALESCENTE' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.itemname, OLD.productid) <> IFNULL(NEW.itemname, NEW.productid) THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Item', IFNULL(OLD.itemname, (SELECT CONCAT(product.id, ' - ', product.name) FROM product WHERE product.id = OLD.productid)), IFNULL(NEW.itemname, (SELECT CONCAT(product.id, ' - ', product.name) FROM product WHERE product.id = NEW.productid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.quantity <> NEW.quantity THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Qtd.', FORMAT(OLD.quantity, 2, 'pt_BR'), FORMAT(NEW.quantity, 2, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.capacity <> NEW.capacity THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Cap.', FORMAT(OLD.capacity, 0, 'pt_BR'), FORMAT(NEW.capacity, 0, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;


ALTER TABLE `manager`.`evaluation` ADD COLUMN `signaturename` VARCHAR(255) NULL DEFAULT NULL AFTER `documentname`;

DROP TRIGGER IF EXISTS `manager`.`evaluationupdate`;

DELIMITER $$
USE `manager`$$
CREATE TRIGGER `evaluationupdate` AFTER UPDATE ON `evaluation` FOR EACH ROW BEGIN
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
IF IFNULL(OLD.documentname, '') <> IFNULL(NEW.documentname, '') THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Documento', NULL, 'Alterado', NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.signaturename, '') <> IFNULL(NEW.signaturename, '') THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Assinatura', NULL, 'Alterado', NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;


CREATE TABLE `evaluationphoto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `creation` date NOT NULL,
  `evaluationid` int NOT NULL,
  `photoname` VARCHAR(255) NOT NULL,
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
CREATE TRIGGER `evaluationphotoinsert` AFTER INSERT ON `evaluationphoto` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1308, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$

CREATE TRIGGER `evaluationphotoupdate` AFTER UPDATE ON `evaluationphoto` FOR EACH ROW BEGIN
IF OLD.photoname <> NEW.photoname THEN INSERT INTO log VALUES (NULL, 1308, NEW.id, 'Foto', NULL, 'Alterado', NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$

CREATE TRIGGER `evaluationphotodelete` AFTER DELETE ON `evaluationphoto` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1308, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DELIMITER ;

/*INCLUI OS PARTBIND NOS ITEMS*/

SET SQL_SAFE_UPDATES = 0;
UPDATE personcompressorpart pcp
LEFT JOIN product p
  ON p.id = pcp.productid
SET pcp.partbindid = 
  CASE
    WHEN LOWER(COALESCE(pcp.itemname, p.name)) LIKE '%filtro de ar%' THEN 1
    WHEN LOWER(COALESCE(pcp.itemname, p.name)) LIKE '%filtro de oleo%' THEN 2
    WHEN LOWER(COALESCE(pcp.itemname, p.name)) LIKE '%separador%' THEN 3
    WHEN LOWER(COALESCE(pcp.itemname, p.name)) LIKE '%oleo%' OR LOWER(COALESCE(pcp.itemname, p.name)) LIKE '%óleo%' 
         AND LOWER(COALESCE(pcp.itemname, p.name)) NOT LIKE '%filtro%' 
         AND LOWER(COALESCE(pcp.itemname, p.name)) NOT LIKE '%elemento%' THEN 4
    WHEN LOWER(COALESCE(pcp.itemname, p.name)) LIKE '%coalescente%' THEN 5
    ELSE pcp.partbindid
  END;
SET SQL_SAFE_UPDATES = 1;


CREATE TABLE visitschedule (
	id INT NOT NULL AUTO_INCREMENT,
    creation DATE NOT NULL,
    statusid INT NOT NULL,
    visitdate DATE NOT NULL,
	visittypeid INT NOT NULL,
    customerid INT NOT NULL,
    personcompressorid INT NOT NULL,
    instructions LONGTEXT,
    lastupdate DATETIME NOT NULL,
    userid INT NOT NULL,    
    PRIMARY KEY(id),
    FOREIGN KEY (customerid) REFERENCES person (id) ON DELETE RESTRICT,
    FOREIGN KEY (personcompressorid) REFERENCES personcompressor (id) ON DELETE RESTRICT,
    FOREIGN KEY (userid) REFERENCES user (id) ON DELETE RESTRICT
);

DELIMITER $$
USE `manager`$$
CREATE TRIGGER `visitscheduleinsert` AFTER INSERT ON `visitschedule` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 22, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$

CREATE TRIGGER `visitscheduleupdate` AFTER UPDATE ON `visitschedule` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'PENDENTE' WHEN OLD.statusid = 1 THEN 'FINALIZADA' WHEN OLD.statusid = 2 THEN 'CANCELADA' END, CASE WHEN NEW.statusid = 0 THEN 'PENDENTE' WHEN NEW.statusid = 1 THEN 'FINALIZADA' WHEN NEW.statusid = 2 THEN 'CANCELADA' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.visitdate <> NEW.visitdate THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Data da Visita', OLD.visitdate, NEW.visitdate, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.visittypeid <> NEW.visittypeid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Tipo de Visita', CASE WHEN OLD.visittypeid = 0 THEN 'LEVANTAMENTO' WHEN OLD.visittypeid = 1 THEN 'PREVENTIVA' WHEN OLD.visittypeid = 2 THEN 'CHAMADO' WHEN OLD.visittypeid = 3 THEN 'CONTRATO'END, CASE WHEN NEW.visittypeid = 0 THEN 'LEVANTAMENTO' WHEN NEW.visittypeid = 1 THEN 'PREVENTIVA' WHEN NEW.visittypeid = 2 THEN 'CHAMADO' WHEN NEW.visittypeid = 3 THEN 'CONTRATO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.customerid <> NEW.customerid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Cliente', CONCAT(OLD.customerid, ' - ', (SELECT person.name FROM person WHERE person.id = OLD.customerid)), CONCAT(NEW.customerid, ' - ', (SELECT person.name FROM person WHERE person.id = NEW.customerid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.personcompressorid <> NEW.personcompressorid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Compressor', CONCAT(OLD.personcompressorid, ' - ', (SELECT compressor.name FROM personcompressor LEFT JOIN compressor ON compressor.id = personcompressor.compressorid WHERE personcompressor.id = OLD.personcompressorid)), CONCAT(NEW.personcompressorid, ' - ', (SELECT compressor.name FROM personcompressor LEFT JOIN compressor ON compressor.id = personcompressor.compressorid WHERE personcompressor.id = NEW.personcompressorid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.instructions, '') <> IFNULL(NEW.instructions, '') THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Instruções', OLD.instructions, NEW.instructions, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$

CREATE TRIGGER `visitscheduledelete` AFTER DELETE ON `visitschedule` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 22, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DELIMITER ;


DROP TABLE userprivilege;

DROP TABLE userprivilegepreset;

DROP TABLE privilegepreset;

CREATE TABLE userprivilege (
	id INT NOT NULL AUTO_INCREMENT,
    creation DATE NOT NULL,
    granteduserid INT NOT NULL,
    routineid INT NOT NULL,
    routinename TEXT NOT NULL,
    privilegelevelid INT NOT NULL,
    userid INT NOT NULL,
	PRIMARY KEY(id),
    FOREIGN KEY (granteduserid) REFERENCES user(id) ON DELETE CASCADE,
    FOREIGN KEY (userid) REFERENCES user(id) ON DELETE RESTRICT
);

DELIMITER $$
USE `manager`$$
CREATE TRIGGER `userprivilegeinsert` AFTER INSERT ON `userprivilege` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1, NEW.granteduserid, CONCAT('Permissão: ', NEW.routinename), CASE WHEN NEW.privilegelevelid = 0 THEN 'Acesso Negado' WHEN NEW.privilegelevelid = 1 THEN 'Escrita Negada' WHEN NEW.privilegelevelid = 2 THEN 'Deleção Negada' END, CASE WHEN NEW.privilegelevelid = 0 THEN 'Acesso Permitido' WHEN NEW.privilegelevelid = 1 THEN 'Escrita Permitida' WHEN NEW.privilegelevelid = 2 THEN 'Deleção Permitida' END ,NOW(), CONCAT(NEW.userid, ' - ', (SELECT username FROM user WHERE id = NEW.userid)));
END$$

CREATE TRIGGER `userprivilegedelete` AFTER DELETE ON `userprivilege` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1, OLD.granteduserid, CONCAT('Permissão: ', OLD.routinename), CASE WHEN OLD.privilegelevelid = 0 THEN 'Acesso Permitido' WHEN OLD.privilegelevelid = 1 THEN 'Escrita Permitida' WHEN OLD.privilegelevelid = 2 THEN 'Deleção Permitida' END, CASE WHEN OLD.privilegelevelid = 0 THEN 'Acesso Negado' WHEN OLD.privilegelevelid = 1 THEN 'Escrita Negada' WHEN OLD.privilegelevelid = 2 THEN 'Deleção Negada' END ,NOW(), CONCAT(OLD.userid, ' - ', (SELECT username FROM user WHERE id = OLD.userid)));
END$$
DELIMITER ;

INSERT INTO userprivilege VALUES (NULL, CURDATE(), 1, 1, 'Usuário', 0, 1);
INSERT INTO userprivilege VALUES (NULL, CURDATE(), 1, 1, 'Usuário', 1, 1);
INSERT INTO userprivilege VALUES (NULL, CURDATE(), 1, 1, 'Usuário', 2, 1);

CREATE TABLE privilegepreset (
	id INT NOT NULL AUTO_INCREMENT,
    creation DATE NOT NULL,
    statusid INT NOT NULL,
    name VARCHAR(255) UNIQUE NOT NULL,
    userid INT NOT NULL,
	PRIMARY KEY(id),
    FOREIGN KEY (userid) REFERENCES user(id) ON DELETE RESTRICT
);

DELIMITER $$
USE `manager`$$
CREATE TRIGGER `privilegepresetinsert` AFTER INSERT ON `privilegepreset` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 14, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$

CREATE TRIGGER `privilegepresetupdate` AFTER UPDATE ON `privilegepreset` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 14, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'PENDENTE' WHEN OLD.statusid = 1 THEN 'INICIADA' WHEN OLD.statusid = 2 THEN 'FINALIZADA' WHEN OLD.statusid = 3 THEN 'CANCELADA'END, CASE WHEN NEW.statusid = 0 THEN 'PENDENTE' WHEN NEW.statusid = 1 THEN 'INICIADA' WHEN NEW.statusid = 2 THEN 'FINALIZADA' WHEN NEW.statusid = 3 THEN 'CANCELADA' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.name <> NEW.name THEN INSERT INTO log VALUES (NULL, 14, NEW.id, 'Nome', OLD.name, NEW.name, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$

CREATE TRIGGER `privilegepresetdelete` AFTER DELETE ON `privilegepreset` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 14, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DELIMITER ;

CREATE TABLE privilegepresetprivilege (
	id INT NOT NULL AUTO_INCREMENT,
    privilegepresetid INT NOT NULL,
    creation DATE NOT NULL,
    routineid INT NOT NULL,
	routinename LONGTEXT NOT NULL,
    privilegelevelid INT NOT NULL,
    userid INT NOT NULL,
	PRIMARY KEY(id),
    FOREIGN KEY (privilegepresetid) REFERENCES privilegepreset(id) ON DELETE CASCADE,
    FOREIGN KEY (userid) REFERENCES user(id) ON DELETE RESTRICT
);

DELIMITER $$
USE `manager`$$
CREATE TRIGGER `privilegepresetprivilegeinsert` AFTER INSERT ON `privilegepresetprivilege` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 14, NEW.privilegepresetid, CONCAT('Permissão: ', NEW.routinename), CASE WHEN NEW.privilegelevelid = 0 THEN 'Acesso Negado' WHEN NEW.privilegelevelid = 1 THEN 'Escrita Negada' WHEN NEW.privilegelevelid = 2 THEN 'Deleção Negada' END, CASE WHEN NEW.privilegelevelid = 0 THEN 'Acesso Permitido' WHEN NEW.privilegelevelid = 1 THEN 'Escrita Permitida' WHEN NEW.privilegelevelid = 2 THEN 'Deleção Permitida' END ,NOW(), CONCAT(NEW.userid, ' - ', (SELECT username FROM user WHERE id = NEW.userid)));
END$$

CREATE TRIGGER `privilegepresetprivilegedelete` AFTER DELETE ON `privilegepresetprivilege` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 14, OLD.privilegepresetid, CONCAT('Permissão: ', OLD.routinename), CASE WHEN OLD.privilegelevelid = 0 THEN 'Acesso Permitido' WHEN OLD.privilegelevelid = 1 THEN 'Escrita Permitida' WHEN OLD.privilegelevelid = 2 THEN 'Deleção Permitida' END, CASE WHEN OLD.privilegelevelid = 0 THEN 'Acesso Negado' WHEN OLD.privilegelevelid = 1 THEN 'Escrita Negada' WHEN OLD.privilegelevelid = 2 THEN 'Deleção Negada' END ,NOW(), CONCAT(OLD.userid, ' - ', (SELECT username FROM user WHERE id = OLD.userid)));
END$$
DELIMITER ;

ALTER TABLE `manager`.`evaluation` 
ADD COLUMN `needproposalid` INT NOT NULL AFTER `evaluationtypeid`;
UPDATE evaluation SET needproposalid = 1;

ALTER TABLE `manager`.`evaluation` 
ADD COLUMN `hasrepairid` INT NOT NULL AFTER `needproposalid`;
UPDATE evaluation SET hasrepairid = 1;


ALTER TABLE `manager`.`evaluation` 
CHANGE COLUMN `evaluationtypeid` `calltypeid` INT NOT NULL ;

DROP TRIGGER IF EXISTS `manager`.`evaluationupdate`;

DELIMITER $$
USE `manager`$$
CREATE DEFINER=`root`@`localhost` TRIGGER `evaluationupdate` AFTER UPDATE ON `evaluation` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'DESAPROVADA' WHEN OLD.statusid = 1 THEN 'APROVADA' WHEN OLD.statusid = 2 THEN 'REJEITADA' WHEN OLD.statusid = 3 THEN 'REVISADA'END, CASE WHEN NEW.statusid = 0 THEN 'DESAPROVADA' WHEN NEW.statusid = 1 THEN 'APROVADA' WHEN NEW.statusid = 2 THEN 'REJEITADA' WHEN NEW.statusid = 3 THEN 'REVISADA' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.calltypeid <> NEW.calltypeid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Tipo de Chamado', CASE WHEN OLD.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN OLD.calltypeid = 1 THEN 'PREVENTIVA' WHEN OLD.calltypeid = 2 THEN 'CHAMADO' WHEN OLD.calltypeid = 3 THEN 'CONTRATO' END, CASE WHEN NEW.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN NEW.calltypeid = 1 THEN 'PREVENTIVA' WHEN NEW.calltypeid = 2 THEN 'CHAMADO' WHEN NEW.calltypeid = 3 THEN 'CONTRATO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.needproposalid <> NEW.needproposalid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Proposta Necessária', CASE WHEN OLD.needproposalid = 0 THEN 'SIM' WHEN OLD.needproposalid = 1 THEN 'NÃO' END, CASE WHEN NEW.needproposalid = 0 THEN 'SIM' WHEN NEW.needproposalid = 1 THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.hasrepairid <> NEW.hasrepairid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Houve Reparo', CASE WHEN OLD.hasrepairid = 0 THEN 'SIM' WHEN OLD.hasrepairid = 1 THEN 'NÃO' END, CASE WHEN NEW.hasrepairid = 0 THEN 'SIM' WHEN NEW.hasrepairid = 1 THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
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
IF IFNULL(OLD.documentname, '') <> IFNULL(NEW.documentname, '') THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Documento', NULL, 'Alterado', NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.signaturename, '') <> IFNULL(NEW.signaturename, '') THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Assinatura', NULL, 'Alterado', NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;
