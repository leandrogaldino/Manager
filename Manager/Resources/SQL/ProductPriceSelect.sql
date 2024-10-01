SELECT
	productprice.id,
	productprice.creation,
	productprice.pricetableid,
	productprice.price
FROM productprice
WHERE productprice.productid = @productid;