SELECT 
	productgroup.id AS 'ID',
    productgroup.creation AS 'Criação',
    CASE 
		WHEN productgroup.statusid = 0 THEN "ATIVO"
        WHEN productgroup.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    productgroup.name AS 'Nome'
FROM productgroup
WHERE
	IFNULL(productgroup.id, '') LIKE @id AND
    IFNULL(productgroup.statusid, '') LIKE @statusid AND
    IFNULL(productgroup.name, '') LIKE CONCAT('%', @name, '%')
GROUP BY productgroup.id
ORDER BY productgroup.id;