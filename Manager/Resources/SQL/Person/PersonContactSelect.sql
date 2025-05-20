SELECT
	personcontact.id,
	personcontact.creation,
	personcontact.ismaincontact,
	personcontact.name,
    personcontact.jobtitle,
	personcontact.phone,
	personcontact.email
FROM personcontact
WHERE personcontact.personid = @personid;