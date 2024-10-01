UPDATE productpricetable SET
    statusid =  @statusid,
    name = @name,
    userid = @userid
WHERE productpricetable.id = @id;