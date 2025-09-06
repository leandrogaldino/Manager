UPDATE visitschedule SET
    statusid =  @statusid,
    visitdate = @visitdate,
    calltypeid = @calltypeid,
    customerid = @customerid,
    personcompressorid = @personcompressorid,
    instructions = @instructions,
    evaluationid = @evaluationid,
    overridedvisitscheduleid = @overridedvisitscheduleid,
    lastupdate = @lastupdate,
    userid = @userid
WHERE visitschedule.id = @id;