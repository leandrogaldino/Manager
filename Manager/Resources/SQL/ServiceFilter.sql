SELECT 
	service.id AS 'ID',
    service.creation AS 'Cria��o',
    CASE 
		WHEN service.statusid = 0 THEN "ATIVO"
        WHEN service.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    service.name AS 'Nome',
    service.servicecode AS 'C�digo Servi�o',  
    REPLACE(service.note, '\n', ' ') AS 'Observa��o'
FROM service
WHERE
	IFNULL(service.id, '') LIKE @id AND
    IFNULL(service.statusid, '') LIKE @statusid AND
    IFNULL(service.name, '') LIKE CONCAT('%', @name, '%') AND
    IFNULL(service.servicecode, '') LIKE CONCAT('%', @servicecode, '%') AND
    IFNULL(service.note, '') LIKE CONCAT('%', @note, '%')
GROUP BY service.id
ORDER BY service.id;