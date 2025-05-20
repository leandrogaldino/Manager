INSERT INTO privilegepresetprivilege
(
	creation,
	privilegepresetid,
	routineid,
	routinename,
	privilegelevelid,
	userid
)
VALUES
(
	@creation,
	@privilegepresetid,
	@routineid,
	@routinename,
	@privilegelevelid,
	@userid
);
