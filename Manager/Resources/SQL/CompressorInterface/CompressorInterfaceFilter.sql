SELECT 
	compressorinterface.id AS 'ID',
    compressorinterface.creation AS 'Criação',
    CASE 
		WHEN compressorinterface.statusid = 0 THEN "ATIVO"
        WHEN compressorinterface.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    compressorinterface.name AS 'Nome'
    productprovidercode.code AS 'Código',
    product.name AS 'Produto'
FROM compressorinterface
LEFT JOIN product ON compressorinterface.productid = product.id
WHERE
	IFNULL(compressorinterface.id, '') LIKE @id AND
    IFNULL(compressorinterface.statusid, '') LIKE @statusid AND
    IFNULL(compressorinterface.name, '') LIKE CONCAT('%', @name, '%') AND
    IFNULL(product.id,'') LIKE @productid AND
    IFNULL(productprovidercode.code,'') LIKE @productcode AND
    (
        IFNULL(product.name, '') LIKE CONCAT('%', @productname, '%') OR 
        IFNULL(product.shortname, '') LIKE CONCAT('%', @productname, '%')
    )
GROUP BY compressorinterface.id
ORDER BY compressorinterface.id;