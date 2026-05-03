UPDATE request SET
    statusid =  @statusid,
    destination = @destination,
    responsible = @responsible,
    note = @note,
    documentname = @documentname,
    userid = @userid
WHERE request.id = @id;