UPDATE person SET
	id = @id,
    statusid = @statusid,
	entityid = @entityid,
	iscustomer = @iscustomer,
	isprovider = @isprovider,
	isemployee = @isemployee,
	istechnician = @istechnician,
	iscarrier = @iscarrier,
	controlmaintenance = @controlmaintenance,
	document = @document,
	name = @name,
	shortname = @shortname,
	note = @note,
	userid = @userid
WHERE person.id = @id;