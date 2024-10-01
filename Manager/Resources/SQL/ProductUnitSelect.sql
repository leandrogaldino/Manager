SELECT
	productunit.id,
	productunit.creation,
    productunit.statusid,
	productunit.name,
	productunit.shortname
FROM productunit
WHERE productunit.id = @id;