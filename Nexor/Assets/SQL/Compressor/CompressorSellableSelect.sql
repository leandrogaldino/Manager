SELECT
	compressorsellable.id,
	compressorsellable.creation,
	compressorsellable.statusid,
	compressorsellable.controltypeid,
	CASE WHEN compressorsellable.productid IS NULL THEN 2 WHEN compressorsellable.serviceid IS NULL THEN 1 END sellabletypeid,
	compressorsellable.productid,
	compressorsellable.serviceid,
	compressorsellable.quantity,
	IFNULL(product.name, service.name) name,
	IFNULL(productprovidercode.code, '') code
FROM compressorsellable
LEFT JOIN product ON product.id = compressorsellable.productid
LEFT JOIN service ON service.id = compressorsellable.serviceid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE 
	compressorsellable.compressorid = @compressorid AND
	compressorsellable.controltypeid = @controltypeid
ORDER BY compressorsellable.id;