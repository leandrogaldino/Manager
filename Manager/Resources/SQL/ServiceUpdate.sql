UPDATE service SET
    statusid =  @statusid,
    name = @name,
    servicecode = @servicecode,
    note = @note,
    userid = @userid
WHERE service.id = @id;