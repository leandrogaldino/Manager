SELECT
	COUNT(evaluation.id)
FROM evaluation 
WHERE
	evaluation.id <> @evaluationid AND
	personcompressorid = @personcompressorid AND
	FIND_IN_SET(evaluation.statusid, @statusid);