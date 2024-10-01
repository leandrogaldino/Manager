SELECT 
	productunit.id AS 'ID',
    productunit.creation AS 'Criação',
    CASE 
		WHEN productunit.statusid = 0 THEN "ATIVO"
        WHEN productunit.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    productunit.name AS 'Nome',
    productunit.shortname AS 'Nome Curto'
FROM productunit
WHERE
	IFNULL(productunit.id, '') LIKE @id AND
    IFNULL(productunit.statusid, '') LIKE @statusid AND
    IFNULL(productunit.name, '') LIKE CONCAT('%', @name, '%') AND
    IFNULL(productunit.shortname, '') LIKE CONCAT('%', @name, '%')
GROUP BY productunit.id
ORDER BY productunit.id;