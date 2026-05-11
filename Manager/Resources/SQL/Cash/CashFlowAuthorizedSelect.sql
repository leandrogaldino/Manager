SELECT
	cashflowauthorized.id,
	cashflowauthorized.creation,
	cashflowauthorized.authorizedid
FROM cashflowauthorized
WHERE cashflowauthorized.cashflowid = @cashflowid;