UPDATE evaluationreplacedpart SET
	productid = @productid,
	quantity = @quantity,
	userid = @userid
WHERE evaluationreplacedpart.id = @id;
