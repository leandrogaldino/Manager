SELECT
	CASE
		WHEN requestitem.statusid = 0 THEN 'PENDENTE'
        WHEN requestitem.statusid = 1 THEN 'PARCIAL'
        WHEN requestitem.statusid = 2 THEN 'CONCLUÍDO'
	END AS 'Status',
    productprovidercode.code AS 'Código',
    IFNULL(requestitem.itemname, product.name) AS 'Item'
FROM requestitem
LEFT JOIN product ON product.id = requestitem.productid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE
	requestitem.requestid = @requestid;