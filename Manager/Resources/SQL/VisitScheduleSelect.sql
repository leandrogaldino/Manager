SELECT
	visitschedule.id,
	visitschedule.creation,
    visitschedule.statusid,
	visitschedule.visitdate,
	visitschedule.visittypeid,
	visitschedule.customerid,
	visitschedule.personcompressorid,
	visitschedule.instructions,
	visitschedule.evaluationid
FROM visitschedule
WHERE visitschedule.id = @id;