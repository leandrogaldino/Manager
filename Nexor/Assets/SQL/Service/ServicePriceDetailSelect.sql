SELECT
	pricetable.name AS 'Tabela de Preços',
    pricetablesellable.price AS 'Preço'
FROM pricetable
LEFT JOIN pricetablesellable ON pricetablesellable.pricetableid = pricetable.id
LEFT JOIN service ON service.id = pricetablesellable.serviceid
WHERE service.id = @serviceid;