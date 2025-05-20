SELECT
	evaluation.id evaluation,
	person.shortname customer,
	CONCAT(city.name, '-', state.shortname) city,
    compressor.name compressor,
    personcompressor.serialnumber,
	evaluation.evaluationdate + INTERVAL
		(
			(
				SELECT
					MIN(evaluationpart.currentcapacity)
				FROM evaluationpart 
				LEFT JOIN personcompressorpart ON personcompressorpart.id = evaluationpart.personcompressorpartid
				WHERE evaluationpart.evaluationid = evaluation.id and personcompressorpart.parttypeid = 0
			) / evaluation.averageworkload
		) DAY workedhourexchangeday,        
	evaluation.evaluationdate + INTERVAL
		(
			(
				SELECT
					MIN(evaluationpart.currentcapacity)
				FROM evaluationpart 
				LEFT JOIN personcompressorpart ON personcompressorpart.id = evaluationpart.personcompressorpartid
				WHERE evaluationpart.evaluationid = evaluation.id and personcompressorpart.parttypeid = 1
			)
		) DAY elapseddayexchangeday,
    IFNULL(LEAST((SELECT workedhourexchangeday), (SELECT elapseddayexchangeday)), IFNULL((SELECT workedhourexchangeday), (SELECT elapseddayexchangeday))) nextexchange	
FROM evaluation
INNER JOIN person ON person.id = evaluation.customerid
INNER JOIN personaddress ON personaddress.personid = person.id
INNER JOIN personcompressor ON personcompressor.id = evaluation.personcompressorid
INNER JOIN compressor ON compressor.id = personcompressor.compressorid
INNER JOIN city ON city.id = personaddress.cityid
INNER JOIN state ON state.id = city.stateid
LEFT JOIN cityroute ON cityroute.cityid = city.id
LEFT JOIN route ON route.id = cityroute.routeid
LEFT JOIN evaluationpart ON evaluationpart.evaluationid = evaluation.id
LEFT JOIN personcompressorpart ON personcompressorpart.id = evaluationpart.personcompressorpartid
WHERE
	evaluation.evaluationdate = (
									SELECT
										MAX(ev.evaluationdate)
									FROM evaluation ev
                                    INNER JOIN personcompressor pc ON pc.id = ev.personcompressorid
                                    WHERE pc.id = personcompressor.id AND ev.statusid = 1
								) AND
    person.controlmaintenance = 1 AND
    personcompressor.statusid = 0 AND
	personaddress.ismainaddress = 1 AND
	IFNULL(person.id,'') LIKE @personid AND
    IFNULL(person.document,'') LIKE CONCAT('%', @persondocument, '%') AND
    (
        IFNULL(person.name, '') LIKE CONCAT('%', @personname, '%') OR 
        IFNULL(person.shortname, '') LIKE CONCAT('%', @personname, '%')
    ) AND
    IFNULL(personaddress.zipcode, '') LIKE CONCAT('%', @zipcode, '%') AND
    (    
        IFNULL(personaddress.street, '') LIKE CONCAT('%', @address, '%') OR 
        IFNULL(personaddress.complement, '') LIKE CONCAT('%', @address, '%') OR 
        IFNULL(personaddress.number, '') LIKE CONCAT('%', @address, '%') OR
        IFNULL(personaddress.district, '') LIKE CONCAT('%', @address, '%')
    ) AND
    IFNULL(compressor.name, '') LIKE CONCAT('%', @compressorname, '%') AND
    IFNULL(personcompressor.serialnumber, '') LIKE CONCAT('%', @serialnumber, '%') AND
    IFNULL(personcompressor.patrimony, '') LIKE CONCAT('%', @patrimony, '%') AND
    IFNULL(personcompressor.sector, '') LIKE CONCAT('%', @sector, '%') AND
    IFNULL(city.name, '') LIKE CONCAT('%', @city, '%') AND
    IFNULL(state.name, '') LIKE CONCAT('%', @state, '%') AND
    IFNULL(route.name, '') LIKE CONCAT('%', @route, '%')
GROUP BY personcompressor.id
HAVING nextexchange BETWEEN @nextexchangei AND @nextexchangef
ORDER BY nextexchange ASC;
