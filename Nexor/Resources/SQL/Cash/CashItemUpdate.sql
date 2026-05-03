UPDATE cashitem SET
	itemtypeid = @itemtypeid,
	itemcategoryid = @itemcategoryid,
	description = @description,
	documentdate = @documentdate,
	documentnumber = @documentnumber,
	value = @value,
	userid = @userid
WHERE cashitem.id = @id;