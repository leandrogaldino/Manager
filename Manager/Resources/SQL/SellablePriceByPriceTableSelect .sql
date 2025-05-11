SELECT
	sellableprice.id,
	sellableprice.creation,
	sellableprice.sellablepricetableid,
	sellableprice.price,
	sellableprice.productid,
	sellableprice.serviceid
FROM sellableprice
WHERE 
	sellableprice.sellablepricetableid = @sellablepricetableid;