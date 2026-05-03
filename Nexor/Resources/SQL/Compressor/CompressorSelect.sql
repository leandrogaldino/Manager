SELECT
	compressor.id,
	compressor.creation,
    compressor.statusid,
	IFNULL(compressor.manufacturerid, 0) manufacturerid,
	IFNULL(manufacturer.name, '') manufacturername,
	compressor.name
FROM compressor
LEFT JOIN person manufacturer ON compressor.manufacturerid = manufacturer.id
WHERE compressor.id = @id;