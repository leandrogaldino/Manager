/*Como a cryptokey foi alterada, a senha de todos os usuarios deve ser resetada
/*Como a cryptokey foi alterada, a senha de todos os e-mails cadastradosuser
/*No caixa reicol comercio no mes 02/2024 tem um registro do expresso vedações que está sem responsavel, colocar reicol
/*No caixa reicol comercio no mes 08/2023 tem um registro da di napoli que está sem responsavel, colocar reicol
/*No caixa reicol comercio no mes 08/2023 tem um registro da di napoli que está sem responsavel, colocar reicol
/*No caixa aberto no mes 03/2024 tem um registro do almoço leandro que está sem responsavel, colocar leandro
/*Tem alguma avaliação que está com ano muito errado
/*Deletar UserPrivilege e UserPriuvilegePreset, PrivilegePreset  e PrivilegePresetPrivilege*/
ALTER TABLE personcompressorpart ADD COLUMN partbindid INT NOT NULL AFTER statusid;
ALTER TABLE `manager`.`agentevent` CHANGE COLUMN `description` `description` TEXT NULL DEFAULT NULL;
ALTER TABLE `manager`.`evaluation` ADD COLUMN `signaturename` VARCHAR(255) NULL DEFAULT NULL AFTER `documentname`;
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
ALTER TABLE `manager`.`visitschedule` DROP FOREIGN KEY `visitschedule_ibfk_4`;
ALTER TABLE `manager`.`visitschedule` DROP COLUMN `parentid`, DROP INDEX `parentid`;
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
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`evaluation` ADD COLUMN `needproposalid` INT NOT NULL AFTER `evaluationtypeid`;
UPDATE evaluation SET needproposalid = 1;
ALTER TABLE `manager`.`evaluation` ADD COLUMN `hasrepairid` INT NOT NULL AFTER `needproposalid`;
UPDATE evaluation SET hasrepairid = 1;
SET SQL_SAFE_UPDATES = 1;
ALTER TABLE `manager`.`evaluation` CHANGE COLUMN `evaluationtypeid` `calltypeid` INT NOT NULL ;
ALTER TABLE `manager`.`visitschedule` CHANGE COLUMN `visittypeid` `calltypeid` INT NOT NULL ;
ALTER TABLE `manager`.`visitschedule` ADD COLUMN `evaluationid` INT NULL DEFAULT NULL AFTER `lastupdate`;
CREATE TABLE `evaluationreplacedpart` (
  `id` int NOT NULL AUTO_INCREMENT,
  `evaluationid` int NOT NULL,
  `creation` date NOT NULL,
  `itemname` varchar(255) DEFAULT NULL,
  `productid` int DEFAULT NULL,
  `quantity` decimal(10,2) NOT NULL,
  `userid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `evaluationid` (`evaluationid`),
  KEY `productid` (`productid`),
  KEY `userid` (`userid`),
  CONSTRAINT `evaluationreplacedpart_product` FOREIGN KEY (`productid`) REFERENCES `product` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `evaluationreplacedpart_evaluation` FOREIGN KEY (`evaluationid`) REFERENCES `evaluation` (`id`) ON DELETE CASCADE,
  CONSTRAINT `evaluationreplacedpart_user` FOREIGN KEY (`userid`) REFERENCES `user` (`id`) ON DELETE RESTRICT
);
CREATE TABLE service (
	id INT NOT NULL AUTO_INCREMENT,
    creation DATE NOT NULL,
    statusid INT NOT NULL,
    name VARCHAR(255) NOT NULL,
    note LONGTEXT,
    userid INT NOT NULL,
	PRIMARY KEY(id),
    FOREIGN KEY (userid) REFERENCES user(id) ON DELETE RESTRICT
);
CREATE TABLE servicecomplement (
	id INT NOT NULL AUTO_INCREMENT,
	creation DATE NOT NULL,
    serviceid INT NOT NULL,
    complement VARCHAR(255) NOT NULL,
    userid INT NOT NULL,
	PRIMARY KEY(id),
    FOREIGN KEY (serviceid) REFERENCES service(id) ON DELETE CASCADE,
	FOREIGN KEY (userid) REFERENCES user(id) ON DELETE RESTRICT
);
DROP TABLE `manager`.`productprice`;
DROP TABLE `manager`.`productpricetable`;

CREATE TABLE pricetable (
	id INT NOT NULL AUTO_INCREMENT,
    pricetabletypeid INT NOT NULL,
    creation DATE NOT NULL,
    statusid INT NOT NULL,
    name VARCHAR(255) NOT NULL,
	PRIMARY KEY(id),
    userid INT NOT NULL,
	FOREIGN KEY (userid) REFERENCES user(id) ON DELETE RESTRICT
);
CREATE TABLE pricetableitem (
	id INT NOT NULL AUTO_INCREMENT,
    pricetableid INT NOT NULL,
	creation DATE NOT NULL,
	productid INT DEFAULT NULL,
	serviceid INT DEFAULT NULL,
	price DECIMAL(10,2) NOT NULL,
	userid INT NOT NULL,
	PRIMARY KEY(id),
    FOREIGN KEY (pricetableid) REFERENCES pricetable(id) ON DELETE CASCADE,
	FOREIGN KEY (userid) REFERENCES user(id) ON DELETE RESTRICT,
	FOREIGN KEY (productid) REFERENCES product(id) ON DELETE RESTRICT,
	FOREIGN KEY (serviceid) REFERENCES service(id) ON DELETE RESTRICT,
	UNIQUE (pricetableid, productid),
	UNIQUE (pricetableid, serviceid)
);
CREATE TABLE `servicecode` (
  `id` int NOT NULL AUTO_INCREMENT,
  `serviceid` int NOT NULL,
  `creation` date NOT NULL,
  `name` varchar(20) NOT NULL,
  `code` varchar(20) NOT NULL,
  `userid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `serviceid` (`serviceid`),
  KEY `userid` (`userid`),
  CONSTRAINT `servicecode_service` FOREIGN KEY (`serviceid`) REFERENCES `service` (`id`) ON DELETE CASCADE,
  CONSTRAINT `servicecode_user` FOREIGN KEY (`userid`) REFERENCES `user` (`id`) ON DELETE RESTRICT
);

