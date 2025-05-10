SELECT
	sellableprice.id,
	sellableprice.creation,
	sellableprice.sellablepricetableid,
	sellableprice.price
FROM sellableprice
WHERE sellableprice.productid = @productid;