UPDATE visitschedule SET
    statusid =  @statusid,
    visitetypeid = @visitetypeid,
    customerid = @customerid,
    compressorid = @compressorid,
    instructions = @instructions,
    evaluationid = @evaluationid
WHERE visitschedule.id = @id;