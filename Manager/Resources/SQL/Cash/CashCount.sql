SELECT
	COUNT(cash.id)
FROM cash 
INNER JOIN cashflow ON cashflow.id = cash.cashflowid
WHERE
	cash.id <> @cashid AND
	cashflow.id = @cashflowid AND
	FIND_IN_SET(cash.statusid, @statusid);