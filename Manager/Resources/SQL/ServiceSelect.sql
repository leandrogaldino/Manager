SELECT
	service.id,
	service.creation,
    service.statusid,
	service.name,
	service.servicecode,
	service.note
FROM service
WHERE service.id = @id;