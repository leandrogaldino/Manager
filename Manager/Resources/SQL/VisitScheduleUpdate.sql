UPDATE visitschedule SET
    statusid =  @statusid,
    visitdate = @visitdate,
    calltypeid = @calltypeid,
    customerid = @customerid,
    personcompressorid = @personcompressorid,
    instructions = @instructions,
    evaluationid = @evaluationid,
    lastupdate = @lastupdate
WHERE visitschedule.id = @id;