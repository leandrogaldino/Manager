SELECT
	productpricetable.name AS 'Tabela',
	productprice.price AS 'Pre�o'
FROM productprice
INNER JOIN productpricetable ON productpricetable.id = productprice.pricetableid
WHERE productprice.productid = @productid;
