SELECT 
	emailsignature.id AS 'ID',
    emailsignature.creation AS 'Criação',
    emailsignature.name AS 'Nome'
FROM emailsignature
WHERE
    emailsignature.ofuserid = @ofuserid AND
	IFNULL(emailsignature.id, '') LIKE @id AND
    IFNULL(emailsignature.name, '') LIKE CONCAT('%', @name, '%')
GROUP BY emailsignature.id
ORDER BY emailsignature.id;