SELECT
	person.id AS personid,
	person.shortname AS customer,
	CONCAT(city.name, '-', state.shortname) AS city,
    compressor.name AS compressor,
    personcompressor.serialnumber,
	evaluation.horimeter,
	evaluation.evaluationdate + INTERVAL((personcompressor.unitcapacity - evaluation.horimeter) / evaluation.averageworkload) DAY AS nextexchange
FROM person
INNER JOIN personcompressor ON personcompressor.personid = person.id
INNER JOIN compressor ON compressor.id = personcompressor.compressorid
INNER JOIN evaluation ON evaluation.personcompressorid = personcompressor.id
INNER JOIN personaddress ON personaddress.personid = person.id
INNER JOIN city ON city.id = personaddress.cityid
INNER JOIN state ON state.id = city.stateid
WHERE
	personaddress.ismainaddress = 1 AND
	evaluation.evaluationdate = (SELECT MAX(ev.evaluationdate) FROM evaluation ev WHERE ev.personcompressorid = evaluation.personcompressorid)
HAVING nextexchange < NOW()
ORDER BY nextexchange;