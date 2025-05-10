UPDATE service SET
    statusid =  @statusid,
    name = @name,
    servicecode = @servicecode,
    note = @note,
    lastupdate = @lastupdate
WHERE service.id = @id;