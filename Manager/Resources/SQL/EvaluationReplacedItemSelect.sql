SELECT
	evaluationreplaceditem.id,
	evaluationreplaceditem.creation,
	evaluationreplaceditem.itemname,
	IFNULL(evaluationreplaceditem.productid, 0) AS productid,
	evaluationreplaceditem.quantity
FROM evaluationreplaceditem
WHERE evaluationreplaceditem.evaluationid = @evaluationid;