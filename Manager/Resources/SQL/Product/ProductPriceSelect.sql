SELECT
	pricetableitem.id,
	pricetableitem.creation,
	product.name product,
    pricetable.id pricetableid,
	pricetable.name pricetablename,
    pricetableitem.price
FROM pricetable
LEFT JOIN pricetableitem ON pricetableitem.pricetableid = pricetable.id
LEFT JOIN product ON product.id = pricetableitem.productid
WHERE product.id = @productid;