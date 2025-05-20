UPDATE personcompressor SET
	statusid = @statusid,
    compressorid = @compressorid,
	serialnumber = @serialnumber,
	patrimony = @patrimony,
	sector = @sector,
	unitcapacity = @unitcapacity,
	note = @note,
	userid = @userid
WHERE personcompressor.id = @id;