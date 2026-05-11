SELECT
	pricetablesellable.id,
	pricetablesellable.creation,
	product.name product,
    pricetable.id pricetableid,
	pricetable.name pricetablename,
    pricetablesellable.price
FROM pricetable
LEFT JOIN pricetablesellable ON pricetablesellable.pricetableid = pricetable.id
LEFT JOIN product ON product.id = pricetablesellable.productid
WHERE product.id = @productid;