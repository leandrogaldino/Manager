UPDATE cashitemresponsible SET
	responsibleid = @responsibleid,
	userid = @userid
WHERE cashitemresponsible.id = @id;