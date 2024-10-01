SELECT 
	productprovidercode.code AS 'Código',
	IFNULL(compressorpart.itemname, product.name) AS 'Item',
    compressorpart.quantity AS 'Qtd.'
FROM
    compressorpart
LEFT JOIN product ON product.id = compressorpart.productid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE
    compressorpart.compressorid = @compressorid AND
    compressorpart.parttypeid = @parttypeid;