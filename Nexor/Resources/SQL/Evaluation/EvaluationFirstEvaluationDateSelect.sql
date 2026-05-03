SELECT evaluation.evaluationdate
FROM evaluation
WHERE personcompressorid = @personcompressorid
ORDER BY evaluationdate LIMIT 1;