UPDATE personcompressorpart SET
	statusid = @statusid,
	partbindid = @partbindid,
	itemname = @itemname,
	productid = @productid,
	quantity = @quantity,
	capacity = @capacity,
	userid = @userid
WHERE personcompressorpart.id = @id;