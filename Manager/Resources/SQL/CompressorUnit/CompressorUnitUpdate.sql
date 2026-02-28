UPDATE compressorunit SET
    statusid =  @statusid,
    name = @name,
    productid = @productid,
    userid = @userid
WHERE compressorunit.id = @id;