SELECT
	emailmodel.id,
	emailmodel.creation,
    emailmodel.name,
	emailmodel.subject,
	emailmodel.body,
	IFNULL(emailmodel.signatureid, 0) AS signatureid
FROM emailmodel
WHERE emailmodel.id = @id;