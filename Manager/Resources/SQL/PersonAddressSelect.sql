SELECT
	personaddress.id,
	personaddress.creation,
	personaddress.ismainaddress,
	personaddress.statusid,
	personaddress.name,
	personaddress.zipcode,
    personaddress.street,
	personaddress.number,
	personaddress.complement,
	personaddress.district,
	personaddress.cityid,
	personaddress.citydocument,
	personaddress.statedocument,	
	personaddress.contributiontypeid,
	IFNULL(personaddress.carrierid, 0) AS carrierid
FROM personaddress
WHERE personaddress.personid = @personid;