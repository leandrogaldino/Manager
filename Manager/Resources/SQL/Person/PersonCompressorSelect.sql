SELECT
	personcompressor.id,
	personcompressor.creation,
	personcompressor.statusid,
	personcompressor.compressorid,
	personcompressor.compressorinterfaceid,
	personcompressor.compressorunitid,
	personcompressor.controlledid,
	compressor.name AS compressorname,
	compressorinterface.name AS compressorinterfacename,
	compressorunit.name AS compressorunitname,
    personcompressor.serialnumber,
	personcompressor.patrimony,
	personcompressor.sector,
	personcompressor.unitcapacity,
	personcompressor.note
FROM personcompressor
LEFT JOIN compressor ON compressor.id = personcompressor.compressorid
LEFT JOIN compressorinterface ON compressorinterface.id = personcompressor.compressorinterfaceid
LEFT JOIN compressorunit ON compressorunit.id = personcompressor.compressorunitid
WHERE personcompressor.personid = @personid;