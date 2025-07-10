UPDATE personcompressorsellable SET
	statusid = @statusid,
	sellablebindid = @sellablebindid,
	itemname = @itemname,
	productid = @productid,
	quantity = @quantity,
	capacity = @capacity,
	userid = @userid
WHERE personcompressorsellable.id = @id;