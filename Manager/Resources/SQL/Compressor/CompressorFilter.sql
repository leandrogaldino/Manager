SELECT 
	compressor.id AS 'ID',
    compressor.creation AS 'Criação',
    CASE 
		WHEN compressor.statusid = 0 THEN "ATIVO"
        WHEN compressor.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    compressor.name AS 'Nome',
    manufacturer.name AS 'Fabricante'
FROM compressor
LEFT JOIN person AS manufacturer ON manufacturer.id = compressor.manufacturerid
WHERE
	IFNULL(compressor.id, '') LIKE @id AND
    IFNULL(compressor.statusid, '') LIKE @statusid AND
    IFNULL(compressor.name, '') LIKE CONCAT('%', @name, '%') AND
    IFNULL(manufacturer.id, '') LIKE CONCAT('%', @manufacturerid, '%') AND
    IFNULL(manufacturer.document, '') LIKE CONCAT('%', @manufacturerdocument, '%') AND
    (
        IFNULL(manufacturer.name, '') LIKE CONCAT('%', @manufacturername, '%') OR 
        IFNULL(manufacturer.shortname, '') LIKE CONCAT('%', @manufacturername, '%')
    )
GROUP BY compressor.id
ORDER BY compressor.id;