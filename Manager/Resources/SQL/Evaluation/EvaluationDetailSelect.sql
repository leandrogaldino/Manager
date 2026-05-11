SELECT 
	IFNULL(product.name, service.name) AS 'Produto/Serviço',
    evaluationcontrolledsellable.currentcapacity AS 'Cap. Atual',
    evaluationcontrolledsellable.sold AS 'Vendido',
    evaluationcontrolledsellable.lost AS 'Perdido'
FROM
    evaluationcontrolledsellable
INNER JOIN personcompressorsellable ON personcompressorsellable.id = evaluationcontrolledsellable.personcompressorsellableid
LEFT JOIN product ON product.id = personcompressorsellable.productid
LEFT JOIN service ON service.id = personcompressorsellable.serviceid
WHERE
    evaluationcontrolledsellable.evaluationid = @evaluationid AND
    personcompressorsellable.controltypeid = @controltypeid;