SELECT 
	pricetable.id AS 'ID',
    pricetable.creation AS 'Criação',
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
    IFNULL(pricetable.statusid, '') LIKE @statusid AND
    IFNULL(pricetable.name, '') LIKE CONCAT('%', @name, '%') AND
    (
        IFNULL(product.name, '') LIKE CONCAT('%', @codeorname, '%') OR
        IFNULL(service.name, '') LIKE CONCAT('%', @codeorname, '%') OR
        IFNULL(productprovidercode.code, '') LIKE CONCAT('%', @codeorname, '%')
    ) AND
    pricetableitem.price BETWEEN @pricemin AND @pricemax AND
GROUP BY pricetable.id
ORDER BY pricetable.id;