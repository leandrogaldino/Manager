SELECT 
	user.id AS 'ID',
    user.creation AS 'Cria��o',
    CASE 
		WHEN user.statusid = 0 THEN "ATIVO"
        WHEN user.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    user.username AS 'Nome de Usu�rio',
    REPLACE(user.note, '\n', ' ') AS 'Observa��o'
FROM user
WHERE
    user.username <> 'ADMIN' AND
    user.username <> 'AGENTE' AND
	IFNULL(user.id, '') LIKE @id AND
    IFNULL(user.statusid, '') LIKE @statusid
GROUP BY user.id;