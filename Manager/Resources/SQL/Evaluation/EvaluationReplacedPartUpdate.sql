UPDATE evaluationreplacedpart SET
	itemname = @itemname,
	productid = @productid,
	quantity = @quantity,
	userid = @userid
WHERE evaluationreplacedpart.id = @id;
