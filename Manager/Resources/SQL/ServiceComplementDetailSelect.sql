SELECT 
	servicecomplement.complement AS 'Complemento'
FROM servicecomplement
WHERE servicecomplement.serviceid = @serviceid;