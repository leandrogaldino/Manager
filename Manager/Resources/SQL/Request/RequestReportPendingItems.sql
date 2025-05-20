SELECT
	request.id,
    request.creation,
    productprovidercode.code,
    IFNULL(requestitem.itemname, product.name) AS part,
    requestitem.taked - requestitem.returned - requestitem.applied - requestitem.lossed as qty,
    request.responsible,
    request.destination
FROM request
LEFT JOIN requestitem ON requestitem.requestid = request.id
LEFT JOIN product ON product.id = requestitem.productid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE 
    requestitem.statusid <> 2 AND 
    request.creation BETWEEN @initialdate AND @finaldate
GROUP BY requestitem.id;