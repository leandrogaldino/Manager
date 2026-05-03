INSERT INTO servicecode
(
	serviceid,
	creation,
	name,
	code,
	userid
)
VALUES
(
	@serviceid,
	@creation,
	@name,
	@code,
	@userid
);
