SELECT
	COUNT(evaluation.evaluationdate)
FROM evaluation
WHERE
	evaluation.id <> @evaluationid AND
	evaluation.statusid = 1 AND
	evaluation.personcompressorid = @personcompressorid AND
    evaluation.evaluationdate = (
								  SELECT 
								    MAX(evaluation.evaluationdate)
								  FROM evaluation
								  WHERE evaluation.evaluationdate <= @evaluationdate AND
								    evaluation.personcompressorid = @personcompressorid AND
									evaluation.id <> @evaluationid
								);