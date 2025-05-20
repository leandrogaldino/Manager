SELECT 
    emailsent.id AS 'ID',
    emailsent.sentdate AS 'Data',
    emailsent.fromemail AS 'De',
    emailsent.subject AS 'Assunto',
    emailsent.toemail AS 'Para',
    emailsent.ccemail AS 'Cópia',
    emailsent.bccemail AS 'Cópia Oculta',
    emailsent.attachment AS 'Anexos'
FROM emailsent
WHERE
    emailsent.ofuserid = @ofuserid AND
    IFNULL(emailsent.fromemail, '') LIKE CONCAT('%', @fromemail, '%') AND
    IFNULL(emailsent.subject, '') LIKE CONCAT('%', @subject, '%') AND
    IFNULL(emailsent.toemail, '') LIKE CONCAT('%', @toemail, '%') AND
    IFNULL(emailsent.ccemail, '') LIKE CONCAT('%', @ccemail, '%') AND
    IFNULL(emailsent.bccemail, '') LIKE CONCAT('%', @bccemail, '%') AND
    emailsent.sentdate BETWEEN @datei AND @datef
GROUP BY emailsent.id
ORDER BY emailsent.id;