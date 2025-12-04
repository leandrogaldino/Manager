TRUNCATE useremail;
DROP TRIGGER IF EXISTS `manager`.`evaluationpictureinsert`;
DROP TRIGGER IF EXISTS `manager`.`evaluationpictureupdate`;
DROP TRIGGER IF EXISTS `manager`.`evaluationpicturedelete`;
DELIMITER $$
CREATE TRIGGER `evaluationpictureinsert` AFTER INSERT ON `evaluationpicture` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 13, NEW.evaluationid, 'Foto Incluída', NULL, NULL, NOW(), CONCAT(NEW.userid , ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid)));
END$$
CREATE TRIGGER `evaluationpictureupdate` AFTER UPDATE ON `evaluationpicture` FOR EACH ROW BEGIN
IF OLD.picturename <> NEW.picturename THEN INSERT INTO log VALUES (NULL, 13, NEW.evaluationid, 'Foto Alterada', NULL, NULL, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
CREATE TRIGGER `evaluationpicturedelete` AFTER DELETE ON `evaluationpicture` FOR EACH ROW BEGIN
INSERT INTO log VALUES (NULL, 13, OLD.evaluationid, 'Foto Excluída', NULL, NULL, NOW(), CONCAT(OLD.userid, ' - ',  (SELECT user.username FROM user WHERE user.id = OLD.userid)));
END$$
DELIMITER ;

#PERSONCOMPRESSORSELLABLE
INSERT INTO log (
    routineid,
    registryid,
    fieldname,
    oldvalue,
    newvalue,
    changedate,
    user
)
SELECT
    204 AS routineid,
    pcs.id AS registryid,
    'Criação' AS fieldname,
    NULL AS oldvalue,
    NULL AS newvalue,
    MIN(l203.changedate) AS changedate,  -- primeira aparição do pc.id no log 203
    SUBSTRING_INDEX(GROUP_CONCAT(l203.user ORDER BY l203.changedate ASC), ',', 1) AS user
FROM personcompressorsellable pcs
JOIN personcompressor pc
    ON pc.id = pcs.personcompressorid
LEFT JOIN log l204
    ON l204.registryid = pcs.id
    AND l204.routineid = 204
LEFT JOIN log l203
    ON l203.registryid = pc.id
    AND l203.routineid = 203
WHERE l204.registryid IS NULL
GROUP BY pcs.id, pc.serialnumber;

#COMPRESSORSELLABLE
INSERT INTO log (
    routineid,
    registryid,
    fieldname,
    oldvalue,
    newvalue,
    changedate,
    user
)
SELECT
    1201 AS routineid,
    cs.id AS registryid,
    'Criação' AS fieldname,
    NULL AS oldvalue,
    NULL AS newvalue,
    l12.FirstAppearance AS changedate,
    l12.user AS user
FROM compressorsellable cs
JOIN compressor c
    ON c.id = cs.compressorid
LEFT JOIN (
    SELECT
        registryid,
        MIN(changedate) AS FirstAppearance,
        SUBSTRING_INDEX(
            GROUP_CONCAT(user ORDER BY changedate ASC SEPARATOR ','),
            ',',
            1
        ) AS user
    FROM log
    WHERE routineid = 12
    GROUP BY registryid
) AS l12
    ON l12.registryid = c.id
LEFT JOIN log l204
    ON l204.registryid = cs.id
    AND l204.routineid = 1201
WHERE l204.registryid IS NULL
  AND l12.FirstAppearance IS NOT NULL;  -- evita erro por campo obrigatório
SET SQL_SAFE_UPDATES = 1;

# EVALUATIONTECHNICIAN
INSERT INTO log (
    routineid,
    registryid,
    fieldname,
    oldvalue,
    newvalue,
    changedate,
    user
)
SELECT
    1307 AS routineid,
    pcs.id AS registryid,
    'Criação' AS fieldname,
    NULL AS oldvalue,
    NULL AS newvalue,
    l13.FirstAppearance AS changedate,
    l13.user AS user
FROM evaluationtechnician pcs
JOIN evaluation pc
    ON pc.id = pcs.evaluationid
LEFT JOIN (
    SELECT
        registryid,
        MIN(changedate) AS FirstAppearance,
        SUBSTRING_INDEX(
            GROUP_CONCAT(user ORDER BY changedate ASC SEPARATOR ','),
            ',',
            1
        ) AS user
    FROM log
    WHERE routineid = 13
    GROUP BY registryid
) AS l13
    ON l13.registryid = pc.id
LEFT JOIN log l1307
    ON l1307.registryid = pcs.id
    AND l1307.routineid = 1307
WHERE l1307.registryid IS NULL
  AND l13.FirstAppearance IS NOT NULL;

#CASH
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`cash` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE cash
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 11
    GROUP BY registryid
) lmax ON lmax.registryid = cash.id
SET cash.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`cash` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`cash` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#CASH FLOW
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`cashflow` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE cashflow
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 19
    GROUP BY registryid
) lmax ON lmax.registryid = cashflow.id
SET cashflow.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`cashflow` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`cashflow` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#CASH FLOW AUTHORIZED
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`cashflowauthorized` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE cashflowauthorized
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 1901
    GROUP BY registryid
) lmax ON lmax.registryid = cashflowauthorized.id
SET cashflowauthorized.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`cashflowauthorized` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`cashflowauthorized` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#CASH ITEM
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`cashitem` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE cashitem
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 1101
    GROUP BY registryid
) lmax ON lmax.registryid = cashitem.id
SET cashitem.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`cashitem` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`cashitem` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#CASH ITEM RESPONSIBLE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`cashitemresponsible` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE cashitemresponsible
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 1102
    GROUP BY registryid
) lmax ON lmax.registryid = cashitemresponsible.id
SET cashitemresponsible.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`cashitemresponsible` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`cashitemresponsible` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#CITY
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`city` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE city
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 3
    GROUP BY registryid
) lmax ON lmax.registryid = city.id
SET city.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`city` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`city` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#CITY ROUTE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`cityroute` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE cityroute
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 301
    GROUP BY registryid
) lmax ON lmax.registryid = cityroute.id
SET cityroute.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`cityroute` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`cityroute` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#COMPRESSOR
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`compressor` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE compressor
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 12
    GROUP BY registryid
) lmax ON lmax.registryid = compressor.id
SET compressor.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`compressor` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`compressor` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#COMPRESSOR SELLABLE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`compressorsellable` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE compressorsellable
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 1201
    GROUP BY registryid
) lmax ON lmax.registryid = compressorsellable.id
SET compressorsellable.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`compressorsellable` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`compressorsellable` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#EMAIL MODEL
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`emailmodel` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE emailmodel
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 16
    GROUP BY registryid
) lmax ON lmax.registryid = emailmodel.id
SET emailmodel.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`emailmodel` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`emailmodel` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#EMAIL SIGNATURE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`emailsignature` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE emailsignature
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 20
    GROUP BY registryid
) lmax ON lmax.registryid = emailsignature.id
SET emailsignature.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`emailsignature` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`emailsignature` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#EVALUATION
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`evaluation` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE evaluation
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 13
    GROUP BY registryid
) lmax ON lmax.registryid = evaluation.id
SET evaluation.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`evaluation` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`evaluation` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#EVALUATION CONTROLLED SELLABLE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`evaluationcontrolledsellable` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE evaluationcontrolledsellable
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 1306
    GROUP BY registryid
) lmax ON lmax.registryid = evaluationcontrolledsellable.id
SET evaluationcontrolledsellable.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`evaluationcontrolledsellable` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`evaluationcontrolledsellable` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#EVALUATION REPLACED SELLABLE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`evaluationreplacedsellable` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE evaluationreplacedsellable
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 1312
    GROUP BY registryid
) lmax ON lmax.registryid = evaluationreplacedsellable.id
SET evaluationreplacedsellable.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`evaluationreplacedsellable` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`evaluationreplacedsellable` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#EVALUATION TECHNICIAN
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`evaluationtechnician` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE evaluationtechnician
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 1307
    GROUP BY registryid
) lmax ON lmax.registryid = evaluationtechnician.id
SET evaluationtechnician.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`evaluationtechnician` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`evaluationtechnician` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PERSON
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`person` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE person
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 2
    GROUP BY registryid
) lmax ON lmax.registryid = person.id
SET person.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`person` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`person` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PERSON ADDRESS
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`personaddress` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE personaddress
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 201
    GROUP BY registryid
) lmax ON lmax.registryid = personaddress.id
SET personaddress.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`personaddress` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`personaddress` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PERSON COMPRESSOR
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`personcompressor` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE personcompressor
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 203
    GROUP BY registryid
) lmax ON lmax.registryid = personcompressor.id
SET personcompressor.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`personcompressor` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`personcompressor` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PERSON COMPRESSOR
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`personcompressorsellable` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE personcompressorsellable
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 204
    GROUP BY registryid
) lmax ON lmax.registryid = personcompressorsellable.id
SET personcompressorsellable.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`personcompressorsellable` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`personcompressorsellable` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PERSON CONTACT
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`personcontact` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE personcontact
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 202
    GROUP BY registryid
) lmax ON lmax.registryid = personcontact.id
SET personcontact.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`personcontact` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`personcontact` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PRICE TABLE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`pricetable` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE pricetable
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 8
    GROUP BY registryid
) lmax ON lmax.registryid = pricetable.id
SET pricetable.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`pricetable` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`pricetable` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PRICE TABLE SELLABLE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`pricetablesellable` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE pricetablesellable
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 801
    GROUP BY registryid
) lmax ON lmax.registryid = pricetablesellable.id
SET pricetablesellable.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`pricetablesellable` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`pricetablesellable` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PRIVILEGE PRESET
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`privilegepreset` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE privilegepreset
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 14
    GROUP BY registryid
) lmax ON lmax.registryid = privilegepreset.id
SET privilegepreset.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`privilegepreset` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`privilegepreset` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PRODUCT
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`product` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE product
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 6
    GROUP BY registryid
) lmax ON lmax.registryid = product.id
SET product.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`product` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`product` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PRODUCT CODE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`productcode` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE productcode
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 602
    GROUP BY registryid
) lmax ON lmax.registryid = productcode.id
SET productcode.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`productcode` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`productcode` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PRODUCT FAMILY
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`productfamily` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE productfamily
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 9
    GROUP BY registryid
) lmax ON lmax.registryid = productfamily.id
SET productfamily.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`productfamily` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`productfamily` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PRODUCT GROUP
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`productgroup` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE productgroup
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 10
    GROUP BY registryid
) lmax ON lmax.registryid = productgroup.id
SET productgroup.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`productgroup` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`productgroup` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PRODUCT PROVIDER CODE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`productprovidercode` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE productprovidercode
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 601
    GROUP BY registryid
) lmax ON lmax.registryid = productprovidercode.id
SET productprovidercode.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`productprovidercode` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`productprovidercode` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#PRODUCT UNIT
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`productunit` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE productunit
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 7
    GROUP BY registryid
) lmax ON lmax.registryid = productunit.id
SET productunit.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`productunit` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`productunit` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#REQUEST
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`request` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE request
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 15
    GROUP BY registryid
) lmax ON lmax.registryid = request.id
SET request.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`request` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`request` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#REQUEST
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`requestitem` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE requestitem
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 1501
    GROUP BY registryid
) lmax ON lmax.registryid = requestitem.id
SET requestitem.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`requestitem` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`requestitem` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#ROUTE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`route` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE route
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 5
    GROUP BY registryid
) lmax ON lmax.registryid = route.id
SET route.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`route` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`route` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#SERVICE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`service` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE service
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 23
    GROUP BY registryid
) lmax ON lmax.registryid = service.id
SET service.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`service` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`service` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#SERVICE CODE
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`servicecode` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE servicecode
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 2303
    GROUP BY registryid
) lmax ON lmax.registryid = servicecode.id
SET servicecode.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`servicecode` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`servicecode` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#SERVICE COMPLEMENT
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`servicecomplement` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE servicecomplement
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 2301
    GROUP BY registryid
) lmax ON lmax.registryid = servicecomplement.id
SET servicecomplement.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`servicecomplement` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`servicecomplement` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#USER
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`user` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE user
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 1
    GROUP BY registryid
) lmax ON lmax.registryid = user.id
SET user.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`user` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`user` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#USER EMAIL
SET SQL_SAFE_UPDATES = 0;
ALTER TABLE `manager`.`useremail` ADD COLUMN `lastupdate` DATETIME NULL AFTER `userid`;
UPDATE useremail
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 101
    GROUP BY registryid
) lmax ON lmax.registryid = useremail.id
SET useremail.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`useremail` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`useremail` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;

