SELECT 
	route.id AS 'ID',
    route.creation AS 'Criação',
    CASE 
		WHEN route.statusid = 0 THEN "ATIVO"
        WHEN route.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    route.name AS 'Nome'
FROM route
WHERE
	IFNULL(route.id, '') LIKE @id AND
    IFNULL(route.statusid, '') LIKE @statusid AND
    IFNULL(route.name, '') LIKE CONCAT('%', @name, '%')
GROUP BY route.id
ORDER BY route.id;