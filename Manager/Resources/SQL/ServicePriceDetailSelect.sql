SELECT
	pricetable.name AS 'Tabela de Preços',
    pricetableitem.price AS 'Preço'
FROM pricetable
LEFT JOIN pricetableitem ON pricetableitem.pricetableid = pricetable.id
LEFT JOIN service ON service.id = pricetableitem.serviceid
WHERE service.id = @serviceid;