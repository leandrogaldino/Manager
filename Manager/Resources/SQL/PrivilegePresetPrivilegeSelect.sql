SELECT
	privilegepresetprivilege.id,
	privilegepresetprivilege.creation,
	privilegepresetprivilege.privilegepresetid,
	privilegepresetprivilege.routineid,
	privilegepresetprivilege.routinename,
	privilegepresetprivilege.privilegelevelid,
	privilegepresetprivilege.userid
FROM privilegepresetprivilege
WHERE privilegepresetprivilege.privilegepresetid = @privilegepresetid;