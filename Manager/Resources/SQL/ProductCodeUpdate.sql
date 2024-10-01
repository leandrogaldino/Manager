UPDATE productcode SET
    name = @name,
    code = @code,
    userid = @userid
WHERE productcode.id = @id;