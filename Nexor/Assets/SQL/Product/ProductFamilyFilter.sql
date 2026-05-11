SELECT 
	productfamily.id AS 'ID',
    productfamily.creation AS 'Criação',
    CASE 
		WHEN productfamily.statusid = 0 THEN "ATIVO"
        WHEN productfamily.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    productfamily.name AS 'Nome'
FROM productfamily
WHERE
	IFNULL(productfamily.id, '') LIKE @id AND
    IFNULL(productfamily.statusid, '') LIKE @statusid AND
    IFNULL(productfamily.name, '') LIKE CONCAT('%', @name, '%')
GROUP BY productfamily.id
ORDER BY productfamily.id;