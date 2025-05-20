UPDATE city SET
    statusid =  @statusid,
    name = @name,
    bigscode = @bigscode,
    stateid = @stateid,
    userid = @userid
WHERE city.id = @id;