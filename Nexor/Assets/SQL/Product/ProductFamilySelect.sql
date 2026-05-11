SELECT
	productfamily.id,
	productfamily.creation,
    productfamily.statusid,
	productfamily.name
FROM productfamily
WHERE productfamily.id = @id;