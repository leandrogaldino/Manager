SELECT
    r.id requestid,
    r.responsible,
    r.destination,
    ri.id itemid,
    ri.productid,
    pc.code,
    p.name,
    ri.taked - ri.returned - ri.applied - ri.lossed AS pending
FROM requestitem ri
JOIN product p ON p.id = ri.productid
JOIN request r ON r.id = ri.requestid
LEFT join productprovidercode pc on pc.productid = p.id AND pc.ismainprovider = 1
WHERE
    ri.statusid = 0
    AND ri.productid IN (@inclause)
ORDER BY r.id DESC