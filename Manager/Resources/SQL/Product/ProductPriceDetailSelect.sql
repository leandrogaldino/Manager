SELECT
	pricetable.name AS 'Tabela de Pre�os',
    pricetablesellable.price AS 'Pre�o'
FROM pricetable
LEFT JOIN pricetablesellable ON pricetablesellable.pricetableid = pricetable.id
LEFT JOIN product ON product.id = pricetablesellable.productid
WHERE product.id = @productid;