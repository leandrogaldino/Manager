SELECT 
	servicecode.name AS 'Nome',
    servicecode.code AS 'C�digo'
FROM servicecode
WHERE servicecode.serviceid = @serviceid;