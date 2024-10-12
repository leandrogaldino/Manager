UPDATE request SET
    statusid =  @statusid,
    destination = @destination,
    responsible = @responsible,
    note = @note,
    documentpath = @documentpath,
    userid = @userid
WHERE request.id = @id;