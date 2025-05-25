SELECT
	pricetable.id,
	pricetable.creation,
    pricetable.statusid,
	pricetable.name
FROM pricetable
WHERE pricetable.id = @id;