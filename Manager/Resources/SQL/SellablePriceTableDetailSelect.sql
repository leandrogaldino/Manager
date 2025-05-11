SELECT
	IFNULL(product.name, service.name) AS 'Produto/Serviço',
	sellableprice.price AS 'Preço'
FROM sellableprice
INNER JOIN sellablepricetable ON sellablepricetable.id = sellableprice.sellablepricetableid
LEFT JOIN product ON product.id = sellableprice.productid
LEFT JOIN service ON service.id = sellableprice.serviceid
WHERE 
	sellablepricetable.id = @sellablepricetableid;
