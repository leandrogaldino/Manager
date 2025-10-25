DROP TRIGGER IF EXISTS `manager`.`personcompressorsellableupdate`;
DELIMITER $$
CREATE TRIGGER `personcompressorsellableupdate` AFTER UPDATE ON `personcompressorsellable` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 204, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.sellablebindid <> NEW.sellablebindid THEN INSERT INTO log VALUES (NULL, 204, NEW.id, 'Vínculo', CASE WHEN OLD.sellablebindid = 0 THEN 'NENHUM' WHEN OLD.sellablebindid = 1 THEN 'FILTRO DE AR' WHEN OLD.sellablebindid = 2 THEN 'FILTRO DE OLEO' WHEN OLD.sellablebindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN OLD.sellablebindid = 4 THEN 'OLEO' WHEN OLD.sellablebindid = 5 THEN 'COALESCENTE' WHEN OLD.sellablebindid = 6 THEN 'ENGRAXAMENTO' END, CASE WHEN NEW.sellablebindid = 0 THEN 'NENHUM' WHEN NEW.sellablebindid = 1 THEN 'FILTRO DE AR' WHEN NEW.sellablebindid = 2 THEN 'FILTRO DE OLEO' WHEN NEW.sellablebindid = 3 THEN 'ELEMENTO SEPARADOR' WHEN NEW.sellablebindid = 4 THEN 'OLEO' WHEN NEW.sellablebindid = 5 THEN 'COALESCENTE' WHEN NEW.sellablebindid = 6 THEN 'ENGRAXAMENTO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
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
DELIMITER ;
SET SQL_SAFE_UPDATES = 0;
UPDATE personcompressorsellable SET userid = 1 WHERE serviceid = 1;
UPDATE personcompressorsellable SET sellablebindid = 6 WHERE serviceid = 1;
SET SQL_SAFE_UPDATES = 1;


