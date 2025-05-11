SELECT
	productprovidercode.code AS 'Código',
	IFNULL(product.name, service.name) AS 'Peça/Serviço',
	sellableprice.price AS 'Preço'
FROM sellableprice
INNER JOIN sellablepricetable ON sellablepricetable.id = sellableprice.sellablepricetableid
LEFT JOIN product ON product.id = sellableprice.productid
LEFT JOIN service ON service.id = sellableprice.serviceid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id
LEFT JOIN person ON person.id = productprovidercode.providerid
WHERE sellablepricetable.id = @sellablepricetableid;
