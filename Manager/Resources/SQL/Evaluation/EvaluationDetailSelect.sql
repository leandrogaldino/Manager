SELECT 
	IFNULL(personcompressorpart.itemname, product.name) AS 'Item',
    evaluationpart.currentcapacity AS 'Cap. Atual',
    evaluationpart.sold AS 'Vendido',
    evaluationpart.lost AS 'Perdido'
FROM
    evaluationpart
INNER JOIN personcompressorpart ON personcompressorpart.id = evaluationpart.personcompressorpartid
LEFT JOIN product ON product.id = personcompressorpart.productid
WHERE
    evaluationpart.evaluationid = @evaluationid AND
    personcompressorpart.parttypeid = @parttypeid;