SELECT 
    YEAR(evaluation.evaluationdate) AS yearnumber,
    UCASE(MONTHNAME(evaluation.evaluationdate)) AS monthname
FROM evaluation
WHERE evaluation.statusid = 1
GROUP BY yearnumber, MONTH(evaluation.evaluationdate), monthname
ORDER BY yearnumber DESC, MONTH(evaluation.evaluationdate) ASC;
