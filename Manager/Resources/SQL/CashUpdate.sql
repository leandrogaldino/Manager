UPDATE cash SET
	id = @id,
    note = @note,
	documentpath = @documentpath,
	userid = @userid
WHERE cash.id = @id;