UPDATE compressorinterface SET
    statusid =  @statusid,
    name = @name,
    productid = @productid,
    userid = @userid
WHERE compressorinterface.id = @id;