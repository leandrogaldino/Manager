INSERT INTO sellableprice
(
	productid,
	serviceid,
	creation,
	sellablepricetableid,
	price,
	userid
)
VALUES
(
	@productid,
	@serviceid,
	@creation,
	@sellablepricetableid,
	@price,
	@userid
);
