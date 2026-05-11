SELECT 
	emailmodel.id AS 'ID',
    emailmodel.creation AS 'Criação',
    emailmodel.name AS 'Nome'
FROM emailmodel
WHERE
    emailmodel.ofuserid = @ofuserid AND
	IFNULL(emailmodel.id, '') LIKE @id AND
    IFNULL(emailmodel.name, '') LIKE CONCAT('%', @name, '%') AND
    IFNULL(emailmodel.subject, '') LIKE CONCAT('%', @subject, '%') AND
    IFNULL(emailmodel.body, '') LIKE CONCAT('%', @body, '%')
GROUP BY emailmodel.id
ORDER BY emailmodel.id;