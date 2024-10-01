SELECT
	evaluation.evaluationdate + INTERVAL((personcompressor.unitcapacity - evaluation.horimeter) / evaluation.averageworkload) DAY AS nextchange
FROM evaluation
INNER JOIN personcompressor ON personcompressor.id = evaluation.personcompressorid
WHERE evaluation.id = @evaluationid;