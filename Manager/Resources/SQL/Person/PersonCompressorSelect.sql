SELECT
	personcompressor.id,
	personcompressor.creation,
	personcompressor.statusid,
	personcompressor.compressorid,
    personcompressor.serialnumber,
	personcompressor.patrimony,
	personcompressor.sector,
	personcompressor.unitcapacity,
	personcompressor.note
FROM personcompressor
WHERE personcompressor.personid = @personid;