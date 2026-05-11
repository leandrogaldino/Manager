UPDATE cashflowauthorized SET
	authorizedid = @authorizedid,
	userid = @userid
WHERE cashflowauthorized.id = @id;