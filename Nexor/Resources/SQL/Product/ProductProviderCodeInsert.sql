INSERT INTO productprovidercode
(
	productid,
	creation,
	ismainprovider,
	code,
	providerid,
	userid
)
VALUES
(
	@productid,
	@creation,
	@ismainprovider,
	@code,
	@providerid,
	@userid
);
