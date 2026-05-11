SELECT
	compressorunit.id,
	compressorunit.creation,
    compressorunit.statusid,
	compressorunit.name,
	product.id AS productid,
	product.name AS productname
FROM compressorunit
LEFT JOIN product ON compressorunit.productid = product.id
WHERE compressorunit.id = @id;