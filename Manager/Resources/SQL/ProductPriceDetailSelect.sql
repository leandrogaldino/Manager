SELECT
	sellablepricetable.name AS 'Tabela',
	sellablepricetable.price AS 'Pre�o'
FROM sellablepricetable
INNER JOIN sellablepricetable ON sellablepricetable.id = sellablepri.sellablepricetableid
WHERE sellableprice.productid = @productid;
