UPDATE product SET
	id = @id,
    statusid = @statusid,
	name = @name,
	internalname = @internalname,
	location = @location,
	minimumquantity = @minimumquantity,
	maximumquantity = @maximumquantity,
	unitid = @unitid,
	familyid = @familyid,
	groupid = @groupid,
	grossweight = @grossweight,
	netweight = @netweight,
	dimensions = @dimensions,
	sku = @sku,
	note = @note,
	userid = @userid
WHERE product.id = @id;