SELECT
	pricetable.name AS 'Tabela de Pre�os',
    pricetableitem.price AS 'Pre�o'
FROM pricetable
LEFT JOIN pricetableitem ON pricetableitem.pricetableid = pricetable.id
LEFT JOIN product ON product.id = pricetableitem.productid
WHERE product.id = @productid;