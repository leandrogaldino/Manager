SELECT
	visitschedule.id,
	visitschedule.creation,
    visitschedule.statusid,
	visitschedule.scheduleddate,
	visitschedule.performeddate,
	visitschedule.calltypeid,
	visitschedule.customerid,
	visitschedule.personcompressorid,
	visitschedule.technicianid,
	visitschedule.instructions,
	visitschedule.evaluationid
FROM visitschedule
WHERE visitschedule.id = @id;