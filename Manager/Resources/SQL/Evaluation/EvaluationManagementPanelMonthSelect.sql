SELECT
	UCASE(MONTHNAME(evaluation.evaluationdate)) AS evaluationmonth
FROM evaluation
WHERE
	YEAR(evaluation.evaluationdate) = @year AND
	evaluation.statusid = 1
GROUP BY MONTHNAME(evaluation.evaluationdate)
ORDER BY evaluation.evaluationdate DESC;