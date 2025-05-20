SELECT
	person.id,
	person.creation,
    person.statusid,
	person.entityid,
	person.iscustomer,
	person.isprovider,
	person.isemployee,
	person.istechnician,
	person.iscarrier,
	person.controlmaintenance,
	person.document,
	person.name,
	person.shortname,
	person.note,
	person.userid
FROM person
WHERE person.id = @id;