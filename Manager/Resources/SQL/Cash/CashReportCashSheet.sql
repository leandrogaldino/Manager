SELECT
	cash.cashflowid,
	cashitem.documentdate,
    cashitem.description,
	cashitem.documentnumber,
    cashitem.value
FROM cashitem
INNER JOIN cash on cash.id = cashitem.cashid
WHERE 
	cashitem.cashid = @cashid AND
    cashitem.itemtypeid = @itemtypeid;