UPDATE compressorsellable SET
	statusid = @statusid,
    productid = @productid,
	serviceid = @serviceid,
	quantity = @quantity,
	userid = @userid
WHERE compressorsellable.id = @id;