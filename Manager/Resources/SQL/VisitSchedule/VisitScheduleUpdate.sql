UPDATE visitschedule SET
    statusid =  @statusid,
    scheduleddate = @scheduleddate,
    performeddate = @performeddate,
    calltypeid = @calltypeid,
    customerid = @customerid,
    personcompressorid = @personcompressorid,
    technicianid = @technicianid,
    instructions = @instructions,
    evaluationid = @evaluationid,
    overridedvisitscheduleid = @overridedvisitscheduleid,
    userid = @userid
WHERE visitschedule.id = @id;