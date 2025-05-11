SELECT
	productprovidercode.code AS 'C�digo',
	IFNULL(product.name, service.name) AS 'Pe�a/Servi�o',
	sellableprice.price AS 'Pre�o'
FROM sellableprice
INNER JOIN sellablepricetable ON sellablepricetable.id = sellableprice.sellablepricetableid
LEFT JOIN product ON product.id = sellableprice.productid
LEFT JOIN service ON service.id = sellableprice.serviceid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id
LEFT JOIN person ON person.id = productprovidercode.providerid
WHERE sellablepricetable.id = @sellablepricetableid;
