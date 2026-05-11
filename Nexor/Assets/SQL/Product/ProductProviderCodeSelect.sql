SELECT
	productprovidercode.id,
	productprovidercode.creation,
	productprovidercode.ismainprovider,
	productprovidercode.code,
	productprovidercode.providerid
FROM productprovidercode
WHERE productprovidercode.productid = @productid;