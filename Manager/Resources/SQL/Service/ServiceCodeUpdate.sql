UPDATE servicecode SET
    name = @name,
    code = @code,
    userid = @userid
WHERE servicecode.id = @id;