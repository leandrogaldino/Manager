UPDATE pricetable Set
    statusid =  @statusid,
    name = @name
    userid = @userid
WHERE pricetable.id = @id;