UPDATE cashflow SET
    statusid =  @statusid,
    name = @name,
    userid = @userid
WHERE cashflow.id = @id;