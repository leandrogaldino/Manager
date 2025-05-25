SELECT
	productpriceindicator.indicatorid,
    productpriceindicator.price AS 'Preço'
FROM productpriceindicator
WHERE productpriceindicator.productid = @productid;