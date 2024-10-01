SELECT
	requestitem.id,
	requestitem.creation,
	requestitem.statusid,
	requestitem.itemname,
	IFNULL(requestitem.productid, 0) AS productid,
	requestitem.taked,
    requestitem.returned,
	requestitem.applied,
	requestitem.lossed,
	requestitem.lossreason
FROM requestitem
WHERE requestitem.requestid = @requestid;