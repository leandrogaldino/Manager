INSERT INTO productprice
(
	productid,
	creation,
	pricetableid,
	price,
	userid
)
VALUES
(
	@productid,
	@creation,
	@pricetableid,
	@price,
	@userid
);
