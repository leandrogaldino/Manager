UPDATE cash SET
	id = @id,
    note = @note,
	documentname = @documentname,
	userid = @userid
WHERE cash.id = @id;