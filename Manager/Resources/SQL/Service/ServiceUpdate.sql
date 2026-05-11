UPDATE service SET
    statusid =  @statusid,
    name = @name,
    note = @note,
    userid = @userid
WHERE service.id = @id;