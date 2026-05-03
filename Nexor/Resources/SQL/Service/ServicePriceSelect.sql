SELECT
	pricetablesellable.id,
	pricetablesellable.creation,
	service.name service,
    pricetable.id pricetableid,
	pricetable.name pricetablename,
    pricetablesellable.price
FROM pricetable
LEFT JOIN pricetablesellable ON pricetablesellable.pricetableid = pricetable.id
LEFT JOIN service ON service.id = pricetablesellable.serviceid
WHERE service.id = @serviceid;