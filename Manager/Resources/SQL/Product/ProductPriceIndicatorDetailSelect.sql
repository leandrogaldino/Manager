SELECT
	productpriceindicator.indicatorid,
    productpriceindicator.price AS 'Pre�o'
FROM productpriceindicator
WHERE productpriceindicator.productid = @productid;