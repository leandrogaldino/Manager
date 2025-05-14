SELECT 
    CASE
		WHEN pricetableitem.statusid = 0 THEN 'ATIVO'
        WHEN pricetableitem.statusid = 1 THEN 'INATIVO'
	END AS 'Status',
    IFNULL(product.name, service.name) 'Produto/Serviço'
    pricetableitem.price 'Preço'
FROM pricetableitem
LEFT JOIN product ON product.id = pricetableitem.productid
LEFT JOIN service ON service.id = pricetableitem.serviceid
WHERE pricetableitem.pricetableid = @pricetableid;