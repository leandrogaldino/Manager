UPDATE compressorpart SET
	statusid = @statusid,
	itemname = @itemname,
    productid = @productid,
	quantity = @quantity,
	userid = @userid
WHERE compressorpart.id = @id;