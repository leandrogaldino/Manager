SELECT
	servicecode.id,
	servicecode.creation,
	servicecode.name,
	servicecode.code
FROM servicecode
WHERE servicecode.serviceid = @serviceid;