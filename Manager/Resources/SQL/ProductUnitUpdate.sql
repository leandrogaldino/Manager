UPDATE productunit SET
    statusid =  @statusid,
    name = @name,
    shortname = @shortname,
    userid = @userid
WHERE productunit.id = @id;