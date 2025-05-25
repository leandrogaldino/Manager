SELECT
	pricetable.name AS 'Tabela de Preços',
    pricetableitem.price AS 'Preço'
FROM pricetable
LEFT JOIN pricetableitem ON pricetableitem.pricetableid = pricetable.id
LEFT JOIN product ON product.id = pricetableitem.productid
WHERE product.id = @productid;