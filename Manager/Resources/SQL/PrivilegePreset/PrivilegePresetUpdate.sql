UPDATE privilegepreset SET
    statusid =  @statusid,
    name = @name,
    userid = @userid
WHERE privilegepreset.id = @id;