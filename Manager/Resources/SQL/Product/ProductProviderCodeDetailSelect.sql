SELECT 
	productprovidercode.ismainprovider AS 'Principal',
	person.shortname AS 'Fornecedor',
    productprovidercode.code AS 'Código'
FROM productprovidercode
INNER JOIN person ON person.id = productprovidercode.providerid
WHERE productprovidercode.productid = @productid;