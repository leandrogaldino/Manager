SELECT 
	productprovidercode.ismainprovider AS 'Principal',
	person.shortname AS 'Fornecedor',
    productprovidercode.code AS 'C�digo'
FROM productprovidercode
INNER JOIN person ON person.id = productprovidercode.providerid
WHERE productprovidercode.productid = @productid;