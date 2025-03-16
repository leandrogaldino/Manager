SELECT
	visitschedule.id,
	visitschedule.creation,
    visitschedule.statusid,
	visitschedule.visitdate,
	visitschedule.calltypeid,
	visitschedule.customerid,
	visitschedule.personcompressorid,
	visitschedule.instructions,
	visitschedule.evaluationid,
	visitschedule.lastupdate
FROM visitschedule
WHERE visitschedule.id = @id;