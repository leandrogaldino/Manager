SELECT 
	productprovidercode.code AS 'C�digo',
	IFNULL(product.name, service.name) AS 'Produto/Servi�o',
    compressorsellable.quantity AS 'Qtd.'
FROM
    compressorsellable
LEFT JOIN product ON product.id = compressorsellable.productid
LEFT JOIN service ON service.id = compressorsellable.serviceid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id AND productprovidercode.ismainprovider = 1
WHERE
    compressorsellable.compressorid = @compressorid AND
    compressorsellable.controltypeid = @controltypeid;