SELECT 
	service.id AS 'ID',
    service.creation AS 'Criação',
    CASE 
		WHEN service.statusid = 0 THEN "ATIVO"
        WHEN service.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    service.name AS 'Nome',
    service.servicecode AS 'Código Serviço',  
    REPLACE(service.note, '\n', ' ') AS 'Observação'
FROM service
WHERE
	IFNULL(service.id, '') LIKE @id AND
    IFNULL(service.statusid, '') LIKE @statusid AND
    IFNULL(service.name, '') LIKE CONCAT('%', @name, '%') AND
    IFNULL(service.servicecode, '') LIKE CONCAT('%', @servicecode, '%') AND
    IFNULL(service.note, '') LIKE CONCAT('%', @note, '%')
GROUP BY service.id
ORDER BY service.id;