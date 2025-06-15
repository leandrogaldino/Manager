SELECT
	compressorsellable.id,
	compressorsellable.creation,
	compressorsellable.statusid,
	compressorsellable.controltypeid,
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