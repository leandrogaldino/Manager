/*
Como a cryptokey foi alterada, a senha de todos os usuarios deve ser resetada
Como a cryptokey foi alterada, a senha de todos os e-mails cadastradosuser
No caixa reicol comercio no mes 02/2024 tem um registro do expresso vedações que está sem responsavel, colocar reicol
No caixa reicol comercio no mes 08/2023 tem um registro da di napoli que está sem responsavel, colocar reicol
No caixa reicol comercio no mes 08/2023 tem um registro da di napoli que está sem responsavel, colocar reicol
No caixa aberto no mes 03/2024 tem um registro do almoço que está sem responsavel, colocar leandro
Tem alguma avaliação que está com ano muito errado
Deletar UserPrivilege e UserPriuvilegePreset, PrivilegePreset  e PrivilegePresetPrivilege
*/

/*
CREATE USER 'root'@'%' IDENTIFIED BY '123456';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;
*/
ALTER TABLE personcompressorpart ADD COLUMN partbindid INT NOT NULL AFTER statusid;

SET SQL_SAFE_UPDATES = 0;
UPDATE USER SET PASSWORD = 'kMY08GUx41ZTR8sUAjMHdA=='; 
UPDATE USER SET requestnewpassword = 1;
SET SQL_SAFE_UPDATES = 1;



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
ALTER TABLE `manager`.`evaluation` ADD COLUMN `signaturename` INT NOT NULL AFTER `documentname`;

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


INSERT INTO userprivilege VALUES (NULL, CURDATE(), 1, 1, 'Usuário', 0, 1);
INSERT INTO userprivilege VALUES (NULL, CURDATE(), 1, 1, 'Usuário', 1, 1);
INSERT INTO userprivilege VALUES (NULL, CURDATE(), 1, 1, 'Usuário', 2, 1);

INSERT INTO `userprivilege` VALUES (4,'2025-06-15',2,22,'Agenda de Visita',0,1),(5,'2025-06-15',2,13,'Avaliação de Compressor',0,1),(6,'2025-06-15',2,22,'Agenda de Visita',1,1),(7,'2025-06-15',2,20,'Assinatura de E-Mail',0,1),(8,'2025-06-15',2,20,'Assinatura de E-Mail',1,1),(9,'2025-06-15',2,13,'Avaliação de Compressor',1,1),(10,'2025-06-15',2,11,'Caixa',0,1),(11,'2025-06-15',2,11,'Caixa',1,1),(12,'2025-06-15',2,3,'Cidade',0,1),(13,'2025-06-15',2,2,'Pessoa',0,1),(14,'2025-06-15',2,3,'Cidade',1,1),(15,'2025-06-15',2,12,'Compressor',0,1),(16,'2025-06-15',2,12,'Compressor',1,1),(17,'2025-06-15',2,21,'CRM',0,1),(18,'2025-06-15',2,21,'CRM',1,1),(19,'2025-06-15',2,17,'E-mails Enviados',0,1),(20,'2025-06-15',2,17,'E-mails Enviados',1,1),(21,'2025-06-15',2,4,'Estado',0,1),(22,'2025-06-15',2,4,'Estado',1,1),(23,'2025-06-15',2,9,'Família de Produtos',0,1),(24,'2025-06-15',2,6,'Produto',0,1),(25,'2025-06-15',2,9,'Família de Produtos',1,1),(26,'2025-06-15',2,19,'Fluxo de Caixa',0,1),(27,'2025-06-15',2,19,'Fluxo de Caixa',1,1),(28,'2025-06-15',2,19,'Fluxo de Caixa',2,1),(29,'2025-06-15',2,9,'Família de Produtos',2,1),(30,'2025-06-15',2,4,'Estado',2,1),(31,'2025-06-15',2,17,'E-mails Enviados',2,1),(32,'2025-06-15',2,21,'CRM',2,1),(33,'2025-06-15',2,12,'Compressor',2,1),(34,'2025-06-15',2,3,'Cidade',2,1),(35,'2025-06-15',2,11,'Caixa',2,1),(36,'2025-06-15',2,13,'Avaliação de Compressor',2,1),(37,'2025-06-15',2,20,'Assinatura de E-Mail',2,1),(38,'2025-06-15',2,22,'Agenda de Visita',2,1),(39,'2025-06-15',2,10,'Grupo de Produtos',0,1),(40,'2025-06-15',2,10,'Grupo de Produtos',1,1),(41,'2025-06-15',2,16,'Modelo de E-mail',0,1),(42,'2025-06-15',2,16,'Modelo de E-mail',1,1),(43,'2025-06-15',2,2,'Pessoa',1,1),(44,'2025-06-15',2,14,'Predefinição de Permissões',0,1),(45,'2025-06-15',2,1,'Usuário',0,1),(46,'2025-06-15',2,14,'Predefinição de Permissões',1,1),(47,'2025-06-15',2,6,'Produto',1,1),(48,'2025-06-15',2,15,'Requisição',0,1),(49,'2025-06-15',2,15,'Requisição',1,1),(50,'2025-06-15',2,5,'Rota',0,1),(51,'2025-06-15',2,5,'Rota',1,1),(52,'2025-06-15',2,23,'Serviço',0,1),(53,'2025-06-15',2,23,'Serviço',1,1),(54,'2025-06-15',2,23,'Serviço',2,1),(55,'2025-06-15',2,5,'Rota',2,1),(56,'2025-06-15',2,15,'Requisição',2,1),(57,'2025-06-15',2,6,'Produto',2,1),(58,'2025-06-15',2,14,'Predefinição de Permissões',2,1),(59,'2025-06-15',2,2,'Pessoa',2,1),(60,'2025-06-15',2,16,'Modelo de E-mail',2,1),(61,'2025-06-15',2,10,'Grupo de Produtos',2,1),(62,'2025-06-15',2,8,'Tabela de Preços',0,1),(63,'2025-06-15',2,8,'Tabela de Preços',1,1),(64,'2025-06-15',2,7,'Unidade de Medida',0,1),(65,'2025-06-15',2,7,'Unidade de Medida',1,1),(66,'2025-06-15',2,1,'Usuário',1,1),(67,'2025-06-15',2,1,'Usuário',2,1),(68,'2025-06-15',2,7,'Unidade de Medida',2,1),(69,'2025-06-15',2,8,'Tabela de Preços',2,1),(70,'2025-06-15',2,9902,'Acessar o histórico',0,1),(71,'2025-06-15',2,2105,'Alterar o assunto do CRM',0,1),(72,'2025-06-15',2,2103,'Alterar o cliente do CRM',0,1),(73,'2025-06-15',2,206,'Alterar o documento da Pessoa',0,1),(74,'2025-06-15',2,2104,'Alterar o responsavel do CRM',0,1),(75,'2025-06-15',2,2102,'Alterar o status do CRM para pendente',0,1),(76,'2025-06-15',2,1309,'Aprovar e rejeitar uma avaliação',0,1),(77,'2025-06-15',2,2106,'Editar um atendimento do CRM',0,1),(78,'2025-06-15',2,1310,'Criar avaliações automáticas',0,1),(79,'2025-06-15',2,9901,'Exportar as grades',0,1),(80,'2025-06-15',2,1305,'Exportar imagem do painel de compressores',0,1),(81,'2025-06-15',2,1903,'Gerar o relatório de despesas por responsável do caixa',0,1),(82,'2025-06-15',2,207,'Gerar o relatório de ficha cadastral da pessoa',0,1),(83,'2025-06-15',2,1902,'Gerar o relatório de folha de caixa',0,1),(84,'2025-06-15',2,1502,'Gerar o relatório de folha de requisição de itens',0,1),(85,'2025-06-15',2,1503,'Gerar o relatório de itens pendentes da requisição de itens',0,1),(86,'2025-06-15',2,208,'Gerar o relatório de plano de manutenção',0,1),(87,'2025-06-15',2,1301,'Gerenciamento de Avaliações',0,1),(88,'2025-06-15',2,1311,'Importar avaliações da núvem',0,1),(89,'2025-06-15',2,1304,'Painel de Compressores',0,1),(90,'2025-06-15',2,102,'Permite Resetar Senha',0,1),(91,'2025-06-15',2,1904,'Reabrir um caixa',0,1);



