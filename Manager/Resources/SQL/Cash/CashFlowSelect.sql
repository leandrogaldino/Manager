SELECT
	cashflow.id,
	cashflow.creation,
    cashflow.statusid,
	cashflow.name
FROM cashflow
WHERE cashflow.id = @id;