DELIMITER $$
DROP TRIGGER IF EXISTS `manager`.`personcompressorpartupdate`$$
CREATE TRIGGER `personcompressorpartupdate` AFTER UPDATE ON `personcompressorpart` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.partbindid <> NEW.partbindid THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Vínculo', CASE WHEN OLD.partbindid = 0 THEN 'NENHUM' WHEN OLD.partbindid = 1 THEN 'FILTRO DE AR' WHEN OLD.partbindid = 2 THEN 'FILTRO DE OLEO' WHEN OLD.partbindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN OLD.partbindid = 4 THEN 'OLEO' WHEN OLD.partbindid = 5 THEN 'COALESCENTE' END, CASE WHEN NEW.partbindid = 0 THEN 'NENHUM' WHEN NEW.partbindid = 1 THEN 'FILTRO DE AR' WHEN NEW.partbindid = 2 THEN 'FILTRO DE OLEO' WHEN NEW.partbindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN NEW.partbindid = 4 THEN 'OLEO' WHEN NEW.partbindid = 5 THEN 'COALESCENTE' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.itemname, OLD.productid) <> IFNULL(NEW.itemname, NEW.productid) THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Item', IFNULL(OLD.itemname, (SELECT CONCAT(product.id, ' - ', product.name) FROM product WHERE product.id = OLD.productid)), IFNULL(NEW.itemname, (SELECT CONCAT(product.id, ' - ', product.name) FROM product WHERE product.id = NEW.productid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.quantity <> NEW.quantity THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Qtd.', FORMAT(OLD.quantity, 2, 'pt_BR'), FORMAT(NEW.quantity, 2, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.capacity <> NEW.capacity THEN INSERT INTO log VALUES (NULL, CASE WHEN old.parttypeid = 0 THEN 204 WHEN old.parttypeid = 1 THEN 205 END, NEW.id, 'Cap.', FORMAT(OLD.capacity, 0, 'pt_BR'), FORMAT(NEW.capacity, 0, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DROP TRIGGER IF EXISTS `manager`.`userprivilegeinsert`$$
CREATE TRIGGER `userprivilegeinsert` AFTER INSERT ON `userprivilege` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1, NEW.granteduserid, CONCAT('Permissão: ', NEW.routinename), CASE WHEN NEW.privilegelevelid = 0 THEN 'Acesso Negado' WHEN NEW.privilegelevelid = 1 THEN 'Escrita Negada' WHEN NEW.privilegelevelid = 2 THEN 'Deleção Negada' END, CASE WHEN NEW.privilegelevelid = 0 THEN 'Acesso Permitido' WHEN NEW.privilegelevelid = 1 THEN 'Escrita Permitida' WHEN NEW.privilegelevelid = 2 THEN 'Deleção Permitida' END ,NOW(), CONCAT(NEW.userid, ' - ', (SELECT username FROM user WHERE id = NEW.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`userprivilegedelete`$$
CREATE TRIGGER `userprivilegedelete` AFTER DELETE ON `userprivilege` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1, OLD.granteduserid, CONCAT('Permissão: ', OLD.routinename), CASE WHEN OLD.privilegelevelid = 0 THEN 'Acesso Permitido' WHEN OLD.privilegelevelid = 1 THEN 'Escrita Permitida' WHEN OLD.privilegelevelid = 2 THEN 'Deleção Permitida' END, CASE WHEN OLD.privilegelevelid = 0 THEN 'Acesso Negado' WHEN OLD.privilegelevelid = 1 THEN 'Escrita Negada' WHEN OLD.privilegelevelid = 2 THEN 'Deleção Negada' END ,NOW(), CONCAT(OLD.userid, ' - ', (SELECT username FROM user WHERE id = OLD.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`evaluationupdate`$$
CREATE TRIGGER `evaluationupdate` AFTER UPDATE ON `evaluation` FOR EACH ROW BEGIN
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
DROP TRIGGER IF EXISTS `manager`.`visitscheduleinsert`$$
CREATE TRIGGER `visitscheduleinsert` AFTER INSERT ON `visitschedule` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 22, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`visitscheduledelete`$$
CREATE TRIGGER `visitscheduledelete` AFTER DELETE ON `visitschedule` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 22, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`visitscheduleupdate`$$
CREATE TRIGGER `visitscheduleupdate` AFTER UPDATE ON `visitschedule` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'PENDENTE' WHEN OLD.statusid = 1 THEN 'FINALIZADO' WHEN OLD.statusid = 2 THEN 'CANCELADO' END, CASE WHEN NEW.statusid = 0 THEN 'PENDENTE' WHEN NEW.statusid = 1 THEN 'FINALIZADO' WHEN NEW.statusid = 2 THEN 'CANCELADO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.visitdate <> NEW.visitdate THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Data da Visita', OLD.visitdate, NEW.visitdate, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.calltypeid <> NEW.calltypeid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Tipo de Chamado', CASE WHEN OLD.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN OLD.calltypeid = 1 THEN 'PREVENTIVA' WHEN OLD.calltypeid = 2 THEN 'CHAMADO' WHEN OLD.calltypeid = 3 THEN 'CONTRATO'END, CASE WHEN NEW.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN NEW.calltypeid = 1 THEN 'PREVENTIVA' WHEN NEW.calltypeid = 2 THEN 'CHAMADO' WHEN NEW.calltypeid = 3 THEN 'CONTRATO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.customerid <> NEW.customerid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Cliente', CONCAT(OLD.customerid, ' - ', (SELECT person.name FROM person WHERE person.id = OLD.customerid)), CONCAT(NEW.customerid, ' - ', (SELECT person.name FROM person WHERE person.id = NEW.customerid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.personcompressorid <> NEW.personcompressorid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Compressor', CONCAT(OLD.personcompressorid, ' - ', (SELECT compressor.name FROM personcompressor LEFT JOIN compressor ON compressor.id = personcompressor.compressorid WHERE personcompressor.id = OLD.personcompressorid)), CONCAT(NEW.personcompressorid, ' - ', (SELECT compressor.name FROM personcompressor LEFT JOIN compressor ON compressor.id = personcompressor.compressorid WHERE personcompressor.id = NEW.personcompressorid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.instructions, '') <> IFNULL(NEW.instructions, '') THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Instruções', OLD.instructions, NEW.instructions, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DROP TRIGGER IF EXISTS `manager`.`evaluationreplacedpartinsert`$$
CREATE TRIGGER `evaluationreplacedpartinsert` AFTER INSERT ON `evaluationreplacedpart` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1312, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`evaluationreplacedpartdelete`$$
CREATE TRIGGER `evaluationreplacedpartdelete` AFTER DELETE ON `evaluationreplacedpart` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1312, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ', (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`evaluationreplacedpartupdate`$$
CREATE TRIGGER `evaluationreplacedpartupdate` AFTER UPDATE ON `evaluationreplacedpart` FOR EACH ROW BEGIN
IF IFNULL(OLD.itemname, OLD.productid) <> IFNULL(NEW.itemname, NEW.productid) THEN INSERT INTO log VALUES (NULL, 1312, NEW.id, 'Item', IFNULL(OLD.itemname, (SELECT CONCAT(product.id, ' - ', product.name) FROM product WHERE product.id = OLD.productid)), IFNULL(NEW.itemname, (SELECT CONCAT(product.id, ' - ', product.name) FROM product WHERE product.id = NEW.productid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.quantity <> NEW.quantity THEN INSERT INTO log VALUES (NULL, 1312, NEW.id, 'Quantidade', FORMAT(OLD.quantity, 2, 'pt_BR'), FORMAT(NEW.quantity, 2, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DROP TRIGGER IF EXISTS `manager`.`serviceinsert` $$
CREATE TRIGGER `serviceinsert` AFTER INSERT ON `service` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 23, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`servicedelete` $$
CREATE TRIGGER `servicedelete` AFTER DELETE ON `service` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 23, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`serviceupdate` $$
CREATE TRIGGER `serviceupdate` AFTER UPDATE ON `service` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 23, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.name <> NEW.name THEN INSERT INTO log VALUES (NULL, 23, NEW.id, 'Nome', OLD.name, NEW.name, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.note, '') <> IFNULL(NEW.note, '') THEN INSERT INTO log VALUES (NULL, 23, NEW.id, 'Observação', OLD.note, NEW.note, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DROP TRIGGER IF EXISTS `manager`.`servicecomplementinsert` $$
CREATE TRIGGER `servicecomplementinsert` AFTER INSERT ON `servicecomplement` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 2301, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`servicecomplementdelete` $$
CREATE TRIGGER `servicecomplementdelete` AFTER DELETE ON `servicecomplement` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 2301, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`servicecomplementupdate` $$
CREATE TRIGGER `servicecomplementupdate` AFTER UPDATE ON `servicecomplement` FOR EACH ROW BEGIN
IF OLD.complement <> NEW.complement THEN INSERT INTO log VALUES (NULL, 2301, NEW.id, 'Complemento', OLD.complement, NEW.complement, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DROP TRIGGER IF EXISTS `manager`.`pricetableinsert`$$
CREATE TRIGGER `pricetableinsert` AFTER INSERT ON `pricetable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 8, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`pricetabledelete`$$
CREATE TRIGGER `pricetabledelete` AFTER DELETE ON `pricetable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 8, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`pricetableupdate`$$
CREATE TRIGGER `pricetableupdate` AFTER UPDATE ON `pricetable` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 8, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.name <> NEW.name THEN INSERT INTO log VALUES (NULL, 8, NEW.id, 'Nome', OLD.name, NEW.name, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DROP TRIGGER IF EXISTS `manager`.`pricetableiteminsert`$$
CREATE TRIGGER `pricetableiteminsert` AFTER INSERT ON `pricetableitem` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 801, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`pricetableitemdelete`$$
CREATE TRIGGER `pricetableitemdelete` AFTER DELETE ON `pricetableitem` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 801, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`pricetableitemupdate`$$
CREATE TRIGGER `pricetableitemupdate` AFTER UPDATE ON `pricetableitem` FOR EACH ROW BEGIN
IF (
    (OLD.productid IS NOT NULL AND NEW.productid IS NULL AND OLD.serviceid IS NULL AND NEW.serviceid IS NOT NULL) OR
    (OLD.serviceid IS NOT NULL AND NEW.serviceid IS NULL AND OLD.productid IS NULL AND NEW.productid IS NOT NULL) OR
    (OLD.productid <> NEW.productid) OR (OLD.serviceid <> NEW.serviceid)
) THEN
	INSERT INTO log VALUES (
		NULL,
        801,
        NEW.id,
        'Produto/Serviço', 
        CASE
			WHEN OLD.productid IS NOT NULL
				THEN (SELECT CONCAT(product.id, ' - ', product.name) FROM product WHERE product.id = OLD.productid)
			WHEN OLD.serviceid IS NOT NULL
				THEN (SELECT CONCAT(service.id, ' - ', service.name) FROM service WHERE service.id = OLD.serviceid)
		END,
        CASE
			WHEN NEW.productid IS NOT NULL
				THEN (SELECT CONCAT(product.id, ' - ', product.name) FROM product WHERE product.id = NEW.productid)
			WHEN NEW.serviceid IS NOT NULL
				THEN (SELECT CONCAT(service.id, ' - ', service.name) FROM service WHERE service.id = NEW.serviceid)
		END,
        NOW(),
        CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END IF;
IF OLD.price <> NEW.price THEN INSERT INTO log VALUES (NULL, 801, NEW.id, 'Preço', FORMAT(OLD.price, 2, 'pt_BR'), FORMAT(NEW.price, 2, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$

CREATE TRIGGER `servicecodeinsert` AFTER INSERT ON `servicecode` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 2303, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
CREATE TRIGGER `servicecodedelete` AFTER DELETE ON `servicecode` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 2303, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
CREATE TRIGGER `servicecodeupdate` AFTER UPDATE ON `servicecode` FOR EACH ROW BEGIN
IF OLD.name <> NEW.name THEN INSERT INTO log VALUES (NULL, 2303, NEW.id, 'Nome', OLD.name, NEW.name, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.code <> NEW.code THEN INSERT INTO log VALUES (NULL, 2303, NEW.id, 'Código', OLD.code, NEW.code, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;

INSERT INTO userprivilege VALUES (NULL, CURDATE(), 1, 1, 'Usuário', 0, 1);
INSERT INTO userprivilege VALUES (NULL, CURDATE(), 1, 1, 'Usuário', 1, 1);
INSERT INTO userprivilege VALUES (NULL, CURDATE(), 1, 1, 'Usuário', 2, 1);
INSERT INTO pricetable VALUES (
	NULL,
    1,
	DATE(NOW()),
    0,
    'CUSTO BRUTO',
    1
);
INSERT INTO manager.pricetableitem (
    id,
    pricetableid,
    creation,
    productid,
    serviceid,
    price,
    userid
)
SELECT
    NULL, 
    1,                 
    DATE(NOW()),           
    p.id,               
    NULL,   
    0,
    1
FROM product p;
INSERT INTO pricetable VALUES (
	NULL,
    1,
	DATE(NOW()),
    0,
    'CUSTO LÍQUIDO',
    1
);
INSERT INTO manager.pricetableitem (
    id,
    pricetableid,
    creation,
    productid,
    serviceid,
    price,
    userid
)
SELECT
    NULL, 
    2,                 
    DATE(NOW()),           
    p.id,               
    NULL,   
    0,
    1
FROM product p;
INSERT INTO pricetable VALUES (
	NULL,
    1,
	DATE(NOW()),
    0,
    'CUSTO MÉDIO',
    1
);
INSERT INTO manager.pricetableitem (
    id,
    pricetableid,
    creation,
    productid,
    serviceid,
    price,
    userid
)
SELECT
    NULL, 
    3,                 
    DATE(NOW()),           
    p.id,               
    NULL,   
    0,
    1
FROM product p;
INSERT INTO pricetable VALUES (
	NULL,
    1,
	DATE(NOW()),
    0,
    'PREÇO MÍNIMO',
    1
);
INSERT INTO manager.pricetableitem (
    id,
    pricetableid,
    creation,
    productid,
    serviceid,
    price,
    userid
)
SELECT
    NULL, 
    4,                 
    DATE(NOW()),           
    p.id,               
    NULL,   
    0,
    1
FROM product p;
INSERT INTO pricetable VALUES (
	NULL,
	1,
	DATE(NOW()),
    0,
    'MENOR VENDA',
    1
);
INSERT INTO manager.pricetableitem (
    id,
    pricetableid,
    creation,
    productid,
    serviceid,
    price,
    userid
)
SELECT
    NULL, 
    5,                 
    DATE(NOW()),           
    p.id,               
    NULL,   
    0,
    1
FROM product p;
INSERT INTO pricetable VALUES (
	NULL,
    1,
	DATE(NOW()),
    0,
    'MAIOR VENDA',
    1
);
INSERT INTO manager.pricetableitem (
    id,
    pricetableid,
    creation,
    productid,
    serviceid,
    price,
    userid
)
SELECT
    NULL, 
    6,                 
    DATE(NOW()),           
    p.id,               
    NULL,   
    0,
    1
FROM product p;
INSERT INTO pricetable VALUES (
	NULL,
    1,
	DATE(NOW()),
    0,
    'ÚLTIMA COMPRA',
    1
);
INSERT INTO manager.pricetableitem (
    id,
    pricetableid,
    creation,
    productid,
    serviceid,
    price,
    userid
)
SELECT
    NULL, 
    7,                 
    DATE(NOW()),           
    p.id,               
    NULL,   
    0,
    1
FROM product p;