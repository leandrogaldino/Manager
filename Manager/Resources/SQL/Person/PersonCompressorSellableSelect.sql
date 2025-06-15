SELECT
	personcompressorpart.id,
	personcompressorpart.creation,
	personcompressorpart.statusid,
	personcompressorpart.partbindid,
	personcompressorpart.parttypeid,
	personcompressorpart.itemname,
	IFNULL(personcompressorpart.productid, 0) AS productid,
	personcompressorpart.quantity,
	personcompressorpart.capacity
FROM personcompressorpart
WHERE 
	personcompressorpart.personcompressorid = @personcompressorid AND
	personcompressorpart.parttypeid = @parttypeid
ORDER BY personcompressorpart.id;
