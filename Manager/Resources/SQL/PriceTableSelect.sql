SELECT
	pricetable.id,
	pricetable.pricetabletypeid,
	pricetable.creation,
    pricetable.statusid,
	pricetable.name
FROM pricetable
WHERE pricetable.id = @id;