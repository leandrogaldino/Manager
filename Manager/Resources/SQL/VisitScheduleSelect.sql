SELECT
	visitschedule.id,
	visitschedule.creation,
    visitschedule.statusid,
	visitschedule.visitdate,
	visitschedule.visittypeid,
	visitschedule.customerid,
	visitschedule.personcompressorid,
	visitschedule.instructions,
	visitschedule.evaluationid,
	visitschedule.synchronized,
	visitschedule.lastupdate
FROM visitschedule
WHERE visitschedule.id = @id;