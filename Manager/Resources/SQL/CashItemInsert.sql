INSERT INTO cashitem
(
	cashid,
	creation,
	itemtypeid,
	itemcategoryid,
	description,
	documentdate,
	documentnumber,
	value,
	userid
)
VALUES
(
	@cashid,
	@creation,
	@itemtypeid,
	@itemcategoryid,
	@description,
	@documentdate,
	@documentnumber,
	@value,
	@userid
);
