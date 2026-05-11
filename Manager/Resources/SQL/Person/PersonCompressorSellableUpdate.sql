UPDATE personcompressorsellable SET
	statusid = @statusid,
	sellablebindid = @sellablebindid,
	productid = @productid,
	serviceid = @serviceid,
	quantity = @quantity,
	capacity = @capacity,
	userid = @userid
WHERE personcompressorsellable.id = @id;