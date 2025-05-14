SELECT
	pricetableitem.id,
	pricetableitem.pricetableid,
	pricetableitem.creation,
	pricetableitem.productid,
	pricetableitem.serviceid,
	pricetableitem.price
FROM pricetableitem
WHERE pricetableitem.pricetableid = @pricetableid;