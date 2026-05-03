UPDATE personaddress SET
	ismainaddress = @ismainaddress,
	statusid = @statusid,
	name = @name,
    zipcode = @zipcode,
	street = @street,
	number = @number,
	complement = @complement,
	district = @district,
	cityid = @cityid,
	citydocument = @citydocument,
	statedocument = @statedocument,
	contributiontypeid = @contributiontypeid,
	carrierid = @carrierid,
	userid = @userid
WHERE personaddress.id = @id;