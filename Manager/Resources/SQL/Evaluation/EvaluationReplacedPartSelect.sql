SELECT
	evaluationreplacedpart.id,
	evaluationreplacedpart.creation,
	evaluationreplacedpart.productid,
	evaluationreplacedpart.quantity
FROM evaluationreplacedpart
WHERE evaluationreplacedpart.evaluationid = @evaluationid;