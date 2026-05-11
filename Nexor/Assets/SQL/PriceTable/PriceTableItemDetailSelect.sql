SELECT 
	IFNULL(productprovidercode.code, '') 'Código',
    IFNULL(product.name, service.name) 'Produto/Serviço',
    pricetablesellable.price 'Preço'
FROM pricetablesellable
LEFT JOIN product ON product.id = pricetablesellable.productid
LEFT JOIN service ON service.id = pricetablesellable.serviceid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE pricetablesellable.pricetableid = @pricetableid
ORDER BY productprovidercode.code, IFNULL(product.name, service.name);