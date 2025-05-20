UPDATE crm SET
    statusid =  @statusid,
    userid = @userid
WHERE crm.id = @id;