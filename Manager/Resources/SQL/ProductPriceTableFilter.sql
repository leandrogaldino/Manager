SELECT 
	productpricetable.id AS 'ID',
    productpricetable.creation AS 'Criação',
    CASE 
		WHEN productpricetable.statusid = 0 THEN "ATIVO"
        WHEN productpricetable.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    productpricetable.name AS 'Nome'
FROM productpricetable
WHERE
	IFNULL(productpricetable.id, '') LIKE @id AND
    IFNULL(productpricetable.statusid, '') LIKE @statusid AND
    IFNULL(productpricetable.name, '') LIKE CONCAT('%', @name, '%')
GROUP BY productpricetable.id
ORDER BY productpricetable.id;