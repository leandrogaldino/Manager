SELECT
	personcontact.ismaincontact AS 'Principal',
    personcontact.name AS 'Nome',
    personcontact.jobtitle AS 'Cargo',
    personcontact.phone AS 'Telefone',
    personcontact.email AS 'E-Mail'
FROM personcontact
WHERE personcontact.personid = @personid;