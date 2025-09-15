/*
CREATE USER 'root'@'%' IDENTIFIED BY '123456';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;
*/

SET SQL_SAFE_UPDATES = 0;
UPDATE USER SET PASSWORD = 'kMY08GUx41ZTR8sUAjMHdA=='; 
UPDATE USER SET requestnewpassword = 1;
SET SQL_SAFE_UPDATES = 1;

ALTER TABLE personcompressorpart ADD COLUMN partbindid INT NOT NULL AFTER statusid;

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
DROP TABLE privilegepresetprivilege;
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
CREATE TABLE `privilegepreset` (
  `id` int NOT NULL AUTO_INCREMENT,
  `creation` date NOT NULL,
  `statusid` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `userid` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`),
  KEY `userid` (`userid`),
  CONSTRAINT `privilegepreset_ibfk_1` FOREIGN KEY (`userid`) REFERENCES `user` (`id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
ALTER TABLE `manager`.`evaluation` ADD COLUMN `signaturename` VARCHAR(255) NULL AFTER `documentname`;

ALTER TABLE `manager`.`evaluation` ADD COLUMN `unitname` VARCHAR(10) NULL AFTER `hasrepairid`;
ALTER TABLE `manager`.`evaluation` ADD COLUMN `temperature` INT DEFAULT 0 AFTER `unitname`;
ALTER TABLE `manager`.`evaluation` ADD COLUMN `pressure` DECIMAL(4,1) DEFAULT 0 AFTER `temperature`;
ALTER TABLE `manager`.`evaluation` CHANGE COLUMN `evaluationnumber` `evaluationnumber` VARCHAR(20) NOT NULL ;



ALTER TABLE `manager`.`evaluation` CHANGE COLUMN `evaluationtypeid` `calltypeid` INT NOT NULL ;
ALTER TABLE `manager`.`visitschedule` CHANGE COLUMN `visittypeid` `calltypeid` INT NOT NULL ;
ALTER TABLE `manager`.`visitschedule` ADD COLUMN `evaluationid` INT NULL DEFAULT NULL AFTER `lastupdate`;

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
CREATE TABLE `servicecode` (
  `id` int NOT NULL AUTO_INCREMENT,
  `serviceid` int NOT NULL,
  `creation` date NOT NULL,
  `name` varchar(30) NOT NULL,
  `code` varchar(20) NOT NULL,
  `userid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `serviceid` (`serviceid`),
  KEY `userid` (`userid`),
  CONSTRAINT `servicecode_service` FOREIGN KEY (`serviceid`) REFERENCES `service` (`id`) ON DELETE CASCADE,
  CONSTRAINT `servicecode_user` FOREIGN KEY (`userid`) REFERENCES `user` (`id`) ON DELETE RESTRICT
);
CREATE TABLE servicepriceindicator (
	id INT NOT NULL AUTO_INCREMENT,
	creation DATE NOT NULL,
    serviceid INT NOT NULL,
    indicatorid INT NOT NULL,
	price DECIMAL(10,2) NOT NULL,
	userid INT NOT NULL,
	PRIMARY KEY (`id`),
	KEY `userid` (`userid`),
	KEY `serviceid` (`serviceid`),
	CONSTRAINT `servicepriceindicator_service` FOREIGN KEY (`serviceid`) REFERENCES `service` (`id`) ON DELETE CASCADE,
	CONSTRAINT `servicepriceindicator_user` FOREIGN KEY (`userid`) REFERENCES `user` (`id`) ON DELETE RESTRICT
);
CREATE TABLE productpriceindicator (
	id INT NOT NULL AUTO_INCREMENT,
	creation DATE NOT NULL,
    productid INT NOT NULL,
    indicatorid INT NOT NULL,
	price DECIMAL(10,2) NOT NULL,
	userid INT NOT NULL,
	PRIMARY KEY (`id`),
	KEY `userid` (`userid`),
	KEY `productid` (`productid`),
	CONSTRAINT `productpriceindicator_product` FOREIGN KEY (`productid`) REFERENCES `product` (`id`) ON DELETE CASCADE,
	CONSTRAINT `productpriceindicator_user` FOREIGN KEY (`userid`) REFERENCES `user` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `evaluationreplacedsellable` (
  `id` int NOT NULL AUTO_INCREMENT,
  `evaluationid` int NOT NULL,
  `creation` date NOT NULL,
  `productid` int DEFAULT NULL,
  `serviceid` int DEFAULT NULL,
  `quantity` decimal(10,2) NOT NULL,
  `userid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `evaluationid` (`evaluationid`),
  KEY `productid` (`productid`),
  KEY `userid` (`userid`),
  CONSTRAINT `evaluationreplacedsellable_product` FOREIGN KEY (`productid`) REFERENCES `product` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `evaluationreplacedsellable_service` FOREIGN KEY (`serviceid`) REFERENCES `service` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `evaluationreplacedsellable_evaluation` FOREIGN KEY (`evaluationid`) REFERENCES `evaluation` (`id`) ON DELETE CASCADE,
  CONSTRAINT `evaluationreplacedsellable_user` FOREIGN KEY (`userid`) REFERENCES `user` (`id`) ON DELETE RESTRICT
);
DROP TABLE `manager`.`productprice`;
DROP TABLE `manager`.`productpricetable`;
CREATE TABLE pricetable (
	id INT NOT NULL AUTO_INCREMENT,
    creation DATE NOT NULL,
    statusid INT NOT NULL,
    name VARCHAR(255) NOT NULL,
	PRIMARY KEY(id),
    userid INT NOT NULL,
	FOREIGN KEY (userid) REFERENCES user(id) ON DELETE RESTRICT
);
CREATE TABLE pricetablesellable (
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


ALTER TABLE `manager`.`compressor` 
DROP FOREIGN KEY `compressor_manufacturer`;
ALTER TABLE `manager`.`compressor` 
CHANGE COLUMN `manufacturerid` `manufacturerid` INT NULL ;
ALTER TABLE `manager`.`compressor` 
ADD CONSTRAINT `compressor_manufacturer`
  FOREIGN KEY (`manufacturerid`)
  REFERENCES `manager`.`person` (`id`)
  ON DELETE RESTRICT;


ALTER TABLE `manager`.`compressorpart` 
ADD COLUMN `serviceid` INT NULL DEFAULT NULL AFTER `productid`,
CHANGE COLUMN `parttypeid` `controltypeid` INT NOT NULL ,
DROP INDEX `compressorid` ,
ADD UNIQUE INDEX `compressorid_productid` (`compressorid` ASC, `productid` ASC) VISIBLE,
ADD UNIQUE INDEX `compressorid_serviceid` (`compressorid` ASC, `serviceid` ASC) VISIBLE, RENAME TO `manager`.`compressorsellable` ;



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

IF IFNULL(OLD.unitname, '') <> IFNULL(NEW.unitname, '') THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Unidade', OLD.unitname, NEW.unitname, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.temperature <> NEW.temperature THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Temperatura', OLD.temperature, NEW.temperature, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.pressure <> NEW.pressure THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Pressão', FORMAT(OLD.temperature, 1, 'pt_BR'), FORMAT(NEW.pressure, 1, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;


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
DROP TRIGGER IF EXISTS `manager`.`evaluationreplacedsellableinsert`$$
CREATE TRIGGER `evaluationreplacedsellableinsert` AFTER INSERT ON `evaluationreplacedsellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1312, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`evaluationreplacedsellabledelete`$$
CREATE TRIGGER `evaluationreplacedsellabledelete` AFTER DELETE ON `evaluationreplacedsellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1312, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ', (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`evaluationreplacedsellableupdate`$$
CREATE TRIGGER `evaluationreplacedsellableupdate` AFTER UPDATE ON `evaluationreplacedsellable` FOR EACH ROW BEGIN
IF (
    (OLD.productid IS NOT NULL AND NEW.productid IS NULL AND OLD.serviceid IS NULL AND NEW.serviceid IS NOT NULL) OR
    (OLD.serviceid IS NOT NULL AND NEW.serviceid IS NULL AND OLD.productid IS NULL AND NEW.productid IS NOT NULL) OR
    (OLD.productid <> NEW.productid) OR (OLD.serviceid <> NEW.serviceid)
) THEN
	INSERT INTO log VALUES (
		NULL,
        1312,
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
DROP TRIGGER IF EXISTS `manager`.`pricetablesellableinsert`$$
CREATE TRIGGER `pricetablesellableinsert` AFTER INSERT ON `pricetablesellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 801, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`pricetablesellabledelete`$$
CREATE TRIGGER `pricetablesellabledelete` AFTER DELETE ON `pricetablesellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 801, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`pricetablesellableupdate`$$
CREATE TRIGGER `pricetablesellableupdate` AFTER UPDATE ON `pricetablesellable` FOR EACH ROW BEGIN
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
DROP TRIGGER IF EXISTS `manager`.`servicecodeinsert`$$
CREATE TRIGGER `servicecodeinsert` AFTER INSERT ON `servicecode` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 2303, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`servicecodedelete`$$
CREATE TRIGGER `servicecodedelete` AFTER DELETE ON `servicecode` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 2303, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`servicecodeupdate`$$
CREATE TRIGGER `servicecodeupdate` AFTER UPDATE ON `servicecode` FOR EACH ROW BEGIN
IF OLD.name <> NEW.name THEN INSERT INTO log VALUES (NULL, 2303, NEW.id, 'Nome', OLD.name, NEW.name, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.code <> NEW.code THEN INSERT INTO log VALUES (NULL, 2303, NEW.id, 'Código', OLD.code, NEW.code, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$


DROP TRIGGER IF EXISTS `manager`.`compressorpartinsert`$$
DROP TRIGGER IF EXISTS `manager`.`compressorsellableinsert`$$
CREATE TRIGGER `compressorsellableinsert` AFTER INSERT ON `compressorsellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, CASE WHEN new.controltypeid = 0 THEN 1201 WHEN new.controltypeid = 1 THEN 1202 END, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$

DROP TRIGGER IF EXISTS `manager`.`compressorpartdelete`$$
DROP TRIGGER IF EXISTS `manager`.`compressorsellabledelete`$$
CREATE TRIGGER `compressorsellabledelete` AFTER DELETE ON `compressorsellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, CASE WHEN old.controltypeid = 0 THEN 1201 WHEN old.controltypeid = 1 THEN 1202 END, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$

DROP TRIGGER IF EXISTS `manager`.`compressorpartupdate`$$
DROP TRIGGER IF EXISTS `manager`.`compressorsellableupdate`$$
CREATE TRIGGER `compressorsellableupdate` AFTER UPDATE ON `compressorsellable` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, CASE WHEN old.controltypeid = 0 THEN 1201 WHEN old.controltypeid = 1 THEN 1202 END, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF (
    (OLD.productid IS NOT NULL AND NEW.productid IS NULL AND OLD.serviceid IS NULL AND NEW.serviceid IS NOT NULL) OR
    (OLD.serviceid IS NOT NULL AND NEW.serviceid IS NULL AND OLD.productid IS NULL AND NEW.productid IS NOT NULL) OR
    (OLD.productid <> NEW.productid) OR (OLD.serviceid <> NEW.serviceid)
) THEN
	INSERT INTO log VALUES (
		NULL,
        1201,
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
IF OLD.quantity <> NEW.quantity THEN INSERT INTO log VALUES (NULL, CASE WHEN old.controltypeid = 0 THEN 1201 WHEN old.controltypeid = 1 THEN 1202 END, NEW.id, 'Qtd.', FORMAT(OLD.quantity, 2, 'pt_BR'), FORMAT(NEW.quantity, 2, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$

DELIMITER ;


INSERT INTO `userprivilege` VALUES
	(NULL,'2025-06-15',1,22,'Agenda de Visita',0,1),
    (NULL,'2025-06-15',1,13,'Avaliação de Compressor',0,1),
    (NULL,'2025-06-15',1,22,'Agenda de Visita',1,1),
    (NULL,'2025-06-15',1,20,'Assinatura de E-Mail',0,1),
    (NULL,'2025-06-15',1,20,'Assinatura de E-Mail',1,1),
    (NULL,'2025-06-15',1,13,'Avaliação de Compressor',1,1),
    (NULL,'2025-06-15',1,11,'Caixa',0,1),
    (NULL,'2025-06-15',1,11,'Caixa',1,1),
    (NULL,'2025-06-15',1,3,'Cidade',0,1),
    (NULL,'2025-06-15',1,2,'Pessoa',0,1),
    (NULL,'2025-06-15',1,3,'Cidade',1,1),
    (NULL,'2025-06-15',1,12,'Compressor',0,1),
    (NULL,'2025-06-15',1,12,'Compressor',1,1),
    (NULL,'2025-06-15',1,21,'CRM',0,1),
    (NULL,'2025-06-15',1,21,'CRM',1,1),
    (NULL,'2025-06-15',1,17,'E-mails Enviados',0,1),
    (NULL,'2025-06-15',1,17,'E-mails Enviados',1,1),
    (NULL,'2025-06-15',1,4,'Estado',0,1),
    (NULL,'2025-06-15',1,4,'Estado',1,1),
    (NULL,'2025-06-15',1,9,'Família de Produtos',0,1),
    (NULL,'2025-06-15',1,6,'Produto',0,1),
    (NULL,'2025-06-15',1,9,'Família de Produtos',1,1),
    (NULL,'2025-06-15',1,19,'Fluxo de Caixa',0,1),
    (NULL,'2025-06-15',1,19,'Fluxo de Caixa',1,1),
    (NULL,'2025-06-15',1,19,'Fluxo de Caixa',2,1),
    (NULL,'2025-06-15',1,9,'Família de Produtos',2,1),
    (NULL,'2025-06-15',1,4,'Estado',2,1),
    (NULL,'2025-06-15',1,17,'E-mails Enviados',2,1),
    (NULL,'2025-06-15',1,21,'CRM',2,1),
    (NULL,'2025-06-15',1,12,'Compressor',2,1),
    (NULL,'2025-06-15',1,3,'Cidade',2,1),
    (NULL,'2025-06-15',1,11,'Caixa',2,1),
    (NULL,'2025-06-15',1,13,'Avaliação de Compressor',2,1),
    (NULL,'2025-06-15',1,20,'Assinatura de E-Mail',2,1),
    (NULL,'2025-06-15',1,22,'Agenda de Visita',2,1),
    (NULL,'2025-06-15',1,10,'Grupo de Produtos',0,1),
    (NULL,'2025-06-15',1,10,'Grupo de Produtos',1,1),
    (NULL,'2025-06-15',1,16,'Modelo de E-mail',0,1),
    (NULL,'2025-06-15',1,16,'Modelo de E-mail',1,1),
    (NULL,'2025-06-15',1,2,'Pessoa',1,1),
    (NULL,'2025-06-15',1,14,'Predefinição de Permissões',0,1),
    (NULL,'2025-06-15',1,1,'Usuário',0,1),
    (NULL,'2025-06-15',1,14,'Predefinição de Permissões',1,1),
    (NULL,'2025-06-15',1,6,'Produto',1,1),
    (NULL,'2025-06-15',1,15,'Requisição',0,1),
    (NULL,'2025-06-15',1,15,'Requisição',1,1),
    (NULL,'2025-06-15',1,5,'Rota',0,1),
    (NULL,'2025-06-15',1,5,'Rota',1,1),
    (NULL,'2025-06-15',1,23,'Serviço',0,1),
    (NULL,'2025-06-15',1,23,'Serviço',1,1),
    (NULL,'2025-06-15',1,23,'Serviço',2,1),
    (NULL,'2025-06-15',1,5,'Rota',2,1),
    (NULL,'2025-06-15',1,15,'Requisição',2,1),
    (NULL,'2025-06-15',1,6,'Produto',2,1),
    (NULL,'2025-06-15',1,14,'Predefinição de Permissões',2,1),
    (NULL,'2025-06-15',1,2,'Pessoa',2,1),
    (NULL,'2025-06-15',1,16,'Modelo de E-mail',2,1),
    (NULL,'2025-06-15',1,10,'Grupo de Produtos',2,1),
    (NULL,'2025-06-15',1,8,'Tabela de Preços',0,1),
    (NULL,'2025-06-15',1,8,'Tabela de Preços',1,1),
    (NULL,'2025-06-15',1,7,'Unidade de Medida',0,1),
    (NULL,'2025-06-15',1,7,'Unidade de Medida',1,1),
    (NULL,'2025-06-15',1,1,'Usuário',1,1),
    (NULL,'2025-06-15',1,1,'Usuário',2,1),
    (NULL,'2025-06-15',1,7,'Unidade de Medida',2,1),
    (NULL,'2025-06-15',1,8,'Tabela de Preços',2,1),
    (NULL,'2025-06-15',1,9902,'Acessar o histórico',0,1),
    (NULL,'2025-06-15',1,2105,'Alterar o assunto do CRM',0,1),
    (NULL,'2025-06-15',1,2103,'Alterar o cliente do CRM',0,1),
    (NULL,'2025-06-15',1,206,'Alterar o documento da Pessoa',0,1),
    (NULL,'2025-06-15',1,2104,'Alterar o responsavel do CRM',0,1),
    (NULL,'2025-06-15',1,2102,'Alterar o status do CRM para pendente',0,1),
    (NULL,'2025-06-15',1,1309,'Aprovar e rejeitar uma avaliação',0,1),
    (NULL,'2025-06-15',1,2106,'Editar um atendimento do CRM',0,1),
    (NULL,'2025-06-15',1,1310,'Criar avaliações automáticas',0,1),
    (NULL,'2025-06-15',1,9901,'Exportar as grades',0,1),
    (NULL,'2025-06-15',1,1305,'Exportar imagem do painel de compressores',0,1),
    (NULL,'2025-06-15',1,1903,'Gerar o relatório de despesas por responsável do caixa',0,1),
    (NULL,'2025-06-15',1,207,'Gerar o relatório de ficha cadastral da pessoa',0,1),
    (NULL,'2025-06-15',1,1902,'Gerar o relatório de folha de caixa',0,1),
    (NULL,'2025-06-15',1,1502,'Gerar o relatório de folha de requisição de itens',0,1),
    (NULL,'2025-06-15',1,1503,'Gerar o relatório de itens pendentes da requisição de itens',0,1),
    (NULL,'2025-06-15',1,208,'Gerar o relatório de plano de manutenção',0,1),
    (NULL,'2025-06-15',1,1301,'Gerenciamento de Avaliações',0,1),
    (NULL,'2025-06-15',1,1311,'Importar avaliações da núvem',0,1),
    (NULL,'2025-06-15',1,1304,'Painel de Compressores',0,1),
    (NULL,'2025-06-15',1,102,'Permite Resetar Senha',0,1),
    (NULL,'2025-06-15',1,1904,'Reabrir um caixa',0,1);
    
    



SET SQL_SAFE_UPDATES = 0;
INSERT INTO service VALUES (NULL, CURDATE(), 0, 'ENGRAXAMENTO', NULL, 1);
SET @idengraxamento = LAST_INSERT_ID();
INSERT INTO servicecode VALUES (NULL, 1, CURDATE(), 'Cód. da Lista de Serviços', '14.01.35', 1);
UPDATE compressorsellable SET serviceid = @idengraxamento WHERE compressorsellable.itemname = "REVITALIZACAO";

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE AR INGERSOLL', 'FILTRO DE AR INGERSOLL', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1); #209
SET @faringersoll = LAST_INSERT_ID();
UPDATE compressorsellable SET productid = @faringersoll WHERE id = 408;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE OLEO INGERSOLL', 'FILTRO DE OLEO INGERSOLL', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1); #210
SET @foleoingersoll = LAST_INSERT_ID();
UPDATE compressorsellable SET productid = @foleoingersoll WHERE id = 409;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO SEPARADOR INGERSOLL', 'FILTRO SEPARADOR INGERSOLL', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1); #211
SET @fseparadoringersoll = LAST_INSERT_ID();
UPDATE compressorsellable SET productid = @fseparadoringersoll WHERE id = 410;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'OLEO ALIMENTICIO 19L', 'OLEO ALIMENTICIO 19L', NULL, 1, 1, 7, 0, 0, 0, 0, NULL, 1); #213
SET @oleoalimenticio = LAST_INSERT_ID();
UPDATE compressorsellable SET productid = @oleoalimenticio WHERE id = 411;
UPDATE compressorsellable SET productid = @oleoalimenticio WHERE id = 434;


UPDATE compressorsellable SET productid = 34 WHERE id = 460;
UPDATE compressorsellable SET productid = 34 WHERE id = 464;



INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE AR ATLAS', 'FILTRO DE AR ATLAS', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1); #213
SET @faratlas = LAST_INSERT_ID();
UPDATE compressorsellable SET productid = @faratlas WHERE id = 431;



INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE OLEO ATLAS', 'FILTRO DE OLEO ATLAS', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1); #214
SET @foleoatlas = LAST_INSERT_ID();
UPDATE compressorsellable SET productid = @foleoatlas WHERE id = 432; #AQUI: Error Code: 1062. Duplicate entry '54-213' for key 'compressorsellable.compressorid_productid'

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO SEPARADOR ATLAS', 'FILTRO SEPARADOR ATLAS', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1); #215
SET @fseparadoratlas = LAST_INSERT_ID();
UPDATE compressorsellable SET productid = @fseparadoratlas WHERE id = 433;



INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE AR ZHEJIANG LEADWAY', 'FILTRO DE AR ZHEJIANG LEADWAY', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1); #216
SET @farchines = LAST_INSERT_ID();
UPDATE compressorsellable SET productid = @farchines WHERE id = 457;
UPDATE compressorsellable SET productid = @farchines WHERE id = 461;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE OLEO ZHEJIANG LEADWAY', 'FILTRO DE OLEO ZHEJIANG LEADWAY', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1); #217
SET @foleochines = LAST_INSERT_ID();
UPDATE compressorsellable SET productid = @foleochines WHERE id = 458;
UPDATE compressorsellable SET productid = @foleochines WHERE id = 462;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO SEPARADOR ZHEJIANG LEADWAY', 'FILTRO SEPARADOR ZHEJIANG LEADWAY', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1); #218
SET @fseparadorchines = LAST_INSERT_ID();
UPDATE compressorsellable SET productid = @fseparadorchines WHERE id = 459;
UPDATE compressorsellable SET productid = @fseparadorchines WHERE id = 463;

UPDATE compressor SET manufacturerid = NULL WHERE id = 60;
UPDATE compressor SET manufacturerid = NULL WHERE id = 61;


SET SQL_SAFE_UPDATES = 1;

/*
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
ANTES DE EXECUTAR O PROXIMO ALTER TABLE, CERTIFICAR SE NAO HA MAIS NENUM ITEM NA TABELA compressorsellable
QUE NAO TEM productid e serviceid SIMUNTANEAMENTE, USAR A itemname PARA CADASTRAR O ITEM OU SERVIÇO E ATUALIZAR
A TABELA COM O productid ou serviceid CORRESPONDENTE, UTILIZAT A QUERY ABAIXO PARA CONSULTAR.
SELECT 
compressorsellable.id,
	person.name,	
    personcompressor.personid,
    manufacturer.name,    
    compressorsellable.productid,
    compressorsellable.serviceid,
    compressor.name,
    compressorsellable.itemname
FROM
    compressorsellable
        JOIN
    compressor ON compressorsellable.compressorid = compressor.id
    JOIN personcompressor ON personcompressor.compressorid = compressor.id
    Join person ON person.id = personcompressor.personid
    Join person manufacturer ON manufacturer.id = compressor.manufacturerid
WHERE
    compressorsellable.productid IS NULL
		AND compressorsellable.serviceid IS NULL;
*/

ALTER TABLE `manager`.`compressorsellable` DROP COLUMN `itemname`;


ALTER TABLE `manager`.`compressorsellable` ADD INDEX `serviceid` (`serviceid` ASC) VISIBLE;
ALTER TABLE `manager`.`compressorsellable` ADD CONSTRAINT `compressorsellable_service`  FOREIGN KEY (`serviceid`)  REFERENCES `manager`.`service` (`id`)  ON DELETE RESTRICT  ON UPDATE RESTRICT;

UPDATE evaluationpart SET userid = 1 WHERE id = 10729;
UPDATE evaluationpart SET userid = 1 WHERE id = 10730;
UPDATE evaluationpart SET userid = 1 WHERE id = 23194;
UPDATE evaluationpart SET userid = 1 WHERE id = 23195;
UPDATE personcompressorpart SET userid = 1 WHERE id = 3960;
UPDATE personcompressorpart SET userid = 1 WHERE id = 3961;
DELETE FROM evaluationpart WHERE id = 10729;
DELETE FROM evaluationpart WHERE id = 10730;
DELETE FROM evaluationpart WHERE id = 23194;
DELETE FROM evaluationpart WHERE id = 23195;
DELETE FROM personcompressorpart where id = 3960;
DELETE FROM personcompressorpart where id = 3961;


ALTER TABLE `manager`.`personcompressorpart` 
ADD COLUMN `serviceid` INT NULL DEFAULT NULL AFTER `productid`,
CHANGE COLUMN `parttypeid` `controltypeid` INT NOT NULL ,
ADD INDEX `productid` (`productid` ASC) VISIBLE,
ADD INDEX `serviceid` (`serviceid` ASC) VISIBLE;

ALTER TABLE `manager`.`personcompressorpart` 
ADD CONSTRAINT `personcompressorpart_product`
  FOREIGN KEY (`productid`)
  REFERENCES `manager`.`product` (`id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT,
ADD CONSTRAINT `personcompressorpart_service`
  FOREIGN KEY (`serviceid`)
  REFERENCES `manager`.`service` (`id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT;  
  ALTER TABLE `manager`.`personcompressorpart` 
RENAME TO  `manager`.`personcompressorsellable` ;
ALTER TABLE `manager`.`compressorsellable` ALTER INDEX `serviceid` VISIBLE;
ALTER TABLE `manager`.`personcompressorsellable` 
DROP FOREIGN KEY `personcompressorpart_personcompressor`,
DROP FOREIGN KEY `personcompressorpart_product`,
DROP FOREIGN KEY `personcompressorpart_service`,
DROP FOREIGN KEY `personcompressorpart_user`;
ALTER TABLE `manager`.`personcompressorsellable`;
ALTER TABLE `manager`.`personcompressorsellable` ALTER INDEX `productid` VISIBLE;
ALTER TABLE `manager`.`personcompressorsellable` ALTER INDEX `serviceid` VISIBLE;
ALTER TABLE `manager`.`personcompressorsellable` 
ADD CONSTRAINT `personcompressorsellable_personcompressor`
  FOREIGN KEY (`personcompressorid`)
  REFERENCES `manager`.`personcompressor` (`id`)
  ON DELETE CASCADE,
ADD CONSTRAINT `personcompressorsellable_product`
  FOREIGN KEY (`productid`)
  REFERENCES `manager`.`product` (`id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT,
ADD CONSTRAINT `personcompressorsellable_service`
  FOREIGN KEY (`serviceid`)
  REFERENCES `manager`.`service` (`id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT,
ADD CONSTRAINT `personcompressorsellable_user`
  FOREIGN KEY (`userid`)
  REFERENCES `manager`.`user` (`id`)
  ON DELETE RESTRICT;



SET SQL_SAFE_UPDATES = 0;
UPDATE personcompressorsellable SET serviceid = @idengraxamento WHERE personcompressorsellable.itemname = "REVITALIZACAO";
UPDATE personcompressorsellable SET serviceid = @idengraxamento WHERE personcompressorsellable.itemname = "REVITALIAZACAO";
UPDATE personcompressorsellable SET serviceid = @idengraxamento WHERE personcompressorsellable.itemname = "REVITALIAZAO";
UPDATE personcompressorsellable SET productid = 67 WHERE personcompressorsellable.id = 1853;
UPDATE personcompressorsellable SET productid = 16 WHERE personcompressorsellable.id = 4274;
UPDATE personcompressorsellable SET productid = 47 WHERE personcompressorsellable.id = 3513;
UPDATE personcompressorsellable SET productid = 19 WHERE personcompressorsellable.id = 3501;
UPDATE personcompressorsellable SET productid = 49 WHERE personcompressorsellable.id = 3505;
UPDATE personcompressorsellable SET productid = 46 WHERE personcompressorsellable.id = 3504;
UPDATE personcompressorsellable SET productid = 6 WHERE personcompressorsellable.id = 3431;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'CORREIA PL1613', 'CORREIA PL1613', NULL, 1, 1, 8, 0, 0, 0, 0, NULL, 1);
UPDATE personcompressorsellable SET productid = LAST_INSERT_ID() WHERE personcompressorsellable.id = 231;

UPDATE personcompressorsellable SET productid = @faringersoll WHERE personcompressorsellable.id = 3448;
UPDATE personcompressorsellable SET productid = @faringersoll WHERE personcompressorsellable.id = 3452;
UPDATE personcompressorsellable SET productid = @faringersoll WHERE personcompressorsellable.id = 3456;

UPDATE personcompressorsellable SET productid = @foleoingersoll WHERE personcompressorsellable.id = 3449;
UPDATE personcompressorsellable SET productid = @foleoingersoll WHERE personcompressorsellable.id = 3453;
UPDATE personcompressorsellable SET productid = @foleoingersoll WHERE personcompressorsellable.id = 3457;

UPDATE personcompressorsellable SET productid = @fseparadoringersoll WHERE personcompressorsellable.id = 3450;
UPDATE personcompressorsellable SET productid = @fseparadoringersoll WHERE personcompressorsellable.id = 3454;
UPDATE personcompressorsellable SET productid = @fseparadoringersoll WHERE personcompressorsellable.id = 3458;

UPDATE personcompressorsellable SET productid = @oleoalimenticio WHERE personcompressorsellable.id = 3455;
UPDATE personcompressorsellable SET productid = @oleoalimenticio WHERE personcompressorsellable.id = 3459;


UPDATE personcompressorsellable SET productid = @faratlas WHERE personcompressorsellable.id = 423;
UPDATE personcompressorsellable SET productid = @faratlas WHERE personcompressorsellable.id = 2505;
UPDATE personcompressorsellable SET productid = @faratlas WHERE personcompressorsellable.id = 3113;
UPDATE personcompressorsellable SET productid = @faratlas WHERE personcompressorsellable.id = 2772;
UPDATE personcompressorsellable SET productid = @faratlas WHERE personcompressorsellable.id = 3828;
UPDATE personcompressorsellable SET productid = @faratlas WHERE personcompressorsellable.id = 4660;
UPDATE personcompressorsellable SET productid = @faratlas WHERE personcompressorsellable.id = 4331;
UPDATE personcompressorsellable SET productid = @faratlas WHERE personcompressorsellable.id = 4940;
UPDATE personcompressorsellable SET productid = @faratlas WHERE personcompressorsellable.id = 500;

UPDATE personcompressorsellable SET productid = @foleoatlas WHERE personcompressorsellable.id = 424;
UPDATE personcompressorsellable SET productid = @foleoatlas WHERE personcompressorsellable.id = 2506;
UPDATE personcompressorsellable SET productid = @foleoatlas WHERE personcompressorsellable.id = 3114;
UPDATE personcompressorsellable SET productid = @foleoatlas WHERE personcompressorsellable.id = 2773;
UPDATE personcompressorsellable SET productid = @foleoatlas WHERE personcompressorsellable.id = 3829;
UPDATE personcompressorsellable SET productid = @foleoatlas WHERE personcompressorsellable.id = 4661;
UPDATE personcompressorsellable SET productid = @foleoatlas WHERE personcompressorsellable.id = 4328;
UPDATE personcompressorsellable SET productid = @foleoatlas WHERE personcompressorsellable.id = 4941;
UPDATE personcompressorsellable SET productid = @foleoatlas WHERE personcompressorsellable.id = 501;


UPDATE personcompressorsellable SET productid = @fseparadoratlas WHERE personcompressorsellable.id = 4662;
UPDATE personcompressorsellable SET productid = @fseparadoratlas WHERE personcompressorsellable.id = 4329;
UPDATE personcompressorsellable SET productid = @fseparadoratlas WHERE personcompressorsellable.id = 4942;
UPDATE personcompressorsellable SET productid = @fseparadoratlas WHERE personcompressorsellable.id = 425;
UPDATE personcompressorsellable SET productid = @fseparadoratlas WHERE personcompressorsellable.id = 2507;
UPDATE personcompressorsellable SET productid = @fseparadoratlas WHERE personcompressorsellable.id = 3115;
UPDATE personcompressorsellable SET productid = @fseparadoratlas WHERE personcompressorsellable.id = 2774;
UPDATE personcompressorsellable SET productid = @fseparadoratlas WHERE personcompressorsellable.id = 3830;
UPDATE personcompressorsellable SET productid = @fseparadoratlas WHERE personcompressorsellable.id = 502;

UPDATE personcompressorsellable SET productid = 29 WHERE personcompressorsellable.id = 426;
UPDATE personcompressorsellable SET productid = 34 WHERE personcompressorsellable.id = 503;
UPDATE personcompressorsellable SET productid = 34 WHERE personcompressorsellable.id = 2775;
UPDATE personcompressorsellable SET productid = 58 WHERE personcompressorsellable.id = 2508;
UPDATE personcompressorsellable SET productid = @oleoalimenticio WHERE personcompressorsellable.id = 4330;

UPDATE personcompressorsellable SET productid = @farchines WHERE personcompressorsellable.id = 4815;
UPDATE personcompressorsellable SET productid = @farchines WHERE personcompressorsellable.id = 4811;
UPDATE personcompressorsellable SET productid = @foleochines WHERE personcompressorsellable.id = 4812;
UPDATE personcompressorsellable SET productid = @foleochines WHERE personcompressorsellable.id = 4816;
UPDATE personcompressorsellable SET productid = @fseparadorchines WHERE personcompressorsellable.id = 4817;
UPDATE personcompressorsellable SET productid = @fseparadorchines WHERE personcompressorsellable.id = 4813;

UPDATE personcompressorsellable SET productid = 34 WHERE personcompressorsellable.id = 4814;
UPDATE personcompressorsellable SET productid = 34 WHERE personcompressorsellable.id = 4818;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE AR CHICAGO', 'FILTRO DE AR CHICAGO', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
SET @farchicago = LAST_INSERT_ID();
INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE OLEO CHICAGO', 'FILTRO DE OLEO CHICAGO', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
SET @foleochicago = LAST_INSERT_ID();
INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO SEPARADOR CHICAGO', 'FILTRO SEPARADOR CHICAGO', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
SET @fseparadorchicago = LAST_INSERT_ID();

UPDATE personcompressorsellable SET productid = @farchicago WHERE personcompressorsellable.id = 496;
UPDATE personcompressorsellable SET productid = @farchicago WHERE personcompressorsellable.id = 2131;
UPDATE personcompressorsellable SET productid = @farchicago WHERE personcompressorsellable.id = 4826;

UPDATE personcompressorsellable SET productid = @foleochicago WHERE personcompressorsellable.id = 497;
UPDATE personcompressorsellable SET productid = @foleochicago WHERE personcompressorsellable.id = 2132;
UPDATE personcompressorsellable SET productid = @foleochicago WHERE personcompressorsellable.id = 4827;

UPDATE personcompressorsellable SET productid = @fseparadorchicago WHERE personcompressorsellable.id = 2133;
UPDATE personcompressorsellable SET productid = @fseparadorchicago WHERE personcompressorsellable.id = 498;
UPDATE personcompressorsellable SET productid = @fseparadorchicago WHERE personcompressorsellable.id = 4828;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'KIT REPARO CHICAGO', 'KIT REPARO CHICAGO', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
SET @kitreparochicago = LAST_INSERT_ID();
UPDATE personcompressorsellable SET productid = @kitreparochicago WHERE personcompressorsellable.id = 2135;

UPDATE personcompressorsellable SET productid = 34 WHERE personcompressorsellable.id = 499;
UPDATE personcompressorsellable SET productid = 34 WHERE personcompressorsellable.id = 4829;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'OLEO BOOSTER 4L', 'OLEO BOOSTER 4L', NULL, 1, 1, 7, 0, 0, 0, 0, NULL, 1);
SET @oleobooster = LAST_INSERT_ID();
UPDATE personcompressorsellable SET productid = @oleobooster WHERE personcompressorsellable.id = 2788;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE AR BOOSTER', 'FILTRO DE AR BOOSTER', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
SET @farbooster = LAST_INSERT_ID();
UPDATE personcompressorsellable SET productid = @farbooster WHERE personcompressorsellable.id = 2787;

UPDATE personcompressorsellable SET productid = 92 WHERE personcompressorsellable.id = 1910;
UPDATE personcompressorsellable SET productid = 92 WHERE personcompressorsellable.id = 1907;

UPDATE personcompressorsellable SET productid = 91 WHERE personcompressorsellable.id = 1911;
UPDATE personcompressorsellable SET productid = 91 WHERE personcompressorsellable.id = 1908;

UPDATE personcompressorsellable SET productid = 124 WHERE personcompressorsellable.id = 1909;

UPDATE personcompressorsellable SET productid = 127 WHERE personcompressorsellable.id = 2874;
UPDATE personcompressorsellable SET productid = 128 WHERE personcompressorsellable.id = 2875;

UPDATE personcompressorsellable SET productid = @oleoalimenticio WHERE personcompressorsellable.id = 3700;
UPDATE personcompressorsellable SET productid = @oleoalimenticio WHERE personcompressorsellable.id = 3701;

UPDATE personcompressorsellable SET productid = 34 WHERE personcompressorsellable.id = 2966;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'ELEMENTO COALESCENTE 25130 PRE', 'ELEMENTO COALESCENTE 25130 PRE', NULL, 1, 1, 6, 0, 0, 0, 0, NULL, 1);
SET @coalpre = LAST_INSERT_ID();
UPDATE personcompressorsellable SET productid = @coalpre WHERE personcompressorsellable.id = 4464;
UPDATE personcompressorsellable SET productid = @coalpre WHERE personcompressorsellable.id = 4466;
UPDATE personcompressorsellable SET productid = @coalpre WHERE personcompressorsellable.id = 4468;


INSERT INTO product VALUES (NULL, CURDATE(), 0, 'ELEMENTO COALESCENTE 25130 POS', 'ELEMENTO COALESCENTE 25130 POS', NULL, 1, 1, 6, 0, 0, 0, 0, NULL, 1);
SET @coalpos = LAST_INSERT_ID();
UPDATE personcompressorsellable SET productid = @coalpos WHERE personcompressorsellable.id = 4465;
UPDATE personcompressorsellable SET productid = @coalpos WHERE personcompressorsellable.id = 4467;

UPDATE personcompressorsellable SET productid = 44 WHERE personcompressorsellable.id = 333;
UPDATE personcompressorsellable SET productid = 44 WHERE personcompressorsellable.id = 334;
UPDATE personcompressorsellable SET productid = 44 WHERE personcompressorsellable.id = 367;


INSERT INTO product VALUES (NULL, CURDATE(), 0, 'CORREIA PL1715', 'CORREIA PL1715', NULL, 1, 1, 8, 0, 0, 0, 0, NULL, 1);
SET @correia1715 = LAST_INSERT_ID();
UPDATE personcompressorsellable SET productid = @correia1715 WHERE personcompressorsellable.id = 594;
UPDATE personcompressorsellable SET productid = @correia1715 WHERE personcompressorsellable.id = 595;
UPDATE personcompressorsellable SET productid = @correia1715 WHERE personcompressorsellable.id = 241;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE AR', 'ELEMENTO FILTRO AR 10 MICRONS LOGAN CFA 037 P -AT', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
UPDATE personcompressorsellable SET productid = LAST_INSERT_ID() WHERE personcompressorsellable.id = 2576;
INSERT INTO productprovidercode VALUES (NULL, LAST_INSERT_ID(), CURDATE(), '007.0044-4/AT', 2, 1, 1);

UPDATE personcompressorsellable SET productid = 113 WHERE personcompressorsellable.id = 2577;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO SEPARADOR', 'ELEMENTO SEPARADOR AR/OLEO 60/75CV', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
UPDATE personcompressorsellable SET productid = LAST_INSERT_ID() WHERE personcompressorsellable.id = 2578;
INSERT INTO productprovidercode VALUES (NULL, LAST_INSERT_ID(), CURDATE(), '021.0011-9', 2, 1, 1);

UPDATE personcompressorsellable SET productid = 50 WHERE personcompressorsellable.id = 2963;
UPDATE personcompressorsellable SET productid = 113 WHERE personcompressorsellable.id = 2964;
UPDATE personcompressorsellable SET productid = 75 WHERE personcompressorsellable.id = 2965;


UPDATE personcompressorsellable SET productid = 1 WHERE personcompressorsellable.id = 2870;
UPDATE personcompressorsellable SET productid = 2 WHERE personcompressorsellable.id = 2871;
UPDATE personcompressorsellable SET productid = 3 WHERE personcompressorsellable.id = 2872;

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'ELEMENTO COALESCENTE FAPS 80U', 'ELEMENTO COALESCENTE FAPS 80U', NULL, 1, 1, 6, 0, 0, 0, 0, NULL, 1);
UPDATE personcompressorsellable SET productid = LAST_INSERT_ID() WHERE personcompressorsellable.id = 3655;
INSERT INTO productprovidercode VALUES (NULL, LAST_INSERT_ID(), CURDATE(), '007.0496-0', 2, 1, 1);

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'ELEMENTO COALESCENTE FAPS 80H', 'ELEMENTO COALESCENTE FAPS 80H', NULL, 1, 1, 6, 0, 0, 0, 0, NULL, 1);
UPDATE personcompressorsellable SET productid = LAST_INSERT_ID() WHERE personcompressorsellable.id = 3656;
INSERT INTO productprovidercode VALUES (NULL, LAST_INSERT_ID(), CURDATE(), '007.0500-0', 2, 1, 1);

UPDATE personcompressorsellable SET productid = 115 WHERE personcompressorsellable.id = 2957;
UPDATE personcompressorsellable SET productid = 116 WHERE personcompressorsellable.id = 2958;
UPDATE personcompressorsellable SET productid = 15 WHERE personcompressorsellable.id = 2959;
UPDATE personcompressorsellable SET productid = 152 WHERE personcompressorsellable.id = 2960;

UPDATE personcompressorsellable SET productid = @faratlas where personcompressorsellable.id = 5009;
UPDATE personcompressorsellable SET productid = @foleoatlas where personcompressorsellable.id = 5010;
UPDATE personcompressorsellable SET productid = @fseparadoratlas where personcompressorsellable.id = 5011;
UPDATE personcompressorsellable SET productid = 29 where personcompressorsellable.id = 5012;


UPDATE personcompressorsellable SET productid = @farchicago where personcompressorsellable.id = 5035;
UPDATE personcompressorsellable SET productid = @foleochicago where personcompressorsellable.id = 5036;
UPDATE personcompressorsellable SET productid = @fseparadorchicago where personcompressorsellable.id = 5037;


SET SQL_SAFE_UPDATES = 1;


/*
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
---------------------------------------------------ATENCAO---------------------------------------------------
ANTES DE EXECUTAR O PROXIMO ALTER TABLE, CERTIFICAR SE NAO HA MAIS NENUM ITEM NA TABELA personcompressorsellable
QUE NAO TEM productid e serviceid SIMUNTANEAMENTE, USAR A itemname PARA CADASTRAR O ITEM OU SERVIÇO E ATUALIZAR
A TABELA COM O productid ou serviceid CORRESPONDENTE, UTILIZAT A QUERY ABAIXO PARA CONSULTAR.

SELECT 
	pcs.id,
    p.shortname,
    c.name,
	pcs.itemname,
    pcs.productid,
    pcs.serviceid
FROM personcompressorsellable pcs
JOIN personcompressor pc ON pc.id = pcs.personcompressorid
JOIN compressor c ON c.id = pc.compressorid
JOIN person p ON p.id = pc.personid
WHERE
    pcs.productid IS NULL AND
	pcs.serviceid IS NULL
order by  itemname;       
        
*/


#REFAZER AS TRIGGERS DO COMPRESSORSELLABLE E PERSONCOMPRESSORSELLABLE AQUI
ALTER TABLE `manager`.`personcompressorsellable` CHANGE COLUMN `partbindid` `sellablebindid` INT NOT NULL ;
DELIMITER $$
DROP TRIGGER IF EXISTS `manager`.`personcompressorpartinsert` $$
DROP TRIGGER IF EXISTS `manager`.`personcompressorsellableinsert`$$
CREATE TRIGGER `personcompressorsellableinsert` AFTER INSERT ON `personcompressorsellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, CASE WHEN new.controltypeid = 0 THEN 204 WHEN new.controltypeid = 1 THEN 205 END, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`personcompressorpartupdate`$$
DROP TRIGGER IF EXISTS `manager`.`personcompressorsellableupdate`$$
CREATE TRIGGER `personcompressorsellableupdate` AFTER UPDATE ON `personcompressorsellable` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, CASE WHEN old.controltypeid = 0 THEN 204 WHEN old.controltypeid = 1 THEN 205 END, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.sellablebindid <> NEW.sellablebindid THEN INSERT INTO log VALUES (NULL, CASE WHEN old.sellablebindid = 0 THEN 204 WHEN old.sellablebindid = 1 THEN 205 END, NEW.id, 'Vínculo', CASE WHEN OLD.sellablebindid = 0 THEN 'NENHUM' WHEN OLD.sellablebindid = 1 THEN 'FILTRO DE AR' WHEN OLD.sellablebindid = 2 THEN 'FILTRO DE OLEO' WHEN OLD.sellablebindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN OLD.sellablebindid = 4 THEN 'OLEO' WHEN OLD.sellablebindid = 5 THEN 'COALESCENTE' END, CASE WHEN NEW.sellablebindid = 0 THEN 'NENHUM' WHEN NEW.sellablebindid = 1 THEN 'FILTRO DE AR' WHEN NEW.sellablebindid = 2 THEN 'FILTRO DE OLEO' WHEN NEW.sellablebindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN NEW.sellablebindid = 4 THEN 'OLEO' WHEN NEW.sellablebindid = 5 THEN 'COALESCENTE' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF (
    (OLD.productid IS NOT NULL AND NEW.productid IS NULL AND OLD.serviceid IS NULL AND NEW.serviceid IS NOT NULL) OR
    (OLD.serviceid IS NOT NULL AND NEW.serviceid IS NULL AND OLD.productid IS NULL AND NEW.productid IS NOT NULL) OR
    (OLD.productid <> NEW.productid) OR (OLD.serviceid <> NEW.serviceid)
) THEN
	INSERT INTO log VALUES (
		NULL,
        CASE WHEN old.controltypeid = 0 THEN 204 WHEN old.controltypeid = 1 THEN 205 END,
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
IF OLD.quantity <> NEW.quantity THEN INSERT INTO log VALUES (NULL, CASE WHEN old.controltypeid = 0 THEN 204 WHEN old.controltypeid = 1 THEN 205 END, NEW.id, 'Qtd.', FORMAT(OLD.quantity, 2, 'pt_BR'), FORMAT(NEW.quantity, 2, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.capacity <> NEW.capacity THEN INSERT INTO log VALUES (NULL, CASE WHEN old.controltypeid = 0 THEN 204 WHEN old.controltypeid = 1 THEN 205 END, NEW.id, 'Cap.', FORMAT(OLD.capacity, 0, 'pt_BR'), FORMAT(NEW.capacity, 0, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DROP TRIGGER IF EXISTS `manager`.`personcompressorpartdelete` $$
DROP TRIGGER IF EXISTS `manager`.`personcompressorsellabledelete` $$
CREATE TRIGGER `personcompressorsellabledelete` AFTER DELETE ON `personcompressorsellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, CASE WHEN old.controltypeid = 0 THEN 204 WHEN old.controltypeid = 1 THEN 205 END, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DROP TRIGGER IF EXISTS `manager`.`compressorsellableupdate`$$
CREATE TRIGGER `compressorsellableupdate` AFTER UPDATE ON `compressorsellable` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, CASE WHEN old.controltypeid = 0 THEN 1201 WHEN old.controltypeid = 1 THEN 1202 END, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF (
    (OLD.productid IS NOT NULL AND NEW.productid IS NULL AND OLD.serviceid IS NULL AND NEW.serviceid IS NOT NULL) OR
    (OLD.serviceid IS NOT NULL AND NEW.serviceid IS NULL AND OLD.productid IS NULL AND NEW.productid IS NOT NULL) OR
    (OLD.productid <> NEW.productid) OR (OLD.serviceid <> NEW.serviceid)
) THEN
	INSERT INTO log VALUES (
		NULL,
        CASE WHEN old.controltypeid = 0 THEN 1201 WHEN old.controltypeid = 1 THEN 1202 END,
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
IF OLD.quantity <> NEW.quantity THEN INSERT INTO log VALUES (NULL, CASE WHEN old.controltypeid = 0 THEN 1201 WHEN old.controltypeid = 1 THEN 1202 END, NEW.id, 'Qtd.', FORMAT(OLD.quantity, 2, 'pt_BR'), FORMAT(NEW.quantity, 2, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;

UPDATE evaluationpart SET userid = 1 WHERE personcompressorpartid = 3431;
UPDATE evaluationpart SET userid = 1 WHERE personcompressorpartid = 3501;
UPDATE evaluationpart SET userid = 1 WHERE personcompressorpartid = 3504;
UPDATE evaluationpart SET userid = 1 WHERE personcompressorpartid = 3505;
DELETE FROM evaluationpart WHERE personcompressorpartid = 3431;
DELETE FROM evaluationpart WHERE personcompressorpartid = 3501;
DELETE FROM evaluationpart WHERE personcompressorpartid = 3504;
DELETE FROM evaluationpart WHERE personcompressorpartid = 3505;
UPDATE personcompressorsellable SET userid = 1 WHERE id = 3431;
UPDATE personcompressorsellable SET userid = 1 WHERE id = 3501;
UPDATE personcompressorsellable SET userid = 1 WHERE id = 3504;
UPDATE personcompressorsellable SET userid = 1 WHERE id = 3505;
DELETE FROM personcompressorsellable WHERE id = 3431;
DELETE FROM personcompressorsellable WHERE id = 3501;
DELETE FROM personcompressorsellable WHERE id = 3504;
DELETE FROM personcompressorsellable WHERE id = 3505;

ALTER TABLE `manager`.`personcompressorsellable` DROP COLUMN `itemname`;
ALTER TABLE `manager`.`personcompressorsellable` DROP FOREIGN KEY `personcompressorsellable_personcompressor`;
ALTER TABLE `manager`.`personcompressorsellable` DROP INDEX `personcompressorid` ;
ALTER TABLE `manager`.`personcompressorsellable` ADD INDEX `personcompressor` (`personcompressorid` ASC) VISIBLE;
ALTER TABLE `manager`.`personcompressorsellable` ADD CONSTRAINT `personcompressorsellable_personcompressor` FOREIGN KEY (`personcompressorid`) REFERENCES `manager`.`personcompressor` (`id`)  ON DELETE CASCADE  ON UPDATE RESTRICT;
ALTER TABLE `manager`.`personcompressorsellable` ADD UNIQUE INDEX `personcompressor_product` (`personcompressorid` ASC, `productid` ASC) VISIBLE;
ALTER TABLE `manager`.`personcompressorsellable` ALTER INDEX `productid` INVISIBLE;
ALTER TABLE `manager`.`personcompressorsellable` ADD UNIQUE INDEX `personcompressor_service` (`personcompressorid` ASC, `serviceid` ASC) VISIBLE;
ALTER TABLE `manager`.`personcompressorsellable` ALTER INDEX `serviceid` INVISIBLE;


ALTER TABLE `manager`.`evaluationpart` DROP FOREIGN KEY `evaluationpart_personcompressorpart`;
ALTER TABLE `manager`.`evaluationpart` CHANGE COLUMN `personcompressorpartid` `personcompressorsellableid` INT NOT NULL;
ALTER TABLE `manager`.`evaluationpart` ADD CONSTRAINT `evaluationpart_personcompressorsellable` FOREIGN KEY (`personcompressorsellableid`) REFERENCES `manager`.`personcompressorsellable` (`id`)  ON DELETE RESTRICT;
ALTER TABLE `manager`.`evaluationpart` RENAME TO  `manager`.`evaluationcontrolledsellable`;

DROP table config;


ALTER TABLE `manager`.`visitschedule` ADD COLUMN `scheduleddate` DATETIME NULL AFTER `statusid`;
ALTER TABLE `manager`.`visitschedule` ADD COLUMN `overridedvisitscheduleid` INT NULL DEFAULT NULL AFTER `evaluationid`;
ALTER TABLE `manager`.`visitschedule` CHANGE COLUMN `visitdate` `performeddate` DATETIME DEFAULT NULL;
ALTER TABLE `manager`.`visitschedule` ADD INDEX `visitschedile_ibfk_4_idx` (`overridedvisitscheduleid` ASC) VISIBLE;
ALTER TABLE `manager`.`visitschedule` ADD CONSTRAINT `visitschedile_ibfk_4` FOREIGN KEY (`overridedvisitscheduleid`) REFERENCES `manager`.`visitschedule` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;


ALTER TABLE `manager`.`visitschedule` ADD COLUMN `technicianid` INT NOT NULL AFTER `personcompressorid`;
ALTER TABLE `manager`.`visitschedule` ADD INDEX `visitschedile_ibfk_5_idx` (`technicianid` ASC) VISIBLE;
ALTER TABLE `manager`.`visitschedule` ADD CONSTRAINT `visitschedile_ibfk_5` FOREIGN KEY (`technicianid`) REFERENCES `manager`.`person` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

DROP TRIGGER IF EXISTS `manager`.`visitscheduleupdate`;

DELIMITER $$
CREATE TRIGGER `visitscheduleupdate` AFTER UPDATE ON `visitschedule` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'PENDENTE' WHEN OLD.statusid = 1 THEN 'FINALIZADO' WHEN OLD.statusid = 2 THEN 'CANCELADO' END, CASE WHEN NEW.statusid = 0 THEN 'PENDENTE' WHEN NEW.statusid = 1 THEN 'FINALIZADO' WHEN NEW.statusid = 2 THEN 'CANCELADO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.scheduleddate <> NEW.scheduleddate THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Data Agendada', OLD.scheduleddate, NEW.scheduleddate, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.performeddate <> NEW.performeddate THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Data Realizada', OLD.performeddate, NEW.performeddate, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.calltypeid <> NEW.calltypeid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Tipo de Chamado', CASE WHEN OLD.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN OLD.calltypeid = 1 THEN 'PREVENTIVA' WHEN OLD.calltypeid = 2 THEN 'CHAMADO' WHEN OLD.calltypeid = 3 THEN 'CONTRATO'END, CASE WHEN NEW.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN NEW.calltypeid = 1 THEN 'PREVENTIVA' WHEN NEW.calltypeid = 2 THEN 'CHAMADO' WHEN NEW.calltypeid = 3 THEN 'CONTRATO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.customerid <> NEW.customerid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Cliente', CONCAT(OLD.customerid, ' - ', (SELECT person.name FROM person WHERE person.id = OLD.customerid)), CONCAT(NEW.customerid, ' - ', (SELECT person.name FROM person WHERE person.id = NEW.customerid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.technicianid <> NEW.technicianid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Técnico', CONCAT(OLD.technicianid, ' - ', (SELECT person.name FROM person WHERE person.id = OLD.technicianid)), CONCAT(NEW.technicianid, ' - ', (SELECT person.name FROM person WHERE person.id = NEW.technicianid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.personcompressorid <> NEW.personcompressorid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Compressor', CONCAT(OLD.personcompressorid, ' - ', (SELECT compressor.name FROM personcompressor LEFT JOIN compressor ON compressor.id = personcompressor.compressorid WHERE personcompressor.id = OLD.personcompressorid)), CONCAT(NEW.personcompressorid, ' - ', (SELECT compressor.name FROM personcompressor LEFT JOIN compressor ON compressor.id = personcompressor.compressorid WHERE personcompressor.id = NEW.personcompressorid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.instructions, '') <> IFNULL(NEW.instructions, '') THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Instruções', OLD.instructions, NEW.instructions, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;


DROP procedure IF EXISTS `manager`.`UpdateUserID`;

DELIMITER $$

CREATE PROCEDURE `UpdateUserID`(
    IN tablename VARCHAR(64),
    IN userid INT,
    IN id INT
)
BEGIN
    -- Monta o SQL dinâmico, fixando a coluna 'userid'
    SET @sql = CONCAT(
        'UPDATE `', tablename, '` SET `userid` = ? WHERE `id` = ?'
    );

    -- Prepara e executa o SQL
    PREPARE stmt FROM @sql;
    SET @param1 = userid;
    SET @param2 = id;
    EXECUTE stmt USING @param1, @param2;
    DEALLOCATE PREPARE stmt;
END$$
DELIMITER ;

ALTER TABLE `manager`.`evaluationcontrolledsellable` 
DROP FOREIGN KEY `evaluationpart_evaluation`,
DROP FOREIGN KEY `evaluationpart_personcompressor`,
DROP FOREIGN KEY `evaluationpart_personcompressorsellable`,
DROP FOREIGN KEY `evaluationpart_user`;
ALTER TABLE `manager`.`evaluationcontrolledsellable`;
ALTER TABLE `manager`.`evaluationcontrolledsellable` RENAME INDEX `evaluationpart_evaluation` TO `evaluationsellable_evaluation`;
ALTER TABLE `manager`.`evaluationcontrolledsellable` ALTER INDEX `evaluationsellable_evaluation` VISIBLE;
ALTER TABLE `manager`.`evaluationcontrolledsellable` RENAME INDEX `evaluationpart_personcompressor` TO `evaluationsellable_personcompressor`;
ALTER TABLE `manager`.`evaluationcontrolledsellable` ALTER INDEX `evaluationsellable_personcompressor` VISIBLE;
ALTER TABLE `manager`.`evaluationcontrolledsellable` RENAME INDEX `evaluationpart_user` TO `evaluationsellable_user`;
ALTER TABLE `manager`.`evaluationcontrolledsellable` ALTER INDEX `evaluationsellable_user` VISIBLE;
ALTER TABLE `manager`.`evaluationcontrolledsellable` 
ADD CONSTRAINT `evaluationsellable_evaluation`
  FOREIGN KEY (`evaluationid`)
  REFERENCES `manager`.`evaluation` (`id`)
  ON DELETE CASCADE,
ADD CONSTRAINT `evaluationsellable_personcompressor`
  FOREIGN KEY (`personcompressorid`)
  REFERENCES `manager`.`personcompressor` (`id`)
  ON DELETE RESTRICT,
ADD CONSTRAINT `evaluationsellable_personcompressorsellable`
  FOREIGN KEY (`personcompressorsellableid`)
  REFERENCES `manager`.`personcompressorsellable` (`id`)
  ON DELETE RESTRICT,
ADD CONSTRAINT `evaluationsellable_user`
  FOREIGN KEY (`userid`)
  REFERENCES `manager`.`user` (`id`)
  ON DELETE RESTRICT;  
  ALTER TABLE `manager`.`compressorsellable` 
DROP FOREIGN KEY `compressorpart_compressor`,
DROP FOREIGN KEY `compressorpart_product`,
DROP FOREIGN KEY `compressorpart_user`;
ALTER TABLE `manager`.`compressorsellable` 
ADD CONSTRAINT `compressorsellable_compressor`
  FOREIGN KEY (`compressorid`)
  REFERENCES `manager`.`compressor` (`id`)
  ON DELETE CASCADE,
ADD CONSTRAINT `compressorsellable_product`
  FOREIGN KEY (`productid`)
  REFERENCES `manager`.`product` (`id`)
  ON DELETE RESTRICT,
ADD CONSTRAINT `compressorsellable_user`
  FOREIGN KEY (`userid`)
  REFERENCES `manager`.`user` (`id`)
  ON DELETE RESTRICT;
  ALTER TABLE `manager`.`compressorsellable` 
DROP FOREIGN KEY `compressorsellable_compressor`;
ALTER TABLE `manager`.`compressorsellable` 
ADD CONSTRAINT `compressorsellable_compressor`
  FOREIGN KEY (`compressorid`)
  REFERENCES `manager`.`compressor` (`id`)
  ON DELETE NO ACTION;  
  ALTER TABLE `manager`.`cityroute` 
DROP FOREIGN KEY `cityroute_city`;
ALTER TABLE `manager`.`cityroute` 
ADD CONSTRAINT `cityroute_city`
  FOREIGN KEY (`cityid`)
  REFERENCES `manager`.`city` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`useremail` 
DROP FOREIGN KEY `useremail_ofuser`;
ALTER TABLE `manager`.`useremail` 
ADD CONSTRAINT `useremail_ofuser`
  FOREIGN KEY (`ofuserid`)
  REFERENCES `manager`.`user` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`userprivilege` 
DROP FOREIGN KEY `userprivilege_ibfk_1`;
ALTER TABLE `manager`.`userprivilege` 
ADD CONSTRAINT `userprivilege_ibfk_1`
  FOREIGN KEY (`granteduserid`)
  REFERENCES `manager`.`user` (`id`)
  ON DELETE NO ACTION;


DROP TRIGGER IF EXISTS `manager`.`compressordelete`;
DROP TRIGGER IF EXISTS `manager`.`compressordeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`cashflowbeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`cashbeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`cashitembeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`compressorsellableupdate`;
DROP TRIGGER IF EXISTS `manager`.`compressorsellableinsert`;
DROP TRIGGER IF EXISTS `manager`.`compressorsellabledelete`;
DROP TRIGGER IF EXISTS `manager`.`personcompressorsellableupdate`;
DROP TRIGGER IF EXISTS `manager`.`personcompressorsellableinsert`;
DROP TRIGGER IF EXISTS `manager`.`personcompressorsellabledelete`;
DROP TRIGGER IF EXISTS `manager`.`citybeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`evaluationbeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`personbeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`personcompressorbeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`pricetablebeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`privilegepresetinsert`;
DROP TRIGGER IF EXISTS `manager`.`privilegepresetdelete`;
DROP TRIGGER IF EXISTS `manager`.`privilegepresetupdate`;
DROP TRIGGER IF EXISTS `manager`.`privilegepresetbeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`privilegepresetprivilegeinsert`;
DROP TRIGGER IF EXISTS `manager`.`privilegepresetprivilegedelete`;
DROP TRIGGER IF EXISTS `manager`.`productbeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`productpictureinsert`;
DROP TRIGGER IF EXISTS `manager`.`productpictureupdate`;
DROP TRIGGER IF EXISTS `manager`.`productpicturedelete`;
DROP TRIGGER IF EXISTS `manager`.`requestbeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`servicebeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`userbeforedelete`;
DROP TRIGGER IF EXISTS `manager`.`useremailupdate`;
DROP TRIGGER IF EXISTS `manager`.`useremailinsert`;
DROP TRIGGER IF EXISTS `manager`.`useremaildelete`;










ALTER TABLE `manager`.`cashflowauthorized` 
DROP FOREIGN KEY `cashflowauthorized_ibfk_1`;
ALTER TABLE `manager`.`cashflowauthorized` 
ADD CONSTRAINT `cashflowauthorized_ibfk_1`
  FOREIGN KEY (`cashflowid`)
  REFERENCES `manager`.`cashflow` (`id`)
  ON DELETE NO ACTION;
 ALTER TABLE `manager`.`cashitem` 
DROP FOREIGN KEY `cashitem_cash`;
ALTER TABLE `manager`.`cashitem` 
ADD CONSTRAINT `cashitem_cash`
  FOREIGN KEY (`cashid`)
  REFERENCES `manager`.`cash` (`id`)
  ON DELETE NO ACTION;
 ALTER TABLE `manager`.`evaluationtechnician` 
DROP FOREIGN KEY `evaluationtechnician_ibfk_1`;
ALTER TABLE `manager`.`evaluationtechnician` 
ADD CONSTRAINT `evaluationtechnician_ibfk_1`
  FOREIGN KEY (`evaluationid`)
  REFERENCES `manager`.`evaluation` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`evaluationcontrolledsellable` 
DROP FOREIGN KEY `evaluationsellable_evaluation`;
ALTER TABLE `manager`.`evaluationcontrolledsellable` 
ADD CONSTRAINT `evaluationsellable_evaluation`
  FOREIGN KEY (`evaluationid`)
  REFERENCES `manager`.`evaluation` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`evaluationreplacedsellable` 
DROP FOREIGN KEY `evaluationreplacedsellable_evaluation`;
ALTER TABLE `manager`.`evaluationreplacedsellable` 
ADD CONSTRAINT `evaluationreplacedsellable_evaluation`
  FOREIGN KEY (`evaluationid`)
  REFERENCES `manager`.`evaluation` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`evaluationphoto` 
DROP FOREIGN KEY `evaluationphoto_ibfk_1`;
ALTER TABLE `manager`.`evaluationphoto` 
ADD CONSTRAINT `evaluationphoto_ibfk_1`
  FOREIGN KEY (`evaluationid`)
  REFERENCES `manager`.`evaluation` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`personcompressor` 
DROP FOREIGN KEY `personcompressor_person`;
ALTER TABLE `manager`.`personcompressor` 
ADD CONSTRAINT `personcompressor_person`
  FOREIGN KEY (`personid`)
  REFERENCES `manager`.`person` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`personcompressorsellable` 
DROP FOREIGN KEY `personcompressorsellable_personcompressor`;
ALTER TABLE `manager`.`personcompressorsellable` 
ADD CONSTRAINT `personcompressorsellable_personcompressor`
  FOREIGN KEY (`personcompressorid`)
  REFERENCES `manager`.`personcompressor` (`id`)
  ON DELETE NO ACTION
  ON UPDATE RESTRICT;
ALTER TABLE `manager`.`personcontact` 
DROP FOREIGN KEY `personcontact_person`;
ALTER TABLE `manager`.`personcontact` 
ADD CONSTRAINT `personcontact_person`
  FOREIGN KEY (`personid`)
  REFERENCES `manager`.`person` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`personaddress` 
DROP FOREIGN KEY `personaddress_person`;
ALTER TABLE `manager`.`personaddress` 
ADD CONSTRAINT `personaddress_person`
  FOREIGN KEY (`personid`)
  REFERENCES `manager`.`person` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`pricetablesellable` 
DROP FOREIGN KEY `pricetablesellable_ibfk_1`;
ALTER TABLE `manager`.`pricetablesellable` 
ADD CONSTRAINT `pricetablesellable_ibfk_1`
  FOREIGN KEY (`pricetableid`)
  REFERENCES `manager`.`pricetable` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`privilegepresetprivilege` 
DROP FOREIGN KEY `privilegepresetprivilege_ibfk_1`;
ALTER TABLE `manager`.`privilegepresetprivilege` 
ADD CONSTRAINT `privilegepresetprivilege_ibfk_1`
  FOREIGN KEY (`privilegepresetid`)
  REFERENCES `manager`.`privilegepreset` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`productcode` 
DROP FOREIGN KEY `productcode_product`;
ALTER TABLE `manager`.`productcode` 
ADD CONSTRAINT `productcode_product`
  FOREIGN KEY (`productid`)
  REFERENCES `manager`.`product` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`productpicture` 
DROP FOREIGN KEY `productpicture_product`;
ALTER TABLE `manager`.`productpicture` 
ADD CONSTRAINT `productpicture_product`
  FOREIGN KEY (`productid`)
  REFERENCES `manager`.`product` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`productprovidercode` 
DROP FOREIGN KEY `productprovidercode_product`;
ALTER TABLE `manager`.`productprovidercode` 
ADD CONSTRAINT `productprovidercode_product`
  FOREIGN KEY (`productid`)
  REFERENCES `manager`.`product` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`pricetablesellable` 
DROP FOREIGN KEY `pricetablesellable_ibfk_3`,
DROP FOREIGN KEY `pricetablesellable_ibfk_4`;
ALTER TABLE `manager`.`pricetablesellable` 
ADD CONSTRAINT `pricetablesellable_ibfk_3`
  FOREIGN KEY (`productid`)
  REFERENCES `manager`.`product` (`id`)
  ON DELETE NO ACTION,
ADD CONSTRAINT `pricetablesellable_ibfk_4`
  FOREIGN KEY (`serviceid`)
  REFERENCES `manager`.`service` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`productpicture` ;
ALTER TABLE `manager`.`productpicture` RENAME INDEX `picturelocation` TO `picturename`;
ALTER TABLE `manager`.`productpicture` ALTER INDEX `picturename` VISIBLE;
ALTER TABLE `manager`.`productpicture` DROP COLUMN `caption`,DROP INDEX `caption` ;
ALTER TABLE `manager`.`requestitem` 
DROP FOREIGN KEY `requestitem_request`;
ALTER TABLE `manager`.`requestitem` 
ADD CONSTRAINT `requestitem_request`
  FOREIGN KEY (`requestid`)
  REFERENCES `manager`.`request` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`servicecode` 
DROP FOREIGN KEY `servicecode_service`;
ALTER TABLE `manager`.`servicecode` 
ADD CONSTRAINT `servicecode_service`
  FOREIGN KEY (`serviceid`)
  REFERENCES `manager`.`service` (`id`)
  ON DELETE NO ACTION;
ALTER TABLE `manager`.`servicecomplement` 
DROP FOREIGN KEY `servicecomplement_ibfk_1`;
ALTER TABLE `manager`.`servicecomplement` 
ADD CONSTRAINT `servicecomplement_ibfk_1`
  FOREIGN KEY (`serviceid`)
  REFERENCES `manager`.`service` (`id`)
  ON DELETE NO ACTION;









 

  

DELIMITER $$
CREATE TRIGGER `compressordelete` AFTER DELETE ON `compressor` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 12, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
CREATE TRIGGER `manager`.`compressordeforedelete` BEFORE DELETE ON `compressor` FOR EACH ROW
BEGIN
DELETE FROM compressorsellable WHERE compressorid = OLD.id;
END$$
CREATE TRIGGER `manager`.`cashflowbeforedelete` BEFORE DELETE ON `cashflow` FOR EACH ROW
BEGIN
DELETE FROM cashflowauthorized WHERE cashflowid = OLD.id;
END$$
CREATE TRIGGER `manager`.`cashbeforedelete` BEFORE DELETE ON `cash` FOR EACH ROW
BEGIN
DELETE FROM cashitem WHERE cashid = OLD.id;
END$$
CREATE TRIGGER `manager`.`cashitembeforedelete` BEFORE DELETE ON `cashitem` FOR EACH ROW
BEGIN
DELETE FROM cashitemresponsible WHERE cashitemid = OLD.id;
END$$
CREATE TRIGGER `compressorsellableupdate` AFTER UPDATE ON `compressorsellable` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 1201, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF (
    (OLD.productid IS NOT NULL AND NEW.productid IS NULL AND OLD.serviceid IS NULL AND NEW.serviceid IS NOT NULL) OR
    (OLD.serviceid IS NOT NULL AND NEW.serviceid IS NULL AND OLD.productid IS NULL AND NEW.productid IS NOT NULL) OR
    (OLD.productid <> NEW.productid) OR (OLD.serviceid <> NEW.serviceid)
) THEN
	INSERT INTO log VALUES (
		NULL,
        1201,
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
IF OLD.quantity <> NEW.quantity THEN INSERT INTO log VALUES (NULL, 1201, NEW.id, 'Qtd.', FORMAT(OLD.quantity, 2, 'pt_BR'), FORMAT(NEW.quantity, 2, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
CREATE TRIGGER `compressorsellableinsert` AFTER INSERT ON `compressorsellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1201, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
CREATE TRIGGER `compressorsellabledelete` AFTER DELETE ON `compressorsellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1201, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
CREATE TRIGGER `personcompressorsellableupdate` AFTER UPDATE ON `personcompressorsellable` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 204, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.sellablebindid <> NEW.sellablebindid THEN INSERT INTO log VALUES (NULL, 204, NEW.id, 'Vínculo', CASE WHEN OLD.sellablebindid = 0 THEN 'NENHUM' WHEN OLD.sellablebindid = 1 THEN 'FILTRO DE AR' WHEN OLD.sellablebindid = 2 THEN 'FILTRO DE OLEO' WHEN OLD.sellablebindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN OLD.sellablebindid = 4 THEN 'OLEO' WHEN OLD.sellablebindid = 5 THEN 'COALESCENTE' END, CASE WHEN NEW.sellablebindid = 0 THEN 'NENHUM' WHEN NEW.sellablebindid = 1 THEN 'FILTRO DE AR' WHEN NEW.sellablebindid = 2 THEN 'FILTRO DE OLEO' WHEN NEW.sellablebindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN NEW.sellablebindid = 4 THEN 'OLEO' WHEN NEW.sellablebindid = 5 THEN 'COALESCENTE' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF (
    (OLD.productid IS NOT NULL AND NEW.productid IS NULL AND OLD.serviceid IS NULL AND NEW.serviceid IS NOT NULL) OR
    (OLD.serviceid IS NOT NULL AND NEW.serviceid IS NULL AND OLD.productid IS NULL AND NEW.productid IS NOT NULL) OR
    (OLD.productid <> NEW.productid) OR (OLD.serviceid <> NEW.serviceid)
) THEN
	INSERT INTO log VALUES (
		NULL,
        204,
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
IF OLD.quantity <> NEW.quantity THEN INSERT INTO log VALUES (NULL, 204, NEW.id, 'Qtd.', FORMAT(OLD.quantity, 2, 'pt_BR'), FORMAT(NEW.quantity, 2, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.capacity <> NEW.capacity THEN INSERT INTO log VALUES (NULL, 204, NEW.id, 'Cap.', FORMAT(OLD.capacity, 0, 'pt_BR'), FORMAT(NEW.capacity, 0, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
CREATE TRIGGER `personcompressorsellableinsert` AFTER INSERT ON `personcompressorsellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 204, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
CREATE TRIGGER `personcompressorsellabledelete` AFTER DELETE ON `personcompressorsellable` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 204, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
CREATE TRIGGER `manager`.`citybeforedelete` BEFORE DELETE ON `city` FOR EACH ROW
BEGIN
DELETE FROM cityroute WHERE cityid = OLD.id;
END$$
CREATE TRIGGER `manager`.`evaluationbeforedelete` BEFORE DELETE ON `evaluation` FOR EACH ROW
BEGIN
DELETE FROM evaluationtechnician WHERE evaluationid = OLD.id;
DELETE FROM evaluationcontrolledsellable WHERE evaluationid = OLD.id;
DELETE FROM evaluationreplacedsellable WHERE evaluationid = OLD.id;
DELETE FROM evaluationphoto WHERE evaluationid = OLD.id;
END$$
CREATE TRIGGER `personbeforedelete` BEFORE DELETE ON `person` FOR EACH ROW BEGIN
DELETE FROM personaddress WHERE personid = OLD.id;
DELETE FROM personcontact WHERE personid = OLD.id;
DELETE FROM personcompressor WHERE personid = OLD.id;
END$$
CREATE TRIGGER `manager`.`personcompressorbeforedelete` BEFORE DELETE ON `personcompressor` FOR EACH ROW
BEGIN
DELETE FROM personcompressorsellable WHERE personcompressorid = OLD.id;
END$$
CREATE TRIGGER `manager`.`pricetablebeforedelete` BEFORE DELETE ON `pricetable` FOR EACH ROW
BEGIN
DELETE FROM pricetablesellable WHERE pricetableid = OLD.id;
END$$
CREATE TRIGGER `manager`.`privilegepresetinsert` AFTER INSERT ON `privilegepreset` FOR EACH ROW
BEGIN
INSERT INTO log VALUES (NULL, 14, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
CREATE TRIGGER `manager`.`privilegepresetdelete` AFTER DELETE ON `privilegepreset` FOR EACH ROW
BEGIN
INSERT INTO log VALUES (NULL, 14, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
CREATE TRIGGER `manager`.`privilegepresetupdate` AFTER UPDATE ON `privilegepreset` FOR EACH ROW
BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 14, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.name <> NEW.name THEN INSERT INTO log VALUES (NULL, 14, NEW.id, 'Nome', OLD.name, NEW.name, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
CREATE TRIGGER `manager`.`privilegepresetbeforedelete` BEFORE DELETE ON `privilegepreset` FOR EACH ROW
BEGIN
DELETE FROM privilegepresetprivilege WHERE privilegepresetid = OLD.id;
END$$
CREATE TRIGGER `privilegepresetprivilegeinsert` AFTER INSERT ON `privilegepresetprivilege` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 14, NEW.privilegepresetid, CONCAT('Permissão: ', NEW.routinename), CASE WHEN NEW.privilegelevelid = 0 THEN 'Acesso Negado' WHEN NEW.privilegelevelid = 1 THEN 'Escrita Negada' WHEN NEW.privilegelevelid = 2 THEN 'Deleção Negada' END, CASE WHEN NEW.privilegelevelid = 0 THEN 'Acesso Permitido' WHEN NEW.privilegelevelid = 1 THEN 'Escrita Permitida' WHEN NEW.privilegelevelid = 2 THEN 'Deleção Permitida' END, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
CREATE TRIGGER `privilegepresetprivilegedelete` AFTER DELETE ON `privilegepresetprivilege` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 14, OLD.privilegepresetid, CONCAT('Permissão: ', OLD.routinename), CASE WHEN OLD.privilegelevelid = 0 THEN 'Acesso Permitido' WHEN OLD.privilegelevelid = 1 THEN 'Escrita Permitida' WHEN OLD.privilegelevelid = 2 THEN 'Deleção Permitida' END, CASE WHEN OLD.privilegelevelid = 0 THEN 'Acesso Negado' WHEN OLD.privilegelevelid = 1 THEN 'Escrita Negada' WHEN OLD.privilegelevelid = 2 THEN 'Deleção Negada' END, NOW(), CONCAT(OLD.userid , ' - ', (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
CREATE TRIGGER `manager`.`productbeforedelete` BEFORE DELETE ON `product` FOR EACH ROW
BEGIN
DELETE FROM pricetablesellable WHERE productid = OLD.id;
DELETE FROM productcode WHERE productid = OLD.id;
DELETE FROM productprovidercode WHERE productid = OLD.id;
DELETE FROM productpicture WHERE productid = OLD.id;
END$$
CREATE TRIGGER `productpictureinsert` AFTER INSERT ON `productpicture` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 6, NEW.productid, 'Foto Incluída', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
CREATE TRIGGER `productpictureupdate` AFTER UPDATE ON `productpicture` FOR EACH ROW BEGIN
IF OLD.picturename <> NEW.picturename THEN INSERT INTO log VALUES (NULL, 6, NEW.productid, 'Foto Alterada', NULL, NULL, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
CREATE TRIGGER `productpicturedelete` AFTER DELETE ON `productpicture` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 6, OLD.productid, 'Foto Excluída', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
CREATE TRIGGER `manager`.`requestbeforedelete` BEFORE DELETE ON `request` FOR EACH ROW
BEGIN
DELETE FROM requestitem WHERE requestid = OLD.id;
END$$
CREATE TRIGGER `manager`.`servicebeforedelete` BEFORE DELETE ON `service` FOR EACH ROW
BEGIN
DELETE FROM pricetablesellable WHERE serviceid = OLD.id;
DELETE FROM servicecomplement WHERE serviceid = OLD.id;
DELETE FROM servicecode WHERE serviceid = OLD.id;
END$$
CREATE TRIGGER `manager`.`userbeforedelete` BEFORE DELETE ON `user` FOR EACH ROW
BEGIN
DELETE FROM useremail WHERE ofuserid = OLD.id;
DELETE FROM userprivilege WHERE granteduserid = OLD.ID;
END$$
CREATE TRIGGER `useremailupdate` AFTER UPDATE ON `useremail` FOR EACH ROW BEGIN
IF OLD.ismainemail <> NEW.ismainemail THEN INSERT INTO log VALUES (NULL, 101, NEW.id, 'E-Mail Principal', CASE WHEN OLD.ismainemail = TRUE THEN 'SIM' WHEN OLD.ismainemail = FALSE THEN 'NÃO' END, CASE WHEN NEW.ismainemail = TRUE THEN 'SIM' WHEN NEW.ismainemail = FALSE THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.host, '') <> IFNULL(NEW.host, '') THEN INSERT INTO log VALUES (NULL, 101, NEW.id, 'Servidor E-mail', OLD.host, NEW.host, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.port <> NEW.port THEN INSERT INTO log VALUES (NULL, 101, NEW.id, 'Porta E-Mail', OLD.port, NEW.port, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.email, '') <> IFNULL(NEW.email, '') THEN INSERT INTO log VALUES (NULL, 101, NEW.id, 'E-mail', OLD.email, NEW.email, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.password, '') <> IFNULL(NEW.password, '') THEN INSERT INTO log VALUES (NULL, 101, NEW.id, 'Senha E-mail Alterada', NULL, NULL, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.enablessl <> NEW.enablessl THEN INSERT INTO log VALUES (NULL, 101, NEW.id, 'Habilita SSL E-Mail', OLD.enablessl, NEW.enablessl, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
CREATE TRIGGER `manager`.`useremailinsert` AFTER INSERT ON `useremail` FOR EACH ROW
BEGIN
INSERT INTO log VALUES (NULL, 101, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
CREATE TRIGGER `manager`.`useremaildelete` AFTER DELETE ON `useremail` FOR EACH ROW
BEGIN
INSERT INTO log VALUES (NULL, 101, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ', (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DELIMITER ;
SET SQL_SAFE_UPDATES = 0;
UPDATE log SET routineid = 1201 WHERE routineid = 1202;
UPDATE log SET routineid = 204 WHERE routineid = 205;
DELETE FROM log WHERE routineid = 14;
DELETE FROM log WHERE routineid = 1401;
SET SQL_SAFE_UPDATES = 1;
ALTER TABLE `manager`.`evaluationphoto` CHANGE COLUMN `photoname` `picturename` VARCHAR(255) NOT NULL , RENAME TO  `manager`.`evaluationpicture` ;



DROP TRIGGER IF EXISTS `manager`.`evaluationphotoinsert`;
DROP TRIGGER IF EXISTS `manager`.`evaluationphotoupdate`;
DROP TRIGGER IF EXISTS `manager`.`evaluationphotodelete`;
DROP TRIGGER IF EXISTS `manager`.`evaluationinsert`;
DROP TRIGGER IF EXISTS `manager`.`evaluationupdate`;
DROP TRIGGER IF EXISTS `manager`.`evaluationdelete`;
DROP TRIGGER IF EXISTS `manager`.`evaluationbeforedelete`;

DELIMITER $$
CREATE TRIGGER `evaluationpictureinsert` AFTER INSERT ON `evaluationpicture` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1308, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
CREATE TRIGGER `evaluationpictureupdate` AFTER UPDATE ON `evaluationpicture` FOR EACH ROW BEGIN
IF OLD.picturename <> NEW.picturename THEN INSERT INTO log VALUES (NULL, 1308, NEW.id, 'Foto', NULL, 'Alterado', NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
CREATE TRIGGER `evaluationpicturedelete` AFTER DELETE ON `evaluationpicture` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 1308, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
CREATE TRIGGER `evaluationinsert` AFTER INSERT ON `evaluation` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 13, NEW.id, 'Criação', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
CREATE TRIGGER `evaluationupdate` AFTER UPDATE ON `evaluation` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'DESAPROVADA' WHEN OLD.statusid = 1 THEN 'APROVADA' WHEN OLD.statusid = 2 THEN 'REJEITADA' WHEN OLD.statusid = 3 THEN 'REVISADA'END, CASE WHEN NEW.statusid = 0 THEN 'DESAPROVADA' WHEN NEW.statusid = 1 THEN 'APROVADA' WHEN NEW.statusid = 2 THEN 'REJEITADA' WHEN NEW.statusid = 3 THEN 'REVISADA' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.calltypeid <> NEW.calltypeid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Tipo de Chamado', CASE WHEN OLD.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN OLD.calltypeid = 1 THEN 'PREVENTIVA' WHEN OLD.calltypeid = 2 THEN 'CHAMADO' WHEN OLD.calltypeid = 3 THEN 'CONTRATO' END, CASE WHEN NEW.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN NEW.calltypeid = 1 THEN 'PREVENTIVA' WHEN NEW.calltypeid = 2 THEN 'CHAMADO' WHEN NEW.calltypeid = 3 THEN 'CONTRATO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.needproposalid <> NEW.needproposalid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Proposta Necessária', CASE WHEN OLD.needproposalid = 0 THEN 'SIM' WHEN OLD.needproposalid = 1 THEN 'NÃO' END, CASE WHEN NEW.needproposalid = 0 THEN 'SIM' WHEN NEW.needproposalid = 1 THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.hasrepairid <> NEW.hasrepairid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Houve Reparo', CASE WHEN OLD.hasrepairid = 0 THEN 'SIM' WHEN OLD.hasrepairid = 1 THEN 'NÃO' END, CASE WHEN NEW.hasrepairid = 0 THEN 'SIM' WHEN NEW.hasrepairid = 1 THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.unitname, '') <> IFNULL(NEW.unitname, '') THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Unidade', OLD.unitname, NEW.unitname, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.temperature <> NEW.temperature THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Temperatura', OLD.temperature, NEW.temperature, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.pressure <> NEW.pressure THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Pressão', FORMAT(OLD.temperature, 1, 'pt_BR'), FORMAT(NEW.pressure, 1, 'pt_BR'), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
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
CREATE TRIGGER `evaluationdelete` AFTER DELETE ON `evaluation` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 13, OLD.id, 'Deleção', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
CREATE TRIGGER `evaluationbeforedelete` BEFORE DELETE ON `evaluation` FOR EACH ROW BEGIN
DELETE FROM evaluationtechnician WHERE evaluationid = OLD.id;
DELETE FROM evaluationcontrolledsellable WHERE evaluationid = OLD.id;
DELETE FROM evaluationreplacedsellable WHERE evaluationid = OLD.id;
DELETE FROM evaluationpicture WHERE evaluationid = OLD.id;
END$$
DELIMITER ;

INSERT INTO user VALUES (NULL, now(), 0, 'SISTEMA', 'kMY08GUx41ZTR8sUAjMHdA==', NULL, NULL, 0, 1); 

SELECT id FROM user WHERE username = 'SISTEMA' LIMIT 1 ;
select * from evaluation where id = 4179;
select * from log order by id desc;









