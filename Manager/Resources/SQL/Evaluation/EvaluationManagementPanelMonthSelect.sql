SELECT
    ANY_VALUE(UCASE(MONTHNAME(evaluation.evaluationdate))) AS evaluationmonth
FROM evaluation
WHERE
    YEAR(evaluation.evaluationdate) = @year
    AND evaluation.statusid = 1
GROUP BY MONTH(evaluation.evaluationdate)
ORDER BY MONTH(evaluation.evaluationdate) ASC;