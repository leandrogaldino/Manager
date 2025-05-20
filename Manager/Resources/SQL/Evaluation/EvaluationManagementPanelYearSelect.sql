SELECT 
	YEAR(evaluation.evaluationdate) AS evaluationyear
FROM evaluation
WHERE 
	evaluation.statusid = 1
GROUP BY evaluationyear
ORDER BY evaluation.evaluationdate DESC