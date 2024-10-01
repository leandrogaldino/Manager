SELECT
	cashitemresponsible.id,
	cashitemresponsible.creation,
	cashitemresponsible.responsibleid
FROM cashitemresponsible
WHERE cashitemresponsible.cashitemid = @cashitemid;