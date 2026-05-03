UPDATE requestitem SET
	statusid = @statusid,
	itemname = @itemname,
	productid = @productid,
	taked = @taked,
	returned = @returned,
	applied = @applied,
	lossed = @lossed,
	lossreason = @lossreason,
	userid = @userid
WHERE requestitem.id = @id;
