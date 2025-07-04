SELECT
	personcompressor.id,
	personcompressor.creation,
	personcompressor.statusid,
	personcompressor.compressorid,
	compressor.name AS compressorname,
    personcompressor.serialnumber,
	personcompressor.patrimony,
	personcompressor.sector,
	personcompressor.unitcapacity,
	personcompressor.note
FROM personcompressor
LEFT JOIN compressor ON compressor.id = personcompressor.compressorid
WHERE personcompressor.personid = @personid;