SELECT
	request.id,
	request.creation,
    request.statusid,
	request.destination,
	request.responsible,
	request.note,
	request.documentname,	
	request.userid
FROM request
WHERE request.id = @id;