UPDATE pricetable SET
    statusid =  @statusid,
    name = @name,
    userid = @userid
WHERE pricetable.id = @id;