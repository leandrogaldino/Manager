SELECT 
	cashflow.id AS 'ID',
    cashflow.creation AS 'Criação',
    CASE 
		WHEN cashflow.statusid = 0 THEN "ATIVO"
        WHEN cashflow.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    cashflow.name AS 'Nome'
FROM cashflow
WHERE
	IFNULL(cashflow.id, '') LIKE @id AND
    IFNULL(cashflow.statusid, '') LIKE @statusid AND
    IFNULL(cashflow.name, '') LIKE CONCAT('%', @name, '%')
GROUP BY cashflow.id
ORDER BY cashflow.id;