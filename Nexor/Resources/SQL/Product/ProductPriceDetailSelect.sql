SELECT
	pricetable.name AS 'Tabela de Preços',
    pricetablesellable.price AS 'Preço'
FROM pricetable
LEFT JOIN pricetablesellable ON pricetablesellable.pricetableid = pricetable.id
LEFT JOIN product ON product.id = pricetablesellable.productid
WHERE product.id = @productid;