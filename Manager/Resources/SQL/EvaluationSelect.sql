SELECT
	evaluation.id,
	evaluation.creation,
    evaluation.statusid,
	evaluation.evaluationtypeid,
	evaluation.evaluationdate,
	evaluation.starttime,
	evaluation.endtime,
	evaluation.evaluationnumber,
	evaluation.customerid,
	evaluation.responsible,
	evaluation.personcompressorid,
	evaluation.horimeter,
	evaluation.manualaverageworkload,
	evaluation.averageworkload,
	evaluation.technicaladvice,
	evaluation.documentpath,
	evaluation.signaturepath,
	evaluation.rejectreason,
	evaluation.userid
FROM evaluation
WHERE evaluation.id = @id;