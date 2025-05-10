SELECT
	sellableprice.id,
	sellableprice.creation,
	sellableprice.pricetableid,
	sellableprice.price
FROM sellableprice
WHERE sellableprice.productid = @productid;