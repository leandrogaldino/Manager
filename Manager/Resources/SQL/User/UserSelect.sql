SELECT
	user.id,
	user.creation,
    user.statusid,
	IFNULL(user.personid, 0) AS personid,
	user.username,
	user.password,
    user.note,
    user.requestnewpassword,
	user.userid
FROM user
WHERE user.id = @id;