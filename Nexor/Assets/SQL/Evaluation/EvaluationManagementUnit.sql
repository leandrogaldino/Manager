SELECT
	IFNULL(
	  evaluation.evaluationdate + INTERVAL ((personcompressor.unitcapacity - evaluation.horimeter) / evaluation.averageworkload) DAY,
	  DATE('0001-01-01')
	) AS nextchange
FROM evaluation
INNER JOIN personcompressor ON personcompressor.id = evaluation.personcompressorid
WHERE evaluation.id = @evaluationid;