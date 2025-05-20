SELECT
	compressor.id,
	compressor.creation,
    compressor.statusid,
	compressor.manufacturerid,
	compressor.name
FROM compressor
WHERE compressor.id = @id;