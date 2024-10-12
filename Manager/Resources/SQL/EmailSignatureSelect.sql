SELECT
	emailsignature.id,
	emailsignature.creation,
    emailsignature.name,
	emailsignature.directorypath
FROM emailsignature
WHERE emailsignature.id = @id;