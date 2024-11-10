SELECT
	userprivilege.id,
	userprivilege.creation,
	userprivilege.granteduserid,
	userprivilege.routineid,
	userprivilege.privilegelevelid,
	userprivilege.userid
FROM userprivilege
WHERE userprivilege.granteduserid = @granteduserid;