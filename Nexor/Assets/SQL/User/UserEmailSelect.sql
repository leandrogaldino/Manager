SELECT
	useremail.id,
	useremail.creation,
	useremail.ismainemail,
    useremail.host,
	useremail.port,
	useremail.email,
    useremail.password,
    useremail.enablessl,
	useremail.userid
FROM useremail
WHERE useremail.ofuserid = @ofuserid;