SELECT
    evaluation.id,
    evaluation.creation As 'Criação',
    CASE 
		WHEN evaluation.statusid = 0 THEN "DESAPROVADA"
        WHEN evaluation.statusid = 1 THEN "APROVADA"
        WHEN evaluation.statusid = 2 THEN "REJEITADA"
        WHEN evaluation.statusid = 3 THEN "REVISADA"
	END AS 'Status',
    CASE
        WHEN evaluation.evaluationtypeid = 0 THEN "LEVANTAMENTO"
        WHEN evaluation.evaluationtypeid = 1 THEN "EXECUCAO"
    END AS 'Tipo',
    evaluation.evaluationdate AS 'Data Avaliação',
    evaluation.evaluationnumber AS 'Nº Avaliação',
    customer.shortname AS 'Cliente',
    evaluation.responsible AS 'Responsável',
    CONCAT(compressor.name, IF(personcompressor.serialnumber IS NOT NULL AND personcompressor.serialnumber <> '', CONCAT(' NS: ', personcompressor.serialnumber), '')) AS 'Compressor',
    evaluation.horimeter AS 'Horímetro',
    evaluation.averageworkload AS 'CMT',
    CONCAT(FLOOR(TIME_TO_SEC(TIMEDIFF(CONCAT(evaluation.evaluationdate, ' ', evaluation.endtime, ':00'), CONCAT(evaluation.evaluationdate, ' ', evaluation.starttime, ':00'))) / 60 / 60),':', LPAD(ROUND((TIME_TO_SEC(TIMEDIFF(CONCAT(evaluation.evaluationdate, ' ', evaluation.endtime, ':00'), CONCAT(evaluation.evaluationdate, ' ', evaluation.starttime, ':00'))) / 60 / 60 - FLOOR(TIME_TO_SEC(TIMEDIFF(CONCAT(evaluation.evaluationdate, ' ', evaluation.endtime, ':00'), CONCAT(evaluation.evaluationdate, ' ', evaluation.starttime, ':00'))) / 60 / 60)) * 60) % 60,2,0)) AS 'Tempo',
    REPLACE(evaluation.technicaladvice, '\n', ' ') AS 'Parecer Técnico'
FROM evaluation
LEFT JOIN personcompressor ON personcompressor.id = evaluation.personcompressorid
LEFT JOIN compressor ON compressor.id = personcompressor.compressorid
INNER JOIN evaluationtechnician ON evaluationtechnician.evaluationid = evaluation.id
LEFT JOIN person AS technician ON technician.id = evaluationtechnician.technicianid
LEFT JOIN person AS customer ON customer.id = evaluation.customerid
WHERE
    IFNULL(evaluation.id, '') LIKE @id AND
    FIND_IN_SET(evaluation.statusid, @statusid) AND
    IFNULL(evaluation.evaluationtypeid, '') LIKE @evaluationtypeid AND
    IFNULL(evaluation.evaluationnumber,'') LIKE CONCAT('%', @evaluationnumber, '%') AND
    IFNULL(evaluation.technicaladvice,'') LIKE CONCAT('%', @technicaladvice, '%') AND
    IFNULL(technician.id,'') LIKE @technicianid AND
    IFNULL(technician.document,'') LIKE CONCAT('%', @techniciandocument, '%') AND
    (
        IFNULL(technician.name, '') LIKE CONCAT('%', @technicianname, '%') OR 
        IFNULL(technician.shortname, '') LIKE CONCAT('%', @technicianname, '%')
    ) AND
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
    evaluation.horimeter BETWEEN @horimetermin AND @horimetermax AND
    evaluation.creation BETWEEN @creationi AND @creationf AND
    evaluation.evaluationdate BETWEEN @evaluationdatei AND @evaluationdatef
GROUP BY evaluation.id
ORDER BY evaluation.id;