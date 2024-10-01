UPDATE productgroup SET
    statusid =  @statusid,
    name = @name,
    userid = @userid
WHERE productgroup.id = @id;