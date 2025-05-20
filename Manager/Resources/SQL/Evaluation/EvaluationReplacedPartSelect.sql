SELECT
	evaluationreplacedpart.id,
	evaluationreplacedpart.creation,
	evaluationreplacedpart.itemname,
	IFNULL(evaluationreplacedpart.productid, 0) AS productid,
	evaluationreplacedpart.quantity
FROM evaluationreplacedpart
WHERE evaluationreplacedpart.evaluationid = @evaluationid;