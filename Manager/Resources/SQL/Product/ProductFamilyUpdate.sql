UPDATE productfamily SET
    statusid =  @statusid,
    name = @name,
    userid = @userid
WHERE productfamily.id = @id;