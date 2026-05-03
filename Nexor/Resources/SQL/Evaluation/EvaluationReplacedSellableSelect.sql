SELECT
	evaluationreplacedsellable.id,
	evaluationreplacedsellable.creation,
	CASE WHEN evaluationreplacedsellable.productid IS NULL THEN 2 WHEN evaluationreplacedsellable.serviceid IS NULL THEN 1 END sellabletypeid,
	evaluationreplacedsellable.productid,
	evaluationreplacedsellable.serviceid,
	evaluationreplacedsellable.quantity,
	IFNULL(product.name, service.name) name,
	IFNULL(productprovidercode.code, '') code
FROM evaluationreplacedsellable
LEFT JOIN product ON product.id = evaluationreplacedsellable.productid
LEFT JOIN service ON service.id = evaluationreplacedsellable.serviceid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE evaluationreplacedsellable.evaluationid = @evaluationid;