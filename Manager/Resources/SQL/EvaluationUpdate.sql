UPDATE evaluation SET
    statusid =  @statusid,
    evaluationtypeid = @evaluationtypeid,
    needproposalid = @needproposalid,
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
    documentname = @documentname,
    signaturename = @signaturename,
    rejectreason = @rejectreason,
    userid = @userid
WHERE evaluation.id = @id;