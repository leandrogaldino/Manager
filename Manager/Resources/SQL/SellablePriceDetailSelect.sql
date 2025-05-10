SELECT
	sellablepricetable.name AS 'Tabela',
	sellableprice.price AS 'Preço'
FROM sellableprice
INNER JOIN sellablepricetable ON sellablepricetable.id = sellableprice.sellablepricetableid
WHERE 
	(@productid IS NULL OR (sellableprice.productid IS NOT NULL AND sellableprice.productid = @productid)) AND
    (@serviceid IS NULL OR (sellableprice.serviceid IS NOT NULL AND sellableprice.serviceid = @serviceid));
