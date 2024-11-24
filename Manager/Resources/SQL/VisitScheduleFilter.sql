SELECT
    visitschedule.id,
    visitschedule.creation As 'Criação',
    CASE 
		WHEN visitschedule.statusid = 0 THEN "PENDENTE"
        WHEN visitschedule.statusid = 1 THEN "INICIADA"
        WHEN visitschedule.statusid = 2 THEN "FINALIZADA"
        WHEN visitschedule.statusid = 3 THEN "CANCELADA"
	END AS 'Status',
    visitschedule.visitdate As 'Data Visita',
    CASE
        WHEN visitschedule.visittypeid = 0 THEN "LEVANTAMENTO"
        WHEN visitschedule.visittypeid = 1 THEN "PREVENTIVA"
        WHEN visitschedule.visittypeid = 2 THEN "CHAMADO"
        WHEN visitschedule.visittypeid = 3 THEN "CONTRATO"
    END AS 'Tipo',
    customer.shortname AS 'Cliente',    
    CONCAT(compressor.name, IF(personcompressor.serialnumber IS NOT NULL AND personcompressor.serialnumber <> '', CONCAT(' NS: ', personcompressor.serialnumber), '')) AS 'Compressor',
    REPLACE(visitschedule.instructions, '\n', ' ') AS 'Instruções',
    visitschedule.synchronized AS 'Sincronizado'
FROM visitschedule
LEFT JOIN personcompressor ON personcompressor.id = visitschedule.personcompressorid
LEFT JOIN compressor ON compressor.id = personcompressor.compressorid
LEFT JOIN person AS customer ON customer.id = visitschedule.customerid
WHERE
    IFNULL(visitschedule.id, '') LIKE @id AND
    FIND_IN_SET(visitschedule.statusid, @statusid) AND
    IFNULL(visitschedule.visittypeid, '') LIKE @visittypeid AND    
    IFNULL(visitschedule.instructions,'') LIKE CONCAT('%', @instructions, '%') AND  
    IFNULL(customer.id,'') LIKE @customerid AND
    IFNULL(customer.document,'') LIKE CONCAT('%', @customerdocument, '%') AND
    (
        IFNULL(customer.name, '') LIKE CONCAT('%', @customername, '%') OR 
        IFNULL(customer.shortname, '') LIKE CONCAT('%', @customername, '%')
    ) AND
    IFNULL(compressor.name, '') LIKE CONCAT('%', @compressorname, '%') AND
    IFNULL(personcompressor.serialnumber, '') LIKE CONCAT('%', @serialnumber, '%') AND
    IFNULL(personcompressor.patrimony, '') LIKE CONCAT('%', @patrimony, '%') AND
    IFNULL(personcompressor.sector, '') LIKE CONCAT('%', @sector, '%') AND
    visitschedule.creation BETWEEN @creationi AND @creationf AND
    visitschedule.visitdate BETWEEN @visitdatei AND @visitdatef
GROUP BY visitschedule.id
ORDER BY visitschedule.id;