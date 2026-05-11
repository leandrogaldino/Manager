SELECT
	evaluationtechnician.id,
	evaluationtechnician.creation,
	evaluationtechnician.evaluationid,
	evaluationtechnician.technicianid
FROM evaluationtechnician
WHERE evaluationtechnician.evaluationid = @evaluationid;