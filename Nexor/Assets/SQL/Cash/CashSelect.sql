SELECT
	cash.id,
	cash.cashflowid,
	cash.creation,
	cash.statusid,
	cash.note,
	cash.documentname,
	cash.userid
FROM cash
WHERE cash.id = @id;