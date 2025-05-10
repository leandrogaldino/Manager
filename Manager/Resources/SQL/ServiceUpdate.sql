UPDATE service SET
    statusid =  @statusid,
    name = @name,
    servicecode = @servicecode,
    note = @note
WHERE service.id = @id;