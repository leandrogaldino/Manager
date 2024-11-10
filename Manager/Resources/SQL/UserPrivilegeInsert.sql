INSERT INTO userprivilege
(
	creation,
	granteduserid,
	routineid,
	privilegelevelid,
	userid
)
VALUES
(
	@creation,
	@granteduserid,
	@routineid,
	@privilegelevelid,
	@userid
);
