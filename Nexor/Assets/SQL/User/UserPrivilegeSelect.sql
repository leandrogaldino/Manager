SELECT
	userprivilege.id,
	userprivilege.creation,
	userprivilege.granteduserid,
	userprivilege.routineid,
	userprivilege.routinename,
	userprivilege.privilegelevelid,
	userprivilege.userid
FROM userprivilege
WHERE userprivilege.granteduserid = @granteduserid;