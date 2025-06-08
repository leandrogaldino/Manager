SELECT
	pricetablesellable.id,
	pricetablesellable.pricetableid,
	pricetablesellable.creation,
	pricetablesellable.productid,
	pricetablesellable.serviceid,
	pricetablesellable.price,
	IFNULL(product.name, service.name) name,
	IFNULL(productprovidercode.code, '') code
FROM pricetablesellable
LEFT JOIN product ON product.id = pricetablesellable.productid
LEFT JOIN service ON service.id = pricetablesellable.serviceid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE pricetablesellable.pricetableid = @pricetableid
ORDER BY productprovidercode.code, IFNULL(product.name, service.name);