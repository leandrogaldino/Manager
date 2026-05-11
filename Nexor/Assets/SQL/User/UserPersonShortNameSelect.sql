SELECT 
	person.shortname
FROM user
LEFT JOIN person on person.id = user.personid
WHERE
	user.statusid = 0 AND
	user.username <> 'ADMIN'
ORDER BY user.username ASC;