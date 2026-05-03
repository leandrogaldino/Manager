SELECT 
	servicecode.name AS 'Nome',
    servicecode.code AS 'Código'
FROM servicecode
WHERE servicecode.serviceid = @serviceid;