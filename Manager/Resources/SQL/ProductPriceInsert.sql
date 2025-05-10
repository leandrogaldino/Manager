INSERT INTO sellableprice
(
	productid,
	creation,
	sellablepricetableid,
	price,
	userid
)
VALUES
(
	@productid,
	@creation,
	@sellablepricetableid,
	@price,
	@userid
);
