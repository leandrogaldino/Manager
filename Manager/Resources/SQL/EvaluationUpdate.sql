UPDATE evaluation SET
    statusid =  @statusid,
    evaluationtypeid = @evaluationtypeid,
    evaluationdate = @evaluationdate,
    starttime = @starttime,
    endtime = @endtime,
    evaluationnumber = @evaluationnumber,
    customerid = @customerid,
    responsible = @responsible,
    personcompressorid = @personcompressorid,
    horimeter = @horimeter,
    manualaverageworkload = @manualaverageworkload,
    averageworkload = @averageworkload,
    technicaladvice = @technicaladvice,
    documentpath = @documentpath,
    rejectreason = @rejectreason,
    userid = @userid
WHERE evaluation.id = @id;