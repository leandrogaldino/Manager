SELECT
    MONTH(evaluation.evaluationdate) AS MonthNumber,
    MONTHNAME(evaluation.evaluationdate) AS MonthName,
    YEAR(evaluation.evaluationdate) AS EvaluationYear,
    COUNT(evaluation.id) AS CountEvaluation
FROM evaluation
INNER JOIN person 
    ON person.id = evaluation.customerid
INNER JOIN personcompressor 
    ON personcompressor.personid = person.id 
   AND personcompressor.id = evaluation.personcompressorid
WHERE
    YEAR(evaluation.evaluationdate) = @year
    AND evaluation.statusid = 1
    AND person.statusid = 0
    AND person.controlmaintenance = 1
    AND personcompressor.statusid = 0
GROUP BY EvaluationYear, MonthNumber, MonthName
ORDER BY MonthNumber ASC;