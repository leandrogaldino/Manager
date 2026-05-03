SELECT
	productpriceindicator.id,
	productpriceindicator.creation,
	productpriceindicator.productid,
    productpriceindicator.indicatorid,
    productpriceindicator.price
FROM productpriceindicator
WHERE productpriceindicator.productid = @productid;