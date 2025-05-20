SELECT 
	IFNULL(productprovidercode.code, '') 'Código',
    IFNULL(product.name, service.name) 'Produto/Serviço',
    pricetableitem.price 'Preço'
FROM pricetableitem
LEFT JOIN product ON product.id = pricetableitem.productid
LEFT JOIN service ON service.id = pricetableitem.serviceid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE pricetableitem.pricetableid = @pricetableid
ORDER BY productprovidercode.code, IFNULL(product.name, service.name);