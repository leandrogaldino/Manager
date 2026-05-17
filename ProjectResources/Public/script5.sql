ALTER TABLE `manager`.`personcompressor` ADD COLUMN `oiltypeid` INT NOT NULL AFTER `controlledid`;
DROP TRIGGER IF EXISTS `manager`.`personcompressorupdate`;
DELIMITER $$
CREATE TRIGGER `personcompressorupdate` AFTER UPDATE ON `personcompressor` FOR EACH ROW BEGIN
IF OLD.statusid <> NEW.statusid THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Status', CASE WHEN OLD.statusid = 0 THEN 'ATIVO' WHEN OLD.statusid = 1 THEN 'INATIVO' END, CASE WHEN NEW.statusid = 0 THEN 'ATIVO' WHEN NEW.statusid = 1 THEN 'INATIVO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.controlledid <> NEW.controlledid THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Controlado', CASE WHEN OLD.controlledid = 0 THEN 'SIM' WHEN OLD.controlledid = 1 THEN 'NÃO' END, CASE WHEN NEW.controlledid = 0 THEN 'SIM' WHEN NEW.controlledid = 1 THEN 'NÃO' END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.oiltypeid <> NEW.oiltypeid THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Tipo Óleo', CASE WHEN OLD.oiltypeid = 0 THEN '' WHEN OLD.oiltypeid = 1 THEN 'MINERAL' WHEN OLD.oiltypeid = 2 THEN 'SEMI-SINTÉTICO' WHEN OLD.oiltypeid = 3 THEN 'SINTÉTICO' END, CASE WHEN NEW.oiltypeid = 0 THEN '' WHEN NEW.oiltypeid = 1 THEN 'MINERAL' WHEN NEW.oiltypeid = 2 THEN 'SEMI-SINTÉTICO' WHEN NEW.oiltypeid = 3 THEN 'SINTÉTICO'END, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.compressorid <> NEW.compressorid THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Compressor', CONCAT(OLD.compressorid, ' - ', (SELECT compressor.name FROM compressor WHERE compressor.id = OLD.compressorid)), CONCAT(NEW.compressorid, ' - ', (SELECT compressor.name FROM compressor WHERE compressor.id = NEW.compressorid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.compressorinterfaceid, 0) <> IFNULL(NEW.compressorinterfaceid, 0) THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Interface', CONCAT(OLD.compressorinterfaceid, ' - ', (SELECT compressorinterface.name FROM compressorinterface WHERE compressorinterface.id = OLD.compressorinterfaceid)), CONCAT(NEW.compressorinterfaceid, ' - ', (SELECT compressorinterface.name FROM compressorinterface WHERE compressorinterface.id = NEW.compressorinterfaceid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.compressorunitid, 0) <> IFNULL(NEW.compressorunitid, 0) THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Unidade', CONCAT(OLD.compressorunitid, ' - ', (SELECT compressorunit.name FROM compressorunit WHERE compressorunit.id = OLD.compressorunitid)), CONCAT(NEW.compressorunitid, ' - ', (SELECT compressorunit.name FROM compressorunit WHERE compressorunit.id = NEW.compressorunitid)), NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.serialnumber, '') <> IFNULL(NEW.serialnumber, '') THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Nº de Série', OLD.serialnumber, NEW.serialnumber, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.patrimony, '') <> IFNULL(NEW.patrimony, '') THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Patrimônio', OLD.patrimony, NEW.patrimony, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.sector, '') <> IFNULL(NEW.sector, '') THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Setor', OLD.sector, NEW.sector, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF OLD.unitcapacity <> NEW.unitcapacity THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Cap. Und.', OLD.unitcapacity, NEW.unitcapacity, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
IF IFNULL(OLD.note, '') <> IFNULL(NEW.note, '') THEN INSERT INTO log VALUES (NULL, 203, NEW.id, 'Observação', OLD.note, NEW.note, NOW(), CONCAT(NEW.userid, ' - ', (SELECT user.username FROM user WHERE user.id = NEW.userid))); END IF;
END$$
DELIMITER ;

/*
-DELETAR AVALIACAO 5267 PELO SISTEMA.

-DEPOIS EXECUTAR ESSA QUERY, VER OS COMPRESSORES QUE ESTAO COM CAPACIDADE ERRADA E CORRIGIR PELO SISTEMA:
select pc.id, pcs.capacity, c.name, p.name
from personcompressor pc
left join personcompressorsellable pcs on pc.id = pcs.personcompressorid and pcs.capacity not in (1000, 4000, 8000)
left join compressor c on c.id = pc.compressorid
left join person p on p.id = pc.personid
where pcs.sellablebindid = 4;

-EXECUTA ISSO PARA ALTERAR O OILTYPEID

UPDATE personcompressor pc
JOIN personcompressorsellable pcs 
    ON pc.id = pcs.personcompressorid
SET pc.oiltypeid = CASE
    WHEN pcs.capacity = 1000 THEN 1
    WHEN pcs.capacity = 4000 THEN 2
    WHEN pcs.capacity = 8000 THEN 3
END,
pc.userid = 12
WHERE pcs.sellablebindid = 4
  AND pcs.capacity IN (1000, 4000, 8000);


-ISSO AGORA PARA VERIFICAR O QUE RESTOU E ANALISAR UM A UM

select pc.id, pcs.capacity, c.name, p.name
from personcompressor pc
left join personcompressorsellable pcs on pc.id = pcs.personcompressorid
left join compressor c on c.id = pc.compressorid
left join person p on p.id = pc.personid
where pc.oiltypeid = 0;


RESETAR O CLOUDTASK PARA REENVIAR OS REGISTROS PARA A NÚVEM


*/




