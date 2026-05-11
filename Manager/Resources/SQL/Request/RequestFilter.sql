SELECT 
	request.id AS 'ID',
    request.creation AS 'Criação',
    CASE 
		WHEN request.statusid = 0 THEN "PENDENTE"
        WHEN request.statusid = 1 THEN "PARCIAL"
        WHEN request.statusid = 2 THEN "CONCLUÍDO"
	END AS 'Status',
    request.destination AS 'Destino',
    request.responsible AS 'Responsável',
    REPLACE(request.note, '\n', ' ') AS 'Observação'
FROM request
LEFT JOIN requestitem ON requestitem.requestid = request.id
LEFT JOIN product ON product.id = requestitem.productid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id
WHERE
	IFNULL(request.id, '') LIKE @id AND
    FIND_IN_SET(request.statusid, @statusid) AND
    IFNULL(request.destination, '') LIKE CONCAT('%', @destination, '%') AND
    IFNULL(request.responsible, '') LIKE CONCAT('%', @responsible, '%') AND
    IFNULL(request.note, '') LIKE CONCAT('%', @note, '%') AND
    (
        IFNULL(requestitem.itemname, '') LIKE CONCAT('%', @item, '%') OR 
        IFNULL(product.name, '') LIKE CONCAT('%', @item, '%') OR
        IFNULL(product.internalname, '') LIKE CONCAT('%', @item, '%') OR
        IFNULL(productprovidercode.code, '') LIKE CONCAT('%', @item, '%')
    ) AND
    CASE WHEN @losseditem = 0 THEN IFNULL(requestitem.lossed, 0) LIKE '%' WHEN @losseditem = 1 THEN IFNULL(requestitem.lossed, 0) > 0  WHEN @losseditem = 2 THEN IFNULL(requestitem.lossed, 0) = 0 END
GROUP BY request.id
ORDER BY request.id;