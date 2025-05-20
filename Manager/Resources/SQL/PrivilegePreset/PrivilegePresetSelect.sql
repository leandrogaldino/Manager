SELECT
	privilegepreset.id,
	privilegepreset.creation,
    privilegepreset.statusid,
	privilegepreset.name
FROM privilegepreset
WHERE privilegepreset.id = @id;