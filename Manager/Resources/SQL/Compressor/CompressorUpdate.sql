UPDATE compressor SET
    statusid =  @statusid,
    manufacturerid = @manufacturerid,
    name = @name,
    userid = @userid
WHERE compressor.id = @id;