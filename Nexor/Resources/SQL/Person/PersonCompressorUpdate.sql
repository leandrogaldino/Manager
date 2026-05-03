UPDATE personcompressor SET
	statusid = @statusid,
    compressorid = @compressorid,
	compressorinterfaceid = @compressorinterfaceid,
	compressorunitid = @compressorunitid,
	controlledid = @controlledid,
	serialnumber = @serialnumber,
	patrimony = @patrimony,
	sector = @sector,
	unitcapacity = @unitcapacity,
	note = @note,
	userid = @userid
WHERE personcompressor.id = @id;