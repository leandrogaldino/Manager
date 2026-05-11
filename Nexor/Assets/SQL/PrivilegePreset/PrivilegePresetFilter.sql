SELECT 
	privilegepreset.id AS 'ID',
    privilegepreset.creation AS 'Criação',
    CASE 
		WHEN privilegepreset.statusid = 0 THEN "ATIVO"
        WHEN privilegepreset.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    privilegepreset.name AS 'Nome'
FROM privilegepreset
WHERE
	IFNULL(privilegepreset.id, '') LIKE @id AND
    IFNULL(privilegepreset.statusid, '') LIKE @statusid AND
    IFNULL(privilegepreset.name, '') LIKE CONCAT('%', @name, '%') 
GROUP BY privilegepreset.id;