INSERT INTO evaluationreplacedpart
(
	evaluationid,
	creation,
	itemname,
	productid,
	quantity,
	userid
)
VALUES
(
	@evaluationid,
	@creation,
	@itemname,
	@productid,
	@quantity,
	@userid
);