INSERT INTO service VALUES (NULL, CURDATE(), 0, 'ENGRAXAMENTO', NULL, 1);
INSERT INTO servicecode VALUES (NULL, 1, CURDATE(), 'Cód. da Lista de Serviços', '14.01.35', 1);
INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE AR INGERSOLL', 'FILTRO DE AR INGERSOLL', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE OLEO INGERSOLL', 'FILTRO DE OLEO INGERSOLL', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO SEPARADOR INGERSOLL', 'FILTRO SEPARADOR INGERSOLL', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
INSERT INTO product VALUES (NULL, CURDATE(), 0, 'OLEO ALIMENTICIO 19L', 'OLEO ALIMENTICIO 19L', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE AR ATLAS', 'FILTRO DE AR ATLAS', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE OLEO ATLAS', 'FILTRO DE OLEO ATLAS', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO SEPARADOR ATLAS', 'FILTRO SEPARADOR ATLAS', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);

INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE AR ZHEJIANG LEADWAY', 'FILTRO DE AR  ZHEJIANG LEADWAY', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO DE OLEO  ZHEJIANG LEADWAY', 'FILTRO DE OLEO  ZHEJIANG LEADWAY', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);
INSERT INTO product VALUES (NULL, CURDATE(), 0, 'FILTRO SEPARADOR  ZHEJIANG LEADWAY', 'FILTRO SEPARADOR  ZHEJIANG LEADWAY', NULL, 1, 1, 1, 0, 0, 0, 0, NULL, 1);







SET SQL_SAFE_UPDATES = 0;
UPDATE compressorsellable SET serviceid = 1 WHERE compressorsellable.itemname = "REVITALIZACAO";
UPDATE compressorsellable SET productid = 193 WHERE id = 408;
UPDATE compressorsellable SET productid = 194 WHERE id = 409;
UPDATE compressorsellable SET productid = 195 WHERE id = 410;
UPDATE compressorsellable SET productid = 196 WHERE id = 411;
UPDATE compressorsellable SET productid = 197 WHERE id = 431;
UPDATE compressorsellable SET productid = 198 WHERE id = 432;
UPDATE compressorsellable SET productid = 199 WHERE id = 433;
UPDATE compressorsellable SET productid = 216 WHERE id = 457;
UPDATE compressorsellable SET productid = 216 WHERE id = 461;
UPDATE compressorsellable SET productid = 217 WHERE id = 458;
UPDATE compressorsellable SET productid = 217 WHERE id = 462;
UPDATE compressorsellable SET productid = 218 WHERE id = 459;
UPDATE compressorsellable SET productid = 218 WHERE id = 463;
UPDATE compressorsellable SET productid = 34 WHERE id = 460;
UPDATE compressorsellable SET productid = 34 WHERE id = 464;

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

