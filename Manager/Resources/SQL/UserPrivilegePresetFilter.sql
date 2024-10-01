SELECT 
	userprivilegepreset.id AS 'ID',
    userprivilegepreset.creation AS 'Criação',
    CASE 
		WHEN userprivilegepreset.statusid = 0 THEN "ATIVO"
        WHEN userprivilegepreset.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    userprivilegepreset.name AS 'Nome'
FROM userprivilegepreset
WHERE
	IFNULL(userprivilegepreset.id, '') LIKE @id AND
    IFNULL(userprivilegepreset.statusid, '') LIKE @statusid AND
    IFNULL(userprivilegepreset.name, '') LIKE CONCAT('%', @name, '%')
GROUP BY userprivilegepreset.id;