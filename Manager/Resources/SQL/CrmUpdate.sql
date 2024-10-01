UPDATE crm SET
	id = @id,
    statusid = @statusid,
	customerid = @customerid,
	responsibleid = @responsibleid,
	subject = @subject,
	userid = @userid
WHERE crm.id = @id;