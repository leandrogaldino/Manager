UPDATE evaluationreplacedsellable SET
	productid = @productid,
	serviceid = @serviceid,
	quantity = @quantity,
	userid = @userid
WHERE evaluationreplacedsellable.id = @id;
