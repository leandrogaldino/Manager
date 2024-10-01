SELECT
	productpricetable.id,
	productpricetable.creation,
    productpricetable.statusid,
	productpricetable.name
FROM productpricetable
WHERE productpricetable.id = @id;