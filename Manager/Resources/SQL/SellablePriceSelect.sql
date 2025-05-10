SELECT
	sellableprice.id,
	sellableprice.creation,
	sellableprice.sellablepricetableid,
	sellableprice.price
FROM sellableprice
WHERE 
(@productid IS NULL OR (sellableprice.productid IS NOT NULL AND sellableprice.productid = @productid))
    AND
    (@serviceid IS NULL OR (sellableprice.serviceid IS NOT NULL AND sellableprice.serviceid = @serviceid));