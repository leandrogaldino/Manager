SELECT
    IFNULL(personcompressorpart.itemname, product.name) AS item,
	evaluationpart.currentcapacity,
	(
		SELECT 
			MAX(ev.evaluationdate)
		FROM evaluation ev
		LEFT JOIN evaluationpart ep ON ep.evaluationid = ev.id
		LEFT JOIN personcompressorpart pcp ON pcp.id = ep.personcompressorpartid
		WHERE 
			(ep.sold = 1 OR ep.lost = 1) AND 
			pcp.id = evaluationpart.personcompressorpartid
	) previousexchange,  
	CASE
		WHEN personcompressorpart.parttypeid = 0 THEN
			evaluation.evaluationdate + INTERVAL(evaluationpart.currentcapacity / evaluation.averageworkload) DAY
        WHEN personcompressorpart.parttypeid = 1 THEN
			evaluation.evaluationdate + INTERVAL(evaluationpart.currentcapacity) DAY
	END nextexchange
FROM evaluationpart
INNER JOIN personcompressorpart ON personcompressorpart.id = evaluationpart.personcompressorpartid
INNER JOIN evaluation ON evaluation.id = evaluationpart.evaluationid
LEFT JOIN product ON product.id = personcompressorpart.productid
WHERE
	evaluation.id = @evaluationid AND
    personcompressorpart.parttypeid = @parttypeid
GROUP BY personcompressorpart.id
ORDER BY nextexchange ASC;