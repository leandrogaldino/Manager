SELECT
	pricetableitem.id,
	pricetableitem.creation,
	service.name service,
    pricetable.id pricetableid,
	pricetable.name pricetablename,
    pricetableitem.price
FROM pricetable
LEFT JOIN pricetableitem ON pricetableitem.pricetableid = pricetable.id
LEFT JOIN service ON service.id = pricetableitem.serviceid
WHERE service.id = @serviceid;