UPDATE route SET
    statusid =  @statusid,
    name = @name,
    userid = @userid
WHERE route.id = @id;