UPDATE user SET
    statusid =  @statusid,
    username = @username,
    personid = @personid,
    note = @note,
    userid = @userid
WHERE user.id = @id;