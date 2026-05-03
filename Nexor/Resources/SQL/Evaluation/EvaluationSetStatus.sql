UPDATE evaluation SET
    statusid =  @statusid,
    rejectreason = @rejectreason,
    userid = @userid
WHERE evaluation.id = @id;