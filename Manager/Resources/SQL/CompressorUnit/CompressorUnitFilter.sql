SELECT 
	compressorunit.id AS 'ID',
    compressorunit.creation AS 'Criação',
    CASE 
		WHEN compressorunit.statusid = 0 THEN "ATIVO"
        WHEN compressorunit.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    compressorunit.name AS 'Nome',
    CASE
        WHEN productprovidercode.code IS NOT NULL 
             AND productprovidercode.code <> ''
        THEN CONCAT(productprovidercode.code, ' - ', product.name)
        ELSE product.name
    END AS 'Produto'
FROM compressorunit
LEFT JOIN product ON compressorunit.productid = product.id
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE
	IFNULL(compressorunit.id, '') LIKE @id AND
    IFNULL(compressorunit.statusid, '') LIKE @statusid AND
    IFNULL(compressorunit.name, '') LIKE CONCAT('%', @name, '%') AND
    IFNULL(product.id,'') LIKE @productid AND
    IFNULL(productprovidercode.code,'') LIKE @productcode AND
    (
        IFNULL(product.name, '') LIKE CONCAT('%', @productname, '%') OR 
        IFNULL(product.internalname, '') LIKE CONCAT('%', @productname, '%')
    )
ORDER BY compressorunit.id;