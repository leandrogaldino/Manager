SELECT 
	productcode.name AS 'Nome',
    productcode.code AS 'C�digo'
FROM productcode
WHERE productcode.productid = @productid;