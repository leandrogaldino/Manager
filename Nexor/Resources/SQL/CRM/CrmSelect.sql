SELECT
	crm.id,
	crm.creation,
    crm.statusid,
	crm.customerid,
	crm.responsibleid,
	crm.subject,
	crm.userid
FROM crm
WHERE crm.id = @id;