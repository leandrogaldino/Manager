SELECT
	productcode.id,
	productcode.creation,
	productcode.name,
	productcode.code
FROM productcode
WHERE productcode.productid = @productid;