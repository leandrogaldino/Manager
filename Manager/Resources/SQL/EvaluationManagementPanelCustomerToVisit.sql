SELECT  
	evaluation.id AS evaluationid,
	personcompressor.id AS personcompressorid,
    person.shortname AS customer,
	CONCAT(city.name, '-', state.shortname) AS city,
    compressor.name AS compressor,
    personcompressor.serialnumber,
    MAX(evaluation.evaluationdate) evaluationdate
FROM personcompressor
INNER JOIN person on person.id = personcompressor.personid
LEFT JOIN evaluation on evaluation.personcompressorid = personcompressor.id
INNER JOIN compressor on compressor.id = personcompressor.compressorid
INNER JOIN personaddress ON personaddress.personid = person.id
INNER JOIN city ON city.id = personaddress.cityid
INNER JOIN state ON state.id = city.stateid
WHERE
	person.controlmaintenance = 1 AND
	personaddress.ismainaddress = 1 AND
	evaluation.statusid = 1
GROUP BY personcompressor.id
HAVING DATE_ADD(evaluationdate, interval @days day) <= curdate();