SELECT id
FROM evaluation
WHERE
    statusid = 1 AND
    evaluation.id <> @evaluationid AND
    personcompressorid = @personcompressorid AND
    evaluationdate <= @evaluationdate
ORDER BY evaluationdate DESC
LIMIT 1;