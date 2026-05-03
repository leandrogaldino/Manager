SELECT
	productgroup.id,
	productgroup.creation,
    productgroup.statusid,
	productgroup.name
FROM productgroup
WHERE productgroup.id = @id;