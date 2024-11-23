SELECT
	visitschedule.id,
	visitschedule.creation,
    visitschedule.statusid,
	visitschedule.visitdate,
	visitschedule.visitetypeid,
	visitschedule.customerid,
	visitschedule.compressorid,
	visitschedule.instructions,
	visitschedule.evaluationid
FROM visitschedule
WHERE visitschedule.id = @id;