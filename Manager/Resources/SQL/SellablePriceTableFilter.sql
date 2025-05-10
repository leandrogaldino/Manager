SELECT 
	sellablepricetable.id AS 'ID',
    sellablepricetable.creation AS 'Criação',
    CASE 
		WHEN sellablepricetable.statusid = 0 THEN "ATIVO"
        WHEN sellablepricetable.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    sellablepricetable.name AS 'Nome'
FROM sellablepricetable
WHERE
	IFNULL(sellablepricetable.id, '') LIKE @id AND
    IFNULL(sellablepricetable.statusid, '') LIKE @statusid AND
    IFNULL(sellablepricetable.name, '') LIKE CONCAT('%', @name, '%')
GROUP BY sellablepricetable.id
ORDER BY sellablepricetable.id;