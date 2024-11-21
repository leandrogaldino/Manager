INSERT INTO userprivilege
(
	creation,
	granteduserid,
	routineid,
	routinename,
	privilegelevelid,
	userid
)
VALUES
(
	@creation,
	@granteduserid,
	@routineid,
	@routinename,
	@privilegelevelid,
	@userid
);
