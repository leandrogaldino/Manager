SELECT 
	pricetable.id AS 'ID',
    pricetable.creation AS 'Criação',
    CASE 
		WHEN pricetable.pricetabletypeid = 0 THEN "USUÁRIO"
        WHEN pricetable.pricetabletypeid = 1 THEN "SISTEMA"
	END AS 'Tipo',
    CASE 
		WHEN pricetable.statusid = 0 THEN "ATIVO"
        WHEN pricetable.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    pricetable.name AS 'Nome'
FROM pricetable
LEFT JOIN pricetableitem ON pricetableitem.pricetableid = pricetable.id
LEFT JOIN product ON product.id = pricetableitem.productid
LEFT JOIN service ON service.id = pricetableitem.serviceid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id
WHERE
	IFNULL(pricetable.id, '') LIKE @id AND
    IFNULL(pricetable.pricetabletypeid, '') LIKE @pricetabletypeid AND
    IFNULL(pricetable.statusid, '') LIKE @statusid AND
    IFNULL(pricetable.name, '') LIKE CONCAT('%', @name, '%') AND
    (
        IFNULL(product.name, '') LIKE CONCAT('%', @productorservice, '%') OR
        IFNULL(service.name, '') LIKE CONCAT('%', @productorservice, '%') OR
        IFNULL(productprovidercode.code, '') LIKE CONCAT('%', @productorservice, '%')
    )
GROUP BY pricetable.id
ORDER BY pricetable.id;