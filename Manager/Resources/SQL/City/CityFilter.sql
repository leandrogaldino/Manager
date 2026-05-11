SELECT 
	city.id AS 'ID',
    city.creation AS 'Criação',
    CASE 
		WHEN city.statusid = 0 THEN "ATIVO"
        WHEN city.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    city.name AS 'Nome',
    CONCAT(state.name, ' - ', state.shortname) AS 'Estado',
    city.bigscode AS 'Cód. IBGE'
FROM city
LEFT JOIN cityroute ON cityroute.cityid = city.id
LEFT JOIN route ON route.id = cityroute.routeid
LEFT JOIN state ON state.id = city.stateid
WHERE
	IFNULL(city.id, '') LIKE @id AND
    IFNULL(city.statusid, '') LIKE @statusid AND
    IFNULL(city.name, '') LIKE CONCAT('%', @name, '%') AND
    IFNULL(city.bigscode, '') LIKE CONCAT('%', @bigscode, '%') AND
    (    
        IFNULL(state.name, '') LIKE CONCAT('%', @state, '%') OR 
        IFNULL(state.shortname, '') LIKE CONCAT('%', @state, '%')
    ) AND
    IFNULL(route.name, '') LIKE CONCAT('%', @route, '%')
GROUP BY city.id
ORDER BY city.id;