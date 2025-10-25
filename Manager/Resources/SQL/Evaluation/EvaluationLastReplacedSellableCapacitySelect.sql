SELECT ecs.currentcapacity FROM evaluation e
JOIN evaluationcontrolledsellable ecs ON ecs.evaluationid = e.id
WHERE ecs.personcompressorsellableid =  @personcompressorsellableid  AND (sold = 1 OR lost =1) AND e.evaluationdate <= @refevaluationdate
ORDER BY e.evaluationdate DESC
LIMIT 1;