SELECT
	pricetableitem.id,
	pricetableitem.pricetableid,
	pricetableitem.creation,
	pricetableitem.productid,
	pricetableitem.serviceid,
	pricetableitem.price,
	IFNULL(product.name, service.name) name,
	IFNULL(productprovidercode.code, '') code
FROM pricetableitem
LEFT JOIN product ON product.id = pricetableitem.productid
LEFT JOIN service ON service.id = pricetableitem.serviceid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE pricetableitem.pricetableid = @pricetableid
ORDER BY productprovidercode.code, IFNULL(product.name, service.name);