SELECT
	person.shortname AS technician,
    IFNULL(
		SUM(
			TIME_TO_SEC(
				TIMEDIFF(CONCAT(evaluation.evaluationdate, ' ', evaluation.endtime, ':00'), CONCAT(evaluation.evaluationdate, ' ', evaluation.starttime, ':00')
			)
		) / 60 / 60
	),0) hours
FROM person
LEFT JOIN evaluationtechnician ON evaluationtechnician.technicianid = person.id
LEFT JOIN evaluation ON evaluation.id = evaluationtechnician.evaluationid AND evaluation.statusid = 1 AND evaluation.evaluationtypeid = @evaluationtypeid AND MONTHNAME(evaluation.evaluationdate) = @month AND YEAR(evaluation.evaluationdate) = @year
WHERE
	person.istechnician = 1
GROUP BY person.id
ORDER BY person.name ASC;