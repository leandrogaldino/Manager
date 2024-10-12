SELECT
	cash.id,
	cash.cashflowid,
	cash.creation,
	cash.statusid,
	cash.note,
	cash.documentpath,
	cash.userid
FROM cash
WHERE cash.id = @id;