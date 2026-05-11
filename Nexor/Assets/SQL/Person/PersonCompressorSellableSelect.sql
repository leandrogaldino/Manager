SELECT
	personcompressorsellable.id,
	personcompressorsellable.creation,
	personcompressorsellable.statusid,
	personcompressorsellable.sellablebindid,
	personcompressorsellable.controltypeid,
	CASE WHEN personcompressorsellable.productid IS NULL THEN 2 WHEN personcompressorsellable.serviceid IS NULL THEN 1 END sellabletypeid,
	personcompressorsellable.productid,
	personcompressorsellable.serviceid,
	IFNULL(product.name, service.name) name,
	IFNULL(productprovidercode.code, '') code,
	personcompressorsellable.quantity,
	personcompressorsellable.capacity
FROM personcompressorsellable
LEFT JOIN product ON product.id = personcompressorsellable.productid
LEFT JOIN service ON service.id = personcompressorsellable.serviceid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE 
	personcompressorsellable.personcompressorid = @personcompressorid AND
	personcompressorsellable.controltypeid = @controltypeid
ORDER BY personcompressorsellable.id;
