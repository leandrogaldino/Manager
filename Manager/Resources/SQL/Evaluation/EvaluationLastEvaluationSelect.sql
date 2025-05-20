SELECT e.id
FROM evaluation AS e
WHERE e.personcompressorid = @personcompressorid
  AND e.evaluationdate = (
    SELECT MAX(evaluationdate)
    FROM evaluation
    WHERE personcompressorid = @personcompressorid
  );
