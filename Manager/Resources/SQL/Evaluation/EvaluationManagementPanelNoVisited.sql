SELECT
	person.id AS personid,
	person.shortname AS customer,
	CONCAT(city.name, '-', state.shortname) AS city,
	compressor.name AS compressor,   
	personcompressor.serialnumber,
    IFNULL(
		(
			SELECT 
				CASE
					WHEN count(personcompressor.id) > 0 THEN 1
				END
			WHERE 
				personcompressor.id IN (
											SELECT 
												ev.personcompressorid
											FROM evaluation ev
										)
		),
	0) As hasevaluation
FROM personcompressor
JOIN person ON person.id = personcompressor.personid
INNER JOIN compressor ON compressor.id = personcompressor.compressorid
LEFT JOIN evaluation ON evaluation.personcompressorid = personcompressor.id
INNER JOIN personaddress ON personaddress.personid = person.id
INNER JOIN city ON city.id = personaddress.cityid
INNER JOIN state ON state.id = city.stateid
WHERE
	person.controlmaintenance = 1 AND
	personaddress.ismainaddress = 1
GROUP BY personcompressor.id, city
HAVING hasevaluation = 0
ORDER BY person.name ASC;