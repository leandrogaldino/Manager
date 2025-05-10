UPDATE sellablepricetable SET
    statusid =  @statusid,
    name = @name,
    userid = @userid
WHERE sellablepricetable.id = @id;