INSERT INTO evaluationreplacedsellable
(
	evaluationid,
	creation,
	productid,
	serviceid,
	quantity,
	userid
)
VALUES
(
	@evaluationid,
	@creation,
	@productid,
	@serviceid,
	@quantity,
	@userid
);
