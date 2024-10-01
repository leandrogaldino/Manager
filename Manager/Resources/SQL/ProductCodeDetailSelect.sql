SELECT 
	productcode.name AS 'Nome',
    productcode.code AS 'Código'
FROM productcode
WHERE productcode.productid = @productid;