#VISIT SCHEDULE
SET SQL_SAFE_UPDATES = 0;
UPDATE visitschedule
JOIN (
    SELECT registryid, MAX(changedate) AS last_changed
    FROM log
    WHERE routineid = 22
    GROUP BY registryid
) lmax ON lmax.registryid = visitschedule.id
SET visitschedule.lastupdate = lmax.last_changed;
ALTER TABLE `manager`.`visitschedule` MODIFY COLUMN lastupdate DATETIME NOT NULL AFTER `userid`;
ALTER TABLE `manager`.`visitschedule` MODIFY COLUMN `lastupdate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP AFTER `userid`;
SET SQL_SAFE_UPDATES = 1;


DROP TRIGGER IF EXISTS `manager`.`evaluationupdate`;
DROP TRIGGER IF EXISTS `manager`.`visitscheduleupdate`;

DELIMITER $$
CREATE TRIGGER `evaluationupdate` AFTER UPDATE ON `evaluation` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'DESAPROVADA' WHEN OLD.statusid = 1 THEN 'APROVADA' WHEN OLD.statusid = 2 THEN 'REJEITADA' WHEN OLD.statusid = 3 THEN 'REVISADA'END, CASE WHEN NEW.statusid = 0 THEN 'DESAPROVADA' WHEN NEW.statusid = 1 THEN 'APROVADA' WHEN NEW.statusid = 2 THEN 'REJEITADA' WHEN NEW.statusid = 3 THEN 'REVISADA' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.calltypeid <> NEW.calltypeid THEN INSERT INTO log VALUES (NULL, 13, NEW.id, 'Tipo de Chamado', CASE WHEN OLD.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN OLD.calltypeid = 1 THEN 'PREVENTIVA' WHEN OLD.calltypeid = 2 THEN 'CORRETIVA' WHEN OLD.calltypeid = 3 THEN 'CONTRATO' END, CASE WHEN NEW.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN NEW.calltypeid = 1 THEN 'PREVENTIVA' WHEN NEW.calltypeid = 2 THEN 'CORRETIVA' WHEN NEW.calltypeid = 3 THEN 'CONTRATO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
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

CREATE TRIGGER `visitscheduleupdate` AFTER UPDATE ON `visitschedule` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'PENDENTE' WHEN OLD.statusid = 1 THEN 'FINALIZADO' WHEN OLD.statusid = 2 THEN 'CANCELADO' END, CASE WHEN NEW.statusid = 0 THEN 'PENDENTE' WHEN NEW.statusid = 1 THEN 'FINALIZADO' WHEN NEW.statusid = 2 THEN 'CANCELADO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.scheduleddate <> NEW.scheduleddate THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Data Agendada', OLD.scheduleddate, NEW.scheduleddate, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.performeddate <> NEW.performeddate THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Data Realizada', OLD.performeddate, NEW.performeddate, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.calltypeid <> NEW.calltypeid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Tipo de Chamado', CASE WHEN OLD.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN OLD.calltypeid = 1 THEN 'PREVENTIVA' WHEN OLD.calltypeid = 2 THEN 'CORRETIVA' WHEN OLD.calltypeid = 3 THEN 'CONTRATO'END, CASE WHEN NEW.calltypeid = 0 THEN 'LEVANTAMENTO' WHEN NEW.calltypeid = 1 THEN 'PREVENTIVA' WHEN NEW.calltypeid = 2 THEN 'CORRETIVA' WHEN NEW.calltypeid = 3 THEN 'CONTRATO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.customerid <> NEW.customerid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Cliente', CONCAT(OLD.customerid, ' - ', (SELECT person.name FROM person WHERE person.id = OLD.customerid)), CONCAT(NEW.customerid, ' - ', (SELECT person.name FROM person WHERE person.id = NEW.customerid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.technicianid <> NEW.technicianid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Técnico', CONCAT(OLD.technicianid, ' - ', (SELECT person.name FROM person WHERE person.id = OLD.technicianid)), CONCAT(NEW.technicianid, ' - ', (SELECT person.name FROM person WHERE person.id = NEW.technicianid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.personcompressorid <> NEW.personcompressorid THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Compressor', CONCAT(OLD.personcompressorid, ' - ', (SELECT compressor.name FROM personcompressor LEFT JOIN compressor ON compressor.id = personcompressor.compressorid WHERE personcompressor.id = OLD.personcompressorid)), CONCAT(NEW.personcompressorid, ' - ', (SELECT compressor.name FROM personcompressor LEFT JOIN compressor ON compressor.id = personcompressor.compressorid WHERE personcompressor.id = NEW.personcompressorid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.instructions, '') <> IFNULL(NEW.instructions, '') THEN INSERT INTO log VALUES (NULL, 22, NEW.id, 'Instruções', OLD.instructions, NEW.instructions, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;

ALTER TABLE `manager`.`visitschedule` 
DROP FOREIGN KEY `visitschedile_ibfk_4`;
ALTER TABLE `manager`.`visitschedule` 
DROP COLUMN `overridedvisitscheduleid`,
DROP INDEX `visitschedile_ibfk_4_idx` ;

