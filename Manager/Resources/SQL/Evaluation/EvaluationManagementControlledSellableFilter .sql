SELECT
    IFNULL(product.name, service.name) AS item,
	evaluationcontrolledsellable.currentcapacity,
	(
		SELECT 
			MAX(ev.evaluationdate)
		FROM evaluation ev
		LEFT JOIN evaluationcontrolledsellable ep ON ep.evaluationid = ev.id
		LEFT JOIN personcompressorsellable pcp ON pcp.id = ep.personcompressorsellableid
		WHERE 
			(ep.sold = 1 OR ep.lost = 1) AND 
			pcp.id = evaluationcontrolledsellable.personcompressorsellableid
	) previousexchange,  
	CASE
		WHEN personcompressorsellable.controltypeid = 0 THEN
			evaluation.evaluationdate + INTERVAL(evaluationcontrolledsellable.currentcapacity / evaluation.averageworkload) DAY
        WHEN personcompressorsellable.controltypeid = 1 THEN
			evaluation.evaluationdate + INTERVAL(evaluationcontrolledsellable.currentcapacity) DAY
	END nextexchange
FROM evaluationcontrolledsellable
INNER JOIN personcompressorsellable ON personcompressorsellable.id = evaluationcontrolledsellable.personcompressorsellableid
INNER JOIN evaluation ON evaluation.id = evaluationcontrolledsellable.evaluationid
LEFT JOIN product ON product.id = personcompressorsellable.productid
LEFT JOIN service ON service.id = personcompressorsellable.serviceid
WHERE
	evaluation.id = @evaluationid AND
    personcompressorsellable.controltypeid = @controltypeid
ORDER BY nextexchange ASC;