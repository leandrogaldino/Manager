ALTER TABLE `manager`.`compressorinterface` 
DROP FOREIGN KEY `compressorinterface_product`;
ALTER TABLE `manager`.`compressorinterface` 
CHANGE COLUMN `productid` `productid` INT NULL ;
ALTER TABLE `manager`.`compressorinterface` 
ADD CONSTRAINT `compressorinterface_product`
  FOREIGN KEY (`productid`)
  REFERENCES `manager`.`product` (`id`)
  ON DELETE RESTRICT;

ALTER TABLE `manager`.`compressorunit` 
DROP FOREIGN KEY `compressorunit_product`;
ALTER TABLE `manager`.`compressorunit` 
CHANGE COLUMN `productid` `productid` INT NULL ;
ALTER TABLE `manager`.`compressorunit` 
ADD CONSTRAINT `compressorunit_product`
  FOREIGN KEY (`productid`)
  REFERENCES `manager`.`product` (`id`)
  ON DELETE RESTRICT;




DROP TRIGGER IF EXISTS `manager`.`compressorinterfaceupdate`;
DROP TRIGGER IF EXISTS `manager`.`compressorunitupdate`;

DELIMITER $$
CREATE TRIGGER `compressorinterfaceupdate` AFTER UPDATE ON `compressorinterface` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 24, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.name <> NEW.name THEN INSERT INTO log VALUES (NULL, 24, NEW.id, 'Nome', OLD.name, NEW.name, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF NOT (OLD.productid <=> NEW.productid) THEN INSERT INTO log VALUES (NULL, 24, NEW.id, 'Produto', IF(OLD.productid IS NULL, '', CONCAT(OLD.productid, ' - ', (SELECT product.name FROM product WHERE product.id = OLD.productid))), IF(NEW.productid IS NULL, '', CONCAT(NEW.productid, ' - ', (SELECT product.name FROM product WHERE product.id = NEW.productid))), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.directionid <> NEW.directionid THEN INSERT INTO log VALUES (NULL, 24, NEW.id, 'Direção', CASE WHEN OLD.directionid = 0 THEN '' WHEN OLD.directionid = 1 THEN 'CRESCENTE' WHEN OLD.directionid = 2 THEN 'DECRESCENTE' END, CASE WHEN NEW.directionid = 0 THEN '' WHEN NEW.directionid = 1 THEN 'CRESCENTE' WHEN NEW.directionid = 2 THEN 'DECRESCENTE' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$


CREATE TRIGGER `compressorunitupdate` AFTER UPDATE ON `compressorunit` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 25, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.name <> NEW.name THEN INSERT INTO log VALUES (NULL, 25, NEW.id, 'Nome', OLD.name, NEW.name, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF NOT (OLD.productid <=> NEW.productid) THEN INSERT INTO log VALUES (NULL, 25, NEW.id, 'Produto', IF(OLD.productid IS NULL, '', CONCAT(OLD.productid, ' - ', (SELECT product.name FROM product WHERE product.id = OLD.productid))), IF(NEW.productid IS NULL, '', CONCAT(NEW.productid, ' - ', (SELECT product.name FROM product WHERE product.id = NEW.productid))), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;

