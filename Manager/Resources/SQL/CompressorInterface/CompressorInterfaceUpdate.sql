UPDATE compressorinterface SET
    statusid =  @statusid,
    name = @name,
    productid = @productid,
    directionid = @directionid,
    userid = @userid
WHERE compressorinterface.id = @id;