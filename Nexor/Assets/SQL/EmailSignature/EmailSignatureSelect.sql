SELECT
	emailsignature.id,
	emailsignature.creation,
    emailsignature.name,
	emailsignature.directoryname
FROM emailsignature
WHERE emailsignature.id = @id;