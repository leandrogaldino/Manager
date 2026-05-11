UPDATE cash SET
    statusid =  @statusid,
    userid = @userid
WHERE cash.id = @id;