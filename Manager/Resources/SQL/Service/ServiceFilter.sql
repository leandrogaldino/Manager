SELECT 
	service.id AS 'ID',
    service.creation AS 'Criação',
    CASE 
		WHEN service.statusid = 0 THEN "ATIVO"
        WHEN service.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    service.name AS 'Nome',
    REPLACE(service.note, '\n', ' ') AS 'Observação'
FROM service
LEFT JOIN servicecode ON servicecode.serviceid = service.id
LEFT JOIN servicecomplement ON servicecomplement.serviceid = service.id
WHERE
	IFNULL(service.id, '') LIKE @id AND
    IFNULL(service.statusid, '') LIKE @statusid AND
    IFNULL(service.name, '') LIKE CONCAT('%', @name, '%') AND
    IFNULL(servicecode.code, '') LIKE CONCAT('%', @code, '%') AND
    IFNULL(servicecomplement.complement, '') LIKE CONCAT('%', @complement, '%') AND
    IFNULL(service.note, '') LIKE CONCAT('%', @note, '%')
GROUP BY service.id
ORDER BY service.id;