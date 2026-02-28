SELECT
	compressorinterface.id,
	compressorinterface.creation,
    compressorinterface.statusid,
	compressorinterface.name,
	product.id AS productid,
	product.name AS productname,
	compressorinterface.directionid
FROM compressorinterface
LEFT JOIN product ON compressorinterface.productid = product.id
WHERE compressorinterface.id = @id;