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
	note = @note,
	userid = @userid
WHERE product.id = @id;