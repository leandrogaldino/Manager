SELECT 
	compressorinterface.id AS 'ID',
    compressorinterface.creation AS 'Criação',
    CASE 
		WHEN compressorinterface.statusid = 0 THEN "ATIVO"
        WHEN compressorinterface.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    compressorinterface.name AS 'Nome',
    CASE
        WHEN productprovidercode.code IS NOT NULL 
             AND productprovidercode.code <> ''
        THEN CONCAT(productprovidercode.code, ' - ', product.name)
        ELSE product.name
    END AS 'Produto',
    CASE 
		WHEN compressorinterface.directionid = 0 THEN "CRESCENTE"
        WHEN compressorinterface.directionid = 1 THEN "DECRESCENTE"
	END AS 'Direção'
FROM compressorinterface
LEFT JOIN product ON compressorinterface.productid = product.id
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE
	IFNULL(compressorinterface.id, '') LIKE @id AND
    IFNULL(compressorinterface.statusid, '') LIKE @statusid AND
    IFNULL(compressorinterface.name, '') LIKE CONCAT('%', @name, '%') AND
    IFNULL(product.id,'') LIKE @productid AND
    IFNULL(productprovidercode.code,'') LIKE @productcode AND
    IFNULL(compressorinterface.directionid, '') LIKE @directionid AND
    (
        IFNULL(product.name, '') LIKE CONCAT('%', @productname, '%') OR 
        IFNULL(product.internalname, '') LIKE CONCAT('%', @productname, '%')
    )
ORDER BY compressorinterface.id;