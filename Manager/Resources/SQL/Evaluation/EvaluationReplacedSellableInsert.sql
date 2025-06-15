INSERT INTO evaluationreplacedpart
(
	evaluationid,
	creation,
	productid,
	quantity,
	userid
)
VALUES
(
	@evaluationid,
	@creation,
	@productid,
	@quantity,
	@userid
);
