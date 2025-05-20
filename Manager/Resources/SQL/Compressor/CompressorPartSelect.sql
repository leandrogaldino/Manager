SELECT
	compressorpart.id,
	compressorpart.creation,
	compressorpart.statusid,
	compressorpart.parttypeid,
    compressorpart.itemname,
	IFNULL(compressorpart.productid, 0) AS productid,
	compressorpart.quantity
FROM compressorpart
WHERE 
	compressorpart.compressorid = @compressorid AND
	compressorpart.parttypeid = @parttypeid
ORDER BY compressorpart.id;