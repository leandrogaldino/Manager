SELECT
    visitschedule.id,
    visitschedule.creation As 'Criação',
    CASE 
		WHEN visitschedule.statusid = 0 THEN "PENDENTE"
        WHEN visitschedule.statusid = 1 THEN "FINALIZADA"
        WHEN visitschedule.statusid = 2 THEN "CANCELADA"
	END AS 'Status',
    visitschedule.scheduleddate As 'Data Agendada',
    visitschedule.performeddate As 'Data Realizada',
    CASE
        WHEN visitschedule.calltypeid = 1 THEN "LEVANTAMENTO"
        WHEN visitschedule.calltypeid = 2 THEN "PREVENTIVA"
        WHEN visitschedule.calltypeid = 3 THEN "CORRETIVA"
        WHEN visitschedule.calltypeid = 4 THEN "CONTRATO"
    END AS 'Tipo',
    customer.shortname AS 'Cliente',    
    CONCAT(compressor.name, IF(personcompressor.serialnumber IS NOT NULL AND personcompressor.serialnumber <> '', CONCAT(' NS: ', personcompressor.serialnumber), '')) AS 'Compressor',
    technician.shortname AS 'Técnico',
    REPLACE(visitschedule.instructions, '\n', ' ') AS 'Instruções'
FROM visitschedule
JOIN personcompressor ON personcompressor.id = visitschedule.personcompressorid
JOIN compressor ON compressor.id = personcompressor.compressorid
JOIN person AS customer ON customer.id = visitschedule.customerid
JOIN person AS technician ON technician.id = visitschedule.technicianid
WHERE
    IFNULL(visitschedule.id, '') LIKE @id AND
    FIND_IN_SET(visitschedule.statusid, @statusid) AND
    IFNULL(visitschedule.calltypeid, '') LIKE @calltypeid AND    
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
    IFNULL(technician.id,'') LIKE @technicianid AND
    IFNULL(technician.document,'') LIKE CONCAT('%', @techniciandocument, '%') AND
    (
        IFNULL(technician.name, '') LIKE CONCAT('%', @technicianname, '%') OR 
        IFNULL(technician.shortname, '') LIKE CONCAT('%', @technicianname, '%')
    ) AND
    visitschedule.creation BETWEEN @creationi AND @creationf AND
    visitschedule.scheduleddate BETWEEN @scheduleddatei AND @scheduleddatef AND
    (
        (visitschedule.performeddate IS NOT NULL 
         AND visitschedule.performeddate BETWEEN @performeddatei AND @performeddatef)
        OR (@performed = TRUE AND visitschedule.performeddate IS NULL)
    )
ORDER BY visitschedule.id;